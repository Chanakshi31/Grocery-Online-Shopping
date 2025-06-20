using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryWorld.View.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            if (!IsPostBack) // Ensure the data is only loaded once, not on every postback
            {
                GetProducts();
                GetCategories();
                SumSell();
                GetSellers();
                GetSeller();
                SumSellBySeller();
            }
        }

        private void GetSeller()
        {
            string Query = "SELECT * FROM Seller";

            // Fetch data once
            var data = Con.getData(Query);

            // Check if data is valid
            if (data != null && data.Rows.Count > 0)
            {
                SellerCb.DataSource = data; // Set data source
                SellerCb.DataTextField = "SelName"; // Set display field
                SellerCb.DataValueField = "SelId"; // Set value field
                SellerCb.DataBind(); // Bind data
            }

            // Add a default "Select Seller" option
            SellerCb.Items.Insert(0, new ListItem("-- Select Seller --", "0"));
        }

        private void GetProducts()
        {
            string Query = "SELECT COUNT(*) AS Number FROM ProductTb";
            var result = Con.getData(Query);
            if (result != null && result.Rows.Count > 0)
            {
                PNumTb.InnerText = result.Rows[0][0].ToString();
            }
        }

        private void GetCategories()
        {
            string Query = "SELECT COUNT(*) AS Number FROM CategoryTbl";
            var result = Con.getData(Query);
            if (result != null && result.Rows.Count > 0)
            {
                CatNumTb.InnerText = result.Rows[0][0].ToString();
            }
        }

        private void GetSellers()
        {
            string Query = "SELECT COUNT(*) AS Number FROM Seller";
            var result = Con.getData(Query);
            if (result != null && result.Rows.Count > 0)
            {
                SelNumTb.InnerText = result.Rows[0][0].ToString();
            }
        }

        private void SumSellBySeller()
        {
            try
            {
                if (SellerCb.SelectedValue != null)
                {
                    string sellerId = SellerCb.SelectedValue;
                    string Query = "SELECT SUM(Amount) AS Total FROM BillTbl WHERE Seller = " + sellerId;
                    var data = Con.getData(Query);

                    if (data.Rows[0][0] != DBNull.Value)
                    {
                        TotalTb.InnerText = "Rs " + data.Rows[0][0].ToString();
                    }
                    else
                    {
                        TotalTb.InnerText = "Rs 0";
                    }
                }
            }
            catch (Exception ex)
            {
                TotalTb.InnerText = "Error!";
            }
        }

        private void SumSell()
        {
            try
            {
                string Query = "SELECT SUM(Amount) AS TotalFinance FROM BillTbl";
                var data = Con.getData(Query);

                if (data.Rows[0][0] != DBNull.Value)
                {
                    FinanceTb.InnerText = "Rs " + data.Rows[0][0].ToString();
                }
                else
                {
                    FinanceTb.InnerText = "Rs 0";
                }
            }
            catch (Exception ex)
            {
                FinanceTb.InnerText = "Error!";
            }
        }


        protected void SellerCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SumSellBySeller();
        }
    }
}
