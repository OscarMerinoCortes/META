<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="SolicitudCompra.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucBusqueda.ascx" TagName="wucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Wuc/wucConsultarProductoPerfil.ascx" TagName="wucConsultarProductoPerfil" TagPrefix="WUCPF" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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
                    </table>
                    <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Solicitud</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBIdSolicitudCompra" runat="server" Enabled="False" CssClass="form-control" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Prioridad</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDTipoPrioridad" runat="server" AutoPostBack="True" CssClass="form-control"/>
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Almacen</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:DropDownList ID="DDAlmacen" runat="server" AutoPostBack="True" CssClass="form-control"/>
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Observacion</div>
                            <div class="col-xs-12 col-sm-11 col-md-3 col-lg-3">
                                <asp:TextBox ID="TBObservacion" runat="server" Enabled="True" Height="30px" TextMode="MultiLine" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1 ">Estado</div>
                            <div class="col-xs-12 col-sm-11 col-md-7 col-lg-7">
                                <asp:DropDownList ID="DDTipoSolicitudEstado" runat="server" Enabled="False" CssClass="form-control" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12">
                                <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                            </div>
                        </div>
                    </div>
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="5" style="background-color: #bbbbbb;">&nbsp;&nbsp;&nbsp;Productos de la solicitud </td>
                        </tr>
                    </table>
                    <asp:Panel ID="PARegistroDetalle" runat="server" Width="100%" BackColor="#FDFDFD" Visible="True">
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Producto</div>
                            <div class="col-xs-12  col-sm-5">
                                <WUCP:wucConsultarProducto ID="wucConsultarProducto1" runat="server" />
                            </div>
                            <div class="col-xs-12 col-sm-1">Cantidad </div>
                            <div class="col-xs-12  col-sm-4">
                                <asp:TextBox ID="TBCantidad" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RFVCantidad" runat="server" ControlToValidate="TBCantidad"
                                    ErrorMessage="&lt;strong>Información requerida</strong> La cantidad es Obligatoria" Display="None" ValidationGroup="Guardar2"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCECantidad" runat="server" TargetControlID="RFVCantidad"></asp:ValidatorCalloutExtender>
                                <%--  linea no permite teclear letras solo numeros--%>
                                <asp:FilteredTextBoxExtender ID="FTBECPColonia" runat="server" FilterType="Numbers" TargetControlID="TBCantidad" />
                            </div>
                            <div class="col-xs-12  col-sm-1">
                                <asp:Button ID="BTNAceptarDetalle" runat="server" Text="Aceptar" ValidationGroup="Guardar2" />
                            </div>
                        </div>

                    </asp:Panel>
                   <%-- <div class="container-fluid" >--%>
                        <div id="divconsultamodulo" class="panel-body col-xs-12" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
                        <asp:GridView ID="GVSolicitudDetalle" Style="margin: 0 auto;" runat="server"
                            CssClass="GridComun" GridLines="None" AutoGenerateColumns="false" Width="100%">
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Eliminar
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BTNSeleccionarSolicitudDetalle" runat="server" Checked="false"
                                            ForeColor="Blue" Text="Eliminar" ShowSelectButton="True" OnClick="BTNSeleccionarSolicitudDetalle_Click1" />
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
                                    <HeaderTemplate>Cantidad</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBGVCantidad" runat="server" AutoPostBack="true" OnTextChanged="GVICantidad_TextChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Almacen" HeaderText="Destino" SortExpression="Destino" Visible="true" />
                                <asp:BoundField DataField="TipoSolicitudEstado" HeaderText="Estado" SortExpression="TipoSolicitudEstado" Visible="true" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Ver Perfil
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BTNPerfil" runat="server"
                                            ForeColor="Blue" Text="Ver Perfil" ShowSelectButton="True" OnClick="BTNPerfil2_OnClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Button ID="BTNSolicitudDetalle" runat="server" Text="Nuevo Detalle de Solicitud" OnClick="BTNSolicitudDetalle_Click" Visible="False" />
                    <WUCPF:wucConsultarProductoPerfil ID="wucConsultarProductoPerfil1" runat="server" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td />
                            <td colspan="4">
                                <asp:ImageButton ID="BTNRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                                <asp:ImageButton ID="BTNConsultarSolicitud" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp;</td>
                        </tr>
                    </table>
                    <div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Solicitud</div>
                            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                                <asp:TextBox ID="TBSolicitudFiltro" runat="server" AutoPostBack="True" CssClass="form-control"/>
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Prioridad</div>
                            <div class="col-xs-12 col-sm-11 col-md-4 col-lg-4">
                               <asp:DropDownList ID="DDPrioridadFiltro" runat="server" AutoPostBack="True" CssClass="form-control"/>
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1">Del:</div>
                            <div class="col-xs-12 col-sm-11 col-md-2 col-lg-2">
                                <asp:TextBox ID="TBFechaInicioFiltro" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" CssClass="form-control" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioFiltro" />
                            </div>
                            <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">Al:</div>
                            <div class="col-xs-12 col-sm-11 col-md-4 col-lg-4">
                                <asp:TextBox ID="TBFechaFinFiltro" runat="server" Font-Bold="True" CssClass="form-control" AutoPostBack="True" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinFiltro" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                        <div class="container-fluid">
                            <div class="col-xs-12 col-sm-1 ">Estado</div>
                            <div class="col-xs-12 col-sm-11 col-md-7 col-lg-7">
                                <asp:DropDownList ID="DDEstadoFiltro" runat="server" CssClass="form-control" AutoPostBack="True" />
                            </div>
                            <div class="col-md-4 col-lg-4"></div>
                        </div>
                    </div>
                    
                                <div id="divconsulta" class="panel-body col-xs-12" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
                                <asp:GridView ID="GVConsulta" Style="margin: 0 auto;" runat="server" AllowPaging="false" Width="100%"
                                    AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                                </asp:GridView>
                                    </div>
                            
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            min-width: 1%;
            max-width: 1%;
            height: 27px;
        }
        .auto-style2 {
            min-width: 28%;
            max-width: 28%;
            height: 27px;
        }
        .auto-style3 {
            height: 27px;
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



