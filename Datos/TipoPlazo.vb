Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoPlazo
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoPlazo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoPlazo1 As New Entidad.TipoPlazo()
        EntidadTipoPlazo1 = EntidadTipoPlazo
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipPlaCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPlazo", EntidadTipoPlazo1.IdTipoPlazo))
            sqlcom1.Parameters.Add(New SqlParameter("@INPlazo", EntidadTipoPlazo1.Plazo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoPlazo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoPlazo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoPlazo1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoPlazo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoPlazo = EntidadTipoPlazo1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoPlazo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoPlazo1 = New Entidad.TipoPlazo()
        EntidadTipoPlazo1 = EntidadTipoPlazo
        EntidadTipoPlazo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoPlazo1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipPlaDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoPlazo1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipPlaBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoPlazo1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoPlazo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoPlazo = EntidadTipoPlazo1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoPlazo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoPlazo1 As New Entidad.TipoPlazo()
        EntidadTipoPlazo1 = EntidadTipoPlazo
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipPlaCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPlazo", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INPlazo", EntidadTipoPlazo1.Plazo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoPlazo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoPlazo1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoPlazo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoPlazo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoPlazo1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoPlazo1.IdTipoPlazo).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoPlazo1.IdTipoPlazo = sqlcom1.Parameters(EntidadTipoPlazo1.IdTipoPlazo).Value
            EntidadTipoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoPlazo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoPlazo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoPlazo = EntidadTipoPlazo1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
