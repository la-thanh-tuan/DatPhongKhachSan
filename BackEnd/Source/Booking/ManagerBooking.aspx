<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="ManagerBooking.aspx.cs" Inherits="BackEnd.Source.Booking.ManagerBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
            <h3>Quản lí đơn hàng</h3>
        </div>
        <br />
   <asp:DataGrid ID="dtgOrder" runat="server" CssClass="stdtable" AutoGenerateColumns="False" OnItemDataBound="dtgOrder_ItemDataBound" OnItemCommand="dtgOrder_ItemCommand" AllowPaging="True" OnPageIndexChanged="dtgOrder_PageIndexChanged">
        <Columns>
            <asp:TemplateColumn  HeaderText="Mã đơn hàng">
                <HeaderStyle />
                <ItemTemplate>
                    <asp:HyperLink runat="server"  ID="lnkOrderId" NavigateUrl='<%# "BookingDetail.aspx?orderId="+Eval("Id") %>' Text='<%# Eval("Id") %>' ></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Ngày đến">
                <ItemTemplate>
                    <asp:TextBox ID="txtStartDate" runat="server" Text='<%# ((DateTime)Eval("StartDate")).ToString("dd/MM/yyyy") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Ngày đi">
                <HeaderStyle />
                <ItemTemplate>
                    <asp:TextBox ID="txtEndDate" runat="server" Text='<%#((DateTime)Eval("EndDate")).ToString("dd/MM/yyyy")  %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:Label ID="lblState" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="">
                <HeaderStyle />
                <ItemTemplate>
                    <a href='/Source/Booking/BookingDetail.aspx?orderId=<%#Eval("Id") %>' style="text-decoration: underline;"><b style="font-weight: bold;">Xem</b></a>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <HeaderStyle/>
                <ItemTemplate>
                    <asp:ImageButton ID="imbtDelete" runat="server" CommandName="delete" ImageUrl="~/Images/Event/delete.png" CommandArgument='<%# Eval("Id") %>' OnClientClick="javascript : return confirm('Bạn có muốn xóa đơn hàng này ?')" />
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <PagerStyle Mode="NumericPages" CssClass="pager-grid" />
    </asp:DataGrid>
</asp:Content>
