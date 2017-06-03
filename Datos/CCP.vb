Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class CCP
    Implements ICatalogo
    Public Overridable Sub Actualizar(ByRef CCP As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim CCP1 As New Entidad.CCP()
        CCP1 = CCP
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try

            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActCCP", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()

            sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", CCP1.IdCCP))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CCP1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", CCP1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", CCP1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CCP1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()


            '========================================================== Movimientos =====================================================
            'For Each MiDataRow As DataRow In CCP1.TablaMovimientos.Rows
            '    InsertarMovimientos(sqlcom1, MiDataRow, CCP1)
            'Next

            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub
    Public Overridable Sub Consultar(ByRef CCP As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim CCP1 = New Entidad.CCP()
        CCP1 = CCP
        CCP1.TablaConsulta = New DataTable()
        CCP1.TablaVentaCaja = New DataTable()
        CCP1.TablaHistorialCaja = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case CCP1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
                    sqldat1 = New SqlDataAdapter("ERP_LisTipDocBas", sqlcon1)
                    sqldat1.Fill(CCP1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConClieCXC", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IdTipoCCP", CCP1.IdTipoCCP))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    '---------sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(CCP1.FechaActual)))
                    sqldat1.Fill(CCP1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPerBas", sqlcon1)
                    sqldat1.Fill(CCP1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_LisVenPerCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", CCP1.IdVenta))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(CCP1.FechaActual)))
                    sqldat1.Fill(CCP1.TablaConsulta)
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", CCP1.IdVenta))
                    sqlcom1.CommandText = "ERP_LisVenCajCod"
                    sqldat1.Fill(CCP1.TablaVentaCaja)
                    sqlcom1.CommandText = "ERP_LisHisVenCod"
                    sqldat1.Fill(CCP1.TablaHistorialCaja)
                Case Consulta.InstrumentoDeCredito
                    sqlcom1 = New SqlCommand("ERP_LisLiqVenCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", CCP1.IdVenta))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(CCP1.FechaActual)))
                    sqldat1.Fill(CCP1.TablaConsulta)
            End Select
            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub
    Public Overridable Sub InsertarActualizar(ByRef CCP As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim CCP1 As New Entidad.CCP()
        CCP1 = CCP
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActPagCaj", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", CCP1.IdCaja))
            sqlcom1.Parameters.Add(New SqlParameter("@INRecibo", CCP1.Recibo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@INPagoAbono", CCP1.PagoAbono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", CCP1.IdFormaPago))
            sqlcom1.Parameters.Add(New SqlParameter("@INDescuento", CCP1.Descuento))
            sqlcom1.Parameters.Add(New SqlParameter("@INPorcentaje", CCP1.Porcentaje))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", CCP1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CCP1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", CCP1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CCP1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", CCP1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CCP1.FechaActualizacion))
            If CCP1.IdCaja = 0 Then
                sqlcom1.Parameters(CCP1.IdCaja).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            CCP1.IdCaja = sqlcom1.Parameters(CCP1.IdCaja).Value

            For Each MiTableRow As DataRow In CCP1.TablaFormaPagoDetalleCaja.Rows
                sqlcom1.CommandText = "ERP_InsActForAboDet"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPagoDetalle", MiTableRow("IdFormaPagoDetalle")))
                sqlcom1.Parameters.Add(New SqlParameter("@INAbono", MiTableRow("Abono")))
                sqlcom1.Parameters.Add(New SqlParameter("@INDolarDiario", MiTableRow("DolarDiario")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroVale", MiTableRow("NumeroVale")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVReferencia", MiTableRow("Referencia")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdBanco", MiTableRow("IdBanco")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", MiTableRow("IdFormaPago")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", CCP1.IdCaja))
                If MiTableRow("IdFormaPagoDetalle") = 0 Then
                    sqlcom1.Parameters("@INIdFormaPagoDetalle").Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()
            Next


            For Each MiDataRow As DataRow In CCP1.TablaAbonoCaja.Rows
                sqlcom1.CommandText = "ERP_InsActPagAbo"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPagoAbonos", MiDataRow("IdPagoAbonos")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", MiDataRow("IdPersona")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", MiDataRow("IdVenta")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", MiDataRow("IdFormaPago")))
                sqlcom1.Parameters.Add(New SqlParameter("@INAbono", MiDataRow("Abono")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", MiDataRow("Observacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", CCP1.IdCaja))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                If MiDataRow("IdPagoAbonos") = 0 Then
                    sqlcom1.Parameters("@INIdPagoAbonos").Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()

            Next
            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub
    Public Sub Insertar(ByRef CCP As Entidad.EntidadBase)
        Dim CCP1 As New Entidad.CCP()
        CCP1 = CCP
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsCCPCom", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", CCP1.IdTipoDocumento))
            sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", CCP1.Folio))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", CCP1.Serie))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaExpedicion", CCP1.FechaExpedicion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimiento", CCP1.FechaVencimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", CCP1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", CCP1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CCP1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", CCP1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CCP1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", CCP1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIVA", CCP1.IVA))
            sqlcom1.Parameters.Add(New SqlParameter("@INIEPS", CCP1.IEPS))
            sqlcom1.Parameters.Add(New SqlParameter("@INSubTotal", CCP1.Subtotal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCCP", CCP1.IdTipoCCP))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", CCP1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CCP1.FechaCreacion))
            sqlcom1.Parameters(CCP1.IdCCP).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            CCP1.IdCCP = sqlcom1.Parameters(CCP1.IdCCP).Value


            '========================================================== Movimientos =====================================================
            For Each MiDataRow As DataRow In CCP1.TablaMovimientos.Rows
                InsertarMovimientos(sqlcom1, MiDataRow, CCP1)
            Next

            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub
    Private Sub InsertarMovimientos(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal CCP1 As Entidad.CCP)
        CCP1.TablaMovimientos = New DataTable()
        sqlcom1.CommandText = "ERP_InsCCPMov"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdCCPMovimiento", 0))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", IIf(miDataRow("IdCCP") = 0, CCP1.IdCCP, miDataRow("IdCCP"))))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTransaccion", miDataRow("IdTransaccion")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", miDataRow("IdTipoDocumento")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", miDataRow("Folio")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", miDataRow("Serie")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", miDataRow("Fecha")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", miDataRow("Observacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", miDataRow("Descripcion")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdCajaMovimiento", miDataRow("IdCajaMovimiento")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("IdEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", CCP1.idUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CCP1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INMonto", miDataRow("MontoTransaccion")))
        sqlcom1.Parameters.Add(New SqlParameter("@INImpuesto", miDataRow("Impuesto")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", miDataRow("IdSucursal")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", CCP1.idUsuarioCreacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CCP1.FechaCreacion))
        sqlcom1.ExecuteNonQuery()

    End Sub
    Public Sub InsertarMovimiento(ByRef CCP As Entidad.EntidadBase)
        Dim CCP1 As New Entidad.CCP()
        CCP1 = CCP
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsCCPMov", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()

            For Each MiDataRow As DataRow In CCP1.TablaMovimientos.Rows
                InsertarMovimientos(sqlcom1, MiDataRow, CCP1)
            Next

            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try


    End Sub
    Public Sub ActualizarMovimiento(ByRef CCP As Entidad.EntidadBase)

    End Sub
    Sub CancelarMovimiento(ByRef EntidadCCP As Entidad.CCP)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            EntidadCCP.TablaConsulta = New DataTable()
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_CanMovCCP", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimiento", EntidadCCP.IdCCPMovimiento))
            sqlcom1.ExecuteNonQuery()
            EntidadCCP.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCCP.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCCP.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Sub ReporteCCP(ByRef EntidadCCP As Entidad.CCP)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            EntidadCCP.TablaConsulta = New DataTable()
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("LisRepCCP", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()

            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCCP.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCCP.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCCP", EntidadCCP.IdTipoCCP))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadCCP.FechaExpedicion.AddDays(-1)))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadCCP.FechaVencimiento.AddDays(1)))

            sqldat1.Fill(EntidadCCP.TablaConsulta)
            EntidadCCP.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCCP.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCCP.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub Liquidacion(ByRef CCP As Entidad.EntidadBase)
        Dim CCP1 As New Entidad.CCP()
        CCP1 = CCP
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActEstVentCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@IdPersona", CCP1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(CCP1.FechaActual)))
            sqlcom1.ExecuteNonQuery()
            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub
    Public Overridable Sub Obtener(ByRef CCP As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim CCP1 = New Entidad.CCP()
        CCP1 = CCP
        CCP1.TablaConsulta = New DataTable()
        CCP1.TablaVentaCaja = New DataTable()
        CCP1.TablaHistorialCaja = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case CCP1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_LisCCPDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", CCP1.IdCCP))
                    sqlcom1.Parameters.Add(New SqlParameter("@IdTipoCCP", CCP1.IdTipoCCP))
                    sqldat1.Fill(CCP1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqlcom1 = New SqlCommand("ERP_LisProCXPDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", CCP1.IdCCP))
                    sqlcom1.Parameters.Add(New SqlParameter("@IdTipoCCP", CCP1.IdTipoCCP))
                    sqldat1.Fill(CCP1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
                    sqlcom1 = New SqlCommand("ERP_LisCarAboCCPDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", CCP1.IdCCP))
                    sqlcom1.Parameters.Add(New SqlParameter("@IdTipoCCP", CCP1.IdTipoCCP))
                    sqldat1.Fill(CCP1.TablaConsulta)

                    'Case Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
                    '    sqlcom1 = New SqlCommand("ERP_LisVenPerCod", sqlcon1)
                    '    sqldat1 = New SqlDataAdapter(sqlcom1)
                    '    sqlcom1.CommandType = CommandType.StoredProcedure
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", CCP1.IdVenta))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(CCP1.FechaActual)))
                    '    sqldat1.Fill(CCP1.TablaConsulta)
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", CCP1.IdVenta))
                    '    sqlcom1.CommandText = "ERP_LisVenCajCod"
                    '    sqldat1.Fill(CCP1.TablaVentaCaja)
                    '    sqlcom1.CommandText = "ERP_LisHisVenCod"
                    '    sqldat1.Fill(CCP1.TablaHistorialCaja)
                    'Case Consulta.InstrumentoDeCredito
                    '    sqlcom1 = New SqlCommand("ERP_LisLiqVenCod", sqlcon1)
                    '    sqldat1 = New SqlDataAdapter(sqlcom1)
                    '    sqlcom1.CommandType = CommandType.StoredProcedure
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", CCP1.IdPersona))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", CCP1.IdVenta))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(CCP1.FechaActual)))
                    '    sqldat1.Fill(CCP1.TablaConsulta)
            End Select
            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub
    Public Sub CancelarCCPCompra(ByRef CCP As Entidad.EntidadBase)
        Dim CCP1 As New Entidad.CCP()
        CCP1 = CCP
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_CancCCPComp", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", CCP1.IdCompra))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCPP", CCP1.IdCCP))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", CCP1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CCP1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            CCP1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            CCP1.Tarjeta.Resultado = Resultado.Incorrecto
            CCP1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            CCP = CCP1
        End Try
    End Sub

End Class
