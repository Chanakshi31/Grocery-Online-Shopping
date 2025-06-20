<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="GroceryWorld.View.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-8">
                    <br />
                    <img style="height:70px; width:90px;" src="../../Asset/Images/Pmanage2.png" /><h4 class="text-success">Manage Categories</h4>
                </div>
            </div>
        </div>
         <div class="row">
             <div class="col-md-4">
                 <h2 class="text-success">Categories details</h2>
                 
                     <div class="mb-3">
                        <label for="Category" class="form-label">Category Name</label>
                        <input type="text" class="form-control" id="CName" runat="server">
    
                    </div>
                     <div class="mb-3">
                        <label for="Category" class="form-label">Category Remarks</label>
                        <input type="text" class="form-control" id="CRemarks" runat="server">
    
                    </div>
                  <br /> <br /> <br />
                 <label id="ErrMsg" runat="server" class="text-danger"></label> <br />
                 <asp:Button text=" Edit " Class="btn btn-success" runat="server" ID="EditBtn" OnClick="EditBtn_Click"/>
                 <asp:Button text=" Save " Class="btn btn-success" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click"/>
                 <asp:Button text=" Delete " Class="btn btn-success" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click"/>

                
             </div>
              <div class="col-md-8">
                  <!--Table here-->
                   <asp:GridView runat="server" class="table table-hover" ID="CategoryGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoryGV_SelectedIndexChanged" >

                  </asp:GridView>
              </div>
         </div>
    </div>
</asp:Content>
