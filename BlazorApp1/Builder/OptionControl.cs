namespace HtmlBuilder.Builder {

  //
  public class OptionControl : Control {
    private string _value;
    private string _xml;
    private string _selected;

    public OptionControl() {
      TagName = "option";
    }

    public OptionControl(string value) : this() {
      _value = value;
      _xml = value;
    }

    public OptionControl(string value, string text) : this() {
      _value = value;
      _xml = text;
    }

    public OptionControl(string value, string text, string selected) : this() {
      _value = value;
      _xml = text;
      _selected = selected;
    }

    public override void OnRender() {
      if (_value != null)
        ControlDetails.Value = _value;
      if (_xml != null)
        ControlDetails.XML = _xml;
      if (_selected != null)
        ControlDetails.Selected = _selected;
    }
  }
}
