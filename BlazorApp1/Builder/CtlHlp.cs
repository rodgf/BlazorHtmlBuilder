using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HtmlBuilder.Builder {

  // Compose and combine html elements
  public static class CtlHlp {

    // Combine HTML Controls
    public static string Combine(List<Control> controls) {
      string xml = "";

      foreach (Control control in controls) {
        xml += Compose(control);
      }

      return xml;
    }

    // Combine tags and nested tags
    public static string Compose(Control control, string xml = "", Control parent = null, int i = 0) {
      string stXML = xml;

      // Prepare element
      control.OnRender();

      // Content list
      if (control.ControlDetailsList.Count > 0 && !string.IsNullOrEmpty(control.ControlDetails.XML)) {
        stXML += control.ControlDetails.XML;
      } else {

        // Open tag
        stXML += OpenTag(control, parent, i);

        // Contents
        if (!string.IsNullOrEmpty(control.ControlDetails.XML))
          stXML += control.ControlDetails.XML;

        // Nested elements
        foreach (ControlDetails cd in control.ControlDetailsList) {
          stXML += cd.XML + "\n";
        }

        // Nested controls
        int ii = 0;
        foreach (Control child in control.Controls) {
          if (!FindComposed(control, child)) {
            stXML = Compose(child, stXML, control, ii);
          } else {
            Control clone = (Control)child.Clone();
            clone.ControlDetails.XML = "";
            clone.ControlDetails.ID = Guid.NewGuid().ToString("N");
            stXML = Compose(clone, stXML, control, ii);
          }
          ii++;
        }

        // Close tag
        stXML += "</" + control.TagName + ">\n";
      }

      control.ControlDetails.XML = stXML;
      return stXML;
    }

    // Compose the open tag
    private static string OpenTag(Control control, Control parent, int i) {
      string openTag = "<" + control.TagName;

      if (parent != null && parent.ControlDetails.SelectedValue == control.ControlDetails.Value)
        control.ControlDetails.Selected = "selected";
      if (parent != null && !string.IsNullOrEmpty(parent.ControlDetails.SelectedIndex) && i == int.Parse(parent.ControlDetails.SelectedIndex))
        control.ControlDetails.Selected = "selected";
      PropertyInfo[] properties = typeof(ControlDetails).GetProperties();
      foreach (PropertyInfo property in properties) {
        if (property.GetValue(control.ControlDetails) != null
            && property.PropertyType == typeof(string)
            && property.Name != "XML") {
          if (!string.IsNullOrEmpty(property.GetValue(control.ControlDetails).ToString())) {
            openTag += " " + property.Name.ToLower() + "='" + property.GetValue(control.ControlDetails).ToString() + "' ";
          }
        }
      }
      foreach (KeyValuePair<string, string> attr in control.ControlDetails.Data) {
        openTag += " " + attr.Key.ToLower() + "='" + attr.Value + "'";
      }
      openTag += ">\n";

      return openTag;
    }

    // Deep clean Control
    public static void WipeControl(Control control) {
      for (int i = 0; i < control.Controls.Count(); i++) {
        WipeControl(control.Controls[i]);
        control.Controls[i] = null;
      }
      control.Controls.Clear();
    }

    // Find child in Control
    public static bool FindComposed(Control control, Control child) {
      bool found = false;
      foreach (Control item in control.Controls) {
        if (string.IsNullOrEmpty(item.ControlDetails.ID))
          item.ControlDetails.ID = Guid.NewGuid().ToString("N");
        if (item.Equals(child)
            && item.ControlDetails.XML.Contains(item.ControlDetails.ID)) {
          found = true;
          break;
        }
        found = FindComposed(child, item);
        if (found)
          break;
      }

      return found;
    }

    // Show/hide html control
    public static void Show(this Control control, bool visible = true) {
      control.ControlDetails.Class = control.ControlDetails.Class.Replace("oculta", "").Trim();
      if (!visible) {
        control.ControlDetails.Class += " oculta";
      }
    }

    // Enable/disable html control
    public static void Enable(this Control control, bool visible = true) {
      control.ControlDetails.Class = control.ControlDetails.Class.Replace("desabilita", "").Trim();
      if (!visible) {
        control.ControlDetails.Class += " desabilita";
      }
    }

    // Add element and return similar position index
    public static int AddPos(this Control control, Control controlSrc) {
      int pos = control.Controls.Where(_ => _.TagName.ToLower().Trim() == controlSrc.TagName.ToLower().Trim()).Count();
      control.Controls.Add(controlSrc);

      return pos;
    }
  }
}
