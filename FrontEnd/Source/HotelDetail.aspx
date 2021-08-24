<%@ Page Title="" Language="C#" MasterPageFile="~/_FrontEnd.Master" AutoEventWireup="true" CodeBehind="HotelDetail.aspx.cs" Inherits="FrontEnd.Source.HotelDetail" %>

<%@ Register Src="~/Source/usrHotelDetail/usrHotelImage.ascx" TagPrefix="uc1" TagName="usrHotelImage" %>
<%@ Register Src="~/Source/usrHotelDetail/usrHotelDetail.ascx" TagPrefix="uc1" TagName="usrHotelDetail" %>
<%@ Register Src="~/Source/usrHotelDetail/usrHotelIntroduction.ascx" TagPrefix="uc1" TagName="usrHotelIntroduction" %>
<%@ Register Src="~/Source/usrHotelDetail/usrCheckIn.ascx" TagPrefix="uc1" TagName="usrCheckIn" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/HotelDetail/HotelDetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //Dat khach san
            $('#dat-khach-san').click(function () {
                HideShowTab();
                return false;
            });

            var sId = getParameterByName('sId');
            if (sId == "") {
                $('.room-price').hide();
                $('.room-count').hide();
                $('.t-book').hide();
                $('#continue').css("display", "none");
                $('#table1').css("display", "none");
            }
            if (getParameterByName('tab') == '1') {
                HideShowTab();
                $('#dateValidation').text("Lỗi ngày đến,ngày đi");
            }
            if (getParameterByName('tab') == '2') {
                HideShowTab();
            }
        });
        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        function HideShowTab() {
            $("html, body").animate({ scrollTop: 700 }, "normal");
            if ($('li').hasClass('active')) {
                $('li').removeClass('active');
                $('#gioi-thieu').hide();
                $('#huy-phong').hide();
                $('#loai-phong').hide();
                $('#danh-gia').hide();
            }
            $('#datphong').addClass('active');
            $('#dat-phong').show();
        }
    </script>
    <!-- Main tour desc -->
    <div class="main-detail full bg-white margin-top-10 cols_2_main radius-5 shadow ">
        <uc1:usrHotelImage runat="server" ID="usrHotelImage" />
        <div class="main-desc col-1 right relative">
            <uc1:usrHotelDetail runat="server" ID="usrHotelDetail" />
        </div>
    </div>
    <!-- Main tour desc -->
    <!-- Main search -->
    <div class="full cols_2_right margin-top-20">
        <div id="search-result" class="col-1 left bg-white radius-0-5" style="width:100%">
            <ul id="tab-tour" class="po-tabs left i-tabs bg-main full">
                <li class="active" id="gioithieu">
                    <a class="gioi-thieu" data="gioi-thieu" href="">Giới thiệu</a>
                </li>
                <li id="datphong"><a class="dat-phong" href="" data="dat-phong">Đặt phòng</a></li>
            </ul>
            <div class="po-tabs-content i-tab-content full-padding bg-white" id="gioi-thieu">
                <uc1:usrHotelIntroduction runat="server" id="usrHotelIntroduction" />
            </div>
            <div class="po-tabs-content i-tab-content full bg-white hide" id="dat-phong">
                <uc1:usrCheckIn runat="server" id="usrCheckIn" />
            </div>
        </div>
        <!-- Sidebar style -->
        <div class="col-1 right">
        </div>
    </div>
    <!-- End search -->
</asp:Content>
