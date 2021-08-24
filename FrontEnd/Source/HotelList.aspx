<%@ Page Title="" Language="C#" MasterPageFile="~/_FrontEnd.Master" AutoEventWireup="true" CodeBehind="HotelList.aspx.cs" Inherits="FrontEnd.Source.HotelList" %>

<%@ Register Src="~/Source/usrHotelList/usrHotelList.ascx" TagPrefix="uc1" TagName="usrHotelList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <div class="full cols_2_right margin-top-20">
        <div id="search-result" class="col-1 left">
            <uc1:usrHotelList runat="server" ID="usrHotelList" />
        </div>
        <!-- Sidebar style -->
        <div class="col-1 right">
            
        </div>
    </div>
</asp:Content>
