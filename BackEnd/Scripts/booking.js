jQuery(document).ready(function () {
    var tab = getQuery('tab');
    if (tab == '') {
        jQuery('.tableTab td').first().removeClass("tab").addClass("currentTab");
    }
    else {
        jQuery('.tableTab td').each(function () {
            var tabItem = jQuery(this).attr('tab');
            if (tabItem == tab) {
                jQuery(this).removeClass("tab").addClass("currentTab");
            } else
                jQuery(this).removeClass("currentTab").addClass("tab");
        });
    }
});
function getQuery(key) {
    var temp = location.search.match(new RegExp(key + "=(.*?)($|\&)", "i"));
    if (!temp) return "";
    return temp[1];
}