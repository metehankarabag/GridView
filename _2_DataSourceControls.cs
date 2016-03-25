using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _2_DataSourceControls
{
    /* 1. Ders
      Veri tabanındaki verileri programa getirmek için Ado.net kodları kullanmamzı gerekir. Fakat aynı işi DataSource Control'lerini kullanarak da yapabiliriz. DataSource Control'leri veri tabanında çalıştırılacak sorguları belirlediğimiz Control'lerdir. DataSource Control'lerinin hangi veri tabanında hangi sorguyu çalıştırıcağını belirlemek için bu Control'lerin Configure Data Source Wizard'ını kullanabiliriz. Bu Wizard'da yaptığımız her şey DataSouce Control'ünü oluşturan Html'e eklenir. DataSource COntrol'ünü oluşturduktan sonra bu Control'ü DataGrid, GridView gibi DataBound Control'lerinin veri kaynağı olarak belirleyebiliriz. DataSource veri tabanında çalıştırdığı sorgunun sonucunda aldığı veriyi ilişkilendirildiği Data Bound Control'lerine atar. DataSource Control'leri: SqlDataSource,ObjectDataSource, AccessDataSource, XMLDataSource, LinqDataSource, EntityDataSource
      
      Not: Toolbox'da görünmeyen kontrolleri göstermek için -> Control'ü eklemeyi istediğin alana > sağ tıkla > Choose Items
     */
    /*2. Ders SqlDataSource 
      SqlDataSource Control'u Configure Data Source Wizard'ını kullanarak oluşturmayı istiyorsak. İlk pencerede veri tabanını belirlemek için ConnectionString'i belirleriz. Yani Sql DataSource veri tabanına göre çalışır. 2. pencered Specify columns from a Table or View'ı şeçerek veri tabanındaki bir tablonun ve tablonun hangi sütunlarını kullanacağımızı belirleriz. 3. Pencrede de test edip kurulumu tamamlayabiliriz. Artık SqlDataSource Control'ünün Data-Bound Control'leri ile ilişkilendirebiliriz. SqlDataSource veri tabanına göre çalıştığı için sütunları tüm özellikleri ile birlikte alır ve ilişkilendirildiği DataBound Control'ünü buna göre ayarlar. Bu yüzden bizi bazı ayarlar yapamaktan kurtarır. Fakat Sql Data Source kullandığımızda veri tabanı ve veri tabanında çalıştırılacak sorgu gibi ayarlar, Data Source Control'ünü oluşturan Html'e eklenir. Yani her daha Source'da ayarlar yeniden yazılır. Bir değişiklik yapmayı istediğimizde tüm DataSource'ları ayrı ayrı güncellemek zorunda kalırız. 
      1. Not: Bir DataSource Control'ünü DataGrid ile ilişkilendirirsek, sadece DataSource Control'ünde belirediğimiz Select sorgusunu kullanabiliriz. GridView'da daha fazla Column Type var. 
      2. Not: Object Data Source kullanıyorsak, kod yazmak zorundayız.
      3. Not: Gridview ile bir DataSource Control'ünü ilişkilendirmek için Gridview'in DataSourceID Property'sini kullanmalıyız.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProducts", con);
                con.Open();
                Gridview1.DataSource = cmd.ExecuteReader();
                Gridview1.DataBind();
            }
        }
    }
}