using System;
using System.Web.UI.WebControls;

namespace _25_WithoutDataSources
{
    /*25. Ders Insert - Update - Delete Without Using Data Source Controls
      DataSource Control'leri veri tabanına çalıştırılacak sorgunun belirlendiği Control'lerdir. Yain DataSource kullanmadan veri tabanında çalıştırılacak sorguyu belirlemek için  GridView'e eklediğimz Button'ların Click Event'larını kullanabiliriz. Fakat GridView'da bir Butona'a tıkladığımız her an GridView'ın RowCommand Event'ı tetiklenir. Yani sadece bu Event'ı, kullanarak da Data Source'ların yaptığı işi yapabiliriz. 
      RowCommand Event'ında GridView'ın hangi Button'una tıklanıldığını anlayabilmemiz için CommandName Property'sini kullanabiliriz. Fakat Varsayılan olarak Edit ve Delete Button'larını oluşturmak için tek bir CommandField Control'ü kullanılır. Yani 2 button'u oluşturmak içinde tek bir Control kullanılır ve bu Control'ün CommandName Property'si yok, olsa bile 2 button'a da aynı ismi vermiş olacağız.(ButtonField var ama kullanmadık). Bu yüzden Template Field her alana gereki Button Control'ünü ekliyoruz. Satırı Editt Mode'a alacak button ve silme işlemi için kullanılacak Button'u <ItemTemplate> alanına eklemeliyiz. Çünkü gösterim için bu alan kullanılır. <EditItemTemplate>'de ise Update ve Cancel Button'ları olacak. Button'larda CommandName Property'lerine uygun değerler veridikten sonra hangi satırdaki button kullanıldığını anlayabilmemiz için CommandArgument Property'ini de kullanmamız gerekiyor.CommanArgumant Property'sine parametre olarak DataSource'dan Primary Key'i alıyoruz. Bu değeri geçerli işlemin veri tabanında hangi satıra uygulanacağını belirlemek için kullanacağız. Kullandığımız Control GridView'a ait olmadığı için DataSource'dan Eval() ile veriyi alıyouz. RowCommand Event'ını işleyen methodun parametresindeki GridViewCommandEventArgs Class'ında 2 overload' bir Read-Only (object)CommandSource Property'si vardır. Bu Class CommandEventArgs'ından türediği için EventArgs örneğinden CommandEventArgs Class'ının 2 overload'ı ve 2 Read-Only Property'si var. -> (string)CommandName ve (object)CommantArgument. Methodların bu Property'lerine verdiğimiz değerlere bu Class'ın Property'lerinden ulaşabiliriz. 
       4 Button olduğu için 4 farklı iş var fakat yapılacak işlerde 2 temel durum var. Edit Button'u geçerli satırı Edit Mode'a almak için kullanacağız. Fakat Primary Key değeri geçerli satır index'ini vermediği için CommanArgumant Property'sini kullanamayız. Bu yüzden 1. olarak geçerli satır index'ini bulmalıyız. Sonrada 2. olarak da bu Index'ı kullanarak geçerli Row'ın hücre bilgilerini alacağız.
      
      Not: Optimistic Concurrency kullanmayı istiyorsak, işlemin yapıldığı satırdaki tüm sütun değerleri RowIndex'i kullanarak almamız gerelir. Yani DataSource'lar ile yaptığımız her şeyi bu Event'i kullanarak da yapabiliriz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void BindGridViewData()
        {
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridView1.EditIndex = rowIndex;
                BindGridViewData();
            }
            else if (e.CommandName == "DeleteRow")
            {
                EmployeeDataAccessLayer.DeleteEmployee(Convert.ToInt32(e.CommandArgument));
                BindGridViewData();
            }
            else if (e.CommandName == "CancelUpdate")
            {
                GridView1.EditIndex = -1;
                BindGridViewData();
            }
            else if (e.CommandName == "UpdateRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                int employeeId = Convert.ToInt32(e.CommandArgument);
                string name = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
                string gender = ((DropDownList)GridView1.Rows[rowIndex].FindControl("DropDownList1")).SelectedValue;
                string city = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;

                EmployeeDataAccessLayer.UpdateEmployee(employeeId, name, gender, city);

                GridView1.EditIndex = -1;
                BindGridViewData();
            }
            else if (e.CommandName == "InsertRow")
            {
                string name = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
                string gender = ((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
                string city = ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;

                EmployeeDataAccessLayer.InsertEmployee(name, gender, city);

                BindGridViewData();
            }
        }
    }
}