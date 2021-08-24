<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="BackEnd.Source.Account.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
        <h3>Sửa thông tin cá nhân :</h3>
    </div>
    <table class="grd-stdtable">
        <tr>
            <td>UserName :
            </td>
            <td>
                <asp:Label runat="server" ID="lblUserName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Avatar :
            </td>
            <td>
                <asp:Image runat="server" id="imgAvatar" Width="100" Height="100"/>
                <asp:FileUpload runat="server" id="fileAvatar"/>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnChange" OnClick="btnChange_Click" Text="lưu lại" />
            </td>
        </tr>
    </table>
    <div class="contenttitle2">
        <h3>Thay đổi mật khẩu :</h3>
    </div>
    <table class="grd-stdtable">
        <tr>
            <td>UserName :
            </td>
            <td>
                <asp:Label runat="server" ID="lblUserName1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu cũ :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu mới :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNewPassword"  TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nhập lại mật khẩu mới :
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNewPassword1"  TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnChangePass" OnClick="btnChangePass_Click" Text="Lưu lại" />
            </td>
        </tr>
    </table>
</asp:Content>
