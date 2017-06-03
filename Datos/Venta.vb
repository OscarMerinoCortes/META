Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text
Imports Entidad
Imports Operacion.Configuracion.Constante
Public Class Venta
    Implements ICatalogo
    Public Sub Actualizar(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadVenta1 As New Entidad.Venta()
        EntidadVenta1 = EntidadVenta
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        sqlcon1.Open()
        Dim transaccion As SqlTransaction = sqlcon1.BeginTransaction()
        sqlcom1 = New SqlCommand("ERP_ActVenCod", sqlcon1)
        sqlcom1.Transaction = transaccion
        Try
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
            AgragarParametrosVenta(sqlcom1, EntidadVenta1)
            sqlcom1.ExecuteNonQuery()
            '========================================================== Detalle de la venta =====================================================
            InsertarActualizarVentaDetalle(sqlcom1, EntidadVenta1)

            '========================================================== Si la venta es de apartado ===============================================
            If EntidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Apartado Then
                InsertarActualizarApartado(sqlcom1, EntidadVenta1)
            Else
                '========================================================== Cargo de la venta =====================================================
                InsertarActualizarVentaCargo(sqlcom1, EntidadVenta1)
                '========================================================== Descuento de la venta =====================================================
                InsertarActualizarVentaDescuento(sqlcom1, EntidadVenta1)
                '========================================================== Obsequio de la venta =====================================================
                InsertarActualizarVentaObsequio(sqlcom1, EntidadVenta1)

                If EntidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Credito Then
                    '========================================================== Venta Credito =====================================================
                    InsertarActualizarCredito(sqlcom1, EntidadVenta1)
                End If
            End If

            EntidadVenta1.Tarjeta.Resultado = Resultado.Correcto
            transaccion.Commit()
        Catch ex As Exception
            transaccion.Rollback()
            EntidadVenta1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadVenta = EntidadVenta1
        End Try
    End Sub
    Private Sub AgragarParametrosVenta(ByRef sqlcom1 As SqlCommand, ByVal entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", entidadVenta1.IdPersona))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPersona", entidadVenta1.Persona))
        sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", entidadVenta1.Folio))
        sqlcom1.Parameters.Add(New SqlParameter("@IVFolioFisico", entidadVenta1.FolioFisico))
        sqlcom1.Parameters.Add(New SqlParameter("@INSubtotal", entidadVenta1.Subtotal))
        sqlcom1.Parameters.Add(New SqlParameter("@INDescuento", entidadVenta1.DescuentoMonto))
        sqlcom1.Parameters.Add(New SqlParameter("@INCargo", entidadVenta1.CargoMonto))
        sqlcom1.Parameters.Add(New SqlParameter("@INTotal", entidadVenta1.Total))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVenta", entidadVenta1.IdTipoVenta))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVendedor", entidadVenta1.IdVendedor))
        sqlcom1.Parameters.Add(New SqlParameter("@IVVendedor", entidadVenta1.Vendedor))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", entidadVenta1.IdSucursal))
        sqlcom1.Parameters.Add(New SqlParameter("@IVSucursal", entidadVenta1.Sucursal))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoEntrega", entidadVenta1.IdTipoEntrega))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilioEntrega", entidadVenta1.DomicilioEntrega))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVentaEstado", entidadVenta1.IdVentaEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", entidadVenta1.IdEstado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadVenta1.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadVenta1.FechaActualizacion))
    End Sub

    Public Sub ObtenerObsequio(ByRef entidadProducto As EntidadBase)
        Dim EntidadProducto1 = New Entidad.Producto()
        EntidadProducto1 = entidadProducto
        EntidadProducto1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_VenObtObsProId", sqlcon1)
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadProducto1.IdProducto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocion", EntidadProducto1.IdTipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadProducto1.IdSucursal))
            sqldat1.Fill(EntidadProducto1.TablaConsulta)
            EntidadProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            entidadProducto = EntidadProducto1
        End Try
    End Sub

    Public Sub VentaObtener(EntidadVenta As EntidadBase)
        Dim EntidadVenta1 As New Entidad.Venta()
        EntidadVenta1 = EntidadVenta
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        EntidadVenta.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            Select Case EntidadVenta1.Tarjeta.Consulta
                Case Consulta.ConsultaBusqueda
                    sqlcom1 = New SqlCommand("ERP_VenObtVenBus", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", EntidadVenta1.Folio))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVendedor", EntidadVenta1.IdVendedor))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadVenta1.IdSucursal))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVenta", EntidadVenta1.IdTipoVenta))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVentaEstado", EntidadVenta1.IdVentaEstado))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVFechaInicio", EntidadVenta1.FechaCreacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVFechaFin", EntidadVenta1.FechaActualizacion))
                    sqldat1.Fill(EntidadVenta1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    'sqlcom1 = New SqlCommand("ERP_VenObtProId", sqlcon1)
                    'sqldat1 = New SqlDataAdapter(sqlcom1)
                    'sqlcom1.CommandType = CommandType.StoredProcedure
                    'sqlcom1.Parameters.Clear()
                    'sqlcom1.Parameters.Add(New SqlParameter("@IVIdVentaCorto", EntidadVenta1.))
                    'sqldat1.Fill(EntidadVenta1.TablaConsulta)
            End Select
            EntidadVenta1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadVenta1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
    Private Sub InsertarActualizarApartado(ByRef sqlcom1 As SqlCommand, ByRef entidadVenta1 As Entidad.Venta)
        sqlcom1.CommandText = "ERP_InsActVenApaCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaApartado", entidadVenta1.Credito.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", entidadVenta1.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INAnticipo", entidadVenta1.Credito.Anticipo))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPeriodo", entidadVenta1.Credito.IdPlazoContado))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPeriodo", entidadVenta1.Credito.PlazoContado))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaApertura", entidadVenta1.Credito.FechaInicio))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimiento", entidadVenta1.Credito.FechaFinContado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", entidadVenta1.IdEstado))
        sqlcom1.ExecuteNonQuery()
    End Sub

    Private Sub InsertarActualizarCredito(ByRef sqlcom1 As SqlCommand, ByRef venta As Entidad.Venta)
        '======================== Guardar en CCP para obtener el id que se va a guardar en la tabla venta credito =======================================
        InsertarActualizarCCP(sqlcom1, venta)
        If venta.Credito.Anticipo > 0 Then '========= Si hay anticipo guardarlo como movimiento de la cuenta por cobrar =================================
            sqlcom1.CommandText = "ERP_InsCCPMov"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCCPMovimiento", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", venta.Credito.Id))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTransaccion", 2))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", 1))
            sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", venta.Credito.Serie))
            sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", venta.Folio))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", venta.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", "ANTICIPO"))
            sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", venta.Observacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCajaMovimiento", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", venta.Credito.Anticipo))
            sqlcom1.Parameters.Add(New SqlParameter("@INImpuesto", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", venta.IdSucursal))
            If venta.IdEstado = 2 Then
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 7))
            End If
            AgregarParametrosAuditoria(sqlcom1, venta)
            sqlcom1.ExecuteNonQuery()
        End If
        If venta.Cargo.Count > 0 Then '============== Si hay cargos de igual forma guardarlos como movimiento de la cuenta por cobrar ====================
            For Each cargo In From cargo1 In venta.Cargo Where cargo1.IdTipo = 2 '====== el cargo tiene que ser del tipo que afecta el total de la venta =
                sqlcom1.CommandText = "ERP_InsCCPMov"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCCPMovimiento", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", venta.Credito.Id))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTransaccion", 1))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", 4))
                sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", venta.Credito.Serie))
                sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", venta.Folio))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", venta.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", cargo.Cargo.ToUpper()))
                sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", venta.Observacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdCajaMovimiento", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INMonto", cargo.Total))
                sqlcom1.Parameters.Add(New SqlParameter("@INImpuesto", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", venta.IdSucursal))
                If venta.IdEstado = 2 Then
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
                Else
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 7))
                End If
                AgregarParametrosAuditoria(sqlcom1, venta)
                sqlcom1.ExecuteNonQuery()
            Next
        End If
        If venta.Credito.Aval.Length > 0 Then
            sqlcom1.CommandText = "ERP_InsActVenAvaCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaAval", venta.Credito.IdVentaAval))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", venta.Id))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAval", venta.Credito.IdAval))
            sqlcom1.Parameters.Add(New SqlParameter("@IVAval", venta.Credito.Aval.ToUpper()))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", venta.Credito.AvalDomicilio.ToUpper()))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", venta.Credito.AvalTelefono.ToUpper()))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", venta.Credito.IdEstado))
            AgregarParametrosAuditoria(sqlcom1, venta)
            sqlcom1.ExecuteNonQuery()
        End If
        '======================== Guardar en venta credito =======================================
        sqlcom1.CommandText = "ERP_InsActVenCreCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        AgregarParametrosCredito(sqlcom1, venta)
        sqlcom1.ExecuteNonQuery()

        'If Not venta.IdVentaEstado = Operacion.Configuracion.Constante.TipoVentaEstado.PENDIENTE And
        '   Not venta.IdVentaEstado = Operacion.Configuracion.Constante.TipoVentaEstado.CANCELADO Then
        '    '========================= Guardando el nuevo saldo del cliente ==========================
        '    sqlcom1.CommandText = "ERP_ActVenPerSalCod"
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", venta.IdPersona))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INSaldoDisponible", venta.SaldoDisponible - venta.Total))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", venta.IdUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", venta.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        'End If
    End Sub

    Private Sub AgregarParametrosAuditoria(ByRef sqlcom1 As SqlCommand, venta As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", venta.IdUsuarioCreacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", venta.FechaCreacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", venta.IdUsuarioCreacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", venta.FechaCreacion))
    End Sub

    Private Sub InsertarActualizarCCP(ByRef sqlcom1 As SqlCommand, ByRef venta As Entidad.Venta)
        sqlcom1.CommandText = "ERP_InsActCCPCod"
        sqlcom1.CommandType = CommandType.StoredProcedure
        sqlcom1.Parameters.Clear()
        sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", venta.Credito.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDocumento", venta.Credito.IdTipoDocumento))
        sqlcom1.Parameters.Add(New SqlParameter("@IVSerie", venta.Credito.Serie))
        sqlcom1.Parameters.Add(New SqlParameter("@IVFolio", venta.Folio))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", venta.IdPersona))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaExpedicion", venta.Credito.FechaInicio))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimiento", venta.Credito.FechaFinCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", venta.Descripcion))
        sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", venta.Observacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INMonto", venta.Subtotal))
        sqlcom1.Parameters.Add(New SqlParameter("@INIVA", venta.Credito.IVA))
        sqlcom1.Parameters.Add(New SqlParameter("@INIEPS", venta.Credito.IEPS))
        sqlcom1.Parameters.Add(New SqlParameter("@INSubTotal", venta.Subtotal))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCCP", venta.Credito.IdTipoCCP))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", venta.IdUsuarioCreacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", venta.FechaCreacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", venta.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", venta.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado",  venta.Credito.IdEstado))
        sqlcom1.Parameters("@INIdCCP").Direction = ParameterDirection.InputOutput
        sqlcom1.ExecuteNonQuery()
        Try
            venta.Credito.Id = sqlcom1.Parameters("@INIdCCP").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgregarParametrosCredito(ByRef sqlcom1 As SqlCommand, ByVal venta As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdCCP", venta.Credito.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", venta.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPlazoCredito", venta.Credito.IdPlazoCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPlazoCredito", venta.Credito.PlazoCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPlazoContado", venta.Credito.IdPlazoContado))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPlazoContado", venta.Credito.PlazoContado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPeriodo", venta.Credito.IdPeriodo))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPeriodo", venta.Credito.Periodo))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCalendario", venta.Credito.IdCalendario))
        sqlcom1.Parameters.Add(New SqlParameter("@INPeriodoCredito", venta.Credito.PeriodoCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@INPeriodoContado", venta.Credito.PeriodoContado))
        sqlcom1.Parameters.Add(New SqlParameter("@INImporteCredito", venta.Credito.ImporteCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@INImporteContado", venta.Credito.ImporteContado))
        sqlcom1.Parameters.Add(New SqlParameter("@INSubtotalContado", venta.Credito.Subtotal))
        sqlcom1.Parameters.Add(New SqlParameter("@INAnticipo", venta.Credito.Anticipo))
        sqlcom1.Parameters.Add(New SqlParameter("@INTotalContado", venta.Credito.Total))
        sqlcom1.Parameters.Add(New SqlParameter("@INGracia", venta.Credito.Gracia))
        sqlcom1.Parameters.Add(New SqlParameter("@INExtra", venta.Credito.Extra))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaApertura", venta.Credito.FechaInicio))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimientoCredito", venta.Credito.FechaFinCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaVencimientoContado", venta.Credito.FechaFinContado))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", venta.Credito.IdEstado))
        AgregarParametrosAuditoria(sqlcom1, venta)
    End Sub

    Private Sub InsertarActualizarVentaDetalle(ByRef sqlcom1 As SqlCommand, ByVal entidadVenta1 As Entidad.Venta)
        For Each detalle In entidadVenta1.Detalle
            sqlcom1.CommandText = "ERP_InsActVenDetCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            AgregarParametrosVentaDetalle(sqlcom1, detalle, entidadVenta1)
            AgregarParametrosAuditoria(sqlcom1, entidadVenta1)
            sqlcom1.Parameters("@INIdVentaDetalle").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()

            If Not entidadVenta1.IdVentaEstado = Operacion.Configuracion.Constante.TipoVentaEstado.PENDIENTE And
                Not entidadVenta1.IdVentaEstado = Operacion.Configuracion.Constante.TipoVentaEstado.CANCELADO And
                Not entidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Apartado Then
                sqlcom1.CommandText = "ERP_InsActVenProEntCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosVentaProductoEntrega(sqlcom1, detalle, entidadVenta1)
                AgregarParametrosAuditoria(sqlcom1, entidadVenta1)
                sqlcom1.ExecuteNonQuery()

                sqlcom1.CommandText = "ERP_ActVenInvCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", detalle.IdProducto))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", detalle.IdAlmacen))
                sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", detalle.Cantidad))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadVenta1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadVenta1.FechaActualizacion))
                sqlcom1.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub AgregarParametrosVentaProductoEntrega(ByRef sqlcom1 As SqlCommand, detalle As VentaDetalle, entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoEntrega", detalle.IdProductoEntrega))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", detalle.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", detalle.Cantidad))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadFaltante", detalle.Cantidad))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenOrigen", detalle.IdAlmacen))
        sqlcom1.Parameters.Add(New SqlParameter("@IVAlmacenOrigen", detalle.Almacen))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacenDestino", 0))
        sqlcom1.Parameters.Add(New SqlParameter("@IVAlmacenDestino", entidadVenta1.DomicilioEntrega.ToUpper()))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProductoEntregaEstatus", 1))
    End Sub

    Private Sub AgregarParametrosVentaDetalle(ByRef sqlcom1 As SqlCommand, ByVal ventaDetalle As Entidad.VentaDetalle, ByVal entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaDetalle", ventaDetalle.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", entidadVenta1.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", ventaDetalle.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@IVProducto", ventaDetalle.Producto))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidad", ventaDetalle.Cantidad))
        sqlcom1.Parameters.Add(New SqlParameter("@INPrecio", ventaDetalle.PrecioBase))
        sqlcom1.Parameters.Add(New SqlParameter("@INSubtotal", ventaDetalle.SubtotalCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@INDescuento", ventaDetalle.DescuentoCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@INDescuentoPorcentaje", ventaDetalle.DescuentoPorcentaje))
        sqlcom1.Parameters.Add(New SqlParameter("@INTotal", ventaDetalle.TotalCredito))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", ventaDetalle.IdAlmacen))
        sqlcom1.Parameters.Add(New SqlParameter("@IVAlmacen", ventaDetalle.Almacen))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", ventaDetalle.IdEstado))
    End Sub

    Private Sub InsertarActualizarVentaCargo(ByRef sqlcom1 As SqlCommand, ByVal entidadVenta1 As Entidad.Venta)
        For Each cargo In From cargo1 In entidadVenta1.Cargo Where cargo1.Activo
            sqlcom1.CommandText = "ERP_InsActVenCarCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            AgregarParametrosVentaCargo(sqlcom1, cargo, entidadVenta1)
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", entidadVenta1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", entidadVenta1.FechaCreacion))
            sqlcom1.Parameters("@INIdVentaCargo").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
        Next
    End Sub

    Private Sub AgregarParametrosVentaCargo(ByRef sqlcom1 As SqlCommand, ByVal ventaCargo As Entidad.VentaCargo, ByVal entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaCargo", ventaCargo.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", entidadVenta1.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCargoVenta", ventaCargo.IdTipoCargoVenta))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdTipo", ventaCargo.IdTipo))
        sqlcom1.Parameters.Add(New SqlParameter("@IVCargo", ventaCargo.Cargo))
        sqlcom1.Parameters.Add(New SqlParameter("@IVTipoCargoVenta", ventaCargo.TipoCargoVenta))
        sqlcom1.Parameters.Add(New SqlParameter("@INMonto", ventaCargo.Total))
        'sqlcom1.Parameters.Add(New SqlParameter("@INMontoPorcentaje", ventaCargo.MontoPorcentaje))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadVenta1.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadVenta1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", ventaCargo.IdEstado))
    End Sub

    Private Sub InsertarActualizarVentaDescuento(ByRef sqlcom1 As SqlCommand, ByVal entidadVenta1 As Entidad.Venta)
        For Each descuento In entidadVenta1.Descuento
            sqlcom1.CommandText = "ERP_InsActVenDesCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            AgregarParametrosVentaDescuento(sqlcom1, descuento, entidadVenta1)
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", entidadVenta1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", entidadVenta1.FechaCreacion))
            sqlcom1.Parameters("@INIdVentaDescuento").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
        Next
    End Sub

    Private Sub AgregarParametrosVentaDescuento(ByRef sqlcom1 As SqlCommand, ByVal ventaDescuento As Entidad.VentaDescuento, ByVal entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaDescuento", ventaDescuento.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", entidadVenta1.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionDescuento", ventaDescuento.IdPromocion))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPromocionDescuento", ventaDescuento.DescripcionOriginal))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", ventaDescuento.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdGracia", ventaDescuento.Gracia))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdExtra", ventaDescuento.Extra))
        sqlcom1.Parameters.Add(New SqlParameter("@INMonto", ventaDescuento.Descuento))
        sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", ventaDescuento.DescripcionDetalle.ToUpper()))
        'sqlcom1.Parameters.Add(New SqlParameter("@INMontoPorcentaje", ventaDescuento.MontoPorcentaje))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadVenta1.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadVenta1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", ventaDescuento.IdEstado))
    End Sub

    Private Sub InsertarActualizarVentaObsequio(ByRef sqlcom1 As SqlCommand, ByVal entidadVenta1 As Entidad.Venta)
        For i = 0 To entidadVenta1.Obsequio.Count - 1
            Dim obsequio = entidadVenta1.Obsequio(i)
            sqlcom1.CommandText = "ERP_InsActVenObsCod"
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            AgregarParametrosVentaObsequio(sqlcom1, Obsequio, entidadVenta1)
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", entidadVenta1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", entidadVenta1.FechaCreacion))
            sqlcom1.Parameters("@INIdVentaObsequio").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            Try
                entidadVenta1.Obsequio(i).Id = sqlcom1.Parameters("@INIdVentaObsequio").Value
            Catch ex As Exception
            End Try
        Next
        '================================================= Detalle de los obsequios ======================================
        InsertarActualizarVentaObsequioDetalle(sqlcom1, entidadVenta1)
    End Sub

    Private Sub AgregarParametrosVentaObsequio(ByRef sqlcom1 As SqlCommand, ByVal ventaObsequio As Entidad.VentaObsequio, ByVal entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaObsequio", ventaObsequio.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", entidadVenta1.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdPromocionObsequio", ventaObsequio.IdPromocion))
        sqlcom1.Parameters.Add(New SqlParameter("@IVPromocionObsequio", ventaObsequio.DescripcionOriginal))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", ventaObsequio.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INMonto", ventaObsequio.Cargo))
        sqlcom1.Parameters.Add(New SqlParameter("@IVObservacion", ventaObsequio.DescripcionDetalle.ToUpper()))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadVenta1.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadVenta1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", ventaObsequio.IdEstado))
    End Sub

    Private Sub InsertarActualizarVentaObsequioDetalle(ByRef sqlcom1 As SqlCommand, ByVal entidadVenta1 As Entidad.Venta)
        For Each obsequio In entidadVenta1.Obsequio
            For Each detalle In obsequio.Detalle
                sqlcom1.CommandText = "ERP_InsActVenObsDetCod"
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                AgregarParametrosVentaObsequioDetalle(sqlcom1, detalle, obsequio, entidadVenta1)
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", entidadVenta1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", entidadVenta1.FechaCreacion))
                sqlcom1.Parameters("@INIdVentaObsequioDetalle").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                Try
                    detalle.Id = sqlcom1.Parameters("@INIdVentaObsequioDetalle").Value
                Catch ex As Exception
                End Try
            Next
        Next
    End Sub

    Private Sub AgregarParametrosVentaObsequioDetalle(ByRef sqlcom1 As SqlCommand, ByVal ventaObsequioDetalle As Entidad.VentaObsequioDetalle, ventaObsequio As Entidad.VentaObsequio, ByVal entidadVenta1 As Entidad.Venta)
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaObsequioDetalle", ventaObsequioDetalle.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaObsequio", ventaObsequio.Id))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", ventaObsequioDetalle.IdProducto))
        sqlcom1.Parameters.Add(New SqlParameter("@INMonto", ventaObsequioDetalle.Total))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadRegalo", ventaObsequioDetalle.CantidadRegalo))
        sqlcom1.Parameters.Add(New SqlParameter("@INCantidadRegalada", ventaObsequioDetalle.CantidadRegalada))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", entidadVenta1.IdUsuarioActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", entidadVenta1.FechaActualizacion))
        sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", ventaObsequioDetalle.IdEstado))
    End Sub

    Public Sub Consultar(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadVenta1 = New Entidad.Venta()
        EntidadVenta1 = EntidadVenta
        EntidadVenta1.TablaConsulta = New DataTable()
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadVenta1.Tarjeta.Consulta
                Case Consulta.ConsultaBasica ''Consulta de contado
                    sqlcom1 = New SqlCommand("ERP_ConVenConId", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
                    'Tabla Consulta Principal
                    sqlcom1.CommandText = "ERP_ConVenConId"
                    sqldat1.Fill(EntidadVenta1.TablaConsulta)
                    'Tabla Consulta Venta Detalle
                    sqlcom1.CommandText = "ERP_ConVenDetId"
                    Dim tabla As DataTable = New DataTable()
                    sqldat1.Fill(tabla)
                Case Consulta.ConsultaDetallada '' Consulta de Credito
                    sqlcom1 = New SqlCommand("ERP_ConVenId", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
                    'Tabla Consulta Principal
                    sqlcom1.CommandText = "ERP_ConVenId"
                    sqldat1.Fill(EntidadVenta1.TablaConsulta)
                    'Tabla Consulta Venta Detalle
                    sqlcom1.CommandText = "ERP_ConVenDetId"
                    Dim tabla As DataTable = New DataTable()
                    sqldat1.Fill(tabla)
                Case Consulta.ConsultaPorDescripcion
                    sqlcom1 = New SqlCommand("ERP_ConProDes", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqldat1.Fill(EntidadVenta1.TablaConsulta)
                Case Consulta.Ninguno
                    sqlcom1 = New SqlCommand("ERP_ObtUltVen", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadVenta1.IdSucursal))
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqldat1.Fill(EntidadVenta1.TablaConsulta)
                Case Consulta.ConsultaBusqueda
                    sqlcom1 = New SqlCommand("ERP_ConVenBus", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadVenta1.IdPersona))
                    sqlcom1.Parameters.Add(New SqlParameter("@IVCodigo", EntidadVenta1.Folio))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVenta", EntidadVenta1.IdTipoVenta))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVendedor", EntidadVenta1.IdVendedor))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoVentaEstado", EntidadVenta1.IdVentaEstado))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacionInicio", EntidadVenta1.FechaCreacion))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacionFin", EntidadVenta1.FechaActualizacion))
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqldat1.Fill(EntidadVenta1.TablaConsulta)
                Case Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_ConVenId", sqlcon1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
                    'Tabla Consulta Principal
                    ' ============================================== Cargar la venta encabezado ==================================================
                    sqlcom1.CommandText = "ERP_ConVenId"
                    Dim tabla = New DataTable()
                    sqldat1.Fill(tabla)

                    EntidadVenta1.Id = tabla.Rows(0).Item("IdVenta")
                    EntidadVenta1.IdPersona = tabla.Rows(0).Item("IdPersona")
                    EntidadVenta1.Persona = tabla.Rows(0).Item("Persona")
                    EntidadVenta1.Folio = tabla.Rows(0).Item("Folio")
                    EntidadVenta1.FolioFisico = tabla.Rows(0).Item("FolioFisico")
                    EntidadVenta1.Subtotal = tabla.Rows(0).Item("Subtotal")
                    EntidadVenta1.DescuentoMonto = tabla.Rows(0).Item("Descuento")
                    EntidadVenta1.CargoMonto = tabla.Rows(0).Item("Cargo")
                    EntidadVenta1.Total = tabla.Rows(0).Item("Total")
                    EntidadVenta1.IdVendedor = tabla.Rows(0).Item("IdVendedor")
                    EntidadVenta1.Vendedor = tabla.Rows(0).Item("Vendedor")
                    EntidadVenta1.IdSucursal = tabla.Rows(0).Item("IdSucursal")
                    EntidadVenta1.Sucursal = tabla.Rows(0).Item("Sucursal")
                    EntidadVenta1.IdTipoEntrega = tabla.Rows(0).Item("IdTipoEntrega")
                    EntidadVenta1.DomicilioEntrega = tabla.Rows(0).Item("DomicilioEntrega")
                    EntidadVenta1.IdTipoVenta = tabla.Rows(0).Item("IdTipoVenta")
                    EntidadVenta1.IdVentaEstado = tabla.Rows(0).Item("IdTipoVentaEstado")
                    EntidadVenta1.FechaCreacion = tabla.Rows(0).Item("FechaCreacion")
                    EntidadVenta1.IdUsuarioCreacion = tabla.Rows(0).Item("IdUsuarioActualizacion")
                    EntidadVenta1.FechaActualizacion = tabla.Rows(0).Item("FechaActualizacion")
                    EntidadVenta1.IdEstado = tabla.Rows(0).Item("IdEstado")

                    ' ============================================== Cargar la venta detalle ==================================================
                    sqlcom1.CommandText = "ERP_ConVenDetId"
                    tabla = New DataTable()
                    sqldat1.Fill(tabla)
                    Dim fila As Entidad.VentaDetalle
                    For Each row In tabla.Rows
                        fila = New VentaDetalle()
                        fila.Id = row("IdVentaDetalle")
                        fila.IdProducto = row("IdProducto")
                        fila.IdProductoCorto = row("IdProductoCorto")
                        fila.Producto = row("Producto")
                        fila.Cantidad = row("Cantidad")
                        fila.CantidadInventario = row("CantidadInventario")
                        fila.PrecioBase = row("PrecioBase")
                        'fila.DescuentoPorcentaje = row("DescuentoPorciento")
                        'fila.TotalContado = row("Total")
                        fila.IdAlmacen = row("IdAlmacen")
                        fila.Almacen = row("Almacen")
                        fila.IdEstado = row("IdEstado")
                        fila.VentaExistenciaCero = row("VentaExistenciaCero")
                        fila.AfectaInventario = row("IdAfectaInventario")
                        EntidadVenta1.Detalle.Add(fila)
                    Next

                    '=============================================== cargar datos del cliente =================================================
                    sqlcom1.CommandText = "ERP_VenObtPerId"
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPersona", EntidadVenta1.IdPersona))
                    tabla = New DataTable()
                    sqldat1.Fill(tabla)
                    For Each row In tabla.Rows
                        EntidadVenta1.SaldoDisponible = row("Saldo")
                        EntidadVenta1.DomicilioEntrega = row("Domicilio")
                        EntidadVenta1.Identificacion = row("Telefono")
                    Next

                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))

                    If EntidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Apartado Then
                        '=============================================== cargar datos del cliente =================================================
                        sqlcom1.CommandText = "ERP_ConVenApaId"
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
                        tabla = New DataTable()
                        sqldat1.Fill(tabla)
                        For Each row In tabla.Rows
                            EntidadVenta1.Credito.Id = row("IdVentaApartado")
                            EntidadVenta1.Credito.IdPlazoContado = row("IdPeriodo")
                            EntidadVenta1.Credito.PlazoContado = row("Periodo")
                            EntidadVenta1.Credito.FechaInicio = row("FechaApertura")
                            EntidadVenta1.Credito.FechaFinContado = row("FechaVencimiento")
                            EntidadVenta1.Credito.Anticipo = row("Anticipo")
                            EntidadVenta1.Credito.IdEstado = row("IdEstado")
                        Next
                    Else
                        ' ============================================== Cargar la venta Credito ==================================================
                        If EntidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Credito Then
                            'Tabla Consulta Venta Credito
                            sqlcom1.CommandText = "ERP_ConVenCreId"
                            tabla = New DataTable()
                            sqldat1.Fill(tabla)
                            EntidadVenta1.Credito.Id = tabla.Rows(0).Item("IdCCP")
                            EntidadVenta1.Credito.IdPlazoCredito = tabla.Rows(0).Item("IdPlazoCredito")
                            EntidadVenta1.Credito.PlazoCredito = tabla.Rows(0).Item("PlazoCredito")
                            EntidadVenta1.Credito.IdPlazoContado = tabla.Rows(0).Item("IdPlazoContado")
                            EntidadVenta1.Credito.PlazoContado = tabla.Rows(0).Item("PlazoContado")
                            EntidadVenta1.Credito.IdPeriodo = tabla.Rows(0).Item("IdPeriodo")
                            EntidadVenta1.Credito.Periodo = tabla.Rows(0).Item("Periodo")
                            EntidadVenta1.Credito.IdCalendario = tabla.Rows(0).Item("IdTipoCalendario")
                            EntidadVenta1.Credito.PeriodoCredito = tabla.Rows(0).Item("PeriodoCredito")
                            EntidadVenta1.Credito.PeriodoContado = tabla.Rows(0).Item("PeriodoContado")
                            EntidadVenta1.Credito.ImporteCredito = tabla.Rows(0).Item("ImporteCredito")
                            EntidadVenta1.Credito.ImporteContado = tabla.Rows(0).Item("ImporteContado")
                            EntidadVenta1.Credito.Subtotal = tabla.Rows(0).Item("SubtotalContado")
                            EntidadVenta1.Credito.Anticipo = tabla.Rows(0).Item("Anticipo")
                            EntidadVenta1.Credito.Total = tabla.Rows(0).Item("TotalContado")
                            EntidadVenta1.Credito.Gracia = tabla.Rows(0).Item("Gracia")
                            EntidadVenta1.Credito.Extra = tabla.Rows(0).Item("Extra")
                            EntidadVenta1.Credito.FechaInicio = tabla.Rows(0).Item("FechaApertura")
                            EntidadVenta1.Credito.FechaFinCredito = tabla.Rows(0).Item("FechaVencimientoCredito")
                            EntidadVenta1.Credito.FechaFinContado = tabla.Rows(0).Item("FechaVencimientoContado")
                            EntidadVenta1.Credito.IdEstado = tabla.Rows(0).Item("IdEstado")
                        End If

                        ' ============================================== Cargar la venta Descuento ==================================================
                        sqlcom1.CommandText = "ERP_ConVenDesId"
                        tabla = New DataTable()
                        sqldat1.Fill(tabla)
                        Dim fila4 As Entidad.VentaDescuento
                        For Each row In tabla.Rows
                            fila4 = New VentaDescuento
                            fila4.Id = row("IdVentaDescuento")
                            fila4.IdPromocion = row("IdPromocionDescuento")
                            fila4.Descripcion = row("PromocionDescuento")
                            fila4.DescripcionOriginal = row("Observacion")
                            fila4.DescripcionDetalle = row("Observacion")
                            fila4.IdProducto = row("IdProducto")
                            fila4.IdProductoCorto = row("IdProductoCorto")
                            fila4.Gracia = row("Gracia")
                            fila4.Extra = row("Extra")
                            fila4.Descuento = row("Monto")
                            fila4.Observacion = row("Observacion")
                            fila4.IdEstado = row("IdEstado")
                            EntidadVenta1.Descuento.Add(fila4)
                        Next

                        ' ============================================== Cargar la venta Cargos ==================================================
                        If Not EntidadVenta1.IdVentaEstado = Operacion.Configuracion.Constante.TipoVentaEstado.PENDIENTE Then
                            sqlcom1.CommandText = "ERP_ConVenCarId"
                            tabla = New DataTable()
                            sqldat1.Fill(tabla)
                            EntidadVenta1.Cargo.Clear()
                            Dim fila5 As Entidad.VentaCargo
                            For Each row In tabla.Rows
                                fila5 = New VentaCargo
                                fila5.Id = row("IdVentaCargo")
                                fila5.IdTipoCargoVenta = row("IdTipoCargoVenta")
                                fila5.TipoCargoVenta = row("TipoCargoVenta")
                                fila5.IdTipo = row("IdTipo")
                                fila5.Cargo = row("Cargo")
                                fila5.Monto = row("Monto")
                                fila5.Total = row("Monto")
                                fila5.IdEstado = row("IdEstado")
                                fila5.Activo = True
                                EntidadVenta1.Cargo.Add(fila5)
                            Next
                        End If

                        ' ============================================== Cargar la venta avales ==================================================
                        sqlcom1.CommandText = "ERP_ConVenAvaId"
                        tabla = New DataTable()
                        sqldat1.Fill(tabla)
                        For Each row In tabla.Rows
                            EntidadVenta1.Credito.IdVentaAval = row("IdVentaAval")
                            EntidadVenta1.Credito.IdAval = row("IdAval")
                            EntidadVenta1.Credito.Aval = row("Aval")
                            EntidadVenta1.Credito.AvalDomicilio = row("Domicilio")
                            EntidadVenta1.Credito.AvalTelefono = row("Telefono")
                        Next

                        ' ============================================== Cargar la venta obsequio ==================================================
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
                        sqlcom1.CommandText = "ERP_ConVenObsId"
                        tabla = New DataTable()
                        sqldat1.Fill(tabla)
                        Dim fila2 As Entidad.VentaObsequio
                        For Each row In tabla.Rows
                            fila2 = New VentaObsequio()
                            fila2.Id = row("IdVentaObsequio")
                            fila2.IdPromocion = row("IdPromocionObsequio")
                            fila2.Descripcion = row("PromocionObsequio")
                            fila2.IdProducto = row("IdProducto")
                            fila2.IdProductoCorto = row("IdProductoCorto")
                            fila2.Cargo = row("Monto")
                            fila2.Descripcion = row("Observacion")
                            fila2.DescripcionDetalle = row("Observacion")
                            fila2.DescripcionOriginal = row("Observacion")
                            fila2.Observacion = row("Observacion")
                            fila2.IdEstado = row("IdEstado")
                            EntidadVenta1.Obsequio.Add(fila2)
                        Next

                        ' ============================================== Cargar la venta obequio detalle ==================================================
                        sqlcom1.CommandText = "ERP_ConVenObsDetId"
                        For i = 0 To EntidadVenta1.Obsequio.Count - 1
                            sqlcom1.Parameters.Clear()
                            sqlcom1.Parameters.Add(New SqlParameter("@INIdVentaObsequio", EntidadVenta1.Obsequio(i).Id))
                            tabla = New DataTable()
                            sqldat1.Fill(tabla)
                            EntidadVenta1.Obsequio(i).Detalle = New ObjectModel.ObservableCollection(Of VentaObsequioDetalle)
                            Dim fila3 As Entidad.VentaObsequioDetalle
                            For Each row In tabla.Rows
                                fila3 = New VentaObsequioDetalle
                                fila3.Id = row("IdVentaObsequioDetalle")
                                fila3.IdProducto = row("IdProducto")
                                fila3.IdProductoCorto = row("IdProductoCorto")
                                fila3.Producto = row("Producto")
                                fila3.Total = row("Monto")
                                fila3.CantidadRegalo = row("CantidadRegalo")
                                fila3.CantidadRegalada = row("CantidadRegalada")
                                fila3.IdEstado = row("IdEstado")
                                fila3.IdAlmacen = EntidadVenta1.IdAlmacen
                                fila3.Almacen = EntidadVenta1.Almacen
                                EntidadVenta1.Obsequio(i).Detalle.Add(fila3)
                            Next
                        Next
                    End If

            End Select
            EntidadVenta1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadVenta1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadVenta = EntidadVenta1
        End Try
    End Sub

    Public Sub Insertar(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadVenta1 As New Entidad.Venta()
        EntidadVenta1 = EntidadVenta
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        sqlcon1.Open()
        Dim transaccion As SqlTransaction = sqlcon1.BeginTransaction()
        sqlcom1 = New SqlCommand("ERP_InsVenCod", sqlcon1)
        sqlcom1.Transaction = transaccion
        Try
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", 0))
            AgragarParametrosVenta(sqlcom1, EntidadVenta1)
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadVenta1.FechaCreacion))
            sqlcom1.Parameters("@INIdVenta").Direction = ParameterDirection.InputOutput
            sqlcom1.Parameters("@IVFolio").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadVenta1.Id = sqlcom1.Parameters("@INIdVenta").Value
            EntidadVenta1.Folio = sqlcom1.Parameters("@IVFolio").Value
            '========================================================== Detalle de la venta =====================================================
            InsertarActualizarVentaDetalle(sqlcom1, EntidadVenta1)

            '========================================================== Si la venta es de apartado ===============================================
            If EntidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Apartado Then
                InsertarActualizarApartado(sqlcom1, EntidadVenta1)
            Else
                '========================================================== Cargo de la venta =====================================================
                InsertarActualizarVentaCargo(sqlcom1, EntidadVenta1)
                '========================================================== Descuento de la venta =====================================================
                InsertarActualizarVentaDescuento(sqlcom1, EntidadVenta1)
                '========================================================== Obsequio de la venta =====================================================
                InsertarActualizarVentaObsequio(sqlcom1, EntidadVenta1)

                If EntidadVenta1.IdTipoVenta = Operacion.Configuracion.Constante.TipoVenta.Credito Then
                    '========================================================== Venta Credito =====================================================
                    InsertarActualizarCredito(sqlcom1, EntidadVenta1)
                End If
            End If

            EntidadVenta1.Tarjeta.Resultado = Resultado.Correcto
            transaccion.Commit()
        Catch ex As Exception
            transaccion.Rollback()
            EntidadVenta1.Id = 0
            EntidadVenta1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadVenta = EntidadVenta1
        End Try
    End Sub
 
    Public Sub Obtener(ByRef EntidadVenta As Entidad.EntidadBase) Implements ICatalogo.Obtener
        'Dim EntidadVenta1 As New Entidad.Venta()
        'EntidadVenta1 = EntidadVenta
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntidadVenta1.TablaVentaDetalle = New DataTable()
        'EntidadVenta1.TablaMaximoMinimo = New DataTable()
        'EntidadVenta1.TablaPrecio = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_LisProCodBarCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta1.Id))
        '    'Tabla Contacto
        '    sqlcom1.CommandText = "ERP_LisProCodBarCod"
        '    sqldat1.Fill(EntidadVenta1.TablaVentaDetalle)
        '    'Tabla Domicilio
        '    sqlcom1.CommandText = "ERP_LisProMaxMinCod"
        '    sqldat1.Fill(EntidadVenta1.TablaMaximoMinimo)
        '    'Tabla Empleo
        '    sqlcom1.CommandText = "ERP_LisProPreCod"
        '    sqldat1.Fill(EntidadVenta1.TablaPrecio)

        '    EntidadVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadVenta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadVenta1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub

    Public Sub ObtenerTablas(ByRef EntidadVenta As Entidad.EntidadBase)
        'Dim sqlcon1 As New SqlConnection(Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntidadVenta.TablaIdentificacion = New DataTable()
        'EntidadVenta.TablaContacto = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    'tabla identificacion
        '    sqlcom1 = New SqlCommand("ERP_LisPerIdeCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdVenta", EntidadVenta.IdVenta))
        '    sqldat1.Fill(EntidadVenta.TablaIdentificacion)
        '    'Tabla Contacto
        '    sqlcom1.CommandText = "ERP_LisPerMedCod"
        '    sqldat1.Fill(EntidadVenta.TablaContacto)
        '    'Tabla Domicilio
        '    sqlcom1.CommandText = "ERP_LisPerDomCod"
        '    sqldat1.Fill(EntidadVenta.TablaDomicilio)
        '    EntidadVenta.Tarjeta.Resultado = Resultado.Correcto
        'Catch ex As Exception
        '    EntidadVenta.Tarjeta.Resultado = Resultado.Incorrecto
        '    EntidadVenta.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub

    Public Sub ReporteVenta(ByRef EntidadReporteVenta As Entidad.EntidadBase)
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Dim sqldat1 As SqlDataAdapter
        'EntidadReporteVenta.TablaConsulta = New DataTable()
        'Try
        '    sqlcon1.Open()
        '    'tabla identificacion
        '    sqlcom1 = New SqlCommand("ERP_LisRepPerCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqldat1 = New SqlDataAdapter(sqlcom1)
        '    sqlcom1.Parameters.Clear()
        '    If EntidadReporteVenta.IdTipoVenta = -1 Then
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaIni", 0))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaFin", 1000000))
        '    Else
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaIni", EntidadReporteVenta.IdTipoVenta))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idTipoVentaFin", EntidadReporteVenta.IdTipoVenta))
        '    End If
        '    If EntidadReporteVenta.IdGenero = -1 Then
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", 0))
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", 1000000))
        '    Else
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroIni", EntidadReporteVenta.IdGenero))
        '        sqlcom1.Parameters.Add(New SqlParameter("@IdGeneroFin", EntidadReporteVenta.IdGenero))
        '    End If
        '    If EntidadReporteVenta.IdEstado = -1 Then
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", 0))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", 1000000))
        '    Else
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", EntidadReporteVenta.IdEstado))
        '        sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", EntidadReporteVenta.IdEstado))
        '    End If
        '    sqldat1.Fill(EntidadReporteVenta.TablaConsulta)
        '    EntidadReporteVenta.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadReporteVenta.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadReporteVenta.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        'End Try
    End Sub


End Class
