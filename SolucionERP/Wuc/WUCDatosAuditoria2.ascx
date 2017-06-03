<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCDatosAuditoria2.ascx.vb" Inherits="Wuc_WUCDatosAuditoria2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="wucUsuarioResumen.ascx" TagName="wucUsuarioResumen" TagPrefix="uc1" %>

<link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
<table style="wIdth: 100%; border-collapse: collapse;">
    <tr>
        <td>Usuario Creaci&oacute;n</td>
        <td>
            <asp:LinkButton ID="LBIdUsuarioCreacion" runat="server" />
            <asp:HIddenField ID="HFIdUsuarioCreacion" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="PrimeraColumna">Fecha de Creaci&oacute;n</td>
        <td class="SegundaColumna">
            <asp:Label ID="LAFechaCreacion" runat="server" Text="" />
        </td>
    </tr>
    <tr>
        <td>Usuario Actualizaci&oacute;n</td>
        <td>
            <asp:LinkButton ID="LBIdUsuarioActualizacion" runat="server" />
            <asp:HIddenField ID="HFIdUsuarioActualizacion" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="PrimeraColumna">Fecha de Actualizaci&oacute;n</td>
        <td class="SegundaColumna">
            <asp:Label ID="LAFechaActualizacion" runat="server" Text="" />
        </td>
    </tr>
</table>
<asp:ModalPopupExtender ID="MPEUsuarioResumen" runat="server" TargetControlID="HFIdUsuarioActualizacion"
    PopupControlID="PanelUsuarioResumen" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="PanelUsuarioResumen" runat="server"
    CssClass="PanelEmergente" WIdth="400px">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:wucUsuarioResumen ID="wucUsuarioResumen1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
