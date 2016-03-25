using System;
using System.Web.UI.WebControls;

namespace _24_ObjectDataSource
{
    /*24. Ders Insert - Update - Delete Using Object Data Source
     
      SqlDataSource kullanırken veri tabanında oluşturduğumuz Sql Sorgularını kullanan methodlar oluşturup, bu methodları kullanıyoruz.
      Not: GridView'ın DataSource'unu yenilerken, Key ve Field'ları silme uyarısı çıkarsa, uyarıyı silersek, DataKeyNames, Update, Delete Button'ları silme gibi işler yapar. Tekrar aynı işi yapmanın bir anlamı olmadığı için hayır diyoruz.
      Object Data Source'a Insert işlemi için bir method verdiğimizde, bu işlemi tetiklemesi için GridView'a eklediğimiz Insert Button, SqlDataSouce'daki gibi otomatik olarak objectDataSource'u tetiklemez. Bu yüzden aşağıdaki kodu değiştirmiyoruz.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void lbInsert_Click(object sender, EventArgs e)
        {

            ObjectDataSource1.InsertParameters["Name"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            ObjectDataSource1.InsertParameters["Gender"].DefaultValue =((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
            ObjectDataSource1.InsertParameters["City"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
            ObjectDataSource1.Insert();
        }
    }
}