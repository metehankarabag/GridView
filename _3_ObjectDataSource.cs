using System;

namespace _3_ObjectDataSource
{
    /*3. ObjectDataSource
      ObjectDataSource kullanıyorsak, uygulamada veri tabanını temsil etmesi için oluşturduğumuz Class'ları kullanırız. Uygumada kod karmaşası olmaması için işleri 3 parçaya bölüyoruz.
      1. Presentation: Sadece uygulama ile alakalı kodların yazıldığı katman. Yani veri tabanından bağımsız olan işlemlerin yazıldığı katman. 
      2. Bussiness: Veri tabanı tablolarını temsil eden Class'ları oluşturulduğu katmandır. Veri tabanından alınan değerler bu Class'ın örneklerinde örneğinde tutulur. Class'lar, tablolar yerine kullanıldığı için GrdiView bu Class'ların Property'lerine göre sütunlarını oluşturur. Bu yüzden Property'lere uyguladığımız ayarlar GridView sütunlarına da uygulanır.
      3. Data Access: Veri tabanında çalışacak sorguları barındıran method'lar bulunur. Bu methodların dönüş türündeki veri GridView'ın Data Source'u olacağı için ve veri tabanından veri getiren methodun, aldığı tüm veriyi uygulamaya getirebilemesi için dönüş türü List<t>(vb..) olmadıdır. Generic Type olarak veri tabanındaki tabloya göre oluşturduğumuz Bussiness Layer'daki Class olmalıdır. Böylece GridView sütunları Bussines Layer'dak Class Property'lerine göre oluşturulur.
      
      ObjecDataSource Control'ünü oluşturan Html'inde belirlediğimiz Data Acces Class'ı ve methodu görürürüz. Yani kaç tane object Data Source kullanırsak kullanalım, method veya Class adını değiştirmessek, method içinde yaptımız işlemler tüm DataSource'ları etkiler. Bu bizde tek yerden kontrol sağladığı için daha iyi olur.

      Not: Gerçek uygulamalarda bu katmanların hepsi ayrı Projeler'de oluşturulur.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}