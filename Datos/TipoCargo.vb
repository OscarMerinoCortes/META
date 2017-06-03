Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoCargo
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoCargo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadTipoCargo1 As New Entidad.TipoCargo()
        'EntidadTipoCargo1 = EntidadTipoCargo
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCargo", EntidadTipoCargo1.IdTipoCargo))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoCargo1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoCargo1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoCargo1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoCargo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoCargo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoCargo = EntidadTipoCargo1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoCargo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoCargo1 = New Entidad.TipoCargo()
        EntidadTipoCargo1 = EntidadTipoCargo
        EntidadTipoCargo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoCargo1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCarBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoCargo1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCarDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoCargo1.TablaConsulta)
            End Select
            EntidadTipoCargo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoCargo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoCargo = EntidadTipoCargo1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoCargo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadTipoCargo1 As New Entidad.TipoCargo()
        'EntidadTipoCargo1 = EntidadTipoCargo
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCargo", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoCargo1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoCargo1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoCargo1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoCargo1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoCargo1.FechaActualizacion))
        '    sqlcom1.Parameters(EntidadTipoCargo1.IdTipoCargo).Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoCargo1.IdTipoCargo = sqlcom1.Parameters(EntidadTipoCargo1.IdTipoCargo).Value
        '    EntidadTipoCargo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoCargo1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoCargo = EntidadTipoCargo1
        'End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
