<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="Teacher_Master.aspx.cs" Inherits="school.Teacher_Master" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .frm {
            width: 100%;
            height: 300px;
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
            text-align:right;
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
            <asp:Label ID="topic" runat="server" Text="TEACHER MASTER"></asp:Label>
        </div>
        <br />
        <div class="frm">
            <table class="tblfrm">
                <tr>
                    <td class="box">
                        <asp:Label ID="Label1" runat="server" Text="Select School:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_school" DataTextField = "School_Name" DataValueField="School_Code" runat="server" AutoPostBack="true" Height="40px" Width="226px">
                        </asp:DropDownList>
                    </td>
                  
                </tr>
                <tr>
                    <td class="box">
                        <asp:Label ID="Label2" runat="server" Text="Select Teacher:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_teacher" DataTextField = "Teacher_Name" DataValueField="Teacher_ID" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddl_teacher_SelectedIndexChanged" AutoPostBack="true" Height="40px" Width="226px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="box">
                        <asp:Label ID="Label3" runat="server" Text="Teacher's Name:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_teacher" runat="server" Height="36px" Width="288px" BackColor="BlanchedAlmond"></asp:TextBox>
                    </td>
                  
                </tr>
                <tr>
                    <td class="box">
                        <asp:Label ID="Label4" runat="server" Text="Subject Name:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_sub" DataTextField = "Subject_Name" DataValueField="Subject_ID" runat="server" AutoPostBack="true" Height="40px" Width="226px">
                        </asp:DropDownList>
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
                    <asp:Label ID="Label5" runat="server" Text="Click here to download:" Font-Bold="true"></asp:Label></td>
               
                <td class="pdfbt">
                    <asp:ImageButton ID="pdfbtn" runat="server" OnClick="pdfbtn_Click" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" />
                </td>
            </tr>
        </table>
        </div>

        <div>
            <asp:GridView ID="gridtech" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" ShowHeaderWhenEmpty="true" EmptyDataText="No record available"
                     OnRowCommand="gridtech_RowCommand" OnRowEditing="gridtech_RowEditing" OnRowUpdating="gridtech_RowUpdating" OnRowUpdated="gridtech_RowUpdated"
                     OnRowDeleting="gridtech_RowDeleting" style="margin-right:50px">
                    <FooterStyle ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BorderColor="" BackColor="#376ab3" Font-Size="14px" HorizontalAlign="Center" ForeColor="White" />
                    <RowStyle BackColor="#EEF2F6" />
                    <Columns>

                         <asp:TemplateField HeaderText="School" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="School_Code" Font-Size="14px" runat="server" Text='<%#Eval("School_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Teacher ID">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Teacher_ID" Font-Size="14px" runat="server" Text='<%#Eval("Teacher_ID")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Teacher's Name" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Teacher_Name" Font-Size="14px" runat="server" Text='<%#Eval("Teacher_Name")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Subject">
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
                                    <asp:LinkButton ID="btnEdit" Font-Size="15px" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Teacher_ID")%>' ForeColor="#006600">Edit</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btndel" Font-Size="15px" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Teacher_ID")%>' ForeColor="#006600">Delete</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>

    </div>
</asp:Content>
