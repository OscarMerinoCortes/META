Imports System.Threading
Imports System.Data.SqlClient
Public Class Arqueo
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadArqueo1 As New Entidad.Arqueo()
        EntidadArqueo1 = EntidadArqueo
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActArqCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueo", EntidadArqueo1.IdArqueo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadArqueo1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadArqueo1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadArqueo1.IdCaja))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadArqueo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadArqueo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadArqueo1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            For Each MiDataRow As DataRow In EntidadArqueo1.TablaArqueo.Rows
                'si se va a actualizar el registro    
                If MiDataRow("IdArqueoDetalle") = 0 Then
                    'sqlcom1.CommandText = "ERP_InsArqDetCod"
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueoDetalle", 0))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueo", EntidadArqueo1.IdArqueo))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IDValor", MiDataRow("Valor")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IDTotal", MiDataRow("Total")))
                    'sqlcom1.Parameters("@INIdArqueoDetalle").Direction = ParameterDirection.InputOutput
                    'sqlcom1.ExecuteNonQuery()
                Else
                    sqlcom1.CommandText = "ERP_ActArqDetCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueoDetalle", MiDataRow("IdArqueoDetalle")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueo", EntidadArqueo1.IdArqueo))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDValor", MiDataRow("Valor")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDTotal", MiDataRow("Total")))
                    sqlcom1.ExecuteNonQuery()
                End If
            Next
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadArqueo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadArqueo = EntidadArqueo1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadArqueo1 = New Entidad.Arqueo()
        EntidadArqueo1 = EntidadArqueo
        EntidadArqueo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadArqueo1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_LisArqDet", sqlcon1)
                    sqldat1.Fill(EntidadArqueo1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_LisArqBas", sqlcon1)
                    sqldat1.Fill(EntidadArqueo1.TablaConsulta)
                Case Else
            End Select
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadArqueo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadArqueo = EntidadArqueo1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadArqueo1 As New Entidad.Arqueo()
        EntidadArqueo1 = EntidadArqueo
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsArqCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueo", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntidadArqueo1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadArqueo1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCaja", EntidadArqueo1.IdCaja))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadArqueo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadArqueo1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadArqueo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadArqueo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadArqueo1.FechaActualizacion))
            sqlcom1.Parameters(EntidadArqueo1.IdArqueo).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadArqueo1.IdArqueo = sqlcom1.Parameters(EntidadArqueo1.IdArqueo).Value
            '==================================     TABLA DETALLE    =============================================
            For Each MiDataRow As DataRow In EntidadArqueo1.TablaArqueo.Rows
                'si se va a actualizar el registro    
                If MiDataRow("IdArqueoDetalle") = 0 Then
                    sqlcom1.CommandText = "ERP_InsArqDetCod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueoDetalle", 0))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueo", EntidadArqueo1.IdArqueo))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDValor", MiDataRow("Valor")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", MiDataRow("Cantidad")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDTotal", MiDataRow("Total")))
                    sqlcom1.Parameters("@INIdArqueoDetalle").Direction = ParameterDirection.InputOutput
                    sqlcom1.ExecuteNonQuery()
                Else
                    'sqlcom1.CommandText = "ERP_ActPerIde"
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@IdPersonaIdentificacion", MiDataRow("IdPersonaIdentificacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@idPersona", EntidadPersona1.IdPersona))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IdTipoIdentificacion", MiDataRow("IdTipoIdentificacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@Numero", MiDataRow("ClaveIdentificacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", MiDataRow("IdEstado")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioCreacion", MiDataRow("idUsuarioCreacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate(MiDataRow("FechaCreacion"))))
                    'sqlcom1.Parameters.Add(New SqlParameter("@IdUsuarioActualizacion", MiDataRow("idUsuarioActualizacion")))
                    'sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate(MiDataRow("FechaActualizacion"))))
                    'sqlcom1.ExecuteNonQuery()
                End If
            Next
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadArqueo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadArqueo = EntidadArqueo1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadArqueo As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim EntidadArqueo1 As New Entidad.Arqueo
        EntidadArqueo1 = EntidadArqueo
        EntidadArqueo1.TablaArqueo = New DataTable()
        Try
            sqlcon1.Open()            
            sqlcom1 = New SqlCommand("ERP_LisArqDetId", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdArqueo", EntidadArqueo1.IdArqueo))
            sqldat1.Fill(EntidadArqueo1.TablaArqueo)
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadArqueo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadArqueo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
