using System.Collections.Generic;
using System.Linq;

namespace HtmlBuilder.Builder {

  //
  public class MontaDummyForm {
    private List<ControlDetails> ControlList;
    private Dictionary<string, string> Values;

    // Form de entrada do usuário
    public List<ControlDetails> Usuario() {
      DummyForm cf = new DummyForm();
      ControlList = cf.GetControlDetails();
      Values = ControlList.ToDictionary(c => c.Label, c => "");

      // Monta elementos
      foreach (ControlDetails control in ControlList) {

        // Rótulos
        if (control.IsRequired) {
          control.XML = "<div>" + control.Label + "*</div>";
        } else {
          control.XML = "<div>" + @control.Label + "</div>";
        }

        // Campos
        switch (control.Type) {
          case "TextEdit":
            control.XML += "<input value='" + Values[control.Label] + "' required=" + control.IsRequired + "/>";
            break;

          case "DateEdit":
            control.XML += "<input type='date' value='" + Values[control.Label] + "' onchange='ValueChanged(a, label)' required=" + control.IsRequired + "/>";
            break;
        }
      }

      return ControlList;
    }
  }
}
