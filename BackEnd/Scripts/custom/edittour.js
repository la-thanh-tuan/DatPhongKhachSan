
function PopupCenter(pageURL, h, w) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var targetWin = window.open(pageURL, '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=1, resizable=1, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}
jQuery().ready(function () {
    jQuery('a.lich-khoi-hanh').click(function () {
        var id = jQuery('#ContentPlaceHolder1_usrTourBasic1_HiddenFieldTourId').val();
        PopupCenter('/Tour/TourLichKhoiHanh.aspx?tourId='+id, 600, 600);
        return false;
    });
    jQuery('a.ten-khach-cac-phong').click(function () {
        var id = jQuery('#ContentPlaceHolder1_usrTenKhachCacPhong1_HiddenOrderId').val();
        PopupCenter('/Booking/SuaThongTinKhach.aspx?orderId=' + id, 600, 600);
        return false;
    });
});