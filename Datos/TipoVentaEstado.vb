Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoVentaEstado
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoVentaEstado As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadTipoVentaEstado1 As New Entidad.TipoVentaEstado()
        'EntidadTipoVentaEstado1 = EntidadTipoVentaEstado
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActTipVentCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVentaEstado", EntidadTipoVentaEstado1.IdTipoVentaEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoVentaEstado1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoVentaEstado1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoVentaEstado1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoVentaEstado1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoVentaEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoVentaEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoVentaEstado1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoVentaEstado = EntidadTipoVentaEstado1
        'End Try
    End Sub


    Public Overridable Sub Consultar(ByRef EntidadTipoVentaEstado As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoVentaEstado1 = New Entidad.TipoVentaEstado()
        EntidadTipoVentaEstado1 = EntidadTipoVentaEstado
        EntidadTipoVentaEstado1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoVentaEstado1.Tarjeta.Consulta
                'Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                '    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipVenDet", sqlcon1)
                '    sqldat1.Fill(EntidadTipoVentaEstado1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipVenEstBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoVentaEstado1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoVentaEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoVentaEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoVentaEstado1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoVentaEstado = EntidadTipoVentaEstado1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoVentaEstado As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadTipoVentaEstado1 As New Entidad.TipoVentaEstado()
        'EntidadTipoVentaEstado1 = EntidadTipoVentaEstado
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsTipVentCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVentaEstado", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoVentaEstado1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoVentaEstado1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoVentaEstado1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoVentaEstado1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoVentaEstado1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoVentaEstado1.FechaActualizacion))
        '    sqlcom1.Parameters(EntidadTipoVentaEstado1.IdTipoVentaEstado).Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadTipoVentaEstado1.IdTipoVentaEstado = sqlcom1.Parameters(EntidadTipoVentaEstado1.IdTipoVentaEstado).Value

        '    EntidadTipoVentaEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadTipoVentaEstado1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadTipoVentaEstado1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadTipoVentaEstado = EntidadTipoVentaEstado1
        'End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
