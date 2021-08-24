<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrHotelList.ascx.cs" Inherits="FrontEnd.Source.usrHotelList.usrHotelList" %>
<div class="po-tabs-content i-tab-content full bg-white" id="thap-nhat">
    <div class="search-result left">
        <asp:ListView ID="lvHotelList" runat="server" OnPagePropertiesChanging="lvHotelList_PagePropertiesChanging" OnItemDataBound="lvHotelList_ItemDataBound">
            <ItemTemplate>
                <div class="item">
                    <div class="t-main left relative" style="width: 185px;">
                        <a href='<%# "/chi-tiet-khach-san-"+Eval("Id")%>'>
                            <img width="185" height="130" src='<%# FrontEnd.Source.Helper.UrlHelper.BackEndUrl+((DAO.Source.Model.HotelImage)Eval("Avatar")).Url %>' alt="" style="border-radius: 5px; -moz-border-radius: 5px; -webkit-border-radius: 5px;" />
                        </a>
                    </div>
                    <div class="t-detail left" style="width: 305px;">
                        <h3 class="title" style="font-size: 17px;">
                            <a href='<%# "/chi-tiet-khach-san-"+Eval("Id") %>'>
                                <%# Eval("Name")%>
                            </a>
                            <img src="/Images/Hotel/Star/b-star-<%#Eval("Star") %>.png" alt="" />
                        </h3>
                        <p class="address"><%#  Eval("Adress")%></p>
                        <p class="short-desc">
                            <%#  Eval("Description")%>
                        </p>
                        <div style="margin: 10px 0 0px 0px; display: block; float: left; clear: both;">
                            <asp:Literal runat="server" ID="litFeature"></asp:Literal>
                            <div class="clear"></div>
                        </div>
                    </div>
                    <div class="t-book right">
                        <%--<%#GetDanhGia(Eval("HotelId")) %>--%>
                        <p class="price" style="padding-bottom: 20px; padding-top: 20px;">
                            <asp:Literal ID="LiteralPrice" runat="server"></asp:Literal>
                        </p>
                        <a class="button radius-5" href='<%# "/chi-tiet-khach-san-"+Eval("Id") %>'>Đặt phòng</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:DataPager ID="dtpHotelList" runat="server" PagedControlID="lvHotelList" class="paging-v3 left">
            <Fields>
                <asp:NumericPagerField ButtonCount="10" NextPageText="&gt;&gt;" NumericButtonCssClass="page" PreviousPageText="&lt;&lt;" />
            </Fields>
        </asp:DataPager>
    </div>
</div>