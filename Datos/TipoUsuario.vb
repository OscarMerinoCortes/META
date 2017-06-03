Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoUsuario
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoUsuario As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoUsuario1 As New Entidad.TipoUsuario()
        EntidadTipoUsuario1 = EntidadTipoUsuario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipUsuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadTipoUsuario1.IdTipoUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTipoUsuario", EntidadTipoUsuario1.TipoUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoUsuario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoUsuario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoUsuario1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoUsuario = EntidadTipoUsuario1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoUsuario As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoUsuario1 = New Entidad.TipoUsuario()
        EntidadTipoUsuario1 = EntidadTipoUsuario
        EntidadTipoUsuario1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoUsuario1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipUsuDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoUsuario1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipUsuBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoUsuario1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoUsuario = EntidadTipoUsuario1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoUsuario As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoUsuario1 As New Entidad.TipoUsuario()
        EntidadTipoUsuario1 = EntidadTipoUsuario
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipUsuCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTipoUsuario", EntidadTipoUsuario1.TipoUsuario))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoUsuario1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoUsuario1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoUsuario1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoUsuario1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoUsuario1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoUsuario1.IdTipoUsuario).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoUsuario1.IdTipoUsuario = sqlcom1.Parameters(EntidadTipoUsuario1.IdTipoUsuario).Value
            EntidadTipoUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoUsuario1 = EntidadTipoUsuario
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
