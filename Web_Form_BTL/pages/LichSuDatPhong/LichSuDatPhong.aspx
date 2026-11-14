<%@ Page Title="Lịch sử đặt phòng"
    Language="C#"
    MasterPageFile="~/pages/master/Site.Master"
    AutoEventWireup="true"
    CodeBehind="LichSuDatPhong.aspx.cs"
    Inherits="Web_Form_BTL.pages.LichSuDatPhong.LichSuDatHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link
        rel="stylesheet"
        href="<%= ResolveUrl("~/pages/LichSuDatPhong/LsuP.css") %>" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <main class="booking-history">
        <h1 class="booking-history__title">
            Lịch sử đặt phòng
        </h1>

        <asp:Repeater ID="rpLichSuDatPhong" runat="server">
            <ItemTemplate>
                <article class="booking-card">
                    <img
                        class="booking-card__image"
                        src='<%# ResolveUrl("~/pages/image/" + Eval("HinhAnh")) %>'
                        alt="Ảnh khách sạn" />

                    <div class="booking-card__content">
                        <h2 class="booking-card__name">
                            <%# Eval("TenPhong") %>
                        </h2>

                        <div class="booking-card__badges">
                            <span class="status-badge">
                                <%# Eval("TrangThaiDat") %>
                            </span>
                        </div>

                        <div class="booking-card__details">
                            <div class="booking-detail">
                                <span class="detail-icon">▣</span>
                                <div>
                                    <span class="detail-label">Nhận phòng</span>
                                    <strong>
                                        <%# Eval("NgayNhan", "{0:yyyy-MM-dd}") %>
                                    </strong>
                                </div>
                            </div>

                            <div class="booking-detail">
                                <span class="detail-icon">▣</span>
                                <div>
                                    <span class="detail-label">Trả phòng</span>
                                    <strong>
                                        <%# Eval("NgayTra", "{0:yyyy-MM-dd}") %>
                                    </strong>
                                </div>
                            </div>

                            <div class="booking-detail">
                                <span class="detail-icon">◷</span>
                                <div>
                                    <span class="detail-label">Số đêm</span>
                                    <strong>
                                        <%# Eval("SoDem") %> đêm
                                    </strong>
                                </div>
                            </div>

                            <div class="booking-detail">
                                <span class="detail-icon">♙</span>
                                <div>
                                    <span class="detail-label">Số khách</span>
                                    <strong>
                                        <%# Eval("SoKhach") %> người
                                    </strong>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="booking-card__total">
                        <strong>
                            <%# Eval("TongThanhToan", "{0:N0}") %> đ
                        </strong>
                        <span>Tổng thanh toán</span>
                    </div>
                </article>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Panel
            ID="pnlKhongCoDatPhong"
            runat="server"
            CssClass="empty-state"
            Visible="false">
            Bạn chưa có lịch sử đặt phòng.
        </asp:Panel>
    </main>
</asp:Content>