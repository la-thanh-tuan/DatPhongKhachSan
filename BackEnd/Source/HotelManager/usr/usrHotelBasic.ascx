<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrHotelBasic.ascx.cs" Inherits="BackEnd.Source.HotelManager.usr.usrHotelBasic" %>
<table class="grd-stdtable">
    <tr>
        <td>Tên khách sạn :
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtHotelName"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Sao :
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlStar">
                <asp:ListItem Text="1 Sao" Value="1"></asp:ListItem>
                <asp:ListItem Text="2 Sao" Value="2"></asp:ListItem>
                <asp:ListItem Text="3 Sao" Value="3"></asp:ListItem>
                <asp:ListItem Text="4 Sao" Value="4"></asp:ListItem>
                <asp:ListItem Text="5 Sao" Value="5"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>địa chỉ :
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtAdress"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Tỉnh/Thành phố :
        </td>
        <td>
            <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Số điện thoại:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Email:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Mô tả chung :
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtDescription" Rows="5" Columns="70"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Avatar :
        </td>
        <td>
            <asp:Image runat="server" ID="imgAvatar" Width="100" Height="100" />
            <asp:FileUpload runat="server" ID="fileAvatar" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Lưu lại" />
        </td>
    </tr>
</table>
