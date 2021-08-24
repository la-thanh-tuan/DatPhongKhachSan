<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="ManagerFeature.aspx.cs" Inherits="BackEnd.Source.HotelManager.ManagerFeature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
        <h3>Phân loại tiện ích</h3>
    </div>
    <asp:DataGrid ID="dtgFeature" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnItemCommand="dtgFeature_ItemCommand" OnPageIndexChanged="dtgFeature_PageIndexChanged" ShowFooter="True" OnItemDataBound="dtgFeature_ItemDataBound">
        <Columns>
            <asp:TemplateColumn HeaderText="Tên :">
                <FooterTemplate>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <FooterTemplate>
                    <asp:ImageButton ID="imbtAdd" runat="server" CommandName="add" ImageUrl="~/Images/Event/add.png" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="imbtSave" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="save" ImageUrl="~/Images/Event/edit.png" />
                    <asp:ImageButton ID="imbtDelete" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="delete" ImageUrl="~/Images/Event/delete.png" />
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <PagerStyle Mode="NumericPages" />
    </asp:DataGrid>
</asp:Content>
