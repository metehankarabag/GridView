using System;
using System.Web.UI.WebControls;

namespace _47_WithoutControl
{
    /*47. Ders Sorting GridView Without Using DataSource Controls
      Oluşturduğumuz List<t> dönen methodu Object DataSource kullanmayacağı için sıkıntı yok. GridView'ın veri kaynağı olarak methodun dönüşdeki nesnesini veridikten sonra, GridView'ın AllowSorting Property'sine True değeri verip, sıralama yaptığımızda, GridView'ın Sorting Event'ı tetiklenir. Bu Event'i işleyen methodu oluşturmadıysak, hata alırız. Bu yüzden hata alıyoruz. Event'ın EventArgs Class'ının SortDirection Parametresi geçerli sıralama yönünü verir. SortExpression ise sıralamak için kullanılan sütun adını verir. Bu parametrelerden aldığımız değeri Data Access Layer'daki methoda vereceği. Method parametresinden aldığımz değerleri sourgunun order by'dan sonraki kısmına eklendiği için sütun adı + " " + sıralama yönü şeklinde olmalı. Bu işi yaptıktan sonra sıralama işlemini gerçekleştirisek, tekrar hata alırız. Çünkü Sql'de sıralama yönünü belirlemek için Asc veya Desc anahtarları kullanılır. Fakat SortDirection property'si Ascending veya Descending döner. Bu yüzden değeri düzenlememiz gerekir.
      Aşağıdaki kod hiç bir zaman Descendig sıralama yapmaz çünkü Property'e Asceding getirecek. Bu sorunu gelecek derste bir method oluşturark çzöüyor ama bende aşağıda bir şeyler yaptım.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees("EmployeeId");
                GridView1.DataBind();
            }
        }
        string lastUsedColumNameToSort = string.Empty;
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            lastUsedColumNameToSort = e.SortExpression;

            string abc = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
            
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees(e.SortExpression + " " + abc);
            GridView1.DataBind();

            
        }
    }
}
/*
         protected void GridView1_Sorting(object sender, GridViewSortEventArgs e) Session yerine kullandığımda
         {
             if (GridView1.Attributes["sirala"] == "DESC")
             GridView1.Attributes["sirala"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
             else
                 GridView1.Attributes["sirala"] = "DESC";

             GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees(e.SortExpression + " " + GridView1.Attributes["sirala"]);
             GridView1.DataBind();
         }
         
         Anladığım kadarıyla Asp.net Control'lerine istediğimiz gibi Property'i ekleyebiliyoruz. Bu Property'e kod kısmında ulaşmak için ise Control'leri Attributes Property'sini kullanabiliyoruz. Property'i WebControls Class'ının AttributeCollection türündeki Property'sidir ve bu Class'da Index var. Index değeri olarak oluşturduğumuz Property'inin adını veridiğimizde Property içindeki değeri alabilir ve değiştirebiliriz. Aynı işi Session'la da yapabiliriz.
         Not: Shared Field oluştrup, bir önceki değeri hatırlamaya çalıştım fakat, post back'de değer kayboluyor.
*/