Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class ReporteVenta
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadUnidad1 As New Entidad.Unidad()
        'EntidadUnidad1 = EntidadUnidad
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActUniCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUnidad", EntidadUnidad1.IdUnidad))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadUnidad1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadUnidad1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUnidad1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUnidad1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadUnidad1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadUnidad1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadUnidad1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadUnidad = EntidadUnidad1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadReporteVenta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadReporteVenta1 = New Entidad.ReporteVenta()
        EntidadReporteVenta1 = EntidadReporteVenta
        EntidadReporteVenta1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadReporteVenta1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConVenEstBas", sqlcon1)
                    sqldat1.Fill(EntidadReporteVenta1.TablaConsulta)
                    'Case Consulta.ConsultaBasica
                    '    Dim sqldat1 As New SqlDataAdapter("ERP_ConSucBas", sqlcon1)
                    '    sqldat1.Fill(EntidadSucursal1.TablaConsulta)
            End Select
            EntidadReporteVenta1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadReporteVenta1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadReporteVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadReporteVenta = EntidadReporteVenta1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadUnidad1 As New Entidad.Unidad()
        'EntidadUnidad1 = EntidadUnidad
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsUniCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUnidad", EntidadUnidad1.IdUnidad))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadUnidad1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadUnidad1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadUnidad1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadUnidad1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUnidad1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUnidad1.FechaActualizacion))
        '    sqlcom1.Parameters("@INIdUnidad").Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadUnidad1.IdUnidad = sqlcom1.Parameters("@INIdUnidad").Value
        '    EntidadUnidad1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadUnidad1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadUnidad1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadUnidad = EntidadUnidad1
        'End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadReporteVenta As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
    Public Sub ReporteVenta(ByRef EntidadReporteVenta As Entidad.ReporteVenta)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteVenta.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisRepVenCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadReporteVenta.IdSucursal = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalIni", EntidadReporteVenta.IdSucursal))
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalFin", EntidadReporteVenta.IdSucursal))
            End If
            'If EntidadReporteVenta.IdCaja = -1 Then
            '    sqlcom1.Parameters.Add(New SqlParameter("@IdCajaIni", 0))
            '    sqlcom1.Parameters.Add(New SqlParameter("@IdCajaFin", 1000000))
            'Else
            '    sqlcom1.Parameters.Add(New SqlParameter("@IdCajaIni", EntidadReporteVenta.IdCaja))
            '    sqlcom1.Parameters.Add(New SqlParameter("@IdCajaFin", EntidadReporteVenta.IdCaja))
            'End If
            If EntidadReporteVenta.IdUsuario = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioIni", EntidadReporteVenta.IdUsuario))
                sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioFin", EntidadReporteVenta.IdUsuario))
            End If

            If EntidadReporteVenta.IdTipoVenta = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaIni", EntidadReporteVenta.IdTipoVenta))
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaFin", EntidadReporteVenta.IdTipoVenta))
            End If

            If EntidadReporteVenta.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idVentaEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idVentaEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idVentaEstadoIni", EntidadReporteVenta.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@idVentaEstadoFin", EntidadReporteVenta.IdEstado))
            End If

            If EntidadReporteVenta.FechaInicio = "01/01/2016" Then
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", EntidadReporteVenta.FechaInicio))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            End If

            If EntidadReporteVenta.FechaFin = "01/12/2016" Then
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", EntidadReporteVenta.FechaFin))
            End If

            sqldat1.Fill(EntidadReporteVenta.TablaConsulta)
            EntidadReporteVenta.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteVenta.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteVenta.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

End Class
