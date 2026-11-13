<%@ Page Title="Quản lý khách sạn" Language="C#"
    MasterPageFile="~/pages/master/Site.Master"
    AutoEventWireup="true"
    CodeBehind="QLKhachSan.aspx.cs"
    Inherits="Web_Form_BTL.pages.QLKhachSan.QLKhachSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%= ResolveUrl("~/pages/QLPhong/QLPhong.css") %>" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <main class="ql-phong">
        <div class="ql-tieu-de">
            <h1>Quản lý khách sạn</h1>
        </div>

        <asp:Label ID="lblThongBao" runat="server" CssClass="ql-thong-bao" />
        <asp:Label ID="lblLoiDanhSach" runat="server" CssClass="ql-loi" />

        <asp:Panel ID="pnlThemKhachSan" runat="server"
            CssClass="ql-form" DefaultButton="btnThemKhachSan">

            <h2>
                <asp:Literal ID="litTieuDeForm" runat="server" Text="Thêm khách sạn mới" />
            </h2>

            <div class="ql-cac-o">
                <div>
                    <asp:Label runat="server" AssociatedControlID="txtTen" Text="Tên khách sạn" />
                    <asp:TextBox ID="txtTen" runat="server" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtDiaChi" Text="Địa chỉ" />
                    <asp:TextBox ID="txtDiaChi" runat="server" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtThanhPho" Text="Thành phố" />
                    <asp:TextBox ID="txtThanhPho" runat="server" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="ddlSoSao" Text="Số sao" />
                    <asp:DropDownList ID="ddlSoSao" runat="server">
                        <asp:ListItem Value="">-- Chọn số sao --</asp:ListItem>
                        <asp:ListItem Value="1">1 sao</asp:ListItem>
                        <asp:ListItem Value="2">2 sao</asp:ListItem>
                        <asp:ListItem Value="3">3 sao</asp:ListItem>
                        <asp:ListItem Value="4">4 sao</asp:ListItem>
                        <asp:ListItem Value="5">5 sao</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtHinhAnh"
                        Text="Tên file ảnh trong pages/image (tùy chọn)" />
                    <asp:TextBox ID="txtHinhAnh" runat="server" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="txtMoTa"
                        Text="Mô tả (tùy chọn)" />
                    <asp:TextBox ID="txtMoTa" runat="server" />
                </div>

                <div>
                    <asp:Label runat="server" AssociatedControlID="ddlTrangThai" Text="Trạng thái" />
                    <asp:DropDownList ID="ddlTrangThai" runat="server">
                        <asp:ListItem Value="HoatDong">Hoạt động</asp:ListItem>
                        <asp:ListItem Value="NgungHoatDong">Ngừng hoạt động</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <asp:Label ID="lblLoi" runat="server" CssClass="ql-loi" />

            <div class="ql-thao-tac">
                <asp:Button ID="btnThemKhachSan" runat="server"
                    Text="Thêm khách sạn" CssClass="ql-nut"
                    OnClick="btnThemKhachSan_Click" />

                <asp:Button ID="btnHuySua" runat="server"
                    Text="Hủy sửa" CssClass="ql-nut ql-nut-phu"
                    Visible="false" CausesValidation="false"
                    OnClick="btnHuySua_Click" />
            </div>
        </asp:Panel>

        <div class="ql-tim-kiem">
            <h2>Danh sách khách sạn</h2>
        </div>

        <asp:Panel ID="pnlTimKiem" runat="server"
            CssClass="ql-tim-kiem" DefaultButton="btnTimKiem">

            <asp:TextBox ID="txtTimKiem" runat="server"
                placeholder="Tìm theo tên khách sạn..."
                aria-label="Tên khách sạn cần tìm" />

            <asp:Button ID="btnTimKiem" runat="server"
                Text="Tìm kiếm" CssClass="ql-nut"
                CausesValidation="false" OnClick="btnTimKiem_Click" />

            <p>
                Tìm thấy <strong><asp:Literal ID="litSoKetQua" runat="server" /></strong> khách sạn
            </p>
        </asp:Panel>

        <div class="ql-bang">
            <table>
                <thead>
                    <tr>
                        <th scope="col">Ảnh</th>
                        <th scope="col">Tên khách sạn</th>
                        <th scope="col">Địa chỉ</th>
                        <th scope="col">Thành phố</th>
                        <th scope="col">Số sao</th>
                        <th scope="col">Thao tác</th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="rpKhachSan" runat="server"
                        OnItemCommand="rpKhachSan_ItemCommand">

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:PlaceHolder runat="server"
                                        Visible='<%# !string.IsNullOrWhiteSpace(Convert.ToString(Eval("HinhAnh"))) %>'>
                                        <img class="ql-anh-phong"
                                             src='<%#: ResolveUrl("~/pages/image/" + Uri.EscapeDataString(Convert.ToString(Eval("HinhAnh")))) %>'
                                             alt='<%#: Eval("Ten") %>'
                                             loading="lazy" />
                                    </asp:PlaceHolder>
                                </td>

                                <td><strong><%#: Eval("Ten") %></strong></td>
                                <td><%#: Eval("DiaChi") %></td>
                                <td><%#: Eval("ThanhPho") %></td>
                                <td><%#: Convert.ToInt32(Eval("SoSao")) > 0 ? Eval("SoSao", "{0} sao") : "Chưa xếp hạng" %></td>

                                <td>
                                    <div class="ql-thao-tac">
                                        <asp:Button runat="server" Text="Sửa"
                                            CssClass="ql-nut ql-nut-phu"
                                            CommandName="SuaKhachSan"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CausesValidation="false" />

                                        <asp:Button runat="server" Text="Xóa"
                                            CssClass="ql-nut ql-nut-phu"
                                            CommandName="XoaKhachSan"
                                            CommandArgument='<%# Eval("Id") %>'
                                            CausesValidation="false"
                                            OnClientClick="if (!confirm('Bạn có chắc muốn xóa khách sạn này?')) return false;" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:PlaceHolder ID="phDanhSachTrong" runat="server" Visible="false">
                        <tr>
                            <td colspan="6">Không tìm thấy khách sạn nào.</td>
                        </tr>
                    </asp:PlaceHolder>
                </tbody>
            </table>
        </div>
    </main>
</asp:Content>