Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Compra
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntIdadOrdenDetalle1 As New Entidad.Compra()
        'EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActComCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntIdadOrdenDetalle1.IdCompra))

        '    sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntIdadOrdenDetalle1.Monto))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIVA", EntIdadOrdenDetalle1.IVA))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INSubTotal", EntIdadOrdenDetalle1.SubTotal))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INCargos", EntIdadOrdenDetalle1.Cargo))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INAnticipo", EntIdadOrdenDetalle1.Anticipo))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INTotal", EntIdadOrdenDetalle1.Total))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INTipoCompra", EntIdadOrdenDetalle1.TipoCompra))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INTipoCompraEstado", EntIdadOrdenDetalle1.TipoCompraEstado))

        '    AgragarParametrosCompra(sqlcom1, EntIdadOrdenDetalle1)
        '    sqlcom1.ExecuteNonQuery()

        '    '========================================================== Compra Detalle =====================================================
        '    For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaCompraDetalle.Rows
        '        InsertarActualizarCompraDetalle(sqlcom1, MiDataRow, EntIdadOrdenDetalle1)
        '    Next
        '    '========================================================== Orden Detalle =====================================================
        '    For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
        '        InsertarActualizarOrdenDetalle(sqlcom1, MiDataRow)
        '    Next
        '    '========================================================== Solicitud Detalle =====================================================
        '    For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
        '        InsertarActualizarSolicitudDetalle(sqlcom1, MiDataRow)
        '    Next

        '    EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntIdadOrdenDetalle = EntIdadOrdenDetalle1
        'End Try
    End Sub
    Private Sub AgragarParametrosCompra(ByRef sqlcom1 As SqlCommand, ByVal EntIdadOrdenDetalle1 As Entidad.Compra)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", EntIdadOrdenDetalle1.IdTipoDocumento))
        sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", EntIdadOrdenDetalle1.Folio))
        sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", EntIdadOrdenDetalle1.Serie))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaDocumento", EntIdadOrdenDetalle1.FechaDocumento))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdFormaPago", EntIdadOrdenDetalle1.IdFormaPago))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntIdadOrdenDetalle1.IdPersona))
        sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntIdadOrdenDetalle1.Observacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntIdadOrdenDetalle1.IdEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntIdadOrdenDetalle1.idUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntIdadOrdenDetalle1.FechaActualizacion))
    End Sub
    Private Sub InsertarActualizarCompraDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow, ByVal EntIdadOrdenDetalle1 As Entidad.Compra)
        EntIdadOrdenDetalle1.TablaProducto = New DataTable()
        EntIdadOrdenDetalle1.TablaProductoPrecio = New DataTable()
        If miDataRow("IdActualizar") = 1 Then
            sqlcom1.CommandText = "ERP_InsActComDetCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCompraDetalle", miDataRow("IdCompraDetalle")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntIdadOrdenDetalle1.IdCompra))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdOrdenDetalle", miDataRow("IdOrdenDetalle")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", miDataRow("IdProducto")))
            sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUnitario", miDataRow("PrecioUnitario"))) 'Precio de ultima entrada
            sqlcom1.Parameters.Add(New SqlParameter("@INPorcentajeIva", miDataRow("PorcentajeIva")))
            sqlcom1.Parameters.Add(New SqlParameter("@INSubtotal", miDataRow("Subtotal")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIva", miDataRow("Iva")))
            sqlcom1.Parameters.Add(New SqlParameter("@INTotal", miDataRow("Total")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoPrioridad", miDataRow("IdTipoPrioridad")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", miDataRow("IdTipoSolicitudEstado")))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", miDataRow("Descripcion")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", miDataRow("IdSucursal")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", miDataRow("IdAlmacen")))
            sqlcom1.Parameters.Add(New SqlParameter("@INCantIdad", miDataRow("CantIdad")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUnIdad", miDataRow("IdUnIdad")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", miDataRow("IdEstado")))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", miDataRow("IdUsuarioCreacion")))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate(miDataRow("FechaCreacion"))))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("IdUsuarioActualizacion")))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
            sqlcom1.ExecuteNonQuery()
            'HAY QUE MODIFICAR EL PRECIO DE ULTIMA ENTRADA Y MODIFICAR LOS PLAZOS 
            Dim IdProducto As Integer = CInt(miDataRow("IdProducto"))
            Dim PrecioUltimaEntrada As Double = CDbl(miDataRow("PrecioUnitario"))
            Dim UsuarioActualizacion As Integer = CInt(miDataRow("IdUsuarioActualizacion"))
            Dim FechaActualizacion As Date = CDate(miDataRow("FechaActualizacion"))
            Dim Cantidad As Integer = CInt(miDataRow("CantIdad"))
            Dim Destino As Integer = CInt(miDataRow("IdAlmacen"))

            Dim sqldat1 As SqlDataAdapter
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.CommandText = "ERP_ActPrecioBaseCom"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", IdProducto))
            sqlcom1.Parameters.Add(New SqlParameter("@INPrecioUltimaEntrada", PrecioUltimaEntrada))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", UsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", Cantidad))
            sqlcom1.Parameters.Add(New SqlParameter("@INDestino", Destino))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProveedor", EntIdadOrdenDetalle1.IdPersona))
            sqldat1.Fill(EntIdadOrdenDetalle1.TablaProducto)
            'sqldat1 = New SqlDataAdapter(sqlcom1)
            'sqlcom1.CommandText = "ERP_ConComProPre"
            'sqlcom1.CommandType = CommandType.StoredProcedure
            'sqlcom1.Parameters.Clear()
            'sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", IdProducto))
            'sqldat1.Fill(EntIdadOrdenDetalle1.TablaProductoPrecio)
        End If
    End Sub
    Private Sub InsertarActualizarOrdenDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow)
        sqlcom1.CommandText = "ERP_ActOrdDetAutCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdOrdenDetalle", miDataRow("IdOrdenDetalle")))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", miDataRow("Cantidad")))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", ""))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", miDataRow("IdTipoSolicitudEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("IdUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
        sqlcom1.ExecuteNonQuery()
    End Sub
    Private Sub InsertarActualizarSolicitudDetalle(ByRef sqlcom1 As SqlCommand, ByVal miDataRow As DataRow)
        sqlcom1.CommandText = "ERP_ActSolDetOrdCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSolicitudDetalle", miDataRow("IdOrdenDetalle")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoSolicitudEstado", miDataRow("IdTipoSolicitudEstado")))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", miDataRow("IdUsuarioActualizacion")))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(miDataRow("FechaActualizacion"))))
        sqlcom1.ExecuteNonQuery()
    End Sub
    Public Sub Consultar(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntIdadOrdenDetalle1 = New Entidad.Compra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        EntIdadOrdenDetalle1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntIdadOrdenDetalle1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConComDet", sqlcon1)
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

    Public Sub WucEstadistica(ByRef EntIdadEstadistica As Entidad.EntidadBase) 'Implements ICatalogo.Consultar
        Dim EntIdadEstadistica1 = New Entidad.Compra()
        EntIdadEstadistica1 = EntIdadEstadistica
        EntIdadEstadistica1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ConComEst", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            Dim sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoCorto", EntIdadEstadistica1.IdProductoCorto))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", EntIdadEstadistica1.FechaInicio))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", EntIdadEstadistica1.FechaFin))
            sqldat1.Fill(EntIdadEstadistica1.TablaConsulta)
            EntIdadEstadistica1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadEstadistica1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadEstadistica1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntIdadEstadistica = EntIdadEstadistica1
        End Try
    End Sub
    Public Sub ConsultarID(ByRef EntidadCompraCredito As Entidad.EntidadBase)
        Dim EntidadCredito1 = New Entidad.Compra()
        EntidadCredito1 = EntidadCompraCredito
        EntidadCredito1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtComCre", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Add(New SqlParameter("@IdCompra", EntidadCredito1.IdCompra))
            sqldat1.Fill(EntidadCredito1.TablaConsulta)
            EntidadCredito1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCredito1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCredito1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCompraCredito = EntidadCredito1
        End Try
    End Sub

    Public Sub ConsultarFiltro(ByRef EntidadProcesoCompra As Entidad.ReporteProcesoCompra)
        ObtenerSol(EntidadProcesoCompra, "ERP_ObtComFil")
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
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoDocumentoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoDocumentoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoDocumentoIni", EntidadProcesoCompra.IdTipoPrioridad))
                sqlcom1.Parameters.Add(New SqlParameter("@IdTipoDocumentoFin", EntidadProcesoCompra.IdTipoPrioridad))
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
        Dim EntIdadOrdenDetalle1 As New Entidad.Compra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsComCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", 0))
            AgragarParametrosCompra(sqlcom1, EntIdadOrdenDetalle1)

            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntIdadOrdenDetalle1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIVA", EntIdadOrdenDetalle1.IVA))
            sqlcom1.Parameters.Add(New SqlParameter("@INSubTotal", EntIdadOrdenDetalle1.SubTotal))
            sqlcom1.Parameters.Add(New SqlParameter("@INCargos", EntIdadOrdenDetalle1.Cargo))
            sqlcom1.Parameters.Add(New SqlParameter("@INAnticipo", EntIdadOrdenDetalle1.Anticipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INTotal", EntIdadOrdenDetalle1.Total))
            sqlcom1.Parameters.Add(New SqlParameter("@INTipoCompra", EntIdadOrdenDetalle1.TipoCompra))
            sqlcom1.Parameters.Add(New SqlParameter("@INTipoCompraEstado", EntIdadOrdenDetalle1.TipoCompraEstado))

            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntIdadOrdenDetalle1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntIdadOrdenDetalle1.FechaCreacion))
            sqlcom1.Parameters(EntIdadOrdenDetalle1.IdCompra).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntIdadOrdenDetalle1.IdCompra = sqlcom1.Parameters(EntIdadOrdenDetalle1.IdCompra).Value

            '========================================================== Compra Credito =====================================================
            If EntIdadOrdenDetalle1.TipoCompra = 1 Then
                sqlcom1 = New SqlCommand("ERP_InsComCreCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntIdadOrdenDetalle1.IdCompra))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", EntIdadOrdenDetalle1.IdCompraCCP))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPlazoCredito", EntIdadOrdenDetalle1.IdPlazoCredito))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPlazoContado", EntIdadOrdenDetalle1.IdPlazoContado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdPeriodo", EntIdadOrdenDetalle1.IdPeriodo))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCalendario", EntIdadOrdenDetalle1.IdCalendario))
                sqlcom1.Parameters.Add(New SqlParameter("@INNumeroPeriodosContado", EntIdadOrdenDetalle1.NumeroPerdiodosContado))
                sqlcom1.Parameters.Add(New SqlParameter("@INNumeroPeriodosCredito", EntIdadOrdenDetalle1.NumeroPerdiodosCredito))
                sqlcom1.Parameters.Add(New SqlParameter("@INImporteCredito", EntIdadOrdenDetalle1.ImporteCredito))
                sqlcom1.Parameters.Add(New SqlParameter("@INImporteContado", EntIdadOrdenDetalle1.ImporteContado))
                sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntIdadOrdenDetalle1.Monto))
                sqlcom1.Parameters.Add(New SqlParameter("@INIVA", EntIdadOrdenDetalle1.IVA))
                sqlcom1.Parameters.Add(New SqlParameter("@INSubTotal", EntIdadOrdenDetalle1.SubTotal))
                sqlcom1.Parameters.Add(New SqlParameter("@INInteresCredito", EntIdadOrdenDetalle1.InteresCredito))
                sqlcom1.Parameters.Add(New SqlParameter("@INInteresContado", EntIdadOrdenDetalle1.InteresContado))
                sqlcom1.Parameters.Add(New SqlParameter("@INTotalCredito", EntIdadOrdenDetalle1.TotalCredito))
                sqlcom1.Parameters.Add(New SqlParameter("@INTotalContado", EntIdadOrdenDetalle1.TotalContado))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaDocumento", EntIdadOrdenDetalle1.FechaDocumento))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimientoContado", EntIdadOrdenDetalle1.FechaVencimientoContado))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimientoCredito", EntIdadOrdenDetalle1.FechaVencimientoCredito))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", EntIdadOrdenDetalle1.Observacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntIdadOrdenDetalle1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntIdadOrdenDetalle1.idUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntIdadOrdenDetalle1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntIdadOrdenDetalle1.idUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntIdadOrdenDetalle1.FechaActualizacion))
                sqlcom1.ExecuteNonQuery()

            End If

            '========================================================== Compra Detalle =====================================================
            For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaCompraDetalle.Rows
                InsertarActualizarCompraDetalle(sqlcom1, MiDataRow, EntIdadOrdenDetalle1)
            Next
            '========================================================== Orden Detalle =====================================================
            For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
                InsertarActualizarOrdenDetalle(sqlcom1, MiDataRow)
            Next
            '========================================================== Solicitud Detalle =====================================================
            For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
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
        Dim EntIdadOrdenDetalle1 As New Entidad.Compra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntIdadOrdenDetalle1.TablaCompraDetalle = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtComDet", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntIdadOrdenDetalle1.IdCompra))
            'Tabla Contacto
            sqlcom1.CommandText = "ERP_ObtComDet"
            sqldat1.Fill(EntIdadOrdenDetalle1.TablaCompraDetalle)

            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub

    Public Sub ObtenerProveedor(ByRef EntIdadCompra As Entidad.Compra)
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        EntIdadCompra.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ObtOrdProvCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntIdadCompra.IdPersona))
            sqlcom1.CommandText = "ERP_ObtOrdProvCod"
            sqldat1.Fill(EntIdadCompra.TablaConsulta)
            EntIdadCompra.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadCompra.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadCompra.Tarjeta.Excepcion = ex.Message.ToString()
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
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntIdadOrdenDetalle.IdCompra))
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
    Public Sub Cancelar(ByRef EntIdadOrdenDetalle As Entidad.EntidadBase)
        Dim EntIdadOrdenDetalle1 As New Entidad.Compra()
        EntIdadOrdenDetalle1 = EntIdadOrdenDetalle
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActComCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", EntIdadOrdenDetalle1.IdCompra))
            AgragarParametrosCompra(sqlcom1, EntIdadOrdenDetalle1)
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntIdadOrdenDetalle1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIVA", EntIdadOrdenDetalle1.IVA))
            sqlcom1.Parameters.Add(New SqlParameter("@INSubTotal", EntIdadOrdenDetalle1.SubTotal))
            sqlcom1.Parameters.Add(New SqlParameter("@INCargos", EntIdadOrdenDetalle1.Cargo))
            sqlcom1.Parameters.Add(New SqlParameter("@INAnticipo", EntIdadOrdenDetalle1.Anticipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INTotal", EntIdadOrdenDetalle1.Total))
            sqlcom1.Parameters.Add(New SqlParameter("@INTipoCompra", EntIdadOrdenDetalle1.TipoCompra))
            sqlcom1.Parameters.Add(New SqlParameter("@INTipoCompraEstado", EntIdadOrdenDetalle1.TipoCompraEstado))
            'sqlcom1.Parameters(EntIdadOrdenDetalle1.IdCompra).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            'EntIdadOrdenDetalle1.IdCompra = sqlcom1.Parameters(EntIdadOrdenDetalle1.IdCompra).Value



            '========================================================== Compra Detalle =====================================================
            For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaCompraDetalle.Rows
                sqlcom1.CommandText = "ERP_CancCompInvComDetCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCompra", MiDataRow("IdCompra")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCompraDetalle", MiDataRow("IdCompraDetalle")))
                sqlcom1.Parameters.Add(New SqlParameter("@IdOrdenDetalle", MiDataRow("IdOrdenDetalle")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntIdadOrdenDetalle1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntIdadOrdenDetalle1.FechaActualizacion))
                sqlcom1.ExecuteNonQuery()
            Next
            '========================================================== Orden Detalle =====================================================
            'For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
            '    'InsertarActualizarOrdenDetalle(sqlcom1, MiDataRow)
            'Next
            '========================================================== Solicitud Detalle =====================================================
            'For Each MiDataRow As DataRow In EntIdadOrdenDetalle1.TablaOrdenDetalle.Rows
            '    InsertarActualizarSolicitudDetalle(sqlcom1, MiDataRow)
            'Next

            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntIdadOrdenDetalle1.Tarjeta.Resultado = Resultado.Incorrecto
            EntIdadOrdenDetalle1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntIdadOrdenDetalle = EntIdadOrdenDetalle1
        End Try
    End Sub

End Class
