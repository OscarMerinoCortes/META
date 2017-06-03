<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WucConsultarProducto2.ascx.vb" Inherits="WucConsultarProducto2" %>
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
            $('#<%=GVConsultarProducto.ClientID%>').gridviewScroll({
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
                <td>ID</td>
                <td>
                    <asp:TextBox ID="TBIdProducto" runat="server" AutoPostBack="True" OnTextChanged="TBIdProducto_TextChanged" Width="150" />
                    &nbsp;
                                 <asp:ImageButton ID="ImageButton1" ImageUrl="../Imagenes/zoom.png"
                                     runat="server" Text="Aceptar" OnClick="IBTNBuscarProducto_OnClick" />
                </td>
            </tr>
            <tr>
                <td class="PrimeraColumna">ID Corto</td>
                <td class="SegundaColumna">
                    <asp:TextBox ID="TBIdProductoCorto" runat="server" AutoPostBack="True" Width="150" />
                </td>
            </tr>
            <tr>
                <td>Producto</td>
                <td>
                    <asp:TextBox ID="TBDescripcion" runat="server" Enabled="False" AutoPostBack="True" Width="50%" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="HFMPEConsultarProducto" runat="server" />
<asp:ModalPopupExtender ID="MPEConsultarProducto" runat="server" TargetControlID="HFMPEConsultarProducto" CancelControlID="BTNCancelarBusqueda" PopupControlID="PanelConsultarProducto" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
<asp:Panel ID="PanelConsultarProducto" runat="server" CssClass="PanelEmergente" BorderStyle="Solid" BorderColor="#CCD2D7" BorderWidth="0px" Height="550px" Width="1000px">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="left: 0px; position: static; top: 0px; width: 100%;">
                <tr>
                    <td colspan="2" style="background-color: #285583; background-image: none; background-repeat: no-repeat; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: normal; height: 25px; text-align: left; vertical-align: middle; width: 1250px;">&nbsp;&nbsp;&nbsp; Consultar Producto &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                               &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="color: #8E9BA6; font-size: 14px; padding-left: 15px; text-align: center; vertical-align: middle;" colspan="2">
                        <asp:TextBox ID="TBBIdProducto" runat="server" Width="130px" placeholder="ID"></asp:TextBox>
                        <asp:TextBox ID="TBBIdProductoCorto" runat="server" Width="130px" placeholder="ID Corto"></asp:TextBox>
                        <%--<asp:TextBox ID="TBEquivalenciaPrsona" runat="server" Width="150px" placeholder="Equivalencia"></asp:TextBox>--%>
                        <asp:TextBox ID="TBBNombreProducto" runat="server" Width="300px" placeholder="Descripcion"></asp:TextBox>&nbsp;
                                <asp:Button ID="BTNBuscarProducto" runat="server" OnClick="BTBuscarProducto_Click" Text=" Buscar " />&nbsp;
                                <asp:Button ID="BTNCancelarBusqueda" runat="server" OnClick="BTNCancelarBusqueda_Click" Text="Cancelar" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelRegistrosBuscarProducto" runat="server" Text=""></asp:Label>
                    </td>
                    <td />
                </tr>
                <tr style="text-align: center;">
                    <td colspan="2">
                        <asp:GridView ID="GVConsultarProducto" Style="margin: 0 auto;" runat="server"
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
