Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class ReporteMovimientoInventario
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
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUnidad1.FechaActualizacion)
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
    Public Sub ReporteMovimientoInventario(ByRef EntidadReporteMovimientoInventario As Entidad.ReporteMovimientoInventario)
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntidadReporteMovimientoInventario.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_RepMovInvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@IdMovimiento", EntidadReporteMovimientoInventario.IdMovimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@IdTipo", EntidadReporteMovimientoInventario.IdTipoMovimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@IdSubTipo", EntidadReporteMovimientoInventario.IdSubTipoMovimiento))
            sqlcom1.Parameters.Add(New SqlParameter("@IdSucursalOrigen", EntidadReporteMovimientoInventario.IdSucursalOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", EntidadReporteMovimientoInventario.IdAlmacenOrigen))
            sqlcom1.Parameters.Add(New SqlParameter("@IdSucursalDestino", EntidadReporteMovimientoInventario.IdSucursalDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", EntidadReporteMovimientoInventario.IdAlmacenDestino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadReporteMovimientoInventario.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntidadReporteMovimientoInventario.FechaInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntidadReporteMovimientoInventario.FechaFin))
            sqldat1.Fill(EntidadReporteMovimientoInventario.TablaConsulta)
            EntidadReporteMovimientoInventario.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReporteMovimientoInventario.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReporteMovimientoInventario.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

End Class
