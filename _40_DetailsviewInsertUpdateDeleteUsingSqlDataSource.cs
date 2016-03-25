using System;
using System.Web.UI.WebControls;

namespace _40_UsingSqlDataSource
{
    /*40. Ders Insert Update Delete Using SqlDataSource
      SqlDataSource'a Insert update ve Delete sorgularını ekledikten sonra DataSouce'u DetailsView ile ilşikilendirdiğimizde, Enable Inserting seçeneğini de görebiliriz. Insert işlemi veri tabanına bir satır eklemek için kullanılır. DetailsView'ın ItemInserted ItemDeleted ve ItemUpdated Event'leri DetailsView'daki herhangi bir satır üzerinde işlem yapılırsa, tetiklenir.
     */

     /*41. Ders Insert - Update - Delete Using ObjectDataSource
      Bir Fark yok.
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
        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectRow(-1);
        }
        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectRow(GridView1.SelectedIndex);
        }
        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectRow(-1);
        }
    }
}