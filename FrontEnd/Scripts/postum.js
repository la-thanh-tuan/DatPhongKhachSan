/**
 * Created with JetBrains PhpStorm.
 * User: l2qnew
 * Date: 10/24/13
 * Time: 10:49 PM
 * To change this template use File | Settings | File Templates.
 */

$(document).ready(function(){
    // Over deals items
    $('.deal-img,.overlay-deal').hover(function(){
            $(this).parent().find('.overlay-deal').show();
        },function(){
            $(this).parent().find('.overlay-deal').hide();
        }
    )
    // scroll to top
    $(window).scroll(function () {
        goTop = $('#go-top');
        minHeight = 100;
        if ($(window).scrollTop() >= minHeight) {
            goTop.fadeIn();
        }
        else {
            goTop.fadeOut();
        }
    });
    $('#go-top').click(function() {
        $("html, body").animate({ scrollTop: 0 }, "normal");
        return false;
    });
});
function setFeatured(e) {

}

