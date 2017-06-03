<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Caja.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarPersonaCaja.ascx" TagName="wucConsultarPersonaCaja" TagPrefix="WUCPC" %>
<%@ Register Src="~/Wuc/WucBusquedaCliente.ascx" TagName="wucBusquedaCliente" TagPrefix="WUBC" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucPersona.ascx" TagName="wucPersona" TagPrefix="WUP" %>
<%--<%@ Register src="../../../Wuc/WUCDatosAuditoria.ascx" tagname="wucDatosAuditoria" tagprefix="WUCDA" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .hidden {
            display: none;
        }

        .ColumnaOculta {
            display: none;
        }

        .auto-style9 {
            width: 241px;
        }

        .auto-style10 {
            width: 134px;
        }

        .auto-style11 {
            width: 284px;
        }

        .auto-style12 {
            width: 332px;
        }

        .auto-style13 {
            width: 118px;
        }

        .auto-style14 {
            width: 96%;
        }
    </style>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%;">
                <tr>
                    <%--<td colspan="3">
                        <asp:Button ID="BTNNuevo" runat="server" Text="Nuevo" />
                        <asp:Button ID="BTNGuardar" runat="server" Text="Guardar" />
                        <asp:Button ID="BTNSalir" runat="server" Text="Salir" />
                    </td>--%>
                    <td colspan="4" class="MenuHead">
                        <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" Visible="false" />
                        <asp:ImageButton ID="IBTConsultarAbonos" runat="server" ImageUrl="~/Imagenes/IMRegistros.png" />
                        <asp:ImageButton ID="IBTCancelar" Visible="false" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" />
                        <asp:ImageButton ID="IBTReimprimir" Visible="false" runat="server" ImageUrl="~/Imagenes/IMReImprimir.png" />
                        <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td></td>
                </tr>
                <tr runat="server" visible="false">
                    <td>ID</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TBIdCaja" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">
                        <asp:Label ID="Label1" runat="server" Text="Recibo"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TBRecibo" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style13">Serie&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TBSerie" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Cliente</td>

                    <td class="auto-style1">

                        <WUBC:wucBusquedaCliente ID="WUCBusquedaCliente" runat="server" />
                        <asp:Button ID="BTNBuscar" runat="server" Text="Buscar" />
                        <%--<asp:TextBox ID="TBReciboPrueba" runat="server" AutoPostBack="true" Width="350px"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" CompletionSetCount="20" MinimumPrefixLength="4" FirstRowSelected="false" ServiceMethod="SearchCustomers" TargetControlID="TBReciboPrueba" runat="server"></ajaxToolkit:AutoCompleteExtender>--%>
                    </td>

                    <td class="auto-style13">
                        <asp:Label ID="Label4" runat="server" Text=" Saldo Actual"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="TBSaldoActual" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr runat="server" visible="false">
                    <%--<td colspan="2">
                        <WUP:wucPersona ID="wucPersona" runat="server"/>
                    </td>--%>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TBIdPersona" runat="server"></asp:TextBox>
                        <asp:TextBox ID="TBNombreCliente" runat="server" Enabled="False" Visible="true" Width="250px"></asp:TextBox>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <%--<tr id="SaldoAct" runat="server" visible="false">
                    <td style="width: 154px"><asp:Label ID="LBSaldoActual" runat="server" Text=" Saldo Actual"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TBSaldoActual" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr id="SaldoVen" runat="server" visible="false">
                    <td style="width: 154px"> 
                        <asp:Label ID="Label3" runat="server" Text="Saldo Vencido" Visible="false" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style1"> 
                        <asp:TextBox ID="TBSaldoVencido" runat="server" Visible="false"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>--%>
                <tr>
                    <td style="width: 154px">Documento</td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DDTipoDocumento" runat="server" AutoPostBack="false" Style="width: 154px;">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13">Abono</td>
                    <td>
                        <asp:TextBox ID="TBAbono" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Forma de Pago</td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="DDFormaPago" runat="server" AutoPostBack="true" Style="width: 154px;">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr id="TRDescuento" runat="server" visible="false">
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style13">Descuento</td>
                    <td>
                        <asp:TextBox ID="TBDescuento" runat="server"></asp:TextBox>
                        <asp:CheckBox ID="CBPorcentaje" runat="server" />
                        <asp:Label ID="LBPorcentaje" runat="server" Text="Porcentaje"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="2">
                        <table style="width: 100%;">
                            <tr id="TREfectivo" runat="server">
                                <td style="width: 154px">
                                    <asp:Label ID="LBReferencia1" runat="server" Text=" Pago Con:"></asp:Label>
                                    &nbsp;$</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBEfectivo" runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="TRDolares" runat="server">
                                <td style="width: 154px">Pagó con: $</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBDolares" runat="server" AutoPostBack="True"></asp:TextBox>
                                    Dlls</td>

                            </tr>
                            <tr id="TREfectivoDolares" runat="server">
                                <td style="width: 154px">Equivalente a:</td>
                                <td class="auto-style7">
                                    <asp:Label ID="LBEquivalenteDolares" runat="server" Text="$0.00"></asp:Label>
                                </td>

                            </tr>
                            <tr id="TRTarjeta" runat="server">
                                <td style="width: 154px">Tarjeta: $&nbsp;</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBTarjeta" runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="TRTarjetaReferencia" runat="server">
                                <td style="width: 154px">Referencia</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBTarjetaReferencia" runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="TRCheque" runat="server">
                                <td style="width: 154px">Cheque por: $</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBCheque" runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>

                            </tr>
                            <tr id="TRChequeReferencia" runat="server">
                                <td style="width: 154px">Referencia Cheque</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBChequeReferencia" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr id="TRNotaCredito" runat="server">
                                <td style="width: 154px">Nota de Credito</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBNotaCreditoReferencia" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr id="TRVale" runat="server">
                                <td style="width: 154px">&nbsp;Vale: $</td>
                                <td class="auto-style7">
                                    <asp:TextBox ID="TBVale" runat="server" AutoPostBack="True"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 155px;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style13">Observacion:</td>
                    <td rowspan="2">
                        <asp:TextBox ID="TBObservaciones" runat="server" Font-Strikeout="False" TextMode="MultiLine" Width="214px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">Su Cambio: $</td>
                    <td class="auto-style7">
                        <asp:Label ID="LBEfectivoCambio" runat="server" Text="$0.00"></asp:Label>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr runat="server" visible="false">
                    <td style="width: 154px">Fecha</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TBFecha" runat="server" Enabled="False"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFecha" />
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:GridView ID="GVCaja" runat="server" AutoGenerateColumns="False" AllowPaging="false" CaptionAlign="Top" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" Width="100%" PagerStyle-CssClass="pgr" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">
                            <%--AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr"--%>
                            <Columns>

                                <%--<asp:BoundField DataField="IdVenta" HeaderText="Id" SortExpression="IdVenta" Visible="False" />--%>
                                <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" Visible="true" />
                                <%--<asp:BoundField DataField=" <%# pRESENTACION Eval("Descripcion")%>" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />--%>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Descripcion
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Comun.Presentacion.StringTruncado.Truncar(Eval("Descripcion"), 50)%>...
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Abonar
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBGVAbono" runat="server" AutoPostBack="true" OnTextChanged="TBGVItemAbono_TextChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CBGVAbonoHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVAbonoHeader_CheckedChanged" />Abonar
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBGVAbonoItem" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVAbonoItem_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Abono" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" HeaderText="Abono" SortExpression="Abono" Visible="true" />
                                <asp:BoundField DataField="SaldoActual" HeaderText="Saldo Actual" SortExpression="SaldoActual" Visible="true" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto" Visible="true" />

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CBGVLiquidacionHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVLiquidacionHeader_CheckedChanged" />
                                        Liquidar
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBGVLiquidacionItem" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVLiquidacionItem_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Liquidacion" HeaderText="Liquidacion" SortExpression="Liquidacion" Visible="True" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Proyeccion
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBGVLiquidacion" runat="server" AutoPostBack="true" OnTextChanged="TBGVItemLiquidacion_TextChanged" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBGVLiquidacion" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="SaldoVencido" HeaderText="SaldoVencido" SortExpression="SaldoVencido" Visible="true" />--%>


                                <%--<asp:BoundField DataField="Modulo" Visible="true" HeaderText="Interes Generado" SortExpression="Folio" /> --%>

                                <%--<asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" Visible="true" />--%>
                                <%--<asp:BoundField DataField="Venta" HeaderText="Venta" SortExpression="Venta" Visible="true" />--%>
                                <%--<asp:BoundField DataField="VentaVencimiento" HeaderText="Vencimiento" SortExpression="Vencimiento" Visible="true" />--%>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="true" />
                            </Columns>
                            <%--<HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />--%>
                        </asp:GridView>
                        <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
                        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
                        <script type="text/javascript" src="<%= ResolveUrl("~/JS/gridviewScroll.min.js")%>"></script>
                        <script type="text/javascript">
                            $(document).ready(function () {
                                gridviewScroll();
                            });

                            function gridviewScroll() {
                                $('#<%=GVCaja.ClientID%>').gridviewScroll({
                                    width: 1661,
                                    height: 200
                                });
                            }
                       <%-- </script>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 154px">
                        <asp:ImageButton ID="IBTRegresarPersona" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="TBBuscadorPersona" runat="server" Width="250px"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Buscar" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView ID="GVPersonas" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 154px">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                    </td>
                    <td style="width: 272px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView ID="GVAbonos" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 254px">
                        <asp:ImageButton ID="IBTRegresarVerDetalle" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">Folio</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBFolio" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Fecha Venta</td>
                    <td>
                        <asp:TextBox ID="TBFechVenta" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Cliente</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBIdPersonaVenta" runat="server" Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="TBNombreClienteVenta" runat="server" Enabled="False" Visible="true" Width="250px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Vencimiento</td>
                    <td>
                        <asp:TextBox ID="TBFechaVencimineto" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Saldo Actual</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBSaldoActualVenta" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Atraso</td>
                    <td>
                        <asp:TextBox ID="TBAtraso" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Saldo Vencido</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBSaldoVencido" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Abono</td>
                    <td>
                        <asp:TextBox ID="TBAbonoVenta" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Periodo</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBPeriodo" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Dias del Credito:</td>
                    <td>
                        <asp:TextBox ID="TBDiasCredito" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Monto</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBMonto" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Dias Transcurridos:</td>
                    <td>
                        <asp:TextBox ID="TBDiasTranscurridos" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Pagado a la Fecha</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBSumaAbonos" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Dias Faltantes:</td>
                    <td>
                        <asp:TextBox ID="TBDiasFaltantes" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Enganche y Pagos</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TBAnticipo" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style4">Precio Contado</td>
                    <td>
                        <asp:TextBox ID="TBPrecioContado" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Gracia:</td>
                    <td class="auto-style5">
                        <asp:Label ID="LBMesGracia" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">Condonacion si liquida:</td>
                    <td>
                        <asp:TextBox ID="TBCondonacionLiquidacion" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Plazo:</td>
                    <td class="auto-style5">
                        <asp:Label ID="LBPlazo" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">Monto de liquidacion:</td>
                    <td>
                        <asp:TextBox ID="TBLiquidacion" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">Extra:</td>
                    <td class="auto-style5">
                        <asp:Label ID="LBMesExtra" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">No. de Abonos:</td>
                    <td class="auto-style5">
                        <asp:Label ID="LBNumeroAbonos" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="2500px" Width="100%">
                            <Panes>
                                <ajaxToolkit:AccordionPane ID="AccordionPane0" runat="server" ContentCssClass="" HeaderCssClass="" Visible="True">
                                    <Header>&#160;&#160;&#160;&#160;&#160;&#160;&#160;Venta</Header>
                                    <Content>
                                        <table style="width: 100%; text-align: center;">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GVCajaVentaDetalle" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center"></asp:GridView>
                                                </td>
                                            </tr>
                                            <tr></tr>
                                            <tr style="text-align: center;">
                                                <td></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="" Visible="True">
                                    <Header>&#160;&#160;&#160;&#160;&#160;&#160;&#160;Historial</Header>
                                    <Content>
                                        <table style="width: 100%; text-align: center;">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GVCajaHistorial" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center"></asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="" Visible="True">
                                    <Header>&#160;&#160;&#160;&#160;&#160;&#160;&#160;Proyeccion de Liquidacion</Header>
                                    <Content>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TBFechaLiquidacion" runat="server" AutoPostBack="true"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaLiquidacion" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="LBCondonacion" runat="server" Text="Condonacion si Liquida:"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="LBLiquidacion" runat="server" Text="Monto de Liquidacion:"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                            </Panes>
                        </ajaxToolkit:Accordion>

                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </asp:View>
        <asp:View ID="View5" runat="server">
            <div class="Ocultar">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                            <asp:ImageButton ID="BTNImprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimir.png" />
                        </td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <h2>MUEBLES MUÑOZ S. A. DE C. V.</h2>
                    </td>
                    <td class="auto-style4">Folio:
                        <asp:Label ID="LBFolio" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">MATRIZ: Calle 2a Norte No. 123 Telefono 472-01-26 Cd. Delicias Chih.</td>
                    <td class="auto-style4">Fecha:
                        <asp:Label ID="LBFecha" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Recibi del Cliente:</td>
                    <td colspan="2">
                        <asp:Label ID="LBReciboCliente" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">Saldo Anterior:
                        <asp:Label ID="LBSaldoActualAnterior" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Por Concepto de:</td>
                    <td>
                        <asp:Label ID="LBReciboConceptoDescripcion" runat="server"></asp:Label>
                    </td>
                    <td>la cantidad de:
                        <asp:Label ID="LBReciboConcepto" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">Saldo Actual:
                        <asp:Label ID="LBSaldoActual" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">Forma de pago:</td>
                    <td class="auto-style9">
                        <asp:Label ID="LBReciboFormaPago" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style11">Descuento:
                        <asp:Label ID="LBReciboDescuento" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </asp:View>
        <asp:View ID="View6" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="IMRegresarMovimiento" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                        <asp:ImageButton ID="IBTConsultarMovimiento" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">Fecha</td>
                    <td class="auto-style12">
                        <asp:TextBox ID="TBBuscarMovimientos" runat="server" Width="250px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBBuscarMovimientos" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView ID="GVMovimiento" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

    <style type="text/css">
        .auto-style1 {
            width: 296px;
        }

        .auto-style4 {
            width: 338px;
        }

        .auto-style5 {
            width: 429px;
        }

        .auto-style7 {
            width: 569px;
        }
    </style>

</asp:Content>

