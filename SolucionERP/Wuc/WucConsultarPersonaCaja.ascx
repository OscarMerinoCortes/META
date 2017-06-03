﻿<%--<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarPersonaCaja.ascx.vb" Inherits="WucConsultarPersonaCaja" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<link href="//sysetimeta.azurewebsites.net/CSS/StyleSheet.css" rel="stylesheet" />

<link href="//sysetimeta.azurewebsites.net/CSS/gridviewScroll.css" rel="stylesheet" />
<script src="//sysetimeta.azurewebsites.net/Scripts/jquery-1.10.2.min.js"></script>
<script src="//sysetimeta.azurewebsites.net/Scripts/jquery-ui.1.9.1.js"></script>
<script src="//sysetimeta.azurewebsites.net/Scripts/MicrosoftAjax.js"></script>
<script src="//sysetimeta.azurewebsites.net/Scripts/gridviewScroll.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll();
    });

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
    function endReq(sender, args) {
        gridviewScroll();
    }

    function gridviewScroll() {
        try {
            $('#<%=GVConsultaPersona.ClientID%>').gridviewScroll({
                width: 990,
                height: 450,
                startHorizontal: 0,
                barhovercolor: "#285583",
                barcolor: "#285583",
                freezesize: 2
            });
        }
        catch (err) {
            alert(err.message)
        }
    }
</script>
<asp:HiddenField ID="HFMPEConsultarClientesCaja" runat="server" />
<asp:ModalPopupExtender ID="MPEConsultarClientesCaja" runat="server" TargetControlID="HFMPEConsultarClientesCaja" CancelControlID="BTNCancelarBusqueda" PopupControlID="PanelClientesCaja" BackgroundCssClass="modalBackground">
                 </asp:ModalPopupExtender>
<asp:Panel ID="PanelClientesCaja" runat="server" CssClass="PanelEmergente" Height="70%" Width="70%" BorderColor="#CCD2D7" BorderStyle="Solid" BorderWidth="0px">
    <table style="width: 100%;" border="0" class="PanelEmergenteTitulo">
        <tr>
            <td style="background-image: none; background-repeat: repeat-x; height: 30px; vertical-align: middle; text-align: left; color: #FFFFFF; font-size: 16px; font-family: Arial, Helvetica, sans-serif; font-weight: normal; background-color: #3A4F63;">&nbsp;&nbsp;&nbsp; Clientes</td>
        </tr>
    </table>
    <table style="width: 100%; height: 100%; position:static; top:0px;left:0px">
        <tr>
            <td style="color: #8E9BA6; font-size: 14px; padding-left: 15px; text-align: center; vertical-align: middle;">
                <asp:TextBox ID="TBBIdPersona" runat="server" Width="130px" placeholder="ID"></asp:TextBox>
                <asp:TextBox ID="TBBEquivalencia" runat="server" Width="130px" placeholder="Equivalencia"></asp:TextBox>
                <asp:TextBox ID="TBEquivalenciaPrsona" runat="server" Width="150px" placeholder="Equivalencia"></asp:TextBox>
                <asp:TextBox ID="TBBNombrePersona" runat="server" Width="300px" placeholder="Nombre o apellido"></asp:TextBox>&nbsp;
                <asp:Button ID="BTNBuscarPersona" runat="server" OnClick="BTBuscarPersona_Click" Text=" Buscar " />&nbsp;
                <asp:Button ID="BTNCancelarBusqueda" runat="server" OnClick="IBTNCerrar_OnClick" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td style="text-align: left" valign="middle">

                <asp:Label ID="LabelRegistrosBuscarPersona" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td align="center" valign="middle">
                <asp:GridView ID="GVConsultaPersona" runat="server" AllowPaging="false" AutoGenerateColumns="false" CaptionAlign="Top" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                    <HeaderStyle CssClass="GridviewScrollHeader" />
                    <RowStyle CssClass="GridviewScrollItem" />
                    <PagerStyle CssClass="GridviewScrollPager" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">&nbsp;</td>
        </tr>
        <tr>
            <%--<td></td>
            <td align="right" valign="middle" style="position: absolute; bottom: 20px; right: 20px;">
                <asp:Button ID="BTCancelarBuscarDigitalizacion" runat="server" Text="Regresar" />
            </td>
        </tr>
    </table>
</asp:Panel>--%>
<%@ Control Language="vb" AutoEventWireup="false" CodeFile="wucConsultarPersonaCaja.ascx.vb" Inherits="WucConsultarPersonaCaja" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="//sysetimeta.azurewebsites.net/CSS/StyleSheet.css" rel="stylesheet" />

<link href="//sysetimeta.azurewebsites.net/CSS/gridviewScroll.css" rel="stylesheet" />
<script src="//sysetimeta.azurewebsites.net/Scripts/jquery-1.10.2.min.js"></script>
<script src="//sysetimeta.azurewebsites.net/Scripts/jquery-ui.1.9.1.js"></script>
<script src="//sysetimeta.azurewebsites.net/Scripts/MicrosoftAjax.js"></script>
<script src="//sysetimeta.azurewebsites.net/Scripts/gridviewScroll.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll();
    });

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
    function endReq(sender, args) {
        gridviewScroll();
    }

    function gridviewScroll() {
        try {
            $('#<%=GVConsultaPersona.ClientID%>').gridviewScroll({
                width: 990,
                height: 450,
                startHorizontal: 0,
                barhovercolor: "#285583",
                barcolor: "#285583",
                freezesize: 2
            });
        }
        catch (err) {
            alert(err.message)
        }
    }
</script>

<asp:Panel ID="PanelConsultarPersona" runat="server" CssClass="PanelEmergente" BorderStyle="Solid" BorderColor="#CCD2D7" BorderWidth="0px" Height="550px" Width="1000">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="left: 0px; position: static; top: 0px; width: 100%;">
                <tr>
                    <td colspan="2" style="background-color: #285583; background-image: none; background-repeat: no-repeat; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: normal; height: 25px; text-align: left; vertical-align: middle; width: 1250px;">&nbsp;&nbsp;&nbsp; Consultar Persona
                    </td>
                </tr>
                <tr>
                    <td style="color: #8E9BA6; font-size: 14px; padding-left: 15px; text-align: center; vertical-align: middle;" colspan="2">
                        <asp:TextBox ID="TBIdPersona" runat="server" Width="130px" placeholder="ID"></asp:TextBox>
                        <asp:TextBox ID="TBEquivalencia" runat="server" Width="130px" placeholder="Equivalencia"></asp:TextBox>
                        <%--<asp:TextBox ID="TBEquivalenciaPrsona" runat="server" Width="150px" placeholder="Equivalencia"></asp:TextBox>--%>
                        <asp:TextBox ID="TBNombrePersona" runat="server" Width="300px" placeholder="Nombre o apellido"></asp:TextBox>&nbsp;
                                 <asp:Button ID="BTBuscarPersona" runat="server" OnClick="BTBuscarPersona_Click" Text=" Buscar " />&nbsp;
                                <asp:Button ID="BTCancelarBusqueda" runat="server" OnClick="IBCerrar_OnClick" Text="Cancelar" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelRegistrosBuscarPersona" runat="server" Text=""></asp:Label>
                    </td>
                    <td />
                </tr>
                <tr style="text-align: center;">
                    <td colspan="2">
                        <asp:GridView ID="GVConsultaPersona" Style="margin: 0 auto;" runat="server"
                            GridLines="None" AllowPaging="false" AutoGenerateColumns="false" CaptionAlign="Top"
                            HorizontalAlign="Center" PagerStyle-CssClass="pgr">

                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="color: #000000; font-size: 14px">&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>