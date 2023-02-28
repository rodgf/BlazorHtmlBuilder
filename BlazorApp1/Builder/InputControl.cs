namespace HtmlBuilder.Builder {

  //
  public class InputControl : Control {
    private string _type;

    public InputControl() {
      TagName = "input";
    }

    public InputControl(string type) {
      TagName = "input";
      _type = type;
    }

    public override void OnRender() {
      if (_type != null) {
        ControlDetails.Type = _type;
      }
    }
  }
}
