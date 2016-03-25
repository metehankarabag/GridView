using System;
using System.Web.UI.WebControls;

namespace _53_DefaultPagingWithoutControl
{
    /*53. Ders Default Paging Witout Using DataSource Controls
      GridView'ın AllowPaging Property'sine true verdikten sonra, GridView Footer'a oluşan linklere tıkladığımızda, PageIndexChanging Event'ı tetiklenir. Event'ın kullandığı EventArgs Class'ının NewPageIndex Property'isi yeni sayfa Index'ını veri bu Index'ı GridView'ın PageIndex değerine veriyoruz ve veri tabanından veri almak için oluşturduğumuz Methodu çalıştırıyruz. Bu method veri tabanında tüm tablo satırlarını alan bir sorgu çalıştırıyor, gösterilecek satırları GridView'da yaptığımız ayarlar belirliyor.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees();
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees();
            GridView1.DataBind();
        } 
    }
}