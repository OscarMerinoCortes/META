<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="RegistroInventario.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucBusqueda.ascx" TagName="wucConsultarProducto" TagPrefix="WUCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" Style="height: 30px" ValidationGroup="Guardar" />
                        <asp:ImageButton ID="IBTAplicar" runat="server" ImageUrl="~/Imagenes/IMAplicar.png" ValidationGroup="Guardar"/>
                        <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" ValidationGroup="Guardar" />
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><strong>Datos Generales</strong></td>
                </tr>
                <tr>
                    <td class="auto-style17" >ID

                    </td>
                    <td >
                        <asp:TextBox ID="TBIdInventario" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td class="auto-style17">Descripción</td>
                    <td>
                        <asp:TextBox ID="TBDescripcion" runat="server" Enabled="True" Width="150px" style="margin-left: 0px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TBDescripcion"
                            ErrorMessage="&lt;strong>Información requerida</strong> Descripción Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"></asp:ValidatorCalloutExtender>                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" >Observación

                    </td>
                    <td class="auto-style8" >
                        <asp:TextBox ID="TBObservaciones" runat="server" Width="300px" Height="50px" TextMode="MultiLine" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVObservaciones" runat="server" ControlToValidate="TBObservaciones"
                            ErrorMessage="&lt;strong>Información requerida</strong> Observación Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEObservaciones" runat="server" TargetControlID="RFVObservaciones"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>                    
                    <td colspan="2">
                       <WUCDA:wucDatosAuditoria Visible="false" ID="wucDatosAuditoria1" runat="server" />
                    </td>                    
                </tr>
                <tr>
                    <td colspan="2"><strong>&nbsp;&nbsp;&nbsp; Detalles de Inventario</strong></td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="auto-style17" >&nbsp; Sucursal

                    </td>
                    <td >
                        <asp:DropDownList ID="DDSucursal" runat="server" Width="155px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">&nbsp; Almacén</td>
                    <td>
                        <asp:DropDownList ID="DDAlmacen" runat="server" Width="155px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">&nbsp;</td>
                    <td>
                        <asp:Button ID="BTNConsultar" runat="server" Style="height: 26px" Text="Consultar" />
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="auto-style17" >&nbsp; Clasificación 
                    </td>
                    <td >
                        <asp:DropDownList ID="DDClasificacion" runat="server" Height="22px" Width="128px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr  runat="server" visible="false">
                    <td class="auto-style17">&nbsp; SubClasificación</td>
                    <td>
                        <asp:DropDownList ID="DDSubClasificacion" runat="server" Height="22px" Width="128px" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                        <WUCP:wucConsultarProducto ID="wucConsultarProducto" runat="server" />
                        &nbsp;
                        <asp:Button ID="BTNAgregar" runat="server" Text="Agregar" />
                    </td>                    
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:GridView Width="100%" ID="GVInventario" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Style="margin: 0 auto;">
                            <Columns>
                                <%--<asp:CommandField ButtonType="Link" HeaderText="" SelectText="Seleccionar" ShowSelectButton="true" /> --%>
                                <asp:BoundField DataField="IdProducto" HeaderText="Id Producto" SortExpression="ID" />
                                <asp:BoundField DataField="IdProductoCorto" HeaderText="Id Corto" SortExpression="IdProductoCorto" />
                                <asp:BoundField DataField="DescripcionProducto" HeaderText="Descripción" SortExpression="Descripcion" />
                                <asp:BoundField DataField="CantidadSistema" HeaderText="Cantidad Sistema" SortExpression="Cantidad" />
                                <asp:TemplateField HeaderText="Cantidad Real">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBCantidad" runat="server" AutoPostBack="true" OnTextChanged="TBCantidadItem_TextChanged" Text='<%# DataBinder.Eval(Container.DataItem, "CantidadReal")%>' Visible="true"></asp:TextBox>                              
                                         <asp:RegularExpressionValidator Display="none" ID="REVCantidad" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ControlToValidate="TBCantidad"></asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="VCEERCantidad" runat="server" TargetControlID="REVCantidad"></asp:ValidatorCalloutExtender>                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Diferencia">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBDiferencia" runat="server" AutoPostBack="true" Enabled="false" Text='<%# DataBinder.Eval(Container.DataItem, "Diferencia")%>' Visible="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdActualizar" HeaderText="IdActualizar" SortExpression="IdActualizar" Visible="false" />
                                <asp:BoundField DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            </Columns>
                            <EmptyDataTemplate>
                                <label>Sin productos</label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
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
                    <asp:GridView ID="GridView1" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" Width="100%">
                        </asp:GridView>
                </div>
            </div>                                                    
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style4 {
            width: 122px;
        }
        .auto-style7 {
            width: 127px;
            height: 61px;
        }
        .auto-style8 {
            height: 61px;
        }
        .auto-style16 {
            width: 199px;
        }
        .auto-style17 {
            width: 127px;
        }
    </style>
</asp:Content>

