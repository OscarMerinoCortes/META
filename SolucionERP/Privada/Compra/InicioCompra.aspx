<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="InicioCompra.aspx.vb" Inherits="Privada_Compra_Default" %>
<%@ Register Src="~/Wuc/WUCGraficaCompra.ascx" TagName="wucGraficaCompra" TagPrefix="WUCGC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
         <WUCGC:wucGraficaCompra ID="wucGraficaCompra1" runat="server" />
</asp:Content>

