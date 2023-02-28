using System.Data;

namespace HtmlBuilder.Builder {

  //
  public class SelectControl: Control {

    public SelectControl() {
      TagName = "select";
    }

    public void DataBind(DataSet ds, string valueField, string textField) {
      Controls.Clear();
      if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Columns.Count > 1) {
        foreach(DataRow row in ds.Tables[0].Rows) {
          Controls.Add(new OptionControl(@row[valueField].ToString(), row[textField].ToString()));
        }
      }
    }

    public void AddOption(string value, string text, bool selected = false) {
      ControlDetails.XML += "<option value='" + value + "'";
      if (selected)
        ControlDetails.XML += " selected='selected'";
      ControlDetails.XML += ">" + text + "</option>";
    }
  }
}
