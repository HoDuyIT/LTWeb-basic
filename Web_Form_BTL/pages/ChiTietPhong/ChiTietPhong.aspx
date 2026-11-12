<%@ Page Title="" Language="C#" MasterPageFile="~/pages/master/Site.Master" AutoEventWireup="true" CodeBehind="ChiTietPhong.aspx.cs" Inherits="Web_Form_BTL.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%= ResolveUrl("~/pages/ChiTietPhong/StyleCTP.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHolder" runat="server">
    <session class="container-CTPhong">

        <section class="view-hotel-CTPhong">
            <session class="view-img">

            </session>

            <session class="view-info">

            </session>
        </section>

        <session class="hotel-info-CTPhong">

        </session>

    </session>

</asp:Content>
