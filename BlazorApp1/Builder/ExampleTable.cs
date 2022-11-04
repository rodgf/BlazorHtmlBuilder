using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace HtmlBuilder.Builder {

  // RenderFragment based HTML element
  public class ExampleTable {
    public Dictionary<string, string> Rows { get; set; } = new Dictionary<string, string>();

    // Compose element
    public  RenderFragment Create() => builder => {
      int i = 0;
      int ii = 0;
      builder.OpenElement(0, "table");
      foreach (KeyValuePair<string, string> row in Rows) {
        builder.OpenElement(++i, "tr");
        builder.OpenElement(++i, "td");
        builder.AddAttribute(++i, "style", "width: 150px;");
        builder.AddContent(++i, Rows.ElementAt(ii).Key);
        builder.CloseElement();
        builder.OpenElement(++i, "td");
        builder.AddAttribute(++i, "style", "width: 150px;");
        builder.AddContent(++i, Rows.ElementAt(ii++).Value);
        builder.CloseElement();
        builder.CloseElement();
      }
      builder.CloseElement();
    };
  }
}
