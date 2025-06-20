<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="GroceryWorld.View.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-8">
                    
                    <img style="height:70px; width:90px;" src="../../Asset/Images/Pmanage2.png" /><h4 class="text-success">Manage Sellers</h4>
                </div>
            </div>
        </div>
         <div class="row">
             <div class="col-md-4">
                 <h2 class="text-success">Seller details</h2>
                 
                     <div class="mb-3">
                        <label for="SNameTb" class="form-label">Seller Name</label>
                        <input type="text" class="form-control" id="SNameTb" runat="server">
    
                    </div>
                     <div class="mb-3">
                        <label for="SEmailTb" class="form-label">Seller Email</label>
                        <input type="text" class="form-control" id="SEmailTb" runat="server" >
    
                    </div>
                   <div class="mb-3">
                        <label for="SPassTb" class="form-label">Seller Password</label>
                        <input type="text" class="form-control" id="SPassTb" runat="server" >
    
                    </div>
                   <div class="mb-3">
                        <label for="SPhoneTb" class="form-label">Seller Phone No. </label>
                        <input type="text" class="form-control" id="SPhoneTb" runat="server">
    
                    </div>
                   <div class="mb-3">
                        <label for="SAddressTb" class="form-label">Seller Address</label>
                        <input type="text" class="form-control" id="SAddressTb" runat="server" >
    
                    </div>
                 <label id="ErrMsg" runat="server" class="text-danger"></label> <br />
                 <asp:Button text=" Edit " Class="btn btn-success" runat="server" ID="EditBtn" OnClick="EditBtn_Click"/>
                 <asp:Button text=" Save " Class="btn btn-success" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click"/>
                 <asp:Button text=" Delete " Class="btn btn-success" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click"/>

                
             </div>
              <div class="col-md-8">
                  <!--Table here-->
                  <asp:GridView runat="server" class="table table-hover" ID="SellerGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SellerGV_SelectedIndexChanged1">

                  </asp:GridView>
              </div>
         </div>
    </div>
</asp:Content>
