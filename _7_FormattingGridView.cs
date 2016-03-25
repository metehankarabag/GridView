using System;

namespace _7_FormattingGridView
{
    /* 
      GridView varsayılan olarak Sütunlarını oluşturmak için Column Type olarak BoundField kullanır. 
      BoundField'ın DataField Property'si GridView sütununun verisini, DataSource'un hangi sütundan alacağını belirler. 
      Visible Property'sine False veridğimizde GridView sütunu, DataSource Control'ündeki geçerli sütuna bağlanmaz. Bu durumda sütun ne GridView'da nede view Page Source'da görünür.          HeaderText Property'si sütun başlığını belirlemek için kullanılır ve varsayılan olarak sütunun bağlandığı Data Source sütunu ile aynı adı alır.
      DataFormatString Property'si, DataSource'dan sütuna alınan verinin görüntülenme şeklini {} içinde aldığı kod ile düzenlemek için kullanılır. (0:d -> tarih için). Bu Property'i kullanarak ülkelerin kullandığı para biriminide ekleyebiliriz. (0:c -> geçerli ülkenin parabirimini verir.)
      Not: Uygulamanın kullandığı varsayılan Culture değerini uygulama düzeyinde değiştmek için Config dosyasında -> <globalization /> elementinin Culture Attribute'unu kullanabiliriz. Aynı işi sayfa düzeyinde yapmak için Page direktifini kullanabiliriz. 
      Not: Tüm Date and Time Format'larını görmek için videoda link var.
      
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(System.Threading.Thread.CurrentThread.CurrentCulture.ToString()); //--> Geçerli ülkeyi bulmak için 
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
        }
    }
}