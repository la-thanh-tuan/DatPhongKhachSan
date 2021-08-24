$(document).ready(function () {
    $('#search-result>ul>li').click(function () {
        $('#search-result>ul>li').removeClass('active');
        $(this).addClass('active');
        $('.po-tabs-content').hide();
        $('#' + $(this).find('a').attr('data')).show();
        return false;
    });
});
function validOrder() {
    var table = $('#div-room-price').find('table').first();
    var trs = table.find('.room-item');
    for (var i = 0; i < trs.length; i++) {
        var max = parseInt($(trs[i]).find('td.room-person').text()) * parseInt($(trs[i]).find('td.room-count>select').val());
        alert(max);
        if (max < parseInt($(trs[i]).find('td.people>input').val())) {
            $(trs[i]).find('td.people>input').focus();
            alert('Số người vượt quá quy định. Vui lòng kiểm tra lại');
            return false;
        }
    }
    alert('Đặt hàng thành công. Chúng tôi sẽ liên hệ lại cho bạn sớm nhất có thể.');
    return true;
};