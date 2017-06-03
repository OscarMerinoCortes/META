<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Impuesto.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar"  />
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
                        <asp:GridView ID="GVImpuesto" Width="100%" runat="server"
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
                        <asp:TextBox ID="TBIdImpuesto" runat="server" Enabled="False" Width="150"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>&nbsp;</td>
                    <td class="PrimeraColumna">Descripcion</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TBDescripcion"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Descripcion es Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"> </asp:ValidatorCalloutExtender>
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td>Impuesto</td>
                    <td>
                        <asp:TextBox ID="TBImpuesto" runat="server" Width="150"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVImpuesto" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="Guardar" ControlToValidate="TBImpuesto"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERImpuesto" runat="server" TargetControlID="REVImpuesto"></asp:ValidatorCalloutExtender>
                        &nbsp;%
                    </td>
                   
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Estado
                    </td>
                    <td class="SegundaColumna">
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

