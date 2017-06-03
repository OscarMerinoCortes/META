Imports System.Threading
Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Credito
    Implements ICatalogo
    Public Overridable Sub Actualizar(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadCredito1 As New Entidad.Credito()
        EntidadCredito1 = EntidadCredito
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActCreCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCredito", EntidadCredito1.IdCredito))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaSolicitante", EntidadCredito1.IdPersonaSolicitante))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaApertura", EntidadCredito1.FechaApertura))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimiento", EntidadCredito1.FechaVencimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntidadCredito1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCredito", EntidadCredito1.IdEstadoCredito))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCredito1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCredito1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCredito1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadCredito1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCredito1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCredito1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCredito = EntidadCredito1
        End Try
    End Sub
    Public Overridable Sub Consultar(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadCredito1 = New Entidad.Credito()
        EntidadCredito1 = EntidadCredito
        EntidadCredito1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadCredito1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_LisPerDet", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCredito", EntidadCredito1.IdEstadoCredito))
                    sqldat1.Fill(EntidadCredito1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisPerBas", sqlcon1)
                    sqldat1.Fill(EntidadCredito1.TablaConsulta)
                    '--------------------------------------------->>>>>>>>En este case realizamos una consulta basica a la tabla Estado Credito
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_LisEstCreBas", sqlcon1)
                    sqldat1.Fill(EntidadCredito1.TablaConsulta)
            End Select
            EntidadCredito1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCredito1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCredito1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCredito = EntidadCredito1
        End Try
    End Sub
    Public Overridable Sub Insertar(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadCredito1 As New Entidad.Credito()
        EntidadCredito1 = EntidadCredito
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsCreCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCredito", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersonaSolicitante", EntidadCredito1.IdPersonaSolicitante))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaApertura", EntidadCredito1.FechaApertura))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimiento", EntidadCredito1.FechaVencimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntidadCredito1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCredito", EntidadCredito1.IdEstadoCredito))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCredito1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCredito1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCredito1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCredito1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCredito1.FechaActualizacion))
            sqlcom1.Parameters(EntidadCredito1.IdCredito).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadCredito1.IdCredito = sqlcom1.Parameters(EntidadCredito1.IdCredito).Value
            EntidadCredito1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCredito1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCredito1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCredito = EntidadCredito1
        End Try
    End Sub
    Public Overridable Sub Obtener(ByRef EntidadCredito As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadCredito1 As New Entidad.Credito()
        EntidadCredito1 = EntidadCredito
        EntidadCredito1.TablaCredito = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            'tabla identificacion
            sqlcom1 = New SqlCommand("ERP_LisPerIdeFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadCredito1.Id = "-1" Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdFin", 100000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@INIdIni", EntidadCredito1.Id))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdFin", EntidadCredito1.Id))
            End If            
                sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", EntidadCredito1.Nombre))            
            If EntidadCredito1.Idestado2 = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCreditoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCreditoFin", 100000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCreditoIni", EntidadCredito1.Idestado2))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstadoCreditoIni", EntidadCredito1.Idestado2))
            End If
            sqldat1.Fill(EntidadCredito1.TablaCredito)
            EntidadCredito1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadCredito1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadCredito1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
