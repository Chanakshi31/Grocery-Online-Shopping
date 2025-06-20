using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryWorld.View.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowCategories()
        {
            string Query = "select * from CategoryTbl";
            CategoryGV.DataSource = Con.getData(Query);
            CategoryGV.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CName.Value == "" || CRemarks.Value == "" )
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string CNam = CName.Value;
                    string CRem = CRemarks.Value;
                   
                    string Query = "insert into CategoryTbl values ('{0}','{1}')";
                    Query = string.Format(Query, CNam, CRem);
                    Con.setData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Added !!!";

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
                if (CName.Value == "")
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string SNam = CName.Value;


                    string Query = "delete from CategoryTbl  where CatId = '{0}'";
                    Query = string.Format(Query, CategoryGV.SelectedRow.Cells[1].Text);
                    Con.setData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Deleted !!!";

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
                if (CName.Value == "" || CRemarks.Value == "" )
                {
                    ErrMsg.InnerText = "Missing Data";

                }
                else
                {
                    string CNam = CName.Value;
                    string CRem = CRemarks.Value;

                    string Query = "update CategoryTbl set CatName = '{0}', CatDescription = '{1}' where CatId = '{2}'";
                    Query = string.Format(Query, CNam, CRem, CategoryGV.SelectedRow.Cells[1].Text);
                    Con.setData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Updated !!!";

                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        int Key = 0;
        protected void CategoryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            CName.Value = CategoryGV.SelectedRow.Cells[2].Text;
            CRemarks.Value = CategoryGV.SelectedRow.Cells[3].Text;
           
            if (CName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoryGV.SelectedRow.Cells[1].Text);
            }

        }
    }
}