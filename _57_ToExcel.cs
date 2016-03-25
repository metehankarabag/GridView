using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _57_ToExcel
{
    /*57. Ders Export GridView Data to Excel
      Server'dan Client bilgisayarına bir şey göndermek istiyorsak, Response nesnesini kullanırız. Örneğin Client'a Cookie eklemeyi istiyorsak, Response Property'sini kullanırız. Response Property'si Page Class'ının HttpResponse türündeki Read-Only Property'sidir. Bu Class'ın Void dönen ClearContent(), AppendHeader(), String türündeki ContentType Property'sini kullanık.
      ClearContent(): Buffer Stream'deki tüm çıktı içeriğini temizlemek için fakat Buffer Stream'den ne kastetdiğini tam anlamadım.
      AppendHeader(): Buffer Stream'a bir Http Header ekliyorumuz. Fakat hiç bişe anlamadım. 1. parametresine rasgele bir değer verdiğimde WebForm1.aspx dosyası indiriyor.
      ContentType: Çıktının Http MIME türünü ayarlıyor veya alıyormuşuz.(Mime'i Wcf Service de görmüştüm.) Anladığım kadaryla bilginin yazdırılacağı dosya formatını beliliyoruz. 
      
      Control Class'ının RenderControl() methodu parametre olarak HtmlTextWriter nesnesi alır ve uygulandığı Control'ün içeriğini(Html'ini falan sanırım) parametre olarak aldığı nesnede depolar. HtmlTextWriter Class'ının 2 overload'ı var ve 2'side parametre olarak TextWriter nesnesi bekliyor ve parametre olarak veridğimiz nesneyi çalıştırıyor. StringWriter Class'ı TextWriter'dan türediği için parametre olarak StringWriter örneği veribiliyoruz. Dosyaya yazma işini HttpResponse Class'ının Write() methodu yapar. Yani üstteki işlemler çıktının nereye yazılacağını belirlemek için. Parametre olarak yazılacak yazıyı vermemiz gerektiği için ve StringWriter nesnesi verdiğimiz için HtmlTextWriter'in yaptığı iç Control'ün html'ini StringwWriter'a atmak sonrada End() methodu işlemi bitirir ve sayfanın işleyişini durdurur.
                    
     Not: 2 Button var 2'sinde de aynı iş yapılıyor tek fark dosya türünü ve uzantısını belirlediğimiz değerlerde.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblEmployee", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.xls");
            Response.ContentType = "application/excel";

            ControlStyleIleDosyayaYaz();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.doc");
            Response.ContentType = "application/word";

            ControlStyleIleDosyayaYaz();
        }

        private void ControlStyleIleDosyayaYaz()
        {
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(); // Bu 2 Class gerekli.
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            //Bu Foreach'lerin yaptığı iş GridView'ın yazdırılacağı dosyanın stilini belirlemek.
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            foreach (TableCell tableCell in GridView1.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#A55129";
            }

            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }

            GridView1.RenderControl(htw); //Bu method parametre olarak girdiğimiz nesneye GrdiView'ın verisini yazar.
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        //Bu RenderControl() methodunun hata vermesini engelliyor.
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}