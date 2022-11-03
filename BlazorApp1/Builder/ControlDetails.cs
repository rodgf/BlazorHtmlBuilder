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
    public string XML { get; set; } = "";
    public bool IsRequired { get; set; } = false;
  }
}
