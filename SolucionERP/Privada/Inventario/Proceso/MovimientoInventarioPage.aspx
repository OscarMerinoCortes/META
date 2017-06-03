<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MovimientoInventarioPage.aspx.vb" Inherits="Privada_Inventario_Proceso_MovimientoInventarioPage" %>
<%@ Register src="~/Wuc/WucGraficaMovimientoInventario.ascx" tagname="wucGraficaMovimientoInventario" tagprefix="WUCGMI" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <WUCGMI:wucGraficaMovimientoInventario ID="wucGraficaPersona1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SecondContent" runat="server">
</asp:Content>
