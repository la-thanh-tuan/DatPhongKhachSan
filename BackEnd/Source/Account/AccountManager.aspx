<%@ Page Title="" Language="C#" MasterPageFile="~/_BackEnd.Master" AutoEventWireup="true" CodeBehind="AccountManager.aspx.cs" Inherits="BackEnd.Source.Account.AccountManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataGrid ID="dtgAccount" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnItemCommand="dtgAccount_ItemCommand" OnItemDataBound="dtgAccount_ItemDataBound" OnPageIndexChanged="dtgAccount_PageIndexChanged" ShowFooter="True">
        <Columns>
            <asp:TemplateColumn HeaderText="UserName :">
                <FooterTemplate>
                    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Literal ID="litUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Name :">
                <FooterTemplate>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Adress :">
                <FooterTemplate>
                    <asp:TextBox ID="tbUserAdress" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbAdress" runat="server" Text='<%# Eval("Adress") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Phone :">
                <FooterTemplate>
                    <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Email :">
                <FooterTemplate>
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Ngay Sinh :">
                <FooterTemplate>
                    <asp:TextBox ID="tbBirthDay" runat="server" CssClass="datepickerclass"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbBirthDay" runat="server" CssClass="datepickerclass" Text='<%#((DateTime)Eval("BirthDay")).ToString("dd/MM/yyyy") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Gioi tinh :">
                <FooterTemplate>
                    <asp:DropDownList ID="ddlSex" runat="server">
                        <asp:ListItem Value="1">Nam</asp:ListItem>
                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlSex" runat="server">
                        <asp:ListItem Value="1">Nam</asp:ListItem>
                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Skype :">
                <FooterTemplate>
                    <asp:TextBox ID="tbSkype" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbSkype" runat="server" Text='<%# Eval("Skype") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Chuc Vu :">
                <FooterTemplate>
                    <asp:TextBox ID="tbChucVu" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="tbChucVu" runat="server" Text='<%# Eval("ChucVu") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Active :">
                <FooterTemplate>
                    <asp:CheckBox ID="chkActive" runat="server"></asp:CheckBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Eval("Active") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Phân quyền :">
                <FooterTemplate>
                    <asp:DropDownList ID="ddlPermission" runat="server">
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlPermission" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <FooterTemplate>
                    <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/Images/Event/add.png" CommandName="add" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="imgSave" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="save" ImageUrl="~/Images/Event/edit.png" />
                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="delete" ImageUrl="~/Images/Event/delete.png" OnClientClick="javascript:return confirm('bạn có chắc chắn muốn xóa ?')"/>
                </ItemTemplate>
            </asp:TemplateColumn>
            
        </Columns>
        <PagerStyle Mode="NumericPages" CssClass="pager-grid" Wrap="True" />
    </asp:DataGrid>
</asp:Content>
