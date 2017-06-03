Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoSolicitudEstado
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoSolicitudEstado As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadTipoSolicitudEstado1 As New Entidad.TipoSolicitudEstado()
        'EntidadTipoSolicitudEstado1 = EntidadTipoSolicitudEstado
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", EntidadTipoSolicitudEstado1.IdTipoSolicitudEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoSolicitudEstado1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoSolicitudEstado1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoSolicitudEstado1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoSolicitudEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoSolicitudEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoSolicitudEstado1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoSolicitudEstado = EntidadTipoSolicitudEstado1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoSolicitudEstado As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoSolicitudEstado1 = New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado1 = EntidadTipoSolicitudEstado
        EntidadTipoSolicitudEstado1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoSolicitudEstado1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipSolEstBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoSolicitudEstado1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipSolEstNin", sqlcon1)
                    sqldat1.Fill(EntidadTipoSolicitudEstado1.TablaConsulta)
            End Select
            EntidadTipoSolicitudEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoSolicitudEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoSolicitudEstado1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoSolicitudEstado = EntidadTipoSolicitudEstado1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoSolicitudEstado As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadTipoSolicitudEstado1 As New Entidad.TipoSolicitudEstado()
        'EntidadTipoSolicitudEstado1 = EntidadTipoSolicitudEstado
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoSolicitudEstado1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoSolicitudEstado1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoSolicitudEstado1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoSolicitudEstado1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoSolicitudEstado1.FechaActualizacion))
        '    sqlcom1.Parameters(EntidadTipoSolicitudEstado1.IdTipoSolicitudEstado).Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoSolicitudEstado1.IdTipoSolicitudEstado = sqlcom1.Parameters(EntidadTipoSolicitudEstado1.IdTipoSolicitudEstado).Value
        '    EntidadTipoSolicitudEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoSolicitudEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoSolicitudEstado1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoSolicitudEstado = EntidadTipoSolicitudEstado1
        'End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
