Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoDocumento
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoDocumento As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadTipoDocumento1 As New Entidad.TipoDocumento()
        'EntidadTipoDocumento1 = EntidadTipoDocumento
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActTipPlaCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", EntidadTipoDocumento1.IdTipoDocumento))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoDocumento1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDocumento1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDocumento1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoDocumento1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoDocumento1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoDocumento1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoDocumento = EntidadTipoDocumento1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoDocumento As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoDocumento1 = New Entidad.TipoDocumento()
        EntidadTipoDocumento1 = EntidadTipoDocumento
        EntidadTipoDocumento1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoDocumento1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDocBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoDocumento1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDocDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoDocumento1.TablaConsulta)
            End Select
            EntidadTipoDocumento1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDocumento1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoDocumento1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDocumento = EntidadTipoDocumento1
        End Try
    End Sub

    Public Overridable Sub InsertarActualizar(ByRef EntidadTipoDocumento As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoDocumento1 As New Entidad.TipoDocumento()
        EntidadTipoDocumento1 = EntidadTipoDocumento
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActTipDocCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", EntidadTipoDocumento1.IdTipoDocumento))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoDocumento1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoDocumento1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoDocumento1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoDocumento1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDocumento1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDocumento1.FechaActualizacion))
            If EntidadTipoDocumento1.IdTipoDocumento = 0 Then
                sqlcom1.Parameters(EntidadTipoDocumento1.IdTipoDocumento).Direction = ParameterDirection.InputOutput
            End If
            sqlcom1.ExecuteNonQuery()
        Catch ex As Exception
            EntidadTipoDocumento1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoDocumento1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDocumento = EntidadTipoDocumento1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
