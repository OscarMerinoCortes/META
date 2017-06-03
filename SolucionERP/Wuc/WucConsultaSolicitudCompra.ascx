<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultaSolicitudCompra.ascx.vb" Inherits="WucConsultaSolicitudCompra" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../CSS/StyleSheet.css" rel="stylesheet" />
<style type="text/css">
    .scrolling-table-container {
        height  : 300px;
        width   : 600px;
        overflow: auto;
    }
</style>
<asp:HiddenField ID="HFMPEConsultarCliente" runat="server" />
<asp:ModalPopupExtender ID="MPEConsultarCliente" runat="server" TargetControlID="HFMPEConsultarCliente" CancelControlID="BTNCerrar" PopupControlID="PanelConsultarPersona" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
<asp:Panel ID="PanelConsultarPersona" runat="server" CssClass="PanelEmergente" BorderStyle="Solid" BorderColor="#CCD2D7" BorderWidth="0px">
    <table style="width: 100%; height: 100%; position:static; top:0px;left:0px">
        <tr>
            <td colspan="2" style="background-image: none; background-repeat: no-repeat; height: 25px; vertical-align: middle; text-align: left; color: #FFFFFF; font-size: 16px; font-family: Arial, Helvetica, sans-serif;font-weight: normal; background-color: #285583; width: 1250px;">
                &nbsp;&nbsp;&nbsp; Consultar Solicitudes de Compra &nbsp;&nbsp; 
                <asp:Button ID="BTNCerrar" runat="server" BorderStyle="None" Text="X" UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; color: #8E9BA6; font-size: 14px;vertical-align: middle;text-align:center;" colspan="2" >
                <asp:TextBox ID="TBIdPersona" runat="server" Width="130px" placeholder="ID"></asp:TextBox>
                <%--<asp:TextBox ID="TBEquivalenciaPrsona" runat="server" Width="150px" placeholder="Equivalencia"></asp:TextBox>--%>
                <asp:TextBox ID="TBNombrePersona" runat="server" Width="300px" placeholder="Nombre"></asp:TextBox>
                <asp:Button ID="BTBuscarPersona" runat="server" OnClick="BTBuscarPersona_Click" style="height: 26px" Text="Buscar" UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <td class="style1" style="padding-left: 15px; color: #8E9BA6; font-size: 14px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1" style="padding-left: 15px; color: #000; font-size: 14px">
                <asp:Label ID="LabelRegistrosBuscarPersona" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
         </tr>
         <tr>
            <td class="style1">
            </td>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
         </tr>
         <tr>
            <td colspan="2"align="center" valign="middle">
                <div class="scrolling-table-container" style="margin: 0 auto;">
                    <asp:GridView ID="GVConsultarPersona" runat="server" AllowPaging="false" Width="100%" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" CssClass="GridComun"  HorizontalAlign="Center"  style="margin: 0 auto;">
                    </asp:GridView>
                </div>
            </td>
         </tr>
         <tr>
         <td colspan="2" style="color: #000000; font-size: 14px">
            &nbsp;</td>
         </tr>
    </table>
</asp:Panel>