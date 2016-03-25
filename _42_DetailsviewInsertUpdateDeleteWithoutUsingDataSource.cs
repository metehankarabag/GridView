using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _42_WithoutUsingDataSource
{
    /*42. Ders Insert - Update - Delete Without Using DataSource Controls
      GridView'ın selectedChanged Event'ı, GridView'da bir satır seçildiğinde tetiklenir. DataKeyNames Property'sindeki sütunun değerini gerekli methodu verrerek,  method sonucunu DetailsView'a gönderiyoruz. DetailsView'da ki Update veya New Button'larına tıkladığımızda hata alırız. Bunun nesneni DetailsView'ın görüntü methodunun değişmesidir. Bu sorunu çözmek için DetailsView'ın modu her değişmesi geretiğinde tetiklenen ModeChanging Event'ını kullanabiliriz. DetailsView'ın modunu değiştirmek için Event içinde ChangeMode() kullanmamız gerekir. Method parmetre olarak DetailsViewMode nesnesi bekliyor. DetailsView'ın hangi moda alınmak istediğini belirlemek için Event'in EventArgs parametresinin NewMode Property'sini kullanıyoruz.
      Not: DetailsView'ın DataSource Property'si object bekliyor fakat list<t> gibi bir liste vermediğimizde hata alıyoruz.(Sanırım DetailsView gibi tüm Control'ler için böyle)
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewDataBind();
            }
        }

        private void GridViewDataBind()
        {
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployeesBasicDetails();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsViewDataBind();
        }

        private void DetailsViewDataBind()
        {
            if (GridView1.SelectedDataKey != null)
            {
                DetailsView1.Visible = true;

                List<Employee> listEmployee = new List<Employee>();
                listEmployee.Add(EmployeeDataAccessLayer.GetEmployeesFullDetailsById((int)GridView1.SelectedDataKey.Value));

                DetailsView1.DataSource = listEmployee;
                DetailsView1.DataBind();
            }
            else
            {
                DetailsView1.Visible = false;
            }
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsView1.ChangeMode(e.NewMode);
            DetailsViewDataBind();
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            EmployeeDataAccessLayer.InsertEmployee(e.Values["FirstName"].ToString(),
                e.Values["LastName"].ToString(), e.Values["City"].ToString(),
                e.Values["Gender"].ToString(), Convert.ToDateTime(e.Values["DateOfBirth"]),
                e.Values["Country"].ToString(), Convert.ToInt32(e.Values["Salary"]),
                Convert.ToDateTime(e.Values["DateOfJoining"]), e.Values["MaritalStatus"].ToString());

            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);

            GridViewDataBind();
            GridView1.SelectRow(-1);
        }

        protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            EmployeeDataAccessLayer.DeleteEmployee((int)GridView1.SelectedDataKey.Value);

            GridViewDataBind();
            GridView1.SelectRow(-1);
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int employeeId = (int)GridView1.SelectedDataKey.Value;
            EmployeeDataAccessLayer.UpdateEmployee(employeeId,
                e.NewValues["FirstName"].ToString(), e.NewValues["LastName"].ToString(),
                e.NewValues["City"].ToString(), e.NewValues["Gender"].ToString(),
                Convert.ToDateTime(e.NewValues["DateOfBirth"]), e.NewValues["Country"].ToString(),
                Convert.ToInt32(e.NewValues["Salary"]), Convert.ToDateTime(e.NewValues["DateOfJoining"]),
                e.NewValues["MaritalStatus"].ToString());

            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);

            GridViewDataBind();
            GridView1.SelectRow(-1);
        }
    }
}