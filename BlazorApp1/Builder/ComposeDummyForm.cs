using System.Collections.Generic;
using System.Linq;

namespace HtmlBuilder.Builder {

  // Html Control Example
  public class ComposeDummyForm {
    private Dictionary<string, string> Values;

    // User entry form
    public Control User() {
      DummyForm df = new DummyForm();
      df.TagName = "div";
      df.ControlDetails.Class = "formGen";
      Values = df.ControlDetailsList.ToDictionary(c => c.Label, c => "");

      // Mount elements
      foreach (ControlDetails control in df.ControlDetailsList) {

        // Labels
        if (control.Required == "true") {
          control.XML = "<div>" + control.Label + "*</div>";
        } else {
          control.XML = "<div>" + @control.Label + "</div>";
        }

        // Fields
        switch (control.Type) {
          case "TextEdit":
            control.XML += "<input name='" + control.Name + "' title='" + control.Title + "' placeHolder='" + control.Placeholder + "'  required='" + control.Required + "' />";
            break;

          case "DateEdit":
            control.XML += "<input name='" + control.Name + "' title='" + control.Title + "' placeHolder='" + control.Placeholder + "' type='date' value='" + Values[control.Label] + "' required='" + control.Required + "' />";
            break;
        }
      }

      // Summary text
      df.Controls.Add(new DummySummary() {
        ControlDetails = new ControlDetails() {
          Style = "color: blue; padding: 20px;",
          Data = new Dictionary<string, string>() { { "data-dummy", "dummy data" } },
          XML = "This form is mainly used to record basic user entries."
        }
      });

      return df;
    }
  }
}
