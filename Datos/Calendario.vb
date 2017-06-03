Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class Calendario
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadCalendario1 As New Entidad.Calendario()
        EntidadCalendario1 = EntidadCalendario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActUniCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCalendario", EntidadCalendario1.IdCalendario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadCalendario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCalendario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCalendario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCalendario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadCalendario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCalendario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCalendario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCalendario = EntidadCalendario1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadCalendario1 = New Entidad.Calendario()
        EntidadCalendario1 = EntidadCalendario
        EntidadCalendario1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadCalendario1.Tarjeta.Consulta
                Case Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCalDet", sqlcon1)
                    sqldat1.Fill(EntidadCalendario1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCalBas", sqlcon1)
                    sqldat1.Fill(EntidadCalendario1.TablaConsulta)
            End Select
            EntidadCalendario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCalendario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCalendario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCalendario = EntidadCalendario1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadCalendario1 As New Entidad.Calendario()
        EntidadCalendario1 = EntidadCalendario
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsUniCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCalendario", EntidadCalendario1.IdCalendario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadCalendario1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCalendario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCalendario1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCalendario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCalendario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCalendario1.FechaActualizacion))
            sqlcom1.Parameters("@INIdCalendario").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadCalendario1.IdCalendario = sqlcom1.Parameters("@INIdCalendario").Value
            EntidadCalendario1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCalendario1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCalendario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCalendario = EntidadCalendario1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadCalendario As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
