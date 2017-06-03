Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class RegistroInventario
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActInvEncCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioEncabezado", EntidadRegistroInventario1.IdInventario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadRegistroInventario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", EntidadRegistroInventario1.Observaciones))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadRegistroInventario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadRegistroInventario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadRegistroInventario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            '================================Insertar Inventario Detalle===================================================
            For Each MiDataRow As DataRow In EntidadRegistroInventario1.TablaInventarioDetalle.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("idEncabezado") = 0 Then
                        sqlcom1.CommandText = "ERP_InsInvDetCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioDetalle", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INidEncabezado", EntidadRegistroInventario1.IdInventario))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", MiDataRow("IdAlmacen")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", MiDataRow("IdClasificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSubClasificacion", MiDataRow("IdSubClasificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadSistema", MiDataRow("CantidadSistema")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadReal", MiDataRow("CantidadReal")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDiferencia", MiDataRow("Diferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@INIdInventarioDetalle").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActInvDetCod"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEncabezado", EntidadRegistroInventario1.IdInventario))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", MiDataRow("IdAlmacen")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", MiDataRow("IdClasificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSubClasificacion", MiDataRow("IdSubClasificacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadSistema", MiDataRow("CantidadSistema")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadReal", MiDataRow("CantidadReal")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INDiferencia", MiDataRow("Diferencia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        'sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        'sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRegistroInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRegistroInventario = EntidadRegistroInventario1
        End Try
    End Sub

    Public Sub Consultar(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadRegistroInventario1 = New Entidad.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        EntidadRegistroInventario1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadRegistroInventario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_ConInvEncDet", sqlcon1)
                    sqldat1.Fill(EntidadRegistroInventario1.TablaConsulta)
                    'Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    '    sqldat1 = New SqlDataAdapter("ERP_ConProBas", sqlcon1)
                    '    sqldat1.Fill(EntidadProducto1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConInvEncId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadRegistroInventario1.IdSucursal = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalFin", 100000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalIni", EntidadRegistroInventario1.IdSucursal))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursalFin", EntidadRegistroInventario1.IdSucursal))
                    End If
                    If EntidadRegistroInventario1.IdAlmacen = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenFin", 100000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenIni", EntidadRegistroInventario1.IdAlmacen))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenFin", EntidadRegistroInventario1.IdAlmacen))
                    End If
                    If EntidadRegistroInventario1.IdEstado = -1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", 100000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoIni", EntidadRegistroInventario1.IdEstado))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoFin", EntidadRegistroInventario1.IdEstado))
                    End If
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadRegistroInventario1.FechaInicio))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadRegistroInventario1.FechaFin))
                    sqldat1.Fill(EntidadRegistroInventario1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorIdProducto
                    sqlcom1 = New SqlCommand("ERP_LisProId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadRegistroInventario1.IdAlmacen))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIClasificacion", EntidadRegistroInventario1.IdClasificacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubClasificacion", EntidadRegistroInventario1.IdSubClasificacion))
                    sqldat1.Fill(EntidadRegistroInventario1.TablaConsulta)
                Case Consulta.ConsultaDetalladaPorId
                    sqlcom1 = New SqlCommand("ERP_ObtenerExistencia", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadRegistroInventario1.IdProducto))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadRegistroInventario1.IdAlmacen))
                    sqldat1.Fill(EntidadRegistroInventario1.TablaConsulta)
            End Select
            EntidadRegistroInventario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadRegistroInventario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadRegistroInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRegistroInventario = EntidadRegistroInventario1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsInvEncCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioEncabezado", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadRegistroInventario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservaciones", EntidadRegistroInventario1.Observaciones))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadRegistroInventario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadRegistroInventario1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadRegistroInventario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadRegistroInventario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadRegistroInventario1.FechaActualizacion))
            sqlcom1.Parameters(EntidadRegistroInventario1.IdInventario).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadRegistroInventario1.IdInventario = sqlcom1.Parameters(EntidadRegistroInventario1.IdInventario).Value
            '================================Insertar Inventario Detalle===================================================
            For Each MiDataRow As DataRow In EntidadRegistroInventario1.TablaInventarioDetalle.Rows
                'si se va a inserta el registro
                'If MiDataRow("idActualizar") = 1 Then
                If MiDataRow("IdEncabezado") = 0 Then
                    sqlcom1.CommandText = "ERP_InsInvDetCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioDetalle", 0))
                    sqlcom1.Parameters.Add(New SqlParameter("@INidEncabezado", EntidadRegistroInventario1.IdInventario))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", MiDataRow("IdAlmacen")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", MiDataRow("IdClasificacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INidSubClasificacion", MiDataRow("IdSubClasificacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidadSistema", MiDataRow("CantidadSistema")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidadReal", MiDataRow("CantidadReal")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INDiferencia", MiDataRow("Diferencia")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    sqlcom1.Parameters("@INIdInventarioDetalle").Direction = ParameterDirection.InputOutput
                    sqlcom1.ExecuteNonQuery()
                Else
                    'sqlcom1.CommandText = "ERP_ActInvDetCod"
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioDetalle", MiDataRow("Id")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdEncabezado", EntidadRegistroInventario1.IdInventario))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INCantidadSistema", MiDataRow("CantidadSistema")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INCantidadReal", MiDataRow("CantidadReal")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INDiferencia", MiDataRow("Diferencia")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    'sqlcom1.ExecuteNonQuery()
                End If
                'End If
            Next
            '=====================================================================================================
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRegistroInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRegistroInventario = EntidadRegistroInventario1
        End Try
    End Sub
    Public Sub Aplicar(ByRef EntidadRegistroInventario As Entidad.EntidadBase)
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            '======================================================================================
            For Each MiDataRow As DataRow In EntidadRegistroInventario1.TablaInventarioDetalle.Rows
                'si se va a actualizar el registro
                If MiDataRow("IdActualizar") = 0 Then
                    sqlcom1 = New SqlCommand("ERP_AplRegInvCod", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioEncabezado", MiDataRow("IdEncabezado")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("CantidadReal")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidadSistema", MiDataRow("CantidadSistema")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", MiDataRow("IdAlmacen")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    sqlcom1.ExecuteNonQuery()
                End If
            Next
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRegistroInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRegistroInventario = EntidadRegistroInventario1
        End Try
    End Sub
    Public Sub Cancelar(ByRef EntidadRegistroInventario As Entidad.EntidadBase)
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            '======================================================================================
            For Each MiDataRow As DataRow In EntidadRegistroInventario1.TablaInventarioDetalle.Rows
                'si se va a actualizar el registro
                If MiDataRow("IdActualizar") = 0 Then
                    sqlcom1 = New SqlCommand("ERP_CanRegInvCod", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdInventarioEncabezado", MiDataRow("IdEncabezado")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("CantidadSistema")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INDiferencia", MiDataRow("Diferencia")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", MiDataRow("IdAlmacen")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    sqlcom1.ExecuteNonQuery()
                End If
            Next
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRegistroInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRegistroInventario = EntidadRegistroInventario1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadRegistroInventario As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadRegistroInventario1 As New Entidad.RegistroInventario()
        EntidadRegistroInventario1 = EntidadRegistroInventario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadRegistroInventario1.TablaInventarioDetalle = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisInvDetCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdInventario", EntidadRegistroInventario1.IdInventario))
            'sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadRegistroInventario1.IdAlmacen))
            sqldat1.Fill(EntidadRegistroInventario1.TablaInventarioDetalle)
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRegistroInventario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRegistroInventario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ObtenerTablas(ByRef EntidadProducto As Entidad.EntidadBase)
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntidadProducto.TablaIdentificacion = New DataTable()
        'EntidadProducto.TablaContacto = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    'tabla identificacion
        '    sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto.IdProducto))
        '    sqldat1.Fill(EntidadProducto.TablaIdentificacion)
        '    'Tabla Contacto
        '    sqlcom1.CommandText = "ERP_LisPerMedCod"
        '    sqldat1.Fill(EntidadProducto.TablaContacto)
        '    'Tabla Domicilio
        '    sqlcom1.CommandText = "ERP_LisPerDomCod"
        '    sqldat1.Fill(EntidadProducto.TablaDomicilio)
        '    EntidadProducto.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadProducto.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadProducto.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub

    Public Sub ReporteProducto(ByRef EntidadReporteProducto As Entidad.EntidadBase)
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntidadReporteProducto.TablaConsulta = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    'tabla identificacion
        '    sqlcom1 = New SqlCommand("ERP_LisRepPerCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    If EntidadReporteProducto.IdTipoProducto = -1 Then
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoProductoIni", 0))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoProductoFin", 1000000))
        '    Else
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoProductoIni", EntidadReporteProducto.IdTipoProducto))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoProductoFin", EntidadReporteProducto.IdTipoProducto))
        '    End If
        '    If EntidadReporteProducto.IdGenero = -1 Then
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", 0))
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", 1000000))
        '    Else
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", EntidadReporteProducto.IdGenero))
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", EntidadReporteProducto.IdGenero))
        '    End If
        '    If EntidadReporteProducto.IdEstado = -1 Then
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", 0))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", 1000000))
        '    Else
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", EntidadReporteProducto.IdEstado))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", EntidadReporteProducto.IdEstado))
        '    End If
        '    sqldat1.Fill(EntidadReporteProducto.TablaConsulta)
        '    EntidadReporteProducto.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadReporteProducto.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadReporteProducto.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub
End Class
