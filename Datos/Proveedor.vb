Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Proveedor
    Implements IProveedor
    Public Sub Actualizar(ByRef EntidadProveedor As Entidad.EntidadBase) Implements IProveedor.Actualizar
        Dim EntidadProveedor1 As New Entidad.Proveedor()
        EntidadProveedor1 = EntidadProveedor
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActProvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadProveedor1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", EntidadProveedor1.IdTipoPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", EntidadProveedor1.RazonSocial))
            sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", EntidadProveedor1.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", EntidadProveedor1.SegundoNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", EntidadProveedor1.ApellidoPaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", EntidadProveedor1.ApellidoMaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVRFC", EntidadProveedor1.RFC))
            sqlcom1.Parameters.Add(New SqlParameter("@INLimiteCredito", EntidadProveedor1.LimiteCredito))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadProveedor1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadProveedor1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadProveedor1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadProveedor1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            For Each MiDataRow As DataRow In EntidadProveedor1.TablaContacto.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedorContacto") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProvCon"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorContacto", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoContacto", MiDataRow("IdTipoContacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVContacto", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@INIdProveedorContacto").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProvCon"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorContacto", MiDataRow("IdProveedorContacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoContacto", MiDataRow("IdTipoContacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVContacto", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            For Each MiDataRow As DataRow In EntidadProveedor1.TablaDireccion.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedorDomicilio") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProvDom"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorDomicilio", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", MiDataRow("IdPais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", MiDataRow("IdEntidadFederativa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", MiDataRow("IdMunicipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdLocalidad", MiDataRow("IdLocalidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdColonia", MiDataRow("IdColonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCP", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@INIdProveedorDomicilio").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProvDom"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorDomicilio", MiDataRow("IdProveedorDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", MiDataRow("IdPais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", MiDataRow("IdEntidadFederativa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", MiDataRow("IdMunicipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdLocalidad", MiDataRow("IdLocalidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdColonia", MiDataRow("IdColonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCP", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            'Productos
            For Each MiDataRow As DataRow In EntidadProveedor1.TablaProducto.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedor_Producto") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        'sqlcom1.Parameters("@INIdProveedorContacto").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", MiDataRow("IdProveedor_Producto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            EntidadProveedor1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadProveedor1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadProveedor1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadProveedor = EntidadProveedor1
        End Try
    End Sub
    Public Sub WucEstadistica(ByRef EntIdadEstadistica As Entidad.EntidadBase) 'Implements ICatalogo.Consultar
        Dim EntIdadEstadistica1 = New Entidad.Proveedor()
        EntIdadEstadistica1 = EntIdadEstadistica
        EntIdadEstadistica1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ConProvEst", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            Dim sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoCorto", EntIdadEstadistica1.IdProductoCorto))
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
    Public Sub Insertar(ByRef EntidadPersona As Entidad.EntidadBase) Implements IProveedor.Insertar
        Dim EntidadProveedor1 As New Entidad.Proveedor()
        EntidadProveedor1 = EntidadPersona
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsProvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadProveedor1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", EntidadProveedor1.IdTipoPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", EntidadProveedor1.RazonSocial))
            sqlcom1.Parameters.Add(New SqlParameter("@IVRFC", EntidadProveedor1.RFC))
            sqlcom1.Parameters.Add(New SqlParameter("@IVPrimerNombre", EntidadProveedor1.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSegundoNombre", EntidadProveedor1.SegundoNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoPaterno", EntidadProveedor1.ApellidoPaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVApellidoMaterno", EntidadProveedor1.ApellidoMaterno))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadProveedor1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INLimiteCredito", EntidadProveedor1.LimiteCredito))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadProveedor1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadProveedor1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadProveedor1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadProveedor1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadProveedor1.FechaActualizacion))
            sqlcom1.Parameters(EntidadProveedor1.IdProveedor).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadProveedor1.IdProveedor = sqlcom1.Parameters(EntidadProveedor1.IdProveedor).Value

            For Each MiDataRow As DataRow In EntidadProveedor1.TablaContacto.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedorContacto") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProvCon"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorContacto", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoContacto", MiDataRow("IdTipoContacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVContacto", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@INIdProveedorContacto").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProvCon"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorContacto", MiDataRow("IdProveedorContacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoContacto", MiDataRow("IdTipoContacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVContacto", MiDataRow("Contacto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            For Each MiDataRow As DataRow In EntidadProveedor1.TablaDireccion.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedorDomicilio") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProvDom"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedorDomicilio", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", MiDataRow("IdPais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", MiDataRow("IdEntidadFederativa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", MiDataRow("IdMunicipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdLocalidad", MiDataRow("IdLocalidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdColonia", MiDataRow("IdColonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCP", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.Parameters("@INIdProveedorDomicilio").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProvDom"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IdProveedorDomicilio", MiDataRow("IdProveedorDomicilio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVCalle", MiDataRow("Calle")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", MiDataRow("Pais")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", MiDataRow("EntidadFederativa")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", MiDataRow("Municipio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdLocalidad", MiDataRow("Localidad")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdColonia", MiDataRow("Colonia")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroInterior", MiDataRow("NumeroInterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVNumeroExterior", MiDataRow("NumeroExterior")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INCP", MiDataRow("CP")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next

            'proveedor_producto

            For Each MiDataRow As DataRow In EntidadProveedor1.TablaProducto.Rows
                'si se va a actualizar el registro
                If MiDataRow("idActualizar") = 1 Then
                    If MiDataRow("IdProveedor_Producto") = 0 Then
                        sqlcom1.CommandText = "ERP_InsProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", 0))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        'sqlcom1.Parameters("@INIdProveedorContacto").Direction = ParameterDirection.InputOutput
                        sqlcom1.ExecuteNonQuery()
                    Else
                        sqlcom1.CommandText = "ERP_ActProdProv"
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor_Producto", MiDataRow("IdProveedor_Producto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", MiDataRow("Precio")))
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", MiDataRow("IdEstado")))
                        sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                        sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                        sqlcom1.ExecuteNonQuery()
                    End If
                End If
            Next


            EntidadProveedor1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadProveedor1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadProveedor1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadProveedor1
        End Try
    End Sub
    Public Sub Consultar(ByRef EntidadProveedor As Entidad.EntidadBase) Implements IProveedor.Consultar
        Dim EntidadProveedor1 = New Entidad.Proveedor()
        EntidadProveedor1 = EntidadProveedor
        EntidadProveedor1.TablaConsulta = New DataTable()

        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadProveedor1.Tarjeta.Consulta
                Case Consulta.ConsultaDetalladaPorId
                    sqlcom1 = New SqlCommand("ERP_ConProvDetId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    'sqldat1 = New SqlDataAdapter("ERP_ConRegPerDet", sqlcon1)
                    'sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_ConRegProvBas", sqlcon1)
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaProveedor
                    sqldat1 = New SqlDataAdapter("ERP_ConRegProvBasCXP", sqlcon1)
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaProveedorIdPer
                    'sqlcom1 = New SqlCommand("ERP_ConRegPerProvId", sqlcon1)
                    'sqldat1 = New SqlDataAdapter(sqlcom1)
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadProveedor1.IdPersona))
                    'sqldat1.Fill(EntidadProveedor1.TablaConsulta)
               ' Case Consulta.ConsultaProveedorIdPro
                    'sqlcom1 = New SqlCommand("ERP_ConRegPerProvIdPro", sqlcon1)
                    'sqldat1 = New SqlDataAdapter(sqlcom1)
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProveedor1.IdPersona))
                    'sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.Ninguno
                    'sqlcom1 = New SqlCommand("ERP_ConPerBus", sqlcon1)
                    'sqldat1 = New SqlDataAdapter(sqlcom1)
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadProveedor1.IdPersona))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadProveedor1.Equivalencia))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadProveedor1.PrimerNombre))
                    'sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaPorFiltro
                    sqldat1 = New SqlDataAdapter("ERP_ConProvBas", sqlcon1)
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaBusqueda 'Se usa para el wuc de proveedor 
                    sqldat1 = New SqlDataAdapter("ERP_ConBasProVWuc", sqlcon1)
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaProveedorIdPro
                    sqlcom1 = New SqlCommand("ERP_ConProvProdPrec", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProveedor1.IdProducto))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor1.IdProveedor))
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
            End Select
            EntidadProveedor1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProveedor1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProveedor1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadProveedor = EntidadProveedor1
        End Try
    End Sub
    Public Sub ConsultarProveedor(ByRef EntidadPersona As Entidad.EntidadBase)
        Dim EntidadProveedor1 = New Entidad.Proveedor
        EntidadProveedor1 = EntidadPersona
        EntidadProveedor1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadProveedor1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica
                    sqlcom1 = New SqlCommand("ERP_ConProPrId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadProveedor1.IdProveedor))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadProveedor1.Equivalencia))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadProveedor1.PrimerNombre))
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
                Case Consulta.ConsultaPorFiltro
                    sqlcom1 = New SqlCommand("ERP_ConProWuc", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadProveedor1.IdProveedor))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadProveedor1.Equivalencia))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVRazonSocial", EntidadProveedor1.RazonSocial))
                    sqldat1.Fill(EntidadProveedor1.TablaConsulta)
            End Select


            EntidadProveedor1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProveedor1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProveedor1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPersona = EntidadProveedor1
        End Try
    End Sub



    Public Sub Obtener(ByRef EntidadProveedor As Entidad.Proveedor) Implements IProveedor.Obtener
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadProveedor.TablaContacto = New DataTable()
        EntidadProveedor.TablaDireccion = New DataTable()
        EntidadProveedor.TablaProducto = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisProvConCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor.IdProveedor))
            sqldat1.Fill(EntidadProveedor.TablaContacto)
            'Tabla DDireccion
            sqlcom1.CommandText = "ERP_LisProvDirCod"
            sqldat1.Fill(EntidadProveedor.TablaDireccion)
            'Tabla Producto
            sqlcom1.CommandText = "ERP_LisProvProdCod"
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntidadProveedor.IdProveedor))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", 0))
            sqldat1.Fill(EntidadProveedor.TablaProducto)
            EntidadProveedor.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto

        Catch ex As Exception
            EntidadProveedor.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadProveedor.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ObtenerTablas(ByRef EntidadPersona As Entidad.Persona)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPersona.TablaIdentificacion = New DataTable()
        EntidadPersona.TablaContacto = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona.IdPersona))
            sqldat1.Fill(EntidadPersona.TablaIdentificacion)
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_LisPerMedCod"
            sqldat1.Fill(EntidadPersona.TablaContacto)
            'Tabla Domicilio
            sqlcom1.CommandText = "ERP_LisPerDomCod"
            sqldat1.Fill(EntidadPersona.TablaDomicilio)
            EntidadPersona.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPersona.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ReportePersona(ByRef EntidadReportePersona As Entidad.ReportePersona)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReportePersona.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisRepPerCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadReportePersona.IdTipoPersona = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaIni", EntidadReportePersona.IdTipoPersona))
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoPersonaFin", EntidadReportePersona.IdTipoPersona))
            End If
            If EntidadReportePersona.IdGenero = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", EntidadReportePersona.IdGenero))
                sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", EntidadReportePersona.IdGenero))
            End If
            If EntidadReportePersona.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", EntidadReportePersona.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", EntidadReportePersona.IdEstado))
            End If
            sqldat1.Fill(EntidadReportePersona.TablaConsulta)
            EntidadReportePersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReportePersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReportePersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub PerfilPersona(ByRef EntidadPerfilPersona As Entidad.Persona)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPerfilPersona.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisPerfPerCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPerfilPersona.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActual", CDate(Now)))
            sqldat1.Fill(EntidadPerfilPersona.TablaConsulta)
            EntidadPerfilPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPerfilPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPerfilPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ObtenerFiltro(ByRef EntidadPersona As Entidad.Persona)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadPersona.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_ConPerFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadPersona.IdPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadPersona.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadPersona.PrimerNombre))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadPersona.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", DateAdd(DateInterval.Day, 1, EntidadPersona.FechaActualizacion)))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoGenero", EntidadPersona.IdTipoGenero))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPersona", EntidadPersona.IdTipoPersona))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPersona.IdEstado))
            sqldat1.Fill(EntidadPersona.TablaConsulta)
            EntidadPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPersona.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPersona.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
