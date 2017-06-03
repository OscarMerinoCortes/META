<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="ReporteCXC.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%--<%@ Register Src="~/Wuc/WucBusquedaCliente.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <script src="../../../Scripts/Imprimir.js"></script>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="container-fluid">
                <div id="divBotonesPrincipales" class="row">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="4" class="MenuHead">
                                <asp:ImageButton ID="IBTExportar" runat="server" ImageUrl="~/Imagenes/IMExportar.png" />
                                <asp:ImageButton ID="IBTImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimirHab.png"/>
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                    </table>
                </div>
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
                              <WUCP:WucConsultarPersona ID="wucConPer" runat="server" />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px; text-align: right;">Estado</span>
                            <asp:DropDownList ID="DDEstado" runat="server" AutoPostBack="True" CssClass="form-control" Style="direction: rtl;" />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px;"><span class="visible-xs">Inicio</span><span class="hidden-xs">Fecha Inicio</span></span>
                            <asp:TextBox ID="TBFechaInicio" runat="server" AutoPostBack="True" CssClass="form-control" Style="text-align: right;" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicio" />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-4 col-lg-4" style="padding: 0;">
                        <div class="input-group">
                            <span class="input-group-addon" style="padding-right: 5px;"><span class="visible-xs">Fin</span><span class="hidden-xs">Fecha Fin</span></span>
                            <asp:TextBox ID="TBFechaFin" runat="server" AutoPostBack="True" CssClass="form-control" Style="text-align: right;" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFin" />
                        </div>
                    </div>
                    <div class="col-xs-12" style="padding-top: 5px; text-align: right; padding-right: 0;">
                        <asp:Button runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;Buscar&nbsp;&nbsp;&nbsp;&nbsp;" CssClass="btn btn-primary" OnClick="BTNAvanzadoConsultar_Click" />
                    </div>
                </div>

                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                    <div id="divconsulta" class="panel-body col-xs-12" style="overflow: auto; height: 290px; padding: 0; font-size: medium; text-align: center;">
                        <asp:GridView ID="GVCompra" Style="margin: 0 auto;" runat="server" AutoGenerateColumns="false"
                            AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%" 
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None">
                            <EmptyDataTemplate>
                                <label>Sin coincidencia</label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <div class="col-xs-12" style="text-align: right; background-color: #001f40; color: white; height: 30px; padding-top: 0px;">
                        <asp:Label runat="server" Font-Size="12" ID="LBCantidadBusqueda"></asp:Label>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <script>
       Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
       function endReq(sender, args) {
           comprobarTamano();
       }
       $(window).resize(function () {
           comprobarTamano();
       });
       $(document).ready(function () {
           comprobarTamano();
       });
       function comprobarTamano() {
           var alto = $(window).height();
           var altoContenidoFiltro = 0;
           var altoBotonesPrincipales = 0;
           var altoBotonesConsultas = 0;
           if (document.getElementById('MainContent_divAvanzado'))
               altoContenidoFiltro = $("#MainContent_divAvanzado").height();
           if (document.getElementById('divBotonesPrincipales'))
               altoBotonesPrincipales = $("#divBotonesPrincipales").height();
           if (document.getElementById('divBotonesConsultas'))
               altoBotonesConsultas = $("#divBotonesConsultas").height();
           var suma = 108.8 + altoContenidoFiltro + altoBotonesPrincipales + altoBotonesConsultas;
           document.getElementById('divconsulta').style.height = (alto - suma).toString() + "px";
       }
   </script>
</asp:Content>















































































