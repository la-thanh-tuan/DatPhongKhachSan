<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrHotelRoomType.ascx.cs" Inherits="BackEnd.Source.HotelManager.usr.usrHotelRoomType" %>
<asp:DataGrid ID="dtgHotelRoomType" runat="server" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="True" OnItemCommand="dtgHotelRoomType_ItemCommand" OnItemDataBound="dtgHotelRoomType_ItemDataBound" OnPageIndexChanged="dtgHotelRoomType_PageIndexChanged">
    <Columns>
        <asp:TemplateColumn HeaderText="Tên :">
            <FooterTemplate>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Số Khách tối đa :">
            <FooterTemplate>
                <asp:TextBox ID="txtMaxPeople" runat="server"></asp:TextBox>
            </FooterTemplate>
            <ItemTemplate>
                <asp:TextBox ID="txtMaxPeople" runat="server" Text='<%# Eval("MaxPeople") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Hình ảnh">
            <FooterTemplate>
                <asp:FileUpload ID="fileAvatar" runat="server" />
            </FooterTemplate>
            <ItemTemplate>
                <asp:Image ID="imgAvatar" runat="server" Height="50" Width="50" />
                <asp:FileUpload ID="fileAvatar" runat="server" />
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:HyperLink ID="lnkEditRooms" runat="server" CssClass="edit-popup" NavigateUrl='<%#"/Source/HotelManager/EditRooms.aspx?roomTypeId="+Eval("Id") %>'>Sửa danh sách phòng</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:HyperLink ID="lnkEditRoomTypePrice" runat="server" CssClass="edit-popup" NavigateUrl='<%#"/Source/HotelManager/EditPrices.aspx?roomTypeId="+Eval("Id") %>'>Sửa giá</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:HyperLink ID="lnkEditFeature" runat="server" CssClass="edit-popup" NavigateUrl='<%#"/Source/HotelManager/EditFeature.aspx?roomTypeId="+Eval("Id") %>'>Tiện ích</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderStyle Width="50" />
            <FooterTemplate>
                <asp:ImageButton ID="imbAdd" runat="server" CommandName="add" ImageUrl="~/Images/Event/add.png" />
            </FooterTemplate>
            <ItemTemplate>
                <asp:ImageButton ID="imbSave" runat="server" CommandName="save" ImageUrl="~/Images/Event/edit.png" CommandArgument='<%# Eval("Id") %>' />
                <asp:ImageButton ID="imbDelete" runat="server" CommandName="delete" ImageUrl="~/Images/Event/delete.png" CommandArgument='<%# Eval("Id") %>' OnClientClick="javascript : return confirm('Bạn có muốn xóa loại phòng này ?')" />
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
    <PagerStyle Mode="NumericPages" CssClass="pager-grid" />
</asp:DataGrid>