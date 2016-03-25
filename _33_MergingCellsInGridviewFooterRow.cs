using System.Web.UI.WebControls;

namespace _33_MergingCellsInGridviewFooterRow
{
    /*33. Ders Merging Cells In Gridview FooterRow
     Aşağıda yaptık. Bir Tablo Cell oluşturup Bu hücrenin 4 hücrenin brileşiminden oluştuğunu belirtiyoruz. Sonrada GridView'ın FooterRow'una ekliyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        int Count = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Count += 1;                
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells.Clear();
                TableCell tableCell = new TableCell();
                tableCell.ColumnSpan = 4;
                tableCell.Font.Bold = true;
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                tableCell.Text="Total Employees Count = "+ Count.ToString();
                e.Row.Cells.Add(tableCell);
                


            }
        }
    }
}