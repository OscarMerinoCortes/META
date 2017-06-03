<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCDatosAuditoria.ascx.vb" Inherits="Wuc_WUCDatosAuditoria" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="wucUsuarioResumen.ascx" TagName="wucUsuarioResumen" TagPrefix="uc1" %>

<table style="wIdth: 100%; border-collapse: collapse;">
    <tr>
        <td class="PrimeraColumna">Usuario Creaci&oacute;n</td>
        <td class="SegundaColumna">
            <asp:LinkButton ID="LBIdUsuarioCreacion" runat="server" />
            <asp:HIddenField ID="HFIdUsuarioCreacion" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Fecha de Creaci&oacute;n</td>
        <td>
            <asp:Label ID="LAFechaCreacion" runat="server" Text="" />
        </td>
    </tr>
    <tr>
        <td class="PrimeraColumna">Usuario Actualizaci&oacute;n</td>
        <td class="SegundaColumna">
            <asp:LinkButton ID="LBIdUsuarioActualizacion" runat="server" />
            <asp:HIddenField ID="HFIdUsuarioActualizacion" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Fecha de Actualizaci&oacute;n</td>
        <td>
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
