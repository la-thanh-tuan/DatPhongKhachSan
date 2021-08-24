<%@ Page Title="" Language="C#" MasterPageFile="~/_PopUp.Master" AutoEventWireup="true" CodeBehind="EditRooms.aspx.cs" Inherits="BackEnd.Source.HotelManager.EditRooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
            <h3>Quản lý phòng</h3>
        </div>
        <br />
    <asp:DataGrid ID="dtgRoom" runat="server" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" OnItemCommand="dtgRoom_ItemCommand" OnItemDataBound="dtgRoom_ItemDataBound" OnPageIndexChanged="dtgRoom_PageIndexChanged">
        <Columns>
            <asp:TemplateColumn HeaderText="Số phòng :">
                <FooterTemplate>
                    <asp:TextBox ID="txtNo" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtNo" runat="server" Text='<%# Eval("No") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Người quản lý :">
                <FooterTemplate>
                    <asp:DropDownList ID="ddlManager" runat="server">
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlManager" runat="server">
                    </asp:DropDownList>
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
