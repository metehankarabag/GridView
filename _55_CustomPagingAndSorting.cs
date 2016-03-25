using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _55_CustomPagingAndSorting
{
    /*55. Ders Sorting and Paging Witout Using DataSource Controls
      Geçen derslerde yaptığımız işi birleştirip yapıyoruz.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalRows = 0;
                GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(GridView1.PageIndex, GridView1.PageSize,GridView1.Attributes["CurrentSortField"],GridView1.Attributes["CurrentSortDirection"], out totalRows);
                GridView1.DataBind();
                DatabindRepeater(GridView1.PageIndex, GridView1.PageSize, totalRows);
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            int totalRows = 0;
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            GridView1.PageIndex = pageIndex;
            GridView1.Attributes["index"] = pageIndex.ToString();
            GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, GridView1.PageSize,GridView1.Attributes["CurrentSortField"],GridView1.Attributes["CurrentSortDirection"], out totalRows);
            GridView1.DataBind();
            DatabindRepeater(pageIndex, GridView1.PageSize, totalRows);
        }
        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(),i != (pageIndex + 1)));
                }
            }
            repeaterPaging.DataSource = pages;
            repeaterPaging.DataBind();
        }
        private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (sortField == gridView.Attributes["CurrentSortField"])
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
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridview(GridView1, e, out sortDirection, out sortField);
            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

            int totalRows = 0;
            GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(GridView1.PageIndex, GridView1.PageSize, e.SortExpression, strSortDirection, out totalRows);
            GridView1.DataBind();
            DatabindRepeater(GridView1.PageIndex, GridView1.PageSize, totalRows);
        }
    }
} 
