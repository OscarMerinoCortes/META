<%@ Control Language="vb" AutoEventWireup="false" CodeFile="WucConsultarProveedor2.ascx.vb" Inherits="WucConsultarProveedor2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="//sysetimeta.azurewebsites.net/CSS/gridviewScroll.css" rel="stylesheet" />
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

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>      
        <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td>ID Proveedor</td>
                <td>
                    <asp:TextBox ID="TBIdPersona" runat="server" OnTextChanged="TBIdPersona_TextChanged" Width="150px" AutoPostBack="True" />
                    &nbsp;
                                 <asp:ImageButton ID="ImageButton1" ImageUrl="../Imagenes/zoom.png"
                                     runat="server" Text="Aceptar" OnClick="IBTNBuscarPersona_OnClick" />
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td>Equivalencia</td>
                <td>
                    <asp:TextBox ID="TBEquivalencia" runat="server" AutoPostBack="True" Width="150px" />
                </td>
            </tr>
            <tr>
                <td class="PrimeraColumna">Nombre</td>
                <td class="SegundaColumna">
                    <asp:TextBox ID="TBNombre" runat="server" Enabled="False" AutoPostBack="True" Width="50%" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="HFMPEConsultarPersona" runat="server" />
<asp:ModalPopupExtender ID="MPEConsultarPersona" runat="server" TargetControlID="HFMPEConsultarPersona" CancelControlID="BTNCancelarBusqueda" PopupControlID="PanelConsultarPersona" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
<asp:Panel ID="PanelConsultarPersona" runat="server" CssClass="PanelEmergente" BorderStyle="Solid" BorderColor="#CCD2D7" BorderWidth="0px" Height="550px" Width="1000">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="left: 0px; position: static; top: 0px; width: 100%;">
                <tr>
                    <td colspan="2" style="background-color: #285583; background-image: none; background-repeat: no-repeat; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: normal; height: 25px; text-align: left; vertical-align: middle; width: 1250px;">&nbsp;&nbsp;&nbsp; Consultar Proveedor
                    </td>
                </tr>
                <tr>
                    <td style="color: #8E9BA6; font-size: 14px; padding-left: 15px; text-align: center; vertical-align: middle;" colspan="2">
                        <asp:TextBox ID="TBBIdPersona" runat="server" Width="130px" placeholder="ID"></asp:TextBox>
                        <asp:TextBox ID="TBBEquivalencia" runat="server" Width="130px" placeholder="Equivalencia"></asp:TextBox>
                        <%--<asp:TextBox ID="TBEquivalenciaPrsona" runat="server" Width="150px" placeholder="Equivalencia"></asp:TextBox>--%>
                        <asp:TextBox ID="TBBNombrePersona" runat="server" Width="300px" placeholder="Nombre o apellido"></asp:TextBox>&nbsp;
                                 <asp:Button ID="BTNBuscarPersona" runat="server" OnClick="BTBuscarPersona_Click" Text=" Buscar " />&nbsp;
                                <asp:Button ID="BTNCancelarBusqueda" runat="server" OnClick="IBTNCerrar_OnClick" Text="Cancelar" />
                  
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

