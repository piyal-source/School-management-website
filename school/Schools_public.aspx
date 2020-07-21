<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schools_public.aspx.cs" Inherits="school.Schools_public" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schools</title>
    <style>
        .formcss
        {
            width: 100%;
            height: 230px;
            margin-bottom:40px;
            margin-top:30px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
        }
        .auto-style2 {
            width: 634px;
            height: 224px;
            margin-left: 10px;
            margin-top:8px;
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
        <div class="formcss">
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="ldist" runat="server" Text="Select District:" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddldist" DataTextField="Dist_Name" DataValueField="Dist_Code" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" AutoPostBack="true" Height="40px" Width="230px" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lsub" runat="server" Text="Select Subdivision:" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddlsub" DataTextField="Sub_Div_Name" DataValueField="Sub_Div_Code" AutoPostBack="true" Height="40px" Width="230px" runat="server" OnSelectedIndexChanged="ddlsub_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lboard" runat="server" Text="Select Board" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                <asp:DropDownList ID="ddlboard" runat="server" DataTextField="Board" DataValueField="Board_ID" AutoPostBack="true" Height="40px" Width="230px" OnSelectedIndexChanged="ddlboard_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lclass" runat="server" Text="Select Class" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                <asp:DropDownList ID="ddlclass" runat="server" DataTextField="Class" DataValueField="Class" AutoPostBack="true" Height="40px" Width="230px" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" ></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        <div>
            <asp:GridView ID="schgrid" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" ShowHeaderWhenEmpty="true" EmptyDataText="No records available"
                     OnRowCommand="schgrid_RowCommand" style="margin-right:50px">
                    <FooterStyle ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BorderColor="" BackColor="#376ab3" Font-Size="14px" HorizontalAlign="Center" ForeColor="White" />
                    <RowStyle BackColor="#EEF2F6" />
                    <Columns>

                         <asp:TemplateField HeaderText="District" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Dist" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Sub Division" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Sub_Div" Font-Size="14px" runat="server" Text='<%#Eval("Sub_Div_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Board" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Board" Font-Size="14px" runat="server" Text='<%#Eval("Board")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="School Code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="School_Code" Font-Size="14px" runat="server" Text='<%#Eval("School_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="School Name" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="School_Name" Font-Size="14px" runat="server" Text='<%#Eval("School_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Class" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Class" Font-Size="14px" runat="server" Text='<%#Eval("Class")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vacancy" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Vacancy" Font-Size="14px" runat="server" Text='<%#Eval("Vacancy")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Apply">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btnEdit" Font-Size="15px" runat="server" CommandName="Apply" CommandArgument='<%# Eval("School_Code")%>' ForeColor="#006600">Apply</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
