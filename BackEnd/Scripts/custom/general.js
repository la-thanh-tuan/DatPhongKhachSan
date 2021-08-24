/*
 * 	Additional function for this template
 *	Written by ThemePixels	
 *	http://themepixels.com/
 *
 *	Copyright (c) 2012 ThemePixels (http://themepixels.com)
 *	
 *	Built for Amanda Premium Responsive Admin Template
 *  http://themeforest.net/category/site-templates/admin-templates
 */

jQuery.noConflict();

jQuery(document).ready(function () {

    function PopupCenter(pageURL, h, w) {
        var left = (screen.width / 2) - (w / 2);
        var top = (screen.height / 2) - (h / 2);
        var targetWin = window.open(pageURL, '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=1, resizable=1, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        var timer = setInterval(function () {
            if (targetWin.closed) {
                clearInterval(timer);
                window.location.reload();
            }
        }, 1000);
    }
    jQuery('.edit-popup').click(function () {
        PopupCenter(jQuery(this).attr('href'),800,800);
        return false;
    });
    // Set current link in left menu
    var url = window.location.pathname;
    jQuery('.iconmenu ul ul li a').each(function () {
        var href = jQuery(this).attr('href');
        if (href.toLowerCase() == url.toLowerCase()) {
            jQuery('.iconmenu ul ul li').removeClass('current');
            jQuery('.iconmenu ul li').removeClass('current');
            jQuery('.iconmenu ul ul').css("display", "none");
            jQuery(this).parent().addClass('current');
            jQuery(this).parent().parent().parent().addClass('current');
            jQuery(this).parent().parent().css("display", "block");
        }
    });
    //grd-btn-update click to show textbox
    jQuery('.grd-btn-update').click(function () {
        var tr = jQuery(this).parent().parent().addClass('current-test');
        jQuery('.current-test input[type=text]').each(function () {
            jQuery(this).css('display','');
        });
    });
    //Cookie left menu click
    /*jQuery('.iconmenu ul ul li').click(function () {
        jQuery.cookie('li', null);
        var liClass = jQuery(this).attr('class');
        jQuery.cookie('li', liClass, { path: '/' });
        var c = jQuery.cookie('li');
        //alert('click : ' + c);
    });
    if (jQuery.cookie('li')) {
        var c = jQuery.cookie('li');
        //alert('load : ' + c);
        jQuery('.iconmenu ul ul li').removeClass('current');
        jQuery('.iconmenu ul li').removeClass('current');
        jQuery('.iconmenu ul ul').css("display", "none");
        if (c != '' || c == null) {
            jQuery('.' + c).addClass('current');
            jQuery('.' + c).parent().parent().addClass('current');
            jQuery('.' + c).parent().css("display", "block");
        }
        jQuery.cookie('li', null);
    }*/
        

    ///// SHOW/HIDE USERDATA WHEN USERINFO IS CLICKED ///// 

    jQuery('.userinfo').click(function () {
        if (!jQuery(this).hasClass('active')) {
            jQuery('.userinfodrop').show();
            jQuery(this).addClass('active');
        } else {
            jQuery('.userinfodrop').hide();
            jQuery(this).removeClass('active');
        }
        //remove notification box if visible
        jQuery('.notification').removeClass('active');
        jQuery('.noticontent').remove();

        return false;
    });


    ///// SHOW/HIDE NOTIFICATION /////

    //jQuery('.notification a').click(function () {
    //    var t = jQuery(this);
    //    var url = t.attr('href');
    //    if (!jQuery('.noticontent').is(':visible')) {
    //        jQuery.post(url, function (data) {
    //            t.parent().append('<div class="noticontent">' + data + '</div>');
    //        });
    //        //this will hide user info drop down when visible
    //        jQuery('.userinfo').removeClass('active');
    //        jQuery('.userinfodrop').hide();
    //    } else {
    //        t.parent().removeClass('active');
    //        jQuery('.noticontent').hide();
    //    }
    //    return false;
    //});



    ///// SHOW/HIDE BOTH NOTIFICATION & USERINFO WHEN CLICKED OUTSIDE OF THIS ELEMENT /////


    jQuery(document).click(function (event) {
        var ud = jQuery('.userinfodrop');
        var nb = jQuery('.noticontent');

        //hide user drop menu when clicked outside of this element
        if (!jQuery(event.target).is('.userinfodrop')
			&& !jQuery(event.target).is('.userdata')
			&& ud.is(':visible')) {
            ud.hide();
            jQuery('.userinfo').removeClass('active');
        }

        //hide notification box when clicked outside of this element
        if (!jQuery(event.target).is('.noticontent') && nb.is(':visible')) {
            nb.remove();
            jQuery('.notification').removeClass('active');
        }
    });


    ///// NOTIFICATION CONTENT /////

    jQuery('.notitab a').live('click', function () {
        var id = jQuery(this).attr('href');
        jQuery('.notitab li').removeClass('current'); //reset current 
        jQuery(this).parent().addClass('current');
        if (id == '#messages')
            jQuery('#activities').hide();
        else
            jQuery('#messages').hide();

        jQuery(id).show();
        return false;
    });



    ///// SHOW/HIDE VERTICAL SUB MENU /////	

    jQuery('.vernav > ul li a, .vernav2 > ul li a').each(function () {
        var url = jQuery(this).attr('href');
        jQuery(this).click(function () {
            if (jQuery(url).length > 0) {
                if (jQuery(url).is(':visible')) {
                    if (!jQuery(this).parents('div').hasClass('menucoll') &&
					   !jQuery(this).parents('div').hasClass('menucoll2'))
                        jQuery(url).slideUp();
                } else {
                    jQuery('.vernav ul ul, .vernav2 ul ul').each(function () {
                        jQuery(this).slideUp();
                    });
                    if (!jQuery(this).parents('div').hasClass('menucoll') &&
					   !jQuery(this).parents('div').hasClass('menucoll2'))
                        jQuery(url).slideDown();
                }
                return false;
            }
        });
    });


    ///// SHOW/HIDE SUB MENU WHEN MENU COLLAPSED /////
    jQuery('.menucoll > ul > li, .menucoll2 > ul > li').live('mouseenter mouseleave', function (e) {
        if (e.type == 'mouseenter') {
            jQuery(this).addClass('hover');
            jQuery(this).find('ul').show();
        } else {
            jQuery(this).removeClass('hover').find('ul').hide();
        }
    });


    ///// HORIZONTAL NAVIGATION (AJAX/INLINE DATA) /////	

    jQuery('.hornav a').click(function () {
        
        //this is only applicable when window size below 450px
        if (jQuery(this).parents('.more').length == 0)
            jQuery('.hornav li.more ul').hide();

        //remove current menu
        jQuery('.hornav li').each(function () {
            jQuery(this).removeClass('current');
        });

        jQuery(this).parent().addClass('current');	// set as current menu
        var url = jQuery(this).attr('href');
        if (jQuery(this).parent().parent().hasClass('editHotelCookies')) {
            jQuery.cookie('editHotelCookies', null);
            jQuery.cookie('editHotelCookies', url, { path: '/', expires: 1 });
        }
        if (jQuery(this).parent().parent().hasClass('editTourCookies')) {
            jQuery.cookie('editTourCookies', url, { path: '/', expires: 1 });
            jQuery.cookie('editTourCookies', null);
        }
        if (jQuery(url).length > 0) {
            jQuery('.contentwrapper .subcontent').hide();
            jQuery(url).show();
        } else {
            jQuery.post(url, function (data) {
                jQuery('#contentwrapper').html(data);
                jQuery('.stdtable input:checkbox').uniform();	//restyling checkbox
            });
        }
        return false;
    });

    if (jQuery.cookie('editTourCookies')) {
        var urlCookies = jQuery.cookie('editTourCookies');
        jQuery('.editTourCookies li').each(function () {
            jQuery(this).removeClass('current');
        });
        jQuery('.editTourCookies li a').each(function () {
            var url = jQuery(this).attr('href');
            if (url == urlCookies) {
                jQuery(this).parent().addClass('current');
                jQuery('.contentwrapper .subcontent').hide();
                jQuery(url).show();
            }
        });
    }

    if (jQuery.cookie('editHotelCookies')) {
        var urlCookies = jQuery.cookie('editHotelCookies');        
        jQuery('.editHotelCookies li').each(function () {
            jQuery(this).removeClass('current');
        });
        jQuery('.editHotelCookies li a').each(function () {
            var url = jQuery(this).attr('href');
            if (url == urlCookies) {
                jQuery(this).parent().addClass('current');
                jQuery('.contentwrapper .subcontent').hide();
                jQuery(url).show();
            }
        });
    }

    /////// SEARCH BOX WITH AUTOCOMPLETE /////

    //var availableTags = ["Phú Quốc","Nha Trang","Cần Thơ", "Đà Nẵng", "Hà Nội", "Hải Phòng", "Hồ Chí Minh", "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cao Bằng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Tĩnh", "Hải Dương", "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái" ];
    //jQuery('.inputtourauto').autocomplete({
    //    source: availableTags
    //});


    ///// SEARCH BOX ON FOCUS /////

    jQuery('#keyword').bind('focusin focusout', function (e) {
        var t = jQuery(this);        
        if (e.type == 'focusin' && t.val() == 'mã đơn hàng, tên khách hàng ...') {
            
            t.val(''); t.css('color','white');
        } else if (e.type == 'focusout' && t.val() == '') {
            t.val('mã đơn hàng, tên khách hàng ...');
            t.css('color', '#4a5b78');            
        }
    });


    ///// NOTIFICATION CLOSE BUTTON /////

    jQuery('.notibar .close').click(function () {
        jQuery(this).parent().fadeOut(function () {
            jQuery(this).remove();
        });
    });


    ///// COLLAPSED/EXPAND LEFT MENU /////
    jQuery('.togglemenu').click(function () {
        if (!jQuery(this).hasClass('togglemenu_collapsed')) {

            //if(jQuery('.iconmenu').hasClass('vernav')) {
            if (jQuery('.vernav').length > 0) {
                if (jQuery('.vernav').hasClass('iconmenu')) {
                    jQuery('body').addClass('withmenucoll');
                    jQuery('.iconmenu').addClass('menucoll');
                } else {
                    jQuery('body').addClass('withmenucoll');
                    jQuery('.vernav').addClass('menucoll').find('ul').hide();
                }
            } else if (jQuery('.vernav2').length > 0) {
                //} else {
                jQuery('body').addClass('withmenucoll2');
                jQuery('.iconmenu').addClass('menucoll2');
            }

            jQuery(this).addClass('togglemenu_collapsed');

            jQuery('.iconmenu > ul > li > a').each(function () {
                var label = jQuery(this).text();
                jQuery('<li><span>' + label + '</span></li>')
					.insertBefore(jQuery(this).parent().find('ul li:first-child'));
            });
        } else {

            //if(jQuery('.iconmenu').hasClass('vernav')) {
            if (jQuery('.vernav').length > 0) {
                if (jQuery('.vernav').hasClass('iconmenu')) {
                    jQuery('body').removeClass('withmenucoll');
                    jQuery('.iconmenu').removeClass('menucoll');
                } else {
                    jQuery('body').removeClass('withmenucoll');
                    jQuery('.vernav').removeClass('menucoll').find('ul').show();
                }
            } else if (jQuery('.vernav2').length > 0) {
                //} else {
                jQuery('body').removeClass('withmenucoll2');
                jQuery('.iconmenu').removeClass('menucoll2');
            }
            jQuery(this).removeClass('togglemenu_collapsed');

            jQuery('.iconmenu ul ul li:first-child').remove();
        }
    });



    ///// RESPONSIVE /////
    if (jQuery(document).width() < 640) {
        jQuery('.togglemenu').addClass('togglemenu_collapsed');
        if (jQuery('.vernav').length > 0) {

            jQuery('.iconmenu').addClass('menucoll');
            jQuery('body').addClass('withmenucoll');
            jQuery('.centercontent').css({ marginLeft: '56px' });
            if (jQuery('.iconmenu').length == 0) {
                jQuery('.togglemenu').removeClass('togglemenu_collapsed');
            } else {
                jQuery('.iconmenu > ul > li > a').each(function () {
                    var label = jQuery(this).text();
                    jQuery('<li><span>' + label + '</span></li>')
						.insertBefore(jQuery(this).parent().find('ul li:first-child'));
                });
            }

        } else {

            jQuery('.iconmenu').addClass('menucoll2');
            jQuery('body').addClass('withmenucoll2');
            jQuery('.centercontent').css({ marginLeft: '36px' });

            jQuery('.iconmenu > ul > li > a').each(function () {
                var label = jQuery(this).text();
                jQuery('<li><span>' + label + '</span></li>')
					.insertBefore(jQuery(this).parent().find('ul li:first-child'));
            });
        }
    }


    jQuery('.searchicon').live('click', function () {
        jQuery('.searchinner').show();
    });

    jQuery('.searchcancel').live('click', function () {
        jQuery('.searchinner').hide();
    });



    ///// ON LOAD WINDOW /////
    function reposSearch() {
        if (jQuery(window).width() < 520) {
            if (jQuery('.searchinner').length == 0) {
                jQuery('.search').wrapInner('<div class="searchinner"></div>');
                jQuery('<a class="searchicon"></a>').insertBefore(jQuery('.searchinner'));
                jQuery('<a class="searchcancel"></a>').insertAfter(jQuery('.searchinner button'));
            }
        } else {
            if (jQuery('.searchinner').length > 0) {
                jQuery('.search form').unwrap();
                jQuery('.searchicon, .searchcancel').remove();
            }
        }
    }
    reposSearch();

    ///// ON RESIZE WINDOW /////
    jQuery(window).resize(function () {

        if (jQuery(window).width() > 640)
            jQuery('.centercontent').removeAttr('style');

        reposSearch();

    });


    ///// CHANGE THEME /////
    jQuery('.changetheme a').click(function () {
        var c = jQuery(this).attr('class');
        if (jQuery('#addonstyle').length == 0) {
            if (c != 'default') {
                jQuery('head').append('<link id="addonstyle" rel="stylesheet" href="css/style.' + c + '.css" type="text/css" />');
                jQuery.cookie("addonstyle", c, { path: '/' });
            }
        } else {
            if (c != 'default') {
                jQuery('#addonstyle').attr('href', 'css/style.' + c + '.css');
                jQuery.cookie("addonstyle", c, { path: '/' });
            } else {
                jQuery('#addonstyle').remove();
                jQuery.cookie("addonstyle", null);
            }
        }
    });

    ///// LOAD ADDON STYLE WHEN IT'S ALREADY SET /////
    if (jQuery.cookie('addonstyle')) {
        var c = jQuery.cookie('addonstyle');
        if (c != '') {
            jQuery('head').append('<link id="addonstyle" rel="stylesheet" href="css/style.' + c + '.css" type="text/css" />');
            jQuery.cookie("addonstyle", c, { path: '/' });
        }
    }

    ///// filemanager.js
    ///// SEARCH FILE ON FOCUS /////
    jQuery('#filekeyword').bind('focusin focusout', function (e) {
        var t = jQuery(this);
        if (e.type == 'focusin' && t.val() == 'Search file here') {
            t.val('');
        } else if (e.type == 'focusout' && t.val() == '') {
            t.val('Search file here');
        }
    });


    ///// LIST OF FILES: CLICK TO SELECT /////
    jQuery('.listfile a').click(function (e) {        
        var parent = jQuery(this).parent();
        if (!e.ctrlKey && !e.cmdKey) {
            jQuery('.listfile li.selected').removeClass('selected');
        }
        if (!parent.hasClass('selected')) {
            parent.addClass('selected');

            if (jQuery('.filemgr_menu a.trash').hasClass('trash_disabled'))
                jQuery('.filemgr_menu a.trash').removeClass('trash_disabled');
            enablePreview(parent);
        } else {
            parent.removeClass('selected');
            disableTrash();
            enablePreview(parent);
        }
        return false;
    });

    ///// ENABLE PREVIEW IF ONE ITEM IS SELECTED /////
    function enablePreview(parent) {        
        var selected = jQuery('.listfile li.selected').length;
        if (selected == 0) {           
            jQuery('.filemgr_menu a.preview').addClass('preview_disabled');
            jQuery('.filemgr_menu a.preview').removeClass('cboxElement');
            jQuery('.filemgr_menu a.preview').removeAttr('href');
        } else if (selected == 1) {            
            var url = jQuery('.listfile li.selected a').attr('href');
            jQuery('.filemgr_menu a.preview').attr('href', url);
            jQuery('.filemgr_menu a.preview').removeClass('preview_disabled');
            if (parent.find('span.img').length > 0) {
                jQuery('.filemgr_menu a.preview').colorbox();
            } else {
                jQuery('.filemgr_menu a.preview')
				.attr('target', '_blank')
				.removeClass('cboxElement');
            }
        } else {            
            jQuery('.filemgr_menu a.preview').addClass('preview_disabled');
            jQuery('.filemgr_menu a.preview').removeClass('cboxElement');
            jQuery('.filemgr_menu a.preview').removeAttr('href');
        }
    }


    ///// IF NO ITEM SELECTED, THEN DISABLE TRASH
    function disableTrash() {
        var r = true;
        jQuery('.listfile li').each(function () {
            if (jQuery(this).hasClass('selected'))
                r = false;
        });
        if (r)
            jQuery('.filemgr_menu a.trash').addClass('trash_disabled');
    }

    ///// UNSELECT ALL IF CLICK OUTSIDE OF THE ITEMS /////
    jQuery(document).click(function (e) {
        if (!jQuery(e.target).is('.listfile li') && !jQuery(e.target).is('.filemgr_menu a')) {
            jQuery('.listfile li.selected').removeClass('selected');
            jQuery('.filemgr_menu a.preview')
			.removeClass('cboxElement')
			.removeAttr('href')
			.addClass('preview_disabled');
            jQuery('.filemgr_menu a.trash').addClass('trash_disabled');
        }
    });

    ///// RETURN FALSE IF COLORBOX IS DISABLED /////
    jQuery('.filemgr_menu a.preview').live('click', function () {
        if (!jQuery(this).hasClass('cboxElement') && !jQuery(this).attr('target'))
            return false;
    });


    ///// TRASH BUTTON /////
    jQuery('.filemgr_menu a.trash').click(function () {        
        if (!jQuery(this).hasClass('trash_disabled')) {
            if (confirm('This will delete selected items. Continue?', 'Delete Selected')) {
                jQuery('.listfile li.selected').each(function () {
                    var id = jQuery(this).attr("id");
                    var img = this;
                    jQuery.ajax({
                        type: 'GET',
                        url: 'DeleteHotelImage.aspx',
                        data: { imageId: id, src: jQuery(this).children('a.image').attr('href') },
                        beforeSend: function () {
                        },
                        success: function (data) {
                            if (jQuery(data).find('.result').text().trim()== 'true') {
                                jQuery.jGrowl('File successfully deleted', { life: 5000, position: 'center', theme: 'yellowgrowl' });
                                jQuery(img).fadeOut('slow', function () {
                                    jQuery(img).remove();
                                });
                            }
                        },
                        error: function () {
                            alert("have some error!!");
                        }
                    });
                });
            }
        }
    });

    ///// SELECT ALL FILES /////
    jQuery('.selectall').click(function () {        
        if (jQuery(this).hasClass('clicked')) {
            jQuery(this).removeClass('clicked');
            jQuery('.listfile li').removeClass('selected');
            jQuery(this).text('Chọn tất cả');
            jQuery('.filemgr_menu a.trash').addClass('trash_disabled');
        } else {
            jQuery(this).addClass('clicked');
            jQuery('.listfile li').addClass('selected');
            jQuery(this).text('Bỏ Chọn Tất Cả');
            jQuery('.filemgr_menu a.trash').removeClass('trash_disabled');
        }
    });
    jQuery('.datepickerclass').datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
});