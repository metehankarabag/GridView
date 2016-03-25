using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _56_PagingUsingaDropDownList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalRows = 0;
                GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(0, 5,GridView1.Attributes["CurrentSortField"],GridView1.Attributes["CurrentSortDirection"], 
                    out totalRows);
                GridView1.DataBind();

                Databind_DDLPageNumbers(0, 5, totalRows);
            }
        }
        private void Databind_DDLPageNumbers(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            if (totalPages > 1)
            {
                ddlPageNumbers.Enabled = true;
                ddlPageNumbers.Items.Clear();
                for (int i = 1; i <= totalPages; i++)
                {
                    ddlPageNumbers.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            else
            {
                ddlPageNumbers.SelectedIndex = 0;
                ddlPageNumbers.Enabled = false;
            }
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
                gridView.Attributes["CurrentSortDirection"] =  (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridview(GridView1, e, out sortDirection, out sortField);
            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";

            int totalRows = 0;

            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            int pageIndex = int.Parse(ddlPageNumbers.SelectedValue) - 1; 
           

            GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, pageSize,e.SortExpression, strSortDirection, out totalRows);
            GridView1.DataBind();
            ddlPageNumbers.SelectedValue = (pageIndex + 1).ToString();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalRows = 0;

            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            int pageIndex = 0;

            GridView1.PageSize = pageSize;

            GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, pageSize, GridView1.Attributes["CurrentSortField"], GridView1.Attributes["CurrentSortDirection"],
                out totalRows);
            GridView1.DataBind();

            Databind_DDLPageNumbers(pageIndex, pageSize, totalRows);
        }
        protected void ddlPageNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalRows = 0;

            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            int pageIndex = int.Parse(ddlPageNumbers.SelectedValue) - 1;

            GridView1.PageSize = pageSize;

            GridView1.DataSource = EmployeeDataAccessLayer.GetEmployees(pageIndex, pageSize, GridView1.Attributes["CurrentSortField"], GridView1.Attributes["CurrentSortDirection"],
                out totalRows);
            GridView1.DataBind();
        }
    }
}