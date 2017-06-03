<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Subclasificacion.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png"  ValidationGroup="Guardar"/>
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
                <tr>
                    <td style="width: 10%;">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                     <td>
                         ID</td>
                    <td>
                        <asp:TextBox ID="TBIdSubclasificacionConsultar" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Descripcion</td>
                    <td>
                        <asp:TextBox ID="TBDescripcionSubclasificacionConsultar" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td>Clasificacion</td>
                    <td>
                        <asp:DropDownList ID="DDClasificacionConsultar" runat="server" Height="22px" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstadoConsultar" runat="server" Height="22px" Width="155px" />
                    </td>
                </tr>
                <tr>
                     <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="2">
                        <asp:GridView ID="GVSubclasificacion" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" BorderColor="#385c81" CaptionAlign="Top" CssClass="GridComun" HorizontalAlign="Left" PagerStyle-CssClass="pgr" Width="100%">
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
                        <asp:TextBox ID="TBIdSubclasificacion" runat="server" Enabled="False" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Subclasificacion" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150px" />
                        <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TBDescripcion"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Descripcion es Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label2" runat="server" Text="Ganancia" />
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBGanancia" runat="server" Width="150px" Height="22px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVGanancia" runat="server" ControlToValidate="TBGanancia"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Descripcion es Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEGanancia" runat="server" TargetControlID="RFVGanancia"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVGanancia" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBGanancia"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEGanancia2" runat="server" TargetControlID="REVGanancia"></asp:ValidatorCalloutExtender>
                        
                        
                         <asp:CheckBox ID="CBGanancia" runat="server" />
                        <asp:Label ID="LBLPorcentaje" runat="server" Text="% Porcentaje"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Clasificacion" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DDClasificacion" runat="server" Height="22px" Width="155px" />
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
