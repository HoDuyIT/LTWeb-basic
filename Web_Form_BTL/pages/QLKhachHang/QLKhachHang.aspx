<%@ Page Title="Quản lý khách hàng" Language="C#"
    MasterPageFile="~/pages/master/Site.Master"
    AutoEventWireup="true"
    CodeBehind="QLKhachHang.aspx.cs"
    Inherits="Web_Form_BTL.pages.QLKhachHang.QLKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet"
        href="<%= ResolveUrl("~/pages/QLKhachHang/QLKhachHang.css") %>?v=2" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <main class="ql-kh">
        <h1>Quản lý khách hàng</h1>

        <asp:Panel ID="pnlTimKiem" runat="server"
            CssClass="ql-tim-kiem"
            DefaultButton="btnTimKiem">

            <asp:TextBox ID="txtTimKiem" runat="server"
                placeholder="Tìm kiếm theo tên khách hàng"
                aria-label="Tên khách hàng" />

            <asp:Button ID="btnTimKiem" runat="server"
                Text="Tìm kiếm"
                CssClass="ql-nut"
                CausesValidation="false"
                OnClick="btnTimKiem_Click" />

            <p>Tìm thấy <strong><asp:Literal ID="lblTongSearch" runat="server" /></strong> khách hàng</p>
        </asp:Panel>

        <div class="ql-bang">
            <table>
                <thead>
                    <tr>
                        <th scope="col">Họ và tên</th>
                        <th scope="col">Email</th>
                        <th scope="col">Số điện thoại</th>
                        <th scope="col">Tên đăng nhập</th>
                        <th scope="col">Mật khẩu</th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="rpKhachHang" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#: Eval("HoTen") %></td>
                                <td><%#: Eval("Email") %></td>
                                <td><%#: Eval("SoDienThoai") %></td>
                                <td><%#: Eval("TenDangNhap") %></td>
                                <td><%#: Eval("MatKhau") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:PlaceHolder ID="phKhongCoKetQua" runat="server" Visible="false">
                        <tr>
                            <td colspan="5">Không tìm thấy khách hàng nào.</td>
                        </tr>
                    </asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </main>
</asp:Content>