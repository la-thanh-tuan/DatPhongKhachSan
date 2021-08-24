<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrHotelDetail.ascx.cs" Inherits="FrontEnd.Source.usrHotelDetail.usrHotelDetail" %>
<div class="desc-item ">
    <h2 class="title" style="font-size: 16px;"><asp:Literal runat="server" ID="litName"></asp:Literal></h2>
    <p class="desc-detail address">
        <asp:Literal runat="server" ID="litAdress"></asp:Literal>
    </p>
    <p class="star-rate">
        <asp:Image runat="server" ID="imgStar" />
    </p>
</div>
            <!--<div class="desc-item" style="display:none;">
                <p class="rating"><b>Rất tốt 8.5</b>  (16 đánh giá) </p>
            </div>-->
<div class="desc-item table-cell padding-0">
    <div class="so-phong left ">Số phòng: <b><asp:Literal runat="server" ID="litNumOfRoom"></asp:Literal></b></div>
    <div class="tien-ich right">
        <asp:Repeater runat="server" ID="rptFeature">
            <ItemTemplate>
                <p><%# Eval("Name") %></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<%--<div class="desc-item last">
    <ul class="uu-dai full">
        {promotion}
    </ul>
</div>--%>
<div class="desc-item last absolute main-book">
    <p class="price"><asp:Literal runat="server" ID="litPrice"></asp:Literal><sup>đ</sup></p>
    <!--<a class="button favorite" href="">favorite </a>-->
    <a class="button book" href="" id="dat-khach-san">Đặt Khách Sạn</a>
</div>
</div>