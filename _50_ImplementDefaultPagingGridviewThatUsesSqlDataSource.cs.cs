using System;

namespace _50_DefaultPaging
{
    /*50. Ders Pageing GridView Using SqlDataSource 
      SqlDataSource'u GridView'la ilişkilendirdikten sonra, Html'de AllowPaging'e true değeridiğimizde, GridView'ın Footer'ına sayfalama işlemi için gerekli link'ler Button'lar eklenir. Varsayılan olarak her sayfa 10 satırdan oluşur. PageSize Property'sini kullanarak değiştirebiliriz. PageIndex Property'si ile geçerli sayfanın index'ini, PageCount ile toplam kaç sayfa olduğunu öğrenebiliriz. Bu iş için aşağıdaki kodu Page_Load'a yazdığımızda doğru çalışmıyor.(Sanırım sayfa hazırlanmadığı için) Bu yüzden PreRender'a yazıyoruz.
      Not: SqlDataSource kullanırkan her seferinde tüm satır alınıyor. Bu işe Default Paging deniyor. Bu performansı kötü etkiler sadece geçerli sayfaya ait satırları almak için sorguyu sorguyu düzenlemeliyiz. Bu işi Where kullanarak yapıyoruz ve bunada Custom Paging deniyor.
     */
    //51. Ders'de de Default Paging işlemini ObjectDataSource kullanarak yaptık.
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            Label1.Text = "Displaying Page " + (GridView1.PageIndex + 1).ToString() + " of " + GridView1.PageCount.ToString();
        }
    }
}