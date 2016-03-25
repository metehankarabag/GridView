using System;

namespace _37_UsingSqlDataSource
{
    /*37. Ders DetailsView
     DetailsView'da GridView gibi bir DataBound Control'üdür. DetailsView aynı anda sadece bir GridView satırının tüm sütun değerlerini göstermek için kullanılır. Yani tüm değerler GridView'da görünsün istemiyorsak ve kullancı GridView'da seçtiği bir satırın tüm değerlerini görebilsin istiyorsak, DetailsView Control'ünü kullanabiliriz. Yani Details View'ın kullanım mantığı 34,35 ve 36 derslerde hieraşik düzen içinde çalışan GridView'lar ile aynıdır. Yani DetailsView bir GridView'dan aldığı değeri ile filitreleme uygularayak veri kaynağından veri alır.
     Sayfa ilk yüklendiğinde GridView'da hiç bir satır varsayılan olarak seçili değilse, Details View boş kare olarak görüntülenir. Bunun olmaması için PageLoad olayından DetailsView'ın görünürlüğüne False veriyoruz. Fakat ilk seçim için düzgün çalışmıyor. Bunun nedeni seçim işleminin PostBack Event'ından sonra olması, Page_Load PostBack'den önce çalıştığı için seçtiğimiz değer ilk seferde görünmüyor. PreRender Event'i PostBack'den sonra çalıştığı için kodu bu Event'a yazıyoruz. 
     Asp.net Life Cyle: http://fuchangmiao.blogspot.com.tr/2007/11/aspnet-20-page-lifecycle.html
     */
    public partial class WebForm1 : System.Web.UI.Page
    { 
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                DetailsView1.Visible = false;
            }
            else
            {
                DetailsView1.Visible = true;
            }
        }
    }
}