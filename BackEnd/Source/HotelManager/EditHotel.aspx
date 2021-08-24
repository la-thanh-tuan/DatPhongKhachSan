<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="EditHotel.aspx.cs" Inherits="BackEnd.Source.HotelManager.EditHotel" %>

<%@ Register Src="~/Source/HotelManager/usr/usrHotelBasic.ascx" TagPrefix="uc1" TagName="usrHotelBasic" %>
<%@ Register Src="~/Source/HotelManager/usr/usrHotelImage.ascx" TagPrefix="uc1" TagName="usrHotelImage" %>
<%@ Register Src="~/Source/HotelManager/usr/usrHotelRoomType.ascx" TagPrefix="uc1" TagName="usrHotelRoomType" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
            <h3>Sửa khách sạn</h3>
        </div>
        <br />
    <div class="pageheader">
        <h1 class="pagetitle">
            <asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label>
        </h1>


        <ul class="hornav editHotelCookies">
            <li class="current"><a href="#hotelbasic">Thông Tin</a></li>
            <li><a href="#hotelimages">Ảnh</a></li>
            <li><a href="#hotelroomtype">Loại Phòng</a></li>
        </ul>
    </div>
    <!--pageheader-->

    <div id="contentwrapper" class="contentwrapper">

        <div id="hotelbasic" class="subcontent">
            <uc1:usrHotelBasic runat="server" ID="usrHotelBasic" />
        </div>

        <div id="hotelimages" class="subcontent" style="display: none">
            <uc1:usrHotelImage runat="server" ID="usrHotelImage" />
        </div>

        <div id="hotelroomtype" class="subcontent" style="display: none">
            <uc1:usrHotelRoomType runat="server" ID="usrHotelRoomType" />
        </div>

        <%--<div id="hotelroomprice" class="subcontent" style="display: none">
            <uc3:usrHotelPrice ID="usrHotelPrice1" runat="server" />
        </div>--%>
        <div id="hotelFeature" class="subcontent" style="display: none">
            <%--<uc5:usrHotelFeature ID="usrHotelFeature1" runat="server" />--%>
        </div>
        <div id="hotelCancelPolicy" class="subcontent" style="display: none">
            <%--<uc6:usrHotelCancelPolicy ID="usrHotelCancelPolicy1" runat="server" />--%>
        </div>
        <div id="hotelPromotion" class="subcontent" style="display: none">
            <%--<uc7:usrHotelPromotion ID="usrHotelPromotion1" runat="server" />--%>
        </div>
        <div id="hotelIntroduction" class="subcontent" style="display: none; text-align: center;">
            <%--<uc8:usrIntroduction runat="server" ID="usrIntroduction1" />--%>
        </div>
        <!--subcontent-->
        <div id="surcharge" class="subcontent" style="display: none; text-align: center;">
            <%--<uc9:usrPhuThu ID="usrPhuThu1" runat="server" />--%>
        </div>
    </div>
    <!--contentwrapper-->
</asp:Content>
