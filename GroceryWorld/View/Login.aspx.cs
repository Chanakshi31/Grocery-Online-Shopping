using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryWorld.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

        }
        public static string SName;
       public static int Skey;
        //Add this method 
       // public override void VerifyRenderingInServerForm(Control control)
       // {

       // }
        Models.Functions Con;

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AdminRadio.Checked)
            {
                if (EmailId.Value == "Admin@gmail.com" && UserPasswordTb.Value == "Admin")
                {
                    Response.Redirect("Admin/Sellers.aspx");

                }
                else
                {
                    InfoMsg.InnerText = "Invalid Admin !!!";
                }
            }
            else
            {
                String Query = "Select SelId, SelName, SelEmail, SelPassword SelPhone FROM Seller WHERE SelEmail = '{0}' and SelPassword = '{1}'";
                Query = string.Format(Query, EmailId.Value, UserPasswordTb.Value);
                DataTable dt = Con.getData(Query);
                if (dt.Rows.Count == 0)
                {
                    InfoMsg.InnerText = "Invalid User !!!";
                }
                else
                {
                    SName = EmailId.Value;
                    Skey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Billing.aspx");
                }

            }
        }
    }
} 
            
        
