using System;
using System.Web.UI.WebControls;

namespace _19_WithOptimistcConcurrency
{
    /*19. Ders Optimistic Concurrency for the Editing
     Object Data Source kullanarak Delete işlemi için aynı işi yapmıştık. Özel bir şey yok. Yani Edit sorgusu için kullandığımız method parametresinde hem yeni değerleri hemde GridView'da görünen değerleri almak zorundadır.
     */
    /*20. Ders Keep GridView in Edit Mode When Update Fails due to Data Conflict
     Gridview'ın RowUpdated Event'u güncelleme işlemi veri tabanında gerçekleştikten sonra çalışır. GridViewUpdatedEventArgs Class'ının AffectedRow Property'sini kullanarak satırın güncellenip güncellenmediğini anlayabiliriz. Fakat bu Sql Data Source kullanırken düzgün çalışıyor. Object Data Source kullanırken düzgün çalışmıyor. Bunun bir kaç nedeni var.
     1. Güncelleme işlemi için kullandığımız methodun Void dönmesi. Methodu sorgunun etkilediği satır sayısını dönecek sekilde yeniden ayarlıyoruz. 
     2. Güncelleme işlemi GridView'da Update'e tıkladığında, update işleminin veri tabanında çalışması için uygulama Object Data Source'a gelir ve methodu çalıştırır. Method metho sonucunda etkilenen satır sayısını DataSource Control'e almalıyız. Object Data Source Control'ünün Updated Event'ı güncelleme veri tabanında gerçekleştikten sonra çalışır.Event'in EventArgs Class'ının ReturnValue değeri methodun dönüş değerini alan Prametredir. Bu parametreden aldığımız değeri yine aynı EventArgs Class'ının AffectedRows Property'sine veriyoruz. 
      
     Not: AffectedRows Property'i EventArgs Base Class'ının bir Property'si değil yani her EventArgs Class'ı içinde bir tane var. Bir birlerini nasıl etkilediğini anlamadım.
     Not: Method veri tabanında string gibi değerler dönebileceği için Property'e girilen değerin int olup olmadığını kontrol etmemiz gerekir.
     Not: GridViewUpdatedEventArgs Class'ının KeepInEditMode Property'sini kullanarak, güncelleme başarısız olduğunua Edit Mode durumunu koruyabiliriz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.AffectedRows < 1)
            {
                e.KeepInEditMode = true;
                lblMessage.Text = "Row with EmployeeId = " + e.Keys[0].ToString() + " is not update due to data conflict";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.Text = "Row with EmployeeId = " + e.Keys[0].ToString() + " is successfully updated";
                lblMessage.ForeColor = System.Drawing.Color.Navy;
            }
        }
        protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue is int && (int)e.ReturnValue > 0)
            {
                e.AffectedRows = (int)e.ReturnValue;
            }
        }
    }
}