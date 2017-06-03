<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Proveedor.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>

<%@ Register Src="~/Wuc/WucConsultarProducto.ascx" TagName="wucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">  /*--METODO PARA DETECTAR UNA TECLA PRESIONADA (REVISAR MASTER) */
        function ObtenerTecla(key) {
            if (key == 13) {
                return true;
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
                        <asp:TextBox Width="150px" ID="TBIdProveedor" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="PrimeraColumna">&nbsp;</td>
                    <td class="SegundaColumna">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style2">Equivalencia</td>
                    <td class="auto-style2">
                        <asp:TextBox Width="150px" ID="TBEquivalencia" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>Razón Social</td>
                    <td>
                        <asp:TextBox Width="150px" ID="TBRazonSocial" runat="server" Enabled="True"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>RFC</td>
                    <td>
                        <asp:TextBox ID="TBRFC" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Primer nombre</td>
                    <td>
                        <asp:TextBox ID="TBPrimerNombre" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Segundo Nombre</td>
                    <td>
                        <asp:TextBox ID="TBSegundoNombre" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Apellido Paterno</td>
                    <td>
                        <asp:TextBox ID="TBApellidoPaterno" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Apellido Materno</td>
                    <td>
                        <asp:TextBox ID="TBApellidoMaterno" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>Limite de Credito</td>
                    <td>
                        <asp:TextBox ID="TBLimiteCredito" runat="server" Enabled="True" Width="150px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBELimiteCredito" runat="server" FilterType="Numbers" TargetControlID="TBLimiteCredito" />
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
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="1652px" Width="100%">
                            <Panes>
                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Contacto</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="PanelMedio" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Tipo Contacto</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDTipoContacto" runat="server" Height="22px" Width="155px">
                                                                    </asp:DropDownList>

                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Contacto</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBContacto" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVContacto" runat="server" ControlToValidate="TBContacto"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Tipo Medio es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEContacto" runat="server" TargetControlID="RFVContacto"></asp:ValidatorCalloutExtender>
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
                                    <Header>Direccion</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelDomicilio" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
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
                                                                    <asp:TextBox Width="150px" ID="TBDomicilioNumeroExterior" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RFVDomicilioNumeroExterior" runat="server" ControlToValidate="TBDomicilioNumeroExterior"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Numero Exterior es Obligatorio"
                                                                        Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEDomicilioNumeroExterior" runat="server" TargetControlID="RFVDomicilioNumeroExterior"></asp:ValidatorCalloutExtender>
                                                                    <asp:RegularExpressionValidator Display="none" ID="REVDomicilioNumeroExterior" runat="server" ErrorMessage="Este Campo Solo Admite Numeros y Letras" ValidationExpression="^[A-Z0-9 a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBDomicilioNumeroExterior"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERDomicilioNumeroExterior" runat="server" TargetControlID="REVDomicilioNumeroExterior"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Número Interior</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBDomicilioNumeroInterior" runat="server"></asp:TextBox><asp:RegularExpressionValidator Display="none" ID="REVDomicilioNumeroInterior" runat="server" ErrorMessage="Este Campo Solo Admite Numeros y Letras" ValidationExpression="^[A-Z0-9 a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBDomicilioNumeroInterior"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEERDomicilioNumeroInterior" runat="server" TargetControlID="REVDomicilioNumeroInterior"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Codigo Postal</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBDomicilioCodigoPostal" runat="server" AutoPostBack="true" OnTextChanged="TBDomicilioCodigoPostal_TextChanged" /><asp:RequiredFieldValidator ID="RFVDomicilioCodigoPostal" runat="server" ControlToValidate="TBDomicilioCodigoPostal"
                                                                        ErrorMessage="&lt;strong>Información requerida</strong> El Codigo Postal es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEDomicilioCodigoPostal" runat="server" TargetControlID="RFVDomicilioCodigoPostal"></asp:ValidatorCalloutExtender>
                                                                    <asp:FilteredTextBoxExtender ID="FTBEDomicilioCodigoPostal" runat="server" FilterType="Numbers" TargetControlID="TBDomicilioCodigoPostal" />
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">País</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:DropDownList ID="DDPais" runat="server" Height="22px" Width="155px" OnSelectedIndexChanged="DDPais_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
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
                                                                    <asp:TextBox Width="150px" ID="TBIdDomicilio" Visible="False" runat="server"></asp:TextBox></td>
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
                                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                    <Header>Productos</Header>
                                    <Content>
                                        <asp:Panel ID="Productos" runat="server" Width="100%" BackColor="#FDFDFD" Visible="True" Height="350px">
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td></td>
                                                    <td class="Segunda_Columna">
                                                        <WUCP:wucConsultarProducto ID="wucConsultarProducto1" runat="server" />
                                                    </td>
                                                    <td class="Primer_Columna">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Precio</td>
                                                    <td>
                                                        <asp:TextBox ID="TBPrecio" runat="server" Width="150px" />
                                                        &nbsp&nbsp&nbsp
                                                        <asp:Button ID="BTNAceptarProducto" runat="server" Text="Aceptar" />
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="4">&nbsp;
                                                                    <asp:Button ID="BTNActualizarProducto" runat="server" Enabled="false" Text="Actualizar" Visible="false" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarProducto" runat="server" Enabled="false" Text="Eliminar" Visible="false" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarProducto" runat="server" Text="Cancelar" Visible="false" />
                                                                    <asp:TextBox Width="150px" ID="TBIdProducto" Visible="False" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="GVProductos" Style="margin: 0 auto;" runat="server" CssClass="GridComun" GridLines="None" Width="100%" AutoGenerateColumns="false">
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <PagerStyle CssClass="pgr" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Eliminar
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="BTNEliminarProducto" runat="server" Checked="false"
                                                                            ForeColor="Blue" Text="Eliminar" ShowSelectButton="True" OnClick="BTNEliminarProducto_Click1" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:BoundField DataField="IdSolicitudDetalle" HeaderText="ID" Visible="true" />--%>
                                                                <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" Visible="true" />
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Producto
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />--%>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>Precio</HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="TBGVPrecio" runat="server" AutoPostBack="true" OnTextChanged="GVIPrecio_TextChanged" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td colspan="4">
                                                        <%--<asp:GridView Width="100%" ID="GVProductos" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>--%>

                                                    
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Button ID="BTNProducto" runat="server" Text="+ Nuevo Producto" Visible="False" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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
                        <asp:ImageButton ID="IMBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" Visible="false" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td style="width: 10%">Id</td>
                    <td>
                        <asp:TextBox ID="TBIdPersonaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td>Equivalencia</td>
                    <td>
                        <asp:TextBox ID="TBEquivalenciaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr runat="server" visible="false">
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

                <tr runat="server" visible="false">
                    <td>Genero</td>
                    <td>
                        <asp:DropDownList ID="DDGeneroConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td>Tipo Persona</td>
                    <td>
                        <asp:DropDownList ID="DDTipoPersonaConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
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
                        <asp:GridView Width="100%" ID="GVProveedor" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
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


