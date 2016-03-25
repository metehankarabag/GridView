using System.Web.UI;
using System.Web.UI.WebControls;

namespace _13_SqlDataSource
{
    /*13. Ders Deleting Data From GridView using Sql Data Source
      SqlDataSource kullanarak Delete işlemi gerçekleştirebilmemiz için Configure Data Source pencesinde Connection String'i seçtikten sonra açılan 2. penceredeki Advanced butonunu kullanmalıyız. Gerekli işlemleri yaptıktan sonra SqlDataSource'u oluşturan Html'e baktığımızda SelectCommand Property'sine ek olarak Insert, Update, Delete Command Property'leri ve bu sorgularda kullanılacak parametreleri için sorgu parametrelerinin eklendiğini görebiliriz. Bu işi yapmadan önce Data Source'u GridView ile ilişkilendirirsek, Enable Deleting ve Updating seçeneklerini göremeyiz. Enable Deleting'i seçtiğimizde Gridview'a CommandField Control'ü eklenir ve Control'un ShowDeleteButton Property'si true değeri aldığı alır. Varsayılan olarak Buton türü Link Button'dur. Fakat CommandField Control'ünün ButtonType Property'sini kullanarak bunu değiştirebiliriz.
      RowDataBound Event'da GridViewRowEventArgs nesnesinin Row Property'sine Cell Property'sini uygulayıp hücreye ulaşabiliriz. Daha önce GridView'daki hücrelerin değerlerini almıştık. Aynı mantıkla hücre içindeki Control'lere de Control Property'sini kullanarak ulaşabiliriz.
      
      Not: GridViewRowEventArgs Class'ının Row Property'sinin türü GridViewRow'dir. Bu Class TableRow,IDataItemContainer, INamingContainer Type'larından türüyor ve (object)DataItem, (int)DataItemIndex, (int)RowIndex, DataControlRowState türünde RowState, DataControlRowType türünde RowType property'leri ve OnBubbleEvent Event'i var. Yani Cell Property'si yok. Bu Property'i TableRow Class'ının TableCellCollection türündeki virtual Read-Only Property'sidir. TableCellCollection Class'ında Index olduğu için Index uygulayabiliriz. Index uyguladığımızda Property'i TableCell nesnesi döner. TableCell Class'ı WebControl Class'ından, Web Control Class'ıda Control Class'ından türüyor. Controls Property'si bu Class'ın Property'sidir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {//
            if (e.Row.RowType == DataControlRowType.DataRow)// 
            {
                Control control = e.Row.Cells[0].Controls[0]; // 
                if (control is LinkButton)// 
                {
                    ((LinkButton)control).OnClientClick = "return confirm('Are you sure you want to delete? This cannot be undone.');";
                }
            }
        }
    }
}