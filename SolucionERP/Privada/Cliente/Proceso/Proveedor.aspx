<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Proveedor.aspx.vb" Inherits="_Default" %>

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
                    <td class="PrimeraColumna">RFC</td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBRFC0" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">Equivalencia</td>
                    <td class="auto-style2">
                        <asp:TextBox Width="150px" ID="TBEquivalencia" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Estado</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>Razón Social</td>
                    <td>
                        <asp:TextBox Width="150px" ID="TBRazonSocial" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Observaciones</td>
                    <td class="PrimeraColumna" rowspan="3" colspan="2">
                        <asp:TextBox ID="TBObservaciones" runat="server" Height="70px" TextMode="MultiLine" Width="300px" />

                    </td>
                    
                </tr>
                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4"></td>
                    
                </tr>
                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    
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
        .auto-style3 {
            height: 25px;
        }
        .auto-style4 {
            min-width: 200px;
            max-width: 200px;
            background-color: rgba(195, 195, 195, 0.38);
            height: 25px;
        }
    </style>
</asp:Content>


