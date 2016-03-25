using System;

namespace _15_ObjectDataSource
{
    /*15. Ders Deleting Data Form GridView Using Object Data Source
     ObjectDataSource kullanırken Data Access Layer'da Delete işlemi işin oluşturduğumuz methodu Delete işlemi için seçiyoruz. Delete işlemi için seçtiğimiz method Id parametresi bekliyor. Fakat 11. ve 12. derste olduğu gibi parametreye gelecek değeri belirlediğimiz bir pencere daha açılmıyor. Büyük ihtimalle bunun denedi Insert,Update, Delete işlemlerinin uygulanacağı satırı belirlemek için kullanılacak değerin sadece GridView'dan gelmesini sağlamak. Configure Data Souce Wizard'ında işlemi tamamladıktan sonra ObjectDataSource'u oluşturan HTML'e Delete sorgusu için kullanılacak methodu belirleyen DeleteMethod Property'si ve Method parmetresine kullanılacak parametreyi belirleyen <DeleteParameter> elementi eklenir. Bu element içinde Parameter Control'ü kullanılır. Bu Control'ün Name özelliği hem method adını hemde parametrenin geleceği sütun adını belirliyor sanırım. Fakat uygulamayı çalıştırdığımızda silme işlemi gerçekleştirilmez. Çünkü satırın bir değeri DataSource Control'üne gönderilmiyor. Bunun nedeni Primary Key sütunun belli olmaması. GridView'ın DataKeyNames Property'sini Primary Key sütununu belirlemek için kullanabiliriz. Birden fazla sütunu key sütunu olarak belirlemyeyi istiyorsak DataKeyNames property'sine sütun adlarını "," ile ayırarak vermeliyiz. SqlDataSource kullanırken Primary Key sütunu otomatik olarak belirlenir. Çünkü veri tabanı tablosuna göre uylanıyor. Bussiness layer'daki Class'a Key Attribute'u uyguladım olmadı.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}