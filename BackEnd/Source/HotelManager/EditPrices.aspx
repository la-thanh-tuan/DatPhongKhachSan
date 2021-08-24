<%@ Page Title="" Language="C#" MasterPageFile="~/_PopUp.Master" AutoEventWireup="true" CodeBehind="EditPrices.aspx.cs" Inherits="BackEnd.Source.HotelManager.EditPrices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
            <h3>Quản lý gía</h3>
        </div>
        <br />
    <asp:DataGrid ID="dtgPrice" runat="server" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" OnItemCommand="dtgPrice_ItemCommand" OnItemDataBound="dtgPrice_ItemDataBound" OnPageIndexChanged="dtgPrice_PageIndexChanged">
        <Columns>
            <asp:TemplateColumn HeaderText="Ngày bắt đầu :">
                <FooterTemplate>
                    <asp:TextBox ID="txtStartDate" CssClass="datepickerclass" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtStartDate" CssClass="datepickerclass" runat="server" Text='<%# ((DateTime)Eval("StartDate")).ToString("dd/MM/yyyy") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Ngày kết thúc :">
                <FooterTemplate>
                    <asp:TextBox ID="txtEndDate" CssClass="datepickerclass" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtEndDate" CssClass="datepickerclass" runat="server" Text='<%# ((DateTime)Eval("EndDate")).ToString("dd/MM/yyyy") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Giá phòng/1 đêm :">
                <FooterTemplate>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <HeaderStyle Width="50" />
                <FooterTemplate>
                    <asp:ImageButton ID="imbAdd" runat="server" CommandName="add" ImageUrl="~/Images/Event/add.png" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="imbSave" runat="server" CommandName="save" ImageUrl="~/Images/Event/edit.png" CommandArgument='<%# Eval("Id") %>' />
                    <asp:ImageButton ID="imbDelete" runat="server" CommandName="delete" ImageUrl="~/Images/Event/delete.png" CommandArgument='<%# Eval("Id") %>' OnClientClick="javascript : return confirm('Bạn có muốn xóa phòng này ?')" />
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <PagerStyle Mode="NumericPages" CssClass="pager-grid" />
    </asp:DataGrid>

</asp:Content>
