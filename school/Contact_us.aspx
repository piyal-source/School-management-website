<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact_us.aspx.cs" Inherits="school.Contact_us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:wheat; padding:10px;">
    <form id="form1" runat="server">
    <div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/img/school logo.png" Height="50px" Width="50px" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="SCHOOL MANAGEMENT SYSTEM" style="font-size: 50px; font-family: Algerian"></asp:Label>                        
                    </td>
                </tr>
            </table>
        </div>
    <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="LightGray" Font-Size="25px" StaticHoverStyle-BackColor="White" Width="100%" StaticMenuItemStyle-HorizontalPadding="30px" StaticMenuItemStyle-ForeColor="Black" DynamicMenuItemStyle-BackColor="LightGray" DynamicHoverStyle-BackColor="White">
            <Items>
                <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/Login.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Records" Value="Records">
                    <asp:MenuItem Text="District wise Schools" Value="MIS_School" NavigateUrl="~/MIS_School_public.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Subject wise Schools" Value="MIS_Subject" NavigateUrl="~/MIS_Subject_public.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Search Teacher" Value="MIS_Teacher" NavigateUrl="~/MIS_Teacher_public.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Schools" Value="Schools" NavigateUrl="~/Schools_public.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Contact us" Value="Contact_us" NavigateUrl="~/Contact_us.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </div>
        <br />
        <br />
        <div>
            <fieldset>
                <legend style="font-weight:bold; font-size:20px">
                    Contact us
                </legend>
                <br />

                <asp:Label ID="Label1" runat="server" Text="NIC:National Informatics Centre"></asp:Label>
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/img/humanicon.png" Height="38px" Width="46px" />
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Piyal Chakraverty"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/phonelogo.png" Height="44px" Width="40px" />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="+91 8371885295"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/img/maillogo.png" Height="36px" Width="40px" />
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="piyal@gmail.com"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>

    </div>
    </form>
</body>
</html>
