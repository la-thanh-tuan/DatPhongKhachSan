<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usrformSearchHotel.ascx.cs" Inherits="FrontEnd.Source.usrHome.usrformSearchHotel" %>
<%--<asp:HiddenField ID="HiddenFieldTagHotel" runat="server" />--%>
<script type="text/javascript">
    $(document).ready(function () {
        var names = $('#contentMain_usrformSearchHotel_hidHotel').val().split(",", 1000);
        $('#contentMain_usrformSearchHotel_TextBoxHotelName').autocomplete({
            source: names
        });
        var currentDate = new Date();
        $('#contentMain_usrformSearchHotel_TextBoxCheckIn').datepicker({
            changeMonth: true,
            changeYear: true,
            numberOfMonths: 2,
            minDate: 0,
            //dateFormat: 'DD, d MM, yy',
            onClose: function (selectedDate) {
                $("#contentMain_usrformSearchHotel_TextBoxCheckOut").datepicker("option", "minDate", selectedDate);
                $("#contentMain_usrformSearchHotel_TextBoxCheckOut").focus();
            }
        });
        $('#contentMain_usrformSearchHotel_TextBoxCheckOut').datepicker({
            changeMonth: true,
            changeYear: true,
            numberOfMonths: 2,
            onClose: function (selectedDate) {
                $("#contentMain_usrformSearchHotel_TextBoxCheckIn").datepicker("option", "maxDate", selectedDate);
            }
        });
    });
</script>
<style type="text/css">
    .sub-category {
        color: #888;
        padding-left: 10px;
    }
</style>
<div class="bg-content i-tab-content" id="fs-hotel">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <label>Tên khách sạn :</label>
                <asp:TextBox ID="TextBoxHotelName" placeholder="Tên khách sạn bạn cần tìm" runat="server" CssClass="text-input radius-3 txtboxHotelNameSearchForm" Width="300px"></asp:TextBox>
                <asp:HiddenField ID="hidHotel" runat="server" />
            </td>
        </tr>

        <tr>
            <td>
                <label>Ngày Đến</label>
                <asp:TextBox ID="TextBoxCheckIn" runat="server" CssClass="date hotel text-input radius-3"></asp:TextBox>
            </td>
            <td>
                <label>Ngày Đi</label>
                <asp:TextBox ID="TextBoxCheckOut" runat="server" CssClass="date hotel text-input radius-3"></asp:TextBox>
            </td>
        </tr>
        <tr>
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
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="LiteralSearchError" runat="server" Visible="false"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="ButtonSearch" runat="server" Text="" CssClass="fs-submit" OnClick="ButtonSearch_Click" />
            </td>
        </tr>
    </table>
</div>
