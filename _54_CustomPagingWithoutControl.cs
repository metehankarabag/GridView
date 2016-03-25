using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _54_CustomPagingWithoutControl
{
    /*54. Ders Custom Paging Without Using DataSource Controls
      Default Paging ile farkı veri tabanında olduğu için, veri tabanında output parametre olarak toplam satırsayısını dönen ve başlangıc index'i ve sayfa genişliği için 2 değer bekleyen bir Stored Procedure oluşturduk. Data Access Layer'da bu Procedure'u kullanan bir method oluşturduktan sonra sayfa işleminde kullanabiliriz.
      Bu derste DataSource kullanmadığımız Footer'da sayfa link'lerini göstermek için AllowPageing kullanamıyoruz. Bu işi yapmak için Repeater Control kullanıp Control'e linkButton ekliyoruz. Repeater Control içine eklediğimiz LinkButton'u belirlediğimiz sayıda tekrarlayacak. Repeater Control'ün içindekileri kaç kez tekrarlayacağını belirlemek için oluşturulacak sayfa sayısını belirlememiz gerekir. Bu yüzden DatabindRepeater() methodunu oluşturduk. Bu method içinde Repeater'ın kullanacağı DataSource'u da belirliyor. Bu DataSource'daki bilgileri LinkButton'larda kullanacağız. Bu yüzden DataSource'u List<ListItem> nesnesi olarak oluşturuyoruz. ListItem Class'ının 4. overload'ı 3 parametre bekliyor. 1. Görüntülenecek Text 2. Value 3. Enable. Hepsi için gerekli değerleri değerleri verdikten sonra. Html'de LinkButton'ların uygun Property'lerinde(Text, CommandArgument, Enabled) Eval() methodunu kullanarak Repeater'ın DataSource'undan verileri alıyoruz. Enable Buttonu geçerli sayfayı gösteren link buttonun tıklanılabilirliğini engellemek içindir.
     
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalRows = 0;
                GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(0, GridView1.PageSize, out totalRows);
                GridView1.DataBind();

                DatabindRepeater(0, GridView1.PageSize, totalRows);
            }
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            int totalRows = 0; 
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1; 
            GridView1.PageIndex = pageIndex;
            
            GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize, out totalRows);
            GridView1.DataBind();

            DatabindRepeater(pageIndex, GridView1.PageSize, totalRows);
        }

        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0) // Bölümden kalan varsa bir sayfa daha oluştur.
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>(); // Repeater Control'ün DataSource'unu belirliyoruz.
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            repeaterPaging.DataSource = pages;
            repeaterPaging.DataBind();
        } 

    }
}