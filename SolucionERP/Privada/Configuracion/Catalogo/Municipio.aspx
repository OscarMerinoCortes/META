<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Municipio.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="//sysetimeta.azurewebsites.net/CSS/StyleSheet.css" type="text/css" />
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
            <table style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                            <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">Entidad Federativa</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDEntidadFederativa1" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td style="width: 100%;" colspan="5">
                        <asp:GridView ID="GVMunicipio" Width="100%" runat="server"
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
                    <td style="padding-right: 10px;"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdMunicipio" runat="server" Enabled="False" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Descripcion
                    </td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TBDescripcion"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Municipio es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Entidad Federativa
                    </td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDEntidadFederativa" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Pais
                    </td>
                    <td>
                        <asp:DropDownList ID="DDPais" runat="server" AutoPostBack="true" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Equivalencia
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBEquivalencia" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Estado
                    </td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td />
                    <td colspan="2">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" style="width: 100%;" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
