 using System.Web.UI.WebControls;

namespace _21_TemplateField
{
    /*21. Ders Template Filed
     Gridview'ın tüm sütunlar varsaılan olarak BoundField kullanır. Fakat BoundField kullanan hücreye hiç bir Control ekleyemeyiz. Bir GridView sütunun Asp.net Control'leri ile çalışmasını istiyorsak, Sütunu TemplateField kullanarak oluşturmamız gerekir. Bir BoundField'ı TemplateField'a çevirmek için veya Gridview'a bir TemplateField eklemek için GridView Tasks penceresinden Edit Columns'u seçmemiz gerekir. Bir sütunu seçtikten sonra Convert this field to Template field'a tıklasak, sütun TemplateField ile oluşturulur. GridView'ı oluşturan Html'e bağtığımızda Template Field Control'ünün varsayılan olarak 2 parçadan oluştuğunu görürürüz. <EditItemTemplate> ve <ItemTemplate>. EditItemTemplate Edit Mode'a alınmış hücrenin kullanacağı Control'ü barındırırken, ItemTemplate görüntü için kullanılacak Control'ü belirler. GridView Tasks penceresini kullanarak TemplateField'lara Control eklemek için Edit Templates'e tıklayıp açılan penceredki DropDownList'den Template Field kullanan sütunları görebilir ve TemplateField'ın hangi kısmına Control eklemeyi istediğimiz şeçebiliriz. Sonrada pencereye gerekli kontrol'ü sürükleyip, End Edit Template'e tıklayarak işi bitirebiliriz. 
      
     Not: BoundField ile oluşturulmuş sütunun, Data Source kontrol'ündeki bir sütunun değerlerini alabilmesi için DataField Property'ne DataSource'daki bir sütun adını vermeliyiz. Fakat TemplateField'da veri Asp.net Control'lerine alınacağı için bu Property'i kullanamayız. TemplateFiedl içindeki Control'ün uygun Property'sine Data Source Control'ünden veri almak için Eva() veya Bind() methodlarını kullanabiliriz. Methodlara parametre olarak DataSource'daki sütun adını vermemiz yeterlidir. Eval ile Bind arasındaki fark; Eval'ın DataSource'dan veri alabilir, GridView'a Edit Mode'da girdiğimiz değeri uygulamaya getiremez. Yani Void dönen bir method gibidir. Bind'ise hem DataSource'daki veriyi okuyabilir hemde Edit Mode'daki GridView'a girilen değeri uygulamaya getirebilir.
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