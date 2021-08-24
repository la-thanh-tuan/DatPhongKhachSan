$(document).ready(function () {
    $('.ddlTourSubNuocNgoai').hide();
    $('.radSubTourNuocNgoai').click(function () {
        $('.ddlTourSubNuocNgoai').show();
        $('.ddlTourSubTrongNuoc').hide();
    });
    $('.radSubTourTrongNuoc').click(function () {
        $('.ddlTourSubNuocNgoai').hide();
        $('.ddlTourSubTrongNuoc').show();
    });
    $('.ss-hotel').click(function () {
        $('#fs-hotel').show();
        $('#fs-tour').hide();
        return false;
    });
    $('#fs-hotel').hide();
    $('.ss-tour').click(function () {
        $('#fs-tour').show();
        $('#fs-hotel').hide();
        return false;
    }); 
    $('#contentMain_usrFormSearchSubColumn_usrformSearchHotel_ButtonSearch').parent().addClass('ss-submit');
    $('#contentMain_usrFormSearchSubColumn_usrFormSearchTour_ButtonSearch').parent().addClass('ss-submit');
    $('#fs-hotel').removeClass('bg-content hide i-tab-content');
    $('#fs-hotel').addClass('po-tabs-content i-tab-content full bg-white');
    $('#fs-tour').removeClass('bg-content hide i-tab-content');
    $('#fs-tour').addClass('po-tabs-content i-tab-content full bg-white');
    $('#fs-hotel .text-input').css("width", '230px');
    $('#fs-hotel .date.hotel.text-input').css("width", '80px');
    $('#fs-tour .date.hotel.text-input').css("width", '85px');
    $('.date.hotel.text-input').datepicker();
    //var availableTags = $("#contentMain_usrFormSearchSubColumn_usrformSearchHotel_HiddenFieldTagHotel").val().split(',', 10000);
    //$('#contentMain_usrFormSearchSubColumn_usrformSearchHotel_TextBoxHotelName').autocomplete({
    //    source: availableTags
    //})
    //$('.date.hotel').removeAttr('background');
    //$("#contentMain_usrFormSearchSubColumn_usrformSearchHotel_TextBoxCity").autocomplete({
    //    source:
    //        function (request, response) {
    //            $.ajax({
    //                type: "POST",
    //                url: "/Ajax/HotelAutoSuggest.aspx/AutoSuggest",
    //                contentType: "application/json; charset=utf-8",
    //                dataType: "json",
    //                data: JSON.stringify({ q: request.term }),
    //                success: function (data) {
    //                    response(data.d.split(","));
    //                },
    //                error: function (msg) {

    //                }
    //            });
    //        },
    //});
});