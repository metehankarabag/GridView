using System.Web.UI.WebControls;

namespace _14_SqlDataSource
{
    /*14. Ders Conflict Detection Property'i of th Sql Data Source
      Configure Data Source'un 2. penceresindeki Advanced butona tıkladığımızda açılan pencerede Insert,Update,Delete sorgularını ekleyen CheckBox'ı seçip gerekli işlemleri deçen ders yapmıştık. Şimdi bu penceredeki 2. seçenek olan Use Optimistic Concurrency seçeneğinin ne işe yaradığını göreceğiz.
      Geçen derste SqlDataSource'un Html'inde Delete işlemini uygulayacak sorgu, veri tabanında sileceği satırı belirlemek için Where'den sonra sadece Id değerini istiyordu. Fakat uygulama çalıştırıldıktan sonra biri veri tabanında silinecek satırı düzenlerse ve bu düzenlemeden sonra artık silinmemesi gerekiyorsa, uygulama çalışırdırımda olduğu için kullancını bu satırı silebilir. Sorguları oluştururken Use Optimistic Concurrency seçeneğini seçersek tüm sorgular Where'den sonra silinecek satırı belirlemek için satırın tüm değerlerini kullanır. Sorgu çalışmassa sayfa yenilenir ve güncel veriler kullanıcıya gösterilir.
      Not: GridView'ın RowDeleted Event'ı satır GridView'da silme işlemi gerçekleştikten sonra çalışır. GridViewDeletedEventArgs Class'ının AffectedRows Read-Only Property'si kaçtane satırın silindiğini gösterir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            lblMessage.Visible = true;
            if (e.AffectedRows > 0)
            {
                lblMessage.Text = "Employee row with EmployeeID = \"" + e.Keys[0].ToString() + "\" is successfully deleted";
                lblMessage.ForeColor = System.Drawing.Color.Navy;
            }
            else
            {
                lblMessage.Text = "Employee Row with EmployeeID = \"" + e.Keys[0].ToString() + "\" is not deleted due to data conflict";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}