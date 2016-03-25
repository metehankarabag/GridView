using System;

namespace _45_ObjectDataSource
{
    /*44. Ders Sorting GridView Using ObjectDataSource
      Geçen derslerdeki gibi Data Access Layer'da List<t> dönen Read-Only bir method oluşturduk. Method ObjectDataSource ve ObjectDataSource'da kullandık. DataSource'u GridView ile ilişkilendirdiğimizde GridView Tasks penceresinde EnableSourting seçeneğini göremeyiz. Html'de GridView'ın AllowSorting Proeprty'sine True verip, uygulamayı çalıştırdıktan sonra sıralama işlemi gerçekleştirdiğimizde, ObjectDataSource'un Ienumerable veriyi sıralayamadığını gösteren bir hata alırız. ObjectDataSource'un varsayılan sıralamayı yapabilmesi için DataSource'una verdiğimiz nesnenin türünün DataView,DataSet veya DataTable'dan biri olması gerekir. Bu yüzden Property'inin dönüş türünü DataSet yapıyoruz. İşlemleri kolaylaştımak için ise DataAdapter kullanıp, oluşturduğumuz DataSet nesnesinin Fill() methoduna DataAdapter örneğini veriyoruz. Veri tabanından DataAdapter'in aldığı veri DataSet'e yüklenir. Şimdi çalışır. Sonraki Derste List<t> ile nasıl çalışacağını göreceğiz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}