Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class ReporteExistenciaAlmacen
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
    Public Sub ReporteExistenciaAlmacen(ByRef EntidadReporteExistencia As Entidad.ReporteExistenciaAlmacen)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteExistencia.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_RepExiProCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadReporteExistencia.Id))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadReporteExistencia.Producto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadReporteExistencia.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadReporteExistencia.IdAlmacen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadReporteExistencia.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadReporteExistencia.IdSubClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadReporteExistencia.IdEstado))
            sqldat1.Fill(EntidadReporteExistencia.TablaConsulta)
            EntidadReporteExistencia.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteExistencia.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteExistencia.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ReporteExistenciaSucursal(ByRef EntidadReporteExistencia As Entidad.ReporteExistenciaAlmacen)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteExistencia.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_RepExiProSucCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadReporteExistencia.Id))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadReporteExistencia.Producto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadReporteExistencia.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSubclasificacion", EntidadReporteExistencia.IdSubClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadReporteExistencia.IdEstado))
            sqldat1.Fill(EntidadReporteExistencia.TablaConsulta)
            EntidadReporteExistencia.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteExistencia.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteExistencia.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ExistenciaSucursalEstadistica(ByRef EntidadReporteExistencia As Entidad.ReporteExistenciaAlmacen)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteExistencia.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ExiProSucEst", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoCorto", EntidadReporteExistencia.IdProductoCorto))
            sqldat1.Fill(EntidadReporteExistencia.TablaConsulta)
            EntidadReporteExistencia.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteExistencia.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteExistencia.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
