<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Web_Form_BTL.moDels.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="<%=ResolveUrl("~/pages/DangNhap/StyleDangNhap.css")%>";
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">

            <h2>Đăng nhập</h2>

            <label>Tên đăng nhập</label>
            <asp:TextBox ID="txtTenDangNhap" runat="server"
                CssClass="login-input"
                placeholder="Nhập tên đăng nhập">
            </asp:TextBox>

            <label>Mật khẩu</label>
            <asp:TextBox ID="txtMatKhau" runat="server"
                TextMode="Password"
                CssClass="login-input"
                placeholder="Nhập mật khẩu">
            </asp:TextBox>

            Bạn chưa có tài khoản: <asp:HyperLink ID="LinkDangKy" runat="server"
                NavigateUrl="~/pages/Dangky/DangKy.aspx" Text="Dang Ky" ></asp:HyperLink>

            <asp:Button ID="btnDangNhap" runat="server"
                Text="Đăng nhập"
                CssClass="btn-login"
                OnClick="btnDangNhap_Click" />

            <asp:Label ID="lblThongBao" runat="server"
                CssClass="error-message">
            </asp:Label>

        </div>
    </form>
</body>
</html>
