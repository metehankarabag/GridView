
namespace _17_SqlDataSource
{
    /*17. Ders Editing And Updating Data in Gridview Using Sql Data Source
      GridView'daki oka tıkladığımızda Enable Editing gibi seçenekleri görmeyi istiyorsak, kullandığımız Sql Data Source Control'ünü Edit sorgusu içermelidir. Edit butona tıkladığımız satırın tüm sütunları Edit Mode alınır. Edit Mode'a alınmasını istemediğimiz sütunlar varsa, Html'ler bu sütunları temsil eden BoundField Control'lerinin ReadOnly Property'sine True değeri verebiliriz. Bir sütuna değer girmeden güncellemeyi gerçekleştirirsek, bu sütun için veri tabanında Null değeri tutulur. Bunun nedeni BoundField'ın ConvertEmptyStringToNull Property'sinin varsayılan değerinin True olmasıdır. Bu Property'e false değeri verip, boş bir değer ile veri tabanını güncellediğimizde, yine null görünür. Bunun nedeni Gridview'dan gelen boş değerin DataSource Control'ünden method parametresine null gönderilmesidir. Bu sorunu düzelmek için ConvertEmptyStringToNull Property'sini, sütunu kullanan Parameter Control'üne uygulamalıyız.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
    }
}