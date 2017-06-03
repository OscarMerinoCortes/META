Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Producto
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadProducto1 As New Entidad.Producto()
        EntidadProducto1 = EntidadProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActProCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
            AgragarParametrosProducto(sqlcom1, EntidadProducto1)
            sqlcom1.ExecuteNonQuery()
            'EntidadProducto1.IdProducto = sqlcom1.Parameters(EntidadProducto1.IdProducto).Value

            '========================================================== codigo de barras =====================================================
            For Each MiDataRow As DataRow In EntidadProducto1.TablaCodigoBarra.Rows
                'si se va a actualizar el registro
                InsertarActualizarCodigoBarra(sqlcom1, MiDataRow, EntidadProducto1)
            Next
            '========================================================== maximos y minimos =====================================================
            For Each MiDataRow As DataRow In EntidadProducto1.TablaMaximoMinimo.Rows
                'si se va a actualizar el registro
                InsertarActualizarMaximoMinimo(sqlcom1, MiDataRow, EntidadProducto1)
            Next
            '========================================================== maximos y minimos =====================================================
            For Each MiDataRow As DataRow In EntidadProducto1.TablaPrecio.Rows
                'si se va a actualizar el registro
                InsertarActualizarPrecio(sqlcom1, MiDataRow, EntidadProducto1)
            Next

            'Productos
            For Each MiDataRow As DataRow In EntidadProducto1.TablaProveedor.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedor_Producto") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", MiDataRow("IdProveedor")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", MiDataRow("IdProveedor_Producto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", MiDataRow("IdProveedor")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadProducto = EntidadProducto1
        End Try
    End Sub
    Public Sub WucEstadistica(ByRef EntIdadEstadistica As Entidad.EntidadBase) 'Implements ICatalogo.Consultar  ====VENTA
        Dim EntIdadEstadistica1 = New Entidad.Producto()
        EntIdadEstadistica1 = EntIdadEstadistica
        EntIdadEstadistica1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ConVenEst", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            Dim sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoCorto", EntIdadEstadistica1.IdProductoCorto))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntIdadEstadistica1.FechaInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntIdadEstadistica1.FechaFin))
            sqldat1.Fill(EntIdadEstadistica1.TablaConsulta)
            EntIdadEstadistica1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadEstadistica1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadEstadistica1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntIdadEstadistica = EntIdadEstadistica1
        End Try
    End Sub
    Private Sub AgragarParametrosProducto(ByRef sqlcom1 As SqlCommand, ByVal entidadProducto1 As Entidad.Producto)
        sqlcom1.Parameters.Add(New SqlParameter("@IVIdProductoCorto", entidadProducto1.IdProductoCorto))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", entidadProducto1.Descripcion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoProducto", entidadProducto1.IdTipo))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUnidad", entidadProducto1.IdUnidad))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", entidadProducto1.IdSubclasificacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", entidadProducto1.IdEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPermitirVentaPrecioCero", entidadProducto1.VentaPrecioCero))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPermitirVentaCeroExistencia", entidadProducto1.VentaExistenciaCero))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAfectaInventario", entidadProducto1.AfectaInventario))
        sqlcom1.Parameters.Add(New SqlParameter("@INGanancia", entidadProducto1.Ganancia))
        sqlcom1.Parameters.Add(New SqlParameter("@INPorcentaje", entidadProducto1.Porcentaje))
        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioBase", entidadProducto1.PrecioBase))
        sqlcom1.Parameters.Add(New SqlParameter("@INProveedor", entidadProducto1.Proveedor))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadProducto1.idUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadProducto1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", entidadProducto1.PrecioUltimaEntrada))
    End Sub
    Private Sub InsertarActualizarCodigoBarra(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadProducto1 As Entidad.Producto)
        If miDataRow("idActualizar") = 1 Then
            If miDataRow("IdProductoCodigoBarra") = 0 Then
                sqlcom1.CommandText = "ERP_InsProCodBarCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosCodigoBarra(sqlcom1, miDataRow, entidadProducto1)
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", miDataRow("idUsuarioCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(miDataRow("FechaCreacion"))))
                sqlcom1.Parameters("@INIdProductoCodigoBarra").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
            Else
                sqlcom1.CommandText = "ERP_ActProCodBarCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosCodigoBarra(sqlcom1, miDataRow, entidadProducto1)
                sqlcom1.ExecuteNonQuery()
            End If
        End If
    End Sub
    Private Sub AgregarParametrosCodigoBarra(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadProducto1 As Entidad.Producto)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoCodigoBarra", miDataRow("IdProductoCodigoBarra")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVCodigoBarra", miDataRow("CodigoBarra")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", entidadProducto1.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("IdEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("idUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
    End Sub
    Private Sub InsertarActualizarMaximoMinimo(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadProducto1 As Entidad.Producto)
        If miDataRow("idActualizar") = 1 Then
            If miDataRow("IdProductoMaximoMinimo") = 0 Then
                sqlcom1.CommandText = "ERP_InsProMaxMinCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosMaximoMinimo(sqlcom1, miDataRow, entidadProducto1)
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", miDataRow("idUsuarioCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(miDataRow("FechaCreacion"))))
                sqlcom1.Parameters("@INIdProductoMaximoMinimo").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
            Else
                sqlcom1.CommandText = "ERP_ActProMaxMinCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosMaximoMinimo(sqlcom1, miDataRow, entidadProducto1)
                sqlcom1.ExecuteNonQuery()
            End If
        End If
    End Sub
    Private Sub AgregarParametrosMaximoMinimo(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadProducto1 As Entidad.Producto)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoMaximoMinimo", miDataRow("IdProductoMaximoMinimo")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", entidadProducto1.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", miDataRow("IdAlmacen")))
        sqlcom1.Parameters.Add(New SqlParameter("@INMaximo", miDataRow("Maximo")))
        sqlcom1.Parameters.Add(New SqlParameter("@INMinimo", miDataRow("Minimo")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("IdEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("idUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
    End Sub
    Private Sub InsertarActualizarPrecio(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadProducto1 As Entidad.Producto)
        If miDataRow("idActualizar") = 1 Then
            If miDataRow("IdProductoPrecio") = 0 Then
                sqlcom1.CommandText = "ERP_InsProPreCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosPrecio(sqlcom1, miDataRow, entidadProducto1)
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", miDataRow("idUsuarioCreacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(miDataRow("FechaCreacion"))))
                sqlcom1.Parameters("@INIdProductoPrecio").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
            Else
                sqlcom1.CommandText = "ERP_ActProPreCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosPrecio(sqlcom1, miDataRow, entidadProducto1)
                sqlcom1.ExecuteNonQuery()
            End If
        End If
    End Sub
    Private Sub AgregarParametrosPrecio(ByVal sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal entidadProducto1 As Entidad.Producto)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoPrecio", miDataRow("IdProductoPrecio")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", entidadProducto1.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPlazo", miDataRow("IdTipoPlazo")))
        sqlcom1.Parameters.Add(New SqlParameter("@INPrecio", miDataRow("Precio")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("idEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("idUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
    End Sub

    Public Sub Consultar(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadProducto1 = New Entidad.Producto()
        EntidadProducto1 = EntidadProducto
        EntidadProducto1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadProducto1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica
                    If (EntidadProducto1.IVA = 1) Then
                        sqldat1 = New SqlDataAdapter("ERP_ConIvaProCod", sqlcon1)
                        sqldat1.Fill(EntidadProducto1.TablaConsulta)
                    Else
                        sqldat1 = New SqlDataAdapter("ERP_ConProBas", sqlcon1)
                        sqldat1.Fill(EntidadProducto1.TablaConsulta)
                    End If

                Case Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_ConProDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()

                    sqldat1.Fill(EntidadProducto1.TablaConsulta)

                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConProBasId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoCorto", EntidadProducto1.IdProductoCorto))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)

                Case Consulta.ConsultaDetalladaPorId
                    sqlcom1 = New SqlCommand("ERP_ConProDetId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)

                Case Consulta.ConsultaPorIdPadre
                    sqlcom1 = New SqlCommand("ERP_LisProIdPad", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadProducto1.IdProducto = 0 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoIni", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoFin", 100000))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoIni", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoFin", EntidadProducto1.IdProducto))
                    End If
                    sqlcom1.Parameters.Add(New SqlParameter("@IVIdProductoCorto", EntidadProducto1.IdProductoCorto))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)
                Case Consulta.Ninguno
                    If EntidadProducto1.IdTipo = 2 Then
                        sqlcom1 = New SqlCommand("ERP_ConProBus", sqlcon1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
                    Else
                        sqlcom1 = New SqlCommand("ERP_ConProBusCod", sqlcon1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVIdProductoCorto", EntidadProducto1.IdProductoCorto))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
                    End If
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)
                Case Consulta.ConsultaPorIdProducto
                    sqlcom1 = New SqlCommand("ERP_BusProPorIdWuc", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)

                Case Consulta.ConsultarPorIdPersona
                    sqlcom1 = New SqlCommand("ERP_ConSugOrdId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadProducto1.IdProducto))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)

                Case Consulta.ConsultaBusqueda   'Se usa para referenciar al wuc de producto 
                    sqlcom1 = New SqlCommand("ERP_ConBasProWuc", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)
            End Select
            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadProducto = EntidadProducto1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadProducto1 As New Entidad.Producto()
        EntidadProducto1 = EntidadProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsProCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", 0))
            AgragarParametrosProducto(sqlcom1, EntidadProducto1)
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadProducto1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadProducto1.FechaCreacion))
            sqlcom1.Parameters(EntidadProducto1.IdProducto).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadProducto1.IdProducto = sqlcom1.Parameters(EntidadProducto1.IdProducto).Value

            '========================================================== codigo de barras =====================================================
            For Each MiDataRow As DataRow In EntidadProducto1.TablaCodigoBarra.Rows
                'si se va a actualizar el registro
                InsertarActualizarCodigoBarra(sqlcom1, MiDataRow, EntidadProducto1)
            Next
            '========================================================== maximos y minimos =====================================================
            For Each MiDataRow As DataRow In EntidadProducto1.TablaMaximoMinimo.Rows
                'si se va a actualizar el registro
                InsertarActualizarMaximoMinimo(sqlcom1, MiDataRow, EntidadProducto1)
            Next
            '========================================================== maximos y minimos =====================================================
            For Each MiDataRow As DataRow In EntidadProducto1.TablaPrecio.Rows
                'si se va a actualizar el registro
                InsertarActualizarPrecio(sqlcom1, MiDataRow, EntidadProducto1)
            Next


            'Productos
            For Each MiDataRow As DataRow In EntidadProducto1.TablaProveedor.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedor_Producto") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", MiDataRow("IdProveedor")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", MiDataRow("IdProveedor_Producto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", MiDataRow("IdProveedor")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next




            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadProducto = EntidadProducto1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntidadProducto As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadProducto1 As New Entidad.Producto()
        EntidadProducto1 = EntidadProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadProducto1.TablaCodigoBarra = New DataTable()
        EntidadProducto1.TablaMaximoMinimo = New DataTable()
        EntidadProducto1.TablaPrecio = New DataTable()
        EntidadProducto1.TablaProveedor = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisProCodBarCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_LisProCodBarCod"
            sqldat1.Fill(EntidadProducto1.TablaCodigoBarra)
            'Tabla Domicilio
            sqlcom1.CommandText = "ERP_LisProMaxMinCod"
            sqldat1.Fill(EntidadProducto1.TablaMaximoMinimo)
            'Tabla Empleo
            sqlcom1.CommandText = "ERP_LisProPreCod"
            sqldat1.Fill(EntidadProducto1.TablaPrecio)
            'Tabla  Proveedor
            sqlcom1.CommandText = "ERP_LisProvProdCod"
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
            sqldat1.Fill(EntidadProducto1.TablaProveedor)




            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub VentaObtener(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim EntidadProducto1 As New Entidad.Producto()
        EntidadProducto1 = EntidadProducto
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        EntidadProducto.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            Select Case EntidadProducto1.Tarjeta.Consulta
                Case Consulta.ConsultaPorDescripcion
                    If EntidadProducto1.Descripcion.Length >= 2 Then
                        sqlcom1 = New SqlCommand("ERP_VenObtProDes", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadProducto1.IdAlmacen))
                        sqldat1.Fill(EntidadProducto1.TablaConsulta)
                    Else
                        EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
                        EntidadProducto1.Tarjeta.Excepcion = "La busqueda debe tener minimo 2 letras"
                    End If
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_VenObtProId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IVIdProductoCorto", EntidadProducto1.Descripcion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadProducto1.IdAlmacen))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)
                Case Consulta.ConsultaPorFiltro
                    sqlcom1 = New SqlCommand("ERP_VenObtProSucId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IVIdProductoCorto", EntidadProducto1.Descripcion))
                    sqldat1.Fill(EntidadProducto1.TablaConsulta)
            End Select
            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ObtenerPerfil(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim EntidadProducto1 As New Entidad.PerfilProducto()
        EntidadProducto1 = EntidadProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadProducto1.TablaCompra = New DataTable()
        EntidadProducto1.TablaVenta = New DataTable()
        EntidadProducto1.TablaExistencia = New DataTable()
        EntidadProducto1.TablaProveedor = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtProPerCom", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
            'Tabla Compra
            sqlcom1.CommandText = "ERP_ObtProPerCom"
            sqldat1.Fill(EntidadProducto1.TablaCompra)
            'Tabla Venta
            sqlcom1.CommandText = "ERP_ObtProPerVen"
            sqldat1.Fill(EntidadProducto1.TablaVenta)
            'Tabla Existencia
            sqlcom1.CommandText = "ERP_ObtProPerExi"
            sqldat1.Fill(EntidadProducto1.TablaExistencia)
            'Tabla Proveedor
            sqlcom1.CommandText = "ERP_ObtProPerPro"
            sqldat1.Fill(EntidadProducto1.TablaProveedor)

            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ObtenerPerfilWuc(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadProducto.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ConProDet", sqlcon1)
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqldat1.Fill(EntidadProducto.TablaConsulta)
            EntidadProducto.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub WucBusquedaProductoEstadisticas(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim EntidadProducto1 As Entidad.Producto = EntidadProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadProducto1.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ConProIdDes", sqlcon1)
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
            sqldat1.Fill(EntidadProducto1.TablaConsulta)
            EntidadProducto.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
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
    Public Sub ObtenerFiltro(ByRef EntidadProducto As Entidad.EntidadBase)
        Dim EntidadProducto1 As New Entidad.Producto()
        EntidadProducto1 = EntidadProducto
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadProducto.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_ConProFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
            sqlcom1.Parameters.Add(New SqlParameter("@IVIdProductoCorto", EntidadProducto1.IdProductoCorto))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadProducto1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadProducto1.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadProducto1.IdSubclasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadProducto1.IdEstado))
            sqldat1.Fill(EntidadProducto.TablaConsulta)
            EntidadProducto.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadProducto = EntidadProducto1
        End Try
    End Sub
End Class
