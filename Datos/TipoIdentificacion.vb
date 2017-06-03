Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoIdentificacion
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadIdentificaciones As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadIdentificaciones1 As New Entidad.TipoIdentificacion()
        EntidadIdentificaciones1 = EntidadIdentificaciones
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActIdeCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIdentificacion", EntidadIdentificaciones1.IdTipoIdentificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadIdentificaciones1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadIdentificaciones1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadIdentificaciones1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadIdentificaciones1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadIdentificaciones1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIdentificaciones1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIdentificaciones1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIdentificaciones = EntidadIdentificaciones1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadIdentificaciones As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadIdentificaciones1 = New Entidad.TipoIdentificacion()
        EntidadIdentificaciones1 = EntidadIdentificaciones
        EntidadIdentificaciones1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadIdentificaciones1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipIdeDet", sqlcon1)
                    sqldat1.Fill(EntidadIdentificaciones1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipIdeBas", sqlcon1)
                    sqldat1.Fill(EntidadIdentificaciones1.TablaConsulta)
                Case Else
            End Select
            EntidadIdentificaciones1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIdentificaciones1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIdentificaciones1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIdentificaciones = EntidadIdentificaciones1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadIdentificaciones As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadIdentificaciones1 As New Entidad.TipoIdentificacion()
        EntidadIdentificaciones1 = EntidadIdentificaciones
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsIdeCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoIdentificacion", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadIdentificaciones1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadIdentificaciones1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadIdentificaciones1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadIdentificaciones1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadIdentificaciones1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadIdentificaciones1.FechaActualizacion))
            sqlcom1.Parameters(EntidadIdentificaciones1.IdTipoIdentificacion).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadIdentificaciones1.IdTipoIdentificacion = sqlcom1.Parameters(EntidadIdentificaciones1.IdTipoIdentificacion).Value
            EntidadIdentificaciones1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadIdentificaciones1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadIdentificaciones1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadIdentificaciones = EntidadIdentificaciones1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadEstadoCivil As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
