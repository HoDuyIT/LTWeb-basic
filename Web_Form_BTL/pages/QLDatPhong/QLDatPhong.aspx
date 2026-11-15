<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master/Site.Master" AutoEventWireup="true" CodeBehind="QLDatPhong.aspx.cs" Inherits="Web_Form_BTL.pages.QLDatPhong.QLDatPhong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet"
        href="<%= ResolveUrl("~/pages/QLDatPhong/QLDatPhong.css") %>" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <main class="ql-dat-phong">
        <h1>Quản lý đặt phòng</h1>

        <div class="qldp-bo-loc">
            <asp:Button ID="btnDaXacNhan" runat="server"
                Text="Đã xác nhận"
                CommandArgument="DaXacNhan"
                CssClass="qldp-nut"
                CausesValidation="false"
                OnCommand="LocTrangThai_Command" />

            <asp:Button ID="btnChuaXacNhan" runat="server"
                Text="Chưa xác nhận"
                CommandArgument="ChoXacNhan"
                CssClass="qldp-nut"
                CausesValidation="false"
                OnCommand="LocTrangThai_Command" />

            <asp:Button ID="btnDaHuy" runat="server"
                Text="Đã hủy"
                CommandArgument="DaHuy"
                CssClass="qldp-nut"
                CausesValidation="false"
                OnCommand="LocTrangThai_Command" />
        </div>

        <section class="qldp-lich-su">
            <h2>Lịch sử đặt phòng</h2>

            <asp:Label ID="lblThongBao" runat="server"
                CssClass="qldp-thong-bao" role="status" />

            <div class="qldp-khung-bang">
                <table>
                    <thead>
                        <tr>
                            <th scope="col">Mã đơn</th>
                            <th scope="col">Loại phòng</th>
                            <th scope="col">Ngày nhận</th>
                            <th scope="col">Ngày trả</th>
                            <th scope="col">Số đêm</th>
                            <th scope="col">Số khách</th>
                            <th scope="col">Tổng tiền</th>
                            <th scope="col">Trạng thái</th>
                            <th scope="col">Thao tác</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rpDatPhong" runat="server"
                            OnItemCommand="rpDatPhong_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>#<%#: Eval("MaDatPhong") %></td>

                                    <td>
                                        <div class="qldp-phong">
                                            <asp:PlaceHolder runat="server"
                                                Visible='<%# !string.IsNullOrWhiteSpace(Convert.ToString(Eval("HinhAnh"))) %>'>
                                                <img class="qldp-anh"
                                                    src='<%#: ResolveUrl("~/pages/image/" + Uri.EscapeDataString(Convert.ToString(Eval("HinhAnh")))) %>'
                                                    alt=""
                                                    loading="lazy" />
                                            </asp:PlaceHolder>

                                            <strong><%#: Eval("TenPhong") %></strong>
                                        </div>
                                    </td>

                                    <td><%#: Eval("NgayNhan", "{0:dd/MM/yyyy}") %></td>
                                    <td><%#: Eval("NgayTra", "{0:dd/MM/yyyy}") %></td>
                                    <td><%#: Eval("SoDem") %></td>
                                    <td><%#: Eval("SoKhach") %></td>
                                    <td><%#: Eval("TongThanhToan", "{0:N0}") %> đ</td>
                                    <td><%#: (Convert.ToString(Eval("TrangThaiDat"))) %></td>

                                    <td>
                                        <asp:Button ID="btnXacNhan" runat="server"
                                            Text="Xác nhận"
                                            CssClass="qldp-nut qldp-xac-nhan"
                                            CommandName="XacNhan"
                                            CommandArgument='<%# Eval("MaDatPhong") %>'
                                            Visible='<%# Convert.ToString(Eval("TrangThaiDat")) == "ChoXacNhan" %>'
                                            CausesValidation="false" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                        <asp:PlaceHolder ID="phDanhSachTrong" runat="server" Visible="false">
                            <tr>
                                <td colspan="9" class="qldp-trong">Không có đơn đặt phòng trong danh sách này.
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                    </tbody>
                </table>
            </div>
        </section>
    </main>
</asp:Content>
