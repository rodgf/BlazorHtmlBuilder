using System;
using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  // Generic control class
  public abstract class Control : ICloneable {
    public string TagName { get; set; }
    public ControlDetails ControlDetails { get; set; } = new ControlDetails();
    public List<ControlDetails> ControlDetailsList { get; set; } = new List<ControlDetails>();
    public List<Control> Controls { get; set; } = new List<Control>();

    public object Clone() {
      return this.MemberwiseClone();
    }

    public virtual void OnRender() { }
  }
}
