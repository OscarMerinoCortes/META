Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Promocion
    Implements ICatalogo
    Public Overridable Sub Actualizar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Actualizar

    End Sub
    Public Overridable Sub Consultar(ByRef EntidadPromocion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadPromocion1 = New Entidad.Promocion()
        EntidadPromocion1 = EntidadPromocion
        EntidadPromocion1.TablaConsulta = New DataTable()

        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadPromocion1.Tarjeta.Consulta

                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPromocionDescuento", sqlcon1)
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_Con_Promocion", sqlcon1)
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                Case Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_LisPromocionDesCod", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadPromocion1.IdClasificacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadPromocion1.IdSubClasificacion))
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                Case Consulta.ConsultaPorId

                    If EntidadPromocion1.IndicadorConsulta = 3 Then
                        sqlcom1 = New SqlCommand("ERP_Con_DescAlm", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", EntidadPromocion1.IdPromocion))
                        sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                    Else
                        sqlcom1 = New SqlCommand("ERP_Con_PromDet", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", EntidadPromocion1.IdPromocion))
                        sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                    End If


            End Select
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPromocion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPromocion1 = EntidadPromocion1
        End Try
    End Sub
    Public Overridable Sub ObtenerPromocion(ByRef EntidadPromocion As Entidad.EntidadBase)
        Dim EntidadPromocion1 = New Entidad.Promocion()
        EntidadPromocion1 = EntidadPromocion
        EntidadPromocion1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadPromocion1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPromocionDescuento", sqlcon1)
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_Con_Promocion", sqlcon1)
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                Case Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_LisPromocionPro", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadPromocion1.IdClasificacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadPromocion1.IdSubClasificacion))
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_Con_VenConProm", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadPromocion1.IdPromocion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadPromocion1.IdSucursal))
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
            End Select
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPromocion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPromocion1 = EntidadPromocion1
        End Try
    End Sub
        Public Overridable Sub VentaConsultar(ByRef EntidadPromocion As Entidad.EntidadBase)
        Dim EntidadPromocion1 = New Entidad.Promocion()
        EntidadPromocion1 = EntidadPromocion
        EntidadPromocion1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadPromocion1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPromocionDescuento", sqlcon1)
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqldat1 = New SqlDataAdapter("ERP_Con_Promocion", sqlcon1)
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                Case Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_LisPromocionPro", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadPromocion1.IdClasificacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadPromocion1.IdSubClasificacion))
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_Con_VenConProm", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadPromocion1.IdPromocion))
                    sqldat1.Fill(EntidadPromocion1.TablaConsulta)
            End Select
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPromocion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPromocion1 = EntidadPromocion1
        End Try
    End Sub

    Public Overridable Sub InsertarActualizar(ByRef EntidadPromocion As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadPromocion1 As New Entidad.Promocion()
        EntidadPromocion1 = EntidadPromocion
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActPromCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", EntidadPromocion1.IdPromocion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadPromocion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INGracia", EntidadPromocion1.Gracia))
            sqlcom1.Parameters.Add(New SqlParameter("@INTipoGracia", EntidadPromocion1.TipoGracia))
            sqlcom1.Parameters.Add(New SqlParameter("@INExtra", EntidadPromocion1.Extra))
            sqlcom1.Parameters.Add(New SqlParameter("@INTipoExtra", EntidadPromocion1.TipoExtra))
            sqlcom1.Parameters.Add(New SqlParameter("@INDescuento", EntidadPromocion1.Descuento))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTipoDescuento", EntidadPromocion1.TipoDescuento))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadPromocion1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadPromocion1.FechaInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadPromocion1.FechaFin))
            sqlcom1.Parameters.Add(New SqlParameter("@TipoPromocion", EntidadPromocion1.TipoPromocion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPromocion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadPromocion1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadPromocion1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPromocion1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPromocion1.FechaActualizacion))

            If EntidadPromocion1.IdPromocion = 0 Then
                sqlcom1.Parameters(EntidadPromocion1.IdPromocion).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            If EntidadPromocion1.IdPromocion = 0 Then
                EntidadPromocion1.IdPromocion = sqlcom1.Parameters(EntidadPromocion1.IdPromocion).Value
            End If
            'EntidadPromocion1.IdPromocion = IIf(EntidadPromocion1.IdPromocion = 0, sqlcom1.Parameters(EntidadPromocion1.IdPromocion).Value, EntidadPromocion1.IdPromocion)
            For Each MiDataRow As DataRow In EntidadPromocion1.TablaPromocionDetalle.Rows
                sqlcom1.CommandText = "ERP_InsActPromDetCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDetalle", CInt(MiDataRow("IdPromocionDetalle"))))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", CInt(EntidadPromocion1.IdPromocion)))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                sqlcom1.Parameters.Add(New SqlParameter("@INPrecioDescuento", CInt(MiDataRow("Descuento"))))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(IIf(MiDataRow("Estado") = "ACTIVO", 1, 2))))
                If MiDataRow("IdPromocionDetalle") = 0 Then
                    sqlcom1.Parameters("@INIdPromocionDetalle").Direction = ParameterDirection.InputOutput
                End If
                sqlcom1.ExecuteNonQuery()
            Next
            If EntidadPromocion1.TipoPromocion = 0 Then
                For Each MiDataRow As DataRow In EntidadPromocion1.TablaPromocionDetalleObsequio.Rows
                    sqlcom1.CommandText = "ERP_InsActPromDetObsCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDetalle", CInt(MiDataRow("IdPromocionDetalle"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", CInt(EntidadPromocion1.IdPromocion)))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", CInt(MiDataRow("IdProducto"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INPrecioBase", CInt(MiDataRow("PrecioBase"))))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", CInt(IIf(MiDataRow("Estado") = "ACTIVO", 1, 2))))
                    If MiDataRow("IdPromocionDetalle") = 0 Then
                        sqlcom1.Parameters("@INIdPromocionDetalle").Direction = ParameterDirection.InputOutput
                    End If
                    sqlcom1.ExecuteNonQuery()
                Next
            End If
            If EntidadPromocion1.IndicadorEstado = 1 Then
                For Each MiDataRow As DataRow In EntidadPromocion1.TablaSucursal.Rows
                    sqlcom1.CommandText = "ERP_InsActDescAlmCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionSucursal", 0))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", CInt(EntidadPromocion1.IdPromocion)))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                    sqlcom1.ExecuteNonQuery()
                Next
            Else
                sqlcom1 = New SqlCommand("ERP_Del_DescAlmCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", EntidadPromocion1.IdPromocion))
                sqlcom1.ExecuteNonQuery()

                For Each MiDataRow As DataRow In EntidadPromocion1.TablaSucursal.Rows
                    sqlcom1.CommandText = "ERP_InsActDescAlmCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionSucursal", 0))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", CInt(EntidadPromocion1.IdPromocion)))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", MiDataRow("IdSucursal")))
                    sqlcom1.ExecuteNonQuery()
                Next
            End If



            EntidadPromocion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPromocion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPromocion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPromocion = EntidadPromocion1
        End Try
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class