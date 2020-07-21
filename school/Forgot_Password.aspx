<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Password.aspx.cs" Inherits="school.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 405px;
            height: 278px;
            margin-left: 442px;
        }
        .auto-style2 {
            width: 412px;
            height: 243px;
        }
        .csslbl{
            text-align:right;
        }
        .auto-style3 {
            width: 413px;
        }
        .auto-style4 {
            width: 126px;
        }
    </style>
</head>
<body style="height: 685px">
    <form id="form1" runat="server">
    <div style="margin-right: 30px; margin-top: 30px; margin-bottom: 30px;" class="auto-style1">
        <fieldset style="background-color:wheat; box-shadow:10px 10px 5px grey;" class="auto-style3">
<legend><strong style="font-size:25px; color:#5d366f; background-color:wheat; font-family:'Adobe Caslon Pro'">Enter your details:</strong></legend>
            <br />
        <table class="auto-style2">
            <tr>
                <td class="csslbl">
                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtuser" runat="server" Height="25px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="csslbl">
                    <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" Height="25px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="csslbl">
                    <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtmail" runat="server" Height="25px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="csslbl">
                    <asp:Label ID="Label4" runat="server" Text="Phone no:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtphone" runat="server" Height="25px" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <table>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="btnsave" runat="server" Text="Submit" OnClick="btnsave_Click" Height="32px" Width="96px" />
                            </td>
                            <td><asp:Button ID="btnlogin" runat="server" Text="Home" OnClick="btnlogin_Click" Height="32px" Width="96px" /></td>
                        </tr>
                    </table>
               </td>
            </tr>
            <tr>
                <td></td>
                <td style="font-size:20px"><asp:Label ID="lblconfirm" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
            <br />
            <br />
            </fieldset>
    </div>
    </form>
</body>
</html>
