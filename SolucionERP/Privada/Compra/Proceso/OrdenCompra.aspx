<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="OrdenCompra.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucBusquedaProveedor.ascx" TagName="WucBusquedaProveedor" TagPrefix="WUCProv1" %>
<%@ Register Src="~/Wuc/WucBuscarProductoEstadisticas.ascx" TagName="wucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register Src="~/Wuc/WucEstadisticaProducto.ascx" TagName="wucEstadistica" TagPrefix="WUCE" %>
<%@ Register Src="~/Wuc/wucConsultarProductoPerfil.ascx" TagName="wucConsultarProductoPerfil" TagPrefix="WUCPF" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover1);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover2);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover3);
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
        function Hover3() {
            $(".tooltip3").hover(function () {
                var tooltip3 = $("> div", this).show();
                var pos3 = tooltip3.offset();
                tooltip3.hide();
                var right3 = pos3.left + tooltip3.width();
                var pageWidth3 = $(document).width();
                if (pos3.left < 0) {
                    tooltip3.css("marginLeft", "+=" + (-pos3.left) + "px");
                }
                else if (right3 > pageWidth3) {
                    tooltip3.css("marginLeft", "-=" + (right3 - pageWidth3));
                }
                var ids = tooltip3[0].id.replace("divTablasTooltip3", ",").split(",");
                var IdAlmacen = ids[0];
                var IdProducto3 = ids[1];

                $.ajax({
                    //primero es atravez de ajax hacer una llamada al metodo GetChart
                    type: "POST", //por post
                    url: "Compra.aspx/TablasTooltip", //este es el webmethod que esta en el .vb del aspx
                    data: "{idproducto: '" + IdProducto3 + "'}", //la variable que se recibe desde el load del .vb se envia como dato al webmethod
                    contentType: "application/json; charset=utf-8", //se´especifica el tipo de contenido
                    dataType: "json", // se especifica el tipo de dato devuelto
                    success: function (r) { //si la operacion es exitosa
                        var divTabla3 = IdAlmacen + "divTablasTooltip3" + IdProducto3;
                        document.getElementById(divTabla3).innerHTML = r.d;
                    },
                    failure: function (response) {
                        alert('Error al cargar las tablas');
                    }
                });

                tooltip3.fadeIn();
            }, function () {
                $("> div", this).fadeOut(function () { $(this).css("marginLeft", ""); });
            });
        };
    </script>
    <asp:UpdatePanel runat="server" ID="UPPromocion">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="5" class="MenuHead">
                                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" />
                                <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Orden</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBIdOrdenCompra" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Prioridad</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDTipoPrioridad" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Proveedor</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <WUCProv1:WucBusquedaProveedor ID="wucConProv" runat="server" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Observacion</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBObservacion" runat="server" Enabled="True" Height="30px" TextMode="MultiLine" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Almacen</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDDestino" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Estado</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDTipoOrdenEstado" runat="server" Enabled="False" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                            </div>
                        </div>
                    </div>
                    <asp:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Width="100%" Height="1125px" AutoSize="None">
                        <Panes>
                            <asp:AccordionPane ID="PanelSugerencia" runat="server" ContentCssClass="" HeaderCssClass="" Height="1125px">
                                <Header>Productos sugeridos</Header>
                                <Content>
                                    <table style="width: 100%; border-collapse: collapse;">
                                        <tr>
                                            <td class="Primer_Columna" colspan="5">
                                                <asp:Button ID="BTNConsultaSugererncia" runat="server" Text="Consultar" OnClick="BTNConsultaSugererncia_Click" /></td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="5">
                                                <div id="divProductoSugerencia" class="panel-body col-xs-12" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
                                                    <asp:GridView ID="GVProductoSugerencia" runat="server" CssClass="GridComun" GridLines="None" Style="margin: 0 auto;" Width="100%">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <PagerStyle CssClass="pgr" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>Ordenar</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNOrdenarSugerencia" runat="server" ForeColor="Blue" OnClick="BTNOrdenarSugerencia_OnClick" ShowSelectButton="True" Text="Ordenar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-CssClass="tooltip3">
                                                                <HeaderTemplate>Codigo</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%-- <%# Eval("IdProductoCorto")%>
                                                        <div id="divTablasTooltip3<%# Eval("IdProductoCorto")%>" class="tooltipContent3"></div>--%>
                                                                    <%# Eval("IdProductoCorto")%>
                                                                    <div id="<%# Eval("IdAlmacen")%>divTablasTooltip3<%# Eval("IdProductoCorto")%>" class="tooltipContent3"></div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>Producto</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Almacen" Visible="true" />
                                                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" SortExpression="PrecioUnitario" Visible="true" />
                                                            <asp:BoundField DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" Visible="true" />
                                                            <asp:BoundField DataField="Maximo" HeaderText="Maximo" SortExpression="Maximo" Visible="true" />
                                                            <asp:BoundField DataField="Minimo" HeaderText="Minimo" SortExpression="Minimo" Visible="true" />
                                                            <asp:BoundField DataField="Sugerido" HeaderText="Sugerido" SortExpression="Sugerido" Visible="true" />
                                                            <%-- <asp:TemplateField>
                                                            <HeaderTemplate>Ver Perfil</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BTNSeleccionar" runat="server" ForeColor="Blue" OnClick="BTNPerfil3_OnClick" ShowSelectButton="True" Text="Ver Perfil" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        </Columns>
                                                        <EmptyDataTemplate></div><label>Sin Productos</label></EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </asp:AccordionPane>
                            <asp:AccordionPane ID="PanelSolicitudes" runat="server" ContentCssClass="" HeaderCssClass="">
                                <Header>Productos solicitados</Header>
                                <Content>
                                    <table style="width: 100%; border-collapse: collapse;">
                                        <tr>
                                            <td class="Primer_Columna" colspan="5">
                                                <asp:Button ID="BTNConsultarSolicitudes" runat="server" Text="Consultar" /></td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="5">
                                                <div id="divSolicitud" class="panel-body col-xs-12" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
                                                    <asp:GridView ID="GVSolicitud" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top" CssClass="GridComun" GridLines="None" HorizontalAlign="Center" PagerStyle-CssClass="pgr" Style="margin: 0 auto;" Width="100%">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton ID="BTNOrdenarTodo" runat="server" ForeColor="SkyBlue" OnClick="BTNOrdenarTodo_OnClick" ShowSelectButton="True" Text="Ordenar Todo" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNOrdenar" runat="server" ForeColor="Blue" OnClick="BTNOrdenar_OnClick" ShowSelectButton="True" Text="Ordenar" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="BTNAutorizarTodo" runat="server" ForeColor="SkyBlue" OnClick="BTNAutorizarTodo_OnClick" ShowSelectButton="True" Text="Autorizar Todo" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BTNAutorizar" runat="server" ForeColor="Blue" OnClick="BTNAutorizar_OnClick" ShowSelectButton="True" Text="Autorizar" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="BTNEsperaTodo" runat="server" ForeColor="SkyBlue" OnClick="BTNEsperaTodo_OnClick" ShowSelectButton="True" Text="Espera Todo" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BTNEspera" runat="server" ForeColor="Blue" OnClick="BTNEspera_OnClick" ShowSelectButton="True" Text="Espera" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="BTNRechazarTodo" runat="server" ForeColor="SkyBlue" OnClick="BTNCancelarTodo_OnClick" ShowSelectButton="True" Text="Rechazar Todo" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BTNRechazar" runat="server" Checked="false" ForeColor="Blue" OnClick="BTNCancelar_OnClick" ShowSelectButton="True" Text="Rechazar" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                            <asp:BoundField DataField="IdSolicitud" HeaderText="ID" SortExpression="IdSolicitud" Visible="true" />
                                                            <asp:BoundField DataField="IdSolicitudDetalle" HeaderText="ID Detalle" SortExpression="IdSolicitudDetalle" Visible="true" />
                                                            <%--<asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />--%>
                                                            <asp:TemplateField ItemStyle-CssClass="tooltip2">
                                                                <HeaderTemplate>Codigo</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("IdProductoCorto")%>
                                                                    <div id="<%# Eval("IdSolicitudDetalle")%>divTablasTooltip2<%# Eval("IdProductoCorto")%>" class="tooltipContent2"></div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>Producto</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                                            <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Destino" Visible="true" />
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
                                                        <EmptyDataTemplate>
                                                            <label>Sin Solicitudes</label>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </asp:AccordionPane>
                            <asp:AccordionPane ID="PanelDetalleOrden" runat="server">
                                <Header>Productos de la orden</Header>
                                <Content>
                                    <asp:Panel ID="PARegistroDetalle" runat="server" Visible="True" Width="100%" Height="700px">

                                        <div class="container-fluid">
                                            <div class="col-xs-12 col-sm-3 col-md-1 col-lg-1">Producto</div>
                                            <div class="col-xs-12 col-sm-9 col-md-4 col-lg-4">
                                                <WUCP:wucConsultarProducto ID="wucConsultarProducto1" runat="server" />
                                            </div>
                                            <div class="col-xs-12 col-sm-3 col-md-1 col-lg-1">Cantidad </div>
                                            <div class="col-xs-12 col-sm-9 col-md-2 col-lg-2">
                                                <asp:TextBox ID="TBCantidadDetalle" runat="server" CssClass="form-control" OnTextChanged="ObtenerWucEstadisticas" AutoPostBack="true" />
                                                <asp:FilteredTextBoxExtender ID="FTBECantidadDetalle" runat="server" FilterType="Numbers" TargetControlID="TBCantidadDetalle" />
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
                                                <td colspan="4">
                                                    <asp:Button ID="BTNEliminarDetalle" runat="server" Text="Eliminar" /><asp:Button ID="BTNCancelarDetalle" runat="server" Text="Cancelar" Visible="false" /></td>
                                            </tr>
                                            <tr>
                                                <td>&#160;&nbsp</td>
                                            </tr>
                                        </table>
                                        <WUCE:wucEstadistica ID="wucEstadistica1" runat="server" />
                                        
                                            <asp:GridView ID="GVOrdenDetalle" Style="margin: 0 auto;" runat="server"
                                                CssClass="GridComun" GridLines="None" Width="100%">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>Eliminar</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="BTNSeleccionar" runat="server"
                                                                ForeColor="Blue" Text="Eliminar" ShowSelectButton="True" OnClick="BTNSeleccionar_OnClick" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-CssClass="tooltip">
                                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("IdProductoCorto")%>
                                                            <div id="divTablasTooltip<%# Eval("IdProductoCorto")%>" class="tooltipContent"></div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>Producto</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#  Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>Cantidad</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TBGVCantidad" runat="server" AutoPostBack="true" OnTextChanged="GVICantidad_TextChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>Precio Unitario</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TBGVPrecioUnitario" runat="server" AutoPostBack="true" OnTextChanged="GVIPrecio_TextChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" Visible="true" />
                                                    <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Almacen" Visible="true" />
                                                    <asp:BoundField DataField="TipoSolicitudEstado" HeaderText="Estado Solicitud" SortExpression="TipoSolicitudEstado" Visible="true" />
                                                    <%--<asp:TemplateField>
                                                                <HeaderTemplate>Ver Perfil</HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BTNPerfil" runat="server"
                                                                        ForeColor="Blue" Text="Ver Perfil" ShowSelectButton="True" OnClick="BTNPerfil_OnClick" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <label>Sin Productos</label>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                       
                                        <table>
                                            <tr>
                                                <td colspan="3" style="text-align: right">
                                                    <asp:Button ID="BTNSolicitudDetalle" runat="server" Text="Nuevo Detalle de Orden" OnClick="BTNSolicitudDetalle_Click" Visible="false" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                    <WUCPF:wucConsultarProductoPerfil ID="wucConsultarProductoPerfil1" runat="server" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td>
                                <asp:ImageButton ID="BTNRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" CssClass="Ocultar" />
                                <asp:ImageButton ID="BTNConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                    </table>
                    <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Orden</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBOrdenFiltro" runat="server" AutoPostBack="True" CssClass="form-control"/>
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
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioFiltro" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Al:</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBFechaFinFiltro" runat="server" Font-Bold="True" CssClass="form-control" AutoPostBack="True" />
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinFiltro" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Prioridad</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDPrioridadFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Estado</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDEstadoFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                    </div>
                    <div id="divConsulta" class="panel-body col-xs-12" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
                        <asp:GridView ID="GVConsulta" Style="margin: 0 auto;" runat="server" AllowPaging="false"
                            AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" Width="100%">
                        </asp:GridView>
                    </div>

                </asp:View>
                <asp:View ID="Imprimir" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="BTIRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" CssClass="Ocultar" />
                                <asp:ImageButton ID="BTNImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" CssClass="Ocultar" />
                            </td>
                        </tr>
                    </table>
                    <div id="TablaEncabezado">
                        <table>
                            <tr>
                                <td>IdOrdenCompra:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LIdOrdenCompra" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Estado:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LEstado" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Prioridad:&nbsp;&nbsp;&nbsp;&nbsp;

                                </td>
                                <td>
                                    <asp:Label ID="LPrioridad" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Nombre Proveedor:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LNombreProveedor" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Fecha:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LFecha" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="TablaImprimir">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr style="text-align: center;">
                                <td colspan="3">

                                    <asp:GridView ID="GVOrdenProducto" Style="margin: 0 auto;" runat="server" AllowPaging="false"
                                        Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style>
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

        .tooltip3 > div {
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

