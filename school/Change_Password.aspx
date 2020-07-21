<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="school.Change_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .txt
        {
            height:25px;
            width:220px;
        }
        .auto-style1 {
            height: 10px;
        }
        .auto-style2 {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:60px 450px 200px 400px; border:thin #000000; background-color:lightsteelblue; box-shadow:10px 10px 5px grey; height:255px; width:400px">
        <br />
        <table style="margin-left:10px">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="User Id:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbluser" runat="server" Height="28px" Width="210px" Text="" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Old Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtold" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="New Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnew" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtconfirm" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr><td class="auto-style1"></td></tr>
            <tr>
                <td colspan="2"><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <br />
        
    </div>
</asp:Content>
