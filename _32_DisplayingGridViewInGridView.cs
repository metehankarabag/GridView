using System;

namespace _32_DisplayingGridViewInGridView
{
    /*32. Ders Displaying GridView In GridView
      GridView'ın bir ItemTemplate kullanan sütununa GridView Control'ü ekleyip dış'daki gridView'ın kullandığı Data source'daki bir Property'i içdeki GridView'ın DataSource'u olarak ayarlamak için GridView'ın Data Source Property'sine Bind() methodunu veriyoruz. Eval() methodunu'da kullanabiliriz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = DepartmentDataAccessLayer.GetAllDepartmentsandEmployees();
            GridView1.DataBind();
        } 
    }
}