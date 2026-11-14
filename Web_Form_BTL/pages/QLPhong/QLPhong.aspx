<%@ Page Title="Quản lý phòng" Language="C#"
    MasterPageFile="~/pages/master/Site.Master"
    AutoEventWireup="true"
    CodeBehind="QLPhong.aspx.cs"
    Inherits="Web_Form_BTL.pages.QLPhong.QLPhong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%= ResolveUrl("~/pages/QLPhong/QLPhong.css") %>" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <main class="ql-phong">
        <div class="ql-tieu-de">
            <h1>Quản lý phòng</h1>

            <asp:Button ID="btnThemPhong" runat="server"
                Text="+ Thêm loại phòng"
                CssClass="ql-nut"
                CausesValidation="false"
                OnClick="btnThemPhong_Click" />
        </div>

        <asp:Label ID="lblThongBao" runat="server" CssClass="ql-thong-bao" />

        <asp:Panel ID="pnlThemPhong" runat="server"
            CssClass="ql-form" Visible="false" DefaultButton="btnLuuPhong">

            <h2>Thêm loại phòng</h2>

            <div class="ql-cac-o">
                <div>
                    <asp:Label runat="server" AssociatedControlID="ddlKhachSan"
                        Text="Khách sạn" />
                    <asp:DropDownList ID="ddlKhachSan" runat="server" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtTenLoai"
                        Text="Tên loại phòng" />
                    <asp:TextBox ID="txtTenLoai" runat="server"
                        placeholder="Ví dụ: Phòng đôi" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtSoNguoi"
                        Text="Số người tối đa" />
                    <asp:TextBox ID="txtSoNguoi" runat="server" inputmode="numeric" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtGia"
                        Text="Giá mỗi đêm (đồng)" />
                    <asp:TextBox ID="txtGia" runat="server" inputmode="numeric"
                        placeholder="Ví dụ: 450000" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtSoLuong"
                        Text="Số lượng phòng" />
                    <asp:TextBox ID="txtSoLuong" runat="server" inputmode="numeric" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtTienNghi"
                        Text="Tiện nghi (tùy chọn)" />
                    <asp:TextBox ID="txtTienNghi" runat="server"
                        placeholder="Ví dụ: Wi-Fi, điều hòa" />
                </div>
            </div>

            <asp:Label ID="lblLoiThemPhong" runat="server" CssClass="ql-loi" />

            <div class="ql-thao-tac">
                <asp:Button ID="btnLuuPhong" runat="server"
                    Text="Lưu loại phòng"
                    CssClass="ql-nut"
                    OnClick="btnLuuPhong_Click" />

                <asp:Button ID="btnHuy" runat="server"
                    Text="Hủy"
                    CssClass="ql-nut ql-nut-phu"
                    CausesValidation="false"
                    OnClick="btnHuy_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlTimKiem" runat="server"
            CssClass="ql-tim-kiem" DefaultButton="btnTimKiem">

            <asp:TextBox ID="txtTimKiem" runat="server"
                placeholder="Tìm theo tên loại phòng..."
                aria-label="Tên loại phòng" />

            <asp:Button ID="btnTimKiem" runat="server"
                Text="Tìm kiếm"
                CssClass="ql-nut"
                CausesValidation="false"
                OnClick="btnTimKiem_Click" />

            <p>
                Tìm thấy
                <strong><asp:Literal ID="lblTongSearch" runat="server" /></strong>
                loại phòng
            </p>
        </asp:Panel>

        <div class="ql-bang">
            <table>
                <thead>
                    <tr>
                        <th scope="col">Loại phòng</th>
                        <th scope="col">Khách sạn</th>
                        <th scope="col">Sức chứa</th>
                        <th scope="col">Giá mỗi đêm</th>
                        <th scope="col">Số lượng</th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="rpLoaiPhong" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="ql-loai-phong">
                                        <asp:PlaceHolder runat="server"
                                            Visible='<%# !string.IsNullOrWhiteSpace(Convert.ToString(Eval("HinhAnh"))) %>'>
                                            <img class="ql-anh-phong"
                                                 src='<%#: ResolveUrl("~/pages/image/" + Eval("HinhAnh")) %>'
                                                 alt='<%#: Eval("TenKhachSan") %>'
                                                 loading="lazy" />
                                        </asp:PlaceHolder>

                                        <strong><%#: Eval("TenLoai") %></strong>
                                    </div>
                                </td>

                                <td>
                                    <%#: Eval("TenKhachSan") %>
                                    <small><%#: Eval("DiaChi") %></small>
                                </td>

                                <td><%#: Eval("SoNguoiToiDa") %> người</td>
                                <td><%#: Eval("GiaMoiDem", "{0:N0}") %> đ</td>
                                <td><%#: Eval("SoLuongPhong") %> phòng</td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:PlaceHolder ID="phKhongCoKetQua" runat="server" Visible="false">
                        <tr>
                            <td colspan="5">Không tìm thấy loại phòng nào.</td>
                        </tr>
                    </asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </main>
</asp:Content>