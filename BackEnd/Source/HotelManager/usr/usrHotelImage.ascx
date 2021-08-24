<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrHotelImage.ascx.cs" Inherits="BackEnd.Source.HotelManager.usr.usrHotelImage" %>
<div class="contenttitle2">
    <h3>Ảnh khách sạn</h3>
</div>
<div class="filemgr_head" style="width: 1026px;">
    <ul class="filemgr_menu">
        <li class="marginleft5"><a class="selectall">Chọn tất cả</a></li>
        <li class="marginleft5 viewfilebtn"><a class="preview preview_disabled">Xem ảnh</a></li>
        <li class="marginleft5 trashbtn"><a class="trash trash_disabled" title="Trash"></a></li>
        <li class="right newfilebtn">
            <asp:FileUpload CssClass="right fileuploadavatar" ID="FileUploadAvatar" runat="server" AllowMultiple="True" />
            <asp:Button CssClass="right buttonupload" ID="ButtonUpload" runat="server" Text="Thêm ảnh" OnClick="ButtonUpload_Click" />
        </li>
    </ul>
    <span class="clearall"></span>
</div>
<div class="filemgr_content" style="margin-right: 0px; padding: 0px;">
    <ul class="listfile">
        <asp:Label ID="LabelListImage" runat="server" Text=""></asp:Label>
    </ul>
    <br clear="all" />

</div>
