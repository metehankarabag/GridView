using System;

namespace _30_UsingTemplateField
{
    /*30. Ders Displaying Images Using TemplateField
     Gridview'da fotograf göstermek istiyorsak, veri tabanından fotograf'ın yolunu alırız. Bu yolu Image Control'ün Src Property'sine veridğimizde Image Control'ü eklediğimiz TemplateField'da resim görünür.
     */
    /*31. Ders Displaying Images Using Image Field
    ImageField DataBound Control'ler de Image göstermek için oluşturulmuş Field'lardır. TemplateField kullanmaktan daha iyidir.
    ImageField'ın DataImageUrlField Property'sine veri tabanında Url'i barındıran sütunun adını veriyoruz.
                  AlternateText Property'si resim yokken görüntülenecek yazıyı belirler. Fakat Google Chrome'da çalışmıyor. Internet Explorer'da çalıştırıp PageSource'a baktığımızda AlternateText Property'i ile belirlediğimiz yazı <img> tag'ının Alt Attribute'una aktarıldığını görürüz.
                  DataAlternateTextField Property'simi kullanarak, veri tabanında aldığımız Url bir fotografı göstermiyorsa, kişiye özel alt text yazdırabiliriz. Chrome desteklemiyor.
                  NullImageUrl Property'sine Url'i barındıran sütundan hiç değer almıyorsak, varsayılan resim belirlemek için bu Property'e Url verebiliriz. 
                  NullDisplayText Property'sine üstteki durumda resim yerine yazı göstermeyi istiyorsak, kullanabiliriz.    
    
      Fotografın boyutlarını ayarlamak için ControlStyle-Height ControlStyle-Width Property'lerini kullanmalıyız.
    */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees();
            GridView1.DataBind();
        }
    }
}