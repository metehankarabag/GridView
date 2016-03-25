using System;

namespace _38_UsingObjectDataSource
{
    /*38. Ders Using Object Data Source
      ObjectDataSource kullandığımızda, GridView'ın oluşturulması için veriyi getiren methodun dönüştüründe kullandığımız Bussiness Class'daki Property'ler kullanılır. Bu yüzden biz bu Class'daki tüm Property'lere değer girmesek bile Class'ın tüm Property'leri için GridView'da sütun oluşturulur. Bu yüzden sadece temel bilgileri barındırmak için gereki Property'leri olan bir Class oluşturup, methodun dönüş türünde bu Class'ı kullanıyoruz. DetailsView'da tüm bilgileri görüntülemek istediğimiz için başka bir Class oluşturup bu Class'a tüm Property'leri ekleyebiliriz. Aynı Property'leri tekrar tekrar yazmak yerine Base Class'ın Property'lerini kullanmak için kalıtımdan yararlanabiliriz.
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

    }
}