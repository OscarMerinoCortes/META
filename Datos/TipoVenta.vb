Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoVenta
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoVenta As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoVenta1 As New Entidad.TipoVenta()
        EntidadTipoVenta1 = EntidadTipoVenta
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipVentCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVenta", EntidadTipoVenta1.IdTipoVenta))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoVenta1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoVenta1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoVenta1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoVenta1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoVenta = EntidadTipoVenta1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoVenta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoVenta1 = New Entidad.TipoVenta()
        EntidadTipoVenta1 = EntidadTipoVenta
        EntidadTipoVenta1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoVenta1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipVenDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoVenta1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipVenBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoVenta1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoVenta = EntidadTipoVenta1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoVenta As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoVenta1 As New Entidad.TipoVenta()
        EntidadTipoVenta1 = EntidadTipoVenta
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipVentCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVenta", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoVenta1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoVenta1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoVenta1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoVenta1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoVenta1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoVenta1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoVenta1.IdTipoVenta).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoVenta1.IdTipoVenta = sqlcom1.Parameters(EntidadTipoVenta1.IdTipoVenta).Value

            EntidadTipoVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoVenta = EntidadTipoVenta1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
