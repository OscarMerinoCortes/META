Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class MovimientoInventario
    Implements ICatalogo   
    Public Sub Actualizar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActMovInvEnc", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventario", EntidadMovimientoInventario1.IdMovimientoInventario))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", EntidadMovimientoInventario1.Fecha))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadMovimientoInventario1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMovimientoInventario1.IdEstado))            
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMovimientoInventario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMovimientoInventario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            '================================Insertar Inventario Detalle===================================================
            For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaMovimientoDetalle.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("idMovimientoInventario") = 0 Then
                        sqlcom1.CommandText = "ERP_InsMovInvDet"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoDetalle", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventario", EntidadMovimientoInventario1.IdMovimientoInventario))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", MiDataRow("IdTipo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", MiDataRow("IdSubTipo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", MiDataRow("IdSucursalOrigen")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", MiDataRow("IdSucursalDestino")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", MiDataRow("IdAlmacenOrigen")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", MiDataRow("IdAlmacenDestino")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", CDate(MiDataRow("Descripcion"))))
                        sqlcom1.Parameters("@INIdMovimientoDetalle").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActMovInvDet"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoDetalle", EntidadMovimientoInventario1.IdMovimientoInventario))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", MiDataRow("IdTipo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", MiDataRow("IdSubTipo")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", MiDataRow("IdSucursalOrigen")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", MiDataRow("IdSucursalDestino")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", MiDataRow("IdAlmacenOrigen")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", MiDataRow("IdAlmacenDestino")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If

                End If
            Next
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub

    Public Sub Consultar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadMovimientoInventario1 = New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        EntidadMovimientoInventario1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadMovimientoInventario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_ConMovInvDet", sqlcon1)
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_ConProBas", sqlcon1)
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConMovInvEncPorId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadMovimientoInventario1.IdSucursalOrigen = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalFin", 10000000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalIni", EntidadMovimientoInventario1.IdSucursalOrigen))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalFin", EntidadMovimientoInventario1.IdSucursalOrigen))
                    End If
                    If EntidadMovimientoInventario1.IdAlmacenOrigen = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenFin", 10000000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenIni", EntidadMovimientoInventario1.IdAlmacenOrigen))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenFin", EntidadMovimientoInventario1.IdAlmacenOrigen))
                    End If
                    If EntidadMovimientoInventario1.IdEstado = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", 10000000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", EntidadMovimientoInventario1.IdEstado))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", EntidadMovimientoInventario1.IdEstado))
                    End If
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadMovimientoInventario1.FechaInicio))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadMovimientoInventario1.FechaFin))
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
                    sqlcom1 = New SqlCommand("ERP_ConSubMovInvIdPad", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadMovimientoInventario1.IdTipo = 1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
                    End If
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
                    sqlcom1 = New SqlCommand("ERP_ConAlmExiCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadMovimientoInventario1.IdProducto))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadMovimientoInventario1.IdAlmacenOrigen))
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_ConMovInvCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioMovimiento", EntidadMovimientoInventario1.IdMovimientoInventario))
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultarPorIdPersonas
                    For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaMovimientoDetalle.Rows
                        sqlcom1 = New SqlCommand("ValProEntCod", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioMovimiento", EntidadMovimientoInventario1.IdMovimientoInventario))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                        sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)
                        EntidadMovimientoInventario1.validar = True
                        If EntidadMovimientoInventario1.TablaConsulta.Rows.Count <> 1 Then
                            EntidadMovimientoInventario1.validar = False
                        End If
                        EntidadMovimientoInventario1.TablaConsulta.Rows.Clear()
                    Next
            End Select
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub

    Public Sub UpSert(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActMovInvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioMovimiento", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadMovimientoInventario1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", EntidadMovimientoInventario1.IdSucursalOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadMovimientoInventario1.IdAlmacenOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", EntidadMovimientoInventario1.IdSucursalDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", EntidadMovimientoInventario1.IdAlmacenDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", EntidadMovimientoInventario1.IdSubTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMovimientoInventario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadMovimientoInventario1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadMovimientoInventario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMovimientoInventario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMovimientoInventario1.FechaActualizacion))
            sqlcom1.Parameters(EntidadMovimientoInventario1.IdMovimientoInventario).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadMovimientoInventario1.IdMovimientoInventario = sqlcom1.Parameters(EntidadMovimientoInventario1.IdMovimientoInventario).Value
            '================================Insertar Inventario Detalle===================================================
            For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaMovimientoDetalle.Rows
                ''si se va a actualizar el registro
                'If MiDataRow("idActualizar") = 1 Then
                If MiDataRow("IdInventarioMovimiento") = 0 Then
                    'sqlcom1.CommandText = "ERP_InsMovInvDet"
                    sqlcom1.CommandText = "ERP_InsInvMovDetCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventarioDetalle", 0))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventario", EntidadMovimientoInventario1.IdMovimientoInventario))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", EntidadMovimientoInventario1.IdSubTipo))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", EntidadMovimientoInventario1.IdSucursalOrigen))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", EntidadMovimientoInventario1.IdSucursalDestino))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadMovimientoInventario1.IdAlmacenOrigen))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", EntidadMovimientoInventario1.IdAlmacenDestino))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 1))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadMovimientoInventario1.IdUsuarioCreacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadMovimientoInventario1.FechaCreacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMovimientoInventario1.IdUsuarioActualizacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMovimientoInventario1.FechaActualizacion))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", MiDataRow("Descripcion")))
                    sqlcom1.Parameters("@INIdMovimientoInventarioDetalle").Direction = ParameterDirection.InputOutput
                    sqlcom1.ExecuteNonQuery()
                    'Else
                    '    sqlcom1.CommandText = "ERP_ActMovInvDet"
                    '    sqlcom1.CommandType = CommandType.StoredProcedure
                    '    sqlcom1.Parameters.Clear()
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoDetalle", EntidadMovimientoInventario1.IdMovimientoInventario))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", MiDataRow("IdTipo")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", MiDataRow("IdSubTipo")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", MiDataRow("IdSucursalOrigen")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", MiDataRow("IdSucursalDestino")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", MiDataRow("IdAlmacenOrigen")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", MiDataRow("IdAlmacenDestino")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 1))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    '    sqlcom1.ExecuteNonQuery()
                End If
                'End If
            Next
            '=====================================================================================================
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
    Public Sub Aplicar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            '======================================================================================
            For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaMovimientoDetalle.Rows
                'si se va a aplicar
                If MiDataRow("IdActualizar") = 0 Then
                    sqlcom1 = New SqlCommand("ERP_AplMovInvCod", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventarioDetalle", MiDataRow("IdMovimientoInventarioDetalle")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", MiDataRow("IdTipo")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", MiDataRow("IdSubTipo")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", MiDataRow("IdAlmacenOrigen")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", MiDataRow("IdAlmacenDestino")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    sqlcom1.ExecuteNonQuery()
                End If
            Next
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
    Public Sub Cancelar(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            'sqlcon1.Open()
            ''====================================================================================== Cancelar
            'For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaMovimientoDetalle.Rows
            '    'si se va a aplicar
            '    If MiDataRow("IdActualizar") = 0 Then
            '        sqlcom1 = New SqlCommand("ERP_CanMovInvCod", sqlcon1)
            '        sqlcom1.CommandType = CommandType.StoredProcedure
            '        sqlcom1.Parameters.Clear()
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventarioDetalle", MiDataRow("IdMovimientoInventarioDetalle")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", MiDataRow("IdTipo")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", MiDataRow("IdSubTipo")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", MiDataRow("IdAlmacenOrigen")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", MiDataRow("IdAlmacenDestino")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
            '        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
            '        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
            '        sqlcom1.ExecuteNonQuery()
            '    End If
            'Next
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActMovInvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioMovimiento", EntidadMovimientoInventario1.IdMovimientoInventario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadMovimientoInventario1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", EntidadMovimientoInventario1.IdSucursalOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadMovimientoInventario1.IdAlmacenOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", EntidadMovimientoInventario1.IdSucursalDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", EntidadMovimientoInventario1.IdAlmacenDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", EntidadMovimientoInventario1.IdSubTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMovimientoInventario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadMovimientoInventario1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadMovimientoInventario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMovimientoInventario1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMovimientoInventario1.FechaActualizacion))
            'sqlcom1.Parameters(EntidadMovimientoInventario1.IdMovimientoInventario).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            'EntidadMovimientoInventario1.IdMovimientoInventario = sqlcom1.Parameters(EntidadMovimientoInventario1.IdMovimientoInventario).Value
            '================================Insertar Inventario Detalle===================================================
            For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaMovimientoDetalle.Rows
                ''si se va a actualizar el registro
                'If MiDataRow("idActualizar") = 1 Then

                'sqlcom1.CommandText = "ERP_InsMovInvDet"
                sqlcom1.CommandText = "ERP_CanInvMovDetCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioMovimientoDetalle", MiDataRow("IdInventarioMovimientoDetalle")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioMovimiento", EntidadMovimientoInventario1.IdMovimientoInventario))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSubTipo", EntidadMovimientoInventario1.IdSubTipo))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalOrigen", EntidadMovimientoInventario1.IdSucursalOrigen))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalDestino", EntidadMovimientoInventario1.IdSucursalDestino))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadMovimientoInventario1.IdAlmacenOrigen))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", EntidadMovimientoInventario1.IdAlmacenDestino))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2)) 'inactivo
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadMovimientoInventario1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadMovimientoInventario1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMovimientoInventario1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMovimientoInventario1.FechaActualizacion))
                'sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", MiDataRow("Descripcion")))
                'sqlcom1.Parameters("@INIdMovimientoInventarioDetalle").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
            Next
            'End If

            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadMovimientoInventario As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadMovimientoInventario1.TablaMovimientoDetalle = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisMovInvDetCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMovimientoInventario", EntidadMovimientoInventario1.IdMovimientoInventario))
            sqldat1.Fill(EntidadMovimientoInventario1.TablaMovimientoDetalle)
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
    Public Sub ObtenerPendientes(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadMovimientoInventario1.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisProEntCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadMovimientoInventario1.IdAlmacenOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", EntidadMovimientoInventario1.IdAlmacenDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INEstatus", EntidadMovimientoInventario1.Estatus))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadMovimientoInventario1.FechaInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadMovimientoInventario1.FechaFin))
            sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
    Public Sub ActualizarPendientes(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            For Each MiDataRow As DataRow In EntidadMovimientoInventario1.TablaPendientes.Rows
                sqlcom1 = New SqlCommand("ERP_ActMovInvPenCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEntrega", MiDataRow("IdEntrega")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                sqlcom1.Parameters.Add(New SqlParameter("@CantidadFaltante", MiDataRow("CantidadFaltante")))
                sqlcom1.Parameters.Add(New SqlParameter("@INRecibi", MiDataRow("Recibi")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", MiDataRow("IdAlmacenOrigen")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", MiDataRow("IdAlmacenDestino")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMovimientoInventario1.idUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMovimientoInventario1.FechaActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@Estatus", MiDataRow("IdProductoEntregaEstatus")))
                sqlcom1.ExecuteNonQuery()
            Next
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
    Public Sub ConsultaTraspasoEnvio(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 = New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        EntidadMovimientoInventario1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadMovimientoInventario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_ConProEntEst", sqlcon1)
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_ConSegTraEnvDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadMovimientoInventario1.IdAlmacenOrigen = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigenIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigenFin", 10000000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigenIni", EntidadMovimientoInventario1.IdAlmacenOrigen))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigenFin", EntidadMovimientoInventario1.IdAlmacenOrigen))
                    End If
                    If EntidadMovimientoInventario1.IdAlmacenDestino = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestinoIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestinoFin", 10000000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestinoIni", EntidadMovimientoInventario1.IdAlmacenDestino))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestinoFin", EntidadMovimientoInventario1.IdAlmacenDestino))
                    End If
                    If EntidadMovimientoInventario1.IdEstado = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", 10000000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", EntidadMovimientoInventario1.IdEstado))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", EntidadMovimientoInventario1.IdEstado))
                    End If
                    sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio", EntidadMovimientoInventario1.FechaInicio))
                    sqlcom1.Parameters.Add(New SqlParameter("@FechaFin", EntidadMovimientoInventario1.FechaFin))

                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
                    sqlcom1 = New SqlCommand("ERP_ConSubMovInvIdPad", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadMovimientoInventario1.IdTipo = 1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", EntidadMovimientoInventario1.IdTipo))
                    End If
                    sqldat1.Fill(EntidadMovimientoInventario1.TablaConsulta)
            End Select
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
    Public Sub GraficasMovimientoInventario(ByRef EntidadMovimientoInventario As Entidad.EntidadBase)
        Dim EntidadMovimientoInventario1 = New Entidad.MovimientoInventario()
        EntidadMovimientoInventario1 = EntidadMovimientoInventario
        EntidadMovimientoInventario1.TablaConsulta = New DataTable()

        EntidadMovimientoInventario1.TablaCantidadPorSucursal = New DataTable
        EntidadMovimientoInventario1.TablaMontoPorSucursal = New DataTable
        EntidadMovimientoInventario1.TablaExistenciaPorAlmacen = New DataTable
        EntidadMovimientoInventario1.TablaExcedentes = New DataTable
        EntidadMovimientoInventario1.TablaFaltantes = New DataTable
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            'Consultar cantidad de productos por empresa
            sqldat1 = New SqlDataAdapter("ERP_GraNumProMes", sqlcon1)
            sqldat1.Fill(EntidadMovimientoInventario1.TablaCantidadPorSucursal)
            'Consultar monto de productos por empresa
            sqldat1 = New SqlDataAdapter("ERP_GraMonProMes", sqlcon1)
            sqldat1.Fill(EntidadMovimientoInventario1.TablaMontoPorSucursal)
            'Consultar cantidad de productos por almacen
            sqldat1 = New SqlDataAdapter("ERP_GraProAlmMes", sqlcon1)
            sqldat1.Fill(EntidadMovimientoInventario1.TablaExistenciaPorAlmacen)
            'Consultar cantidad de productos excendentes
            sqldat1 = New SqlDataAdapter("ERP_GraProExc", sqlcon1)
            sqldat1.Fill(EntidadMovimientoInventario1.TablaExcedentes)
            'Consultar cantidad de productos faltantes
            sqldat1 = New SqlDataAdapter("ERP_GraProFal", sqlcon1)
            sqldat1.Fill(EntidadMovimientoInventario1.TablaFaltantes)

            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadMovimientoInventario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMovimientoInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMovimientoInventario = EntidadMovimientoInventario1
        End Try
    End Sub
End Class
