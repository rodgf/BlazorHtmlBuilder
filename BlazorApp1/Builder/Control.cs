using System;
using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  // Generic control class
  public abstract class Control : ICloneable, IDisposable {
    private bool disposedValue;

    public string TagName { get; set; }
    public ControlDetails ControlDetails { get; set; } = new ControlDetails();
    public List<ControlDetails> ControlDetailsList { get; set; } = new List<ControlDetails>();
    public List<Control> Controls { get; set; } = new List<Control>();

    public object Clone() {
      Control c = (Control)this.MemberwiseClone();
      c.ControlDetails = (ControlDetails)c.ControlDetails.Clone();
      c.Controls = new List<Control>();
      foreach (Control control in this.Controls)
        c.Controls.Add((Control)control.Clone());
      c.ControlDetailsList = new List<ControlDetails>();
      foreach (ControlDetails cd in this.ControlDetailsList)
        c.ControlDetailsList.Add((ControlDetails)cd.Clone());
      return c;
    }

    public virtual void OnRender() { }

    protected virtual void Dispose(bool disposing) {
      if (!disposedValue) {
        if (disposing) {
          // dispose managed state (managed objects)
        }

        disposedValue = true;
      }
    }

    public void Dispose() {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}
