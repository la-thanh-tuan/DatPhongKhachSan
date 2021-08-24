<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrCheckIn.ascx.cs" Inherits="FrontEnd.Source.usrHotelDetail.usrCheckIn" %>
<script type="text/javascript">
    $(document).ready(function () {
        //var currentDate = new Date();
        $('#contentMain_usrCheckIn_ngay_den').datepicker({
            changeMonth: true,
            changeYear: true,
            numberOfMonths: 2,
            minDate: 0,
            //dateFormat: 'DD, d MM, yy',
            onClose: function (selectedDate) {
                $("#contentMain_usrCheckIn_ngay_di").datepicker("option", { "minDate": selectedDate });
                $("#contentMain_usrCheckIn_ngay_di").focus();
            }
        });
        $('#contentMain_usrCheckIn_ngay_di').datepicker({
            changeMonth: true,
            changeYear: true,
            numberOfMonths: 2,
            onClose: function (selectedDate) {
                $("#contentMain_usrCheckIn_ngay_den").datepicker("option", "maxDate", selectedDate);
            }
        });
    });
    function lnkRoomClick(lnk) {
        if ($(lnk).text().endsWith('+')) {
            $(lnk).text('ấn phòng -');
            var chk = $(lnk).parent().parent().find('.chkRoom').show();
            $(chk).fadeIn('slow', function () {
                $(chk).show();
            });
        } else {
            $(lnk).text('Xem phòng +');
            var chk = $(lnk).parent().parent().find('.chkRoom').show();
            $(chk).fadeOut('slow', function () {
                $(chk).hide();
            });
        }
        return false;
    }
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="hotel-search left">
            <h3 class="title" style="font-size: 16px;">Chọn ngày để kiểm tra giá </h3>
            <table class="margin-top-10 full">
                <tr>
                    <td>
                        <div id="dateValidation" style="font-size:larger;">
                            <asp:Literal runat="server" ID="litError"></asp:Literal></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b class="title" style="margin-right: 25px;">Ngày đến :</b>
                        <asp:TextBox runat="server" ID="ngay_den" CssClass="date hotel text-input radius-3" placeholder="Ngày nhận phòng"></asp:TextBox>
                    </td>
                    <td>
                        <b class="title" style="margin-right: 25px; margin-left: 20px;">Ngày đi :</b>
                        <asp:TextBox runat="server" ID="ngay_di" CssClass="date hotel text-input radius-3" placeholder="Ngày trả phòng"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" CssClass="button radius-5 right" ID="kiemtragia" OnClick="kiemtragia_Click" Text="Kiểm tra giá" Style="padding: 10px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="div-room-price" style="width:100%;padding:10px;float:left;">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="loading" align="center">
                        Hệ thống đang xử lý<br />
                        Xin chờ trong giây lát...
        <br />
                        <img src="/Images/loader6.gif" alt="" style="margin-top: 10px;" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table style="width:100%">
                <tr>
                            <td>

                            </td>
                            <td>
                                Loại phòng
                            </td>
                            <td>
                                Số người tối đa
                            </td>
                            <td>
                                Giá mỗi phòng
                            </td>
                            <td>
                                Số lượng phòng
                            </td>
                            <td>
                                Số người
                            </td>
                        </tr>
                <asp:ListView runat="server" ID="lvRoomDetail" OnItemDataBound="lvRoomDetail_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hidRoomTypeId" Value='<%# Eval("Id") %>' />
                        
                        <tr class="room-item">
                            <td class="room-detail">
                                <asp:Image runat="server" CssClass="left r-image" ID="imgAvatar" ImageUrl='<%# FrontEnd.Source.Helper.UrlHelper.BackEndUrl+((DAO.Source.Model.HotelImage)Eval("Avatar")).Url  %>' />
                            </td>
                            <td>
                                <h3 class="title"><%# Eval("Name") %></h3>
                            </td>
                            <td class="room-person">
                                <%# Eval("MaxPeople") %>
                            </td>
                            <td class="room-price">
                                <p class="new-price" id="newprice">
                                    <asp:Literal runat="server" ID="litPrice"></asp:Literal><sup>đ</sup>
                                </p>
                            </td>
                            <td class="room-count" style="width: 200px">
                                <asp:DropDownList ID="ddlRoomCount" runat="server"></asp:DropDownList>
                            </td>
                            <td class="people" style="width: 200px">
                                <asp:TextBox ID="txtPeople" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
            <style type="text/css">
                .tbl{width:100%;}
                .tbl tr{padding:5px;}
                .tbl tr td{padding:5px;}
            </style>
            <table class="tbl">
                <tr style="text-align:center">
                    <td colspan="2">Thông tin người liên hệ :</td>
                </tr>
                <tr>
                    <td>Họ và tên :
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="426px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Địa chỉ :</td>
                    <td>
                        <asp:TextBox ID="txtAdress" runat="server" Width="426px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Số điện thoại :</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Width="426px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email :</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="426px"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="btnOrder" runat="server" Text="đặt phòng" OnClick="btnOrder_Click" CssClass="button radius-5" OnClientClick="return validOrder();" />
                    </td>
                </tr>
            </table>
        </div>
        
    </ContentTemplate>
</asp:UpdatePanel>

