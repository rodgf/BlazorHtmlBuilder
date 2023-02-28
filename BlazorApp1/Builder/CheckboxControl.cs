
namespace HtmlBuilder.Builder {

  //
  public class CheckboxControl: Control {
    public string Command { get; set; } = "";
    public string Text { get; set; }

    public CheckboxControl() {
      TagName = "input";      
    }

    public override void OnRender() {
      ControlDetails.Type = "checkbox";
      if (!string.IsNullOrEmpty(Text))
        ControlDetails.Data.Add("data-text", Text);
      ControlDetails.Onchange = "checkboxSwitcher(\"" + Command + "\", this.id, this.checked, this.dataset.text.length)";
    }
  }
}
