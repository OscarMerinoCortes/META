Imports System.Data
Imports System.Windows.Forms
Imports System.Web.Script.Serialization
Imports Operacion.Configuracion.Constante
Imports System.Web.Services

Partial Class _Default
    Inherits Page

    Public TablaAbonoCaja As New DataTable()
    Public VistaAbonoCaja As New DataView()
    Public TablaFormaPagoDetalleCaja As New DataTable()
    Shared SaldoActual As Double
    Shared SaldoVencido As Double
    Shared SaldoTotal As Double
    Shared Condicion As Boolean
    Shared SumaAbonos As Double
    Shared SumaLiquidacion As Double
    Shared Dolar As Double = 17.3581
    Shared EsDolar As Boolean = False
    Shared DolarAntes As Boolean
    Shared DolarDespues As Boolean
    Shared SonDolares As Double
    Shared ReciboFormaPago As String
    Shared FolioCaja As String
    Shared SaldoactualAnterior As String
    Shared Bandera As Boolean = True
    Shared Busqueda As String
    Shared IdPersonaBusqueda As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Abono"
            Dim NegocioFormaPago As New Negocio.FormaPago()
            Dim EntidadFormaPago As New Entidad.FormaPago()
            EntidadFormaPago.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioFormaPago.Consultar(EntidadFormaPago)
            DDFormaPago.DataSource = EntidadFormaPago.TablaConsulta
            DDFormaPago.DataValueField = "ID"
            DDFormaPago.DataTextField = "Descripcion"
            DDFormaPago.DataBind()


            wucDatosAuditoria1.Nuevo()
            wucDatosAuditoria1.Visible = False

            Dim NegocioTipoDocumento As New Negocio.TipoDocumento()
            Dim EntidadTipoDocumento As New Entidad.TipoDocumento()
            EntidadTipoDocumento.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioTipoDocumento.Consultar(EntidadTipoDocumento)
            DDTipoDocumento.DataSource = EntidadTipoDocumento.TablaConsulta
            DDTipoDocumento.DataValueField = "ID"
            DDTipoDocumento.DataTextField = "Descripcion"
            DDTipoDocumento.DataBind()
            DDTipoDocumento.SelectedIndex = 2

            'TBFecha.Text = Now.Date
            'EFECTIVO
            TREfectivo.Visible = True
            'DOLARES
            TRDolares.Visible = False
            TREfectivoDolares.Visible = False
            LBEquivalenteDolares.Text = Format(Dolar, Operacion.Configuracion.Constante.Formato.Moneda) + " Dlls"
            'TARJETA
            TRTarjeta.Visible = False
            TRTarjetaReferencia.Visible = False
            'CHEQUE
            TRCheque.Visible = False
            TRChequeReferencia.Visible = False
            'NOTACREDITO
            TRNotaCredito.Visible = False
            'VALE
            TRVale.Visible = False


            '##############################################################################
            TablaAbonoCaja.Columns.Clear()
            TablaAbonoCaja.Columns.Add(New DataColumn("IdCPPMovimiento", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdCPP", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdTransaccion", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdTipoDocumento", System.Type.GetType("System.String")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Serie", System.Type.GetType("System.String")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Folio", System.Type.GetType("System.String")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Fecha", System.Type.GetType("System.DateTime")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Observacion", System.Type.GetType("System.String")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdCajaMovimiento", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Monto", System.Type.GetType("System.Double")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Impuesto", System.Type.GetType("System.Double")))
            TablaAbonoCaja.Columns.Add(New DataColumn("Sucursal", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdUsuarioCreacion", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("FechaCreacion", System.Type.GetType("System.DateTime")))
            TablaAbonoCaja.Columns.Add(New DataColumn("IdUsuarioActualizacion", System.Type.GetType("System.Int32")))
            TablaAbonoCaja.Columns.Add(New DataColumn("FechaActualizacion", System.Type.GetType("System.DateTime")))
            VistaAbonoCaja = TablaAbonoCaja.DefaultView


            Session("TablaAbonoCaja") = TablaAbonoCaja
            Session("VistaAbonoCaja") = VistaAbonoCaja

            '##############################################################################
            TablaFormaPagoDetalleCaja.Columns.Clear()
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("IdFormaPagoDetalle", System.Type.GetType("System.Int32")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("Abono", System.Type.GetType("System.Double")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("DolarDiario", System.Type.GetType("System.Double")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("Referencia", System.Type.GetType("System.String")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("IdBanco", System.Type.GetType("System.Int32")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("NumeroVale", System.Type.GetType("System.String")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("IdFormaPago", System.Type.GetType("System.Int32")))
            TablaFormaPagoDetalleCaja.Columns.Add(New DataColumn("IdCaja", System.Type.GetType("System.Int32")))

            Session("TablaFormaPagoDetalleCaja") = TablaFormaPagoDetalleCaja
            '##############################################################################
            LimpiarTablas()
            MultiView1.SetActiveView(View1)
        Else
            TablaAbonoCaja = Session("TablaAbonoCaja")
            VistaAbonoCaja = Session("VistaAbonoCaja")
            TablaFormaPagoDetalleCaja = Session("TablaFormaPagoDetalleCaja")
        End If
    End Sub
    Public Sub LimpiarTablas()
        TablaAbonoCaja.Rows.Clear()
        VistaAbonoCaja.Table.Rows.Clear()
        Session("TablaAbonoCaja") = TablaAbonoCaja
        Session("VistaAbonoCaja") = VistaAbonoCaja
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
        IBTCancelar.Visible = False
        IBTReimprimir.Visible = False

    End Sub
    Public Sub Nuevo()
        TBIdCaja.Text = ""
        TBRecibo.Text = ""
        TBIdPersona.Text = ""
        TBSaldoActual.Text = ""
        TBSaldoActual.Text = ""
        TBAbono.Text = ""
        TBDescuento.Text = ""
        TBEfectivo.Text = ""
        LBEfectivoCambio.Text = "$0.00"
        TBDolares.Text = ""
        LBEquivalenteDolares.Text = "$0.00"
        TBTarjeta.Text = ""
        TBTarjetaReferencia.Text = ""
        TBChequeReferencia.Text = ""
        TBNotaCreditoReferencia.Text = ""
        TBVale.Text = ""
        EsDolar = False
        DDFormaPago.SelectedValue = 1
        IBTCancelar.Visible = False
        GVCaja.DataSource = Nothing
        'TBFecha.Text = Now.Date
        TBObservaciones.Text = ""

        wucDatosAuditoria1.Nuevo()
        wucDatosAuditoria1.Visible = False


        TBIdPersona.Enabled = True
        TBAbono.Enabled = True
        TBDescuento.Enabled = True
        CBPorcentaje.Enabled = True
        IBTGuardar.Visible = True
        TBNombreCliente.Text = ""

        'TBIdCaja.Enabled = True
        'TBRecibo.Enabled = True
        'TBIdPersona.Enabled = True
        'TBNombreCliente.Enabled = True
        'TBSaldoActual.Enabled = True
        'TBAbono.Enabled = True
        'TBDescuento.Enabled = True
        'CBPorcentaje.Enabled = True
        'TBFecha.Enabled = True
        'TBObservaciones.Enabled = True


        GVCaja.DataBind()
        LimpiarTablas()

        WUCBusquedaCliente.Limpiar()
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim EntidadCaja As New Entidad.Caja()
        Dim NegocioCaja As New Negocio.Caja()
        Dim TablaAbonoCaja As New DataTable()

        Dim Tarjeta As New Entidad.Tarjeta()
        Tarjeta = Session("Tarjeta")


        EntidadCaja.IdUsuarioCreacion = Tarjeta.IdUsuario
        'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
        EntidadCaja.FechaCreacion = Now
        EntidadCaja.IdUsuarioActualizacion = Tarjeta.IdUsuario
        'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
        EntidadCaja.FechaActualizacion = Now

        TablaAbonoCaja = Session("TablaAbonoCaja")
        VistaAbonoCaja = Session("VistaAbonoCaja")

        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")

        Dim index As Integer = 0
        SaldoActual = 0
        FolioCaja = Tarjeta.IdSucursal.ToString() + Now.Year().ToString() + Now.Month().ToString() + Now.Day().ToString() + Now.Hour().ToString + Now.Minute().ToString() + Now.Millisecond().ToString()
        EntidadCaja.IdCaja = IIf(TBIdCaja.Text Is String.Empty, 0, TBIdCaja.Text)
        EntidadCaja.Recibo = FolioCaja
        EntidadCaja.IdPersona = IdPersonaBusqueda

        EntidadCaja.PagoAbono = IIf(DDFormaPago.SelectedItem.Text = "DOLARES", SonDolares * Dolar, TBAbono.Text)

        EntidadCaja.IdFormaPago = DDFormaPago.SelectedValue
        EntidadCaja.Descuento = IIf(TBDescuento.Text Is String.Empty, 0, TBDescuento.Text)
        EntidadCaja.Porcentaje = IIf(CBPorcentaje.Checked = True, 1, 0)
        EntidadCaja.Observacion = TBObservaciones.Text
        EntidadCaja.IdEstado = 1


        EntidadCaja.IdFormaPagoDetalle = 0
        Dim TablaRenglonAInsertar As DataRow
        Select Case DDFormaPago.SelectedItem.Text
            Case "EFECTIVO"
                ReciboFormaPago = "EFECTIVO"
                TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                TablaRenglonAInsertar("Abono") = CDbl(TBAbono.Text)
                TablaRenglonAInsertar("DolarDiario") = 0
                TablaRenglonAInsertar("Referencia") = ""
                TablaRenglonAInsertar("IdBanco") = 0
                TablaRenglonAInsertar("NumeroVale") = ""
                TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                TablaRenglonAInsertar("IdCaja") = 0
                TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
            Case "DOLARES"
                ReciboFormaPago = "DOLARES"
                TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                TablaRenglonAInsertar("Abono") = CDbl(SonDolares) * Dolar
                TablaRenglonAInsertar("DolarDiario") = Dolar
                TablaRenglonAInsertar("Referencia") = ""
                TablaRenglonAInsertar("IdBanco") = 0
                TablaRenglonAInsertar("NumeroVale") = ""
                TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                TablaRenglonAInsertar("IdCaja") = 0
                TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
            Case "TARJETA"
                ReciboFormaPago = "TARJETA"
                TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                TablaRenglonAInsertar("Abono") = CDbl(TBAbono.Text)
                TablaRenglonAInsertar("DolarDiario") = 0
                TablaRenglonAInsertar("Referencia") = TBTarjetaReferencia.Text
                TablaRenglonAInsertar("IdBanco") = 0
                TablaRenglonAInsertar("NumeroVale") = ""
                TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                TablaRenglonAInsertar("IdCaja") = 0
                TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
            Case "CHEQUE"
                ReciboFormaPago = "CHEQUE"
                TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                TablaRenglonAInsertar("Abono") = CDbl(TBAbono.Text)
                TablaRenglonAInsertar("DolarDiario") = 0
                TablaRenglonAInsertar("Referencia") = TBChequeReferencia.Text
                TablaRenglonAInsertar("IdBanco") = 0
                TablaRenglonAInsertar("NumeroVale") = ""
                TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                TablaRenglonAInsertar("IdCaja") = 0
                TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
            Case "NOTA DE CREDITO"
                ReciboFormaPago = "NOTA DE CREDITO"
                TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                TablaRenglonAInsertar("Abono") = CDbl(TBAbono.Text)
                TablaRenglonAInsertar("DolarDiario") = 0
                TablaRenglonAInsertar("Referencia") = TBNotaCreditoReferencia.Text
                TablaRenglonAInsertar("IdBanco") = 0
                TablaRenglonAInsertar("NumeroVale") = ""
                TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                TablaRenglonAInsertar("IdCaja") = 0
                TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
            Case "VALE"
                ReciboFormaPago = "VALE"
                TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                TablaRenglonAInsertar("Abono") = CDbl(TBAbono.Text)
                TablaRenglonAInsertar("DolarDiario") = 0
                TablaRenglonAInsertar("Referencia") = 0
                TablaRenglonAInsertar("IdBanco") = 0
                TablaRenglonAInsertar("NumeroVale") = 0
                TablaRenglonAInsertar("IdFormaPago") = 0
                TablaRenglonAInsertar("IdCaja") = 0
                TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
            Case "MIXTO"
                ReciboFormaPago = "MIXTO"
                If Not TBEfectivo.Text Is String.Empty Then
                    TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                    TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                    TablaRenglonAInsertar("Abono") = CDbl(TBEfectivo.Text)
                    TablaRenglonAInsertar("DolarDiario") = 0
                    TablaRenglonAInsertar("Referencia") = ""
                    TablaRenglonAInsertar("IdBanco") = 0
                    TablaRenglonAInsertar("NumeroVale") = ""
                    TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                    TablaRenglonAInsertar("IdCaja") = 0
                    TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
                End If

                If Not TBDolares.Text Is String.Empty Then
                    TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                    TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                    TablaRenglonAInsertar("Abono") = CDbl(TBDolares.Text) * Dolar
                    TablaRenglonAInsertar("DolarDiario") = Dolar
                    TablaRenglonAInsertar("Referencia") = ""
                    TablaRenglonAInsertar("IdBanco") = 0
                    TablaRenglonAInsertar("NumeroVale") = ""
                    TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                    TablaRenglonAInsertar("IdCaja") = 0
                    TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
                End If
                If Not (TBTarjeta.Text Is String.Empty And TBTarjetaReferencia.Text Is String.Empty) Then
                    TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                    TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                    TablaRenglonAInsertar("Abono") = CDbl(TBTarjeta.Text)
                    TablaRenglonAInsertar("DolarDiario") = 0
                    TablaRenglonAInsertar("Referencia") = TBTarjetaReferencia.Text
                    TablaRenglonAInsertar("IdBanco") = 0
                    TablaRenglonAInsertar("NumeroVale") = ""
                    TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                    TablaRenglonAInsertar("IdCaja") = 0
                    TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
                Else
                    Exit Sub
                End If
                If Not (TBCheque.Text Is String.Empty And TBChequeReferencia.Text Is String.Empty) Then
                    TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                    TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                    TablaRenglonAInsertar("Abono") = CDbl(TBCheque.Text)
                    TablaRenglonAInsertar("DolarDiario") = 0
                    TablaRenglonAInsertar("Referencia") = TBChequeReferencia.Text
                    TablaRenglonAInsertar("IdBanco") = 0
                    TablaRenglonAInsertar("NumeroVale") = ""
                    TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                    TablaRenglonAInsertar("IdCaja") = 0
                    TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
                Else
                    Exit Sub
                End If
                If Not TBNotaCreditoReferencia.Text Is String.Empty Then
                    TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                    TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                    TablaRenglonAInsertar("Abono") = CDbl(TBNotaCreditoReferencia.Text)
                    TablaRenglonAInsertar("DolarDiario") = 0
                    TablaRenglonAInsertar("Referencia") = TBNotaCreditoReferencia.Text
                    TablaRenglonAInsertar("IdBanco") = 0
                    TablaRenglonAInsertar("NumeroVale") = ""
                    TablaRenglonAInsertar("IdFormaPago") = EntidadCaja.IdFormaPago
                    TablaRenglonAInsertar("IdCaja") = 0
                    TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
                End If
                If Not TBVale.Text Is String.Empty Then
                    TablaRenglonAInsertar = TablaFormaPagoDetalleCaja.NewRow()
                    TablaRenglonAInsertar("IdFormaPagoDetalle") = 0
                    TablaRenglonAInsertar("Abono") = CDbl(TBVale.Text)
                    TablaRenglonAInsertar("DolarDiario") = 0
                    TablaRenglonAInsertar("Referencia") = 0
                    TablaRenglonAInsertar("IdBanco") = 0
                    TablaRenglonAInsertar("NumeroVale") = 0
                    TablaRenglonAInsertar("IdFormaPago") = 0
                    TablaRenglonAInsertar("IdCaja") = 0
                    TablaFormaPagoDetalleCaja.Rows.Add(TablaRenglonAInsertar)
                End If
        End Select
        EntidadCaja.TablaFormaPagoDetalleCaja = TablaFormaPagoDetalleCaja
        Session("TablaFormaPagoDetalleCaja") = TablaFormaPagoDetalleCaja

        'FolioCaja = "01" + Now.Year().ToString() + Now.Month().ToString() + Now.Day().ToString() + Now.Hour().ToString + Now.Minute().ToString() + Now.Millisecond().ToString()
        For Each MiDataRow As GridViewRow In GVCaja.Rows
            Dim RenglonAInsertar As DataRow
            index = Convert.ToUInt64(MiDataRow.RowIndex)
            If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                RenglonAInsertar = TablaAbonoCaja.NewRow()
                RenglonAInsertar("IdCPPMovimiento") = 0
                RenglonAInsertar("IdCPP") = TablaCaja.Rows(index).Item("IdCCP")
                RenglonAInsertar("IdTransaccion") = 2
                RenglonAInsertar("IdTipoDocumento") = DDTipoDocumento.SelectedValue
                RenglonAInsertar("Serie") = IIf(TBSerie.Text Is String.Empty, "C", TBSerie.Text)
                RenglonAInsertar("Folio") = FolioCaja
                RenglonAInsertar("Fecha") = Now
                RenglonAInsertar("Descripcion") = "Abono Extraordinario"
                RenglonAInsertar("Observacion") = ""
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("Monto") = Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("Sucursal") = Tarjeta.IdSucursal
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = Tarjeta.IdUsuario
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = Tarjeta.IdUsuario 'cambiar este dato por el de tipo de usuario 
                RenglonAInsertar("FechaActualizacion") = Now
                TablaAbonoCaja.Rows.Add(RenglonAInsertar)
            ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                RenglonAInsertar = TablaAbonoCaja.NewRow()
                RenglonAInsertar("IdCPPMovimiento") = 0
                RenglonAInsertar("IdCPP") = TablaCaja.Rows(index).Item("IdCCP")
                RenglonAInsertar("IdTransaccion") = 2
                RenglonAInsertar("IdTipoDocumento") = DDTipoDocumento.SelectedValue
                RenglonAInsertar("Serie") = IIf(TBSerie.Text Is String.Empty, "C", TBSerie.Text)
                RenglonAInsertar("Folio") = FolioCaja
                RenglonAInsertar("Fecha") = Now
                RenglonAInsertar("Descripcion") = "Abono Normal"
                RenglonAInsertar("Observacion") = ""
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("Monto") = Convert.ToDouble(TablaCaja.Rows(index).Item("Abono"))
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("Sucursal") = Tarjeta.IdSucursal
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = Tarjeta.IdUsuario
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = Tarjeta.IdUsuario 'cambiar este dato por el de tipo de usuario
                RenglonAInsertar("FechaActualizacion") = Now
                TablaAbonoCaja.Rows.Add(RenglonAInsertar)
            ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                RenglonAInsertar = TablaAbonoCaja.NewRow()
                RenglonAInsertar("IdCPPMovimiento") = 0
                RenglonAInsertar("IdCPP") = TablaCaja.Rows(index).Item("IdCCP")
                RenglonAInsertar("IdTransaccion") = 2
                RenglonAInsertar("IdTipoDocumento") = DDTipoDocumento.SelectedValue
                RenglonAInsertar("Serie") = IIf(TBSerie.Text Is String.Empty, "C", TBSerie.Text)
                RenglonAInsertar("Folio") = FolioCaja
                RenglonAInsertar("Fecha") = Now
                RenglonAInsertar("Descripcion") = "Abono Adelantado"
                RenglonAInsertar("Observacion") = ""
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("Monto") = Convert.ToDouble(TablaCaja.Rows(index).Item("Liquidacion"))
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("Sucursal") = Tarjeta.IdSucursal
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = Tarjeta.IdUsuario
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = Tarjeta.IdUsuario 'cambiar este dato por el de tipo de usuario
                RenglonAInsertar("FechaActualizacion") = Now
                TablaAbonoCaja.Rows.Add(RenglonAInsertar)
            End If
        Next
        'TablaAbonoCaja.AcceptChanges() 'CONFIRMAR LOS DATOS DESDE LA ULTIMA VEZ QUE SE UTILIZO
        'Dim lol As String = ""
        'lol = GetJson(TablaAbonoCaja)
        EntidadCaja.TablaAbonoCaja = TablaAbonoCaja

        NegocioCaja.Guardar(EntidadCaja)
        TBIdCaja.Text = EntidadCaja.IdCaja

        EntidadCaja.IdCCP = TablaCaja.Rows(index).Item("IdCCP")
        EntidadCaja.FechaActual = Now '######################################|>VERIFICAR LIQUIDACION DESDE SQL
        'NegocioCaja.Liquidacion(EntidadCaja)
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioCaja.Consultar(EntidadCaja)
        TablaCaja = EntidadCaja.TablaConsulta
        GVCaja.DataSource = TablaCaja
        GVCaja.AutoGenerateColumns = False
        GVCaja.AllowSorting = True
        GVCaja.DataBind()
        Session("TablaCaja") = TablaCaja
        For Each MiDataRow As GridViewRow In GVCaja.Rows
            SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text = Format(TablaCaja.Rows(Convert.ToUInt64(MiDataRow.RowIndex)).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
            CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Text = Format(TablaCaja.Rows(Convert.ToUInt64(MiDataRow.RowIndex)).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
        Next
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        LimpiarTablas()

        Recibo()
        MultiView1.SetActiveView(View5)
    End Sub
    Public Sub Recibo()
        LBReciboFormaPago.Text = ReciboFormaPago
        LBReciboConcepto.Text = TBAbono.Text
        LBReciboCliente.Text = TBNombreCliente.Text
        LBFecha.Text = Format(Now, "dd/MM/yyyy")
        LBFolio.Text = FolioCaja
        LBSaldoActualAnterior.Text = SaldoactualAnterior
        LBSaldoActual.Text = TBSaldoActual.Text
        LBReciboDescuento.Text = "$0.00"
        LBReciboConceptoDescripcion.Text = "ABONO"


    End Sub
    'Metodo para convertir un  DataTable a un arreglo JSON 
    Public Function GetJson(dt As DataTable) As String
        Dim JSSerializer As New JavaScriptSerializer()
        Dim DtRows As New List(Of Dictionary(Of String, Object))()
        Dim newrow As Dictionary(Of String, Object) = Nothing
        'Code to loop each row in the datatable and add it to the dictionary object
        For Each drow As DataRow In dt.Rows
            newrow = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                newrow.Add(col.ColumnName.Trim(), drow(col))
            Next
            DtRows.Add(newrow)
        Next
        'Serialising the dictionary object to produce json output
        Return JSSerializer.Serialize(DtRows)
    End Function




    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCaja.SelectedIndexChanged
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")

        Dim TablaCajaDetalle As New DataTable()
        Dim TablaVentaCaja As New DataTable()
        Dim TablaHistorialCaja As New DataTable()
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        'TBIdPersona.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("IdVenta")
        'TBNombreCliente.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("Nombre Cliente")
        EntidadCaja.IdPersona = IdPersonaBusqueda
        EntidadCaja.IdCCP = TablaCaja.Rows(GVCaja.SelectedIndex).Item("IdCCP") '#############################CAMBIAR IDCCP 
        EntidadCaja.FechaActual = Now
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioCaja.Consultar(EntidadCaja)
        TablaCajaDetalle = EntidadCaja.TablaConsulta
        TablaVentaCaja = EntidadCaja.TablaVentaCaja
        TablaHistorialCaja = EntidadCaja.TablaHistorialCaja

        TBFolio.Text = TablaCajaDetalle.Rows(0).Item("Folio")
        TBIdPersonaVenta.Text = TablaCajaDetalle.Rows(0).Item("IdPersona")
        TBNombreClienteVenta.Text = TablaCajaDetalle.Rows(0).Item("NombreCliente")
        TBSaldoActualVenta.Text = Format(TablaCajaDetalle.Rows(0).Item("SaldoActual"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBSaldoVencido.Text = Format(TablaCajaDetalle.Rows(0).Item("SaldoVencido"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBPeriodo.Text = TablaCajaDetalle.Rows(0).Item("Periodo")
        TBMonto.Text = Format(TablaCajaDetalle.Rows(0).Item("Monto"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBSumaAbonos.Text = Format(TablaCajaDetalle.Rows(0).Item("SumaAbonos"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBAnticipo.Text = Format(TablaCajaDetalle.Rows(0).Item("Anticipo"), Operacion.Configuracion.Constante.Formato.Moneda)
        LBMesGracia.Text = TablaCajaDetalle.Rows(0).Item("Gracia")
        LBPlazo.Text = TablaCajaDetalle.Rows(0).Item("Plazo")
        LBMesExtra.Text = TablaCajaDetalle.Rows(0).Item("Extra")
        LBNumeroAbonos.Text = (CInt(TablaCajaDetalle.Rows(0).Item("SumaAbonos") / TablaCajaDetalle.Rows(0).Item("Abono"))).ToString() + "/" + CStr(TablaCajaDetalle.Rows(0).Item("PeriodoCredito"))
        'LBNumeroAbonos.Text = CStr(TablaCajaDetalle.Rows(0).Item("NumeroAbonos")) + "/" + CStr(TablaCajaDetalle.Rows(0).Item("PeriodoCredito"))
        TBFechVenta.Text = TablaCajaDetalle.Rows(0).Item("Venta")
        TBFechaVencimineto.Text = TablaCajaDetalle.Rows(0).Item("VentaVencimiento")
        'TBAtraso.Text = TablaCajaDetalle.Rows(0).Item("")
        TBAbonoVenta.Text = Format(TablaCajaDetalle.Rows(0).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBDiasCredito.Text = TablaCajaDetalle.Rows(0).Item("DiasCredito")
        TBDiasTranscurridos.Text = TablaCajaDetalle.Rows(0).Item("DiasTranscurridos")
        TBDiasFaltantes.Text = TablaCajaDetalle.Rows(0).Item("DiasFaltantes")
        TBPrecioContado.Text = Format(TablaCajaDetalle.Rows(0).Item("TotalContado"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBCondonacionLiquidacion.Text = Format(TablaCajaDetalle.Rows(0).Item("Condonacion"), Operacion.Configuracion.Constante.Formato.Moneda)
        TBLiquidacion.Text = Format(TablaCajaDetalle.Rows(0).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
        Session("TablaCajaDetalle") = TablaCajaDetalle

        GVCajaVentaDetalle.Columns.Clear()
        GVCajaVentaDetalle.DataSource = TablaVentaCaja
        GVCajaVentaDetalle.AutoGenerateColumns = False
        GVCajaVentaDetalle.AllowSorting = True
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaVentaDetalle, New BoundField(), "Cantidad", "Cantidad")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaVentaDetalle, New BoundField(), "Codigo", "Codigo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaVentaDetalle, New BoundField(), "Producto", "Producto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaVentaDetalle, New BoundField(), "PrecioContado", "PrecioContado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaVentaDetalle, New BoundField(), "PrecioCredito", "PrecioCredito")
        GVCajaVentaDetalle.DataBind()
        Session("TablaVentaCaja") = TablaVentaCaja


        GVCajaHistorial.Columns.Clear()
        GVCajaHistorial.DataSource = TablaHistorialCaja
        GVCajaHistorial.AutoGenerateColumns = False
        GVCajaHistorial.AllowSorting = True
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaHistorial, New BoundField(), "No.", "NumeroAbonos")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaHistorial, New BoundField(), "Abonos", "Abono")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaHistorial, New BoundField(), "Fecha Creacion", "FechaCreacion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaHistorial, New BoundField(), "Forma Pago", "FormaPago")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCajaHistorial, New BoundField(), "Sucursal", "Sucursal")
        GVCajaHistorial.DataBind()
        Session("TablaVentaCaja") = TablaHistorialCaja




        'Format(TablaCajaDetalle.Rows(0).Item("SaldoActual"), Operacion.Configuracion.Constante.Formato.Moneda)
        'TBSaldoActual.Text = TBSaldoVencido.Text + SaldoActual
        MultiView1.SetActiveView(View3)



    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        IBTCancelar.Visible = False
        IBTReimprimir.Visible = False
        Nuevo()
        MultiView1.SetActiveView(View2)
    End Sub
    Protected Sub IBTReimprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTReimprimir.Click
        Recibo()
        Call BTNImprimir_Click(sender, e)
        MultiView1.SetActiveView(View5)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        TBIdPersona.Enabled = True
        TBAbono.Enabled = True
        TBDescuento.Enabled = True
        CBPorcentaje.Enabled = True
        IBTGuardar.Visible = True

        Dim EntidadCaja As New Entidad.Caja()
        Dim NegocioCaja As New Negocio.Caja()
        EntidadCaja.IdCaja = TBIdCaja.Text
        EntidadCaja.IdPersona = TBIdPersona.Text
        EntidadCaja.Observacion = IIf(TBObservaciones.Text Is String.Empty, "n/a", TBObservaciones.Text)
        EntidadCaja.IdEstado = 2
        EntidadCaja.IdUsuarioActualizacion = 1
        EntidadCaja.FechaActualizacion = DateTime.Now
        NegocioCaja.Cancelar(EntidadCaja)
        Nuevo()

    End Sub
    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub CBGVAbonoHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) ' aplicar tipo abono
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        SaldoActual = 0
        SaldoVencido = 0
        SaldoTotal = 0
        SumaAbonos = 0
        If CType(GVCaja.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked Then
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True
                SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(GVCaja.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = False
                If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                    SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                    CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                Else
                    SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Abono"))
                End If
            Next
        Else
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
                If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                    SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                End If
            Next
        End If
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        TBAbono.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        If EsDolar Then
            ConvertirADolares()
        End If
    End Sub
    Protected Sub CBGVAbonoItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'aplicar tipo abono
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        SumaAbonos = 0
        SaldoActual = 0



        For Each MiDataRow As GridViewRow In GVCaja.Rows
            If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(Convert.ToUInt64(MiDataRow.RowIndex)).Item("SaldoActual")) 'Convert.ToDouble(MiDataRow.Cells(6).Text)
            ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False

                SumaAbonos += TablaCaja.Rows(Convert.ToUInt64(MiDataRow.RowIndex)).Item("Abono") ' Convert.ToDouble(MiDataRow.Cells(5).Text)
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(Convert.ToUInt64(MiDataRow.RowIndex)).Item("SaldoActual"))
            ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Liquidacion"))
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            End If
        Next
        If SaldoActual = 0 Then
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            Next
        End If
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        TBAbono.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        If EsDolar Then
            ConvertirADolares()

        End If
    End Sub
    Protected Sub TBGVItemAbono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'aplicar tipo abono
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        SumaAbonos = 0
        'SaldoActual = 0
        For Each MiDataRow As GridViewRow In GVCaja.Rows
            If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False

                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual")) '''''''checar esta linea para el cambio de los Cells
            ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Abono"))
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Liquidacion"))
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            End If
        Next
        'If SaldoActual = 0 Then
        '    For Each MiDataRow As GridViewRow In GVCaja.Rows
        '        SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
        '    Next
        'End If
        'TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        TBAbono.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        If EsDolar Then
            ConvertirADolares()
        End If
    End Sub

    Protected Sub CBGVLiquidacionHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'aplicar tipo abono
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        SumaAbonos = 0
        SaldoActual = 0
        If CType(GVCaja.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked Then
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                CType(GVCaja.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked = False
                If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                    SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                    CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                Else
                    SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Liquidacion"))
                End If
            Next
        Else
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                    SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                    'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
                Else
                    CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                    'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
                End If
            Next
        End If
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        TBAbono.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        If EsDolar Then
            ConvertirADolares()
        End If
    End Sub
    Protected Sub CBGVLiquidacionItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Aplicar abono
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        SumaAbonos = 0
        SaldoActual = 0
        For Each MiDataRow As GridViewRow In GVCaja.Rows
            If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Liquidacion"))
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Abono"))
                'SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            End If
        Next
        If SaldoActual = 0 Then
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                SaldoActual += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("SaldoActual"))
            Next
        End If
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        TBAbono.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        If EsDolar Then
            ConvertirADolares()
        End If
    End Sub

    Protected Sub TBGVItemLiquidacion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        Dim TablaLiquidacionCaja As New DataTable()
        Dim EntidadCaja As New Entidad.Caja()
        Dim NegocioCaja As New Negocio.Caja()
        Dim TBGVLiquidacion As TextBox = CType(sender, TextBox)
        Dim index As Integer = 0
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBGVLiquidacion.Parent, DataControlFieldCell).Parent, GridViewRow)
        index = Convert.ToUInt64(gvrFilaActual.RowIndex)
        If Not CType(gvrFilaActual.FindControl("TBGVLiquidacion"), TextBox).Text Is String.Empty Then


            EntidadCaja.IdPersona = CInt(WUCBusquedaCliente.ObtenerIdPersona())
            EntidadCaja.FechaActual = CDate(CType(gvrFilaActual.FindControl("TBGVLiquidacion"), TextBox).Text)
            EntidadCaja.IdVenta = TablaCaja.Rows(index).Item("IdVenta")
            EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.InstrumentoDeCredito
            NegocioCaja.Consultar(EntidadCaja)
            TablaLiquidacionCaja = EntidadCaja.TablaConsulta
            CType(gvrFilaActual.FindControl("TBGVLiquidacion"), TextBox).Text = Format((TablaLiquidacionCaja.Rows(0).Item("Liquidacion")), Operacion.Configuracion.Constante.Formato.Moneda)
        End If
    End Sub
    Protected Sub GVPersonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPersonas.SelectedIndexChanged
        Dim Tabla As New DataTable()
        SaldoActual = 0
        Dim index As Integer = 0
        Dim TablaCaja As New DataTable()
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        Tabla = Session("Tabla")
        TBIdPersona.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        TBNombreCliente.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("Nombre")
        'Dim IdProducto = 0
        'Dim IdProductoCorto = ""
        'Dim Descripcion = ""
        'wucConsultarPersona1.ObtenerPersona()
        EntidadCaja.IdPersona = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        EntidadCaja.FechaActual = Now
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioCaja.Consultar(EntidadCaja)
        TablaCaja = EntidadCaja.TablaConsulta
        GVCaja.DataSource = TablaCaja
        If Bandera Then
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Ver Detalle"
            Columna.SelectText = "Ver Detalle"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVCaja.Columns.Add(Columna)
            Bandera = False
        End If
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.SelectText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GVCaja.Columns.Add(Columna)
        GVCaja.AutoGenerateColumns = False
        GVCaja.AllowSorting = True
        GVCaja.DataBind()
        Session("TablaCaja") = TablaCaja
        For Each MiDataRow As DataRow In TablaCaja.Rows
            'TBSaldoVencido.Text = CDbl("0")
            SaldoActual += CDbl(MiDataRow.Item("SaldoActual"))
        Next

        For Each MiDataRow As GridViewRow In GVCaja.Rows
            CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text = Format(TablaCaja.Rows(index).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
            CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Text = Format(TablaCaja.Rows(index).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
            index += 1
        Next
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        'TBSaldoActual.Text = TBSaldoVencido.Text + SaldoActual
        SaldoactualAnterior = TBSaldoActual.Text
        Condicion = True
        IBTCancelar.Visible = False
        GVPersonas.DataSource = Nothing
        GVPersonas.DataBind()
        TBBuscadorPersona.Text = ""
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub DDFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDFormaPago.SelectedIndexChanged
        LBEfectivoCambio.Text = "$0.00"
        Select Case DDFormaPago.SelectedItem.Text
            Case "EFECTIVO"
                TREfectivo.Visible = True
                'DOLARES
                EsDolar = False
                TRDolares.Visible = False
                TREfectivoDolares.Visible = False
                'TARJETA
                TRTarjeta.Visible = False
                TRTarjetaReferencia.Visible = False
                'CHEQUE
                TRCheque.Visible = False
                TRChequeReferencia.Visible = False
                'NOTACREDITO
                TRNotaCredito.Visible = False
                'VALE
                TRVale.Visible = False
            Case "DOLARES"
                TREfectivo.Visible = False
                'DOLARES
                TRDolares.Visible = True
                TREfectivoDolares.Visible = True
                EsDolar = True
                If Not TBAbono.Text Is String.Empty Then
                    DolarDespues = True
                    DolarAntes = False
                    ConvertirADolares()
                Else
                    DolarDespues = False
                    DolarAntes = True
                End If
                'TBAbono.Text = IIf(TBAbono.Text Is String.Empty, 0, 1)
                'TBAbono.Text = Format((CDbl(TBAbono.Text) / Dolar), Operacion.Configuracion.Constante.Formato.Moneda)
                'TARJETA
                TRTarjeta.Visible = False
                TRTarjetaReferencia.Visible = False
                'CHEQUE
                TRCheque.Visible = False
                TRChequeReferencia.Visible = False
                'NOTACREDITO
                TRNotaCredito.Visible = False
                'VALE
                TRVale.Visible = False
            Case "TARJETA"
                TREfectivo.Visible = False
                'DOLARES
                EsDolar = False
                TRDolares.Visible = False
                TREfectivoDolares.Visible = False
                'TARJETA
                'TRTarjeta.Visible = True
                TRTarjetaReferencia.Visible = True
                'CHEQUE
                TRCheque.Visible = False
                TRChequeReferencia.Visible = False
                'NOTACREDITO
                TRNotaCredito.Visible = False
                'VALE
                TRVale.Visible = False
            Case "CHEQUE"
                TREfectivo.Visible = False
                'DOLARES
                EsDolar = False
                TRDolares.Visible = False
                TREfectivoDolares.Visible = False
                'TARJETA
                TRTarjeta.Visible = False
                TRTarjetaReferencia.Visible = False
                'CHEQUE
                'TRCheque.Visible = True
                TRChequeReferencia.Visible = True
                'NOTACREDITO
                TRNotaCredito.Visible = False
                'VALE
                TRVale.Visible = False
            Case "NOTA DE CREDITO"
                TREfectivo.Visible = False
                'DOLARES
                EsDolar = False
                TRDolares.Visible = False
                TREfectivoDolares.Visible = False
                'TARJETA
                TRTarjeta.Visible = False
                TRTarjetaReferencia.Visible = False
                'CHEQUE
                TRCheque.Visible = False
                TRChequeReferencia.Visible = False
                'NOTACREDITO
                TRNotaCredito.Visible = True
                'VALE
                TRVale.Visible = False
            Case "VALE"
                EsDolar = False
                TREfectivo.Visible = False
                'DOLARES
                TRDolares.Visible = False
                TREfectivoDolares.Visible = False
                'TARJETA
                TRTarjeta.Visible = False
                TRTarjetaReferencia.Visible = False
                'CHEQUE
                TRCheque.Visible = False
                TRChequeReferencia.Visible = False
                'NOTACREDITO
                TRNotaCredito.Visible = False
                'VALE
                TRVale.Visible = True
            Case "MIXTO"
                'EFECTIVO
                TREfectivo.Visible = True
                'DOLARES
                EsDolar = False
                TRDolares.Visible = True
                TREfectivoDolares.Visible = True
                'TARJETA
                TRTarjeta.Visible = True
                TRTarjetaReferencia.Visible = True
                'CHEQUE
                TRCheque.Visible = True
                TRChequeReferencia.Visible = True
                'NOTACREDITO
                TRNotaCredito.Visible = True
                'VALE
                TRVale.Visible = True
        End Select
    End Sub
    Private Sub TextBoxOnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    'Sub Liquidacion()
    '    For Each MiDataRow As GridViewRow In GVCaja.Rows
    '        If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
    '            SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
    '        ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
    '            SumaLiquidacion += Convert.ToDouble(MiDataRow.Cells(9).Text)
    '        End If
    '    Next
    'End Sub
    'Sub SaldoActualVentas()
    '    For Each MiDataRow As GridViewRow In GVCaja.Rows
    '        If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Or CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
    '            SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
    '        End If
    '    Next
    'End Sub
    Protected Function SuCambio(ByVal Cambio As Double) As String
        Return Format(Cambio, Operacion.Configuracion.Constante.Formato.Moneda)
    End Function
    Protected Sub CBDescuento_CheckedChanged(sender As Object, e As EventArgs) Handles CBPorcentaje.CheckedChanged

    End Sub
    Protected Sub TBFechaLiquidacion_TextChanged(sender As Object, e As EventArgs) Handles TBFechaLiquidacion.TextChanged
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")

        Dim TablaCajaDetalle As New DataTable()
        TablaCajaDetalle = Session("TablaCajaDetalle")

        Dim TablaLiquidacionCaja As New DataTable()

        Dim EntidadCaja As New Entidad.Caja()
        Dim NegocioCaja As New Negocio.Caja()

        EntidadCaja.IdPersona = TBIdPersonaVenta.Text
        EntidadCaja.FechaActual = CDate(TBFechaLiquidacion.Text)
        EntidadCaja.IdVenta = TablaCaja.Rows(GVCaja.SelectedIndex).Item("IdVenta")
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.InstrumentoDeCredito
        NegocioCaja.Consultar(EntidadCaja)
        TablaLiquidacionCaja = EntidadCaja.TablaConsulta
        LBCondonacion.Text = "Condonacion si Liquida: " + Format(TablaCajaDetalle.Rows(0).Item("SaldoActual") - (TablaLiquidacionCaja.Rows(0).Item("Liquidacion")), Operacion.Configuracion.Constante.Formato.Moneda)
        LBLiquidacion.Text = "Monto de Liquidacion: " + Format((TablaLiquidacionCaja.Rows(0).Item("Liquidacion")), Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub
    Protected Sub ConvertirADolares()
        Dim TablaCaja As New DataTable()
        TablaCaja = Session("TablaCaja")
        SumaAbonos = 0
        SonDolares = 0
        'Sub Abono(ByVal Abonos As Double)
        If DolarDespues Then
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                    SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                    SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Abono"))
                End If
            Next
            SonDolares = (SumaAbonos / Dolar)
            TBAbono.Text = Format((SumaAbonos / Dolar), Operacion.Configuracion.Constante.Formato.Moneda)
        ElseIf DolarAntes Then
            For Each MiDataRow As GridViewRow In GVCaja.Rows
                If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                    SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                    SumaAbonos += Convert.ToDouble(TablaCaja.Rows(MiDataRow.RowIndex).Item("Abono")) / Dolar
                End If
            Next
            SonDolares = SumaAbonos
            TBAbono.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        End If

        'End Sub

    End Sub
    Protected Sub TBEfectivo_TextChanged(sender As Object, e As EventArgs) Handles TBEfectivo.TextChanged
        Dim Cambio As Double = CDbl(TBEfectivo.Text) - CDbl(TBAbono.Text)
        LBEfectivoCambio.Text = SuCambio(Cambio)
        EsMixto()
    End Sub

    Protected Sub TBDolares_TextChanged(sender As Object, e As EventArgs) Handles TBDolares.TextChanged
        Dim Cambio As Double
        If EsDolar Then
            Cambio = (CDbl(TBDolares.Text)) - (CDbl(TBAbono.Text))
            Cambio = Cambio * Dolar
        Else
            Cambio = (CDbl(TBDolares.Text) * Dolar) - (CDbl(TBAbono.Text))
        End If
        LBEfectivoCambio.Text = SuCambio(Cambio)
        EsMixto()
    End Sub
    Protected Sub TBTarjeta_TextChanged(sender As Object, e As EventArgs) Handles TBTarjeta.TextChanged
        Dim Cambio As Double = CDbl(TBTarjeta.Text) - CDbl(TBAbono.Text)
        LBEfectivoCambio.Text = SuCambio(Cambio)
        EsMixto()
    End Sub

    Protected Sub TBCheque_TextChanged(sender As Object, e As EventArgs) Handles TBCheque.TextChanged
        Dim Cambio As Double = CDbl(TBCheque.Text) - CDbl(TBAbono.Text)
        LBEfectivoCambio.Text = SuCambio(Cambio)
        EsMixto()
    End Sub

    Protected Sub TBValeReferencia_TextChanged(sender As Object, e As EventArgs) Handles TBVale.TextChanged
        Dim Cambio As Double = CDbl(TBVale.Text) - CDbl(TBAbono.Text)
        LBEfectivoCambio.Text = "$" + CStr(Cambio)
    End Sub

    Protected Sub EsMixto()
        If DDFormaPago.SelectedItem.Text = "MIXTO" Then
            Dim CambioMixto As Double = 0
            If Not TBEfectivo.Text Is String.Empty Then
                CambioMixto += CDbl(TBEfectivo.Text)
            End If
            If Not TBDolares.Text Is String.Empty Then
                CambioMixto += (CDbl(TBDolares.Text) * Dolar)
            End If
            If Not TBTarjeta.Text Is String.Empty Then
                CambioMixto += CDbl(TBTarjeta.Text)
            End If
            If Not TBCheque.Text Is String.Empty Then
                CambioMixto += CDbl(TBCheque.Text)
            End If
            If Not TBNotaCreditoReferencia.Text Is String.Empty Then
                CambioMixto += CDbl(TBNotaCreditoReferencia.Text)
            End If
            If Not TBVale.Text Is String.Empty Then
                CambioMixto += CDbl(TBVale.Text)
            End If
            LBEfectivoCambio.Text = SuCambio(CambioMixto - CDbl(TBAbono.Text))
        End If
    End Sub
    Protected Sub IBTConsultarAbonos_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultarAbonos.Click

        Dim TablaCajaMovimiento As New DataTable()
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        EntidadCaja.FechaActual = Now
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioCaja.Consultar(EntidadCaja)
        TablaCajaMovimiento = EntidadCaja.TablaConsulta
        GVMovimiento.DataSource = TablaCajaMovimiento
        'GVMovimiento.AutoGenerateColumns = False
        GVMovimiento.AllowSorting = True
        GVMovimiento.DataBind()
        Session("TablaCajaMovimiento") = TablaCajaMovimiento

        MultiView1.SetActiveView(View6)
    End Sub

    Protected Sub IBTRegresarPersona_Click(sender As Object, e As ImageClickEventArgs) Handles IBTRegresarPersona.Click
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTRegresarVerDetalle_Click(sender As Object, e As ImageClickEventArgs) Handles IBTRegresarVerDetalle.Click
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        Nuevo()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub BTNImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles BTNImprimir.Click
        Dim cstype As Type = Me.GetType()
        ''imprSelec('TablaEncabezado','TablaImprimir');
        ClientScript.RegisterStartupScript(cstype, "ejecutar script", "window.print()", True)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        'Dim lol As String = CBPorcentaje.Text
        Dim Tabla As New DataTable()
        EntidadPersona.Buscar = TBBuscadorPersona.Text
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioPersona.Consultar(EntidadPersona)
        Tabla = EntidadPersona.TablaConsulta
        GVPersonas.Columns.Clear()
        GVPersonas.DataSource = Tabla
        GVPersonas.AutoGenerateColumns = False
        GVPersonas.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.SelectText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPersonas.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "Nombre Cliente", "Nombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "Tipo Estado", "TipoEstado")
        GVPersonas.DataBind()
        Session("Tabla") = Tabla
    End Sub







    Protected Sub IMRegresarMovimiento_Click(sender As Object, e As ImageClickEventArgs) Handles IMRegresarMovimiento.Click
        MultiView1.SetActiveView(View1)
    End Sub


    Protected Sub IBTConsultarMovimiento_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultarMovimiento.Click
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        EntidadCaja.FechaActual = IIf(TBBuscarMovimientos.Text Is String.Empty, Now, TBBuscarMovimientos.Text)
        Dim TablaCajaMovimiento As New DataTable()
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioCaja.Consultar(EntidadCaja)
        TablaCajaMovimiento = EntidadCaja.TablaConsulta
        GVMovimiento.Columns.Clear()
        GVMovimiento.DataSource = TablaCajaMovimiento
        GVMovimiento.AutoGenerateColumns = False
        GVMovimiento.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.SelectText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVMovimiento.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMovimiento, New BoundField(), "Folio", "Recibo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMovimiento, New BoundField(), "Nombre", "NombreCliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMovimiento, New BoundField(), "Abono", "Abono")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMovimiento, New BoundField(), "Fecha", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVMovimiento, New BoundField(), "Estado", "Estado")
        GVMovimiento.DataBind()
        Session("TablaCajaMovimiento") = TablaCajaMovimiento
    End Sub

    Protected Sub GVMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVMovimiento.SelectedIndexChanged

        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()

        IBTCancelar.Visible = True

        TBIdPersona.Enabled = False
        TBAbono.Enabled = False
        TBDescuento.Enabled = False
        CBPorcentaje.Enabled = False
        IBTGuardar.Visible = False

        Dim TablaCajaMovimiento As New DataTable()
        TablaCajaMovimiento = Session("TablaCajaMovimiento")
        EntidadCaja.IdCaja = TablaCajaMovimiento.Rows(GVMovimiento.SelectedIndex).Item("IdCaja")
        EntidadCaja.IdPersona = TablaCajaMovimiento.Rows(GVMovimiento.SelectedIndex).Item("IdPersona")

        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno


        NegocioCaja.Consultar(EntidadCaja)
        TablaCajaMovimiento = EntidadCaja.TablaConsulta
        TBIdCaja.Text = TablaCajaMovimiento.Rows(0).Item("IdCaja")
        TBRecibo.Text = TablaCajaMovimiento.Rows(0).Item("Recibo")
        TBIdPersona.Text = TablaCajaMovimiento.Rows(0).Item("IdPersona")
        TBNombreCliente.Text = TablaCajaMovimiento.Rows(0).Item("NombreCliente")
        'TBSaldoActual.Text = TablaCajaMovimiento.Rows(0).Item("SaldoActual")
        TBAbono.Text = TablaCajaMovimiento.Rows(0).Item("PagoAbono")
        TBDescuento.Text = TablaCajaMovimiento.Rows(0).Item("Descuento")
        CBPorcentaje.Checked = IIf(TablaCajaMovimiento.Rows(0).Item("Porcentaje") = 0, False, True)
        'TBFecha.Text = TablaCajaMovimiento.Rows(0).Item("FechaCreacion")
        TBObservaciones.Text = TablaCajaMovimiento.Rows(0).Item("Observacion")


        wucDatosAuditoria1.SeleccionarIndice(TablaCajaMovimiento.Rows(0))
        wucDatosAuditoria1.Visible = True



        Dim Tabla As New DataTable()
        SaldoActual = 0
        Dim index As Integer = 0
        Dim TablaCaja As New DataTable()

        Tabla = Session("Tabla")
        'TBIdPersona.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        'TBNombreCliente.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("Nombre")
        ''Dim IdProducto = 0
        ''Dim IdProductoCorto = ""
        ''Dim Descripcion = ""
        ''wucConsultarPersona1.ObtenerPersona()
        'EntidadCaja.IdPersona = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        EntidadCaja.FechaActual = Now
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioCaja.Consultar(EntidadCaja)
        TablaCaja = EntidadCaja.TablaConsulta
        GVCaja.DataSource = TablaCaja
        If Bandera Then
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Ver Detalle"
            Columna.SelectText = "Ver Detalle"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVCaja.Columns.Add(Columna)
            Bandera = False
        End If
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.SelectText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GVCaja.Columns.Add(Columna)
        GVCaja.AutoGenerateColumns = False
        GVCaja.AllowSorting = True
        GVCaja.DataBind()
        Session("TablaCaja") = TablaCaja
        For Each MiDataRow As DataRow In TablaCaja.Rows
            'TBSaldoVencido.Text = CDbl("0")
            SaldoActual += CDbl(MiDataRow.Item("SaldoActual"))
        Next

        For Each MiDataRow As GridViewRow In GVCaja.Rows
            CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text = Format(TablaCaja.Rows(index).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
            CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Text = Format(TablaCaja.Rows(index).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
            index += 1
        Next
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        'TBSaldoActual.Text = TBSaldoVencido.Text + SaldoActual
        SaldoactualAnterior = TBSaldoActual.Text
        Condicion = True
        IBTCancelar.Visible = True
        IBTReimprimir.Visible = True
        MultiView1.SetActiveView(View1)
    End Sub
    <System.Web.Script.Services.ScriptMethod(), _
    System.Web.Services.WebMethod()> _
    Public Shared Function SearchCustomers(ByVal prefixText As String) As List(Of String)
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        'Dim lol As String = CBPorcentaje.Text
        Dim TablaBusquedaPersona As New DataTable()
        EntidadPersona.Buscar = prefixText
        Busqueda = prefixText
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioPersona.Consultar(EntidadPersona)
        TablaBusquedaPersona = EntidadPersona.TablaConsulta
        Dim lista As New List(Of String)
        For Each MiDataRow As DataRow In TablaBusquedaPersona.Rows
            lista.Add(MiDataRow.Item("Nombre").ToString())
        Next
        Return lista
    End Function

    'Protected Sub TBReciboPrueba_TextChanged(sender As Object, e As EventArgs) Handles TBReciboPrueba.TextChanged
    '    Dim NegocioPersona As New Negocio.Persona()
    '    Dim EntidadPersona As New Entidad.Persona()
    '    Dim TablaBusquedaPersona As New DataTable()
    '    Dim Id As Integer
    '    EntidadPersona.Buscar = Busqueda
    '    EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
    '    NegocioPersona.Consultar(EntidadPersona)
    '    TablaBusquedaPersona = EntidadPersona.TablaConsulta
    '    Dim lista As New List(Of String)
    '    For Each MiDataRow As DataRow In TablaBusquedaPersona.Rows
    '        lista.Add(MiDataRow.Item("Nombre").ToString())
    '    Next

    '    Id = TablaBusquedaPersona.Rows(lista.IndexOf(TBReciboPrueba.Text)).Item("ID")
    '    MySub(Id)
    'End Sub
    Sub MySub(ByVal Id As Integer)
        SaldoActual = 0
        Dim index As Integer = 0
        Dim TablaCaja As New DataTable()
        Dim NegocioCaja As New Negocio.Caja()
        Dim EntidadCaja As New Entidad.Caja()
        'Tabla = Session("Tabla")
        'TBIdPersona.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        'TBNombreCliente.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("Nombre")
        'Dim IdProducto = 0
        'Dim IdProductoCorto = ""
        'Dim Descripcion = ""
        'wucConsultarPersona1.ObtenerPersona()
        EntidadCaja.IdPersona = Id
        IdPersonaBusqueda = Id
        EntidadCaja.FechaActual = Now
        EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioCaja.Consultar(EntidadCaja)
        TablaCaja = EntidadCaja.TablaConsulta
        GVCaja.DataSource = TablaCaja
        If Bandera Then
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Ver Detalle"
            Columna.SelectText = "Ver Detalle"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVCaja.Columns.Add(Columna)
            Bandera = False
        End If


        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.SelectText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GVCaja.Columns.Add(Columna)
        GVCaja.AutoGenerateColumns = False
        GVCaja.AllowSorting = True
        GVCaja.DataBind()
        Session("TablaCaja") = TablaCaja
        For Each MiDataRow As DataRow In TablaCaja.Rows
            'TBSaldoVencido.Text = CDbl("0")
            SaldoActual += CDbl(MiDataRow.Item("SaldoActual"))
        Next

        For Each MiDataRow As GridViewRow In GVCaja.Rows
            CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text = Format(TablaCaja.Rows(index).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
            CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Text = Format(TablaCaja.Rows(index).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
            index += 1
        Next
        TBSaldoActual.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        'TBSaldoActual.Text = TBSaldoVencido.Text + SaldoActual
        SaldoactualAnterior = TBSaldoActual.Text
        Condicion = True
        IBTCancelar.Visible = False
        GVPersonas.DataSource = Nothing
        GVPersonas.DataBind()
        TBBuscadorPersona.Text = ""
    End Sub

    Protected Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click
        MySub(CInt(WUCBusquedaCliente.ObtenerIdPersona()))

    End Sub
End Class