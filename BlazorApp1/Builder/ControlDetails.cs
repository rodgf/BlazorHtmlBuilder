using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  // For child elements
  public class ControlDetails {
    public string Label { get; set; }
    public string ID { get; set; } = "";
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public string Class { get; set; } = "";
    public string Style { get; set; } = "";
    public string Title { get; set; } = "";
    public string Placeholder { get; set; } = "";
    public string Colspan { get; set; } = "";
    public string Rowspan { get; set; } = "";
    public string Size { get; set; } = "";
    public string MaxLength { get; set; } = "";
    public string Value { get; set; }
    public string Src { get; set; }
    public string Onclick { get; set; }
    public string Onchange { get; set; }
    public string Checked { get; set; } = "";
    public string Selected { get; set; } = "";
    public string SelectedValue { get; set; } = "";
    public string SelectedIndex { get; set; } = "";
    public string Required { get; set; } = "";
    public string Readonly { get; set; } = "";
    public Dictionary<string, string> Data = new Dictionary<string, string>();
    public string XML { get; set; } = ""; // element body
  }
}
