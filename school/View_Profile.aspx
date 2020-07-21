<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Profile.aspx.cs" Inherits="school.WebForm1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>School Data</title>
    </head>
<body style="background-color:wheat">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
            DataKeyNames="SNo" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize = "3" AllowPaging ="true" OnPageIndexChanging = "OnPaging"
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
            Width="1016px" Height="146px">
            <Columns>

                

                <asp:TemplateField HeaderText="User Id" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l2" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t2" runat="server" Text='<%# Eval("UserId") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t3" runat="server" Text='<%# Eval("Name") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email Id" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l4" runat="server" Text='<%# Eval("EMail") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t4" runat="server" Text='<%# Eval("EMail") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l5" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t5" runat="server" Text='<%# Eval("Phone") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l6" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t6" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Gender" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l7" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t7" runat="server" Text='<%# Eval("Gender") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DOB" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="l8" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="t8" runat="server" Text='<%# Eval("DOB") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
            </Columns>
        </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
        <asp:Button ID="Button1" runat="server" Text="Export to PDF" BackColor="Red" Height="39px" OnClick="Button1_Click" Width="185px" />
    </form>
</body>
</html>
