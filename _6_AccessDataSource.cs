using System;

namespace _6_AccessDataSource
{
    /*
     AccessDataSource Control'ü kullanırken Configure Data Source penceresinde gerekli işlemleri yaptıktan sonra Microsoft.ACE.OLEDB.12.0 is not regestered hatası alabiliriz. Bu sorunu çözmek için videodaki link'den AccessDataBaseEngine'i indirmemeiz gerekir. Kulladığımız MS Office 32 bit ise 32'e uygun olanı indirmeliyiz. 32 bit sistemler için uygulamanın kullandığı Application Pool'e sağ tıklayıp, 32 bit için izin vermek gerekir. Sql Data Source gibi çalıştırılacak sorgu Html'de belirlenir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}