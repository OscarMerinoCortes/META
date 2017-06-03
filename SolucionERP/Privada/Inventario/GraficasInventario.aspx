<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="GraficasInventario.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WucGraficaMovimientoInventario.ascx" TagName="wucGraficaInventario" TagPrefix="WUCGI" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <WUCGI:wucGraficaInventario ID="wucGraficaPersona1" runat="server" />
 </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    </asp:Content>




