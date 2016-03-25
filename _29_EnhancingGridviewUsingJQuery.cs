using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _29_EnhancingGridviewUsingJQuery 
{
    /*29. Ders Enhancing Gridview Using JQuery
     CheckBox'ın CheckedChanged Event'ı Server'a çalışıyor, yani her seferinden sayfa Server'a gönderiliyor. Bu durum her seferinde HMTL'in yeniden oluşturulması gibi performans kaybına yol açar. Bunu düzeltmek için Java scrpit kullanacağız. bunun yerine aynı işi Client'da yapabilecek JavaScript kullanabiliriz. 
      
      JavaScript kodunu açıklamıyorum. Çünkü anlamadım.
      
      function toggleSelectionUsingHeaderCheckBox(source) -> Header'daki seçili ise diğerlerini seç
		{
            $("#GridView1 input[name$='cbDelete']").each(function () {
                $(this).attr('checked', source.checked);
            });
        }
        function toggleSelectionOfHeaderCheckBox() 
		{  --> Sanırım burada DataRow satırlarındaki CheckBox'lar seçili ise Header'dakini seç diyor.
            if ($("#GridView1 input[name$='cbDelete']").length == $("#GridView1 input[name$='cbDelete']:checked").length) { 
                $("#GridView1 input[name$='cbDeleteHeader']").first().attr('checked', true);
            }
            else {
                $("#GridView1 input[name$='cbDeleteHeader']").first().attr('checked', false); -> Üstte ne yazıyorsa tersi :D
            }
        }
     
        $(document).ready(function () 
		{
            $("#btnDelete").click(function () 
			{
                var rowsSelected = $("#GridView1 input[name$='cbDelete']:checked").length; --> Buradan anladığıma göre gridView'ın bu kod gridView'ın tüm satırları için çalışıyor.
                if (rowsSelected == 0) 
				{
                    alert('No rows selected');
                    return false;
                }
                else
                    return confirm(rowsSelected + ' row(s) will be deleted');
            });
        });
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> lstEmployeeIdsToDelete = new List<string>();
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                if (((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                {
                    string employeeId =
                        ((Label)gridViewRow.FindControl("lblEmployeeId")).Text;
                    lstEmployeeIdsToDelete.Add(employeeId);
                }
            }
            if (lstEmployeeIdsToDelete.Count > 0)
            {
                EmployeeDataAccessLayer.DeleteEmployees(lstEmployeeIdsToDelete);
                GetData();
                lblMessage.ForeColor = System.Drawing.Color.Navy;
                lblMessage.Text = lstEmployeeIdsToDelete.Count.ToString() +
                    " row(s) deleted";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No rows selected to delete";
            }
        }
    }
}
