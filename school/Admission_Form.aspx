<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admission_Form.aspx.cs" Inherits="school.Admission_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .lbl
        {
            width:200px;
        }
        .auto-style2 {
            height: 78px;
            width: 1264px;
        }
        .auto-style4 {
            height: 35px;
        }
        .auto-style6 {
            width: 200px;
            height: 35px;
        }
        .auto-style7 {
            height: 10px;
            width: 20px;
        }
        .auto-style9 {
            width: 20px;
        }
        .auto-style10 {
            height: 35px;
            width: 20px;
        }
        .auto-style11 {
            height: 35px;
            width: 286px;
        }
        .auto-style12 {
            width: 286px;
        }
        .auto-style13 {
            height: 50px;
            width: 685px;
        }
        .auto-style14 {
            height: 70px;
            width: 319px;
        }
        .auto-style16 {
            margin-left: 0px;
        }
        .auto-style17 {
            width: 66px;
        }
        .auto-style18 {
            width: 260px;
        }
        .auto-style19 {
            width: 319px;
        }
        .auto-style20 {
            width: 1264px;
        }
        .auto-style21 {
            height: 99px;
            width: 759px;
        }
        .auto-style22 {
            height: 10px;
        }
    </style>
</head>

<body style="background-color:wheat; padding:10px">
    <form id="form1" runat="server">
    <div>
        <div>           
            <table>
                <tr>
                    <td>
                        <asp:Image ID="img" runat="server" ImageUrl="~/img/school logo.png" Height="50px" Width="50px" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="SCHOOL MANAGEMENT SYSTEM" style="font-size: 50px; font-family: Algerian"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="LightGray" Font-Size="25px" StaticHoverStyle-BackColor="White" Width="100%" StaticMenuItemStyle-HorizontalPadding="30px" StaticMenuItemStyle-ForeColor="Black" DynamicMenuItemStyle-BackColor="LightGray" DynamicHoverStyle-BackColor="White" DynamicMenuItemStyle-ForeColor="Black">
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
        <div style="text-align:center">
            <asp:Label ID="School" runat="server" Text="" Font-Size="56px" ForeColor="MediumPurple" Font-Bold="true"></asp:Label>
        </div>
        <br />
        <div style="text-align:center">
            <asp:Label ID="Label1" runat="server" Text="ADMISSION    FORM" Font-Bold="true" Font-Size="30px"></asp:Label>
        </div>
        <br />

        <div style="border:solid #808080; margin-left:200px; margin-right:200px">

            <table class="auto-style21">

                <%--1st row start--%>
                <tr>

                    <td class="auto-style2">
                        <%--labels start--%>
                        <table>

                            <tr><td class="auto-style22"></td></tr>
                            <tr>
                                <td class="auto-style10">1.</td>
                                <td class="auto-style6">
                                    <asp:Label ID="Label2" runat="server" Text="Name of Student:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtname" runat="server" Width="155px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10"></td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label3" runat="server" Text="Date of Birth:" Font-Bold="true"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtdob" runat="server" TextMode="Date" Width="155px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                        <%--labels end--%>

                    </td>
                    <td class="auto-style17"></td>
                    <%--picture--%>
                                <td class="auto-style14">
                                    <asp:Image ID="Image1" runat="server" Height="65px" Width="75px" />
                                </td>
                       <%--picture--%>   
                </tr>
                <%--1st row end--%>

                <%--2nd row start--%>
                <tr>
                    <td class="auto-style20">
                        <table>
                            <tr>
                                    <td class="auto-style9">2.</td>
                                    <td class="lbl">
                                        <asp:Label ID="Label4" runat="server" Text="Father's Name:" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtfname" runat="server" Width="155px" Height="20px"></asp:TextBox>
                                    </td>
                             </tr>
                             <tr>
                                    <td class="auto-style9"></td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Occupation:" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtfocc" runat="server" Width="155px" Height="20px"></asp:TextBox>
                                    </td>
                             </tr>
                       </table>
                  </td>
                    <td class="auto-style17"></td>
                    <td class="auto-style19">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style16" Width="200px" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td class="auto-style9">3.</td>
                    <td class="lbl">
                        <asp:Label ID="Label7" runat="server" Text="Mother's Name:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtmname" runat="server" Width="155px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="lbl">
                        <asp:Label ID="Label8" runat="server" Text="Occupation:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtmocc" runat="server" Width="155px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        4.
                    </td>
                    <td class="lbl">
                        <asp:Label ID="Label9" runat="server" Text="Address" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtadd" runat="server" TextMode="MultiLine" Height="40px" Width="217px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="lbl">
                        <asp:Label ID="Label10" runat="server" Text="Phone no:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtnum" runat="server" TextMode="Number" MaxLength="10" Width="155px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">5.</td>
                    <td class="lbl">
                        <asp:Label ID="Label11" runat="server" Text="Gender:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:RadioButtonList ID="gender" runat="server" RepeatDirection="Horizontal" Width="165px" Height="20px">
                        <asp:ListItem Value="m">Male</asp:ListItem>
                        <asp:ListItem Value="f">Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <table class="auto-style13">
                <tr>
                    <td class="auto-style10">
                        6.
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="Label12" runat="server" Text="Class to which admission is desired:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddlclass" runat="server" Width="155px" Height="20px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">

                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style9">

                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" Font-Bold="true" Height="34px" Width="163px" OnClick="btnsubmit_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
