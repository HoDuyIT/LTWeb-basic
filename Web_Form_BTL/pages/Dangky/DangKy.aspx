<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="DangKy.aspx.cs"
    Inherits="Web_Form_BTL.pages.Dangky.DangKy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký tài khoản</title>

    <link
        rel="stylesheet"
        href="<%= ResolveUrl("~/pages/Dangky/StyleDangKy.css") %>" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="register-container">

            <h2>Đăng ký tài khoản</h2>

            <label for="txtTenDangNhap">Tên đăng nhập</label>
            <asp:TextBox
                ID="txtTenDangNhap"
                runat="server"
                CssClass="register-input"
                placeholder="Nhập tên đăng nhập">
            </asp:TextBox>

            <label for="txtMatKhau">Mật khẩu</label>
            <asp:TextBox
                ID="txtMatKhau"
                runat="server"
                TextMode="Password"
                CssClass="register-input"
                placeholder="Nhập mật khẩu">
            </asp:TextBox>

            <label for="txtNhapLaiMatKhau">Nhập lại mật khẩu</label>
            <asp:TextBox
                ID="txtNhapLaiMatKhau"
                runat="server"
                TextMode="Password"
                CssClass="register-input"
                placeholder="Nhập lại mật khẩu">
            </asp:TextBox>

            <label for="txtHoTen">Họ và tên</label>
            <asp:TextBox
                ID="txtHoTen"
                runat="server"
                CssClass="register-input"
                placeholder="Nhập họ tên">
            </asp:TextBox>

            <label for="txtEmail">Email</label>
            <asp:TextBox
                ID="txtEmail"
                runat="server"
                TextMode="Email"
                CssClass="register-input"
                placeholder="Nhập email">
            </asp:TextBox>

            <label for="txtSoDienThoai">Số điện thoại</label>
            <asp:TextBox
                ID="txtSoDienThoai"
                runat="server"
                CssClass="register-input"
                placeholder="Nhập số điện thoại">
            </asp:TextBox>

            <asp:Button
                ID="btnDangKy"
                runat="server"
                Text="Đăng ký"
                CssClass="btn-register"
                OnClick="btnDangKy_Click" />

            <asp:Label
                ID="lblThongBao"
                runat="server"
                CssClass="message">
            </asp:Label>

            <div class="login-link">
                Đã có tài khoản?
                <asp:HyperLink
                    ID="lnkDangNhap"
                    runat="server"
                    NavigateUrl="~/pages/DangNhap/DangNhap.aspx"
                    Text="Đăng nhập">
                </asp:HyperLink>
            </div>

        </div>
    </form>
</body>
</html>