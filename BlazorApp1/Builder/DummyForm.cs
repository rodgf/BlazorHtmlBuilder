using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  // Control example
  public class DummyForm: Control {

    public DummyForm() {
      ControlDetailsList = new List<ControlDetails>() {
        new ControlDetails { Type = "TextEdit", Name="FirstName", Title="User`s first name", Placeholder = "", Label = "First Name", IsRequired = true },
        new ControlDetails { Type = "TextEdit", Name="LastName", Title="User`s first name", Placeholder = "", Label = "Last Name", IsRequired = true },
        new ControlDetails { Type = "DateEdit", Name="BirthDate", Title="User`s first name", Placeholder = "", Label = "Birth Date", IsRequired = false }
      };
    }
  }
}
