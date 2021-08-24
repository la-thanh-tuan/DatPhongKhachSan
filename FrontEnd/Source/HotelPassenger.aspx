<%@ Page Title="" Language="C#" MasterPageFile="~/_FrontEnd.Master" AutoEventWireup="true" CodeBehind="HotelPassenger.aspx.cs" Inherits="FrontEnd.Source.HotelPassenger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dat-khach-san').hide();
            $('.price').hide();
        });
    </script>

    <!-- Slide show  -->

    <div class="main-detail full bg-white margin-top-10 cols_2_main radius-5 shadow ">
        <%--<uc3:usrHotelImage runat="server" ID="usrHotelImage" />--%>
        <%-- Hotel Image --%>
        <div class="main-img col-1 left">
            <div id="imageview">
                <img src="{hotelimage}" alt="example" width="722" height="406" />
            </div>
            <div id="img-thumbnails" class="full">
                <div id="prev-image" class="control-button left"></div>
                <div id="thumbnails">
                    {otherhotelimage}                    
                </div>
                <div id="next-image" class="control-button left"></div>
            </div>

            <script type="text/javascript">
                $(document).ready(function () {
                    $('#thumbnails').simplethumbs({ slideshow: '#imageview' });
                    slideItem = $('#thumbnails a').length;
                    $('#next-image').click(function () {
                        activeE = $('#thumbnails a.active');
                        acticeIndex = $('#thumbnails a').index(activeE);
                        if (slideItem > 5 && acticeIndex > 3 && acticeIndex < (slideItem)) {
                            indexHide = acticeIndex - 3;
                            $('#thumbnails a').show();
                            if (acticeIndex == (slideItem - 1)) {
                                indexHide = acticeIndex - 4;
                                $('#thumbnails a:lt(' + indexHide + ')').hide();
                            }
                            else {
                                $('#thumbnails a:lt(' + indexHide + ')').hide("slide", { direction: 'left' });
                            }
                        }
                    });
                    $('#prev-image').click(function () {
                        activeE = $('#thumbnails a.active');
                        acticeIndex = $('#thumbnails a').index(activeE);
                        if (slideItem > 5 && acticeIndex > 0) {
                            if (acticeIndex <= 3) {
                                $('#thumbnails a').show();
                            }
                            else {
                                indexHide = acticeIndex - 2;
                                $('#thumbnails a:gt(' + indexHide + ')').show("slide", { direction: 'left' });
                            }
                        }
                    });
                });
            </script>
        </div>

        <%-- End hotel image --%>
        <div class="main-desc col-1 right relative">
            <%--<uc2:usrhoteldetail runat="server" id="usrHotelDetail" />--%>
            <div class="desc-item ">
                <h2 class="title" style="font-size:16px;">{hotelname}</h2>
                <p class="desc-detail address">
                    {address} 
                </p>
                <p class="star-rate">
                    <img src="{star}" alt="" />
                </p>
            </div>
            {danhgia}
            <!--<div class="desc-item" style="display:none;">
                <p class="rating"><b>Rất tốt 8.5</b>  (16 đánh giá) </p>
            </div>-->
            <div class="desc-item table-cell padding-0">
                <div class="so-phong left ">Số phòng: <b>{roomtotal}</b></div>
                <div class="tien-ich right">
                    {feature}

                </div>
            </div>
            <div class="desc-item last">
                <ul class="uu-dai full">
                    {promotion}
                </ul>
            </div>
            <div class="desc-item last absolute main-book">
                <p class="price">{price}</p>
                <!--<a class="button favorite" href="">favorite </a>-->
                <a class="button book" href="" id="dat-khach-san">Đặt Khách Sạn</a>
            </div>
        </div>
        </div>
    </div>
    <!-- Main search -->
    <div class="full cols_2_right margin-top-20">
        <div id="search-result" class="col-1 left">

            <div class="po-tabs-content i-tab-content hotel passenger full-padding bg-white radius-5" id="">
                <!-- THÔNG TIN ĐẶT PHÒNG  -->
                <div class="dieu-kien full">
                    <h3 class="title"><span class="hotel">Thông Tin Đặt Phòng</span></h3>
                    <div class="content full">
                        <div style="margin-left: 30px;">
                            <table border="0" width="100%" class="booking-info-bg-table" cellspacing="0" cellpadding="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <%--<uc7:usrhotelpassengerdetail runat="server" id="usrHotelPassengerDetail" />--%>
                                            <table width="100%" cellpadding="0" cellspacing="0" class="tbPassenger">
                                                <thead>
                                                    <tr>
                                                        <th style="text-align: left">Loại Phòng 
                                                        </th>
                                                        <th style="text-align: left">Khách Tối Đa
                                                        </th>
                                                        <th>Giá {songay} Đêm
                                                        </th>
                                                        <th>Số Lượng Phòng 
                                                        </th>
                                                        <th>Tổng Giá 
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    
                                                    {detail}
                                                    <!--<tr>
                                                        <td style="text-align: left">
                                                            <div>{tenphong}</div>
                                                        </td>
                                                        <td style="padding-top: 5px">
                                                            <!--<img src="/images/person-icon.png">-->
                                                        <!--</td>
                                                        <td>{giatien}
                                                        </td>
                                                        <td>
                                                            <b>{sophong}</b>
                                                        </td>
                                                        <td>
                                                            <b style="color: #EF9123">{tonggiatien}</b>
                                                        </td>
                                                    </tr>-->
                                                    
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- THÔNG TIN KHÁCH  -->
                <div class="dieu-kien full">
                    <h3 class="title"><span class="hotel">Thông Tin Khách Đặt Phòng</span></h3>
                    <div class="content full" style="margin-left: 30px;">
                        <asp:Label runat="server" ID="lblValidation" ForeColor="Red" Visible="false"></asp:Label>
                        <asp:Table runat="server" ID="tb1">
                        </asp:Table>
                    </div>
                </div>
                <!-- ĐIỀU KIỆN HOTEL  -->
                <div class="dieu-kien full" style="display: none;">
                    <h3 class="title"><span class="hotel">Điều kiện Hotel</span></h3>
                    <div class="content full">
                        <%--<uc5:usrcondition runat="server" id="usrCondition" />--%>
                        <p><b class="other-color">Hủy đặt phòng:</b></p>
                        <%--<uc6:usrpolicy runat="server" id="usrPolicy" />--%>
                    </div>
                </div>
                <form action="" class="full">
                    <%--<uc1:usrpassenger runat="server" id="usrPassenger" />--%>
                    <div class="extra-info full">
                        <h3 class="title"><span class="extra">Yêu cầu Thêm</span></h3>
                        <div class="content full-padding-per ">
                            <asp:TextBox CssClass="extra-info radius-5 textarea-input" runat="server" ID="yeucauthem"></asp:TextBox>
                            <p class="main-color">Lưu ý</p>
                            <p>
                                Xin quý khách lưu ý, POSTUM TRAVEL sẽ chủ động liên hệ với quý khách (qua email hoặc điện thoại) sớm nhất có thể để xác nhận phòng và thời hạn thanh toán.
                                                <br>
                                Việc thanh toán chỉ được tiến hành sau khi quý khách nhận được xác nhận còn phòng trống từ POSTUM TRAVEL
                                <br>
                                Trường hợp Quý khách muốn xác nhận ngay, vui lòng liên hệ với <a
                                    href="http://www.postumtravel.vn/">POSTUM TRAVEL</a> theo
                                <br>
                                Hotline : 0913.320.889 - 0968.67.27.68
                                <br />

                                Hà Nội: (+84.4) 39.45.45.00/01 - 62.78.00.78/79 -  Hồ Chí Minh: (+84.8) 9.432.147 
                            </p>
                            <br>
                            <table style="display: none;">
                                <tr>
                                    <td>
                                        <label for="">
                                            <input type="checkbox" name="" id="Checkbox1" />
                                            Tôi muốn xuất hóa đơn
                                        </label>
                                    </td>
                                    <td>
                                        <label for="">
                                            <input type="checkbox" name="" id="Checkbox2" />Tôi muốn nhận được thông tin về chương trình khuyến mãi, tin tức....
                                        </label>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                            <br>
                            <p class="submit">
                                <asp:Button runat="server" CssClass="button radius-5 larger" ID="TiepTuc" OnClick="TiepTuc_Click" Text="Tiếp Tục" />
                            </p>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <!-- Sidebar style -->
        <div class="col-1 right">
            <%--<uc9:usrhotelsubcolum runat="server" id="usrHotelSubColum" />--%>
        </div>
    </div>
    <!-- End search -->


    <!-- End Main -->

</asp:Content>
