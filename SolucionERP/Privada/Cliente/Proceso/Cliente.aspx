<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <script type="text/javascript">  /*--METODO PARA DETECTAR UNA TECLA PRESIONADA (REVISAR MASTER) */
        function ObtenerTecla(key) {
            if (key == 13) {
                return false;
            }
        }
    </script>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%; border-collapse: collapse;">
                <tr>
                    <td colspan="5" class="MenuHead">
                        <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td class="CeroColumna"></td>
                    <td colspan="4"><strong>Datos Generales</strong></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">ID</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox Width="150px" ID="TBIdPersona" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="PrimeraColumna">Fecha de Nacimiento</td>
                    <td class="SegundaColumna">
                        <asp:TextBox Width="150px" ID="TBFecha" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFecha" />
                        <asp:RequiredFieldValidator ID="RFVFecha" runat="server" ControlToValidate="TBFecha"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Fecha es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFecha" runat="server" TargetControlID="RFVFecha"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">Equivalencia</td>
                    <td class="auto-style2">
                        <asp:TextBox Width="150px" ID="TBEquivalencia" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Genero</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DDGenero" runat="server" AutoPostBack="True" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Tipo Persona</td>
                    <td class="PrimeraColumna">
                        <asp:DropDownList ID="DDTipoPersona" runat="server" Height="22px" Width="155px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td class="PrimeraColumna">Estado Civil</td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDEstadoCivil" runat="server" AutoPostBack="True" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Razón Social</td>
                    <td>
                        <asp:TextBox Width="150px" ID="TBRazonSocial" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Primer Nombre</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox Width="150px" ID="TBNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TBNombre"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Primer Nombre es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCENombre" runat="server" TargetControlID="RFVNombre"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBNombre"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERNombre" runat="server" TargetControlID="REVNombre"></asp:ValidatorCalloutExtender>

                    </td>
                    <td class="PrimeraColumna">Observaciones</td>
                    <td class="PrimeraColumna" rowspan="3">
                        <asp:TextBox ID="TBObservaciones" runat="server" Height="70px" TextMode="MultiLine" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Segundo Nombre</td>
                    <td>
                        <asp:TextBox Width="150px" ID="TBSegundoNombre" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVSegundoNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBSegundoNombre"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERSegundoNombre" runat="server" TargetControlID="REVSegundoNombre"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Apellido Paterno</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox Width="150px" ID="TBAPaterno" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVAPaterno" runat="server" ControlToValidate="TBAPaterno"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Paterno es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEAPaterno" runat="server" TargetControlID="RFVAPaterno"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVAPaterno" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBAPaterno"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERAPaterno" runat="server" TargetControlID="REVAPaterno"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="PrimeraColumna"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>Apellido Materno</td>
                    <td>
                        <asp:TextBox Width="150px" ID="TBAMaterno" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVAMaterno" runat="server" ControlToValidate="TBAMaterno"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Materno es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEAMaterno" runat="server" TargetControlID="RFVAMaterno"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVAMaterno" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBAMaterno"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERAMaterno" runat="server" TargetControlID="REVAMaterno"></asp:ValidatorCalloutExtender>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width: 100%; border-collapse: collapse;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="3752px" Width="100%">
                            <Panes>
                                <ajaxToolkit:AccordionPane ID="AccordionPane0" runat="server" ContentCssClass="" HeaderCssClass="" Visible="false">
                                    <Header>Conyugue</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="PAConyugue" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-size: medium;" class="PrimeraColumna">ID</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBIdPerConyugue" runat="server" Enabled="False">
                                                                    </asp:TextBox></td>
                                                                <td class="PrimeraColumna">Fecha de Nacimiento</td>
                                                                <td class="SegundaColumna">
                                                                    <asp:TextBox Width="150px" ID="TBFechaConyugue" runat="server">


                                                                    </asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender3" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaConyugue" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Equivalencia</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBEquivalenciaConyugue" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>Genero</td>
                                                                <td>
                                                                    <asp:DropDownList ID="DDGeneroConyugue" runat="server" Height="22px" Width="155px" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Primer Nombre</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBPriNomConyugue" runat="server"></asp:TextBox><asp:RegularExpressionValidator Display="none" ID="REVPriNomConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBPriNomConyugue"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERPriNomConyugue" runat="server" TargetControlID="REVPriNomConyugue"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                
                                                                <td class="PrimeraColumna">Estado Civil</td>
                                                                <td class="SegundaColumna">
                                                                    <asp:DropDownList ID="DDEstCivConyugue" runat="server" Height="22px" Width="155px" Enabled="False"></asp:DropDownList></td>


                                                            </tr>
                                                            <tr>
                                                                <td>Segundo Nombre</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBSegNomConyugue" runat="server"></asp:TextBox><asp:RegularExpressionValidator Display="none" ID="REVSegNomConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBSegNomConyugue"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERSegNomConyugue" runat="server" TargetControlID="REVSegNomConyugue"></asp:ValidatorCalloutExtender>
                                                                </td>

                                                                <td>Estado</td>
                                                                <td>
                                                                    <asp:DropDownList ID="DDEstadoConyugue" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Apellido Paterno</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBApePatConyugue" runat="server"></asp:TextBox><asp:RegularExpressionValidator Display="none" ID="REVApePatConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApePatConyugue"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERApePatConyugue" runat="server" TargetControlID="REVApePatConyugue"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                 <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Apellido Materno</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBApeMatConyugue" runat="server"></asp:TextBox><asp:RegularExpressionValidator Display="none" ID="REVApeMatConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApeMatConyugue"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERApeMatConyugue" runat="server" TargetControlID="REVApeMatConyugue"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td ></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="BTNConsultarConyugue" runat="server" Text="Consultar" />&nbsp;
                                                                    <asp:Button ID="BTNAceptarConyugue" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarConyugue" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarConyugue" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarConyugue" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaConyugue" Visible="false" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp; </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td colspan="2">
                                                    <asp:GridView ID="GVConyugue" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="BTNConyugue" runat="server" Text="+ Conyugue" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Identificacion</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="PAIdentificacion" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Tipo Identificacion</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoIdentificacion" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna" />
                                                                <td class="SegundaColumna" />
                                                            </tr>
                                                            <tr>
                                                                <td>Numero Identificacion</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBNumIdentificacion" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVNumIdentificacion" runat="server" ControlToValidate="TBNumIdentificacion"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCENumIdentificacion" runat="server" TargetControlID="RFVNumIdentificacion"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td />
                                                                <td />
                                                            </tr>
                                                            <tr>
                                                                <td class="SegundaColumna" colspan="4">
                                                                    <asp:Button ID="BTNAceptarIdentificacion" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarIdentificacion" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarIdentificacion" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarIdentificacion" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdIdentificacion" Visible="False" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp; </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td colspan="2">
                                                    <asp:GridView ID="GVIdentificacion" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="BTNuevaIdentificacion" runat="server" Text="+ Nueva Identificacion" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Contacto</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="PanelMedio" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Tipo Medio</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoMedio" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Medio</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBValorMedio" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVValorMedio" runat="server" ControlToValidate="TBValorMedio"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Tipo Medio es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEValorMedio" runat="server" TargetControlID="RFVValorMedio"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="SegundaColumna" colspan="4">
                                                                    <asp:Button ID="BTNAceptarMedio" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarMedio" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarMedio" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarMedio" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdMedio" Visible="False" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp; </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td colspan="2">
                                                    <asp:GridView Width="100%" ID="GVMedio" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Button ID="BTNMedio" runat="server" Text="+ Nueva Medio" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Domicilio</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelDomicilio" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Tipo Domicilio</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoDomicilio" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Calle</td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="TBCalle" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator ID="RFVCalle" runat="server" ControlToValidate="TBCalle"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Calle es Obligatoria"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCECalle" runat="server" TargetControlID="RFVCalle"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Número Exterior</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBDomNumExterior" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVDomNumExterior" runat="server" ControlToValidate="TBDomNumExterior"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Numero Exterior es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEDomNumExterior" runat="server" TargetControlID="RFVDomNumExterior"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVDomNumExterior" runat="server" ErrorMessage="Este Campo Solo Admite Numeros y Letras" ValidationExpression="^[A-Z0-9 a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBDomNumExterior"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERDomNumExterior" runat="server" TargetControlID="REVDomNumExterior"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Número Interior</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBDomNumInterior" runat="server"></asp:TextBox><asp:RegularExpressionValidator Display="none" ID="REVDomNumInterior" runat="server" ErrorMessage="Este Campo Solo Admite Numeros y Letras" ValidationExpression="^[A-Z0-9 a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBDomNumInterior"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERDomNumInterior" runat="server" TargetControlID="REVDomNumInterior"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Telefono</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBDomTelefono" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVDomTelefono" runat="server" ControlToValidate="TBDomTelefono"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEDomTelefono" runat="server" TargetControlID="RFVDomTelefono"></asp:ValidatorCalloutExtender>
                                                                    <asp:FilteredTextBoxExtender ID="FTBEDomTelefono"  runat="server" FilterType="Numbers" TargetControlID="TBDomTelefono"/>     
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Antiguedad</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBDomAntiguedad" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RFVDomAntiguedad" runat="server" ControlToValidate="TBDomAntiguedad"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Antiguedad es Obligatoria"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEDomAntiguedad" runat="server" TargetControlID="RFVDomAntiguedad"></asp:ValidatorCalloutExtender>
                                                                     <asp:FilteredTextBoxExtender ID="FTBEAntiguedad"  runat="server" FilterType="Numbers" TargetControlID="TBDomAntiguedad"/> 
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="RBAnos" Text="Años" GroupName="Antiguedad" Value="1" runat="server" OnCheckedChanged="RBAnos_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                    <asp:RadioButton GroupName="Antiguedad" Value="2" ID="RBMeses" Text="Meses" runat="server" OnCheckedChanged="RBMeses_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                    <asp:RadioButton Value="3"  GroupName="Antiguedad" ID="RBDias" Text="Dias" runat="server" OnCheckedChanged="RBDias_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Propietario</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBDomPropietario" runat="server"></asp:TextBox></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Codigo Postal</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBDomCodigoPostal" runat="server" AutoPostBack="true" OnTextChanged="TBDomicilioCodigoPostal_TextChanged" />
                                                                    <asp:RequiredFieldValidator ID="RFVDomCodigoPostal" runat="server" ControlToValidate="TBDomCodigoPostal"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Codigo Postal es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEDomCodigoPostal" runat="server" TargetControlID="RFVDomCodigoPostal"></asp:ValidatorCalloutExtender>
                                                                   <asp:FilteredTextBoxExtender ID="FTBEDomCodigoPostal"  runat="server" FilterType="Numbers" TargetControlID="TBDomCodigoPostal"/>     
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr runat="server" id="ControlPais">
                                                                <td class="PrimeraColumna">País</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDPais" runat="server" Height="22px" Width="155px" OnSelectedIndexChanged="DDPais_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr runat="server" id="ControlEntidadFederativa">
                                                                <td>Entidad Federativa</td>
                                                                <td>
                                                                    <asp:DropDownList ID="DDEntidadFederativa" runat="server" Height="22px" Width="155px" OnSelectedIndexChanged="DDEntidadFederativa_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Municipio</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDDomMunicipio" runat="server" Height="22px" Width="155px" OnSelectedIndexChanged="DDDomMunicipio_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Colonia</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDDomColonia" runat="server" Height="22px" Width="155px" OnSelectedIndexChanged="DDDomColonia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="BTNAceptarDomicilio" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarDomicilio" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarDomicilio" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelar" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdDomicilio" Visible="False" runat="server"></asp:TextBox>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView Width="100%" ID="GVDomicilio" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" colspan="2">
                                                    <asp:Button ID="BTNDomicilio" runat="server" Text="+ Nuevo Domicilio" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Empleos</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelEmpleo" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Tipo Empleo</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoEmpleos" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Ocupacion</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBEmpOcupacion" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVEmpOcupacion" runat="server" ControlToValidate="TBEmpOcupacion"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Empleo es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEEmpOcupacion" runat="server" TargetControlID="RFVEmpOcupacion"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVEmpOcupacion" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBEmpOcupacion"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEEREmpOcupacion" runat="server" TargetControlID="REVEmpOcupacion"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Empresa</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBEmpEmpresa" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVEmpEmpresa" runat="server" ControlToValidate="TBEmpEmpresa"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Empresa es Obligatoria"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEEmpEmpresa" runat="server" TargetControlID="RFVEmpEmpresa"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Antiguedad</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBEmpAntiguedad" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVEmpAntiguedad" runat="server" ControlToValidate="TBEmpAntiguedad"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Antiguedad es Obligatoria"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEEmpAntiguedad" runat="server" TargetControlID="RFVEmpAntiguedad"></asp:ValidatorCalloutExtender>
                                                                     <asp:FilteredTextBoxExtender ID="FTBEEmpAntiguedad"  runat="server" FilterType="Numbers" TargetControlID="TBEmpAntiguedad"/>  
                                                                     </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Domicilio</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBEmpDomicilio" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVEmpDomicilio" runat="server" ControlToValidate="TBEmpDomicilio"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEEmpDomicilio" runat="server" TargetControlID="RFVEmpDomicilio"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Telefono/Cel</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBEmpTelefono" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVEmpTelefono" runat="server" ControlToValidate="TBEmpTelefono"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEEmpTelefono" runat="server" TargetControlID="RFVEmpTelefono"></asp:ValidatorCalloutExtender>
                                                                    <asp:FilteredTextBoxExtender ID="FTBEEmpTelefono"  runat="server" FilterType="Numbers" TargetControlID="TBEmpTelefono"/>   
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="SegundaColumna" colspan="4">
                                                                    <asp:Button ID="BTNAceptarEmpleo" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarEmpleo" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarEmpleo" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarEmpleo" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaEmpleo" Visible="False" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView Width="100%" ID="GVEmpleo" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" colspan="4">
                                                    <asp:Button ID="BTNEmpleo" runat="server" Text="+ Nuevo Empleo" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Referencias</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelReferencia" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Tipo Referencia</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoReferencia" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Nombre</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBRefNombre" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVRefNombre" runat="server" ControlToValidate="TBRefNombre"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Nombre es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCERefNombre" runat="server" TargetControlID="RFVRefNombre"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVRefNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBRefNombre"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERRefNombre" runat="server" TargetControlID="REVRefNombre"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Ocupacion</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBRefOcupacion" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVRefOcupacion" runat="server" ControlToValidate="TBRefOcupacion"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Ocupacion es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCERefOcupacion" runat="server" TargetControlID="RFVRefOcupacion"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVRefOcupacion" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBRefOcupacion"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERRefOcupacion" runat="server" TargetControlID="REVRefOcupacion"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Compañia</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBRefEmpresa" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVRefEmpresa" runat="server" ControlToValidate="TBRefEmpresa"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Compañia es Obligatoria"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCERefEmpresa" runat="server" TargetControlID="RFVRefEmpresa"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Antiguedad</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBRefAntiguedad" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVRefAntiguedad" runat="server" ControlToValidate="TBRefAntiguedad"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> La Antiguedad es Obligatoria"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCERefAntiguedad" runat="server" TargetControlID="RFVRefAntiguedad"></asp:ValidatorCalloutExtender>
                                                                 <asp:FilteredTextBoxExtender ID="FTBERefAntiguedad"  runat="server" FilterType="Numbers" TargetControlID="TBRefAntiguedad"/>   
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Domicilio</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBRefDomicilio" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVRefDomicilio" runat="server" ControlToValidate="TBRefDomicilio"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCERefDomicilio" runat="server" TargetControlID="RFVRefDomicilio"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Telefono/Cel.</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBRefTelCel" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVRefTelCel" runat="server" ControlToValidate="TBRefTelCel"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCERefTelCel" runat="server" TargetControlID="RFVRefTelCel"></asp:ValidatorCalloutExtender>
                                                                     <asp:FilteredTextBoxExtender ID="FTBERefTelCel"  runat="server" FilterType="Numbers" TargetControlID="TBRefTelCel"/>   
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="BTNAceptarReferencia" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarReferencia" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarReferencia" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarReferencia" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaReferencia" Visible="False" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView Width="100%" ID="GVReferencia" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" colspan="4">
                                                    <asp:Button ID="BTNReferencia" runat="server" Text="+ Nueva Referencia" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Linea de Credito</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelLineaCredito" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Fecha</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBFechaLineaCredito" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" Enabled="True" runat="server" PopupPosition="BottomRight" Format="dd/MM/yyyy" TargetControlID="TBFechaLineaCredito" />
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Credito</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBLineaCredito" runat="server"></asp:TextBox></td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Monto</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBMontoLineaCredito" runat="server"></asp:TextBox>
                                                                     <asp:FilteredTextBoxExtender ID="FTBEMontoLineaCredito"  runat="server" FilterType="Numbers" TargetControlID="TBMontoLineaCredito"/>   
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="BTNAceptarLineaCredito" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarLineaCredito" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarLineaCredito" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarLineaCredito" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaLineaCredito" Visible="false" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView Width="100%" ID="GVLineaCredito" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" colspan="4">
                                                    <asp:Button ID="BTNLineaCredito" runat="server" Text="+ Nueva Linea de credito" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane7" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Indicadores</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelIndicadores" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Indicador</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoIndicador" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Monto</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBMontoIndicador" runat="server"></asp:TextBox>
                                                                     <asp:FilteredTextBoxExtender ID="FTBEMontoIndicador"  runat="server" FilterType="Numbers" TargetControlID="TBMontoIndicador"/>   
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="SegundaColumna" colspan="4">
                                                                    <asp:Button ID="BTNAceptarIndicador" runat="server" Text="Aceptar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarIndicador" runat="server" Text="Actualizar" ValidationGroup="Guardar" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarIndicador" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarIndicador" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaIndicador" Visible="False" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView Width="100%" ID="GVIndicador" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" colspan="4">
                                                    <asp:Button ID="BTNIndicador" runat="server" Text="+ Nueva Indicador" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                            </Panes>
                        </ajaxToolkit:Accordion>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="IBTRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                        <asp:ImageButton ID="IMBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                    </td>
                    <td></td>
                </tr>
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
                <tr>
                    <td>Equivalencia</td>
                    <td>
                        <asp:TextBox ID="TBEquivalenciaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Nombre Cliente</td>
                    <td>
                        <asp:TextBox ID="TBNombreClienteConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <!--Solo poner en true para que se puedab ver las fechas de inicio y verificar si otras empresas lo usan si no para quitarlos definitivamente-->
                <tr runat="server" visible="false">
                    <td>Fecha Inicio</td>
                    <td>
                        <asp:TextBox ID="TBFechaInicioConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <!--Solo poner en true para que se puedab ver las fechas de inicio -->
                <tr runat="server" visible="false">
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
                <tr>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstadoConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView Width="100%" ID="GVPersona" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            padding-right: 10px;
            height: 28px;
        }
        .auto-style2 {
            height: 28px;
        }
    </style>
</asp:Content>


