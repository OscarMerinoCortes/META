<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InicioVenta.aspx.vb" Inherits="Privada_Compra_Default" %>
<%@ Register Src="~/Wuc/WUCGraficaVenta.ascx" TagName="wucGraficaVenta" TagPrefix="WUCGV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
         <WUCGV:wucGraficaVenta ID="wucGraficaVenta1" runat="server" />
</asp:Content>

