using System; 
using System.Web.UI.WebControls;

namespace _23_SqlDataSource
{
    /*23. Ders Insert - Update - Delete Using Sql Data Source 
     Update ve Delete işlemini Sql Data Source kullanarak yapmıştık. Bu işlerde bir değişiklik yok. GridView'a Insert işlemi için gerekli Control'leri ve Validation Controlleri ekleyeceğiz. SqlDataSource'a Insert işlemi için bir sorgu verdiğimizde, GridView'ın GridView Tasks penceresinde, Enable Inserting seçeneğini göremiyoruz. Bu yüzden Insert işlemi için gerekili Control'leri GridView'ın Footer'ına ekleyeceğiz. Sütunlar BoundField kullanılarak oluşturulduğundan Template Field'lara çevirmeden ekleyemeyiz. Sütunların sadece Footer'daki satırlarına Control eklemeyi istiyorsak, <FooterTemplate> alanı kullanmalıyız. 
     Veri tabanında çalışacak sorugu SqlDataSource belirler, bu yüzden Update veya Delete Button'a tıkladığımızda otomatik olarak SqlDataSource gerekili parametreler ile çalıştırılır. Fakat Insert işlemi için eklediğimiz Control'lerin SqlDataSource ile bir ilişkisi olmadığı için SqlDataSource'u otomatik olarak tetiklemiyor. Bu yüzden Insert Button'un Click Event'ını kullanarak, Button'a tıklama işlemi gerçekleştiğinde SqlDataSource'un InsertCommand Property'sini kodda tetiklemeliyiz. Bu iş için Click Event'da 2 iş yapmamız gerekir. Biri InsertCommand Property'sinin kullandığı InsertParameter'daki parametrelere değerlerini vermek diğeri SqlDataSource'un Insert() metodunu kullanarak sorguyu tetiklemek. Kullanıcının değerleri girdiği Asp.net Control'leri GridView'ın alt Control'ü olduğu için Control'lere direk ulaşıp değerlerini alamayız. Bu işi yapabilmek için GridView'ın hangi satırındaki Control'ü kullanacağımızı belirledikten sonra FindControl() methodunu uygulayıp methoda parametre olarak Control'ün Id değeri vermeliyiz. 
     
     Not: GridView'da varsayılan olarak Footer görüntülenmez gerekli property'i kullanarak düzetmek gerkeir.
     Not: Uygulamadaki herhangi bir Control'ü kullanarak sayfayı Server'a göndermek istediğimizde, tüm Validation Control'ler kontrol edilir. Bu sorunu Çözmek için post işleminde kullanılan Button ve ilişkili Validation Control'leri guruplamamız gerekir. Bu işi yapmak için tüm Control'lere ValidationGrup Property'sini kullanabiliriz. Her Validation Grup için bir tane ValidationSummary Control'ü kullanmaliyiz.
     Not: TemplateField'ın InsertVisible Property'sine False verdiğimizde kullanıcının değer girmesi için eklenmiş sütunlara değer girilemez.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void lbInsert_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue =((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
            SqlDataSource1.InsertParameters["Gender"].DefaultValue =((DropDownList)GridView1.FooterRow.FindControl("ddlInsertGender")).SelectedValue;
            SqlDataSource1.InsertParameters["City"].DefaultValue =((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
            SqlDataSource1.Insert();
        }
    }
}
