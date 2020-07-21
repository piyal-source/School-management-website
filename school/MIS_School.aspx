<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS_School.aspx.cs" Inherits="school.MIS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        MIS School
    </title>
    <style>
        .formcss
        {
            width: 100%;
            height: 85px;
            margin-bottom:40px;
            margin-top:20px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
        }
        .auto-style1 {
            width: 1153px;
            height: 82px;
            margin-left: 10px;
        }
        .auto-style2 {
            width: 532px;
        }
        .auto-style3 {
            width: 171px;
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
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/school logo.png" Height="50px" Width="50px" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="SCHOOL MANAGEMENT SYSTEM" style="text-align: center; font-size: 50px; font-family: Algerian"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="LightGray" Font-Size="25px" StaticHoverStyle-BackColor="White" Width="100%" StaticMenuItemStyle-HorizontalPadding="30px" StaticMenuItemStyle-ForeColor="Black" DynamicMenuItemStyle-BackColor="LightGray" DynamicHoverStyle-BackColor="White" DynamicMenuItemStyle-ForeColor="Black">
            <Items>
                <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/User_Dashboard.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Master Data" Value="Master Data">
                    <asp:MenuItem Text="District Master" Value="District Master" NavigateUrl="~/District_Master1.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Sub-Division Master" Value="Sub_Division_Master" NavigateUrl="~/Sub_Div_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="School Master" Value="School_Master" NavigateUrl="~/School_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Subject Master" Value="Subject_Master" NavigateUrl="~/Subject_Master.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Teacher Master" Value="Teacher_Master" NavigateUrl="~/Teacher_Master.aspx"></asp:MenuItem>
                    </asp:MenuItem>
                <asp:MenuItem Text="MIS" Value="MIS">
                    <asp:MenuItem Text="District wise Schools" Value="MIS_School" NavigateUrl="~/MIS_School.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Subject wise Subjects" Value="MIS_Subject" NavigateUrl="~/MIS_Subject.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Search Teacher" Value="MIS_Teacher" NavigateUrl="~/MIS_Teacher.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Change Password" Value="Change_password" NavigateUrl="~/Change_Password.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Logout" Value="Logout" NavigateUrl="~/Login.aspx"></asp:MenuItem>
            </Items>
          </asp:Menu>
        </div>
        <div class="formcss">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="ldist" runat="server" Text="Select District:" Font-Bold="true" Font-Size="18px"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddldist" DataTextField="Dist_Name" DataValueField="Dist_Code" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" AutoPostBack="true" Height="30" Width="230px" runat="server"></asp:DropDownList>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lsub" runat="server" Text="Select Subdivision:" Font-Bold="true" Font-Size="18px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsub" DataTextField="Sub_Div_Name" DataValueField="Sub_Div_Code" OnSelectedIndexChanged="ddlsub_SelectedIndexChanged" AutoPostBack="true" Height="30" Width="230px" runat="server"></asp:DropDownList>
                </td>
            </tr>

            </table>
            </div>
        <div>
            <table style="width:100%">
                <tr>
                    <td style="text-align:right">
                        <asp:Label ID="Label1" runat="server" Text="Click here to download:" Font-Bold="true"></asp:Label>
                    </td>
                    <td style="height:50px; width:50px">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" OnClick="ImageButton1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gridsch" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" style="margin-right:50px" ShowHeaderWhenEmpty="true" EmptyDataText="No records available">
                    <FooterStyle ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BorderColor="" BackColor="#376ab3" Font-Size="14px" HorizontalAlign="Center" ForeColor="White" />
                    <RowStyle BackColor="#EEF2F6" />
                    <Columns>

                        <asp:TemplateField HeaderText="District code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Dist" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="District" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Dist" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sub Division code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Sub_Div" Font-Size="14px" runat="server" Text='<%#Eval("Sub_Div_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Sub Division" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Sub_Div" Font-Size="14px" runat="server" Text='<%#Eval("Sub_Div_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="School">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="School_Code" Font-Size="14px" runat="server" Text='<%#Eval("School_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </div>
    </div>
    </form>
</body>
</html>
