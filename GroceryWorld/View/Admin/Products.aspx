<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="GroceryWorld.View.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-8">
                    <br />
                    <img style="height:70px; width:90px;" src="../../Asset/Images/Pmanage2.png" /><h4 class="text-success">Manage Products</h4>
                </div>
            </div>
        </div>
         <div class="row">
             <div class="col-md-4">
                 <h2 class="text-success">Product details</h2>
                 
                     <div class="mb-3">
                        <label for="PName" class="form-label">Product Name</label>
                     <input type="text" class="form-control" id="PName" runat="server" >  
                         
    
                    </div>
                     <div class="mb-3">
                        <label for="CategoryPr" class="form-label">Product Category</label>
                    <!--    <input type="text" class="form-control" id="PCategory" runat="server"  > -->
                         <asp:DropDownList id="CategoryPr" Class="form-control" runat="server"></asp:DropDownList>
    
                    </div>
                   <div class="mb-3">
                        <label for="PPrice" class="form-label">Product Price</label>
                        <input type="text" class="form-control" id="PPrice" runat="server"  >
    
                    </div>
                   <div class="mb-3">
                        <label for="PrQuantity" class="form-label">Product Quantity </label>
                        <input type="text" class="form-control" id="PrQuantity" runat="server"  >
    
                    </div>
                   <div class="mb-3">
                        <label for="PExpdate" class="form-label">Expiration Date</label>
                        <input type="date" class="form-control" id="PExpdate" runat="server"  >
    
                    </div>

                 <label id="ErrMsg" runat="server" class="text-danger"></label> <br />
                 <asp:Button text=" Edit " Class="btn btn-success" runat="server" ID="EditBtn" OnClick="EditBtn_Click"/>
                 <asp:Button text=" Save " Class="btn btn-success" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click"/>
                 <asp:Button text=" Delete " Class="btn btn-success" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click"/>

                
             </div>
              <div class="col-md-8">
                  <!--Table here-->
                  <asp:GridView runat="server" class="table table-hover" ID="ProductGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged" >

                  </asp:GridView>
              </div>
         </div>
    </div>
</asp:Content>
