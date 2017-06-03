Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoPrioridad
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoPrioridad As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadTipoPrioridad1 As New Entidad.TipoPrioridad()
        'EntidadTipoPrioridad1 = EntidadTipoPrioridad
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPrioridad", EntidadTipoPrioridad1.IdTipoPrioridad))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoPrioridad1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoPrioridad1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoPrioridad1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoPrioridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoPrioridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoPrioridad1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoPrioridad = EntidadTipoPrioridad1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoPrioridad As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoPrioridad1 = New Entidad.TipoPrioridad()
        EntidadTipoPrioridad1 = EntidadTipoPrioridad
        EntidadTipoPrioridad1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoPrioridad1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConPriBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoPrioridad1.TablaConsulta)
            End Select
            EntidadTipoPrioridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoPrioridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoPrioridad1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoPrioridad = EntidadTipoPrioridad1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoPrioridad As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadTipoPrioridad1 As New Entidad.TipoPrioridad()
        'EntidadTipoPrioridad1 = EntidadTipoPrioridad
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPrioridad", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoPrioridad1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoPrioridad1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoPrioridad1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoPrioridad1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoPrioridad1.FechaActualizacion))
        '    sqlcom1.Parameters(EntidadTipoPrioridad1.IdTipoPrioridad).Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoPrioridad1.IdTipoPrioridad = sqlcom1.Parameters(EntidadTipoPrioridad1.IdTipoPrioridad).Value
        '    EntidadTipoPrioridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoPrioridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoPrioridad1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoPrioridad = EntidadTipoPrioridad1
        'End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
