<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Iva.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" style="margin-bottom: 0px" />
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
                        <asp:GridView ID="GVIva" Width="100%" runat="server"
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
                        <asp:TextBox ID="TBIdIva" runat="server" Enabled="False" Width="150"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td>IVA
                    </td>
                    <td>
                        <asp:TextBox ID="TBDescripcionIVA" runat="server" Width="150"></asp:TextBox>
                        &nbsp;%
                        <asp:RequiredFieldValidator ID="RFVDescripcionIVA" runat="server" ControlToValidate="TBDescripcionIVA"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> El IVA es Obligatorio"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcionIVA" runat="server" TargetControlID="RFVDescripcionIVA"> </asp:ValidatorCalloutExtender>
                        <asp:FilteredTextBoxExtender ID="FTBEDescripcionIVA"  runat="server" FilterType="Numbers" TargetControlID="TBDescripcionIVA"/>
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            min-width: 200px;
            max-width: 200px;
            background-color: rgba(195, 195, 195, 0.38);
            height: 22px;
        }
        .auto-style3 {
            width: 100%;
            background-color: rgba(195, 195, 195, 0.38);
            height: 22px;
        }
    </style>
</asp:Content>

