using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  // Control example
  public class DummyForm: Control {

    public DummyForm() {
      ControlDetailsList = new List<ControlDetails>() {
        new ControlDetails { Type = "TextEdit", Name="FirstName", Title="User`s first name", Placeholder = "", Label = "First Name", Required = "true" },
        new ControlDetails { Type = "TextEdit", Name="LastName", Title="User`s last name", Placeholder = "", Label = "Last Name", Required = "true" },
        new ControlDetails { Type = "DateEdit", Name="BirthDate", Title="User`s birth date", Placeholder = "", Label = "Birth Date", Required = "false" }
      };
    }
  }
}
