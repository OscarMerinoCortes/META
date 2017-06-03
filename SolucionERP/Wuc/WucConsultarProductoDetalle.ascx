<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarProductoDetalle.ascx.vb" Inherits="WucConsultarProductoDetalle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../CSS/StyleSheet.css" rel="stylesheet" />

<asp:HiddenField ID="HFMPEConsultarProductoDetalle" runat="server" />
<asp:ModalPopupExtender ID="MPEConsultarProductoDetalle" runat="server" TargetControlID="HFMPEConsultarProductoDetalle" PopupControlID="PanelConsultarProductoDetalle" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
<asp:Panel ID="PanelConsultarProductoDetalle" runat="server" CssClass="PanelEmergente" BorderStyle="Solid" BorderColor="#CCD2D7" BorderWidth="0px" Height="550px" Width="1000px">
    <table style="left: 0px; position: static; top: 0px; width: 100%;">

        <tr>
            <td class="auto-style2" style="color: #FFFFFF; font-size: 16px; text-align: left; vertical-align: middle; background-color: #285583; background-image: none; background-repeat: no-repeat; font-family: Arial, Helvetica, sans-serif; font-weight: normal;">&nbsp;&nbsp;&nbsp; Detalle del Producto &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>

        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: left; vertical-align: middle;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="LBIDProducto" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: left; vertical-align: middle;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID Corto: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LBIdProductoCorto" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: left; vertical-align: middle;">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descripcion:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LBDescripcion" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: left; vertical-align: middle;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Clasificacion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="LBClasificacion" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: left; vertical-align: middle;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SubClasificacion:&nbsp;&nbsp;
                        <asp:Label ID="LBSubClasificacion" runat="server" Text="Label"></asp:Label>
                &nbsp;</td>
        </tr>


        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: right; vertical-align: middle;">
                <asp:Button ID="BTNSalir" runat="server" style="margin-left: 12px" Text="Salir" Width="103px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9" style="color: #000000; font-size: 14px; padding-left: 15px; text-align: right; vertical-align: middle;">
                &nbsp;</td>
        </tr>
        <tr style="text-align: center;">
            <td class="auto-style10">
                <asp:GridView ID="GVConsultarProductoDetalle" runat="server" AllowPaging="false" AutoGenerateColumns="false" CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;" Width="995px">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
