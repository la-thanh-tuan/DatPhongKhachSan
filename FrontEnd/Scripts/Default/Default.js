$(document).ready(function () {
    if (!$('.bg-main').hasClass('homepage')) {
        $('.bg-main').addClass('homepage');
    };
    $('#contentMain_usrFormSearchTour1_DropDownListTourNuocNgoai').hide();
    $('#contentMain_usrFormSearchTour1_radTourNuocNgoai').click(function () {
        $('#contentMain_usrFormSearchTour1_DropDownListTourNuocNgoai').show();
        $('#contentMain_usrFormSearchTour1_DropDownListTourTrongNuoc').hide();
    });
    $('#contentMain_usrFormSearchTour1_radTourTrongNuoc').click(function () {
        $('#contentMain_usrFormSearchTour1_DropDownListTourNuocNgoai').hide();
        $('#contentMain_usrFormSearchTour1_DropDownListTourTrongNuoc').show();
    });
});
