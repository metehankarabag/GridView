using System;

namespace _16_ObjectDataSources
{
    /*16. Ders Conflict Detection Property of the Object Data Source
     Geçen dersdeki sorgu veri tabanına sileceği satırı belirlemek için Where'den sonra sadece Id sütununu kullanıyordu. Tüm sütunları kullanmasını istiyoruz. Bu yüzden methoda parametre olarak tüm sütunları ekliyoruz. ObjectDataSource'u güncelledikten sonra çalıştırdığımızda hata veriyor. Bunun nedeni ObejectDataSource Control'ünün 2 Property'i otomatik olarak güncellememesidir. Bu yüzden ConflictDetection Property'sine CompareAllValues ve OldValuesParameterFormatString="orginal_{0}" özelliklerini eklememiz gerekir. Parametre isimleri bu ön eki alıyor. Bu Property'i görünen değerleri kullanan method parametrelerini tanımlamak içindir.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}