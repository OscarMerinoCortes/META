Imports System.Threading
Imports System.Data.SqlClient
Public Class Garantia
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Actualizar
     
    End Sub
    Public Overridable Sub Consultar(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadGarantia1 = New Entidad.Garantia()
        EntidadGarantia1 = EntidadGarantia
        EntidadGarantia1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadGarantia1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    sqlcom1 = New SqlCommand("ERP_LisVenGarDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdCliente", EntidadGarantia1.IdCliente))
                    sqldat1.Fill(EntidadGarantia1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
                    sqlcom1 = New SqlCommand("ERP_LisVenDetGar", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadGarantia1.IdVenta))
                    sqldat1.Fill(EntidadGarantia1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_ConGarDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqldat1.Fill(EntidadGarantia1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConDetPorIdGar", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdGarantia", EntidadGarantia1.IdGarantia))
                    sqldat1.Fill(EntidadGarantia1.TablaConsulta)
                Case Else
            End Select
            EntidadGarantia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadGarantia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadGarantia1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadGarantia = EntidadGarantia1
        End Try
    End Sub

    Public Overridable Sub Upsert(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadGarantia1 As New Entidad.Garantia()
        EntidadGarantia1 = EntidadGarantia
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActGarEnc", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdGarantia", EntidadGarantia1.IdGarantia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadGarantia1.IdVenta))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCliente", EntidadGarantia1.IdCliente))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadGarantia1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", EntidadGarantia1.Telefono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadGarantia1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadGarantia1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadGarantia1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadGarantia1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadGarantia1.FechaActualizacion))
            If EntidadGarantia1.IdGarantia = 0 Then
                sqlcom1.Parameters(EntidadGarantia1.IdGarantia).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
            EntidadGarantia1.IdGarantia = sqlcom1.Parameters("@INIdGarantia").Value
            For Each MiDataRow As DataRow In EntidadGarantia1.TablaGarantiaDetalle.Rows
                sqlcom1.CommandText = "ERP_InsActGarDet"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdGarantiaDetalle", EntidadGarantia1.IdGarantiaDetalle))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdGarantia", EntidadGarantia1.IdGarantia))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadGarantia1.IdProducto))
                sqlcom1.Parameters.Add(New SqlParameter("@IVFalla", EntidadGarantia1.Falla))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadGarantia1.Observacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVAccesorios", EntidadGarantia1.Accesorios))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaEstimada", EntidadGarantia1.FechaEstimada))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadGarantia1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadGarantia1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadGarantia1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadGarantia1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadGarantia1.FechaActualizacion))
                'If MiDataRow("IdGarantiaDetalle") = 0 Then
                '    sqlcom1.Parameters("@INIdGarantiaDetalle").Direction = ParameterDirection.InputOutput
                'End If
                sqlcom1.ExecuteNonQuery()
            Next
            EntidadGarantia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadGarantia1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadGarantia1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadGarantia = EntidadGarantia1
        End Try
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadGarantia As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
