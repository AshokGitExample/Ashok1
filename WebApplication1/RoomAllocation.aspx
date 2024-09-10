<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomAllocation.aspx.cs" Inherits="WebApplication1.RoomAllocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Hotel Management System</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
    <div class="row">
        <div class="col-sm-8">
            <h3 style="text-align:center;">Customer Details</h3>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="ID">Customer ID</label>
                        <asp:TextBox ID="ID" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="Name">Customer Name</label>
                        <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="CNum">Contact Number</label>
                        <asp:TextBox ID="CNum" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="Email">Customer Email</label>
                        <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="RNum">Room Number</label>
                        <asp:TextBox ID="RNum" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-sm-6">
     <div class="form-group">
         <label for="RDrp">DropDown</label>
         <asp:DropDownList  ID="DrpName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DrpName_SelectedIndexChanged"></asp:DropDownList>

     </div>
 </div>
            </div>
             <div class="col-sm-2">
               
                    <asp:Button class="btn btn-success" ID="Button2" runat="server" OnClick="Button1_Click" Text="Submit" />
            </div>
        </div>
        
    </div>
</div>

    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</body>
</html>
