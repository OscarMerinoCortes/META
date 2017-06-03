Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class OrdenCompra
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntIdadOrdenDetalle1 As New Entidad.OrdenCompra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try

            If EntIdadOrdenDetalle1.Cancelar = 1 Then
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ActOrdCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", EntIdadOrdenDetalle1.IdOrden))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPrioridad", EntIdadOrdenDetalle1.IdTipoPrioridad))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", EntIdadOrdenDetalle1.IdTipoSolicitudEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntIdadOrdenDetalle1.IdCliente))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntIdadOrdenDetalle1.Observacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntIdadOrdenDetalle1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntIdadOrdenDetalle1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntIdadOrdenDetalle1.FechaActualizacion))
                sqlcom1.ExecuteNonQuery()
                'Cancelar Detalle Orden 
                For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
                    CancelarOrdenDetalle(sqlcom1, MiDataRow, EntIdadOrdenDetalle1)
                Next
            Else
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ActOrdCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", EntIdadOrdenDetalle1.IdOrden))
                AgragarParametrosOrdenCompra(sqlcom1, EntIdadOrdenDetalle1)
                sqlcom1.ExecuteNonQuery()

                '========================================================== Orden Detalle =====================================================
                For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
                    InsertarActualizarOrdenDetalle(sqlcom1, MiDataRow, EntIdadOrdenDetalle1)
                Next
                '========================================================== Solicitud Detalle =====================================================
                For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaSolicitudDetalle.Rows
                    InsertarActualizarSolicitudDetalle(sqlcom1, MiDataRow)
                Next
            End If

            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto

        Catch ex As Exception
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntIdadOrdenDetalle = EntIdadOrdenDetalle1
        End Try
    End Sub
    Private Sub AgragarParametrosOrdenCompra(ByRef sqlcom1 As SqlCommand, ByVal EntIdadOrdenDetalle1 As Entidad.OrdenCompra)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPriorIdad", EntIdadOrdenDetalle1.IdTipoPrioridad))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", EntIdadOrdenDetalle1.IdTipoSolicitudEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntIdadOrdenDetalle1.IdCliente))
        sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntIdadOrdenDetalle1.Observacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntIdadOrdenDetalle1.IdEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntIdadOrdenDetalle1.idUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntIdadOrdenDetalle1.FechaActualizacion))
    End Sub
    Private Sub InsertarActualizarOrdenDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal EntIdadOrdenDetalle1 As Entidad.OrdenCompra)
        If miDataRow("IdActualizar") = 1 Then
            sqlcom1.CommandText = "ERP_InsOrdDetCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdOrdenDetalle", miDataRow("IdOrdenDetalle")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", miDataRow("IdUsuarioCreacion")))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(miDataRow("FechaCreacion"))))
            AgregarParametrosOrdenDetalle(sqlcom1, miDataRow, EntIdadOrdenDetalle1)
            sqlcom1.ExecuteNonQuery()
        End If
    End Sub
    Private Sub CancelarOrdenDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal EntIdadOrdenDetalle1 As Entidad.OrdenCompra)

        sqlcom1.CommandText = "ERP_CanOrdDetCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdOrdenDetalle", miDataRow("IdOrdenDetalle")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", miDataRow("IdOrden")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", miDataRow("IdSolicitudDetalle")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntIdadOrdenDetalle1.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntIdadOrdenDetalle1.FechaActualizacion))
        sqlcom1.ExecuteNonQuery()
    End Sub
    Private Sub AgregarParametrosOrdenDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal EntIdadOrdenDetalle1 As Entidad.OrdenCompra)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", EntIdadOrdenDetalle1.IdOrden))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", miDataRow("IdSolicitudDetalle")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVIdProducto", miDataRow("IdProducto")))
        sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUnitario", miDataRow("PrecioUnitario")))
        sqlcom1.Parameters.Add(New SqlParameter("@INPorcentajeIva", miDataRow("PorcentajeIva")))
        sqlcom1.Parameters.Add(New SqlParameter("@INSubtotal", miDataRow("Subtotal")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIva", miDataRow("Iva")))
        sqlcom1.Parameters.Add(New SqlParameter("@INTotal", miDataRow("Total")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPriorIdad", EntIdadOrdenDetalle1.IdTipoPrioridad))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", miDataRow("IdTipoSolicitudEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", miDataRow("Descripcion")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", miDataRow("IdSucursal")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", miDataRow("IdAlmacen")))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantIdad", miDataRow("CantIdad")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUnIdad", miDataRow("IdUnIdad")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("IdUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("IdEstado")))
    End Sub
    Private Sub InsertarActualizarSolicitudDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow)
        sqlcom1.CommandText = "ERP_ActSolDetOrdCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", miDataRow("IdSolicitudDetalle")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", miDataRow("IdTipoSolicitudEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("IdUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
        sqlcom1.ExecuteNonQuery()
    End Sub
    Public Sub ActualizarOrdenDetalle(ByRef EntidadOrdenCompra As Entidad.EntidadBase)
        Dim EntidadOrdenCompra1 As New Entidad.OrdenCompra()
        EntidadOrdenCompra1 = EntidadOrdenCompra
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActOrdDetAutCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdOrdenDetalle", EntidadOrdenCompra1.IdOrden))
            sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", EntidadOrdenCompra1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoOrdenEstado", EntidadOrdenCompra1.IdTipoSolicitudEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadOrdenCompra1.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadOrdenCompra1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadOrdenCompra1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadOrdenCompra1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadOrdenCompra1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadOrdenCompra1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadOrdenCompra = EntidadOrdenCompra1
        End Try
    End Sub
    Public Sub Consultar(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntIdadOrdenDetalle1 = New Entidad.OrdenCompra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        EntIdadOrdenDetalle1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntIdadOrdenDetalle1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConOrdDet", sqlcon1)
                    sqldat1.Fill(EntIdadOrdenDetalle1.TablaConsulta)
                Case Consulta.Ninguno
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConOrdNin", sqlcon1)
                    sqldat1.Fill(EntIdadOrdenDetalle1.TablaConsulta)
                Case Else
            End Select
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntIdadOrdenDetalle = EntIdadOrdenDetalle1
        End Try
    End Sub

    Public Sub ConsultarFiltro(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_ObtOrdComFil")
    End Sub


    Private Sub ObtenerSol(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra, sp As String)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            EntidadProcesoCompra.TablaConsulta = New DataTable()
            sqlcon1.Open()
            sqlcom1 = New SqlCommand(sp, sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadProcesoCompra.IdProceso = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoIni", EntidadProcesoCompra.IdProceso))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProcesoFin", EntidadProcesoCompra.IdProceso))
            End If
            If EntidadProcesoCompra.IdClasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdProveedorIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProveedorFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdProveedorIni", EntidadProcesoCompra.IdClasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IdProveedorFin", EntidadProcesoCompra.IdClasificacion))
            End If
            If EntidadProcesoCompra.IdTipoPrioridad = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadIni", EntidadProcesoCompra.IdTipoPrioridad))
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoPrioridadFin", EntidadProcesoCompra.IdTipoPrioridad))
            End If

            If EntidadProcesoCompra.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoIni", EntidadProcesoCompra.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@IdEstadoFin", EntidadProcesoCompra.IdEstado))
            End If

            If EntidadProcesoCompra.IdSolicitudEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoIni", EntidadProcesoCompra.IdSolicitudEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@IdSolicitudEstadoFin", EntidadProcesoCompra.IdSolicitudEstado))
            End If

            If EntidadProcesoCompra.FechaInicio = "01/01/2016" Then
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio1", EntidadProcesoCompra.FechaInicio))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin1", 1000000))
            End If

            If EntidadProcesoCompra.FechaFin = "01/12/2016" Then
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@FechaInicio2", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@FechaFin2", EntidadProcesoCompra.FechaFin.AddDays(1)))
            End If
            sqldat1.Fill(EntidadProcesoCompra.TablaConsulta)
            EntidadProcesoCompra.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProcesoCompra.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProcesoCompra.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub Insertar(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntIdadOrdenDetalle1 As New Entidad.OrdenCompra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsOrdCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", 0))
            AgragarParametrosOrdenCompra(sqlcom1, EntIdadOrdenDetalle1)
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntIdadOrdenDetalle1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntIdadOrdenDetalle1.FechaCreacion))
            sqlcom1.Parameters(EntIdadOrdenDetalle1.IdOrden).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntIdadOrdenDetalle1.IdOrden = sqlcom1.Parameters(EntIdadOrdenDetalle1.IdOrden).Value

            '========================================================== Orden Detalle =====================================================
            For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
                InsertarActualizarOrdenDetalle(sqlcom1, MiDataRow, EntIdadOrdenDetalle1)
            Next
            '========================================================== Solicitud Detalle =====================================================
            For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaSolicitudDetalle.Rows
                InsertarActualizarSolicitudDetalle(sqlcom1, MiDataRow)
            Next
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntIdadOrdenDetalle = EntIdadOrdenDetalle1
        End Try
    End Sub

    Public Sub Obtener(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntIdadOrdenDetalle1 As New Entidad.OrdenCompra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntIdadOrdenDetalle1.TablaOrdenDetalle = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtOrdDetCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", EntIdadOrdenDetalle1.IdOrden))
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_ObtOrdDetCod"
            sqldat1.Fill(EntIdadOrdenDetalle1.TablaOrdenDetalle)

            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ObtenerProveedor(ByRef EntIdadOrdenCompra As Entidad.OrdenCompra)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntIdadOrdenCompra.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtOrdProvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCliente", EntIdadOrdenCompra.IdCliente))
            sqlcom1.CommandText = "ERP_ObtOrdProvCod"
            sqldat1.Fill(EntIdadOrdenCompra.TablaConsulta)
            EntIdadOrdenCompra.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadOrdenCompra.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenCompra.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Public Sub ObtenerTablas(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase)
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntIdadOrdenDetalle.TablaIdentificacion = New DataTable()
        'EntIdadOrdenDetalle.TablaContacto = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    'tabla Identificacion
        '    sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdOrden", EntIdadOrdenDetalle.IdOrden))
        '    sqldat1.Fill(EntIdadOrdenDetalle.TablaIdentificacion)
        '    'Tabla Contacto
        '    sqlcom1.CommandText = "ERP_LisPerMedCod"
        '    sqldat1.Fill(EntIdadOrdenDetalle.TablaContacto)
        '    'Tabla Domicilio
        '    sqlcom1.CommandText = "ERP_LisPerDomCod"
        '    sqldat1.Fill(EntIdadOrdenDetalle.TablaDomicilio)
        '    EntIdadOrdenDetalle.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntIdadOrdenDetalle.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntIdadOrdenDetalle.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub


End Class
