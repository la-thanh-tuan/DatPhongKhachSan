<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="ManagerHotel.aspx.cs" Inherits="BackEnd.Source.HotelManager.ManagerHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td {
            text-align: center; /* center checkbox horizontally */
            vertical-align: middle; /* center checkbox vertically */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenFieldHotelNames" runat="server" />
    <div id="contentwrapper" class="contentwrapper">
        <div class="contenttitle2">
            <h3>Quản lý khách sạn</h3>
        </div>
        <br />
        <label style="margin-right: 20px;">Tên khách sạn </label>
        <asp:TextBox ID="TextBoxHotelName" runat="server" CssClass="smallinput" Width="300"></asp:TextBox>
        <script type="text/javascript">
            jQuery(function () {
                var names = jQuery('#ContentPlaceHolder1_HiddenFieldHotelNames').val().split(",", 100);
                jQuery('#ContentPlaceHolder1_TextBoxHotelName').autocomplete({
                    source: names
                });
            });
        </script>
        <label style="margin-left: 20px; margin-right: 20px;">Star</label>
        <asp:DropDownList ID="DropDownListStar" runat="server" Style="min-width: 10%;">
            <asp:ListItem Value="0">Tất cả Sao</asp:ListItem>
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonSearch" runat="server" Text="Tìm kiếm" CssClass="submit radius2" OnClick="ButtonSearch_Click" />
        <br />
        <br />
        <asp:Button Text="Thêm mới Khách sạn" runat="server" CssClass="submit radius2" ID="btnAddNewHotel" OnClick="btnAddNewHotel_Click" />
        <br />
        <br />
        <asp:DataGrid ID="DataGridHotel" runat="server" CssClass="stdtable" AllowPaging="True" AutoGenerateColumns="False" OnItemCommand="DataGridHotel_ItemCommand" OnItemDataBound="DataGridHotel_ItemDataBound" OnPageIndexChanged="DataGridHotel_PageIndexChanged">
            <Columns>
                <asp:TemplateColumn>
                    <HeaderStyle Width="100" />
                    <ItemTemplate>
                        <asp:HyperLink runat="server"  ID="lnkHotelAvata" Width="100px" Height="100px" NavigateUrl='<%# "EditHotel.aspx?hotelId="+Eval("Id") %>' ImageHeight="100" ImageWidth="100" ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Tên Khách sạn">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxHotelName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Star">
                    <HeaderStyle Width="50" />
                    <ItemTemplate>
                        <asp:Image ID="ImageStar" runat="server" ImageUrl='<%# "/Images/Hotel/Star/"+Eval("Star")+".png" %>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Địa chỉ">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# Eval("Adress") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="">
                    <HeaderStyle Width="30" />
                    <ItemTemplate>
                        <a href="EditHotel.aspx?hotelId=<%#Eval("Id") %>" style="text-decoration: underline;"><b style="font-weight: bold;">Edit</b></a>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderStyle Width="50" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonSave" runat="server" CommandName="save" ImageUrl="~/Images/Event/edit.png" CommandArgument='<%# Eval("Id") %>' />
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="delete" ImageUrl="~/Images/Event/delete.png" CommandArgument='<%# Eval("Id") %>' OnClientClick="javascript : return confirm('Bạn có muốn xóa khach san nay ?')" />
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle Mode="NumericPages" CssClass="pager-grid" />
        </asp:DataGrid>
    </div>
</asp:Content>
