Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class ReporteExistenciaEmpresa
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadUnidad1 As New Entidad.Unidad(
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

    Public Overridable Sub Consultar(ByRef EntidadUnidad As Entidad.EntidadBase) Implements ICatalogo.Consultar
        'Dim EntidadUnidad1 = New Entidad.Unidad()
        'EntidadUnidad1 = EntidadUnidad
        'EntidadUnidad1.TablaConsulta = New DataTable()
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Try
        '    sqlcon1.Open()
        '    Select Case EntidadUnidad1.Tarjeta.Consulta
        '        Case Consulta.ConsultaDetallada
        '            Dim sqldat1 As New SqlDataAdapter("ERP_ConDetUniCod", sqlcon1)
        '            sqldat1.Fill(EntidadUnidad1.TablaConsulta)
        '        Case Consulta.ConsultaBasica
        '            Dim sqldat1 As New SqlDataAdapter("ERP_ConDetUniCod", sqlcon1)
        '            sqldat1.Fill(EntidadUnidad1.TablaConsulta)
        '    End Select
        '    EntidadUnidad1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadUnidad1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadUnidad1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadUnidad = EntidadUnidad1
        'End Try
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
    Public Sub ReporteExistenciaEmpresa(ByRef EntidadReporteExistenciaEmpresa As Entidad.ReporteExistenciaEmpresa)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteExistenciaEmpresa.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_RepExiEmpCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()

            If EntidadReporteExistenciaEmpresa.Id = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdProductoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProductoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdProductoIni", EntidadReporteExistenciaEmpresa.Id))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProductoFin", EntidadReporteExistenciaEmpresa.Id))
            End If
            If EntidadReporteExistenciaEmpresa.IdSucursal = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalIni", EntidadReporteExistenciaEmpresa.IdSucursal))
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalFin", EntidadReporteExistenciaEmpresa.IdSucursal))
            End If
            If EntidadReporteExistenciaEmpresa.IdAlmacen = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenIni", EntidadReporteExistenciaEmpresa.IdAlmacen))
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenFin", EntidadReporteExistenciaEmpresa.IdAlmacen))
            End If
            If EntidadReporteExistenciaEmpresa.IdClasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionIni", EntidadReporteExistenciaEmpresa.IdClasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionFin", EntidadReporteExistenciaEmpresa.IdClasificacion))
            End If

            If EntidadReporteExistenciaEmpresa.IdSubClasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionIni", EntidadReporteExistenciaEmpresa.IdSubClasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionFin", EntidadReporteExistenciaEmpresa.IdSubClasificacion))
            End If

            If EntidadReporteExistenciaEmpresa.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", EntidadReporteExistenciaEmpresa.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", EntidadReporteExistenciaEmpresa.IdEstado))
            End If

            'If EntidadReporteExistencia.FechaInicio = "01/01/1900" Then
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", 0))
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            'Else
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", EntidadReporteExistencia.FechaInicio))
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            'End If

            'If EntidadReporteExistencia.FechaFin = "01/01/2050" Then
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", 1000000))
            'Else
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
            '    sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", EntidadReporteExistencia.FechaFin))
            'End If            

            sqldat1.Fill(EntidadReporteExistenciaEmpresa.TablaConsulta)
            EntidadReporteExistenciaEmpresa.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteExistenciaEmpresa.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteExistenciaEmpresa.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub



    Public Sub ReporteListadoAlmacen(ByRef EntidadReporteExistenciaEmpresa As Entidad.ReporteExistenciaEmpresa)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteExistenciaEmpresa.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_RepListAlmCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadReporteExistenciaEmpresa.Id))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadReporteExistenciaEmpresa.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadReporteExistenciaEmpresa.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadReporteExistenciaEmpresa.IdAlmacen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadReporteExistenciaEmpresa.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadReporteExistenciaEmpresa.IdSubClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadReporteExistenciaEmpresa.IdEstado))
            sqldat1.Fill(EntidadReporteExistenciaEmpresa.TablaConsulta)
            EntidadReporteExistenciaEmpresa.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteExistenciaEmpresa.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteExistenciaEmpresa.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

End Class
