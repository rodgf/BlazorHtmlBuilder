
namespace HtmlBuilder.Builder {

  //
  public class ImageButtonControl: Control {

    public ImageButtonControl() {
      TagName = "input";
    }

    public override void OnRender() {
      ControlDetails.Type = "image";
    }
  }
}
