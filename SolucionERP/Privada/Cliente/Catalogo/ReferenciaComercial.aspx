<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReferenciaComercial.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
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
                        <asp:GridView ID="GVReferenciaComercial" Width="100%" runat="server"
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
                        <asp:TextBox ID="TBIdReferenciaComercial" runat="server" Enabled="False" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Referencia Comercial" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBReferenciaComercial" runat="server" Width="150px" />
                        <asp:RequiredFieldValidator ID="RFVReferenciaComercial" runat="server" ControlToValidate="TBReferenciaComercial"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Refencia Comercial es Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEReferenciaComercial" runat="server" TargetControlID="RFVReferenciaComercial"> </asp:ValidatorCalloutExtender>
                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label2" runat="server" Text="Domicilio" />
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBDomicilio" runat="server" Width="150px" />
                        <asp:RequiredFieldValidator ID="RFVDomicilio" runat="server" ControlToValidate="TBDomicilio"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>

                        <asp:ValidatorCalloutExtender ID="VCEDomicilio" runat="server" TargetControlID="RFVDomicilio"> </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Telefono" />
                    </td>
                    <td>
                        <asp:TextBox ID="TBTelefono" runat="server" Width="150px" />
                        <asp:RequiredFieldValidator ID="RFVTelefono" runat="server" ControlToValidate="TBTelefono"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>

                        <asp:ValidatorCalloutExtender ID="VCETelefono" runat="server" TargetControlID="RFVTelefono"> </asp:ValidatorCalloutExtender>
                          <asp:FilteredTextBoxExtender ID="FTBETelefono"  runat="server" FilterType="Numbers" TargetControlID="TBTelefono"/> 
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Estado" />
                    </td>
                    <td class="auto-style3">
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            min-width: 200px;
            max-width: 200px;
            background-color: rgba(195, 195, 195, 0.38);
            height: 24px;
        }
        .auto-style3 {
            width: 100%;
            background-color: rgba(195, 195, 195, 0.38);
            height: 24px;
        }         
    </style>
</asp:Content>

