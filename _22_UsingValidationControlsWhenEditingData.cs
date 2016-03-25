using System.Web.UI.WebControls;

namespace _22_UsingValidationControlsWhenEditingData
{
    /*
     Gridview'da Edit Mode'a aldığımız sütunların Validation kullanmasını istiyorsak, sütun Template Field kullanmalı ve <EditItemTemplate> bölümüne bir Validation Control ekleyip, diğer kontrolle ilişkilendirmeliyiz.
     Not: Required Field Validator Control'ünün InvalideValue Property'si geçersiz değeri belirlemek için kullanılır.
                                                Text Property'si Control'ün yanında gösterilecek hata yazısını belirler.
                                                ErrorMessage Property'si ValidationSummary Control'ünde gösterilecek yazıyı belirler.
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.AffectedRows < 1)
            {
                e.KeepInEditMode = true;
                lblMessage.Text = "Row with EmployeeId = " + e.Keys[0].ToString() + " is not update due to data conflict";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.Text = "Row with EmployeeId = " + e.Keys[0].ToString() + " is successfully updated";
                lblMessage.ForeColor = System.Drawing.Color.Navy;
            }
        }
        protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue is int && (int)e.ReturnValue > 0)
            {
                e.AffectedRows = (int)e.ReturnValue;
            }
        }
    }
}