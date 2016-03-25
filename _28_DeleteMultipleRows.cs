using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _28_DeleteMultipleRows
{
    /*28. Ders Delete Multiple Rows
      Bu Derste GridView ile iligi çok fazla bir şey yok. Fakat GridView'ı baştan sonra elle oluşturduğu için ders biraz uzun. GridView'a TemplateField ile oluşturulmuş bir sütun ekliyoruz. Bu sütunun DataRow ve HeaderRown'una Checkbox eklememiz gerkiyor. Bu yüzden itemtemplate ve HeaderTemple alanlarını kullanıyoruz. Header'a eklediğimiz CheckBox seçildiğinde, DataRow'daki tüm CheckBox'lar seçilecek ve Checked işareti kaldırıldığında DataRow'dakilerin işaretide kaldırılacak. Bu işi yapabilmemiz için Header'a eklediğimiz CheckBox'ın CheckedChanged Event'ını kullanabiliriz. Event'ın sender parametresinde Header'daki CheckBox Control'üne ulaşıp değerini alabiliriz. Bu değeri DataRow'daki tüm ChechBox'lara verebilmemiz için GridView'ın tüm satırlarını dönmemiz ve belirlenen sütundaki Control'e ulaşmamız gerekir. GridView'ın GridViewRowCollection türündeki Read-Only Rows Property'sini kullanarak, GridView'ın tüm satırlarına ulaşabiliriz. Satırlar içindeki Control'lere ulaşmayı daha önce yapmıştık. DataRow'daki CheckBox'lar içinde benzer işler yapıyoruz.
      
      Delete Methodu açıklaması
      Birden fazla satırın aynı anda silinebilmesini istediğimiz için kullandığımız Delete Methodu parametre olarak List<string> bekliyor. Oluşturacağımız sorgunun tek seferde tüm değerleri alarak veri tabanındaki satırları silmesi için Delete Sorgusun Where'den sonra In() anahtarını uyguluyoruz. Sql Injection olmaması için In() içinde parameter oluşturmamız gerekiyor. Fakat kullanıcının ne kadar satır seçdiğini bilemeyeceğimiz için bu iş dinamik olarak yapmalıyız. Method parametresindeki Listeye Select() Extesion methodunu uygulayarak, seçilen her satır için dinamik bir parametre adı belirledikten sonra yeni bir listeye parametre isimlerini atıyoruz. Bu listedeki her üyeyi araya virgül gelecek sekilde bir string'de birleştirip In() içine atıyoruz. Sorguyu SqlCommand'a attıktan sonra parametre isimlerini barındıran listeyi kullanarak sorgu parametrelerini oluşturuyoruz..
      
     Not: GridView'ın veri kaynağındaki veri BoundField ile almayı istiyorsak, BoundField'ın DataField Property'si, ItemTemplate içindeki Control'e almak istiyosak, Bind() methodunu kullanabiliriz.
     Not: Eval() methodu GridView hücresindeki değeri uygulamaya almak için kullanılır. 
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        public void GetData()
        {
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees();
            GridView1.DataBind();
        }

        protected void cbDeleteHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                ((CheckBox)gridViewRow.FindControl("cbDelete")).Checked = ((CheckBox)sender).Checked;
            }
        }

        protected void cbDelete_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (CheckBox)GridView1.HeaderRow.FindControl("cbDeleteHeader");
            if (headerCheckBox.Checked)//Header'daki CheckBox seçiliyse DataRow'daki tüm CheckBox'larda seçilidir.
            {
                headerCheckBox.Checked = ((CheckBox)sender).Checked;// Yani Event'ı tetikleyen CheckBox artık UnChecked, biri seçili olmadığında Header'dakininde seçili olmaması gerekir.
            }
            else
            {
                bool allCheckBoxesChecked = true;
                foreach (GridViewRow gridViewRow in GridView1.Rows)
                {
                    // Tüm CheckBox'lar seçili ise içeri girmeyeceği için, aşağıdaki Code Header'daki CheckBox'ı Checked değeri gönderir.
                    if (!((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                    { 
                        allCheckBoxesChecked = false; break; 
                    }
                }
                headerCheckBox.Checked = allCheckBoxesChecked;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> lstEmployeeIdsToDelete = new List<string>();
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                if (((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                {
                    string employeeId = ((Label)gridViewRow.FindControl("lblEmployeeId")).Text;
                    lstEmployeeIdsToDelete.Add(employeeId);
                }
            }
            if (lstEmployeeIdsToDelete.Count > 0)
            {
                EmployeeDataAccessLayer.DeleteEmployees(lstEmployeeIdsToDelete);
                GetData();
                lblMessage.ForeColor = System.Drawing.Color.Navy;
                lblMessage.Text = lstEmployeeIdsToDelete.Count.ToString() + " row(s) deleted";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No rows selected to delete";
            }
        }
    }
}
