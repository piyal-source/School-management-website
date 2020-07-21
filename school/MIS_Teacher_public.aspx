<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS_Teacher_public.aspx.cs" Inherits="school.MIS_Teacher_public" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         .auto-style1 {
            width: 474px;
            height: 82px;
            margin-left:40px;
         }
         .formcss
        {
            width: 100%;
            height: 85px;
            margin-bottom:40px;
            margin-top:30px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
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
    <div class="formcss">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="lblt" runat="server" Text="Select Teacher:" Font-Bold="true" Font-Size="18px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddltch" DataTextField="Teacher_Name" DataValueField="Teacher_ID" OnSelectedIndexChanged="ddltch_SelectedIndexChanged" AutoPostBack="true" Height="30" Width="230px" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
        </div>
        <div>
            <table style="width:100%">
                <tr>
                    <td style="text-align:right">
                        <asp:Label ID="lbldd" runat="server" Text="Click here to download:" Font-Bold="true"></asp:Label>
                    </td>
                    <td style="height:50px; width:50px">
                        <asp:ImageButton ID="btnpdf" runat="server" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" OnClick="btnpdf_Click" />
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

                        <asp:TemplateField HeaderText="Teacher" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="sub" Font-Size="14px" runat="server" Text='<%#Eval("Teacher_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Teacher code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="s" Font-Size="14px" runat="server" Text='<%#Eval("Teacher_ID")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="subject code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Label2" Font-Size="14px" runat="server" Text='<%#Eval("Subject_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Subject" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="sch" Font-Size="14px" runat="server" Text='<%#Eval("Subject_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="School code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Label2" Font-Size="14px" runat="server" Text='<%#Eval("School_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="School" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="sch" Font-Size="14px" runat="server" Text='<%#Eval("School_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="dist code" Visible="false">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="s" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="District" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="sch" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        </Columns>
                </asp:GridView>
            </div>
    </div>
    </form>
</body>
</html>
