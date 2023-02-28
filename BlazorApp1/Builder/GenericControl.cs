using System.Collections.Generic;
using System.Linq;

namespace HtmlBuilder.Builder {

  //
  public class GenericControl: Control {
    private string _data_type;

    public GenericControl(string tagName) {
      TagName = tagName;
    }

    public GenericControl(string tagName, string dataType) {
      TagName = tagName;
      _data_type = dataType;
    }

    public override void OnRender() {
      if (_data_type != null) {
        ControlDetails.Data.Add("data-type", _data_type);
      }
    }
  }
}
