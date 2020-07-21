<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="Subject_Master.aspx.cs" Inherits="school.Subject_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .frm {
            width: 100%;
            height: 220px;
            margin-bottom:40px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
        }
        
        .tblfrm {
            width: 629px;
            height: 208px;
            margin-left: 10px;
            margin-top:8px;
        }

        .box {
            height: 50px;
        }

        .dwd{
            text-align:right;
        }

        .pdfbt{
            height: 50px;
            width:50px;
        }

        .auto-style1 {
            height: 8px;
        }

     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <div style="font-weight:bold; color:mediumpurple; font-size:30px">
            <asp:Label ID="Label4" runat="server" Text="SUBJECT MASTER"></asp:Label>
        </div>
        <br />
        <div class="frm">
            <table class="tblfrm">
                <tr>
                    <td class="box">
                        <asp:Label ID="Label1" runat="server" Text="Select Subject:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="box">
                        <asp:DropDownList ID="ddl_sub" DataTextField = "Subject_Name" DataValueField="Subject_ID" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddl_sub_SelectedIndexChanged" AutoPostBack="true" Height="40px" Width="226px">
                        </asp:DropDownList>
                    </td>
                  
                </tr>
                <tr>
                    <td class="box">
                        <asp:Label ID="Label2" runat="server" Text="Subject Name:" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="box">
                        <asp:TextBox ID="txt_sub" runat="server" Height="36px" Width="288px" BackColor="BlanchedAlmond"></asp:TextBox>
                    </td>
                </tr>
                <tr><td class="auto-style1"></td></tr>
                <tr>
                    <td>

                    </td>
                    <td>
                         <asp:Button ID="btn_save" runat="server" Text="Submit" OnClick="btn_save_Click" Height="40px" Width="160px" />
                    </td>
                </tr>

            </table>
           
        </div>

        <div>
            <table style="width:100%">
            <tr>
                <td class="dwd">
                    <asp:Label ID="Label3" runat="server" Text="Click here to download:" Font-Bold="true"></asp:Label></td>
               
                <td class="pdfbt">
                    <asp:ImageButton ID="pdfbtn" runat="server" OnClick="pdfbtn_Click" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" />
                </td>
            </tr>
        </table>
        </div>

        <div>
            <asp:GridView ID="subgrid" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" ShowHeaderWhenEmpty="true" EmptyDataText="No record available"
                     OnRowCommand="subgrid_RowCommand" OnRowEditing="subgrid_RowEditing" OnRowUpdating="subgrid_RowUpdating" OnRowUpdated="subgrid_RowUpdated"
                     OnRowDeleting="subgrid_RowDeleting" style="margin-right:50px">
                    <FooterStyle ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BorderColor="" BackColor="#376ab3" Font-Size="14px" HorizontalAlign="Center" ForeColor="White" />
                    <RowStyle BackColor="#EEF2F6" />
                    <Columns>

                         <asp:TemplateField HeaderText="Subject ID" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Subject_ID" Font-Size="14px" runat="server" Text='<%#Eval("Subject_ID")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Subject Name">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Subject_Name" Font-Size="14px" runat="server" Text='<%#Eval("Subject_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btnEdit" Font-Size="15px" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Subject_ID")%>' ForeColor="#006600">Edit</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btndel" Font-Size="15px" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Subject_ID")%>' ForeColor="#006600">Delete</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>

    </div>
</asp:Content>
