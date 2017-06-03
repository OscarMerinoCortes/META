Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoMedio
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoMedio As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoMedio1 As New Entidad.TipoMedio()
        EntidadTipoMedio1 = EntidadTipoMedio
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipMedCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMedio", EntidadTipoMedio1.IdTipoMedio))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoMedio1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoMedio1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoMedio1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoMedio1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoMedio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoMedio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoMedio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoMedio = EntidadTipoMedio1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoMedio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoMedio1 = New Entidad.TipoMedio()
        EntidadTipoMedio1 = EntidadTipoMedio
        EntidadTipoMedio1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoMedio1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipMedDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoMedio1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipMedBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoMedio1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoMedio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoMedio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoMedio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoMedio = EntidadTipoMedio1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoMedio As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoMedio1 As New Entidad.TipoMedio()
        EntidadTipoMedio1 = EntidadTipoMedio
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipMedCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMedio", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoMedio1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoMedio1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoMedio1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoMedio1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoMedio1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoMedio1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoMedio1.IdTipoMedio).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoMedio1.IdTipoMedio = sqlcom1.Parameters(EntidadTipoMedio1.IdTipoMedio).Value
            EntidadTipoMedio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoMedio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoMedio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoMedio = EntidadTipoMedio1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
