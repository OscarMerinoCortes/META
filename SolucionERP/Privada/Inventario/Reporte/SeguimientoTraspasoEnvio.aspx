<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" MaintainScrollPositionOnPostback="true" CodeFile="SeguimientoTraspasoEnvio.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.4.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="container-fluid">
                <div id="divBotonesPrincipales" class="row">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="3" class="MenuHead">
                                <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png" OnClientClick="window.print()" />
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divBotonesConsultas" class="row">
                    <div class="btn-group" style="margin-bottom: 2px; margin-top: 2px; margin-left: 10px;">
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Hoy&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNHoy_Click" />
                        <asp:Button runat="server" Text="Esta Semana" CssClass="btn btn-primary" OnClick="BTNSemana_Click"/>
                        <asp:Button runat="server" Text="Este Mes" CssClass="btn btn-primary" OnClick="BTNMes_Click"/>
                        <asp:Button runat="server" Text="Este Año" CssClass="btn btn-primary" OnClick="BTNAno_Click"/>
                        <asp:Button runat="server" Text="Avanzado" CssClass="btn btn-primary" OnClick="BTNAvanzado_Click"/>
                    </div>
                </div>
                <div class="row" runat="server" id="divAvanzado" style="padding-right: 20px;">                  
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
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
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
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNAvanzadoConsultar_Click" />
                    </div>
                </div>
                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                    <div id="divconsulta" class="panel-body col-xs-12" style="overflow: auto; padding: 0; font-size: medium; text-align: center;">
                        <asp:GridView ID="GVSolicitud" Style="margin: 0 auto;" runat="server" CssClass="GridComun"
                            GridLines="None" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CaptionAlign="Top"
                            HorizontalAlign="Center" PagerStyle-CssClass="pgr" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="IdEntrega" HeaderText="ID" SortExpression="IdEntrega" Visible="true" />
                                <asp:BoundField DataField="IdProductoCorto" HeaderText="Codigo" SortExpression="IdProductoCorto" Visible="true" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" Visible="true" />
                                <asp:BoundField DataField="AlmacenOrigen" HeaderText="Origen" SortExpression="Origen" Visible="true" />
                                <asp:BoundField DataField="AlmacenDestino" HeaderText="Destino" SortExpression="Destino" Visible="true" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" Visible="true" />
                                <asp:BoundField DataField="Estatus" HeaderText="Estado" SortExpression="Estatus" Visible="true" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" Visible="true" />
                            </Columns>
                            <EmptyDataTemplate>
                                <label>Sin coincidencia</label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>                    
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style9 {
            width: 380px;
        }
        .auto-style12 {
            width: 26px;
        }
    </style>
</asp:Content>

