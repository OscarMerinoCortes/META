<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="MovimientoInventario.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WucBusqueda.ascx" TagName="wucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
    <asp:UpdatePanel runat="server" ID="UPPromocion">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%; border-collapse: collapse; height: 40px;">                 
                        <tr>
                            <td colspan="5" class="MenuHead">

                                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                                <asp:ImageButton ID="IBTAplicar" runat="server" ImageUrl="~/Imagenes/IMAplicar.png" Visible="False" />
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" />
                                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                                <asp:ImageButton ID="IBTPendientes" runat="server" ImageUrl="~/Imagenes/EnTransito.png" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" Style="width: 143px" />
                                <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="auto-style151" />
                            <td class="auto-style149"></td>
                            <td class="auto-style141"></td> 
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style151">Id de Movimiento
                            </td>
                            <td class="auto-style149" >
                                <asp:TextBox ID="TBIdMovimientoInventario" runat="server" Enabled="False" Width="155px"></asp:TextBox>
                            </td>
                            <td class="auto-style141"></td>
                            <td class="auto-style140"></td> 
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style151" >Tipo
                            </td>
                            <td class="auto-style149"  >
                                <asp:DropDownList ID="DDTipo" runat="server" AutoPostBack="true" Width="155px">
                                </asp:DropDownList>
                            </td>
                             <td class="auto-style141">Estado </td>
                            <td class="auto-style140">
                                <asp:DropDownList ID="DDEstado" runat="server" Width="155px">
                                </asp:DropDownList>
                            </td>                            
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style151" >SubTipo
                            </td>
                            <td class="auto-style149" >
                                <asp:DropDownList ID="DDSubTipo" runat="server" AutoPostBack="true" Height="22px" Width="155px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style141" >Observación</td>
                            <td class="auto-style140">
                                <asp:TextBox ID="TBObservacion" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                            </td> 
                        </tr>
                        <tr>
                            <td  />
                            <td class="auto-style151" >Almacén Origen</td>
                            <td class="auto-style149" >
                                <asp:DropDownList ID="DDAlmacenOrigen" runat="server" AutoPostBack="true" Height="22px" Width="155px">
                                </asp:DropDownList>
                            </td>   
                            <td class="auto-style141">&nbsp;</td>
                             <td class="auto-style140" >
                                 &nbsp;</td>
                            <td >
                                &nbsp;</td>                         
                        </tr>
                        <tr>                        
                            <td  />
                           <td class="auto-style151" >Almacén Destino 
                           </td>
                            <td class="auto-style149"  >
                                <asp:DropDownList ID="DDAlmacenDestino" runat="server" AutoPostBack="true" Height="22px" Width="155px">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style141">&nbsp;</td>
                            <td class="auto-style140" >
                                &nbsp;</td>
                        </tr>                           
                        <tr>    
                            <td />
                            <td colspan="5">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" style="width: 100%;" />
                            </td>                         
                        </tr>
                       </table>
                                <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent"
                                 CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                                    Width="100%" Height="1985px">
                                    <Panes>
                                        <ajaxToolkit:AccordionPane ID="PanelProductos" runat="server" ContentCssClass="" HeaderCssClass="">
                                            <Header>Productos del Movimiento</Header>
                                            <Content>
                                                 <asp:Panel ID="PADetalle" runat="server" Width="100%" BackColor="#FDFDFD" Visible="True" Height="350px">
                                                     
                                                                 <asp:Panel ID="PAProductos" runat="server" BackColor="#FDFDFD" Width="100%">
                                                                     <table  style="width: 100%; border-collapse: collapse; height: 40px;" >
                                                                         <tr>
                                                                             <td>
                                                                                 <WUCP:wucConsultarProducto ID="wucConsultarProducto" runat="server" />
                                                                             </td>
                                                                             <td class="auto-style115">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cantidad&nbsp;&nbsp;&nbsp;</td>
                                                                             <td>
                                                                                 <asp:TextBox ID="TBCantidad" runat="server" Width="150"></asp:TextBox>
                                                                                 <asp:FilteredTextBoxExtender ID="FTBECantidad" runat="server" FilterType="Numbers" TargetControlID="TBCantidad" />
                                                                                 <asp:Button ID="BTNAgregar" runat="server" Text="Agregar" />
                                                                             </td>
                                                                         </tr>
                                                                         <tr>
                                                                             <td>&nbsp;</td>
                                                                             <td class="auto-style115">&nbsp;</td>
                                                                             <td>&nbsp;</td>
                                                                         </tr>
                                                                         <tr style="text-align: center;">
                                                                             <td colspan="3">
                                                                                 <asp:GridView ID="GVInventario" runat="server" CssClass="GridComun" GridLines="None" Style="margin: 0 auto;" Width="100%">
                                                                                     <Columns>
                                                                                         <asp:TemplateField>
                                                                                             <HeaderTemplate>
                                                                                                 Eliminar
                                                                                             </HeaderTemplate>
                                                                                             <ItemTemplate>
                                                                                                 <asp:LinkButton ID="BTNEliminar" runat="server" ForeColor="Blue" OnClick="BTNEliminar_OnClick" ShowSelectButton="True" Text="Eliminar" />
                                                                                             </ItemTemplate>
                                                                                         </asp:TemplateField>
                                                                                         <asp:BoundField DataField="IdInventarioMovimientoDetalle" HeaderText="IdInventarioMoviientoDetalle" SortExpression="ID" Visible="false" />
                                                                                         <asp:BoundField DataField="IdInventarioMovimiento" HeaderText="IdInventarioMovimiento" SortExpression="ID" Visible="false" />
                                                                                         <asp:BoundField DataField="IdProducto" HeaderText="ID" SortExpression="ID" Visible="false" />
                                                                                         <asp:BoundField DataField="IdProductoCorto" HeaderText="Código" SortExpression="IDCorto" />
                                                                                         <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                                                                         <asp:TemplateField HeaderText="Cantidad">
                                                                                             <ItemTemplate>
                                                                                                 <asp:TextBox ID="TBCantidadActualizar" runat="server" AutoPostBack="true" OnTextChanged="TBCantidadActualizarItem_TextChanged" Text='<%# DataBinder.Eval(Container.DataItem, "Cantidad")%>' Visible="true"></asp:TextBox>
                                                                                             </ItemTemplate>
                                                                                         </asp:TemplateField>
                                                                                         <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" SortExpression="IdEstado" Visible="false" />
                                                                                         <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                                                                     </Columns>
                                                                                     <EmptyDataTemplate>
                                                                                         <label>
                                                                                             Sin productos</label>
                                                                                     </EmptyDataTemplate>
                                                                                 </asp:GridView>
                                                                             </td>
                                                                         </tr>
                                                                     </table>
                                                                 </asp:Panel>
                                                             
                                                     </asp:Panel>
                                            </Content>
                                        </ajaxToolkit:AccordionPane>
                                    </Panes>
                                </ajaxToolkit:Accordion>
                          
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td colspan="4" class="MenuHead">
                                <asp:ImageButton ID="BTNRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                            </td>
                        </tr>
                     </table>
                    <div id="divBotonesConsultas" class="row">
                        <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNHoy_Click" />
                            <asp:Button runat="server" Text="Esta Semana" CssClass="btn btn-primary" OnClick="BTNSemana_Click" />
                            <asp:Button runat="server" Text="Este Mes" CssClass="btn btn-primary" OnClick="BTNMes_Click" />
                            <asp:Button runat="server" Text="Este Año" CssClass="btn btn-primary" OnClick="BTNAno_Click" />
                            <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" OnClick="BTNAvanzado_Click" />
                        </div>
                    </div>
                    <div class="row" runat="server" id="divAvanzado" style="padding-right: 20px;">                 
                         <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Almacen</span>
                                <asp:DropDownList ID="DDAlmacenBusq" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Estado</span>
                                <asp:DropDownList ID="DDEstadoBusq" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Fecha de Inicio</span>
                                <asp:TextBox ID="TBFechaInicio" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" Width="150px" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Fecha de Fin</span>
                                <asp:TextBox ID="TBFechaFin" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" Width="150px" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                            </div>
                        </div>
                        <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNAvanzadoConsultar_Click" />
                        </div>                       
                    </div>
                    <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                        <div id="divconsulta" class="panel-body col-xs-12" style="overflow: auto; padding: 0; font-size: medium; text-align: center;">
                            <asp:GridView ID="GridView1" Width="100%" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                            </asp:GridView>
                        </div>
                    </div>
                </asp:View>

                <asp:View ID="View3" runat="server">
                    <div id="divBotonesPrincipales2" class="row">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2" class="MenuHead">
                                    <asp:ImageButton ID="BTNRegresarPendiente" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divBotonesConsultas2" class="row">
                    <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNHoy2_Click" />
                        <asp:Button runat="server" Text="Esta Semana" CssClass="btn btn-primary" OnClick="BTNSemana2_Click"/>
                        <asp:Button runat="server" Text="Este Mes" CssClass="btn btn-primary" OnClick="BTNMes2_Click"/>
                        <asp:Button runat="server" Text="Este Año" CssClass="btn btn-primary" OnClick="BTNAno2_Click"/>
                        <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" OnClick="BTNAvanzado2_Click"/>
                    </div>
                </div>
                    <div class="row" runat="server" id="divAvanzado2" style="padding-right: 20px;">
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Almacen Origen</span>
                                <asp:DropDownList ID="DDAlmacenOrigenPendiente" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Almacen Destino</span>
                                <asp:DropDownList ID="DDAlmacenDestinoPendiente" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                            </div>
                        </div>
                         <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Estatus</span>
                                <asp:DropDownList ID="DDEstatus" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Fecha de Inicio</span>
                                <asp:TextBox ID="TBFechaInicioPendiente" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" Width="150px" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioPendiente" />
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                            <div class="input-group">
                                <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Fecha de Fin</span>
                                <asp:TextBox ID="TBFechaFinPendiente" runat="server" Font-Bold="True" Width="150" AutoPostBack="True" CssClass="form-control" Style="text-align: right;" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinPendiente" />
                            </div>
                        </div>
                        <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                            <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNAvanzadoConsultar2_Click" />
                        </div>
                    </div>                 
                      <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                          <div id="divconsulta2" class="panel-body col-xs-12" style="overflow: auto; padding: 0; font-size: medium; text-align: center;">
                              <asp:GridView ID="GVSolicitud" Style="margin: 0 auto;" runat="server" CssClass="GridComun"
                                    GridLines="None" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top"
                                    PagerStyle-CssClass="pgr" Width="100%" HorizontalAlign="center">
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
                                        <asp:BoundField DataField="IdEntrega" HeaderText="ID Entrega" SortExpression="IdEntrega" Visible="true" />
                                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" SortExpression="IdProducto" Visible="true" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" Visible="true" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>Recibí</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="GVTBCantidad" Text='NA' Width="50"
                                                    runat="server" AutoPostBack="true" OnTextChanged="GVICantidad_TextChanged"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CantidadFaltante" HeaderText="Cantidad Faltante" SortExpression="CantidadFaltante" Visible="true" />
                                        <asp:BoundField DataField="AlmacenOrigen" HeaderText="Alm. Origen" SortExpression="AlmacenOrigen" Visible="true" />
                                        <asp:BoundField DataField="AlmacenDestino" HeaderText="Alm. Destino" SortExpression="AlmacenDestino" Visible="true" />
                                        <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" Visible="true" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" Visible="true" />
                                    </Columns>
                                </asp:GridView>
                              </div>
                          </div>                                 
                </asp:View>
                <asp:View ID="View4" runat="server">
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
                                <td>Id Movimiento Inventario:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LIdMovimientoInventario" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Fecha:&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="LFecha" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Observacion:&nbsp;&nbsp;&nbsp;&nbsp;

                                </td>
                                <td>
                                    <asp:Label ID="LBObservacion" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Sucursal Origen:&nbsp;&nbsp;&nbsp;&nbsp; 
                                </td>
                                <td>
                                    <asp:Label ID="LSucursalOrigen" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Almacen Origen:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LAlmacenOrigen" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Tipo:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LTipo" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Sub Tipo:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td>
                                    <asp:Label ID="LSubTipo" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LSucursalDestinoP" runat="server" Text="Sucursal Destino"></asp:Label>:</td>
                                <td>
                                    <asp:Label ID="LSucursalDestino" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LAlmacenDestinoP" runat="server" Text="Almacen Destino"></asp:Label>:</td>
                                <td>
                                    <asp:Label ID="LAlmacenDestino" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="TablaImprimir">
                        <table style="width: 100%; border-collapse: collapse;">
                            <tr style="text-align: center;">
                                <td colspan="3">

                                    <asp:GridView ID="GVImprimirMovimiento" Style="margin: 0 auto;" runat="server" AllowPaging="false"
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
    <style type="text/css">
        
        }

        .Ocultar {
            height: 30px;
        }

        .auto-style140 {
            width: 1501px;
        }
        .auto-style141 {
            width: 202px;
        }
        .auto-style149 {
            width: 342px;
        }
        .auto-style151 {
            width: 240px;
        }
        </style>
</asp:Content>

