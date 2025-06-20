using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryWorld.View.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowSellers();

        }
        //Add this method
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowSellers()
        {
            string Query = "select * from Seller";
            SellerGV.DataSource = Con.getData(Query);
            SellerGV.DataBind();
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPassTb.Value == "" || SEmailTb.Value == "" || SNameTb.Value == "" || SPhoneTb.Value == "" || SAddressTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string Password = SPassTb.Value;
                    string Phone = SPhoneTb.Value;
                    string Address = SAddressTb.Value;

                    string Query = "insert into Seller values ('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, SName, SEmail, Password, Phone, Address);
                    Con.setData(Query);  
                    ShowSellers();
                    ErrMsg.InnerText = "Seller Added !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        int key = 0;
        protected void SellerGV_SelectedIndexChanged1(object sender, EventArgs e)
        {
            SNameTb.Value = SellerGV.SelectedRow.Cells[2].Text;
            SEmailTb.Value = SellerGV.SelectedRow.Cells[3].Text;
            SPassTb.Value = SellerGV.SelectedRow.Cells[4].Text;
            SPhoneTb.Value = SellerGV.SelectedRow.Cells[5].Text;
            SAddressTb.Value = SellerGV.SelectedRow.Cells[6].Text;
            if (SNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(SellerGV.SelectedRow.Cells[1].Text);
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPassTb.Value == "" || SEmailTb.Value == "" || SNameTb.Value == "" || SPhoneTb.Value == "" || SAddressTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string SName = SNameTb.Value;
                    string SEmail = SEmailTb.Value;
                    string Password = SPassTb.Value;
                    string Phone = SPhoneTb.Value;
                    string Address = SAddressTb.Value;

                    string Query = "update Seller set SelName = '{0}', SelEmail = '{1}', SelPassword = '{2}', SelPhone = '{3}', SelAddress = '{4}' where SelId = '{5}'";
                    Query = string.Format(Query, SName, SEmail, Password, Phone, Address, SellerGV.SelectedRow.Cells[1].Text);
                    Con.setData(Query);
                    ShowSellers();
                    ErrMsg.InnerText = "Seller Updated !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPassTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string SName = SNameTb.Value;
                   

                    string Query = "delete from Seller  where SelId = '{0}'";
                    Query = string.Format(Query, SellerGV.SelectedRow.Cells[1].Text);
                    Con.setData(Query);
                    ShowSellers();
                    ErrMsg.InnerText = "Seller Deleted !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }


        }
    }
}