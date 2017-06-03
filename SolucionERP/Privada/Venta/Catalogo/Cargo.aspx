<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Cargo.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />--%>
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
                        <asp:GridView ID="GVCargo" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="VRegistro" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdCargo" runat="server" Enabled="False" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label runat="server" Text="Equivalencia" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBEquivalencia" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label runat="server" Text="Concepto" />
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label Text="Monto" runat="server" ID="LMonto"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TBMonto" runat="server" Width="150px"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMonto" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBMonto"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMonto" runat="server" TargetControlID="REVMonto"></asp:ValidatorCalloutExtender>
                        <asp:DropDownList runat="server" ID="DDTipoMonto" Height="22px" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label runat="server" Text="Tipo de Cargo" />
                    </td>
                    <td class="SegundaColumna">
                       <asp:DropDownList runat="server" ID="DDTipoCargo" Height="22px" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label runat="server" Text="Agregar Automaticamente" />
                    </td>
                    <td>
                       <asp:DropDownList runat="server" ID="DDAgregaAuto" Height="22px" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td  class="PrimeraColumna">
                        <asp:Label ID="Label2" runat="server" Text="Estado" />
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
