<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master/Site.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="Web_Form_BTL.pages.TrangChu.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainHolder" runat="server">
    <section class="hero_TrangChu">
        <div class="text_hero">
            <h1>Khám phá phòng lý tưởng của bạn</h1>
            <h3>Trải nghiệm dịch vụ đẳng cấp</h3>
        </div>
        <div class="search_TrangChu">
            <div class="NgayNhan">
                <p>Ngày nhận phòng</p>
                <asp:TextBox ID="txtNgayNhan" runat="server" TextMode="Date" CssClass="dateInput"></asp:TextBox>
            </div>
            <div class="NgayTra">
                <p>Ngày trả phòng</p>
                <asp:TextBox ID="txtNgayTra" runat="server" TextMode="Date" CssClass="dateInput"></asp:TextBox>
            </div>
            <div class="LoaiPhong">
                <p>Loại phòng</p>
                <asp:TextBox ID="txtLoaiPhong" runat="server" CssClass="InputLoaiPhong"></asp:TextBox>
            </div>
            <div class="SoNguoi">
                <p>Số người</p>
                <asp:DropDownList ID="ddlSoNguoi" runat="server" CssClass="search-input">
                    <asp:ListItem Value="0">Tất cả</asp:ListItem>
                    <asp:ListItem Value="1">1 người</asp:ListItem>
                    <asp:ListItem Value="2">2 người</asp:ListItem>
                    <asp:ListItem Value="3">3 người</asp:ListItem>
                    <asp:ListItem Value="4">4 người</asp:ListItem>
                    <asp:ListItem Value="5">5 người</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="btn_search">
                <asp:Button ID="btnTimKiem" Text="Tìm kiếm" runat="server" CssClass="btn-search" OnClick="btnTimKiem_Click"></asp:Button>
            </div>
        </div>
    </section>


    <section class="container">
        <p class="txtSearchTong">Kết quả tìm được là: <asp:Label ID="lblTongSearch" runat="server"></asp:Label></p>
        <div class="grid-card">
            <asp:Repeater ID="rpKhachSan" runat="server">
                <ItemTemplate>
                    <div class="hotel-card">
                        <div class="hotel-image">
                            <img src='<%# ResolveUrl("~/pages/image/" + Eval("HinhAnh")) %>'
                                 alt="Ảnh khách sạn" />
                        </div>

                        <!-- Thong tin khach san -->
                        <div class="hotel-info">
                            <h3> <%# Eval("Ten") %></h3>
                            <div class="hotel-stars">
                                <%# new string('*', Convert.ToInt32(Eval("SoSao"))) %>
                            </div>
                            <div class="rating">
                                <b>9.4</b>
                                <span>Tuyệt vời</span>
                            </div>
                            <p class="hotel-location">|!| <%# Eval("DiaChi") %></p>

                            <p class="hotel-description"><%# Eval("MoTa") %></p>

                            <div class="hotel-price">
                                <span>Giá mỗi đêm từ</span>
                                <strong>
                                    <%# Eval("GiaTu", "{0:N0}") %>đ
                                </strong>
                            </div>

                            <a href="../ChiTietPhong/ChiTietPhong.aspx" class="btn-detail">Xem chi tiết</a>

                        </div>

                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>

</asp:Content>
