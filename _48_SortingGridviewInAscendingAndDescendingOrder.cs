using System;
using System.Web.UI.WebControls;

namespace _48_InAscAndDescOrder
{
    /* 48. Ders Sorting a Gridview In Asc And Desc Order
       Geçen deste benim yazdığım kod daha basit fakt burada yapılan işi daha çok gerçek uygulamara göre hazırlanmış
      
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees("EmployeeId");
                GridView1.DataBind();
            }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;
            SortGridview((GridView)sender, e, out sortDirection, out sortField);

            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";
            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees(e.SortExpression + " " + strSortDirection);
            GridView1.DataBind();
            
            TextBox1.Text = TextBox1.Attributes["ABC"];
        }
        private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {                        
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null) //Property'lere değer verdiğimiz için Null olmayacaklar
            {
                if (sortField == gridView.Attributes["CurrentSortField"]) // Sadece Property'i aynıysa yön değiştirmek için kullanılır. 
                {
                    if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }

                gridView.Attributes["CurrentSortField"] = sortField;
                gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        } 
    }
}