using System;
using System.Web.UI.WebControls;

namespace _8_DataBoundEvent
{
    /*8. Data Bound Event
     Gridview'ın RowDataBound Event'ı bir satırın tüm sütunlarına veri bağlama işlemi gerçekleşdikten hemen sonra tetiklenir. Yani satıra gelen veriyi Event'ın EventArgs parametresinde alıp, üzerinde değişiklikler yapabiliriz. Düzenlenmiş veriyi tekrar geçerli sütuna vermessek, Gridview'da eski veri görünür. Yani bu Event her satır için ayrı ayrı çalışan bir Event'dır. GridViewRowEventArgs Class'ında sadece GridViewRow türünde Read-Only Row Property'si var. Bu Property'i kullanarak tüm sütunlara ulaşabiliriz.
      Event'i kullanarak, her satırda farklı para sembolü uygulamayı istiyoruz. Satırda hangi para sembolünün kullanılmak istediğini dinamik olarak belirleyebilmemiz için satırların ülke değerini içeren sütunları olmalıdır. Row Property'sini kullanarak ülke değerini aldıktan sonra ülkenin kullandığı para sembolüne ulamak için CultureInfo Class'ına parametre olarak ülke değerini veriyoruz. String Class'ının Static Format methodunu kullanarak, sembol ile yine Row Property'sini kullanarak aldığımız para değerini birleştiriyoruz.
      
     Not: Uygulamanın kullandığı Culture'u değiştirmek için System.Threding.Thread Class'ınıdan ulaştığımız CurrentCultre Property'sine yeni değer verebiliriz. Fakat bu değer bir sonraki satır için geçerli olduğundan doğru sonucu alamıyoruz.
     Not: Tüm Cultre değerlerini almak için Culture Class'ının GetCultures() Static methoduna parametre olarak CultureTypes Enum'unun AllCultures değeri vermeliyiz
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text == "US")
                {
                    int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                    string formattedString = string.Format(new System.Globalization.CultureInfo("en-US"), "{0:c}", salary);
                    e.Row.Cells[2].Text = formattedString;
                }
                else if (e.Row.Cells[3].Text == "UK")
                {
                    int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                    string formattedString = string.Format(new System.Globalization.CultureInfo("en-GB"), "{0:c}", salary);
                    e.Row.Cells[2].Text = formattedString;
                }
                else if (e.Row.Cells[3].Text == "India")
                {
                    int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                    string formattedString = string.Format(new System.Globalization.CultureInfo("en-IN"), "{0:c}", salary);
                    e.Row.Cells[2].Text = formattedString;
                }
                else if (e.Row.Cells[3].Text == "South Africa")
                {
                    int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                    string formattedString = string.Format(new System.Globalization.CultureInfo("en-ZA"), "{0:c}", salary);
                    e.Row.Cells[2].Text = formattedString;
                }
                else if (e.Row.Cells[3].Text == "Malaysia")
                {
                    int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                    string formattedString = string.Format(new System.Globalization.CultureInfo("en-MY"), "{0:c}", salary);
                    e.Row.Cells[2].Text = formattedString;
                }
            }
        }
    }
}