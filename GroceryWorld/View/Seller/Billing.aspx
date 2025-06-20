<%@ Page Title="" Language="C#" MasterPageFile="~/View/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="GroceryWorld.View.Seller.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintPanel() {
            var PGrid = document.getElementById('<%=BillGV.ClientID %>');
            PGrid.border = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 " >
                <div class="row">
                    <div class="col">
                        <br />
                        <div class="mb-3">
                        <label for="PName" class="form-label">Product Name</label>
                         <input type="text" class="form-control" id="PName" runat="server" required ="required" >  
                        </div>
                        <div class="mb-3">
                        <label for="PPrice" class="form-label">Product Price</label>
                        <input type="text" class="form-control" id="PPrice" runat="server" required ="required" />

                        </div>
                       <div class="mb-3">
                        <label for="PrQuantity" class="form-label">Product Quantity </label>
                        <input type="text" class="form-control" id="PrQuantity" runat="server" required ="required"  >

                       </div>
                    </div>
                    <div class="col">
                        <img style="height:120px; width:130px" src="../../Asset/Images/Doller.jpg"/><br /> <br /> <br /> 
                         <label id="ErrMsg" runat="server" class="text-danger"></label> <br />
                         <asp:Button text=" Add To Bill " Class="btn btn-warning" runat="server" ID="AddToBillBtn" OnClick="AddToBillBtn_Click" />
                         <asp:Button text=" Reset " Class="btn btn-success" runat="server" ID="Reset" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                         <asp:GridView runat="server" class="table table-hover" ID="ProductGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged" >

                         </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-7 ">
                <div class="row">
                    <div class="col-3"></div>
                    <div class="col"><h1 class="text-warning pl-2">Client Billing</h1></div>
                </div>
                <div class="row">
                    <asp:GridView ID="BillGV" runat="server" Class="table">
                    </asp:GridView>
                </div>
                <div class="row">
                    <div class="col"></div>
                    <div class="col"><h3 id="GrdTotTb" class="text-success" runat="server">
                         Total Amount: Rs <span id="TotalAmountPlaceholder"></span>
                                     </h3></div>
                    <div class="col d-grid">
                        <asp:Button text=" Print Bill " Class="btn btn-warning btn-block text-white-50" ID="PrintBtn" OnClientClick="PrintPanel()" runat="server" OnClick="PrintBtn_Click"   />
                    </div>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>
