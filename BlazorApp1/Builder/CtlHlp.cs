using System.Collections.Generic;
using System.Reflection;

namespace HtmlBuilder.Builder {

  // Compose and combine html elements
  public class CtlHlp {

    // Combine HTML Controls
    public static string Combine(List<Control> controls) {
      string xml = "";

      foreach (Control control in controls) {
        xml += Compose(control);
      }

      return xml;
    }

    // Combine tags and nested tags
    public static string Compose(Control control, string xml = "") {
      string stXML = xml;

      // Prepare element
      control.OnRender();

      // Content list
      if (control.ControlDetailsList.Count > 0 && !string.IsNullOrEmpty(control.ControlDetails.XML)) {
        stXML += control.ControlDetails.XML;
      } else {

        // Open tag
        stXML += OpenTag(control);

        // Contents
        if (!string.IsNullOrEmpty(control.ControlDetails.XML))
          stXML += control.ControlDetails.XML;

        // Nested elements
        foreach (ControlDetails cd in control.ControlDetailsList) {
          stXML += cd.XML + "\n";
        }

        // Nested controls
        foreach (Control child in control.Controls) {
          stXML = Compose(child, stXML);
        }

        // Close tag
        stXML += "</" + control.TagName + ">\n";
      }

      control.ControlDetails.XML = stXML;
      return stXML;
    }

    // Compose the open tag
    private static string OpenTag(Control control) {
      string openTag = "<" + control.TagName + " ";

      PropertyInfo[] properties = typeof(ControlDetails).GetProperties();
      foreach (PropertyInfo property in properties) {
        if (property.GetValue(control.ControlDetails) != null
            && property.PropertyType == typeof(string)
            && property.Name != "XML") {
          if (!string.IsNullOrEmpty(property.GetValue(control.ControlDetails).ToString())) {
            openTag += property.Name.ToLower() + "='" + property.GetValue(control.ControlDetails).ToString() + "' ";
          }
        }
      }
      foreach (KeyValuePair<string, string> attr in control.ControlDetails.Data) {
        openTag += attr.Key.ToLower() + "='" + attr.Value + "' ";
      }
      openTag += ">\n";

      return openTag;
    }
  }
}
