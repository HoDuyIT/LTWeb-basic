<%@ Page Title="Tài khoản của tôi"
    Language="C#"
    MasterPageFile="~/pages/master/Site.Master"
    AutoEventWireup="true"
    CodeBehind="TaiKhoan.aspx.cs"
    Inherits="Web_Form_BTL.pages.DangNhap.TaiKhoan.TaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .account-page {
            width: min(1050px, calc(100% - 40px));
            margin: 42px auto;
            color: #111827;
            font-family: Arial, sans-serif;
        }

        .account-title {
            margin: 0 0 28px;
            font-size: 36px;
            font-weight: 600;
        }

        .account-card {
            padding: 32px;
            background: #fff;
            border-radius: 14px;
            box-shadow: 0 3px 10px rgb(15 23 42 / 12%);
        }

        .account-header {
            display: flex;
            align-items: center;
            gap: 18px;
            margin-bottom: 28px;
        }

        .account-avatar {
            display: grid;
            width: 78px;
            height: 78px;
            place-items: center;
            color: #2160f5;
            background: #e4efff;
            border-radius: 50%;
            font-size: 38px;
        }

        .account-header h2 {
            margin: 0 0 6px;
            font-size: 27px;
        }

        .account-header p {
            margin: 0;
            color: #64748b;
            font-size: 16px;
        }

        .account-field {
            margin-top: 20px;
        }

        .account-field label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
        }

        .account-value,
        .account-input {
            display: block;
            box-sizing: border-box;
            width: 100%;
            padding: 14px 18px;
            border: 1px solid #cbd5e1;
            border-radius: 11px;
            background: #fff;
            color: #111827;
            font-size: 17px;
        }

        .account-actions {
            display: flex;
            gap: 12px;
            margin-top: 24px;
        }

        .account-button {
            padding: 12px 20px;
            border: 0;
            border-radius: 9px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }

        .button-edit,
        .button-save {
            background: #2160f5;
        }

        .button-cancel {
            background: #64748b;
        }

        .account-message {
            display: block;
            margin-top: 16px;
            color: #087443;
        }

        @media (max-width: 600px) {
            .account-page {
                width: calc(100% - 28px);
                margin: 24px auto;
            }

            .account-card {
                padding: 22px 18px;
            }

            .account-title {
                font-size: 29px;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <main class="account-page">
        <h1 class="account-title">Thông tin cá nhân</h1>

        <section class="account-card">
            <div class="account-header">
                <div class="account-avatar" aria-hidden="true">♙</div>

                <div>
                    <h2>
                        <asp:Label ID="lblHoTenHeader" runat="server"></asp:Label>
                    </h2>
                    <p>
                        <asp:Label ID="lblEmailHeader" runat="server"></asp:Label>
                    </p>
                </div>
            </div>

            <%-- Chế độ xem thông tin --%>
            <asp:Panel ID="pnlThongTin" runat="server">
                <div class="account-field">
                    <label>Họ và tên</label>
                    <asp:Label
                        ID="lblHoTen"
                        runat="server"
                        CssClass="account-value">
                    </asp:Label>
                </div>

                <div class="account-field">
                    <label>Số điện thoại</label>
                    <asp:Label
                        ID="lblSoDienThoai"
                        runat="server"
                        CssClass="account-value">
                    </asp:Label>
                </div>

                <div class="account-field">
                    <label>Email</label>
                    <asp:Label
                        ID="lblEmail"
                        runat="server"
                        CssClass="account-value">
                    </asp:Label>
                </div>

                <div class="account-field">
                    <label>Vai trò</label>
                    <asp:Label
                        ID="lblVaiTro"
                        runat="server"
                        CssClass="account-value">
                    </asp:Label>
                </div>

                <div class="account-field">
                    <label>Tên đăng nhập</label>
                    <asp:Label
                        ID="lblTenDangNhap"
                        runat="server"
                        CssClass="account-value">
                    </asp:Label>
                </div>

                <div class="account-actions">
                    <asp:Button
                        ID="btnSua"
                        runat="server"
                        Text="Chỉnh sửa"
                        CssClass="account-button button-edit"
                        OnClick="btnSua_Click" />
                </div>
            </asp:Panel>

            <%-- Chế độ chỉnh sửa: chỉ cho sửa họ tên, số điện thoại và email --%>
            <asp:Panel ID="pnlChinhSua" runat="server" Visible="false">
                <div class="account-field">
                    <label for="txtHoTen">Họ và tên</label>
                    <asp:TextBox
                        ID="txtHoTen"
                        runat="server"
                        CssClass="account-input">
                    </asp:TextBox>
                </div>

                <div class="account-field">
                    <label for="txtSoDienThoai">Số điện thoại</label>
                    <asp:TextBox
                        ID="txtSoDienThoai"
                        runat="server"
                        CssClass="account-input">
                    </asp:TextBox>
                </div>

                <div class="account-field">
                    <label for="txtEmail">Email</label>
                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        TextMode="Email"
                        CssClass="account-input">
                    </asp:TextBox>
                </div>

                <div class="account-actions">
                    <asp:Button
                        ID="btnLuu"
                        runat="server"
                        Text="Lưu thay đổi"
                        CssClass="account-button button-save"
                        OnClick="btnLuu_Click" />

                    <asp:Button
                        ID="btnHuy"
                        runat="server"
                        Text="Hủy"
                        CssClass="account-button button-cancel"
                        CausesValidation="false"
                        OnClick="btnHuy_Click" />
                </div>
            </asp:Panel>

            <asp:Label
                ID="lblThongBao"
                runat="server"
                CssClass="account-message">
            </asp:Label>
        </section>
    </main>
</asp:Content>