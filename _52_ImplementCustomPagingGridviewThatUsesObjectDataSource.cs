using System;

namespace _52_CustomPaging
{
    /*52. Ders Custom Paging Using ObjectDataSource
      DataAcces Layer'da veri tabanından veri almak için oluşturduğumuz methoda 2 parametre ekliyoruz. 1. parametreyi alınacak ilk satırın Index'ini 2. parametreyi kaç satır alacağımız belirlemek için kullanıyoruz. Methodu ObjectDataSource'u ilişkilendirirken, Configure Data Source'da method parametrelerinin nereden geleceğini ayarlamadan kurulumu tamamlıyoruz. Html'de method parametresi  için oluşturulan elementleri sildikden sonra ObjectDataSource'un 4 property'sini kullanarak işi bitireceğiz.
      1. EnablePaging: Sayfalamaya ObjectDataSource Control'ün de de izin vermeliyiz.
      2. MaximumRowsParameterName: Bu da methodun 2 parametresine gidecek değeri belirlemek için.
      3. StartRowIndexParameterName: Sayfanın başlaangıc değerinin hangi method parametresine atılacağını belirliyoruz.
      4. SelectCountMethod: Bu Property'e Data Access Layer'da satır sayısını sayması için oluşturduğumuz methodu veriyoruz.
       
      Bu tablonun belirli bir kısmını doğru alabilmemiz için veri tabanında çalıştırılacak sorguda, InnerQuery kullanılmış. Bunun nedeni satır Index'ının EmployeId'e göre alamamamız. InnerQuery dış sorgunun kullanacağı tabloyu belirliyor. Bu tablonun gerçek tablodan farkı PrimaryKey'i Row Index'i olarak kullanamayacağımız için bu tabloya RowIndex'ını veren bir sütun eklememiz.
      
      Not: Default Paging ve Custom Paging arasında sadece veri tabanında çalışacak sorgu farklı. Custom paging'de parametre kullanmamız gerektiği için parametre kullanıyoruz.
      Not:Sayfa ilk yüklendiğinde 2 kayıt görüntüleniyor bunun nedeni Stored Procedure'a start index olarak 0 verilmesi. Bir nedenden dolayı row sayısının 1 eksiği kadar satır gösteriyor. Bu yüzden Procedure'de işleme başlamadan önce start index'i bir artırıyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}