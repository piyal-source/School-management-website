<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="School_Master.aspx.cs" Inherits="school.School_Master" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formcss
        {
            width: 100%;
            height: 295px;
            margin-bottom:40px;
            margin-top:30px;
            background-color:lightsteelblue;
            border-radius:10px;
            border:solid #808080;
        }
        .auto-style1 {
            height: 72px;
            text-align:right;
        }
        .auto-style2 {
            width: 634px;
            height: 224px;
            margin-left: 10px;
            margin-top:8px;
        }
        .btn
        {
            height:50px;
            width:50px;
        }
        .auto-style3 {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <br />
        <br />
        <div style="font-weight:bold; color:mediumpurple; font-size:30px">
            <asp:Label ID="Label4" runat="server" Text="SCHOOL MASTER"></asp:Label>
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
                    <asp:DropDownList ID="ddlsub" DataTextField="Sub_Div_Name" DataValueField="Sub_Div_Code" OnSelectedIndexChanged="ddlsub_SelectedIndexChanged" AutoPostBack="true" Height="40px" Width="230px" runat="server"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lschoolcode" runat="server" Text="Select School" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                <asp:DropDownList ID="ddlschool" runat="server" DataTextField="School_Name" DataValueField="School_Code" AutoPostBack="true" Height="40px" Width="230px" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlschool_SelectedIndexChanged" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lschoolname" runat="server" Text="School Name:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtschool" runat="server" Height="35px" Width="288px" BackColor="BlanchedAlmond"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lboard" runat="server" Text="Select Board" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                <asp:DropDownList ID="ddlboard" runat="server" DataTextField="Board" DataValueField="Board_ID" AutoPostBack="true" Height="40px" Width="230px" AppendDataBoundItems="true" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="height:8px"></td>
            </tr>

            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="Save" Height="35px" Width="146px" OnClick="btnsave_Click" />
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
                    <td class="btn">
                        <asp:ImageButton ID="btnpdf" runat="server" Height="50px" Width="50px" ImageUrl="~/img/pdflogo.png" OnClick="btnpdf_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <asp:GridView ID="schgrid" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" CellSpacing="2" ShowHeaderWhenEmpty="true" EmptyDataText="No records available"
                     OnRowCommand="schgrid_RowCommand" OnRowEditing="schgrid_RowEditing" OnRowUpdating="schgrid_RowUpdating" OnRowUpdated="schgrid_RowUpdated"
                     OnRowDeleting="schgrid_RowDeleting" style="margin-right:50px">
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

                        <asp:TemplateField HeaderText="School Code" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="School_Code" Font-Size="14px" runat="server" Text='<%#Eval("School_Code")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
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

                        <asp:TemplateField HeaderText="Board ID" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Board_ID" Font-Size="14px" runat="server" Text='<%#Eval("Board_ID")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Board Name" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Board" Font-Size="14px" runat="server" Text='<%#Eval("Board")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="8px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btnEdit" Font-Size="15px" runat="server" CommandName="Edit" CommandArgument='<%# Eval("School_Code")%>' ForeColor="#006600">Edit</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5px" />
                            <ItemTemplate>
                                <div style="padding: 0px 0px 0px 0px">
                                    <asp:LinkButton ID="btndel" Font-Size="15px" runat="server" CommandName="Delete" CommandArgument='<%# Eval("School_Code")%>' ForeColor="#006600">Delete</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>

    </div>

</asp:Content>
