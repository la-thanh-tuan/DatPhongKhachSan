<%@ Page Title="" Language="C#" MasterPageFile="~/_FrontEnd.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FrontEnd.Source.Home" %>

<%@ Register Src="~/Source/usrHome/usrformSearchHotel.ascx" TagPrefix="uc1" TagName="usrformSearchHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <!-- Form search -->
    <div id="access" class="relative full">
        <div id="form-search" class="absolute left">
            <ul class="tab-search i-tabs">                
                <li class="active"><a class="fs-hotel" data="fs-hotel" href="">Khách sạn</a></li>
            </ul>
            <uc1:usrformSearchHotel runat="server" id="usrformSearchHotel" />
        </div>
    </div>
    <!-- Form search -->
</asp:Content>
