Imports System.Data
Imports System.Windows.Forms
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page

    Public TablaCCPDetalle As New DataTable()
    Public VistaCCPDetalle As New DataView()


    Public TablaFormaPagoDetalleCaja As New DataTable()
    Shared SaldoActual As Double
    Shared EstadoCuenta As Integer
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Cuentas Por Cobrar"
            LlenarDDs()
            '######################### TABLA CCP DETALLE ################################
            TablaCCPDetalle.Columns.Clear()      
            TablaCCPDetalle.Columns.Add(New DataColumn("IdCCP", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdTransaccion", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdTipoDocumento", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("Serie", System.Type.GetType("System.String")))
            TablaCCPDetalle.Columns.Add(New DataColumn("Folio", System.Type.GetType("System.String")))
            TablaCCPDetalle.Columns.Add(New DataColumn("Fecha", System.Type.GetType("System.DateTime")))
            TablaCCPDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaCCPDetalle.Columns.Add(New DataColumn("Observacion", System.Type.GetType("System.String")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdCajaMovimiento", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("MontoTransaccion", System.Type.GetType("System.Double")))
            TablaCCPDetalle.Columns.Add(New DataColumn("Impuesto", System.Type.GetType("System.Double")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdUsuarioCreacion", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("FechaCreacion", System.Type.GetType("System.DateTime")))
            TablaCCPDetalle.Columns.Add(New DataColumn("IdUsuarioActualizacion", System.Type.GetType("System.Int32")))
            TablaCCPDetalle.Columns.Add(New DataColumn("FechaActualizacion", System.Type.GetType("System.DateTime")))
            VistaCCPDetalle = TablaCCPDetalle.DefaultView

            Session("TablaCCPDetalle") = TablaCCPDetalle
            Session("VistaCCPDetalle") = VistaCCPDetalle

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
            Nuevo()
            '##############################################################################
            MultiView1.SetActiveView(View1)
        Else
            TablaCCPDetalle = Session("TablaCCPDetalle")
            VistaCCPDetalle = Session("VistaCCPDetalle")
            TablaFormaPagoDetalleCaja = Session("TablaFormaPagoDetalleCaja")
        End If

    End Sub
    Private Sub LlenarDDs()
        DDEstado.Items.Add(New ListItem("ACTIVO", 4))
        DDEstado.Items.Add(New ListItem("CANCELADA", 2))
        'DDEstado.Items.Add(New ListItem("LIQUIDADO", 5))
        DDEstado.SelectedValue = 4
        '------------Transaccion--------------
        DDIdTransaccion.Items.Add(New ListItem("CARGO", 1))
        DDIdTransaccion.Items.Add(New ListItem("ABONO", 2))
        DDIdTransaccion.SelectedValue = 2
        '-----------Tipo Doc Encabezado--------------------
        Dim NegocioCCP As New Negocio.CCP()
        Dim EntidadCCP As New Entidad.CCP()
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        NegocioCCP.Consultar(EntidadCCP)
        DDIdTipoDocumento.DataSource = EntidadCCP.TablaConsulta
        DDIdTipoDocumento.DataValueField = "ID"
        DDIdTipoDocumento.DataTextField = "Descripcion"
        DDIdTipoDocumento.DataBind()
        '-----------Tipo Doc Transaccion--------------------
        DDIdTipoDocumentoTransaccion.DataSource = EntidadCCP.TablaConsulta
        DDIdTipoDocumentoTransaccion.DataValueField = "ID"
        DDIdTipoDocumentoTransaccion.DataTextField = "Descripcion"
        DDIdTipoDocumentoTransaccion.DataBind()
    End Sub
    Private Sub Inhabilitar()
        'DDEstado.Enabled = False
        TBFecha.Enabled = False
        TBFechaVencimientoE.Enabled = False
        TBDescripcion.Enabled = False
        TBMonto.Enabled = False
        TBIVA.Enabled = False
        TBIEPS.Enabled = False
        TBSubtotal.Enabled = False
        TBCargo.Enabled = False
        TBAbono.Enabled = False
        DDIdTipoDocumento.Enabled = False
        TBSerie.Enabled = False
        TBFolioE.Enabled = False
        ' TBObservacion.Enabled = False
    End Sub
    Private Sub Habilitar()
        DDEstado.Enabled = True
        TBFecha.Enabled = True
        TBFechaVencimientoE.Enabled = True
        TBDescripcion.Enabled = True
        TBMonto.Enabled = True
        TBIVA.Enabled = True
        TBIEPS.Enabled = True
        TBSubtotal.Enabled = True
        TBCargo.Enabled = True
        TBAbono.Enabled = True
        DDIdTipoDocumento.Enabled = True
        TBSerie.Enabled = True
        TBFolioE.Enabled = True
        TBObservacion.Enabled = True
    End Sub
    Private Sub Nuevo()
        TBIdCCP.Text = ""
        TBFecha.Text = Now.ToString("dd/MM/yyyy")
        DDEstado.SelectedValue = 4
        TBFechaVencimientoE.Text = ""
        TBDescripcion.Text = ""
        TBMonto.Text = ""
        TBIVA.Text = "0"
        TBIEPS.Text = "0"
        TBSubtotal.Text = "0"
        TBCargo.Text = "0"
        TBAbono.Text = "0"
        TBSaldo.Text = "0"
        wucDatosAuditoria1.Visible = False
        DDIdTipoDocumento.SelectedValue = 1
        TBSerie.Text = ""
        TBFolioE.Text = ""
        TBObservacion.Text = ""
        TBIdClienteTransaccion.Text = ""
        TBNombreCliente.Text = ""
        TBSaldoVigenteTransaccion.Text = "0"
        TBSaldoVencidoTransaccion.Text = "0"
        DDIdTransaccion.Text = 2
        TBAbonarTransaccion.Text = "0"
        TBDescripcionTransaccion.Text = ""
        TBPagoTransaccion.Text = "0"
        TBCambioTransaccion.Text = "0"
        DDIdTipoDocumentoTransaccion.SelectedValue = 1
        TBSerieTransaccion.Text = ""
        TBFolioTransaccion.Text = ""
        TBObservacionTransaccion.Text = ""
        TBSaldoVencido.Text = "0"
        TBSaldoTotalTransaccion.Text = "0"
        GVCCP.DataSource = Nothing
        GVCCP.DataBind()
        GVPersonas.DataSource = Nothing
        GVPersonas.DataBind()
        GVCargosAbonos.DataSource = Nothing
        GVCargosAbonos.DataBind()
        GVProductos.DataSource = Nothing
        GVProductos.DataBind()
        'wucConPer.AsignarPersona(0, "", "")
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Habilitar()
        Nuevo()
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        InsertarTransaccion()
    End Sub
    Private Sub InsertarTransaccion()
        Dim EntidadCCP As New Entidad.CCP()
        Dim NegocioCCP As New Negocio.CCP()


        Dim IdPersona As Integer
        'Dim Equivalencia As String
        'Dim Nombre As String
        TablaCCPDetalle = Session("TablaCCPDetalle")
        VistaCCPDetalle = Session("VistaCCPDetalle")
        Dim TablaCCP As New DataTable()
        If TBIdCCP.Text Is String.Empty Then
            EntidadCCP.IdCCP = IIf(TBIdCCP.Text Is String.Empty, 0, TBIdCCP.Text)
            'wucConPer.ObtenerPersona(IdPersona, Equivalencia, Nombre)
            'wucConProv.ObtenerPersona(IdPersona, "", "")
            IdPersona = wucConPer.ObtenerIdPersona()
            EntidadCCP.IdPersona = IdPersona
            EntidadCCP.IdTipoDocumento = DDIdTipoDocumento.SelectedValue
            EntidadCCP.Serie = IIf(TBSerie.Text Is String.Empty, "A", TBSerie.Text)
            EntidadCCP.Folio = IIf(TBFolioE.Text Is String.Empty, 0, TBFolioE.Text)
            EntidadCCP.FechaExpedicion = TBFecha.Text
            EntidadCCP.FechaVencimiento = TBFechaVencimientoE.Text
            EntidadCCP.Descripcion = TBDescripcion.Text
            EntidadCCP.Observacion = TBObservacion.Text
            EntidadCCP.Monto = IIf(TBMonto.Text Is String.Empty, 0, TBMonto.Text)
            EntidadCCP.IVA = IIf(TBIVA.Text Is String.Empty, 0, TBIVA.Text)
            EntidadCCP.IEPS = IIf(TBIEPS.Text Is String.Empty, 0, TBIEPS.Text)
            EntidadCCP.Subtotal = IIf(TBSubtotal.Text Is String.Empty, 0, TBSubtotal.Text)
            EntidadCCP.IdTipoCCP = 1
            EntidadCCP.IdEstado = DDEstado.SelectedValue

            Dim RenglonAInsertar As DataRow
            If Not TBCargo.Text Is String.Empty And TBCargo.Text > 0 Then
                RenglonAInsertar = TablaCCPDetalle.NewRow()
                RenglonAInsertar("IdCCP") = EntidadCCP.IdCCP
                RenglonAInsertar("IdTransaccion") = 1
                RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumento.SelectedValue
                RenglonAInsertar("Serie") = TBSerie.Text
                RenglonAInsertar("Folio") = TBFolioE.Text
                RenglonAInsertar("Fecha") = TBFecha.Text
                RenglonAInsertar("Descripcion") = TBDescripcion.Text
                RenglonAInsertar("Observacion") = TBObservacion.Text
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("MontoTransaccion") = TBCargo.Text
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("IdSucursal") = 1
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = Now
                TablaCCPDetalle.Rows.Add(RenglonAInsertar)
            End If
            If Not TBAbono.Text Is String.Empty And TBAbono.Text > 0 Then
                RenglonAInsertar = TablaCCPDetalle.NewRow()
                RenglonAInsertar("IdCCP") = EntidadCCP.IdCCP
                RenglonAInsertar("IdTransaccion") = 2
                RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumento.SelectedValue
                RenglonAInsertar("Serie") = TBSerie.Text
                RenglonAInsertar("Folio") = TBFolioE.Text
                RenglonAInsertar("Fecha") = TBFecha.Text
                RenglonAInsertar("Descripcion") = TBDescripcion.Text
                RenglonAInsertar("Observacion") = TBObservacion.Text
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("MontoTransaccion") = TBAbono.Text
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("IdSucursal") = 1
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = Now
                TablaCCPDetalle.Rows.Add(RenglonAInsertar)
            End If
        Else
            EntidadCCP.IdCCP = TBIdCCP.Text
            EntidadCCP.IdEstado = DDEstado.SelectedValue
            EntidadCCP.Observacion = TBObservacion.Text
        End If
        EntidadCCP.TablaMovimientos = TablaCCPDetalle
        NegocioCCP.GuardarCCP(EntidadCCP)
        TBIdCCP.Text = EntidadCCP.IdCCP
        TablaCCPDetalle.Clear()
        Session("TablaCCPDetalle") = TablaCCPDetalle
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCCP.SelectedIndexChanged

        Dim EntidadCCP As New Entidad.CCP()
        Dim NegocioCCP As New Negocio.CCP()
        Dim TablaCCPConsultaCargosAbonos As New DataTable()
        Dim TablaCCPConsultaCargosAbonos2 As New DataTable()
        TablaCCPConsultaCargosAbonos = Session("TablaCCPConsulta")
        Dim index As Integer = GVCCP.SelectedIndex
        Dim valor As Integer = TablaCCPConsultaCargosAbonos.Rows(index).Item("IdCCP")
        EntidadCCP.IdCCP = CInt(valor)
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        NegocioCCP.Obtener(EntidadCCP)
        TablaCCPConsultaCargosAbonos2 = EntidadCCP.TablaConsulta        
        GVCargosAbonos.DataSource = TablaCCPConsultaCargosAbonos2
        GVCargosAbonos.AutoGenerateColumns = True
        GVCargosAbonos.AllowSorting = True
        GVCargosAbonos.DataBind()


        MultiView1.SetActiveView(View4)
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        'Revisar Que Clientes Y/O Proveedores
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadPersona As New Entidad.Persona()
        Dim Tabla As New DataTable()
        EntidadPersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaCXP
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
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "RazonSocial", "RazonSocial")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "Representante", "Representante")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPersonas, New BoundField(), "Estado", "Estado")
        GVPersonas.DataBind()
        Session("Tabla") = Tabla
        MultiView1.SetActiveView(View2)
    End Sub
    Protected Sub IBTReimprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTReimprimir.Click

    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click

    End Sub
    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub CBGVAbonoHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) ' aplicar tipo abono
        If CType(GVCCP.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked = True Then
            For Each MiDataRow As GridViewRow In GVCCP.Rows
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(GVCCP.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
            Next
        Else
            For Each MiDataRow As GridViewRow In GVCCP.Rows
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                'CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                'CType(GVCCP.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = False
                'CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""

            Next
        End If
    End Sub
    Protected Sub CBGVAbonoItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'aplicar tipo abono
        'Dim TablaCaja As New DataTable()
        'TablaCaja = Session("TablaCaja")
        'SumaAbonos = 0
        'SaldoActual = 0
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            If CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
                CType(GVCCP.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = False
            End If
        Next

        'If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
        '    CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
        '    CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
        'ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
        '    CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
        'ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
        '    CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
        'End If

        'If SaldoActual = 0 Then
        '    For Each MiDataRow As GridViewRow In GVCaja.Rows
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    Next
        'End If
        'TBDescripcion.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        'TBIVA.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        'If EsDolar Then
        '    ConvertirADolares()

        'End If
    End Sub

    Protected Sub TBGVAbono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim TablaCCP As New DataTable()
        TablaCCP = Session("TablaCCPConsulta")
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            Dim Abono As Double
            Dim Saldo As Double

            Saldo = Convert.ToDouble(TablaCCP.Rows(MiDataRow.RowIndex).Item("SaldoActual")) 'Convert.ToDouble(MiDataRow.Cells(9).Text)
            Abono = 0
            If IsNumeric(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text) Then
                Abono = Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)

                If 0 < Abono Then
                    If Not (CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text) Is String.Empty Then
                        Abono = Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                        ' EstadoCuenta = 4
                        CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                        CType(GVCCP.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = False
                        CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                        CType(GVCCP.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked = False
                    End If
                    If Abono > Saldo Then
                        If DDIdTransaccion.SelectedValue = 2 Then
                            CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = Saldo.ToString
                            '  EstadoCuenta = 5
                        End If

                    End If
                Else

                    CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
                End If

            Else
                CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
            End If
        Next
    End Sub
    Protected Sub TBGVItemAbono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'aplicar tipo abono

        'Dim TablaCaja As New DataTable()
        'TablaCaja = Session("TablaCaja")
        'SumaAbonos = 0
        'SaldoActual = 0
        'For Each MiDataRow As GridViewRow In GVCaja.Rows
        '    If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
        '        SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
        '        CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
        '        CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
        '        CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
        '        SumaAbonos += Convert.ToDouble(MiDataRow.Cells(5).Text)
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
        '        CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
        '        SumaAbonos += Convert.ToDouble(MiDataRow.Cells(9).Text)
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    End If
        'Next
        'If SaldoActual = 0 Then
        '    For Each MiDataRow As GridViewRow In GVCaja.Rows
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    Next
        'End If
        'TBDescripcion.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        'TBIVA.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        'If EsDolar Then
        '    ConvertirADolares()
        'End If
    End Sub


    Protected Sub CBGVLiquidacionHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'aplicar tipo abono



        If CType(GVCCP.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = True Then
            For Each MiDataRow As GridViewRow In GVCCP.Rows
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                CType(GVCCP.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
            Next
        Else
            For Each MiDataRow As GridViewRow In GVCCP.Rows
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False

            Next
        End If
    End Sub
    Protected Sub CBGVLiquidacionItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Aplicar abono




        For Each MiDataRow As GridViewRow In GVCCP.Rows
            If CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                CType(GVCCP.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
            End If
        Next
        'Dim TablaCaja As New DataTable()
        'TablaCaja = Session("TablaCaja")
        'SumaAbonos = 0
        'SaldoActual = 0
        'For Each MiDataRow As GridViewRow In GVCaja.Rows
        '    If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
        '        SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
        '        CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
        '        CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
        '        CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
        '        SumaAbonos += Convert.ToDouble(MiDataRow.Cells(9).Text)
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
        '        CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
        '        SumaAbonos += Convert.ToDouble(MiDataRow.Cells(5).Text)
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    End If
        'Next
        'If SaldoActual = 0 Then
        '    For Each MiDataRow As GridViewRow In GVCaja.Rows
        '        SaldoActual += Convert.ToDouble(MiDataRow.Cells(6).Text)
        '    Next
        'End If
        'TBDescripcion.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        'TBIVA.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        'If EsDolar Then
        '    ConvertirADolares()
        'End If
    End Sub

    Protected Sub TBGVItemLiquidacion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim TablaCaja As New DataTable()
        'TablaCaja = Session("TablaCaja")

        'Dim TablaLiquidacionCaja As New DataTable()

        'Dim EntidadCaja As New Entidad.Caja()
        'Dim NegocioCaja As New Negocio.Caja()

        'Dim TBGVLiquidacion As TextBox = CType(sender, TextBox)
        'Dim index As Integer = 0
        'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBGVLiquidacion.Parent, DataControlFieldCell).Parent, GridViewRow)
        'index = Convert.ToUInt64(gvrFilaActual.RowIndex)
        'If Not CType(gvrFilaActual.FindControl("TBGVLiquidacion"), TextBox).Text Is String.Empty Then


        '    EntidadCaja.IdPersona = TBIdPersona.Text
        '    EntidadCaja.FechaActual = CDate(CType(gvrFilaActual.FindControl("TBGVLiquidacion"), TextBox).Text)
        '    EntidadCaja.IdVenta = TablaCaja.Rows(index).Item("IdVenta")
        '    EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.InstrumentoDeCredito
        '    NegocioCaja.Consultar(EntidadCaja)
        '    TablaLiquidacionCaja = EntidadCaja.TablaConsulta
        '    CType(gvrFilaActual.FindControl("TBGVLiquidacion"), TextBox).Text = Format((TablaLiquidacionCaja.Rows(0).Item("Liquidacion")), Operacion.Configuracion.Constante.Formato.Moneda)
        'End If
    End Sub
    Protected Sub GVPersonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPersonas.SelectedIndexChanged
        Nuevo()
        Dim Tabla As New DataTable()
        SaldoActual = 0
        SaldoVencido = 0
        SaldoTotal = 0
        Dim index As Integer = 0
        Dim TablaCCPConsulta As New DataTable()
        Dim NegocioCCP As New Negocio.CCP()
        Dim EntidadCCP As New Entidad.CCP()
        Tabla = Session("Tabla")

        TBIdClienteTransaccion.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        TBNombreCliente.Text = Tabla.Rows(GVPersonas.SelectedIndex).Item("RazonSocial")
        EntidadCCP.IdPersona = Tabla.Rows(GVPersonas.SelectedIndex).Item("ID")
        EntidadCCP.FechaActual = Now
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioCCP.Consultar(EntidadCCP)
        TablaCCPConsulta = EntidadCCP.TablaConsulta
        GVCCP.DataSource = TablaCCPConsulta
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.SelectText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GVCCP.Columns.Add(Columna)
        GVCCP.AutoGenerateColumns = False
        GVCCP.AllowSorting = True
        GVCCP.DataBind()
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text = Format(TablaCCPConsulta.Rows(index).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
            CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Text = Format(TablaCCPConsulta.Rows(index).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
            index += 1
        Next
        For Each MiDataRow As DataRow In TablaCCPConsulta.Rows
            SaldoActual += CDbl(MiDataRow.Item("SaldoVigente"))
        Next
        TBSaldoVigenteTransaccion.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        For Each MiDataRow2 As DataRow In TablaCCPConsulta.Rows
            SaldoVencido += CDbl(MiDataRow2.Item("SaldoVencido"))
        Next
        TBSaldoVencidoTransaccion.Text = Format(SaldoVencido, Operacion.Configuracion.Constante.Formato.Moneda)
        TBSaldoTotalTransaccion.Text = Format(CDbl(TBSaldoVigenteTransaccion.Text) + CDbl(TBSaldoVencidoTransaccion.Text), Operacion.Configuracion.Constante.Formato.Moneda)
        Session("TablaCCPConsulta") = TablaCCPConsulta
        MultiView1.SetActiveView(View5)
    End Sub
    Private Sub BuscarCuentas()
        Dim Tabla As New DataTable()
        SaldoActual = 0
        SaldoVencido = 0
        SaldoTotal = 0
        Dim index As Integer = 0
        Dim TablaCCPConsulta As New DataTable()
        Dim NegocioCCP As New Negocio.CCP()
        Dim EntidadCCP As New Entidad.CCP()
        Tabla = Session("Tabla")

        EntidadCCP.IdPersona = TBIdClienteTransaccion.Text
        EntidadCCP.FechaActual = Now
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioCCP.Consultar(EntidadCCP)
        TablaCCPConsulta = EntidadCCP.TablaConsulta
        GVCCP.DataSource = TablaCCPConsulta
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.SelectText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GVCCP.Columns.Add(Columna)
        GVCCP.AutoGenerateColumns = False
        GVCCP.AllowSorting = True
        GVCCP.DataBind()
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text = Format(TablaCCPConsulta.Rows(index).Item("Abono"), Operacion.Configuracion.Constante.Formato.Moneda)
            CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Text = Format(TablaCCPConsulta.Rows(index).Item("Liquidacion"), Operacion.Configuracion.Constante.Formato.Moneda)
            index += 1
        Next
        For Each MiDataRow As DataRow In TablaCCPConsulta.Rows
            SaldoActual += CDbl(MiDataRow.Item("SaldoVigente"))
        Next
        TBSaldoVigenteTransaccion.Text = Format(SaldoActual, Operacion.Configuracion.Constante.Formato.Moneda)
        For Each MiDataRow2 As DataRow In TablaCCPConsulta.Rows
            SaldoVencido += CDbl(MiDataRow2.Item("SaldoVencido"))
        Next
        TBSaldoVencidoTransaccion.Text = Format(SaldoVencido, Operacion.Configuracion.Constante.Formato.Moneda)
        TBSaldoTotalTransaccion.Text = Format(CDbl(TBSaldoVigenteTransaccion.Text) + CDbl(TBSaldoVencidoTransaccion.Text), Operacion.Configuracion.Constante.Formato.Moneda)
        Session("TablaCCPConsulta") = TablaCCPConsulta
    End Sub

    'Protected Sub DDFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDFormaPago.SelectedIndexChanged
    '    'LBEfectivoCambio.Text = "$0.00"
    '    'Select Case DDFormaPago.SelectedItem.Text
    '    '    Case "EFECTIVO"
    '    '        TREfectivo.Visible = True
    '    '        'DOLARES
    '    '        EsDolar = False
    '    '        TRDolares.Visible = False
    '    '        TREfectivoDolares.Visible = False
    '    '        'TARJETA
    '    '        TRTarjeta.Visible = False
    '    '        TRTarjetaReferencia.Visible = False
    '    '        'CHEQUE
    '    '        TRCheque.Visible = False
    '    '        TRChequeReferencia.Visible = False
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = False
    '    '        'VALE
    '    '        TRVale.Visible = False
    '    '    Case "DOLARES"
    '    '        TREfectivo.Visible = False
    '    '        'DOLARES
    '    '        TRDolares.Visible = True
    '    '        TREfectivoDolares.Visible = True
    '    '        EsDolar = True
    '    '        If Not TBIVA.Text Is String.Empty Then
    '    '            DolarDespues = True
    '    '            DolarAntes = False
    '    '            ConvertirADolares()
    '    '        Else
    '    '            DolarDespues = False
    '    '            DolarAntes = True
    '    '        End If
    '    '        'TBAbono.Text = IIf(TBAbono.Text Is String.Empty, 0, 1)
    '    '        'TBAbono.Text = Format((CDbl(TBAbono.Text) / Dolar), Operacion.Configuracion.Constante.Formato.Moneda)
    '    '        'TARJETA
    '    '        TRTarjeta.Visible = False
    '    '        TRTarjetaReferencia.Visible = False
    '    '        'CHEQUE
    '    '        TRCheque.Visible = False
    '    '        TRChequeReferencia.Visible = False
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = False
    '    '        'VALE
    '    '        TRVale.Visible = False
    '    '    Case "TARJETA"
    '    '        TREfectivo.Visible = False
    '    '        'DOLARES
    '    '        EsDolar = False
    '    '        TRDolares.Visible = False
    '    '        TREfectivoDolares.Visible = False
    '    '        'TARJETA
    '    '        'TRTarjeta.Visible = True
    '    '        TRTarjetaReferencia.Visible = True
    '    '        'CHEQUE
    '    '        TRCheque.Visible = False
    '    '        TRChequeReferencia.Visible = False
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = False
    '    '        'VALE
    '    '        TRVale.Visible = False
    '    '    Case "CHEQUE"
    '    '        TREfectivo.Visible = False
    '    '        'DOLARES
    '    '        EsDolar = False
    '    '        TRDolares.Visible = False
    '    '        TREfectivoDolares.Visible = False
    '    '        'TARJETA
    '    '        TRTarjeta.Visible = False
    '    '        TRTarjetaReferencia.Visible = False
    '    '        'CHEQUE
    '    '        'TRCheque.Visible = True
    '    '        TRChequeReferencia.Visible = True
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = False
    '    '        'VALE
    '    '        TRVale.Visible = False
    '    '    Case "NOTA DE CREDITO"
    '    '        TREfectivo.Visible = False
    '    '        'DOLARES
    '    '        EsDolar = False
    '    '        TRDolares.Visible = False
    '    '        TREfectivoDolares.Visible = False
    '    '        'TARJETA
    '    '        TRTarjeta.Visible = False
    '    '        TRTarjetaReferencia.Visible = False
    '    '        'CHEQUE
    '    '        TRCheque.Visible = False
    '    '        TRChequeReferencia.Visible = False
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = True
    '    '        'VALE
    '    '        TRVale.Visible = False
    '    '    Case "VALE"
    '    '        EsDolar = False
    '    '        TREfectivo.Visible = False
    '    '        'DOLARES
    '    '        TRDolares.Visible = False
    '    '        TREfectivoDolares.Visible = False
    '    '        'TARJETA
    '    '        TRTarjeta.Visible = False
    '    '        TRTarjetaReferencia.Visible = False
    '    '        'CHEQUE
    '    '        TRCheque.Visible = False
    '    '        TRChequeReferencia.Visible = False
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = False
    '    '        'VALE
    '    '        TRVale.Visible = True
    '    '    Case "MIXTO"
    '    '        'EFECTIVO
    '    '        TREfectivo.Visible = True
    '    '        'DOLARES
    '    '        EsDolar = False
    '    '        TRDolares.Visible = True
    '    '        TREfectivoDolares.Visible = True
    '    '        'TARJETA
    '    '        TRTarjeta.Visible = True
    '    '        TRTarjetaReferencia.Visible = True
    '    '        'CHEQUE
    '    '        TRCheque.Visible = True
    '    '        TRChequeReferencia.Visible = True
    '    '        'NOTACREDITO
    '    '        TRNotaCredito.Visible = True
    '    '        'VALE
    '    '        TRVale.Visible = True
    '    'End Select
    'End Sub
    Private Sub TextBoxOnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    'Sub Liquidacion()
    '    For Each MiDataRow As GridViewRow In GVCaja.Rows
    '        If Not CType(MiDataRow.FindControl("GVTBAbono"), TextBox).Text Is String.Empty Then
    '            SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("GVTBAbono"), TextBox).Text)
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
    'Protected Sub CBDescuento_CheckedChanged(sender As Object, e As EventArgs) Handles CBPorcentaje.CheckedChanged

    'End Sub
    Protected Sub TBFechaLiquidacion_TextChanged(sender As Object, e As EventArgs) Handles TBFechaLiquidacion.TextChanged
        'Dim TablaCaja As New DataTable()
        'TablaCaja = Session("TablaCaja")

        'Dim TablaCajaDetalle As New DataTable()
        'TablaCajaDetalle = Session("TablaCajaDetalle")

        'Dim TablaLiquidacionCaja As New DataTable()

        'Dim EntidadCaja As New Entidad.Caja()
        'Dim NegocioCaja As New Negocio.Caja()

        'EntidadCaja.IdPersona = TBIdPersonaVenta.Text
        'EntidadCaja.FechaActual = CDate(TBFechaLiquidacion.Text)
        'EntidadCaja.IdVenta = TablaCaja.Rows(GVCaja.SelectedIndex).Item("IdVenta")
        'EntidadCaja.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.InstrumentoDeCredito
        'NegocioCaja.Consultar(EntidadCaja)
        'TablaLiquidacionCaja = EntidadCaja.TablaConsulta
        'LBCondonacion.Text = "Condonacion si Liquida: " + Format(TablaCajaDetalle.Rows(0).Item("SaldoActual") - (TablaLiquidacionCaja.Rows(0).Item("Liquidacion")), Operacion.Configuracion.Constante.Formato.Moneda)
        'LBLiquidacion.Text = "Monto de Liquidacion: " + Format((TablaLiquidacionCaja.Rows(0).Item("Liquidacion")), Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub
    Protected Sub ConvertirADolares()
        'SumaAbonos = 0
        'SonDolares = 0
        ''Sub Abono(ByVal Abonos As Double)
        'If DolarDespues Then
        '    For Each MiDataRow As GridViewRow In GVCaja.Rows
        '        If Not CType(MiDataRow.FindControl("GVTBAbono"), TextBox).Text Is String.Empty Then
        '            SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("GVTBAbono"), TextBox).Text)
        '        ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
        '            SumaAbonos += Convert.ToDouble(MiDataRow.Cells(5).Text)
        '        End If
        '    Next
        '    SonDolares = (SumaAbonos / Dolar)
        '    TBIVA.Text = Format((SumaAbonos / Dolar), Operacion.Configuracion.Constante.Formato.Moneda)
        'ElseIf DolarAntes Then
        '    For Each MiDataRow As GridViewRow In GVCaja.Rows
        '        If Not CType(MiDataRow.FindControl("GVTBAbono"), TextBox).Text Is String.Empty Then
        '            SumaAbonos += Convert.ToDouble(CType(MiDataRow.FindControl("GVTBAbono"), TextBox).Text)
        '        ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
        '            SumaAbonos += Convert.ToDouble(MiDataRow.Cells(5).Text) / Dolar
        '        End If
        '    Next
        '    SonDolares = SumaAbonos
        '    TBIVA.Text = Format(SumaAbonos, Operacion.Configuracion.Constante.Formato.Moneda)
        'End If

        ''End Sub
    End Sub
    Protected Sub TBEfectivo_TextChanged(sender As Object, e As EventArgs) Handles TBAbono.TextChanged
        If TBCargo.Text Is String.Empty Then
            TBCargo.Text = 0
        End If
        If TBAbono.Text Is String.Empty Then
            TBAbono.Text = 0
        End If
        TBSaldo.Text = CDbl((CDbl(TBSubtotal.Text) + CDbl(TBCargo.Text)) - CDbl(TBAbono.Text))
    End Sub

    Protected Sub TBDolares_TextChanged(sender As Object, e As EventArgs) Handles TBSaldo.TextChanged
        'Dim Cambio As Double
        'If EsDolar Then
        '    Cambio = (CDbl(TBSaldo.Text)) - (CDbl(TBIVA.Text))
        '    Cambio = Cambio * Dolar
        'Else
        '    Cambio = (CDbl(TBSaldo.Text) * Dolar) - (CDbl(TBIVA.Text))
        'End If
        'LBEfectivoCambio.Text = SuCambio(Cambio)
        'EsMixto()
    End Sub
    'Protected Sub TBTarjeta_TextChanged(sender As Object, e As EventArgs) Handles TBTarjeta.TextChanged
    '    'Dim Cambio As Double = CDbl(TBTarjeta.Text) - CDbl(TBAbono.Text)
    '    'LBEfectivoCambio.Text = SuCambio(Cambio)
    '    'EsMixto()
    'End Sub

    'Protected Sub TBCheque_TextChanged(sender As Object, e As EventArgs) Handles TBCheque.TextChanged
    '    'Dim Cambio As Double = CDbl(TBCheque.Text) - CDbl(TBAbono.Text)
    '    'LBEfectivoCambio.Text = SuCambio(Cambio)
    '    'EsMixto()
    'End Sub

    'Protected Sub TBValeReferencia_TextChanged(sender As Object, e As EventArgs) Handles TBVale.TextChanged
    '    'Dim Cambio As Double = CDbl(TBVale.Text) - CDbl(TBAbono.Text)
    '    'LBEfectivoCambio.Text = "$" + CStr(Cambio)
    'End Sub

    Protected Sub EsMixto()
        'If DDFormaPago.SelectedItem.Text = "MIXTO" Then
        '    Dim CambioMixto As Double = 0
        '    If Not TBAbono.Text Is String.Empty Then
        '        CambioMixto += CDbl(TBAbono.Text)
        '    End If
        '    If Not TBSaldo.Text Is String.Empty Then
        '        CambioMixto += (CDbl(TBSaldo.Text) * Dolar)
        '    End If
        '    If Not TBTarjeta.Text Is String.Empty Then
        '        CambioMixto += CDbl(TBTarjeta.Text)
        '    End If
        '    If Not TBCheque.Text Is String.Empty Then
        '        CambioMixto += CDbl(TBCheque.Text)
        '    End If
        '    If Not TBNotaCreditoReferencia.Text Is String.Empty Then
        '        CambioMixto += CDbl(TBNotaCreditoReferencia.Text)
        '    End If
        '    If Not TBVale.Text Is String.Empty Then
        '        CambioMixto += CDbl(TBVale.Text)
        '    End If
        '    LBEfectivoCambio.Text = SuCambio(CambioMixto - CDbl(TBAbono.Text))
        'End If
    End Sub
    Protected Sub IBTConsultarAbonos_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultarAbonos.Click
        MultiView1.SetActiveView(View5)
    End Sub

    Protected Sub IBTRegresarPersona_Click(sender As Object, e As ImageClickEventArgs) Handles IBTRegresarPersona.Click
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub IBTRegresarVerDetalle_Click(sender As Object, e As ImageClickEventArgs) Handles IBTRegresarVerDetalle.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub TBIVA_TextChanged(sender As Object, e As EventArgs) Handles TBIVA.TextChanged
        If TBIVA.Text Is String.Empty Then
            TBIVA.Text = 0
        End If
        If TBIEPS.Text Is String.Empty Then
            TBIEPS.Text = 0
        End If
        If TBMonto.Text Is String.Empty Then
            TBMonto.Text = 0
        End If
        TBSubtotal.Text = CDbl(TBMonto.Text) + CDbl(TBIVA.Text) + CDbl(TBIEPS.Text)
    End Sub

    Protected Sub TBIEPS_TextChanged(sender As Object, e As EventArgs) Handles TBIEPS.TextChanged
        If TBIVA.Text Is String.Empty Then
            TBIVA.Text = 0
        End If
        If TBIEPS.Text Is String.Empty Then
            TBIEPS.Text = 0
        End If
        If TBMonto.Text Is String.Empty Then
            TBMonto.Text = 0
        End If
        TBSubtotal.Text = CDbl(TBMonto.Text) + CDbl(TBIVA.Text) + CDbl(TBIEPS.Text)

    End Sub

    Protected Sub TBCargo_TextChanged(sender As Object, e As EventArgs) Handles TBCargo.TextChanged
        If TBCargo.Text Is String.Empty Then
            TBCargo.Text = 0
        End If
        If TBAbono.Text Is String.Empty Then
            TBAbono.Text = 0
        End If
        TBSaldo.Text = CDbl((CDbl(TBSubtotal.Text) + CDbl(TBCargo.Text)) - CDbl(TBAbono.Text))
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub BTNSeleccionar_OnClick(sender As Object, e As EventArgs)
        Dim TablaCCPConsulta As New DataTable()
        Dim Tabla As New DataTable()
        Dim Tabla2 As New DataTable()
        TablaCCPConsulta = Session("TablaCCPConsulta")

        Dim EntidadCCP As New Entidad.CCP()
        Dim NegocioCCP As New Negocio.CCP()
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        DDEstado.SelectedValue = TablaCCPConsulta.Rows(index).Item("IdEstado")
        EntidadCCP.IdCCP = CType(TablaCCPConsulta.Rows(index).Item("IdCCP"), Integer)
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioCCP.Obtener(EntidadCCP)
        Tabla = EntidadCCP.TablaConsulta
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioCCP.Obtener(EntidadCCP)
        Tabla2 = EntidadCCP.TablaConsulta

        GVProductos.DataSource = Tabla2
        GVProductos.AutoGenerateColumns = True
        GVProductos.AllowSorting = True
        GVProductos.DataBind()
        TBAbono.Text = CDbl(Tabla.Rows(0).Item("Abonos"))
        TBCargo.Text = String.Format("{0:c}", CDbl(Tabla.Rows(0).Item("Cargos")))
        TBIdCCP.Text = Tabla.Rows(0).Item("IdCCP")
        TBFecha.Text = Tabla.Rows(0).Item("FechaExpedicion")
        Dim IdPersona As String
        Dim Equivalencia As String
        Dim Nombre As String
        IdPersona = Tabla.Rows(0).Item("IdPersona")
        Equivalencia = Tabla.Rows(0).Item("Equivalencia")
        Nombre = Tabla.Rows(0).Item("NombreCliente")
        ' AsignarPersona
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(0))


        'wucConPer.AsignarPersona(IdPersona, Equivalencia, Nombre)
        TBFechaVencimientoE.Text = Tabla.Rows(0).Item("FechaVencimiento")
        TBDescripcion.Text = Tabla.Rows(0).Item("Descripcion")
        TBMonto.Text = CDbl(Tabla.Rows(0).Item("Monto"))
        TBIVA.Text = CDbl(Tabla.Rows(0).Item("IVA"))
        TBIEPS.Text = CDbl(Tabla.Rows(0).Item("IEPS"))
        TBSubtotal.Text = CDbl(Tabla.Rows(0).Item("Subtotal"))
        DDIdTipoDocumento.SelectedValue = CInt(Tabla.Rows(0).Item("IdTipoDocumento"))
        TBSerie.Text = Tabla.Rows(0).Item("Serie")
        TBFolioE.Text = Tabla.Rows(0).Item("Folio")
        'TBFolio.Text = Tabla.Rows(0).Item("Folio")
        TBObservacion.Text = Tabla.Rows(0).Item("Observacion")
        TBSaldo.Text = CDbl(TBCargo.Text - TBAbono.Text + TBSubtotal.Text)
        Inhabilitar()


        Dim TablaCCPConsultaCargosAbonos As New DataTable()
        Dim TablaCCPConsultaCargosAbonos2 As New DataTable()
        TablaCCPConsultaCargosAbonos = Session("TablaCCPConsulta")
        Dim index1 As Integer = gvrFilaActual.RowIndex
        Dim valor As Integer = TablaCCPConsultaCargosAbonos.Rows(index1).Item("IdCCP")
        EntidadCCP.IdCCP = CInt(valor)
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        NegocioCCP.Obtener(EntidadCCP)
        TablaCCPConsultaCargosAbonos2 = EntidadCCP.TablaConsulta
        GVCargosAbonos.DataSource = TablaCCPConsultaCargosAbonos2
        GVCargosAbonos.AutoGenerateColumns = True
        GVCargosAbonos.AllowSorting = True
        GVCargosAbonos.DataBind()
        wucDatosAuditoria1.Visible = True
        'wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVReferenciaComercial.SelectedIndex))

        Session("TablaCCPCargosAbonos") = TablaCCPConsultaCargosAbonos2

        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub BTNCancelarCargoAbono_OnClick(sender As Object, e As EventArgs)
        'Cancelar
        Dim TablaCCPCargosAbonos As New DataTable()
        Dim Tabla As New DataTable()
        Dim Tabla2 As New DataTable()
        TablaCCPCargosAbonos = Session("TablaCCPCargosAbonos")

        Dim EntidadCCP As New Entidad.CCP()
        Dim NegocioCCP As New Negocio.CCP()
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim valor As Integer = TablaCCPCargosAbonos.Rows(index).Item("ID")
        EntidadCCP.IdCCPMovimiento = CInt(valor)
        NegocioCCP.CancelarMovimiento(EntidadCCP)

        BuscarCuentas()
        BuscarMovimientos()

    End Sub
    Private Sub BuscarMovimientos()
        Dim TablaCCPConsulta As New DataTable()
        Dim Tabla As New DataTable()
        Dim Tabla2 As New DataTable()
        TablaCCPConsulta = Session("TablaCCPConsulta")

        Dim EntidadCCP As New Entidad.CCP()
        Dim NegocioCCP As New Negocio.CCP()
        EntidadCCP.IdCCP = TBIdCCP.Text
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioCCP.Obtener(EntidadCCP)
        Tabla = EntidadCCP.TablaConsulta
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioCCP.Obtener(EntidadCCP)
        Tabla2 = EntidadCCP.TablaConsulta

        GVProductos.DataSource = Tabla2
        GVProductos.AutoGenerateColumns = True
        GVProductos.AllowSorting = True
        GVProductos.DataBind()
        TBAbono.Text = CDbl(Tabla.Rows(0).Item("Abonos"))
        TBCargo.Text = CDbl(Tabla.Rows(0).Item("Cargos"))
        TBIdCCP.Text = Tabla.Rows(0).Item("IdCCP")
        TBFecha.Text = Tabla.Rows(0).Item("FechaExpedicion")
        Dim IdPersona As String
        Dim Equivalencia As String
        Dim Nombre As String
        IdPersona = Tabla.Rows(0).Item("IdPersona")
        Equivalencia = Tabla.Rows(0).Item("Equivalencia")
        Nombre = Tabla.Rows(0).Item("NombreCliente")
        ' AsignarPersona
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(0))


        'wucConPer.AsignarPersona(IdPersona, Equivalencia, Nombre)
        TBFechaVencimientoE.Text = Tabla.Rows(0).Item("FechaVencimiento")
        TBDescripcion.Text = Tabla.Rows(0).Item("Descripcion")
        TBMonto.Text = CDbl(Tabla.Rows(0).Item("Monto"))
        TBIVA.Text = CDbl(Tabla.Rows(0).Item("IVA"))
        TBIEPS.Text = CDbl(Tabla.Rows(0).Item("IEPS"))
        TBSubtotal.Text = CDbl(Tabla.Rows(0).Item("Subtotal"))
        DDIdTipoDocumento.SelectedValue = CInt(Tabla.Rows(0).Item("IdTipoDocumento"))
        TBSerie.Text = Tabla.Rows(0).Item("Serie")
        TBFolioE.Text = Tabla.Rows(0).Item("Folio")
        'TBFolio.Text = Tabla.Rows(0).Item("Folio")
        TBObservacion.Text = Tabla.Rows(0).Item("Observacion")
        TBSaldo.Text = CDbl(TBCargo.Text - TBAbono.Text + TBSubtotal.Text)
        Inhabilitar()

        Dim TablaCCPConsultaCargosAbonos As New DataTable()
        Dim TablaCCPConsultaCargosAbonos2 As New DataTable()

        EntidadCCP.IdCCP = TBIdCCP.Text
        EntidadCCP.IdTipoCCP = 1
        EntidadCCP.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        NegocioCCP.Obtener(EntidadCCP)
        TablaCCPConsultaCargosAbonos2 = EntidadCCP.TablaConsulta
        GVCargosAbonos.DataSource = TablaCCPConsultaCargosAbonos2
        GVCargosAbonos.AutoGenerateColumns = True
        GVCargosAbonos.AllowSorting = True
        GVCargosAbonos.DataBind()
        wucDatosAuditoria1.Visible = True
        'wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVReferenciaComercial.SelectedIndex))

        Session("TablaCCPCargosAbonos") = TablaCCPConsultaCargosAbonos2
    End Sub

    Protected Sub IBTGuardarTransaccion_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardarTransaccion.Click
        Dim EntidadCCP As New Entidad.CCP()
        Dim NegocioCCP As New Negocio.CCP()
        TablaCCPDetalle = Session("TablaCCPDetalle")
        VistaCCPDetalle = Session("VistaCCPDetalle")

        Dim Index As Integer
        Index = 0
        Dim TablaCCP As New DataTable()
        TablaCCP = Session("TablaCCPConsulta")
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            Dim RenglonAInsertar As DataRow
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            EntidadCCP.IdCCP = TablaCCP.Rows(Index).Item("IdCCP")
            If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then


                RenglonAInsertar = TablaCCPDetalle.NewRow()

                RenglonAInsertar("IdCCP") = TablaCCP.Rows(Index).Item("IdCCP")
                RenglonAInsertar("IdTransaccion") = DDIdTransaccion.SelectedValue
                RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumentoTransaccion.SelectedValue
                RenglonAInsertar("Serie") = TBSerieTransaccion.Text
                RenglonAInsertar("Folio") = TBFolioTransaccion.Text
                RenglonAInsertar("Fecha") = Now
                Dim Concepto As String
                Concepto = ""
                If (CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text) Is String.Empty Then
                    If DDIdTransaccion.SelectedValue = 1 Then
                        Concepto = "Cargo"
                    End If
                    If DDIdTransaccion.SelectedValue = 2 Then
                        Concepto = "Abono"
                    End If
                End If
                If Not (CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text) Is String.Empty Then
                    Concepto = Convert.ToString(CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text)
                End If
                RenglonAInsertar("Descripcion") = Concepto
                RenglonAInsertar("Observacion") = TBObservacionTransaccion.Text
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("MontoTransaccion") = Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("IdSucursal") = 1
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = Now
                TablaCCPDetalle.Rows.Add(RenglonAInsertar)
            ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                'RenglonAInsertar = TablaAbonoCaja.NewRow()
                'RenglonAInsertar("IdPagoAbonos") = 0
                'RenglonAInsertar("IdPersona") = TablaCaja.Rows(Index).Item("IdPersona")
                'RenglonAInsertar("IdVenta") = TablaCaja.Rows(Index).Item("IdVenta")
                'RenglonAInsertar("IdFormaPago") = DDFormaPago.SelectedValue
                'RenglonAInsertar("Abono") = TablaCaja.Rows(Index).Item("Abono")
                'RenglonAInsertar("IdTipoAbono") = Operacion.Configuracion.Constante.TipoAbono.Normal
                'RenglonAInsertar("IdEstado") = 7
                'RenglonAInsertar("IdUsuarioCreacion") = 1
                'RenglonAInsertar("FechaCreacion") = Now
                'RenglonAInsertar("IdUsuarioActualizacion") = 1
                'RenglonAInsertar("FechaActualizacion") = Now
                'TablaAbonoCaja.Rows.Add(RenglonAInsertar)
                RenglonAInsertar = TablaCCPDetalle.NewRow()
                RenglonAInsertar("IdCCP") = TablaCCP.Rows(Index).Item("IdCCP")
                RenglonAInsertar("IdTransaccion") = DDIdTransaccion.SelectedValue
                RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumentoTransaccion.SelectedValue
                RenglonAInsertar("Serie") = TBSerieTransaccion.Text
                RenglonAInsertar("Folio") = TBFolioTransaccion.Text
                RenglonAInsertar("Fecha") = Now
                Dim Concepto As String
                Concepto = ""
                If (CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text) Is String.Empty Then
                    If DDIdTransaccion.SelectedValue = 1 Then
                        Concepto = "Cargo"
                    End If
                    If DDIdTransaccion.SelectedValue = 2 Then
                        Concepto = "Abono"
                    End If
                End If
                If Not (CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text) Is String.Empty Then
                    Concepto = Convert.ToString(CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text)
                End If
                RenglonAInsertar("Descripcion") = Concepto
                RenglonAInsertar("Observacion") = TBObservacionTransaccion.Text
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("MontoTransaccion") = Convert.ToDouble(TablaCCP.Rows(MiDataRow.RowIndex).Item("Abono"))
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("IdSucursal") = 1
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = Now
                TablaCCPDetalle.Rows.Add(RenglonAInsertar)
            ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                'RenglonAInsertar = TablaAbonoCaja.NewRow()
                'RenglonAInsertar("IdPagoAbonos") = 0
                'RenglonAInsertar("IdPersona") = TablaCaja.Rows(Index).Item("IdPersona")
                'RenglonAInsertar("IdVenta") = TablaCaja.Rows(Index).Item("IdVenta")
                'RenglonAInsertar("IdFormaPago") = DDFormaPago.SelectedValue
                'RenglonAInsertar("Abono") = TablaCaja.Rows(Index).Item("Liquidacion")
                'RenglonAInsertar("IdTipoAbono") = Operacion.Configuracion.Constante.TipoAbono.Adelantado
                'RenglonAInsertar("IdEstado") = 5
                'RenglonAInsertar("IdUsuarioCreacion") = 1
                'RenglonAInsertar("FechaCreacion") = Now
                'RenglonAInsertar("IdUsuarioActualizacion") = 1
                'RenglonAInsertar("FechaActualizacion") = Now
                'TablaAbonoCaja.Rows.Add(RenglonAInsertar)
                RenglonAInsertar = TablaCCPDetalle.NewRow()
                RenglonAInsertar("IdCCP") = TablaCCP.Rows(Index).Item("IdCCP")
                RenglonAInsertar("IdTransaccion") = DDIdTransaccion.SelectedValue
                RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumentoTransaccion.SelectedValue
                RenglonAInsertar("Serie") = TBSerieTransaccion.Text
                RenglonAInsertar("Folio") = TBFolioTransaccion.Text
                RenglonAInsertar("Fecha") = Now
                Dim Concepto As String
                Concepto = ""
                If (CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text) Is String.Empty Then
                    If DDIdTransaccion.SelectedValue = 1 Then
                        Concepto = "Cargo"
                    End If
                    If DDIdTransaccion.SelectedValue = 2 Then
                        Concepto = "Abono"
                    End If
                End If
                If Not (CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text) Is String.Empty Then
                    Concepto = Convert.ToString(CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text)
                End If
                RenglonAInsertar("Descripcion") = Concepto
                RenglonAInsertar("Observacion") = TBObservacionTransaccion.Text
                RenglonAInsertar("IdCajaMovimiento") = 0
                RenglonAInsertar("MontoTransaccion") = Convert.ToDouble(TablaCCP.Rows(MiDataRow.RowIndex).Item("Liquidacion"))
                RenglonAInsertar("Impuesto") = 0
                RenglonAInsertar("IdSucursal") = 1
                RenglonAInsertar("IdEstado") = 7
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = Now
                TablaCCPDetalle.Rows.Add(RenglonAInsertar)

            End If
        Next




        'If Not TBIdCCP.Text Is String.Empty Then
        '    Dim RenglonAInsertar As DataRow
        '    If Not TBMonto.Text Is String.Empty And DDIdTransaccion.SelectedValue = 1 Then
        '        RenglonAInsertar = TablaCCPDetalle.NewRow()
        '        RenglonAInsertar("IdCCP") = CInt(TBIdCCP.Text)
        '        RenglonAInsertar("IdTransaccion") = DDIdTransaccion.SelectedValue
        '        RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumentoTransaccion.SelectedValue
        '        RenglonAInsertar("Serie") = TBSerieTransaccion.Text
        '        RenglonAInsertar("Folio") = TBFolioTransaccion.Text
        '        RenglonAInsertar("Fecha") = Now
        '        RenglonAInsertar("Descripcion") = TBDescripcionTransaccion.Text
        '        RenglonAInsertar("Observacion") = TBObservacionTransaccion.Text
        '        RenglonAInsertar("IdCajaMovimiento") = 0
        '        RenglonAInsertar("MontoTransaccion") = TBAbonarTransaccion.Text
        '        RenglonAInsertar("Impuesto") = 0
        '        RenglonAInsertar("IdSucursal") = 1
        '        RenglonAInsertar("IdEstado") = 1
        '        RenglonAInsertar("IdUsuarioCreacion") = 1
        '        RenglonAInsertar("FechaCreacion") = Now
        '        RenglonAInsertar("IdUsuarioActualizacion") = 1
        '        RenglonAInsertar("FechaActualizacion") = Now
        '        TablaCCPDetalle.Rows.Add(RenglonAInsertar)
        '    End If
        '    If Not TBMonto.Text Is String.Empty And DDIdTransaccion.SelectedValue = 2 Then
        '        RenglonAInsertar = TablaCCPDetalle.NewRow()
        '        RenglonAInsertar("IdCCP") = CInt(TBIdCCP.Text)
        '        RenglonAInsertar("IdTransaccion") = DDIdTransaccion.SelectedValue
        '        RenglonAInsertar("IdTipoDocumento") = DDIdTipoDocumentoTransaccion.SelectedValue
        '        RenglonAInsertar("Serie") = TBSerieTransaccion.Text
        '        RenglonAInsertar("Folio") = TBFolioTransaccion.Text
        '        RenglonAInsertar("Fecha") = Now
        '        RenglonAInsertar("Descripcion") = TBDescripcionTransaccion.Text
        '        RenglonAInsertar("Observacion") = TBObservacionTransaccion.Text
        '        RenglonAInsertar("IdCajaMovimiento") = 0
        '        RenglonAInsertar("MontoTransaccion") = TBAbonarTransaccion.Text
        '        RenglonAInsertar("Impuesto") = 0
        '        RenglonAInsertar("IdSucursal") = 1
        '        RenglonAInsertar("IdEstado") = 1
        '        RenglonAInsertar("IdUsuarioCreacion") = 1
        '        RenglonAInsertar("FechaCreacion") = Now
        '        RenglonAInsertar("IdUsuarioActualizacion") = 1
        '        RenglonAInsertar("FechaActualizacion") = Now
        '        TablaCCPDetalle.Rows.Add(RenglonAInsertar)
        '    End If
        'Else
        '    EntidadCCP.IdCCP =
        '    EntidadCCP.IdEstado = DDEstado.SelectedValue
        'End If
        'EntidadCCP.IdCCP =
        EntidadCCP.IdEstado = DDEstado.SelectedValue
        EntidadCCP.TablaMovimientos = TablaCCPDetalle
        NegocioCCP.GuardarCCPMovimiento(EntidadCCP)
        TBIdCCP.Text = EntidadCCP.IdCCP
        TablaCCPDetalle.Clear()
        Session("TablaCCPDetalle") = TablaCCPDetalle
        'MultiView1.SetActiveView(View1)
        BuscarCuentas()
        TBDescripcionTransaccion.Text = ""
        TBAbonarTransaccion.Text = ""
        TBPagoTransaccion.Text = ""
        TBCambioTransaccion.Text = ""
        TBSerieTransaccion.Text = ""
        TBObservacionTransaccion.Text = ""
        TBFolioTransaccion.Text = ""
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        MultiView1.SetActiveView(View5)
    End Sub

    Protected Sub BNTCalcular_Click(sender As Object, e As EventArgs) Handles BNTCalcular.Click
        Dim index As Integer = 0
        Dim Abono As Double = 0
        Dim TablaCCP As New DataTable()
        TablaCCP = Session("TablaCCPConsulta")
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            'Index = Convert.ToUInt64(MiDataRow.RowIndex)
            'If CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
            '    Abono += CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Text
            'End If
            If Not CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text Is String.Empty Then
                Abono += Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
            ElseIf CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                Abono += Convert.ToDouble(TablaCCP.Rows(MiDataRow.RowIndex).Item("Abono"))
            ElseIf CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = True Then
                CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                Abono += Convert.ToDouble(TablaCCP.Rows(MiDataRow.RowIndex).Item("Liquidacion"))
            End If

        Next
        TBAbonarTransaccion.Text = Format(Abono, Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub
    Protected Sub TBAbonarTransaccion_TextChanged(sender As Object, e As EventArgs) Handles TBAbonarTransaccion.TextChanged
        If TBPagoTransaccion.Text Is String.Empty Then
            TBPagoTransaccion.Text = 0
        End If
        TBCambioTransaccion.Text = Format(CDbl(TBPagoTransaccion.Text) - CDbl(TBAbonarTransaccion.Text), Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub
    Protected Sub TBPagoTransaccion_TextChanged(sender As Object, e As EventArgs) Handles TBPagoTransaccion.TextChanged
        If TBAbonarTransaccion.Text Is String.Empty Then
            TBAbonarTransaccion.Text = 0
        End If
        TBCambioTransaccion.Text = Format(CDbl(TBPagoTransaccion.Text) - CDbl(TBAbonarTransaccion.Text), Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub
    Protected Sub TBIdCCP_TextChanged(sender As Object, e As EventArgs) Handles TBIdCCP.TextChanged

    End Sub
    Protected Sub TBDescripcionTransaccion_TextChanged(sender As Object, e As EventArgs) Handles TBDescripcionTransaccion.TextChanged
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            CType(MiDataRow.FindControl("TBGVConcepto"), TextBox).Text = TBDescripcionTransaccion.Text
        Next
    End Sub
    Protected Sub TBMonto_TextChanged(sender As Object, e As EventArgs) Handles TBMonto.TextChanged
        TBSubtotal.Text = TBMonto.Text
    End Sub
    Protected Sub DDIdTransaccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDIdTransaccion.SelectedIndexChanged
        Dim TablaCCP As New DataTable()
        TablaCCP = Session("TablaCCPConsulta")
        For Each MiDataRow As GridViewRow In GVCCP.Rows
            Dim Abono As Double
            Dim Saldo As Double

            Saldo = Convert.ToDouble(TablaCCP.Rows(MiDataRow.RowIndex).Item("SaldoActual")) 'Convert.ToDouble(MiDataRow.Cells(9).Text)
            Abono = 0
            If IsNumeric(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text) Then
                Abono = Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)

                If 0 < Abono Then
                    If Not (CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text) Is String.Empty Then
                        Abono = Convert.ToDouble(CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text)
                        ' EstadoCuenta = 4
                        CType(MiDataRow.FindControl("CBGVLiquidacionItem"), CheckBox).Checked = False
                        CType(GVCCP.HeaderRow.FindControl("CBGVLiquidacionHeader"), CheckBox).Checked = False
                        CType(MiDataRow.FindControl("CBGVAbonoItem"), CheckBox).Checked = False
                        CType(GVCCP.HeaderRow.FindControl("CBGVAbonoHeader"), CheckBox).Checked = False
                    End If
                    If Abono > Saldo Then
                        If DDIdTransaccion.SelectedValue = 2 Then
                            CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = Saldo.ToString
                            '  EstadoCuenta = 5
                        End If

                    End If
                Else

                    CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
                End If

            Else
                CType(MiDataRow.FindControl("TBGVAbono"), TextBox).Text = ""
            End If
        Next
    End Sub
End Class