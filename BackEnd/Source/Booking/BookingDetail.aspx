<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="BookingDetail.aspx.cs" Inherits="BackEnd.Source.Booking.BookingDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td.header-order{
            width:30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenttitle2">
        <h3>Xem chi tiết đơn hàng</h3>
    </div>
    <br />
    <table class="grd-stdtable">
        <tr>
            <td class="header-order">Thông tin đơn hàng:</td>
            <td>
                <table class="grd-stdtable">
                    <tr>
                        <td>Mã đơn hàng :
                        </td>
                        <td>
                            <asp:Literal ID="litOrderId" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Khách sạn :
                        </td>
                        <td>
                            <asp:Literal ID="litHotel" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày đến:
                        </td>
                        <td>
                            <asp:Literal ID="litStartDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày đi:
                        </td>
                        <td>
                            <asp:Literal ID="litEndDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Giá tiền :
                        </td>
                        <td>
                            <asp:Literal ID="litPrice" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày đặt :
                        </td>
                        <td>
                            <asp:Literal ID="litOrderDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Trạng thái :
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlState">
                                <asp:ListItem Text="Đơn hàng mới" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Đơn hàng đang xử lí" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Đơn hàng huỷ" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Đơn hàng đã hoàn thành" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnState" runat="server" OnClick="btnState_Click" Text="Cập nhật trạng thái" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td  class="header-order">Danh sách phòng :
            </td>
            <td>
                <asp:DataGrid ID="dtgOrderRoom" runat="server" CssClass="stdtable" AutoGenerateColumns="False" OnItemDataBound="dtgOrderRoom_ItemDataBound">
                    <Columns>
                        <asp:TemplateColumn HeaderText="Loại phòng :">
                            <ItemTemplate>
                                <asp:Literal ID="litRoomType" runat="server" Text='<%# ((DAO.Source.Model.HotelRoomType)Eval("HotelRoomType")).Name %>'></asp:Literal>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateColumn>
                    </Columns>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Số lượng phòng:">
                            <ItemTemplate>
                                <asp:Literal ID="litRoomCount" runat="server" Text='<%# Eval("NumOfRoom") %>'></asp:Literal>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateColumn>
                    </Columns>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Số người :">
                            <ItemTemplate>
                                <asp:Literal ID="litNumOfPeople" runat="server" Text='<%# Eval("NumOfPeople") %>'></asp:Literal>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle Mode="NumericPages" CssClass="pager-grid" />
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td  class="header-order">Thông tin người liên hệ:
            </td>
            <td>
                <table class="grd-stdtable">
                    <tr>
                        <td>Họ và tên :</td>
                        <td>

                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>địa chỉ :</td>
                        <td>

                            <asp:Label ID="lblAdress" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>Số điện thoại :</td>
                        <td>

                            <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>Email :</td>
                        <td>

                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
