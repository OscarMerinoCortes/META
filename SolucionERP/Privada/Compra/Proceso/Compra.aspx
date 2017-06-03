<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="Compra.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>

<%@ Register Src="~/Wuc/WucBusquedaProveedor.ascx" TagName="WucBusquedaProveedor" TagPrefix="WUCProv" %>
<%@ Register Src="~/Wuc/WucBusqueda.ascx" TagName="WucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register Src="~/Wuc/wucConsultarProductoPerfil.ascx" TagName="wucConsultarProductoPerfil" TagPrefix="WUCPF" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%--Linea Para las Validaciones--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover1);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover2);
        function Hover1() {
            $(".tooltip").hover(function () {
                var tooltip = $("> div", this).show();
                var pos = tooltip.offset();
                tooltip.hide();
                var right = pos.left + tooltip.width();
                var pageWidth = $(document).width();
                if (pos.left < 0) {
                    tooltip.css("marginLeft", "+=" + (-pos.left) + "px");
                }
                else if (right > pageWidth) {
                    tooltip.css("marginLeft", "-=" + (right - pageWidth));
                }
                var IdProducto = tooltip[0].id.replace("divTablasTooltip", "");
                $.ajax({
                    //primero es atravez de ajax hacer una llamada al metodo GetChart
                    type: "POST", //por post
                    url: "Compra.aspx/TablasTooltip", //este es el webmethod que esta en el .vb del aspx
                    data: "{idproducto: '" + IdProducto + "'}", //la variable que se recibe desde el load del .vb se envia como dato al webmethod
                    contentType: "application/json; charset=utf-8", //se´especifica el tipo de contenido
                    dataType: "json", // se especifica el tipo de dato devuelto
                    success: function (r) { //si la operacion es exitosa
                        var divTabla = "divTablasTooltip" + IdProducto;
                        document.getElementById(divTabla).innerHTML = r.d;
                    },
                    failure: function (response) {
                        alert('Error al cargar las tablas');
                    }
                });

                tooltip.fadeIn();
            }, function () {
                $("> div", this).fadeOut(function () { $(this).css("marginLeft", ""); });
            });
        };
        function Hover2() {
            $(".tooltip2").hover(function () {
                var tooltip2 = $("> div", this).show();
                var pos2 = tooltip2.offset();
                tooltip2.hide();
                var right2 = pos2.left + tooltip2.width();
                var pageWidth2 = $(document).width();
                if (pos2.left < 0) {
                    tooltip2.css("marginLeft", "+=" + (-pos2.left) + "px");
                }
                else if (right2 > pageWidth2) {
                    tooltip2.css("marginLeft", "-=" + (right2 - pageWidth2));
                }
                var ids = tooltip2[0].id.replace("divTablasTooltip2", ",").split(",");
                var IdSolicitudDetalle = ids[0];
                var IdProducto2 = ids[1];
                $.ajax({
                    //primero es atravez de ajax hacer una llamada al metodo GetChart
                    type: "POST", //por post
                    url: "Compra.aspx/TablasTooltip", //este es el webmethod que esta en el .vb del aspx
                    data: "{idproducto: '" + IdProducto2 + "'}", //la variable que se recibe desde el load del .vb se envia como dato al webmethod
                    contentType: "application/json; charset=utf-8", //se´especifica el tipo de contenido
                    dataType: "json", // se especifica el tipo de dato devuelto
                    success: function (r) { //si la operacion es exitosa
                        var divTabla2 = IdSolicitudDetalle + "divTablasTooltip2" + IdProducto2;
                        document.getElementById(divTabla2).innerHTML = r.d;
                    },
                    failure: function (response) {
                        alert('Error al cargar las tablas');
                    }
                });

                tooltip2.fadeIn();
            }, function () {
                $("> div", this).fadeOut(function () { $(this).css("marginLeft", ""); });
            });
        };
        function imprSelec(muestra, muestra2) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);

            var ficha2 = document.getElementById(muestra2);
            ventimp.document.write(ficha2.innerHTML);

            ventimp.document.close();
            ventimp.print();
            ventimp.close();
        }
        <%--function EnterEvent(e) {
            if (e.keyCode == 13) {
               
                __doPostBack('<%=BTNAceptarDetalle.UniqueID%>', "");
            }
            
        }--%>
        function IsValid(args) {
            if (args.value.length == 0) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <asp:UpdatePanel runat="server" ID="UPPromocion">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="5" class="MenuHead">
                                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" Style="height: 30px" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" />
                                <asp:ImageButton ID="IMBackorder" runat="server" ImageUrl="~/Imagenes/IMBackorder.png" />
                                <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="imprSelec('TablaPrueba','TablaPrueba');" />--%>
                            </td>
                        </tr>
                    </table>
                     <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2 ">
                                <span>Compra</span>
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBIdCompra" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2">
                                <span>Tipo del documento</span>
                            </div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDTipoDocumento" runat="server" CssClass="form-control"/>
                            </div>
                            <div class="col-md-3 col-lg-3"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2"><span>Proveedor</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                                <WUCProv:WucBusquedaProveedor ID="wucConProv" runat="server" />
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2"><span>Serie del documento</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                               <asp:TextBox ID="TBSerieDocumento" runat="server" Enabled="True" CssClass="form-control" />
                            </div>
                            <div class="col-md-3 col-lg-3"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2 "><span>Almacen</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                               <asp:DropDownList ID="DDDestino" runat="server" CssClass="form-control"/>
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2"><span>Folio del documento</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBFolioDocumento" runat="server" Enabled="True" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RFVFolioDocumento" runat="server" ControlToValidate="TBFolioDocumento" Display="None" ErrorMessage="&lt;strong&gt;Información requerida&lt;/strong&gt; Folio Obligatorio" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCEFolioDocumento" runat="server" TargetControlID="RFVFolioDocumento"></asp:ValidatorCalloutExtender>
                            </div>
                            <div class="col-md-3 col-lg-3"></div>
                        </div>

                         <div class="container-fluid">
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2 "><span>Compra a credito</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                              <asp:CheckBox ID="CBCompraCredito" runat="server" AutoPostBack="true" />
                            </div>
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2"><span>Fecha del documento</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBFechaDocumento" runat="server" AutoPostBack="True" Font-Strikeout="False" CssClass="form-control" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaDocumento" />
                            </div>
                            <div class="col-md-3 col-lg-3"></div>
                        </div>
                         <div class="container-fluid">
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2 "><span>Estado</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                             <asp:DropDownList ID="DDTipoCompraEstado" runat="server" Enabled="False" CssClass="form-control"/></div>
                            <div class="col-xs-12 col-sm-3 col-md-2 col-lg-2"><span>Observacion</span></div>
                            <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                               <asp:TextBox ID="TBObservacion" runat="server" Enabled="True" TextMode="MultiLine" Height="30px" CssClass="form-control" />
                            </div>
                            <div class="col-md-3 col-lg-3"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                            </div>
                        </div>
                    </div>
                                <asp:DropDownList ID="DDFormaPago" runat="server" Height="22px" Width="155px" Visible="false" />
                    <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent"
                        CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                        Width="100%" Height="1985px">
                        <Panes>
                            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="" Visible="false">
                                <Header>Compra Credito</Header>
                                <Content>
                                    <table style="width: 100%; border-collapse: collapse;">
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Cargos</td>
                                            <td class="Segunda_Columna">
                                                <asp:TextBox ID="TBCCargo" runat="server" AutoPostBack="True" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="Primer_Columna">Anticipos</td>
                                            <td class="Cuarta_Columna">
                                                <asp:TextBox ID="TBCAnticipo" runat="server" AutoPostBack="True" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Fecha Limite de Liquidacion</td>
                                            <td class="Segunda_Columna">
                                                <asp:RadioButton ID="RBFechaLimite" runat="server" AutoPostBack="true" Checked="true" GroupName="TipoPago" Text="" Value="1" /></td>
                                            <td class="Primer_Columna"></td>
                                            <td class="Cuarta_Columna"></td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Pago Por Periodos</td>
                                            <td class="Segunda_Columna">
                                                <asp:RadioButton ID="RBPagoPeriodos" runat="server" AutoPostBack="true" GroupName="TipoPago" Text="" Value="2" /></td>
                                            <td class="Primer_Columna"></td>
                                            <td class="Cuarta_Columna"></td>
                                        </tr>
                                        <tr id="TRPeriodos" runat="server" visible="false">
                                            <td />
                                            <td class="PrimeraColumna">Periodo</td>
                                            <td class="PrimeraColumna">
                                                <asp:DropDownList ID="DDPeriodo" runat="server" AutoPostBack="True" Width="155px" /></td>
                                            <td class="PrimeraColumna"></td>
                                            <td class="SegundaColumna"></td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="">Plazo Limite</td>
                                            <td class="">
                                                <asp:DropDownList ID="DDPlazoLimite" runat="server" AutoPostBack="True" Width="155px" /></td>
                                            <td class="">Intereses</td>
                                            <td class="">
                                                <asp:TextBox ID="TBPLInteres" runat="server" AutoPostBack="True" Font-Bold="True" Font-Strikeout="False" Width="150px" /><asp:FilteredTextBoxExtender ID="FTBEPLInteres" runat="server" FilterType="Numbers" TargetControlID="TBPLInteres" />
                                                % </td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Fecha Inicio</td>
                                            <td class="Segunda_Columna">
                                                <asp:TextBox ID="TBPLFechaInicio" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="Primer_Columna">Fecha Fin</td>
                                            <td class="Cuarta_Columna">
                                                <asp:TextBox ID="TBPLFechaFin" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                        </tr>
                                        <tr id="PeriodosPlazoLimite" runat="server" visible="false">
                                            <td class="Primer_Columna0"></td>
                                            <td class="">Periodos</td>
                                            <td class="">
                                                <asp:TextBox ID="TBPLPeriodos" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="">Abonos</td>
                                            <td class="">
                                                <asp:TextBox ID="TBPLAbonos" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Total</td>
                                            <td class="Segunda_Columna">
                                                <asp:TextBox ID="TBPLTotal" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="Primer_Columna"></td>
                                            <td class="Cuarta_Columna"></td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="">Plazo Limite Corto</td>
                                            <td class="">
                                                <asp:DropDownList ID="DDPlazoLimiteCorto" runat="server" AutoPostBack="True" Width="155px" /></td>
                                            <td class="">Intereses</td>
                                            <td class="">
                                                <asp:TextBox ID="TBPLCInteres" runat="server" AutoPostBack="True" Font-Bold="True" Font-Strikeout="False" Width="150px" /><asp:FilteredTextBoxExtender ID="FTBEPLCInteres" runat="server" FilterType="Numbers" TargetControlID="TBPLCInteres" />
                                                % </td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Fecha Inicio</td>
                                            <td class="Segunda_Columna">
                                                <asp:TextBox ID="TBPLCFechaInicio" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="Primer_Columna">Fecha Fin</td>
                                            <td class="Cuarta_Columna">
                                                <asp:TextBox ID="TBPLCFechaFin" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                        </tr>
                                        <tr id="PeriodosPlazoLimiteCorto" runat="server" visible="false">
                                            <td />
                                            <td class="">Periodos</td>
                                            <td class="">
                                                <asp:TextBox ID="TBPLCPeriodos" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="">Abonos</td>
                                            <td class="">
                                                <asp:TextBox ID="TBPLCAbonos" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                        </tr>
                                        <tr>
                                            <td class="Primer_Columna0"></td>
                                            <td class="Primer_Columna">Total</td>
                                            <td class="Segunda_Columna">
                                                <asp:TextBox ID="TBPLCTotal" runat="server" AutoPostBack="True" Enabled="False" Font-Bold="True" Font-Strikeout="False" Width="150px" /></td>
                                            <td class="Primer_Columna"></td>
                                            <td class="Cuarta_Columna"></td>
                                        </tr>
                                    </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="PanelSolicitudes" runat="server" ContentCssClass="" HeaderCssClass="">
                                <Header>Ordenes de Compra</Header>
                                <Content>
                                    <asp:Panel ID="Panel1" runat="server" Width="100%" BackColor="#FDFDFD" Visible="True" Height="300px">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td class="Primer_Columna0"></td>
                                                <td colspan="4">
                                                    <asp:Button ID="BTNConsultarOrdenes" runat="server" Text="Consultar" /></td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td colspan="5">
                                                    <asp:GridView ID="GVOrden" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" CssClass="GridComun" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="BTNComprarTodo" runat="server" AutoPostBack="true" ForeColor="SkyBlue" OnClick="BTNOrdenarTodo_OnClick" ShowSelectButton="True" Text="Comprar Todo" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNComprar" runat="server" AutoPostBack="true" ForeColor="Blue" OnClick="BTNOrdenar_OnClick" ShowSelectButton="True" Text="Comprar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IdOrden" HeaderText="Orden" SortExpression="IdOrden" Visible="true" />
                                                            <asp:BoundField DataField="IdOrdenDetalle" HeaderText="Detalle" SortExpression="IdOrdenDetalle" Visible="true" />
                                                            <%--<asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />--%>
                                                            <asp:TemplateField ItemStyle-CssClass="tooltip2">
                                                                <HeaderTemplate>Codigo</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("IdProductoCorto")%>
                                                                    <div id="<%# Eval("IdOrdenDetalle")%>divTablasTooltip2<%# Eval("IdProductoCorto")%>" class="tooltipContent2"></div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>Producto</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" />
                                                            <asp:BoundField DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" Visible="true" />
                                                            <asp:BoundField DataField="TipoSolicitudEstado" HeaderText="Estado" SortExpression="TipoSolicitudEstado" Visible="true" />
                                                            <asp:BoundField DataField="TipoPrioridad" HeaderText="Prioridad" SortExpression="TipoPrioridad" Visible="true" />
                                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" Visible="true" />
                                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" Visible="true" />
                                                            <%--<asp:TemplateField>
                                                                <HeaderTemplate>Ver Perfil</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNPerfil" runat="server" ForeColor="Blue" OnClick="BTNPerfil2_OnClick" ShowSelectButton="True" Text="Ver Perfil" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane ID="PanelDetalleCompra" runat="server" ContentCssClass="" HeaderCssClass="">
                                <Header>Productos de la compra</Header>
                                <Content>
                                    <asp:Panel ID="PADetalle" runat="server" Width="100%" BackColor="#FDFDFD" Visible="True" Height="600px">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td colspan="4">
                                                    <asp:DropDownList ID="DDAlmacen" runat="server" Height="22px" Width="155px" Visible="false" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Button ID="BTNEliminarDetalle" runat="server" Text="Eliminar" Visible="false" /><asp:Button ID="BTNCancelarDetalle" runat="server" Text="Cancelar" Visible="false" /></td>
                                            </tr>
                                        </table>

                                        <div class="container-fluid">
                                            <div class="col-xs-12 col-sm-3 col-md-1 col-lg-1">Producto</div>
                                            <div class="col-xs-12 col-sm-9 col-md-4 col-lg-4">
                                                <WUCP:WucConsultarProducto ID="wucConsultarProducto1" runat="server" />
                                            </div>
                                            <div class="col-xs-12 col-sm-3 col-md-1 col-lg-1">Cantidad </div>
                                            <div class="col-xs-12 col-sm-9 col-md-2 col-lg-2">
                                                <asp:TextBox ID="TBCantidadDetalle" runat="server" CssClass="form-control" /><asp:FilteredTextBoxExtender ID="FTBECantidadDetalle" runat="server" FilterType="Numbers" TargetControlID="TBCantidadDetalle" />
                                            </div>
                                            <div class="col-xs-12 col-sm-3 col-md-1 col-lg-1">Costo </div>
                                            <div class="col-xs-12 col-sm-9 col-md-2 col-lg-2">
                                                <asp:TextBox ID="TBPrecioUnitario" runat="server" CssClass="form-control" />
                                            </div>
                                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1">
                                                <asp:Button ID="BTNAceptarDetalle" runat="server" Text="Aceptar" />
                                            </div>
                                        </div>

                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td colspan="3">&nbsp </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td colspan="3">

                                                    <asp:GridView ID="GVCompraDetalle" runat="server" CssClass="GridComun table table-responsive" GridLines="None" Style="margin: 0 auto;" Width="100%">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <PagerStyle CssClass="pgr" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Eliminar
                                                                </HeaderTemplate>

                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNSeleccionar_OnClick" ShowSelectButton="True" Text="Eliminar" />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />--%>
                                                            <asp:TemplateField ItemStyle-CssClass="tooltip">
                                                                <HeaderTemplate>Codigo</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("IdProductoCorto")%>
                                                                    <div id="divTablasTooltip<%# Eval("IdProductoCorto")%>" class="tooltipContent"></div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Producto
                                                                </HeaderTemplate>

                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="false" />--%>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>Cantidad</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TBGVCantidad" runat="server" AutoPostBack="true" OnTextChanged="GVICantidad_TextChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" SortExpression="PrecioUnitario" Visible="false" />--%>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>Precio Unitario</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TBGVPrecioUnitario" runat="server" AutoPostBack="true" OnTextChanged="GVIPrecio_TextChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" />
                                                            <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Almacen" Visible="true" />
                                                            <asp:BoundField DataField="TipoSolicitudEstado" HeaderText="Estado Solicitud" SortExpression="TipoSolicitudEstado" Visible="true" />
                                                   <%--         <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Ver Perfil
                                                                </HeaderTemplate>

                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNPerfil" runat="server" ForeColor="Blue" OnClick="BTNPerfil_OnClick" ShowSelectButton="True" Text="Ver Perfil" />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>--%>

                                                        </Columns>
                                                    </asp:GridView>




                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: right">
                                                    <asp:Button ID="BTNCompraDetalle" runat="server" OnClick="BTNCompraDetalle_Click" Text="Nuevo Detalle de Compra" Visible="false" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                        </Panes>
                    </ajaxToolkit:Accordion>
                    <WUCPF:wucConsultarProductoPerfil ID="wucConsultarProductoPerfil1" runat="server" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td class="Primer_Columna0" />
                            <td class="Primer_Columna">
                                <asp:ImageButton ID="BTNRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                                <asp:ImageButton ID="BTNConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Compra</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                               <asp:TextBox ID="TBOrdenFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Proveedor</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                               <asp:DropDownList ID="DDProveedorFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Del:</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                               <asp:TextBox ID="TBFechaInicioFiltro" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" CssClass="form-control"/>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioFiltro" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Al:</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBFechaFinFiltro" runat="server" Font-Bold="True" AutoPostBack="True" CssClass="form-control"/>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinFiltro" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Documento</div>
                            <div class="col-xs-12 col-sm-11 col-md-7 col-lg-7">
                               <asp:DropDownList ID="DDTipoDocumentoFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                        </div>
                    </div>
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr style="text-align: center;">
                            <td>
                                <asp:GridView ID="GVConsulta" Style="margin: 0 auto;" runat="server" AllowPaging="false"
                                    Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="Imprimir" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="BTNImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" CssClass="Ocultar" />
                                <asp:ImageButton ID="BTIRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" CssClass="Ocultar" />
                            </td>
                        </tr>
                    </table>

                    <div id="TablaEncabezado">
                        <table>
                            <tr>
                                <td>IdCompra:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LIdCompra" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Tipo de Documento:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LTipoDocumento" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Serie Documento:&nbsp;&nbsp;&nbsp;&nbsp;

                                </td>
                                <td>
                                    <asp:Label ID="LSerieDocumento" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Folio Documento:&nbsp;&nbsp;&nbsp;&nbsp; 
                                </td>
                                <td>
                                    <asp:Label ID="LFolioDocumento" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Fecha del Documento:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LFechaDocumento" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Forma de Pago:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LFormaPago" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                        <td>Id Proveedor:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td>
                            <asp:Label ID="LIdProveedor" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>--%>
                            <tr>
                                <td>Nombre Proveedor:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LNombreProveedor" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Observacion:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Label ID="LObservacion" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Cargos:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Label ID="LCargos" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Anticipos:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Label ID="LAnticipo" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="TablaImprimir">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr style="text-align: center;">
                                <td colspan="3">

                                    <asp:GridView ID="GVCompraProducto" Style="margin: 0 auto;" runat="server" AllowPaging="false"
                                        Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
                <asp:View ID="BackOrder" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="BTNRegresarBackOrder" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" CssClass="Ocultar" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GVBackOrder" Width="100%" runat="server"
                        AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                        BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .tooltip, .tooltip2, .tooltip3 {
            position: relative;
        }

            .tooltip > div {
                display: none;
                position: absolute;
                left: 50%;
                margin-left: 30px;
                width: 1000%;
                top: -100px;
            }

        .tooltipContent, .tooltipContent2, .tooltipContent3 {
            position: absolute;
            background-color: #eee;
            border: 1px solid #555;
            border-radius: 5px;
            padding: 5px;
            z-index: 99999;
        }

        .tooltip2 > div {
            display: none;
            position: absolute;
            left: 50%;
            margin-left: 30px;
            width: 1000%;
            top: -3px;
        }
        .divTooltipTablas {
            font-size:12px;
            z-index:999999;
            color:#000000;
            text-align:left;
        }
        .divTooltipTablas table{
            font-size:12px;
            color:#000000;
        }
        
    </style>
</asp:Content>

