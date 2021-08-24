<%@ Page Title="" Language="C#" MasterPageFile="~/_FrontEnd.Master" AutoEventWireup="true" CodeBehind="HotelResult.aspx.cs" Inherits="FrontEnd.Source.HotelResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var currentDate = new Date();
            $('#contentMain_TextBoxNgayDen').datepicker({
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 2,
                minDate: 0,
                //dateFormat: 'DD, d MM, yy',
                onClose: function (selectedDate) {
                    $("#contentMain_TextBoxNgayDi").datepicker("option", "minDate", selectedDate);
                    $("#contentMain_TextBoxNgayDi").focus();
                }
            });
            $('#contentMain_TextBoxNgayDi').datepicker({
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 2,
                onClose: function (selectedDate) {
                    $("#contentMain_TextBoxNgayDen").datepicker("option", "maxDate", selectedDate);
                }
            });
            var count = 0;
            $('#contentMain_mnOrderBy ul li').each(function () {
                if (count == 0)
                    $(this).find('a').addClass('thap-nhat');
                else if (count == 1)
                    $(this).find('a').addClass('cao-nhat');
                else if (count == 2)
                    $(this).find('a').addClass('sao');
                count++;
                if ($(this).find('a').hasClass('selected')) {
                    $(this).addClass('active');
                }
            });
            var names = $('#contentMain_hidHotelTag').val().split(",", 1000);
            $('#contentMain_TextBoxHotelName').autocomplete({
                source: names
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <!-- Search form -->
    <div id="tp-search" class="full">
        <div id="tp-search-form" class="left bg-white radius-5 search-form shadow">
            <table width="100%">
                <tr>
                    <td>
                        <asp:HiddenField ID="hidHotelTag" runat="server" />
                        <asp:TextBox ID="TextBoxHotelName" runat="server" CssClass="text-input radius-3" placeholder="Tên khách sạn"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNgayDen" CssClass="date hotel text-input radius-3" runat="server" placeholder="Ngày nhận phòng"></asp:TextBox>
                    </td>
                    <td>

                        <asp:TextBox ID="TextBoxNgayDi" CssClass="date hotel text-input radius-3" runat="server" placeholder="Ngày trả phòng"></asp:TextBox>
                    </td>
                    <td>
                        <label>Thành phố</label>
                        <asp:DropDownList ID="ddlCity" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <label>Sao</label>
                        <asp:DropDownList ID="ddlStar" runat="server">
                            <asp:ListItem Value="0">Tất cả</asp:ListItem>
                            <asp:ListItem Value="1">1 Sao</asp:ListItem>
                            <asp:ListItem Value="2">2 Sao</asp:ListItem>
                            <asp:ListItem Value="3">3 Sao</asp:ListItem>
                            <asp:ListItem Value="4">4 Sao</asp:ListItem>
                            <asp:ListItem Value="5">5 Sao</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSearch" runat="server" CssClass="fs-submit right" Text="" OnClick="ButtonSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- End search form -->
    <!-- Main search -->
    <div class="full cols_2_right margin-top-20">
        <div id="search-result" class="col-1 left">
            <ul id="tab-tour" class="po-tabs left i-tabs">
                <asp:Menu runat="server" ID="mnOrderBy" OnMenuItemClick="mnOrderBy_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="Giá thấp nhất" Value="thap-nhat" Selected="true"></asp:MenuItem>
                        <asp:MenuItem Text="Giá cao nhất" Value="cao-nhat"></asp:MenuItem>
                        <asp:MenuItem Text="Sao" Value="sao"></asp:MenuItem>
                    </Items>
                </asp:Menu>

            </ul>
            <div class="po-tabs-content i-tab-content full bg-white" id="thap-nhat">
                <div class="search-result left">
                    <div class="hotel-data-thap-nhat">
                        <%-- data --%>
                        <asp:ListView runat="server" ID="lvHotel" OnItemDataBound="lvHotel_ItemDataBound" OnPagePropertiesChanging="lvHotel_PagePropertiesChanging">
                            <ItemTemplate>
                                <div class="item">
                                    <div class="t-main left relative" style="width: 175px;">
                                        <a href='<%# "/chi-tiet-khach-san-"+Eval("Id")+"?sId="+Request["sId"] %>'>
                                            <img width="175" height="130" src='<%# FrontEnd.Source.Helper.UrlHelper.BackEndUrl+((DAO.Source.Model.HotelImage)Eval("Avatar")).Url %>' alt="" style="border-radius: 5px; -moz-border-radius: 5px; -webkit-border-radius: 5px;" />
                                        </a>
                                    </div>
                                    <div class="t-detail left" style="width: 305px;">
                                        <h3 class="title" style="font-size: 17px;">
                                            <a href='<%# "/chi-tiet-khach-san-"+Eval("Id")+"?sId="+Request["sId"] %>'><%# Eval("Name") %></a>
                                            <img src='<%# "/Images/Hotel/Star/"+Eval("Star")+".png" %>' alt="" />
                                        </h3>
                                        <p class="address"><%# Eval("Adress") %></p>
                                        <p class="short-desc">
                                            <%# Eval("Description") %>
                                        </p>
                                        <div style="margin: 10px 0 0px 0px; display: block; float: left; clear: both;">
                                            <!--<div class="divFeatured"><b>ăn sáng</b> miễn phí</div>-->
                                            <asp:Literal runat="server" ID="litFeature"></asp:Literal>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>

                                    <div class="t-book right">
                                        <p class="price" style="padding-bottom: 20px; padding-top: 20px;">
                                            <asp:Literal runat="server" ID="litPrice"></asp:Literal>
                                            <sup><u>đ</u></sup></p>
                                        <a class="button radius-5" href='<%# "/chi-tiet-khach-san-"+Eval("Id")+"?sId="+Request["sId"] %>'>Đặt phòng</a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:DataPager ID="dtpHotel" runat="server" PagedControlID="lvHotel" class="paging-v3 left">
                            <Fields>
                                <asp:NumericPagerField ButtonCount="10" NextPageText="&gt;&gt;" NumericButtonCssClass="page" PreviousPageText="&lt;&lt;" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
