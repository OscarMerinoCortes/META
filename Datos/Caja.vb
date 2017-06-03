Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Caja
    Implements ICatalogo
    Public Overridable Sub Actualizar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadCaja1 As New Entidad.Caja()
        'EntidadCaja1 = EntidadCaja
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActCreCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdCredito", EntidadCaja1.IdCredito))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaSolicitante", EntidadCaja1.IdPersonaSolicitante))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaApertura", EntidadCaja1.FechaApertura))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimiento", EntidadCaja1.FechaVencimiento))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntidadCaja1.Monto))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCredito", EntidadCaja1.IdEstadoCredito))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCaja1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCaja1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCaja1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadCaja1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadCaja1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadCaja = EntidadCaja1
        'End Try
    End Sub
    Public Overridable Sub Consultar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadCaja1 = New Entidad.Caja()
        EntidadCaja1 = EntidadCaja
        EntidadCaja1.TablaConsulta = New DataTable()
        EntidadCaja1.TablaVentaCaja = New DataTable()
        EntidadCaja1.TablaHistorialCaja = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadCaja1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_LisCrePerCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(EntidadCaja1.FechaActual)))
                    sqlcom1.Parameters.Add(New SqlParameter("@IdTipoCCP", 1))
                    sqldat1.Fill(EntidadCaja1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPerBas", sqlcon1)
                    sqldat1.Fill(EntidadCaja1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_LisVenPerCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", EntidadCaja1.IdCCP))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(EntidadCaja1.FechaActual)))
                    sqldat1.Fill(EntidadCaja1.TablaConsulta)
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", EntidadCaja1.IdCCP))
                    sqlcom1.CommandText = "ERP_LisVenCajCod"
                    sqldat1.Fill(EntidadCaja1.TablaVentaCaja)
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", EntidadCaja1.IdCCP))
                    sqlcom1.CommandText = "ERP_LisHisVenCod"
                    sqldat1.Fill(EntidadCaja1.TablaHistorialCaja)
                Case Consulta.InstrumentoDeCredito
                    sqlcom1 = New SqlCommand("ERP_LisLiqVenCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadCaja1.IdVenta))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(EntidadCaja1.FechaActual)))
                    sqldat1.Fill(EntidadCaja1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
                    sqlcom1 = New SqlCommand("ERP_LisAboCaj", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(EntidadCaja1.FechaActual)))
                    sqldat1.Fill(EntidadCaja1.TablaConsulta)
                Case Consulta.Ninguno
                    sqlcom1 = New SqlCommand("LisRegCaj", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadCaja1.IdCaja))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
                    sqldat1.Fill(EntidadCaja1.TablaConsulta)
            End Select
            EntidadCaja1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCaja1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCaja = EntidadCaja1
        End Try
    End Sub
    Public Overridable Sub InsertarActualizar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadCaja1 As New Entidad.Caja()
        EntidadCaja1 = EntidadCaja
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActPagCaj", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadCaja1.IdCaja))
            sqlcom1.Parameters.Add(New SqlParameter("@INRecibo", EntidadCaja1.Recibo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@INPagoAbono", EntidadCaja1.PagoAbono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", EntidadCaja1.IdFormaPago))
            sqlcom1.Parameters.Add(New SqlParameter("@INDescuento", EntidadCaja1.Descuento))
            sqlcom1.Parameters.Add(New SqlParameter("@INPorcentaje", EntidadCaja1.Porcentaje))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadCaja1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCaja1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCaja1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCaja1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCaja1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCaja1.FechaActualizacion))
            If EntidadCaja1.IdCaja = 0 Then
                sqlcom1.Parameters(EntidadCaja1.IdCaja).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            EntidadCaja1.IdCaja = sqlcom1.Parameters(EntidadCaja1.IdCaja).Value

            For Each MiTableRow As DataRow In EntidadCaja1.TablaFormaPagoDetalleCaja.Rows
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
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadCaja1.IdCaja))
                If MiTableRow("IdFormaPagoDetalle") = 0 Then
                    sqlcom1.Parameters("@INIdFormaPagoDetalle").Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()
            Next
            For Each MiDataRow As DataRow In EntidadCaja1.TablaAbonoCaja.Rows
                sqlcom1.CommandText = "ERP_InsActPagAbo"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INCCPMovimiento", MiDataRow("IdCPPMovimiento")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCPP", MiDataRow("IdCPP")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTransaccion", MiDataRow("IdTransaccion")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", MiDataRow("IdTipoDocumento")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", MiDataRow("Serie")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", MiDataRow("Folio")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", MiDataRow("Fecha")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", MiDataRow("Descripcion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", MiDataRow("Observacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCajaMovimiento", EntidadCaja1.IdCaja))
                sqlcom1.Parameters.Add(New SqlParameter("@INMonto", MiDataRow("Monto")))
                sqlcom1.Parameters.Add(New SqlParameter("@INImpuesto", MiDataRow("Impuesto")))
                sqlcom1.Parameters.Add(New SqlParameter("@INSucursal", MiDataRow("Sucursal")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", MiDataRow("FechaCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", MiDataRow("FechaActualizacion")))




                'sqlcom1.Parameters.Add(New SqlParameter("@INIdPagoAbonos", MiDataRow("IdPagoAbonos")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", MiDataRow("IdPersona")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", MiDataRow("IdVenta")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", MiDataRow("IdFormaPago")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INAbono", MiDataRow("Abono")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoAbono", MiDataRow("IdTipoAbono")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadCaja1.IdCaja))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("IdUsuarioCreacion")))
                'sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                'sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("IdUsuarioActualizacion")))
                'sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))

                If MiDataRow("IdCPPMovimiento") = 0 Then
                    sqlcom1.Parameters("@INCCPMovimiento").Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()

            Next
            EntidadCaja1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCaja1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCaja = EntidadCaja1
        End Try
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
    Public Sub Liquidacion(ByRef EntidadCaja As Entidad.EntidadBase)
        Dim EntidadCaja1 As New Entidad.Caja()
        EntidadCaja1 = EntidadCaja
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActEstVentCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCPP", EntidadCaja1.IdVenta))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(EntidadCaja1.FechaActual)))
            sqlcom1.ExecuteNonQuery()
            EntidadCaja1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCaja1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCaja = EntidadCaja1
        End Try
    End Sub
    Public Sub ReporteMovimientoCaja(ByRef EntidadCaja As Entidad.Caja)
        'Dim EntidadCaja1 As New Entidad.Caja()
        'EntidadCaja1 = EntidadCaja
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadCaja.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisRepMovCajCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadCaja.IdPersona = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaFin", 100000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIni", EntidadCaja.IdPersona))
                sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaFin", EntidadCaja.IdPersona))
            End If
            If EntidadCaja.IdSucursal = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdSucursalIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSucursalFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdSucursalIni", EntidadCaja.IdSucursal))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSucursalFin", EntidadCaja.IdSucursal))
            End If
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaIni", CDate(EntidadCaja.FechaInicio)))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", CDate(EntidadCaja.FechaFin)))
            sqldat1.Fill(EntidadCaja.TablaConsulta)
            EntidadCaja.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCaja.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCaja.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub Cancelar(ByRef EntidadCaja As Entidad.EntidadBase)
        Dim EntidadCaja1 As New Entidad.Caja()
        EntidadCaja1 = EntidadCaja
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActCajCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadCaja1.IdCaja))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadCaja1.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadCaja1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCaja1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCaja1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCaja1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            sqlcom1.CommandText = "ERP_ActCajCodMov"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadCaja1.IdCaja))
            sqlcom1.ExecuteNonQuery()
            EntidadCaja1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCaja1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCaja = EntidadCaja1
        End Try
    End Sub
End Class




