using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryWorld.View.Seller
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions Con;
        DataTable dt = new DataTable();
        int Seller = Login.Skey; // Seller ID
        public static int Amount; // Total amount
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowProducts();

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
            new DataColumn("Id"),
            new DataColumn("Product"),
            new DataColumn("Price"),
            new DataColumn("Quantity"),
            new DataColumn("Total")
        });
                ViewState["Bill"] = dt;
                BindGrid();
            }

            // Handle JavaScript-triggered postback for inserting bill
            if (Request["__EVENTTARGET"] == "InsertBillHandler")
            {
                InsertBill(DateTime.Now, Seller.ToString(), Amount);
            }
        }

         private void InsertBill(DateTime billDate, string seller, int amount)
          {
            try
            {
                // Insert query with parameters
                string query = "INSERT INTO BillTbl (BillDate, Seller, Amount) VALUES (@BillDate, @Seller, @Amount)";
                Con.setData(query,
                    new SqlParameter("@BillDate", billDate),
                    new SqlParameter("@Seller", seller),
                    new SqlParameter("@Amount", amount));

                // Display success message
                ErrMsg.InnerText = "Bill Inserted Successfully!";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Error inserting bill: " + ex.Message;
            }
        }


        private void BindGrid()
        {
            BillGV.DataSource = (DataTable)ViewState["Bill"];
            BillGV.DataBind();
        }


        
        //Add this method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowProducts()
        {
            string query = "SELECT PrId AS Id, PrName AS Name, PrCat AS Category, PrPrice AS Price, PrQty AS Quantity FROM ProductTb";
            ProductGV.DataSource = Con.getData(query);
            ProductGV.DataBind();
        }

        int key = 0;
        int Stock;

        public object PrQty { get; private set; }
        public object InsertBillHiddenField { get; private set; }

        protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PName.Value = ProductGV.SelectedRow.Cells[2].Text;
            PPrice.Value = ProductGV.SelectedRow.Cells[4].Text;
            Stock = Convert.ToInt32(ProductGV.SelectedRow.Cells[5].Text);

            if (string.IsNullOrEmpty(PName.Value))
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
            }
        }

        private void UpdateStock()
        {
            try
            {
                int newQty = Convert.ToInt32(ProductGV.SelectedRow.Cells[5].Text) - Convert.ToInt32(PrQuantity.Value);

                string query = "UPDATE ProductTb SET PrQty = @NewQty WHERE PrId = @ProductId";
                Con.setData(query,
                    new SqlParameter("@NewQty", newQty),
                    new SqlParameter("@ProductId", ProductGV.SelectedRow.Cells[1].Text));

                ShowProducts();
                ErrMsg.InnerText = "Quantity Updated Successfully!";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Error updating stock: " + ex.Message;
            }
        }
        int GrdTotal = 0;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int total = Convert.ToInt32(PrQuantity.Value) * Convert.ToInt32(PPrice.Value);
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(BillGV.Rows.Count + 1,
                    PName.Value.Trim(),
                    PPrice.Value.Trim(),
                    PrQuantity.Value.Trim(),
                    total);

                ViewState["Bill"] = dt;
                BindGrid();
                UpdateStock();

                GrdTotal = 0;
                foreach (GridViewRow row in BillGV.Rows)
                {
                    GrdTotal += Convert.ToInt32(row.Cells[4].Text);
                }

             

                // Update UI
                GrdTotTb.InnerHtml = "Rs " + GrdTotal;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "updateTotal",
                    $"document.getElementById('TotalAmountPlaceholder').innerText = '{GrdTotal}';", true);

                // Clear inputs
                PName.Value = string.Empty;
                PPrice.Value = string.Empty;
                PrQuantity.Value = string.Empty;
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Error adding to bill: " + ex.Message;
            }
        }

      
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // JavaScript to trigger postback after print dialog
                string script = @"
            window.onafterprint = function() {
                __doPostBack('InsertBillHandler', '');
            };
            window.print();
        ";

                // Register script for print and server-side insertion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintAndInsert", script, true);

                // Optionally refresh UI
                ShowProducts();
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Error during printing: " + ex.Message;
            }
        }
    }
}