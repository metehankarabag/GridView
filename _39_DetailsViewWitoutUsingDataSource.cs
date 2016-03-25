using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _39_WitoutUsingDataSource
{
    /*39 Witout Using Data Source
      DataSOurce kullanmadan DetailsView'ı tetiklemek için RowComman Event'ını kullanabiliriz. Event'ın tetiklendiği satırdan gereki Primary key değerini alıp Details View'ı çalıştırabiliriz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployeesBasicDetails();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectFullDetails")
            {
                int rowIndex =((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridView1.SelectRow(rowIndex);
                int employeeId = Convert.ToInt32(GridView1.SelectedValue);
                // Method List<Employee> dönüyor. Yani aşağıdaki kod boş listeyi doldurur. Bu liste'i DetailsView'a veriyoruz.
                List<Employee> employeeList = new List<Employee>()
                {
                    EmployeeDataAccessLayer.GetEmployeesFullDetailsById(employeeId)
                };

                DetailsView1.DataSource = employeeList;
                DetailsView1.DataBind();
            }
        } 
    }
}