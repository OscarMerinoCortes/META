<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="CalculoPlazo.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
        </table>
    <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVConfiguracionPlazo" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="VRegistro" runat="server">
            <table style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdCalculoPlazo" runat="server" Enabled="False" Width="150"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>&nbsp;</td>
                    <td>Precio Inicio</td>
                    <td>
                        <asp:TextBox ID="TBPrecioInicio" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="PrimeraColumna">Precio Fin </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBPrecioFin" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>&nbsp;</td>
                    <td >Plazo Contado</td>
                    <td>
                        <asp:DropDownList ID="DDIdTipoPlazoContado" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>


                <tr>
                    <td>&nbsp;</td>
                    <td class="PrimeraColumna">Plazo Credito</td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDIdTipoPlazoCredito" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td >Estado
                    </td>
                    <td >
                         <asp:DropDownList ID="DDEstado" runat="server" Width="155px">
                        </asp:DropDownList>                      
                    </td>
                </tr>            
                                
                <tr>
                    <td>&nbsp;</td>
                    <td class="PrimeraColumna">&nbsp;</td>
                    <td class="SegundaColumna">&nbsp;</td>
                </tr>
                                
                <tr>
                    <td />
                    <td colspan="2" >
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" style="width: 100%;" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>


