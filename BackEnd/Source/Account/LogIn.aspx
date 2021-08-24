<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BackEnd.Source.Account.LogIn" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login Page | ADMINISTRATION</title>
    <link rel="stylesheet" href="/Styles/style.default.css" type="text/css" />
    <script type="text/javascript" src="/Scripts/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="/Scripts/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="/Scripts/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="/Scripts/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="/Scripts/custom/general.js"></script>
    <script type="text/javascript" src="/Scripts/custom/index.js"></script>
    <!--[if IE 9]>
    <link rel="stylesheet" media="screen" href="css/style.ie9.css"/>
<![endif]-->
    <!--[if IE 8]>
    <link rel="stylesheet" media="screen" href="css/style.ie8.css"/>
<![endif]-->
    <!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
<![endif]-->
</head>
<body class="loginpage">
    <form id="form1" runat="server">
        <div class="loginbox">
            <div class="loginboxinner">

                <div class="logo">
                    <h1><span>Đặt phòng khách sạn</span></h1>
                    <p>Hệ Quản Trị Admin</p>
                </div>
                <!--logo-->

                <br clear="all" />
                <br />

                <asp:Panel runat="server" ID="pnlLoginError" Visible="false">


                <div class="nousername">
                    <div class="loginmsg">Tài khoản hoặc mật khẩu không đúng !</div>
                </div>
                </asp:Panel>                             
                <!--nopassword-->

                <form id="login" action="dashboard.html" method="post">
                    <div class="username">
                        <div class="usernameinner">                            
                            <asp:TextBox runat="server" Id="txtUserName" name="username"/>
                        </div>
                    </div>
                    <div class="password">
                        <div class="passwordinner">
                            <asp:TextBox runat="server" TextMode="Password" name="password" Id="txtPassword"/>                            
                        </div>
                    </div>
                    <asp:Button Text="ĐĂNG NHẬP" runat="server" id="btnSubmit" OnClick="btnSubmit_Click"/>
                    <div class="keep">
                        <asp:CheckBox id="chkKeepMeLogIn" runat="server"/>
                        Duy trì đăng nhập</div>
                </form>
            </div>
            <!--loginboxinner-->
        </div>
        <!--loginbox-->
    </form>
</body>
</html>
