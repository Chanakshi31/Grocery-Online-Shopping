<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GroceryWorld.View.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
 <!--   <h1>Dashboard</h1> -->
    <div class="container-fluid">
    <!-- Header Row -->
    <div class="row mb-5">
        <div class="col-12 text-center d-flex align-items-center justify-content-center">
            <img src="../../Asset/Images/Dashboardlogo.png" alt="Dashboard Logo" class="rounded" style="height: 40px; width: 40px;" />
            <h2 class="text-success ms-3">Grocery Dashboard</h2>
        </div>
    </div>

    <!-- Dashboard Summary Section -->
    <div class="row mb-5">
        <div class="col-md-3 bg-success text-white text-center rounded py-3">
            <img src="../../Asset/Images/Product3.png" alt="Products" style="height: 60px; width: 40px;" />
            <h3>Products</h3>
            <h1 runat="server" id="PNumTb">Num</h1>
        </div>
        <div class="col-md-1"></div>
        <div class="col-md-3 bg-warning text-white text-center rounded py-3">
            <img src="../../Asset/Images/categories2.png" alt="Categories" style="height: 40px; width: 40px;" />
            <h3>Categories</h3>
            <h1 runat="server" id="CatNumTb">Num</h1>
        </div>
        <div class="col-md-1"></div>
        <div class="col-md-3 bg-primary text-white text-center rounded py-3">
            <img src="../../Asset/Images/Indian Rupee1.png" alt="Finance" style="height: 40px; width: 40px;" />
            <h3>Finance</h3>
            <h1 runat="server" id="FinanceTb">Num</h1>
        </div>
    </div>

    <!-- Dropdown and Additional Information Section -->
    <div class="row mb-5">
        <div class="col-12 text-center">
            <asp:DropDownList id="SellerCb" class="form-control" runat="server" style="width: 250px; margin: 0 auto;"></asp:DropDownList>
        </div>
    </div>

    <div class="row mb-5">
        <div class="col-md-3 bg-info text-white text-center rounded py-3">
            <img src="../../Asset/Images/Product3.png" alt="Categories Amount" style="height: 60px; width: 40px;" />
            <h5>Categories Amount</h5>
            <h1 runat="server" id="AmountCatTb">Num</h1>
        </div>
        <div class="col-md-1"></div>
        <div class="col-md-3 bg-secondary text-white text-center rounded py-3">
            <img src="../../Asset/Images/categories2.png" alt="Total Sells" style="height: 40px; width: 40px;" />
            <h3>Total Sells</h3>
            <h1 runat="server" id="TotalTb">Num</h1>
        </div>
        <div class="col-md-1"></div>
        <div class="col-md-3 bg-success text-white text-center rounded py-3">
            <img src="../../Asset/Images/Indian Rupee1.png" alt="Sellers" style="height: 40px; width: 40px;" />
            <h3>Sellers</h3>
            <h1 runat="server" id="SelNumTb">Num</h1>
        </div>
    </div>

    <!-- Footer Section -->
    <div class="row">
        <div class="col-12 text-center">
            <img src="../../Asset/Images/Products2.png" alt="Products Image" class="img-fluid mt-5" style="height: 250px; width: 400px;" />
        </div>
    </div>
</div>

</asp:Content>
