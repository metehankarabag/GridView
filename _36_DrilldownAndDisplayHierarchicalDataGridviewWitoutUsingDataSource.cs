using System;
using System.Web.UI.WebControls;

namespace _36_
{
    /*36. Ders DrillDown And Display Hierarchical data GridView Witout Using DataSource Controls
      25. Dersde GridView'ın RowCommand Event'ını DataSource'lar yerine kullanmışdık. Bu derste de aynı Event'ı kullanacağız. GridView'a bir Select Button ekleyeceği bu Button'un tıkladığı satırdaki Id değerini alıp 2. GridView'ın veri kaynağını hazırlayacak methodu çalıştırıp, göstereceğiz. 
      
     Not: Aşağıdaki kodda 1. GridView'ın bi satırını seçtikten sonra RowCommand Event'ında 2. GridView yüklenir. 2. GridView'da bir satırı seçtiklen sonra 3. gridView yüklenir. 1. GridView'daki seçimi değiştirdiğimizde ise 1. gridView'ın Event'i 2. GridView'ı dataSource'u güncellenir. Fakat bu durum 2. GridView'ın Event'ını tetiklemeyeceği için 3. GridView yenilenmez. Bu sorunu 1. GridView'da 2. GridView'ın bir satırı seçilmişse, 3. GridView'ı güncelle diyerek çözmüş.
     */
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = ContinentDataAccessLayer.GetAllContinents();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectCountries")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                Label lblContinent = (Label)GridView1.Rows[rowIndex].FindControl("Label1");
                int continentId = Convert.ToInt32(lblContinent.Text);

                GridView2.DataSource = CountryDataAccessLayer.GetCountriesByContinent(continentId);
                GridView2.DataBind();

                GridView1.SelectRow(rowIndex); // --> Seçilmiş satırı belirlemek için 

                if (GridView2.SelectedValue != null)
                {
                    GridView3.DataSource = CityDataAccessLayer.GetCitiesByCountryId(Convert.ToInt32(GridView2.SelectedValue));
                    GridView3.DataBind();
                }
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectCities")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                Label lblCountry = (Label)GridView2.Rows[rowIndex].FindControl("Label2");
                int countryId = Convert.ToInt32(lblCountry.Text);

                GridView3.DataSource = CityDataAccessLayer.GetCitiesByCountryId(countryId);
                GridView3.DataBind();

                GridView2.SelectRow(rowIndex);
            }
        } 
    }
}