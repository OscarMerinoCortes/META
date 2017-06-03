<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="SeguimientoSolicitud.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Hover1);
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
                var ids = tooltip[0].id.replace("divTablasTooltip", ",").split(",");
                var IdSolicitudDetalle = ids[0];
                var IdProducto = ids[1];
                $.ajax({
                    //primero es atravez de ajax hacer una llamada al metodo GetChart
                    type: "POST", //por post
                    url: "Compra.aspx/TablasTooltip", //este es el webmethod que esta en el .vb del aspx
                    data: "{idproducto: '" + IdProducto + "'}", //la variable que se recibe desde el load del .vb se envia como dato al webmethod
                    contentType: "application/json; charset=utf-8", //se´especifica el tipo de contenido
                    dataType: "json", // se especifica el tipo de dato devuelto
                    success: function (r) { //si la operacion es exitosa
                        var divTabla = IdSolicitudDetalle + "divTablasTooltip" + IdProducto;
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
    </script>
    <asp:UpdatePanel runat="server" ID="UPPromocion">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="4" class="MenuHead">
                                <asp:ImageButton ID="BTNConsultar2" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" Visible="False" />
                                <asp:ImageButton ID="IBTReporte" runat="server" ImageUrl="~/Imagenes/IMReporte.png" Visible="False" />
                                <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" Visible="False" />
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                    </table>
                    <div id="divBotonesConsultas" class="row">
                        <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                            <asp:Button runat="server" Text="Baja" CssClass="btn btn-primary" ID="BTNBaja" />
                            <asp:Button runat="server" Text="Media" CssClass="btn btn-primary" ID="BTNMedia" />
                            <asp:Button runat="server" Text="Alta" CssClass="btn btn-primary" ID="BTNAlta" />
                            <asp:Button runat="server" Text="Todo" CssClass="btn btn-primary" ID="BTNTodo" />
                            <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" ID="BTNAvanzado" />
                        </div>
                    </div>
                    <div class="row" runat="server" id="divAvanzado" style="padding-right: 20px;">
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding-right: 0;">
                            <div class="input-group">
                                <label class="input-group-addon" style="padding: 0px;">Solicitud</label>
                                <asp:TextBox ID="TBSolicitud" runat="server" AutoPostBack="True" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Destino</span>
                                <asp:DropDownList ID="DDDestino" runat="server" AutoPostBack="True" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Clasificación</span>
                                <asp:DropDownList ID="DDClasificacion" runat="server" AutoPostBack="True" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Subclasificación</span>
                                <asp:DropDownList ID="DDSubclasificacion" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Prioridad</span>
                                <asp:DropDownList ID="DDPrioridad" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Estado</span>
                                <asp:DropDownList ID="DDEstado" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Del </span>
                                <asp:TextBox ID="TBFechaInicio" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" CssClass="form-control" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Al</span>
                                <asp:TextBox ID="TBFechaFin" runat="server" Font-Bold="True" CssClass="form-control" AutoPostBack="True" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                            </div>
                        </div>
                        <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Consultar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" ID="BTNConsultar" />
                        </div>
                    </div>
                  
                        <asp:GridView ID="GVSolicitud" Style="margin: 0 auto;" runat="server" CssClass="GridComun"
                            GridLines="None" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top"
                            HorizontalAlign="Center" PagerStyle-CssClass="pgr" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="BTNAutorizarTodo" runat="server" AutoPostBack="true" ForeColor="SkyBlue"
                                            Text="Autorizar Todo" ShowSelectButton="True" OnClick="BTNAutorizarTodo_OnClick" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BTNAutorizar" runat="server" AutoPostBack="true"
                                            ForeColor="Blue" Text="Autorizar" ShowSelectButton="True" OnClick="BTNAutorizar_OnClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="BTNEsperaTodo" runat="server" Text="Espera Todo" ShowSelectButton="True"
                                            AutoPostBack="true" ForeColor="SkyBlue" OnClick="BTNEsperaTodo_OnClick" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BTNEspera" runat="server" AutoPostBack="true"
                                            ForeColor="Blue" Text="Espera" ShowSelectButton="True" OnClick="BTNEspera_OnClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="BTNRechazarTodo" runat="server" Text="Rechazar Todo" ShowSelectButton="True"
                                            AutoPostBack="true" ForeColor="SkyBlue" OnClick="BTNRechazarTodo_OnClick" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BTNRechazar" runat="server" AutoPostBack="true" Checked="false"
                                            ForeColor="Blue" Text="Rechazar" ShowSelectButton="True" OnClick="BTNRechazar_OnClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdSolicitudDetalle" HeaderText="ID" SortExpression="IdSolicitudDetalle" Visible="true" />
                                <%--<asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />--%>
                                <asp:TemplateField ItemStyle-CssClass="tooltip">
                                    <HeaderTemplate>Codigo</HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("IdProductoCorto")%>
                                        <div id="<%# Eval("IdSolicitudDetalle")%>divTablasTooltip<%# Eval("IdProductoCorto")%>" class="tooltipContent"></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Producto
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Comun.Presentacion.StringTruncado.Truncar(Convert.ToString(Eval("Producto")), 30) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Cantidad
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="GVTBCantidad" Text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' Width="50"
                                            runat="server" AutoPostBack="true" OnTextChanged="GVICantidad_TextChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Almacen" Visible="true" />
                                <asp:BoundField DataField="TipoSolicitudEstado" HeaderText="Estado" SortExpression="TipoSolicitudEstado" Visible="true" />
                                <asp:BoundField DataField="TipoPrioridad" HeaderText="Prioridad" SortExpression="TipoPrioridad" Visible="true" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" Visible="true" />
                            </Columns>
                        </asp:GridView>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <style>
        .tooltip {
            position: relative;
        }

            .tooltip > div {
                display: none;
                position: absolute;
                left: 50%;
                margin-left: 30px;
                width: 1000%;
                top: -3px;
            }

        .tooltipContent {
            position: absolute;
            background-color: #eee;
            border: 1px solid #555;
            border-radius: 5px;
            padding: 5px;
            z-index: 99999;
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
