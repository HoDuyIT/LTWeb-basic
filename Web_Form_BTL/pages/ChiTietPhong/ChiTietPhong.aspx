<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master/Site.Master" AutoEventWireup="true" CodeBehind="ChiTietPhong.aspx.cs" Inherits="Web_Form_BTL.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%= ResolveUrl("~/pages/ChiTietPhong/StyleCTP.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <session class="container-CTPhong">

        <section class="view-hotel-CTPhong"><!--cho de anh-->
            <div class="khu_vuc_anh">
                <div class="anh_chinh">
                    <asp:Image ID="imgAnhChinh"
                        runat="server"
                        ClientIDMode="Static"
                        AlternateText="Ảnh khách sạn" />
                </div>

                <div class="danh_sach_anh">

                    <asp:ImageButton ID="imgAnhNho1"
                        runat="server"
                        ClientIDMode="Static"
                        CssClass="anh_nho"

                        AlternateText="Ảnh khách sạn"
                        OnClientClick="return doiAnh(this);" />

                    <asp:ImageButton ID="imgAnhNho2"
                        runat="server"
                        ClientIDMode="Static"
                        ImageUrl="~/pages/image/seastar.jpg"
                        CssClass="anh_nho"
                        OnClientClick="return doiAnh(this);" />

                    <asp:ImageButton ID="imgAnhNho3"
                        runat="server"
                        ClientIDMode="Static"
                        ImageUrl="~/pages/image/green.jpg"
                        CssClass="anh_nho"
                        OnClientClick="return doiAnh(this);" />

                </div>

            </div>

            <div class="khu_vuc_duoi">

                <div class="thong_tin_phong">
                    <div class="ten_khach_san">
                        <h2>
                            <asp:Label ID="lblTenKhachSan"
                                runat="server">
                            </asp:Label>
                        </h2>
                    </div>
                    <div class="thong_tin_co_ban">

                        <div class="ten_phong">
                            <asp:Label ID="lblTenLoaiPhong"
                                runat="server">
                            </asp:Label>
                        </div>

                        <div class="gia_phong">

                            <asp:Label ID="lblGiaPhong"
                                runat="server">
                            </asp:Label>

                            <p>/ đêm</p>

                        </div>

                        <div class="dac_diem_phong">

                            <span class="loai_phong">
                                <asp:Label ID="lblLoaiPhong"
                                    runat="server">
                                </asp:Label>
                            </span>

                            <div class="so_nguoi_toi_da">
                                <span>Số Ngươi tối đa: </span>

                                <asp:Label ID="lblSoNguoiToiDa"
                                    runat="server">
                                </asp:Label>

                            </div>

                        </div>

                    </div>

                    <div class="mo_ta_phong">

                        <h3>Mô tả</h3>

                        <asp:Label ID="lblMoTa"
                            runat="server">
                        </asp:Label>

                    </div>

                    <div class="tien_nghi_phong">

                        <h3>Tiện nghi</h3>

                        <div class="danh_sach_tien_nghi">

                            <asp:Label ID="lblTienNghi"
                                runat="server">
                            </asp:Label>

                        </div>

                    </div>

                </div>

            </div>
        </section>



        <div class="khu_vuc_dat_phong">

            <div class="thong_tin_dat_phong">

                <h3>Thông tin đặt phòng</h3>

                
                <div class="form_group">
                    <p>Ngày nhận phòng</p>

                    <asp:TextBox ID="txtNgayNhan"
                        runat="server"
                        TextMode="Date"
                        
                        ClientIDMode="Static">
                    </asp:TextBox>
                </div>

                        
                <div class="form_group">
                    <p>Ngày trả phòng</p>

                    <asp:TextBox ID="txtNgayTra"
                        runat="server"
                        TextMode="Date"
                             
                        ClientIDMode="Static">
                    </asp:TextBox>
                </div>

                <div class="form_group">
                    <p>Số khách</p>

                    <asp:TextBox ID="txtSoKhach"
                        runat="server"
                        TextMode="Number"
                        ClientIDMode="Static">
                    </asp:TextBox>
                </div>

                <div class="form_group">
                    <asp:Button ID="btnDatPhong"
                        runat="server"
                        Text="Đặt phòng ngay"
                        OnClientClick="moModal(); return false;"  
                        CausesValidation="false" />
                </div>

            </div>

        </div>

    </session>


    <div id="modalDatPhong" class="modal-overlay">

        <div class="modal-content">
            <div class="modal-header">
                <h2>Xác nhận đặt phòng</h2>
                <!--heafer-->
                <button type="button"
                    class="btn-close"
                    onclick="dongModal()">
                    &times;
                </button>
            </div>

            <div class="modal-body">

                <h3>Thông tin đặt phòng</h3>

                <div class="modal-info">
                    <span>Khách sạn</span>
                    <strong>
                        <asp:Label ID="lblTenKhachSanModal"
                            runat="server">
                        </asp:Label>
                    </strong>
                </div>

                <div class="modal-info">
                    <span>Loại phòng</span>
                    <strong>
                        <asp:Label ID="lblTenPhongModal"
                            runat="server">
                        </asp:Label>
                    </strong>
                </div>

                <div class="modal-info">
                    <span>Ngày nhận phòng</span>
                    <strong>
                        <asp:Label ID="modalNgayNhan"
                            runat="server"
                             ClientIDMode="Static">--
                        </asp:Label>
                    </strong>
                  
                </div>


                 <asp:HiddenField ID="hdnGiaPhong"
                    runat="server"
                    ClientIDMode="Static" />


                <div class="modal-info">
                    <span>Ngày trả phòng</span>
                    <strong>
                        <asp:Label ID="modalNgayTra"
                            runat="server"
                             ClientIDMode="Static">--
                        </asp:Label>
                    </strong>
                </div>

                <div class="modal-info">
                    <span>Số khách</span>
                    <strong>
                        <asp:Label ID="modalSoKhach"
                            runat="server"
                            ClientIDMode="Static">--
                        </asp:Label>
                    </strong>
                </div>

                <div class="modal-info">
                    <span>Giá mỗi đêm</span>
                    <strong>
                        <asp:Label ID="lblGiaModal"
                            runat="server">
                        </asp:Label>
                    </strong>
                </div>

                <div class="modal-total">
                    <span>Tổng tiền</span>
                    <strong>
                        <asp:Label ID="lblTongModal"
                            runat="server"
                             ClientIDMode="Static">

                        </asp:Label>
                    </strong>
                </div>

            </div>

            <div class="modal-footer">

                <button type="button"
                    class="btn-cancel"
                    onclick="dongModal()">
                    Hủy
                </button>

                <asp:Button ID="btnXacNhanDatPhong"
                    runat="server"
                    Text="Xác nhận đặt phòng"
                    CssClass="btn-confirm"
                    OnClick="btnXacNhanDatPhong_Click" />

            </div>

        </div>

    </div>
    <script src="<%= ResolveUrl("~/pages/ChiTietPhong/ScriptCTPhong.js") %>"></script>
</asp:Content>
