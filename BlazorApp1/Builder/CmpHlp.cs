using Microsoft.AspNetCore.Components;

namespace HtmlBuilder.Builder {

  // Helper for component manipulate
  public class CmpHlp {

    // Create a coponent based RenderFragment
    public static RenderFragment ComposeExample(string id, string msg) => builder => {
      builder.OpenComponent(0, typeof(ExampleComponent));
      builder.AddAttribute(1, "ID", id);
      builder.AddAttribute(3, "Msg", msg);
      builder.CloseComponent();
    };
  }
}
