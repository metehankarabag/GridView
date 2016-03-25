using System;

namespace _43_NestedGridview
{
    /* 43. Ders Nesned GridView
      32. Derste Nesned GridView kullanmıştık. Nesned GridView bir GridView sütundaki GriView'a denir. Bu derste bir adım daha ait 3. seviyede nesned GridView kullanmış. İçdeki GridView dıştaki gridview'ın bir sütunundan tüm verisini alacağı için içdeki GridView'ın DataSource Property'isine Bind() methodunu uygulamamız gerekir. Sadece göstermek için kullandığımız için Eval'da kullanabiliriz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = ContinentDataAccessLayer.GetAllContinents();
            GridView1.DataBind(); 

        }
    }
}