namespace HtmlBuilder.Builder {

  //
  public class OptionControl : Control {
    private string _value;
    private string _selected;

    public string Text { get; set; }

    public OptionControl() {
      TagName = "option";
    }

    public OptionControl(string value) : this() {
      _value = value;
      Text = value;
    }

    public OptionControl(string value, string text) : this() {
      _value = value;
      Text = text;
    }

    public OptionControl(string value, string text, string selected) : this() {
      _value = value;
      Text = text;
      _selected = selected;
    }

    public override void OnRender() {
      if (_value != null)
        ControlDetails.Value = _value;
      if (Text != null)
        ControlDetails.XML = Text;
      if (_selected != null)
        ControlDetails.Selected = _selected;
    }
  }
}
