using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _26_DisplayingSummaryInDataFooter
{
    /*26. Ders Displaying Summary In Data Footer
     DataRow'daki bilgileri toplayarak FooterRow'daki sütunlarda toplamı göstermeyi istiyoruz. DataSource'dan gelen veri bir Gridview satırına atıldıktan sonra RowDataBound Event'i tetiklenir. Bu Event içinde istediğimiz sütun değerini, Shared Field'a alıyoruz. Yani WebForm1 Class'ına ait bir Field'a alıyoruz. Böylece uygulama açık kaldığı sürece değer  hatırlanabilecek. Bu kullanım'ın istek bazında tetiklenseydi Field'daki değerler korunamayacağı için çalışmazdı. Fakat tek bir istekde bulunduğumuzda ve Event bu istek içinde birden fazla kez tetiklendiğinden sorun çıkmıyor. Yeni değeri geçerli değerle topladıktan sonra Event'da Footer'ı işlerken WebForm1 Class'ının Field'ındaki değeri istediğimiz sütuna atıyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        int totalUnitPrice = 0;
        int totalQuanitySold = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalUnitPrice += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
                totalQuanitySold += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QuantitySold"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Grand Total";
                e.Row.Cells[1].Font.Bold = true;

                e.Row.Cells[2].Text = totalUnitPrice.ToString();
                e.Row.Cells[2].Font.Bold = true;

                e.Row.Cells[3].Text = totalQuanitySold.ToString();
                e.Row.Cells[3].Font.Bold = true;
            }
        }
    }
}