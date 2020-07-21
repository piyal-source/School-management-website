<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="District_Master_1.aspx.cs" Inherits="school.District_Master_1" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 250px;
            margin-bottom:40px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
        }
        .lbl
        {
            text-align:right;
        }
        
        .auto-style2 {
            width: 629px;
            height: 208px;
            margin-left: 10px;
        }
       
        .pdfbt{
            width: 50px;
            height: 50px;
        }

        .auto-style3 {
            text-align:right;
        }
        
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
                        <asp:Label ID="Label5" runat="server" Text="SCHOOL MANAGEMENT SYSTEM" style="font-size: 50px; font-family: Algerian"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="LightGray" Font-Size="25px" StaticHoverStyle-BackColor="White" Width="100%" StaticMenuItemStyle-HorizontalPadding="30px" StaticMenuItemStyle-ForeColor="Black" DynamicMenuItemStyle-BackColor="LightGray" DynamicHoverStyle-BackColor="White" DynamicMenuItemStyle-ForeColor="Black">
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
        <br />
        <br />
        <div style="font-weight:bold; color:mediumpurple; font-size:30px">
            <asp:Label ID="Label4" runat="server" Text="DISTRICT MASTER"></asp:Label>
        </div>
        <br />
        <div class="auto-style1">
            <br />
            <table class="auto-style2">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Select District:" Font-Bold="true" CssClass="lbl"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_dist" DataTextField = "Dist_Name" DataValueField="Dist_Code" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddl_dist_SelectedIndexChanged" AutoPostBack="true" Height="40px" Width="226px">
                            
                        </asp:DropDownList>
                    </td>
                  
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="District Name:" Font-Bold="true" CssClass="lbl"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_dist_name" runat="server" Height="35px" Width="288px" BackColor="BlanchedAlmond"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                         <asp:Button ID="btn_save" runat="server" Text="Submit" OnClick="btn_save_Click" Height="34px" Width="146px" />
                    </td>
                </tr>

            </table>
           
        </div>
        <table style="width:100%">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Click here to download:" Font-Bold="true"></asp:Label></td>
               
                <td class="pdfbt">
                    <asp:ImageButton ID="ImageButton1" runat="server"  OnClick="Button1_Click" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" />
                </td>
            </tr>
        </table>
        
        
       <%-- Grid View--%>
                <asp:GridView ID="grid_deg" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" ShowHeaderWhenEmpty="true" EmptyDataText="No records available"
                     OnRowCommand="grid_deg_RowCommand" OnRowEditing="grid_deg_RowEditing" OnRowUpdating="grid_deg_RowUpdating" OnRowUpdated="grid_deg_RowUpdated"
                     OnRowDeleting="grid_deg_RowDeleting" style="margin-right:50px">
                    <FooterStyle ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BorderColor="" BackColor="#376ab3" Font-Size="14px" HorizontalAlign="Center" ForeColor="White" />
                    <RowStyle BackColor="#EEF2F6" />
                    <Columns>

                         <asp:TemplateField HeaderText="District Code" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Dist_Code" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="District Name">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Dist_Name" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="left" Width="170px" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btnEdit" Font-Size="15px" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Dist_Code")%>' ForeColor="#006600">Edit</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btndel" Font-Size="15px" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Dist_Code")%>' ForeColor="#006600">Delete</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


    </form>
</body>
</html>
