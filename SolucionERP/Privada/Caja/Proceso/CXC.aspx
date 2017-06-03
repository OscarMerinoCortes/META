<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="CXC.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WucBusquedaCliente.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Wuc/WucConsultarPersonaCaja.ascx" TagName="wucConsultarPersonaCaja" TagPrefix="WUCPC" %>
<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucConsultarProveedor.ascx" TagName="wucConsultarProveedor" TagPrefix="WUCProv" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <style type="text/css">
        .hidden {
            display: none;
        }

        .ColumnaOculta {
            display: none;
        }

        .auto-style11 {
            height: 26px;
        }

        .auto-style23 {
            width: 99px;
            height: 26px;
        }

        .auto-style24 {
            width: 556px;
        }

        .auto-style25 {
            width: 556px;
            height: 26px;
        }

        .auto-style26 {
            width: 115px;
        }

        .auto-style27 {
            height: 26px;
            width: 115px;
        }

        .auto-style28 {
            width: 99px;
        }

        .auto-style29 {
            width: 752px;
        }

        .auto-style30 {
            height: 26px;
            width: 752px;
        }

        .auto-style48 {
            width: 272px;
        }

        .auto-style50 {
            width: 848px;
        }

        .auto-style53 {
            width: 272px;
            height: 26px;
        }

        .auto-style54 {
            width: 848px;
            height: 26px;
        }

        .auto-style57 {
            width: 577px;
            height: 26px;
        }

        .auto-style60 {
            width: 577px;
        }

        .AlineadoDerecha {
            text-align: right;
        }

        .AlineadoCentro {
            text-align: center;
        }

        .auto-style61 {
            height: 103px;
        }
    </style>
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css">
    <link rel="StyleSheet" href="../CSS/gridviewScroll.css" type="text/css">
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
                        <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                        <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                        <asp:ImageButton ID="IBTConsultarAbonos" runat="server" ImageUrl="~/Imagenes/IMMovimientos.png" />
                        <asp:ImageButton Visible="false" ID="IBTReimprimir" runat="server" ImageUrl="~/Imagenes/IMReImprimir.png" />
                        <asp:ImageButton ID="IBTCancelar" Visible="false" runat="server" ImageUrl="~/Imagenes/IMCancelar.png" />
                        <asp:ImageButton ID="IBTSalir" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                    </td>
                </tr>
                <tr>

                    <td colspan="2">&nbsp;</td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50"></td>
                </tr>
                <tr>
                    <td>ID</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBIdCCP" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                      <td >
                        Cliente
                    </td> 
                    <td colspan="4">
                        <WUCP:wucConsultarPersona ID="wucConPer" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Estado</td>
                    <td class="auto-style60">
                        <asp:DropDownList ID="DDEstado" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style48">TIpo Documento</td>
                    <td class="auto-style50">
                        <asp:DropDownList ID="DDIdTipoDocumento" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Expedición</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBFecha" runat="server" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TBFecha_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFecha" />
                        <asp:RequiredFieldValidator ID="RFVFecha" runat="server" ControlToValidate="TBFecha"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Fecha es Requerida" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFecha" runat="server" TargetControlID="RFVFecha"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="auto-style48">Serie</td>
                    <td class="auto-style50">
                        <asp:TextBox ID="TBSerie" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVSerie" runat="server" ControlToValidate="TBSerie"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Serie es Requerida" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCESerie" runat="server" TargetControlID="RFVSerie"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Vencimiento</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBFechaVencimientoE" runat="server" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TBFecha_CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaVencimientoE" />
                        <asp:RequiredFieldValidator ID="RFVFechaV" runat="server" ControlToValidate="TBFechaVencimientoE"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Fecha es Requerida" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFechaV" runat="server" TargetControlID="RFVFechaV"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="auto-style48">Folio</td>
                    <td class="auto-style50">
                        <asp:TextBox ID="TBFolioE" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFolioE" runat="server" ControlToValidate="TBFolioE"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Folio es Requerido" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFolioE" runat="server" TargetControlID="RFVFolioE"></asp:ValidatorCalloutExtender>
                    </td>
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
                    <td class="auto-style11">Descripción</td>
                    <td class="auto-style57">
                        <asp:TextBox ID="TBDescripcion" runat="server" Width="150px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" ControlToValidate="TBDescripcion"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Descripcion es Requerida" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcion" runat="server" TargetControlID="RFVDescripcion"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="auto-style53">Observación</td>
                    <td class="auto-style54">
                        <asp:TextBox ID="TBObservacion" runat="server" Font-Strikeout="False" TextMode="MultiLine" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVObservacion" runat="server" ControlToValidate="TBObservacion"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Observacion es Requerida" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEObservacion" runat="server" TargetControlID="RFVObservacion"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Monto</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBMonto" runat="server" Width="150px" AutoPostBack="true"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBEMonto" runat="server" FilterType="Numbers" TargetControlID="TBMonto" />
                        <asp:RequiredFieldValidator ID="RFVMonto" runat="server" ControlToValidate="TBMonto"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Monto es Requerido" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMonto" runat="server" TargetControlID="RFVMonto"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="auto-style48"></td>
                    <td class="auto-style50"></td>
                </tr>
                <tr>
                    <td>IVA</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBIVA" runat="server" Width="150px" AutoPostBack="true"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBEIVA" runat="server" FilterType="Numbers" TargetControlID="TBIVA" />
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td>IEPS</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBIEPS" runat="server" Width="150px" AutoPostBack="true"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBEIEPS" runat="server" FilterType="Numbers" TargetControlID="TBIEPS" />
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td>Subtotal</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBSubtotal" runat="server" Width="150px" AutoPostBack="true" Enabled="false"></asp:TextBox>
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>

                <tr>
                    <td>Cargo</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBCargo" runat="server" Width="150px" AutoPostBack="true"></asp:TextBox>
                      <%--  <asp:FilteredTextBoxExtender ID="FTBECargo" runat="server" FilterType="Numbers" TargetControlID="TBCargo" />--%>
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td>Abono</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBAbono" runat="server" AutoPostBack="True" Width="150px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBEAbono" runat="server" FilterType="Numbers" TargetControlID="TBAbono" />
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td>Saldo</td>
                    <td class="auto-style60">
                        <asp:TextBox ID="TBSaldo" runat="server" AutoPostBack="True" Width="150px" Enabled="false"></asp:TextBox>
                    </td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" Visible="false" runat="server" style="width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="5">
                        <asp:GridView ID="GVProductos" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center" Width="100%">
                        </asp:GridView>
                    </td>
                </tr>

                <tr style="text-align: center;">
                    <td colspan="5">
                        <asp:GridView ID="GVCargosAbonos" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center" Width="100%">
                            <Columns>
                                  <asp:TemplateField><ItemTemplate><asp:LinkButton ID="BTNCancelarCargoAbono" runat="server" AutoPostBack="true"
                                            ForeColor="Blue" Text="Cancelar" ShowSelectButton = "True" OnClick="BTNCancelarCargoAbono_OnClick"/></ItemTemplate></asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

            </table>
        </asp:View>




        <asp:View ID="View5" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td colspan="5">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                        <asp:ImageButton ID="IBTGuardarTransaccion" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="GuardarTransaccion" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">ID Cliente</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBIdClienteTransaccion" runat="server" Width="50px" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="TBNombreCliente" runat="server" Width="300px" Enabled="false"></asp:TextBox>
                    </td>
                    <td class="auto-style26">TIpo Documento</td>
                    <td class="auto-style29">
                        <asp:DropDownList ID="DDIdTipoDocumentoTransaccion" runat="server" Width="155">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">Saldo Vigente</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBSaldoVigenteTransaccion" runat="server" Width="150px" Enabled="false" CssClass="AlineadoDerecha"></asp:TextBox>
                    </td>
                    <td class="auto-style26">Serie</td>
                    <td class="auto-style29">
                        <asp:TextBox ID="TBSerieTransaccion" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVSerieTransaccion" runat="server" ControlToValidate="TBSerieTransaccion"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Serie es Requerida" Display="None" ValidationGroup="GuardarTransaccion"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCESerieTransaccion" runat="server" TargetControlID="RFVSerieTransaccion"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">Saldo Vencido</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBSaldoVencidoTransaccion" runat="server" Width="150px" Enabled="false" CssClass="AlineadoDerecha"></asp:TextBox>
                    </td>
                    <td class="auto-style26">Folio</td>
                    <td class="auto-style29">
                        <asp:TextBox ID="TBFolioTransaccion" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFolioTransaccion" runat="server" ControlToValidate="TBFolioTransaccion"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Folio es Requerido" Display="None" ValidationGroup="GuardarTransaccion"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEFolioTransaccion" runat="server" TargetControlID="RFVFolioTransaccion"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">Saldo Total</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBSaldoTotalTransaccion" runat="server" Width="150px" Enabled="false" CssClass="AlineadoDerecha"></asp:TextBox>
                    </td>
                    <td class="auto-style26">Observación</td>
                    <td class="auto-style29">
                        <asp:TextBox ID="TBObservacionTransaccion" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVDescripcionTransaccion" runat="server" ControlToValidate="TBDescripcionTransaccion"
                            ErrorMessage="&lt;strong>Información requerida</strong> El Concepto es Requerido" Display="None" ValidationGroup="GuardarTransaccion"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDescripcionTransaccion" runat="server" TargetControlID="RFVDescripcionTransaccion"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style23">Transacción</td>
                    <td class="auto-style25">
                        <asp:DropDownList ID="DDIdTransaccion" AutoPostBack="true" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style27"></td>
                    <td class="auto-style30"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style28">Monto</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBAbonarTransaccion" runat="server" Width="150px" Enabled="false" AutoPostBack="true" CssClass="AlineadoDerecha"></asp:TextBox>
                        <asp:Button ID="BNTCalcular" runat="server" Text="Calcular" />
                    </td>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style29">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">Concepto</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBDescripcionTransaccion" runat="server" Width="150px" AutoPostBack="true" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style29">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">Pago</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBPagoTransaccion" AutoPostBack="true" runat="server" Width="150px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FTBEPagoTransaccion" runat="server" FilterType="Numbers" TargetControlID="TBPagoTransaccion" />
                    </td>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style29">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">Cambio</td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TBCambioTransaccion" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                    </td>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style29">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style28">&nbsp;</td>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style29">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="5">

                        <asp:GridView ID="GVCCP" runat="server" AllowPaging="false" CaptionAlign="Top" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" Width="100%" PagerStyle-CssClass="pgr" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">
                            <%--AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr"--%>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BTNSeleccionar" runat="server" AutoPostBack="true"
                                            ForeColor="Blue" Text="Seleccionar" ShowSelectButton="True" OnClick="BTNSeleccionar_OnClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdCCP" HeaderText="Id" Visible="False" />
                                <asp:BoundField DataField="Serie" HeaderText="Serie" Visible="true" />
                                <asp:BoundField DataField="Folio" HeaderText="Folio" Visible="true" />
                                <%--<asp:BoundField DataField=" <%# pRESENTACION Eval("Descripcion")%>" HeaderText="Descripcion" SortExpression="Descripcion" Visible="true" />--%>
                                <asp:TemplateField>
                                    <HeaderTemplate>Descripcion</HeaderTemplate>
                                    <ItemTemplate><%# Comun.Presentacion.StringTruncado.Truncar(Eval("Descripcion"), 50)%>...</ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Abonar</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBGVAbono" AutoPostBack="true" runat="server" OnTextChanged="TBGVAbono_TextChanged" /></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CBGVAbonoHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVAbonoHeader_CheckedChanged" />Abonar</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBGVAbonoItem" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVAbonoItem_CheckedChanged" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Concepto</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="TBGVConcepto" runat="server" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Abono" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" HeaderText="Abono" Visible="true" />
                                <asp:BoundField DataField="SaldoActual" HeaderText="Saldo Actual" Visible="true" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto" Visible="true" />

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CBGVLiquidacionHeader" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVLiquidacionHeader_CheckedChanged" />Liquidar</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CBGVLiquidacionItem" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVLiquidacionItem_CheckedChanged" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Liquidacion" HeaderText="Liquidacion" Visible="True" ItemStyle-CssClass="ColumnaOculta" HeaderStyle-CssClass="ColumnaOculta" />
                                <asp:BoundField DataField="SaldoVencido" HeaderText="Saldo Vencido" Visible="true" />
                                <asp:TemplateField></asp:TemplateField>
                                <%--<asp:BoundField DataField="SaldoVencido" HeaderText="SaldoVencido" SortExpression="SaldoVencido" Visible="true" />--%>


                                <%--<asp:BoundField DataField="Modulo" Visible="true" HeaderText="Interes Generado" SortExpression="Folio" /> --%>

                                <%--                                <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" Visible="true" />--%>
                                <%--<asp:BoundField DataField="Venta" HeaderText="Venta" SortExpression="Venta" Visible="true" />--%>
                                <%--<asp:BoundField DataField="VentaVencimiento" HeaderText="Vencimiento" SortExpression="Vencimiento" Visible="true" />--%>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true" />
                            </Columns>
                            <%--<HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />--%>
                        </asp:GridView>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td class="auto-style26">&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 154px">
                        <asp:ImageButton ID="IBTRegresarPersona" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                    </td>
                    <td style="width: 272px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView ID="GVPersonas" Style="margin: 0 auto;" runat="server" Width="100%" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr" GridLines="None" CaptionAlign="Top" HorizontalAlign="Center">
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
                    <td class="auto-style5">&nbsp;</td>
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
    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

    <style type="text/css">
        .auto-style4 {
            width: 338px;
        }

        .auto-style5 {
            width: 429px;
        }
    </style>

</asp:Content>

