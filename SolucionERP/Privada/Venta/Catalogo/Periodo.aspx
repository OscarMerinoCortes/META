<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Periodo.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            <td></td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVPeriodo" Width="100%" runat="server"
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
                    <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdPeriodo" runat="server" Enabled="False" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Periodo" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label2" runat="server" Text="Equivalencia" />
                    </td>
                    <td class="SegundaColumna">
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Cantidad" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBCantidad" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="DDEquivalencia" runat="server" Height="22px" Width="128px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label5" runat="server" Text="Estado" />
                    </td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td/>
                    <td colspan="2" >
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width:100%;" runat="server"/>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
