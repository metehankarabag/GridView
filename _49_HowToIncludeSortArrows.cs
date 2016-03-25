using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _49_HowToIncludeSortArrows
{
    /*49. Ders How to Include Sort Arrow
      Kullanıcıya geçerli sıralama sütununu ve sıralama yönünü göstermek için sütun başlıklarına ok işareti eklemeyi istiyoruz. Varsayılan bir ayar ile GridView ilk yüklendiğinde sıralanır, bu yüzden ok kullanıcıya GridView ilk yüklendiğinde de gösterilmeli. Ok resimlerini GridView'a eklemek işin GridView oluşturulurken yapabiliriz. GridView'ın RowCreated Event'ı GridView satırı oluşturduktan sonra tetiklenir. Bu Event'ı kullanarak oluşturulmuş satırın bir sütununa, oku ekleyebiliriz.
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
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Eklediğim Property'ler null değişse(ki hiç bir zaman olmayacak)  
            if (GridView1.Attributes["CurrentSortField"] != null && GridView1.Attributes["CurrentSortDirection"] != null) 
            {
                if (e.Row.RowType == DataControlRowType.Header) 
                {
                    foreach (TableCell tableCell in e.Row.Cells) //Oluşturulan Satırların hepsine bir şeyler ekleceğimiz için sütun içine girmeliyiz.
                    {
                        if (tableCell.HasControls())// Header'da COntroller varmı
                        {
                            LinkButton sortLinkButton = null;
                            if (tableCell.Controls[0] is LinkButton) //Zaten sadece 1. tane olduğu için birinci Link Button mu. Bunları zaten biliyoruz.
                            {
                                sortLinkButton = (LinkButton)tableCell.Controls[0]; // Sütundaki Link Buttonu al
                            }

                            if (sortLinkButton != null && GridView1.Attributes["CurrentSortField"] == sortLinkButton.CommandArgument)
                            {
                                Image image = new Image();
                                if (GridView1.Attributes["CurrentSortDirection"] == "ASC")
                                {
                                    image.ImageUrl = "~/Images/up_arrow.png";  // Image'i göster
                                }
                                else
                                {
                                    image.ImageUrl = "~/Images/down_arrow.png";
                                }
                                tableCell.Controls.Add(new LiteralControl("&nbsp;")); //Boşluk eklemek için Sütuna kontrol ekledik.
                                tableCell.Controls.Add(image);
                            }
                        }
                    }
                }
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
                gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }
        }
    }
} 