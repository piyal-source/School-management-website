<%@ Page Title="" Language="C#" MasterPageFile="~/home_master.Master" AutoEventWireup="true" CodeBehind="Vacancy_Master.aspx.cs" Inherits="school.Vacancy_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formcss
        {
            width: 100%;
            height: 300px;
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
        .auto-style3 {
            height: 36px;
        }
        .btn
        {
            height:50px;
            width:50px;
        }
        .auto-style1 {
            height: 72px;
            text-align:right;
        }
        .auto-style4 {
            height: 6px;
        }
        .auto-style5 {
            height: 35px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <br />
        <br />
        <div style="font-weight:bold; color:mediumpurple; font-size:30px">
            <asp:Label ID="Label4" runat="server" Text="VACANCY MASTER"></asp:Label>
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
                <asp:DropDownList ID="ddlschool" runat="server" DataTextField="School_Name" DataValueField="School_Code" AutoPostBack="true" Height="40px" Width="230px" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lclass" runat="server" Text="Select Class" Font-Bold="true"></asp:Label>
                </td>
                <td class="auto-style3">
                <asp:DropDownList ID="ddlclass" runat="server" DataTextField="Class" DataValueField="Class" AutoPostBack="true" Height="40px" Width="230px" AppendDataBoundItems="true" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lvacancy" runat="server" Text="Vacancy:" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtvacancy" runat="server" Height="35px" Width="230px" BackColor="BlanchedAlmond" TextMode="Number"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style4"></td>
            </tr>

            <tr>
                <td class="auto-style5">

                </td>
                <td class="auto-style5">
                    <asp:Button ID="btnsave" runat="server" Text="Save" Height="35px" Width="146px" OnClick="btnsave_Click" />
                </td>
            </tr>

            <%--<tr>
                <td class="auto-style6">

                </td>
                <td class="auto-style6">
                    <asp:Button ID="btnupdate" runat="server" Text="Update" Height="35px" Width="146px" OnClick="btnupdate_Click" />
                </td>
            </tr>--%>
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
                                    <asp:Label ID="Board_ID" Font-Size="14px" runat="server" Text='<%#Eval("Class")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vacancy" Visible="true">
                            <ItemTemplate>
                                <div style="padding: 3px 0px 3px 3px">
                                    <asp:Label ID="Board" Font-Size="14px" runat="server" Text='<%#Eval("Vacancy")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
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
