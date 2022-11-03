using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  // Generic control class
  public abstract class Control {
    public string TagName { get; set; }
    public ControlDetails ControlDetails { get; set; } = new ControlDetails();
    public List<ControlDetails> ControlDetailsList { get; set; } = new List<ControlDetails>();
  }
}
