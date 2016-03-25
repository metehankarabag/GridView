using System;
using System.Web.UI.WebControls;

namespace _9_BasedOnRowData
{
    /*
     Geçen derste para simgesini doğru belirlemek için satırın başka bir sütununu kullandık. Kullanıcının bu sütunu görmesi gerekmediği için sütunu görünmez yapmayı istiyoruz. Fakat Sütunu oluşturan BoundField'ın Visible Property'sine False verdiğimizde, sütun Data Source'dan veri almayacağı için EventArgs örneğinde bu sütunun değerini alamayız. Bu yüzden geçerli para sembolünü belirleyemeyiz. Yani ilk önce HTML kodları çalışıyor ve bizim değere ulaşmamızı engelliyor. Bu yüzden hücre görünürlüğünü, hücredeki değeri kullandıktan sonra kodda hürce hücre kapatmalıyız. Aynı işi BoundField'da Css uygulayarak da yapabiliriz. Çünkü Css Client'da çalışır. BoundField'ın Visible Property'sine False verdiğimizde PageSource'da sütunu göremeyiz, Css iştemci tarayıcıda çalıştığı için Page Source'da sütun bilgilerini görebilirizi. 
     Not: Kod'da DataRow'lara Visible False verirken HeaderRow'lara vermessek sadece headerRow görünür.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header) { e.Row.Cells[4].Visible = false; }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                string countryCulture = e.Row.Cells[4].Text;
                e.Row.Cells[4].Visible = false;
                string formattedString = string.Format(new System.Globalization.CultureInfo(countryCulture), "{0:c}", salary);
                e.Row.Cells[2].Text = formattedString;
            }
        }
    }
}