<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="Sub_Div_Master.aspx.cs" Inherits="school.Sub_Div_Master" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formcss
        {
            width: 100%;
            height: 220px;
            margin-bottom:40px;
            margin-top:30px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
        }
        .tblcss
        {
            width: 629px;
            height: 208px;
            margin-left: 10px;
            margin-top:8px;
        }
        .auto-style1 {
            text-align:right;
        }
        .auto-style2 {
            height: 50px;
            width:50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <div style="font-weight:bold; color:mediumpurple; font-size:30px">
            <asp:Label ID="Label4" runat="server" Text="SUB DIVISION MASTER"></asp:Label>
        </div>
    <div class="formcss">
        <table class="tblcss">
            <tr>
                <td>
                    <asp:Label ID="ldist" runat="server" Text="Select District:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddldist" DataTextField="Dist_Name" DataValueField="Dist_Code" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" AutoPostBack="true" Height="40px" Width="230px" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lsubcode" runat="server" Text="Select Subdivision:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsub" DataTextField="Sub_Div_Name" DataValueField="Sub_Div_Code" AutoPostBack="true" Height="40px" Width="230px" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlsub_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lsubname" runat="server" Text="Subdivision Name:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsub" runat="server" Height="28px" Width="288px" BackColor="BlanchedAlmond"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height:8px"></td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save" Height="34px" Width="146px" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
        <div>
            <table style="width:100%">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Click here to Download:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" OnClick="ImageButton1_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="subgrid" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" ShowHeaderWhenEmpty="true" EmptyDataText="No records available"
                     OnRowCommand="subgrid_RowCommand" OnRowEditing="subgrid_RowEditing" OnRowUpdating="subgrid_RowUpdating" OnRowUpdated="subgrid_RowUpdated"
                     OnRowDeleting="subgrid_RowDeleting" style="margin-right:50px">
                    <FooterStyle ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BorderColor="" BackColor="#376ab3" Font-Size="14px" HorizontalAlign="Center" ForeColor="White" />
                    <RowStyle BackColor="#EEF2F6" />
                    <Columns>

                         <asp:TemplateField HeaderText="District" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Dist_Code" Font-Size="14px" runat="server" Text='<%#Eval("Dist_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Sub Division Code" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Sub_Div_Code" Font-Size="14px" runat="server" Text='<%#Eval("Sub_Div_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sub Division Name">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Sub_Div_Name" Font-Size="14px" runat="server" Text='<%#Eval("Sub_Div_Name")%>'></asp:Label>
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
                                    <asp:LinkButton ID="btnEdit" Font-Size="15px" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Sub_Div_Code")%>' ForeColor="#006600">Edit</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btndel" Font-Size="15px" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Sub_Div_Code")%>' ForeColor="#006600">Delete</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>

    </div>



</asp:Content>
