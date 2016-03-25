using System;

namespace _46_SortingWithList
{
    /*46. Ders Sorting List<t> data Using ObjectDataSource
      ObjectDataSource List<t> türündeki veri kaynağına varsayılan sıralama yapamadığı için kullandığımız methodun veri tabanında çalıştıracağı sorguya order by eklerek veri tabanından sıralanmış veri alıyoruz. Order By parametreleri GridView'da geleceği için metod 2 parametre beklemeli orderby "sütunAdı + sıralamaYonu". ObjectDataSource'un SortParameterName Property'sini methoda sütun adının girilmesi için eklediğimiz parametresini veriyoruz. Property, GridView'da kullanılan BuounField'ın SortExpression Property'sindeki değeri belirlenen method parametresine gönderir. Bu yüzden SortExpression Property'si sütun adını içerir. 
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}