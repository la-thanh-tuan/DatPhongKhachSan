<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrUserInfo.ascx.cs" Inherits="BackEnd.Source.Account.usrUserInfo" %>
<div class="right">
    <div class="notification">
        <a class="count" href="/"><span>Trang Chủ</span></a>
    </div>
    <div class="userinfo" style="min-width:100px;">
        <asp:Image runat="server" ID="imgAvatar" Width="25" Height="25" />
        <span><asp:Literal ID="litUserName" runat="server"></asp:Literal></span>
    </div>
    <!--userinfo-->

    <div class="userinfodrop">
        <div class="avatar">
            <a href="#">
                <asp:Image runat="server" ID="imgAvatar2" Width="75" Height="75" />
            </a>     
        </div>
        <!--avatar-->
        <div class="userdata">
            <h4><asp:Literal ID="litUserName2" runat="server"></asp:Literal> </h4><br />
            <span class="email"><asp:Literal ID="litEmail" runat="server"></asp:Literal></span>
            <ul>
                <li><a href="/Source/Account/EditProfile.aspx">Thông tin cá nhân</a></li>                                
                <li><a href="/Source/Account/SigOut.aspx">Đăng xuất</a></li>
            </ul>
        </div>
        <!--userdata-->
    </div>
    <!--userinfodrop-->
</div>
<!--right-->