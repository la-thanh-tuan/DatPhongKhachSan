<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="AddNewHotel.aspx.cs" Inherits="BackEnd.Source.HotelManager.AddNewHotel" %>

<%@ Register Src="~/Source/HotelManager/usr/usrHotelBasic.ascx" TagPrefix="uc1" TagName="usrHotelBasic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
            <h3>Thêm mới khách sạn</h3>
        </div>
        <br />
    <uc1:usrHotelBasic runat="server" id="usrHotelBasic" />
</asp:Content>
