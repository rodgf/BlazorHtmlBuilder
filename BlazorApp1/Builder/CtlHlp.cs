using System.Collections.Generic;

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
    public static string Compose(Control control) {
      string xml = "";

      // Open tag
      xml += "<" + control.TagName +
        " id='" + control.ControlDetails.ID +
        "' name='" + control.ControlDetails.Name +
        "' type='" + control.ControlDetails.Type +
        "' class='" + control.ControlDetails.Class +
        "' style='" + control.ControlDetails.Style +
        "' required=" + control.ControlDetails.IsRequired + "/>\n";

      // Content
      xml += control.ControlDetails.XML;

      // Nested elements
      foreach (ControlDetails cd in control.ControlDetailsList) {
        xml += cd.XML + "\n";
      }

      // Nested controls
      foreach (Control child in control.Controls) {
        xml += Compose(child);
      }

      // Close tag
      xml += "</" + control.TagName + ">\n";

      return xml;
    }
  }
}
