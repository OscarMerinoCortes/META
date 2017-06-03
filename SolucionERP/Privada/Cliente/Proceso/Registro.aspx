<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Registro.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
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

                <%--<tr>
                    <td colspan="2">
                        <asp:ImageButton ID="IBTRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                        <asp:ImageButton ID="IMBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                    </td>
                    <td></td>
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10%">Id</td>
                    <td>
                        <asp:TextBox ID="TBIdPersonaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <%--<tr>
                    <td>Equivalencia</td>
                    <td>
                        <asp:TextBox ID="TBEquivalenciaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>--%>
                <tr>
                    <td>Nombre Cliente</td>
                    <td>
                        <asp:TextBox ID="TBNombreClienteConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Fecha Inicio</td>
                    <td>
                        <asp:TextBox ID="TBFechaInicioConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Fin</td>
                    <td>
                        <asp:TextBox ID="TBFechaFinConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Genero</td>
                    <td>
                        <asp:DropDownList ID="DDGeneroConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Persona</td>
                    <td>
                        <asp:DropDownList ID="DDTipoPersonaConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
<%--                <tr>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstadoConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>--%>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>



                <tr style="text-align: center;">
                    <td style="width: 100%;" colspan="4">
                        <asp:GridView ID="GVRegistro" Width="100%" runat="server" 
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
                        <asp:Label ID="Label3" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdCredito" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td/>
                    <td  colspan="2">
                        <WUCP:wucConsultarPersona ID="wucConsultarPersona1" runat="server"  style="width: 100%;"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Fecha Apertura
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBFechaApertura" runat="server" Width="150px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVFechaApertura" runat="server" ControlToValidate="TBFechaApertura"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Fecha de Apertura es Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFechaApertura" runat="server" TargetControlID="RFVFechaApertura"> </asp:ValidatorCalloutExtender>
                        <ajaxToolkit:CalendarExtender ID="CEFechaApertura" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaApertura" />
                    </td>                    
                </tr>
                <tr>
                    <td></td>
                    <td>Fecha Vencimiento
                    </td>
                    <td>
                        <asp:TextBox ID="TBFechaVencimiento" runat="server" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TBFechaVencimiento_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaVencimiento" />
                         <asp:RequiredFieldValidator ID="RFVFechaVencimiento" runat="server" ControlToValidate="TBFechaVencimiento"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Fecha de Vencimiento es Obligatoria"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFechaVencimiento" runat="server" TargetControlID="RFVFechaVencimiento"> </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Monto 
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBMonto" runat="server" Width="150px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVMonto" runat="server" ControlToValidate="TBMonto"
                                                            ErrorMessage="&lt;strong>Información requerida</strong> El Monto es Obligatorio"
                                                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMonto" runat="server" TargetControlID="RFVMonto"> </asp:ValidatorCalloutExtender>
                           <asp:FilteredTextBoxExtender ID="FTBEMonto"  runat="server" FilterType="Numbers" TargetControlID="TBMonto"/> 
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Estado
                    </td>
                    <td >
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px">
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



