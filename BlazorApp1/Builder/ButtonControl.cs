using System.Diagnostics;

namespace HtmlBuilder.Builder {

  //
  public class ButtonControl: Control {
    public string Command { get; set; } = "";
    public string CommandName { get; set; }
    public string CommandArgument { get; set; }

    public ButtonControl() {
      TagName = "button";
    }

    public ButtonControl(string command, string commandName, string commandArgument): this() {
      Command = command.Trim().ToLower();
      CommandName = commandName.Trim().ToLower();
      CommandArgument = commandArgument;
    }

    public override void OnRender() {
      ControlDetails.Type = "button";
      if (!string.IsNullOrEmpty(Command))
        ControlDetails.Onclick = "commandSwitcher(\"" + Command + "\", this.id, \"" + CommandName + "\",\"" + CommandArgument + "\")";
    }
  }
}
