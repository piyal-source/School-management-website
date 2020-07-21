<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="school.newuser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <style>
        .txt
        {
            font-size:18px;
            font-weight:bold;
        }
    </style>
</head>
<body style="margin:30px">
    <form id="form1" runat="server">
        <fieldset style="background-color:wheat; box-shadow:10px 10px 5px grey;">
<legend><strong style="font-size:25px; color:#5d366f; background-color:wheat; font-family:'Adobe Caslon Pro'">REGISTRATION FORM</strong></legend>
    <div>
    <table style="width:400px; height:400px;">
       <tr>
           <td>
               <asp:Label ID="Label1" runat="server" Text="User Id:" CssClass="txt"></asp:Label>
           </td>
           <td>
               <asp:TextBox ID="tbox1" runat="server" Height="25px" Width="200px"></asp:TextBox>
           </td>
       </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbox2" runat="server" TextMode="Password" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Name:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbox3" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Email id:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbox4" runat="server" Height="25px" Width="200px" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Phone no.:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtnum" runat="server" TextMode="Number" Height="25px" width="200px" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Address:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_addr"  runat="server" Height="50px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Gender:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="gender" runat="server" RepeatDirection="Horizontal" Height="32px" Width="232px">
                    <asp:ListItem Value="m">Male</asp:ListItem>
                    <asp:ListItem Value="f">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Date Of Birth:" CssClass="txt"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdob" TextMode="Date" runat="server" height="20px" width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Button ID="Button1" runat="server" Text="Register" Height="37px" Width="120px" OnClick="Button1_Click" />
            </td>
            <td>
                &nbsp; &nbsp;
                <asp:Label ID="label9" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp; &nbsp;
                <asp:Button ID="button2" runat="server" Text="Login" />
            </td>
        </tr>
    </table>
        
    </div>
            </fieldset>
    </form>
</body>
</html>
