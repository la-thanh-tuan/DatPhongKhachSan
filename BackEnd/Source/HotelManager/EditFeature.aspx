<%@ Page Title="" Language="C#" MasterPageFile="~/_PopUp.Master" AutoEventWireup="true" CodeBehind="EditFeature.aspx.cs" Inherits="BackEnd.Source.HotelManager.EditFeature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
            <h3>Sửa tiện ích khách sạn</h3>
        </div>
        <br />
    <asp:CheckBoxList ID="chkFeature" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnDataBound="chkFeature_DataBound"></asp:CheckBoxList>
    <asp:Button ID="btnUpdate" runat="server" Text="Luu Lai" OnClick="btnUpdate_Click"/>
</asp:Content>
