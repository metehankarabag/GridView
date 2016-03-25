using System;

namespace _11_SqlDataSource
{
    /*11. Ders Stored Procedure With Sql Data Source
     SqlDataSource kullanırken kullanacağımız veri tabanını balirlemek için Configure Data Source'un ilk penceresinde ConnectionString istenir. Next'e tıkladığımızda ConnectionString kullanılarak veri tabanına bağlanılır. Bu sadeye veri tabanında oluşturduğumuz Procedure'leri SqlDataSource'un Configure Data Source penceresinde görebiliriz. Procedure'leri kullanmak için açılan 2. penceredeki ilk CheckBox'ı seçip Next'e tıkladığımızda açılan 3. pencerede veri tabanında oluşturduğumuz Stored Procedure'ların hangi sorgu için kullanılanağını belirleyebiliriz. Kullandığımız Stored Procedure'e parametreli ise Next'e tıkladığımızda bir pencere daha açlır. Bu pencerede değerin geleceği Source'un türünü belirledikten sonra nesne kullanılacak nesneyi belirlemeliyiz. Parametre bir Control'den geliyorsa, <...Parameters> elementi içinde ControlParameter Control'ü kullanılır, Bu Control'ün PropertyName Property'si Control'ün hangi Property'sinden değer alınacağını belirler. Name Property'si ise Procedure'nin beklediği parametre adını belirler.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}