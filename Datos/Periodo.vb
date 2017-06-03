Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class Periodo
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadPeriodo1 As New Entidad.Periodo()
        EntidadPeriodo1 = EntidadPeriodo
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActPeriodoCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPeriodo", EntidadPeriodo1.IdPeriodo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadPeriodo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", EntidadPeriodo1.Cantidad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEquivalenciaPeriodo", EntidadPeriodo1.IdTipoEquivalenciaPeriodo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPeriodo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPeriodo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPeriodo1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadPeriodo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPeriodo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPeriodo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPeriodo = EntidadPeriodo1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadPeriodo1 = New Entidad.Periodo()
        EntidadPeriodo1 = EntidadPeriodo
        EntidadPeriodo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadPeriodo1.Tarjeta.Consulta
                Case Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConPerDet", sqlcon1)
                    sqldat1.Fill(EntidadPeriodo1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConPerBas", sqlcon1)
                    sqldat1.Fill(EntidadPeriodo1.TablaConsulta)
            End Select
            EntidadPeriodo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPeriodo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPeriodo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPeriodo = EntidadPeriodo1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadPeriodo1 As New Entidad.Periodo()
        EntidadPeriodo1 = EntidadPeriodo
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsPeriodoCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPeriodo", EntidadPeriodo1.IdPeriodo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadPeriodo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", EntidadPeriodo1.Cantidad))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEquivalenciaPeriodo", EntidadPeriodo1.IdTipoEquivalenciaPeriodo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadPeriodo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadPeriodo1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadPeriodo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadPeriodo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadPeriodo1.FechaActualizacion))
            sqlcom1.Parameters("@INIdPeriodo").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadPeriodo1.IdPeriodo = sqlcom1.Parameters("@INIdPeriodo").Value
            EntidadPeriodo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadPeriodo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadPeriodo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadPeriodo = EntidadPeriodo1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPeriodo As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
