Imports System.Threading
Imports System.Data.SqlClient
Public Class Devolucion
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Actualizar

    End Sub
    Public Overridable Sub Consultar(ByRef EntidadDevolucion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadDevolucion1 = New Entidad.Devolucion()
        EntidadDevolucion1 = EntidadDevolucion
        EntidadDevolucion1.TablaDevolucion = New DataTable()
        EntidadDevolucion1.TablaDevolucionDetalle = New DataTable()
        EntidadDevolucion1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadDevolucion1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaCompra
                    sqlcom1 = New SqlCommand("ERP_LisComDevDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", EntidadDevolucion1.Folio))                    
                    sqldat1.Fill(EntidadDevolucion1.TablaDevolucion)                                      
                    If EntidadDevolucion1.TablaDevolucion.Rows.Count = 0 Then
                        Exit Sub
                    End If
                    EntidadDevolucion1.IdOperacion = EntidadDevolucion1.TablaDevolucion.Rows(0).Item("Id")
                    sqlcom1 = New SqlCommand("ERP_LisComDevDetId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntidadDevolucion1.IdOperacion))
                    sqldat1.Fill(EntidadDevolucion1.TablaDevolucionDetalle)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaVenta
                    sqlcom1 = New SqlCommand("ERP_LisVenDevDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", EntidadDevolucion1.Folio))                   
                    sqldat1.Fill(EntidadDevolucion1.TablaDevolucion)                                 
                    If EntidadDevolucion1.TablaDevolucion.Rows.Count = 0 Then
                        Exit Sub
                    End If
                    EntidadDevolucion1.IdOperacion = EntidadDevolucion1.TablaDevolucion.Rows(0).Item("Id")
                    sqlcom1 = New SqlCommand("ERP_LisVenDevDetId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadDevolucion1.IdOperacion))
                    sqldat1.Fill(EntidadDevolucion1.TablaDevolucionDetalle)

                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_LisDevDet", sqlcon1)
                    sqldat1.Fill(EntidadDevolucion1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_LisDevDetId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucion", EntidadDevolucion1.IdDevolucion))
                    sqldat1.Fill(EntidadDevolucion1.TablaConsulta)
                Case Else
            End Select
            EntidadDevolucion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadDevolucion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadDevolucion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadDevolucion = EntidadDevolucion1
        End Try
    End Sub

    Public Overridable Sub Upsert(ByRef EntidadDevolucion As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadDevolucion1 As New Entidad.Devolucion()
        EntidadDevolucion1 = EntidadDevolucion
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActDevEnc", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucion", EntidadDevolucion1.IdDevolucion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDevolucion", EntidadDevolucion1.IdTipoDevolucion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucionOperacion", EntidadDevolucion1.IdDevolucionOperacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntidadDevolucion1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCargoAbono", EntidadDevolucion1.IdBandera))
            sqlcom1.Parameters.Add(New SqlParameter("@INConcepto", EntidadDevolucion1.Concepto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadDevolucion1.IdAlmacen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadDevolucion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadDevolucion1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadDevolucion1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadDevolucion1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadDevolucion1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadDevolucion1.FechaActualizacion))
            If EntidadDevolucion1.IdDevolucion = 0 Then
                sqlcom1.Parameters(EntidadDevolucion1.IdDevolucion).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            EntidadDevolucion1.IdDevolucion = sqlcom1.Parameters("@INIdDevolucion").Value
            For Each MiDataRow As DataRow In EntidadDevolucion1.TablaDevolucionDetalle.Rows
                sqlcom1.CommandText = "ERP_InsActDevDet"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucionDetalle", MiDataRow("IdDevolucionDetalle")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucion", EntidadDevolucion1.IdDevolucion))
                sqlcom1.Parameters.Add(New SqlParameter("@INId", MiDataRow("Id")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", MiDataRow("Folio")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                sqlcom1.Parameters.Add(New SqlParameter("@INPrecio", MiDataRow("Precio")))
                sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                sqlcom1.Parameters.Add(New SqlParameter("@INTotal", MiDataRow("Total")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", MiDataRow("Observacion")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadDevolucion1.IdEstado))
                sqlcom1.ExecuteNonQuery()
            Next
            EntidadDevolucion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadDevolucion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadDevolucion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadDevolucion = EntidadDevolucion1
        End Try
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadDevolucion As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Overridable Sub Aplicar(ByRef EntidadDevolucion As Entidad.EntidadBase)
        Dim EntidadDevolucion1 As New Entidad.Devolucion()
        EntidadDevolucion1 = EntidadDevolucion
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            For Each MiDataRow As DataRow In EntidadDevolucion1.TablaDevolucionDetalle.Rows
                sqlcom1 = New SqlCommand("ERP_AplDevDetInv", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucion", MiDataRow("IdDevolucion")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdDevolucionDetalle", MiDataRow("IdDevolucionDetalle")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", MiDataRow("IdProducto")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadDevolucion1.IdAlmacen))
                sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadDevolucion1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadDevolucion1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadDevolucion1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadDevolucion1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadDevolucion1.FechaActualizacion))
                sqlcom1.ExecuteNonQuery()
            Next
            EntidadDevolucion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadDevolucion1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadDevolucion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadDevolucion = EntidadDevolucion1
        End Try
    End Sub
End Class
