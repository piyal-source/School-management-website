<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="MIS_Teacher.aspx.cs" Inherits="school.MIS_Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
</asp:Content>
