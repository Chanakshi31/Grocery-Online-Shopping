<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroceryWorld.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Asset/Lib/Bootstrap/css/bootstrap.min.css" />
</head>
<body>
   
    
    <div class="container-fluid">
    <!-- Spacer Row for spacing -->
    <div class="row" style="height:90px;"></div>

    <!-- Main content row -->
    <div class="row">
        <!-- Left Column (Empty space) -->
        <div class="col-md-2"></div>

        <!-- Middle Column (Image) -->
        <div class="col-md-4">
            <img src="../Asset/Images/Grocery.jpg" class="img-fluid" alt="Grocery Image"/>
        </div>

        <!-- Right Column (Sign Up Form) -->
        <div class="col-md-4">
            <h1 class="text-success">Sign Up</h1>
            <form id="formLog" runat="server">
                <!-- Email input -->
                <div class="mb-3">
                    <label for="EmailId" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="EmailId" runat="server" required="required" />
                </div>

                <!-- Password input -->
                <div class="mb-3">
                    <label for="UserPasswordTb" class="form-label">Password</label>
                    <input type="password" class="form-control" id="UserPasswordTb" runat="server" required="required" />
                </div>

                <!-- Radio buttons for Role selection -->
                <div class="mb-3 form-group">
                    <div class="form-check">
                        <input type="radio" id="SellerRadio" name="Role" runat="server" />
                        <label class="form-check-label" for="SellerRadio">Seller</label>
                    </div>
                    <div class="form-check">
                        <input type="radio" id="AdminRadio" checked="true" name="Role" runat="server" />
                        <label class="form-check-label" for="AdminRadio">Admin</label>
                    </div>
                </div>

                <!-- Info message -->
                <div class="mb-3">
                    <label id="InfoMsg" class="text-danger" runat="server"></label>
                </div>

                <!-- Submit button -->
                <div class="mb-3 d-grid">
                    <asp:Button Text="Login" class="btn btn-success btn-block" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                </div>
            </form>
        </div>
    </div>
</div>

</body>
</html>
