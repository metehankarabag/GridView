using System;

namespace _4_XmlDataSource
{
    /*
     XmlDataSource kullanmak için yapmamız gereken tek şey oluşturduğumuz Xml dosyasını Control ile ilişkilendirmek. 
     Not: XmlDataSource Control'ü Child Xml elementleri içeren Xml dosyalarını okumaz. Bu yüzden bir elemente ait ilgileri taşıması için Child Xml Node'larını kullanmak yerine verileri element Attribute'larında barındırmalıyız. Yani Xml dosyası Child Node'lar kullanıyorsa, Node'lardaki bilgileri Parent Node'un Attribute'larına ekleyerek, Xml dosyasını yeniden düzenlemeliyiz. Bunu yapmanın 3 yol var. 
      1. üstteki işi elle yapmak ki bu Xml dosyası büyükse sorun olur. 
      2. XSLT dosyası kullanarak mecut Xml'in formatını başka bir formaya çevirebiliriz. -> 5. ders
      3. Xml dosyasındaki veriyi bir DataSet nesnesine aldıktan sonra DataSet'i bir Data Bound Control ile ilişkilendirebilriz. -> 5. ders
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}