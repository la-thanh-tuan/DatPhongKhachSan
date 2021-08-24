<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrHotelImage.ascx.cs" Inherits="FrontEnd.Source.usrHotelDetail.usrHotelImage" %>
<div class="main-img col-1 left">
    <div id="imageview">
        <asp:Image runat="server" ID="imgHotelImage" Width="722" Height="406" />
    </div>
    <div id="img-thumbnails" class="full">
        <div id="prev-image" class="control-button left"></div>
        <div id="thumbnails">
            <asp:Repeater runat="server" ID="rptImage">
                <ItemTemplate>
                    <a href='<%# FrontEnd.Source.Helper.UrlHelper.BackEndUrl+Eval("Url") %>'>
                        <img src='<%# FrontEnd.Source.Helper.UrlHelper.BackEndUrl+Eval("Url") %>' width='96px' height='60px'/>
                    </a>"
                </ItemTemplate>
            </asp:Repeater>
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