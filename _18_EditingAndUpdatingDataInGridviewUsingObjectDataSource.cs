
namespace _18_ObjectlDataSource
{
    /*18. Ders Editing And Updating Data in Gridview Using Sql Data Source
      ObejctDataSource kullarak aynı işi yapmak için Data Access Class'ına Edit methodu ekleyip, methodu Configure Data Source'da Edit işlemi ile ilişkilendirmemiz gerekir. Sql Data Source kullanırken, Primary Key sütunun otomatik olarak Read-Only olduğu için Edit Mode'a alınmaz. Fakat Object Data Source'da böyle değil. Primary Key sütununu Edit Mode'a aldıktan sonra uygulamayı çalıştırdığımızda ise Update işlemi gerçekleşmiyor. Yani almadan önce gerçekliyordu. Bu sorunu çözmek için DataKeyNames Property'sine kullanarak Primary Key sütununu berliliyoruz. Sql Data Source veri tabanına göre çalıştığı için bu otomatik olarak belirlenebiliriyor.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
    }
}