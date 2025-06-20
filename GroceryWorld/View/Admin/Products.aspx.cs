using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryWorld.View.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            GetCategories();
            ShowProducts();

        }

        private void GetCategories()
        {
            string Query = "Select * from CategoryTbl";
            CategoryPr.DataTextField = Con.getData(Query).Columns["CatName"].ToString();
            CategoryPr.DataValueField = Con.getData(Query).Columns["Catid"].ToString();
            CategoryPr.DataSource = Con.getData(Query);
            CategoryPr.DataBind();

        }

        //Add this method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowProducts()
        {
            string Query = "select * from ProductTb";
            ProductGV.DataSource = Con.getData(Query);
            ProductGV.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        { 
            try
            {
                if (PName.Value == "" || CategoryPr.DataTextField == "" || PPrice.Value == "" || PrQuantity.Value == "" || PExpdate.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string PrName = PName.Value;
                    string PrCat = CategoryPr.SelectedValue;
                    string PrPrice = PPrice.Value;
                    string PrQua = PrQuantity.Value;
                    string PrExDate = PExpdate.Value;

                    string Query = "insert into ProductTb values ('{0}','{1}',{2},{3},'{4}')";
                    Query = string.Format(Query, PrName, PrCat, PrPrice, PrQua, PrExDate);
                    Con.setData(Query);
                    ShowProducts();
                    ErrMsg.InnerText = "Product Added !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
           
        }

        int key = 0;

        public object SelectedRow { get; private set; }

        protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PName.Value = ProductGV.SelectedRow.Cells[2].Text;
            CategoryPr.SelectedValue = ProductGV.SelectedRow.Cells[3].Text;
            PPrice.Value = ProductGV.SelectedRow.Cells[4].Text;
            PrQuantity.Value = ProductGV.SelectedRow.Cells[5].Text;
            PExpdate.Value = ProductGV.SelectedRow.Cells[6].Text;
            if (PName.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PName.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string PNam = PName.Value;


                    string Query = "delete from ProductTb  where PrId = '{0}'";
                    Query = string.Format(Query, ProductGV.SelectedRow.Cells[1].Text);
                    Con.setData(Query);
                    ShowProducts();
                    ErrMsg.InnerText = "Product Deleted !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PName.Value == "" || CategoryPr.DataTextField == "" || PPrice.Value == "" || PrQuantity.Value == "" || PExpdate.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string PrName = PName.Value;
                    string PrCat = CategoryPr.SelectedValue;
                    string PrPrice = PPrice.Value;
                    string PrQua = PrQuantity.Value;
                    string PrExDate = PExpdate.Value;

                    string Query = "update ProductTb set PrName = '{0}', PrCat = {1}, PrPrice = {2}, PrQty = {3}, PrExpDate = '{4}' where PrId = '{5}'";
                    Query = string.Format(Query, PrName, PrCat, PrPrice, PrQua, PrExDate, ProductGV.SelectedRow.Cells[1].Text);
                    Con.setData(Query);
                    ShowProducts();
                    ErrMsg.InnerText = "Product Updated !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }

        }
    }
}