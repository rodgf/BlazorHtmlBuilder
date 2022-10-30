using System.Collections.Generic;

namespace HtmlBuilder.Builder {

  //
  public class DummyForm {

    //
    public List<ControlDetails> GetControlDetails() {
      List<ControlDetails> result = new List<ControlDetails> {
        new ControlDetails { Type = "TextEdit", Label = "First Name", IsRequired = true },
        new ControlDetails { Type = "TextEdit", Label = "Last Name", IsRequired = true },
        new ControlDetails { Type = "DateEdit", Label = "Birth Date", IsRequired = false }
      };
      return result;
    }
  }
}
