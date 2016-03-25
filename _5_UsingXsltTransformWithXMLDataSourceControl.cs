using System;
using System.Data;

namespace _5_UsingXsltTransformWithXMLDataSourceControl
{
    /* 
     2. yol 
     XSLT dosyasında mevcut Xml dosyasının şemasını değiştirmek için yeni bir şema oluştururuz. XmlDataSource'a bu dosyayıda verdikten sonra işlem tamamlanır.
     3 yol DataSet Class'ının ReadXml() methodun parametre olarak Xml dosyasının tam adını verdiğimizde Xml verisi DataSet örneğine alınır. Örneği gridview'ın veri kaynağı olarak belirlemek için ise Gridview'ın DataSource Property'ini kullanırız. DataBind() methodunu kullandığımızda veri Gridview'a eklenir.
     Bunun için kod yazmak zorundayız.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));
            GridView2.DataSource = ds;
            GridView2.DataBind(); 
        }
    }
}