<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteMovimientoInventario.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../../../../CSS/Imprimir.css" type="text/css" media="print"/>
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

                    <div class="col-xs-3 col-sm-3 col-md-2 col-lg-2" style="padding-right: 0;">
                        <div class="col-xs-3 col-sm-3 col-md-2 col-lg-2" style="padding-right: 0;">
                            <label class="input-group-addon" style="padding: 0px;">ID</label>
                            <asp:TextBox ID="TBID" runat="server" CssClass="form-control" Style="text-align: right;" Width="150px" AutoPostBack="True" />
                        </div>
                         <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Fecha de Inicio</span>
                            <asp:TextBox ID="TBDe" runat="server" Font-Bold="True" AutoPostBack="True" Font-Strikeout="False" Width="150px" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBDe" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Fecha de Fin</span>
                            <asp:TextBox ID="TBAl" runat="server" Font-Bold="True" Width="150" AutoPostBack="True" CssClass="form-control" Style="text-align: right;" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBAl" />
                        </div>
                         <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Estado</span>
                            <asp:DropDownList ID="DDEstado" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Tipo Movimiento</span>
                            <asp:DropDownList ID="DDTipo" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl; top: 0px; right: 0px;" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Subtipo Movimiento</span>
                            <asp:DropDownList ID="DDSubTipo" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>                       
                    </div> 
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Sucursal Origen</span>
                            <asp:DropDownList ID="DDSucursalOrigen" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Almacen Origen</span>
                            <asp:DropDownList ID="DDAlmacenOrigen" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>
                    </div>               
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Sucursal Destino</span>
                            <asp:DropDownList ID="DDSucursalDestino" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>
                         <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Almacen Destino</span>
                            <asp:DropDownList ID="DDAlmacenDestino" runat="server" Width="155px" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>
                    </div>                                  
                     <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        
                    </div>
                                       
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                       
                    </div>                  
                    <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNAvanzadoConsultar_Click" />
                    </div>
                </div>
                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                    <div id="divconsulta" class="panel-body col-xs-12" style="overflow: auto; padding: 0; font-size: medium; text-align: center;">
                        <asp:GridView Width="100%" ID="GVReporteMovimientoInventario" runat="server"
                            BorderColor="#385c81"                          
                            AllowSorting="true"
                            CellPadding="4"
                            AlternatingRowStyle-CssClass="alt"
                            CssClass="GridComun table table-responsive"
                            GridLines="None"
                            PagerStyle-CssClass="pgr"
                            Style="margin: 0 auto; text-align: center;">
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
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        
        .auto-style13 {
            padding: 0px;
            margin: 0px;
            border: 0px solid #C0C0C0;
            background-image: url('../../../Imagenes/IMFondo.png');
            background-repeat: repeat-x;
            border-spacing: 0px;
            border-collapse: collapse;
            height: 21px;
        }
        .auto-style14 {
            width: 157px
        }
        .auto-style15 {
            width: 1537px;
        }
    </style>
</asp:Content>

