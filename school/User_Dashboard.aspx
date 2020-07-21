<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Dashboard.aspx.cs" Inherits="school.User_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        
    </style>
</head>
<body style="background-color:wheat; padding:10px">
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/school logo.png" Height="50px" Width="50px" />
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="SCHOOL MANAGEMENT SYSTEM" style="font-size: 50px; font-family: Algerian"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="LightGray" Font-Size="25px" StaticHoverStyle-BackColor="White" Width="100%" StaticMenuItemStyle-HorizontalPadding="30px" StaticMenuItemStyle-ForeColor="Black" DynamicMenuItemStyle-BackColor="LightGray" DynamicHoverStyle-BackColor="White">
            <Items>
                <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/User_Dashboard.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Master Data" Value="Master Data">
                    <asp:MenuItem Text="District Master" Value="District_Master" NavigateUrl="~/District_Master_1.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Sub-Division Master" Value="Sub_Division_Master" NavigateUrl="~/Sub_Div_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="School Master" Value="School_Master" NavigateUrl="~/School_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Subject Master" Value="Subject_Master" NavigateUrl="~/Subject_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Teacher Master" Value="Teacher_Master" NavigateUrl="~/Teacher_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Vacancy Master" Value="Vacancy_Master" NavigateUrl="~/Vacancy_Master.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="MIS" Value="MIS">
                    <asp:MenuItem Text="District wise Schools" Value="MIS_School" NavigateUrl="~/MIS_School.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Subject wise Schools" Value="MIS_Subject" NavigateUrl="~/MIS_Subject.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Search Teacher" Value="MIS_Teacher" NavigateUrl="~/MIS_Teacher.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Change Password" Value="Change_password" NavigateUrl="~/Change_Password.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Logout" Value="Logout" NavigateUrl="~/Login.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
        <fieldset style="margin:20px; background-color:burlywood">
            <legend><strong style="font-size:25px; color:#5d366f; background-color:burlywood">User Information:</strong></legend>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="label1" runat="server" Text="User Id:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label3" runat="server" Text="Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label4" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label5" runat="server" Text="Email Id:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label6" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label7" runat="server" Text="Phone No:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label8" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label9" runat="server" Text="Address:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label10" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label11" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label12" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label13" runat="server" Text="DOB:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="label14" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </fieldset>
    </div>
    </form>
</body>
</html>
