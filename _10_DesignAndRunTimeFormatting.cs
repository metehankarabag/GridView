using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _10_DesignAndRunTimeFormatting
{
    /* RowDataBound Event'ı GridView'daki her satır için ayrı ayrı çalıştığından, Event'ı, sütunlardan aldığımız değerlere göre satırlara dinamik özellikler uygulamak için kullanabliriz.
       Gridview'ın Style Property'lerinin bazıları
       BackColor/ForeColor: Tüm satırların BackGround/yazı rengini belirlemek için kullanılabilir. 
       HeaderStyle/RowStyle: Property'si penceresinde Header'a/DataRow'a uygulayabileceğimi Property'leri gösterir. RowStyle'a BackColor rengi verdiğimizde tüm DataRow satırlarına uygulanır. Row satırlarında 2 rengi sırayla kullanmayı istiyorsak, Properties penceresinde AlternatingRowStyle'ı açıp burada da başka bir değer seçmeliyiz. Aynı durum tüm Row türleri için geçerlidir. 
       EditRowStyle: Edit Mode alınan DataRow'lara uygulanan Style'ı belirler.
       
       Not: Bir sütü var. Html'de görüntüleyebiliriz.
       Not: GridView'ın bir sütunundaki değeri EventArgs nesnesinden almanın 2 yolu var. 
        1. Row Property'sine Cell Property'sini uygulayıp, Cells Property'sine Index değeri vermek. 
        2.DataBinder Sealed Class'ının Eval() methodunu kullanmak.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int salary = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AnnualSalary"));
                if (salary > 70000)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
        } 
    }
}