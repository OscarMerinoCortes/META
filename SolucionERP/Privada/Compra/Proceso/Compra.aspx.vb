Imports System.Data
Imports System.Drawing.Printing
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Imports System.Collections.ObjectModel
Imports System.Web.Services

Partial Class _Default
    Inherits Page
    Private TablaCompraDetalle As New DataTable()
    Private VistaCompraDetalle As New DataView()
    Private TablaOrdenDetalle As New DataTable()
    Private VistaOrdenDetalle As New DataView()

    Private TablaMovimientos As New DataTable()
    Private TablaCredito As New DataTable()
    Shared Subtotal As Decimal
    Shared Monto As Decimal
    Shared TotalC As Decimal
    Shared TotalL As Decimal
    Shared Saldo As Decimal
    Public FechaCreacion As Date
    Public TipoCompraEstado As Integer

    Private ListaEstado As New ObservableCollection(Of Entidad.TipoSolicitudEstado)
    Private ListaPrioridad As New ObservableCollection(Of Entidad.TipoPrioridad)
    Private ListaAlmacen As New ObservableCollection(Of Entidad.Almacen)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Compra"
            IBTCancelar.Visible = False
            LlenarDDs()
            IBTImprimir.Visible = False
            '===========================================================================================================================
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Seleccionar"
            Columna.SelectText = "Seleccionar"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            '=================================================== Orden detalle =========================================================
            TablaCompraDetalle.Columns.Clear()
            TablaCompraDetalle.Columns.Add(New DataColumn("IdCompraDetalle", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdCompra", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdOrdenDetalle", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Producto", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("PrecioUnitario", Type.GetType("System.Double")))
            TablaCompraDetalle.Columns.Add(New DataColumn("PorcentajeIva", Type.GetType("System.Double")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Subtotal", Type.GetType("System.Double")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IVA", Type.GetType("System.Double")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Total", Type.GetType("System.Double")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdTipoPrioridad", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("TipoPrioridad", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdTipoSolicitudEstado", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("TipoSolicitudEstado", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdSucursal", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdAlmacen", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Almacen", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdUnidad", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Unidad", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdActualizar", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("UsuarioCreacion", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaCompraDetalle.Columns.Add(New DataColumn("UsuarioActualizacion", Type.GetType("System.String")))
            TablaCompraDetalle.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))

            VistaCompraDetalle = TablaCompraDetalle.DefaultView
            VistaCompraDetalle.RowFilter = "IdEstado=1"

            'GVCompraDetalle.Columns.Clear()
            GVCompraDetalle.DataSource = TablaCompraDetalle
            GVCompraDetalle.AutoGenerateColumns = False
            GVCompraDetalle.AllowSorting = True

            'GVCompraDetalle.Columns.Add(Columna)

            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Codigo Corto", "IdProductoCorto")
            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Producto", "Producto")
            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Cantidad", "Cantidad")
            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Precio Unitario", "PrecioUnitario")
            ''Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Subtotal", "Subtotal")
            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Total", "Total")
            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Destino", "Almacen")
            'Cuadricula.AgregarColumna(GVCompraDetalle, New BoundField(), "Estado Solicitud", "TipoSolicitudEstado")
            GVCompraDetalle.DataBind()

            Session("TablaCompraDetalle") = TablaCompraDetalle
            Session("VistaCompraDetalle") = VistaCompraDetalle

            '================================================Movimientos===========================================================================
            TablaMovimientos.Columns.Clear()
            TablaMovimientos.Columns.Add(New DataColumn("IdCCP", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("IdTransaccion", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("IdTipoDocumento", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("Serie", Type.GetType("System.String")))
            TablaMovimientos.Columns.Add(New DataColumn("Folio", Type.GetType("System.String")))
            TablaMovimientos.Columns.Add(New DataColumn("Fecha", Type.GetType("System.String")))
            TablaMovimientos.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaMovimientos.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            TablaMovimientos.Columns.Add(New DataColumn("IdCajaMovimiento", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("MontoTransaccion", Type.GetType("System.Double")))
            TablaMovimientos.Columns.Add(New DataColumn("Impuesto", Type.GetType("System.Double")))
            TablaMovimientos.Columns.Add(New DataColumn("IdSucursal", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaMovimientos.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaMovimientos.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            Session("TablaMovimientos") = TablaMovimientos

            TablaCredito.Columns.Clear()
            TablaCredito.Columns.Add(New DataColumn("IdCompra", Type.GetType("System.Int32")))
            TablaCredito.Columns.Add(New DataColumn("IdPlazoCredito", Type.GetType("System.Int32")))
            TablaCredito.Columns.Add(New DataColumn("IdPlazoContado", Type.GetType("System.Int32")))
            TablaCredito.Columns.Add(New DataColumn("IdPeriodo", Type.GetType("System.Int32")))
            TablaCredito.Columns.Add(New DataColumn("InteresCredito", Type.GetType("System.String")))
            TablaCredito.Columns.Add(New DataColumn("InteresContado", Type.GetType("System.String")))
            TablaCredito.Columns.Add(New DataColumn("IdCCP", Type.GetType("System.Int32")))
            Session("TablaCredito") = TablaCredito

            Nuevo()
            TBPLCTotal.Text = String.Format("{0:c}", 0)
            TBPLTotal.Text = String.Format("{0:c}", 0)
            TBPLInteres.Text = "0"
            TBPLCInteres.Text = "0"
            TBCAnticipo.Text = String.Format("{0:c}", 0)
            TBCCargo.Text = String.Format("{0:c}", 0)

            TBPLAbonos.Text = String.Format("{0:c}", 0)
            TBPLCAbonos.Text = String.Format("{0:c}", 0)
            TBPLPeriodos.Text = "0"
            TBPLCPeriodos.Text = "0"

            Saldo = "0"
            Monto = "0"
            Subtotal = "0"
            TotalL = "0"
            TotalC = "0"



            LimpiarDetalle()

            'TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            'TBFechaFin.Text = Now.ToString("dd/MM/yyyy")

            TBFechaDocumento.Text = Now.ToString("dd/MM/yyyy")
            TBPLCFechaInicio.Text = Now.ToString("dd/MM/yyyy")
            TBPLFechaInicio.Text = Now.ToString("dd/MM/yyyy")
            TBPLFechaFin.Text = Now.AddMonths(1).ToString("dd/MM/yyyy")
            TBPLCFechaFin.Text = Now.ToString("dd/MM/yyyy")
            MultiView1.SetActiveView(View1)
            wucDatosAuditoria1.Nuevo()
            wucDatosAuditoria1.Visible = False

            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            'VistaOrdenDetalle = TablaOrdenDetalle.DefaultView
            'VistaOrdenDetalle.RowFilter = "IdEstado=1"
        Else

            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            'VistaOrdenDetalle = TablaOrdenDetalle.DefaultView
            'VistaOrdenDetalle.RowFilter = "IdEstado=1"

            TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
            VistaCompraDetalle = CType(Session("VistaCompraDetalle"), DataView)
            TablaCredito = CType(Session("TablaCredito"), DataTable)
            ListaEstado = CType(Session("ListaEstado"), ObservableCollection(Of Entidad.TipoSolicitudEstado))
            ListaPrioridad = CType(Session("ListaPrioridad"), ObservableCollection(Of Entidad.TipoPrioridad))
        End If
        'TBPrecioUnitario.Attributes("onchange") = "if (IsValid(this)=false)return;"
        AddHandler wucConsultarProducto1.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub

    Private Sub AgregarProductos()
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        VistaCompraDetalle = CType(Session("VistaCompraDetalle"), DataView)
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = wucConsultarProducto1.ObtenerProductos()
        For Each producto In productosSeleccionados
            Dim bandera = Not TablaCompraDetalle.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdProducto").ToString() = producto.IdProducto)
            If bandera Then

                If TBCantidadDetalle.Text = "" Then
                    TBCantidadDetalle.Text = 1
                End If
                If TBPrecioUnitario.Text = "" Then
                    TBPrecioUnitario.Text = 1
                End If
                Dim RenglonAInsertar As DataRow

                RenglonAInsertar = TablaCompraDetalle.NewRow()

                Dim IdOrden = 0
                If IsNumeric(TBIdCompra.Text) Then
                    IdOrden = CType(TBIdCompra.Text, Integer)
                End If
                RenglonAInsertar = TablaCompraDetalle.NewRow()
                RenglonAInsertar("IdOrdenDetalle") = 0
                RenglonAInsertar("IdCompra") = 0
                RenglonAInsertar("IdCompraDetalle") = 0

                RenglonAInsertar("IdProducto") = producto.IdProducto
                RenglonAInsertar("IdProductoCorto") = producto.IdProductoCorto
                RenglonAInsertar("Producto") = producto.Producto

                RenglonAInsertar("Cantidad") = CType(TBCantidadDetalle.Text, Integer)
                RenglonAInsertar("PrecioUnitario") = CType(TBPrecioUnitario.Text, Double)

                RenglonAInsertar("PorcentajeIva") = 0
                RenglonAInsertar("Subtotal") = CType(TBPrecioUnitario.Text, Double) * CType(TBCantidadDetalle.Text, Double)

                'subtotal

                RenglonAInsertar("IVA") = 0
                RenglonAInsertar("Total") = CType(TBPrecioUnitario.Text, Double) * CType(TBCantidadDetalle.Text, Double)

                Monto = Monto + CType(TBPrecioUnitario.Text, Double) * CType(TBCantidadDetalle.Text, Double)
                'iva
                MuestraTotales()
                CalcularTotales()
                RenglonAInsertar("IdTipoPrioridad") = 1
                RenglonAInsertar("TipoPrioridad") = "BAJA"
                RenglonAInsertar("IdTipoSolicitudEstado") = 6
                RenglonAInsertar("TipoSolicitudEstado") = "COMPRADO"
                RenglonAInsertar("IdAlmacen") = DDAlmacen.SelectedValue
                RenglonAInsertar("Almacen") = DDAlmacen.SelectedItem.Text
                RenglonAInsertar("IdSucursal") = 1

                RenglonAInsertar("IdUnidad") = 1
                RenglonAInsertar("Descripcion") = ""

                RenglonAInsertar("IdEstado") = 1
                RenglonAInsertar("IdActualizar") = 1
                RenglonAInsertar("Estado") = "ACTIVO"
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = CDate(Now)
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = CDate(Now)

                TablaCompraDetalle.Rows.Add(RenglonAInsertar)


            Else
                'actualizar renglon
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("IdProducto") = producto.IdProducto
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("IdProductoCorto") = producto.IdProductoCorto
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("Cantidad") = producto.Cantidad
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("IdAlmacen") = DDAlmacen.SelectedValue
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("Almacen") = DDAlmacen.SelectedItem.Text
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("IdEstado") = 1
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("IdUsuarioActualizacion") = 1
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("FechaActualizacion") = Now
                'VistaSolicitudDetalle(GVSolicitudDetalle.SelectedIndex).Item("IdActualizar") = 1

            End If
        Next
        Session("TablaCompraDetalle") = TablaCompraDetalle
        Session("VistaCompraDetalle") = VistaCompraDetalle
        GVCompraDetalle.DataSource = VistaCompraDetalle
        GVCompraDetalle.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("PrecioUnitario")
        Next
        LimpiarDetalle()
        MuestraTotales()
    End Sub
    <WebMethod()>
    Public Shared Function TablasTooltip(idproducto As String) As String
        'Compras
        Dim EntidadCompra = New Entidad.Compra
        Dim NegocioCompra = New Negocio.Compra
        EntidadCompra.IdProductoCorto = idproducto
        EntidadCompra.FechaInicio = CDate(Now.AddYears(-3))
        EntidadCompra.FechaFin = CDate(Now.AddYears(1))
        NegocioCompra.WucEstadistica(EntidadCompra)
        Dim TablaCompra = EntidadCompra.TablaConsulta
        'Ventas
        Dim EntidadVenta = New Entidad.Producto
        Dim NegocioVenta = New Negocio.Producto
        EntidadVenta.IdProductoCorto = idproducto
        EntidadVenta.FechaInicio = CDate(Now.AddYears(-3))
        EntidadVenta.FechaFin = CDate(Now.AddYears(1))
        NegocioVenta.WucEstadisticaVenta(EntidadVenta)
        Dim TablaVenta = EntidadVenta.TablaConsulta
        'producto
        EntidadVenta.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadVenta.IdProductoCorto = idproducto
        EntidadVenta.IdProducto = -1
        NegocioVenta.Consultar(EntidadVenta)
        Dim ProductoDescripcion As String = EntidadVenta.TablaConsulta.Rows(0).Item("Descripcion")

        'Existencia
        Dim NegocioReporteExistencia As New Negocio.ReporteExistenciaAlmacen()
        Dim EntidadReporteExistencia As New Entidad.ReporteExistenciaAlmacen()
        EntidadReporteExistencia.IdProductoCorto = idproducto
        EntidadReporteExistencia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioReporteExistencia.ExistenciaSucursal(EntidadReporteExistencia)
        Dim TablaSucursal = EntidadReporteExistencia.TablaConsulta
        'Proveedores
        Dim EntidadProveedor = New Entidad.Proveedor
        Dim NegocioProveedor = New Negocio.Proveedor
        EntidadProveedor.IdProductoCorto = idproducto
        NegocioProveedor.WucEstadisticaProveedor(EntidadProveedor)
        Dim TablaProveedores = EntidadProveedor.TablaConsulta

        Dim tooltip = "<div class=""divTooltipTablas"">" + ProductoDescripcion + "<br />"
        tooltip += "Cantidad de productos comprados<br />"
        If TablaCompra.Rows.Count > 0 Then
            tooltip += Comun.Presentacion.Herramientas.ConvertDataTableToHTML(TablaCompra)
        Else
            tooltip += "SIN REGISTROS DE COMPRAS"
        End If
        tooltip += "<br />Cantidad de productos vendidos<br />"
        If TablaVenta.Rows.Count > 0 Then
            tooltip += Comun.Presentacion.Herramientas.ConvertDataTableToHTML(TablaVenta)
        Else
            tooltip += "SIN REGISTROS DE VENTAS"
        End If
        tooltip += "<br />Existencias de productos por Sucursal<br />"
        If TablaSucursal.Rows.Count > 0 Then
            tooltip += Comun.Presentacion.Herramientas.ConvertDataTableToHTML(TablaSucursal)
        Else
            tooltip += "SIN REGISTROS DE EXISTENCIAS POR SUCURSAL"
        End If
        tooltip += "<br />Costo de productos por proveedor<br />"
        If TablaProveedores.Rows.Count > 0 Then
            tooltip += Comun.Presentacion.Herramientas.ConvertDataTableToHTML(TablaProveedores)
        Else
            tooltip += "SIN REGISTROS DE COMPRAS A PROVEEDORES"
        End If
        tooltip += "</div>"
        tooltip = tooltip.Replace("anio", "Año")
        tooltip = tooltip.Replace("IdProveedor", "ID")
        tooltip = tooltip.Replace("RazonSocial", "Razon Social")
        tooltip = tooltip.Replace("PrecioUltimaEntrada", "Ultimo Precio")
        tooltip = tooltip.Replace("FechaUltimaCompra", "Ultima Compra")

        Return tooltip
    End Function
    Private Sub LlenarSolicitudes()
        Dim NegocioSolicitudCompra As New Negocio.OrdenCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        EntidadSolicitudCompra.IdProceso = -1 'CType(IIf(IsNumeric(TBOrden.Text), TBOrden.Text, -1), Integer)
        EntidadSolicitudCompra.IdAlmacen = CType(DDDestino.SelectedValue, Integer)
        EntidadSolicitudCompra.IdClasificacion = -1 ' CType(DDClasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdSubclasificacion = -1 ' CType(DDSubclasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdTipoPrioridad = -1 'CType(DDPrioridadOrden.SelectedValue, Integer)
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = 3 'CType(DDEstado.SelectedValue, Integer)
        EntidadSolicitudCompra.FechaInicio = "01/01/2016" 'Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadSolicitudCompra.FechaFin = Now ' Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        'TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        'TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
        EntidadSolicitudCompra.IdProveedor = IdProveedor


        NegocioSolicitudCompra.ObtenerSolicitudCompraOrdenadas(EntidadSolicitudCompra)
        TablaOrdenDetalle = EntidadSolicitudCompra.TablaConsulta

        VistaOrdenDetalle = TablaOrdenDetalle.DefaultView
        Session("TablaOrdenDetalle") = TablaOrdenDetalle
        Session("VistaOrdenDetalle") = VistaOrdenDetalle

        GVOrden.DataSource = VistaOrdenDetalle

        GVOrden.AutoGenerateColumns = False
        GVOrden.AllowSorting = True
        GVOrden.DataBind()

    End Sub

    Private Sub LlenarDDs()
        ' --------------------------- ---- Tipo Solicitud Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        DDTipoCompraEstado.DataSource = EntidadTipoSolicitudEstado.TablaConsulta
        DDTipoCompraEstado.DataValueField = "ID"
        DDTipoCompraEstado.DataTextField = "Descripcion"
        DDTipoCompraEstado.DataBind()
        DDTipoCompraEstado.SelectedIndex = 6
        ' --------------------------- ---- Tipo Documento ---- ---------------------------
        Dim NegocioTipoDocumento = New Negocio.TipoDocumento()
        Dim EntidadTipoDocumento As New Entidad.TipoDocumento()
        EntidadTipoDocumento.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoDocumento.Consultar(EntidadTipoDocumento)
        DDTipoDocumento.DataSource = EntidadTipoDocumento.TablaConsulta
        DDTipoDocumento.DataValueField = "ID"
        DDTipoDocumento.DataTextField = "Descripcion"
        DDTipoDocumento.DataBind()

        ' --------------------------- ---- Tipo Forma de pago ---- ---------------------------
        Dim NegocioFormaPago = New Negocio.FormaPago()
        Dim EntidadFormaPago As New Entidad.FormaPago()
        EntidadFormaPago.Tarjeta.Consulta = Consulta.ConsultaDetallada
        NegocioFormaPago.Consultar(EntidadFormaPago)
        DDFormaPago.DataSource = EntidadFormaPago.TablaConsulta
        DDFormaPago.DataValueField = "ID"
        DDFormaPago.DataTextField = "Descripcion"
        DDFormaPago.DataBind()

        ' --------------------------- ---- Tipo Prioridad ---- ---------------------------
        'Dim NegocioTipoPrioridad = New Negocio.TipoPrioridad()
        'Dim EntidadTipoPrioridad As New Entidad.TipoPrioridad()
        'EntidadTipoPrioridad.Tarjeta.Consulta = Consulta.ConsultaBasica
        'NegocioTipoPrioridad.Consultar(EntidadTipoPrioridad)
        'EntidadTipoPrioridad.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        'DDPrioridadOrden.DataSource = EntidadTipoPrioridad.TablaConsulta
        'DDPrioridadOrden.DataValueField = "ID"
        'DDPrioridadOrden.DataTextField = "Descripcion"
        'DDPrioridadOrden.DataBind()
        'DDPrioridadOrden.SelectedValue = "-1"

        ' --------------------------- ---- Estado ---- ---------------------------
        'Dim NegocioTipoSolicitudEstado = New Negocio.TipoSolicitudEstado()
        'Dim EntidadTipoSolicitudEstado As New Entidad.TipoSolicitudEstado()
        'EntidadTipoSolicitudEstado.Tarjeta.Consulta = Consulta.Ninguno
        'NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        'EntidadTipoSolicitudEstado.TablaConsulta.Rows.Add(-1, "TODO")
        'DDEstado.DataSource = EntidadTipoSolicitudEstado.TablaConsulta
        'DDEstado.DataValueField = "ID"
        'DDEstado.DataTextField = "Descripcion"
        'DDEstado.DataBind()
        'DDEstado.SelectedValue = "-1"

        ' --------------------------- ---- Almacen ---- ---------------------------
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)
        'EntidadAlmacen.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, "TODO")

        DDDestino.DataSource = EntidadAlmacen.TablaConsulta
        DDDestino.DataValueField = "ID"
        DDDestino.DataTextField = "Descripcion"
        DDDestino.DataBind()
        DDDestino.SelectedIndex = 0

        DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacen.DataValueField = "ID"
        DDAlmacen.DataTextField = "Descripcion"
        DDAlmacen.DataBind()
        DDAlmacen.SelectedIndex = 0

        ' --------------------------- ---- Periodo ---- ---------------------------
        Dim NegocioPeriodo = New Negocio.Periodo()
        Dim EntidadPeriodo = New Entidad.Periodo()
        EntidadPeriodo.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioPeriodo.Consultar(EntidadPeriodo)
        DDPeriodo.DataSource = EntidadPeriodo.TablaConsulta

        DDPeriodo.DataValueField = "ID" 'Cantidad
        DDPeriodo.DataTextField = "Descripcion"
        DDPeriodo.DataBind()
        DDPeriodo.Items.Add(New ListItem("NINGUNO", 0))
        DDPeriodo.SelectedValue = "0"

        ' --------------------------- ---- Plazo ---- ---------------------------
        Dim NegocioPlazo = New Negocio.TipoPlazo
        Dim EntidadPlazo = New Entidad.TipoPlazo
        EntidadPlazo.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioPlazo.Consultar(EntidadPlazo)
        DDPlazoLimite.DataSource = EntidadPlazo.TablaConsulta
        DDPlazoLimite.DataValueField = "ID"
        DDPlazoLimite.DataTextField = "Descripcion"
        DDPlazoLimite.DataBind()

        DDPlazoLimiteCorto.DataSource = EntidadPlazo.TablaConsulta
        DDPlazoLimiteCorto.DataValueField = "ID"
        DDPlazoLimiteCorto.DataTextField = "Descripcion"
        DDPlazoLimiteCorto.DataBind()
        DDPlazoLimiteCorto.Items.Add(New ListItem("NINGUNO", 0))
        DDPlazoLimiteCorto.SelectedValue = "0"

        ' --------------------------- ---- Clasificacion ---- ---------------------------
        Dim NegocioClasificacion = New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioClasificacion.Consultar(EntidadClasificacion)
        EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        'DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
        'DDClasificacion.DataValueField = "ID"
        'DDClasificacion.DataTextField = "Descripcion"
        'DDClasificacion.DataBind()
        'DDClasificacion.SelectedValue = "-1"

        'ConsultaSubclasificaciones()
    End Sub

    'Protected Sub DDClasificacion_TextChanged(sender As Object, e As EventArgs) Handles DDClasificacion.TextChanged
    '    ' ConsultaSubclasificaciones()
    '    LlenarSolicitudes()
    'End Sub
    'Private Sub ConsultaSubclasificaciones()
    '    Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
    '    Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
    '    If DDClasificacion.SelectedValue = -1 Then
    '        EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
    '    Else
    '        EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaPorId

    '    End If
    '    EntidadSubclasificacion.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
    '    NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
    '    If EntidadSubclasificacion.TablaConsulta.Rows.Count = 0 Then
    '        DDSubclasificacion.Items.Clear()
    '        DDSubclasificacion.Items.Add(New ListItem("TODO", "-1"))
    '    Else
    '        If EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica Then
    '            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, -1, "TODO")
    '        Else
    '            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1, "TODO")
    '        End If
    '        DDSubclasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
    '        DDSubclasificacion.DataValueField = "ID"
    '        DDSubclasificacion.DataTextField = "Descripcion"
    '    End If
    '    DDSubclasificacion.DataBind()
    '    DDSubclasificacion.SelectedValue = "-1"

    'End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
    End Sub

    Public Sub Nuevo()
        IBTCancelar.Visible = False
        IBTImprimir.Visible = False
        TBIdCompra.Text = ""
        DDTipoDocumento.SelectedIndex = 0
        DDFormaPago.SelectedIndex = 0
        TBFolioDocumento.Text = ""
        TBIdCompra.Text = ""
        DDTipoCompraEstado.SelectedValue = 6
        'wucConProv.Nuevo()
        TBObservacion.Text = ""
        TBSerieDocumento.Text = ""
        wucDatosAuditoria1.Nuevo()
        wucDatosAuditoria1.Visible = False

        'TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
        'TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
        TBFechaDocumento.Text = Now.ToString("dd/MM/yyyy")

        'LBTotalCantidades.Text = ""
        'LBTotalPrecioUnitario.Text = ""
        'LBTotalProductos.Text = ""
        'LBTotalTotal.Text = ""

        CBCompraCredito.Checked = False
        TBPLCTotal.Text = String.Format("{0:c}", 0)
        TBPLTotal.Text = String.Format("{0:c}", 0)
        TBPLInteres.Text = "0"
        TBPLCInteres.Text = "0"
        TBCAnticipo.Text = String.Format("{0:c}", 0)
        TBCCargo.Text = String.Format("{0:c}", 0)

        TBPLAbonos.Text = String.Format("{0:c}", 0)
        TBPLCAbonos.Text = String.Format("{0:c}", 0)
        TBPLPeriodos.Text = "0"
        TBPLCPeriodos.Text = "0"

        Saldo = "0"
        Monto = "0"
        Subtotal = "0"
        TotalL = "0"
        TotalC = "0"

        AccordionPane1.Visible = False


        LimpiarDetalle()
        '----------------Para limpiar los Gridview ----------------
        LimpiarTablas()
        '----------------Se vuelven a cargar las solicitudes ----------------
        'LlenarSolicitudes()
    End Sub

    Public Sub LimpiarTablas()
        'limpiar tablas y vistas del detalle
        Try
            '----------------------------------------------------------
            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            TablaOrdenDetalle.Rows.Clear()
            GVOrden.DataBind()
            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle
            '----------------------------------------------------------
            Dim Tabla As New DataTable

            Tabla = CType(Session("TablaCompraDetalle"), DataTable)
            Tabla.Rows.Clear()
            GVConsulta.DataBind()
            Session("Tabla") = Tabla
            '----------------------------------------------------------
            TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
            VistaCompraDetalle = CType(Session("VistaCompraDetalle"), DataView)
            TablaCompraDetalle.Rows.Clear()
            VistaCompraDetalle.Table.Rows.Clear()
            GVCompraDetalle.DataBind()
            Session("TablaCompraDetalle") = TablaCompraDetalle
            Session("VistaCompraDetalle") = VistaCompraDetalle

            TablaMovimientos = CType(Session("TablaMovimientos"), DataTable)
            TablaMovimientos.Rows.Clear()
            Session("TablaMovimientos") = TablaMovimientos

            TablaCredito = CType(Session("TablaCredito"), DataTable)
            TablaCredito.Rows.Clear()
            Session("TablaCredito") = TablaCredito
        Catch ex As Exception
        End Try
        '----------------------------------------------------------
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        IBTImprimir.Visible = True
        Dim listo = True
        Dim NegocioCompra As New Negocio.Compra()
        Dim EntidadCompra As New Entidad.Compra()
        Dim DescripcionCompraDetalle As String = ""
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        TablaMovimientos = CType(Session("TablaMovimientos"), DataTable)
        EntidadCompra.TablaCompraDetalle = TablaCompraDetalle
        EntidadCompra.TablaOrdenDetalle = TablaOrdenDetalle

        For Each MiDataRow As DataRow In EntidadCompra.TablaCompraDetalle.Rows

            If Not IsNumeric(CType(MiDataRow("Cantidad"), String)) Or MiDataRow("Cantidad") = "0" _
                Or Not IsNumeric(CType(MiDataRow("PrecioUnitario"), String)) Or MiDataRow("PrecioUnitario") = "0" Then
                listo = False
            End If
        Next

        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
        'CCP
        Dim NegocioCCP As New Negocio.CCP()
        Dim EntidadCCP As New Entidad.CCP()
        Dim TIdCCP As Integer

        If IdProveedor > 0 And TBFolioDocumento.Text.Length > 0 And listo Then
            EntidadCompra.IdCompra = 0

            If Not TBIdCompra.Text Is String.Empty Then
                EntidadCompra.IdCompra = CInt(TBIdCompra.Text)
            End If
            If EntidadCompra.IdCompra = 0 Then
                'ccp
                EntidadCCP.IdCCP = 0
            Else
                'actualizar ccp
            End If
            'compra/compracredito
            EntidadCompra.IdEstado = 1
            EntidadCompra.FechaDocumento = Comprobacion.ValidaFechaFin(TBFechaDocumento.Text)
            'TBFechaInicio.Text = EntidadCompra.FechaDocumento.ToString("dd/MM/yyyy")
            EntidadCompra.IdFormaPago = CType(DDFormaPago.SelectedValue, Integer)
            EntidadCompra.IdTipoDocumento = CType(DDTipoDocumento.SelectedValue, Integer)
            EntidadCompra.Folio = TBFolioDocumento.Text
            EntidadCompra.Serie = TBSerieDocumento.Text
            EntidadCompra.IdPersona = IdProveedor
            EntidadCompra.Observacion = TBObservacion.Text
            EntidadCompra.Monto = Monto
            EntidadCompra.IVA = 0
            EntidadCompra.SubTotal = Subtotal
            EntidadCompra.Cargo = TBCCargo.Text
            EntidadCompra.Anticipo = TBCAnticipo.Text
            EntidadCompra.Total = TotalL
            If CBCompraCredito.Checked = True Then
                'CompraCredito
                EntidadCompra.TipoCompra = 1
                EntidadCompra.IdPlazoCredito = DDPlazoLimite.SelectedValue
                EntidadCompra.IdPlazoContado = DDPlazoLimiteCorto.SelectedValue
                EntidadCompra.IdPeriodo = DDPeriodo.SelectedValue
                EntidadCompra.NumeroPerdiodosContado = TBPLCPeriodos.Text
                EntidadCompra.NumeroPerdiodosCredito = TBPLPeriodos.Text
                EntidadCompra.ImporteCredito = TBPLAbonos.Text
                EntidadCompra.ImporteContado = TBPLCAbonos.Text
                EntidadCompra.InteresCredito = TBPLInteres.Text
                EntidadCompra.InteresContado = TBPLCInteres.Text
                EntidadCompra.TotalCredito = TotalL
                EntidadCompra.TotalContado = TotalC
                EntidadCompra.FechaVencimientoContado = Comprobacion.ValidaFechaFin(TBPLCFechaFin.Text)
                EntidadCompra.FechaVencimientoCredito = Comprobacion.ValidaFechaFin(TBPLFechaFin.Text)
                'compra a credito
                'CCP
                'MovimientosCCP
                If Not TBCAnticipo.Text Is String.Empty And TBCAnticipo.Text > 0 Then
                    'no vacio
                    Dim RenglonAInsertar As DataRow
                    RenglonAInsertar = TablaMovimientos.NewRow()
                    RenglonAInsertar("IdCCP") = 0
                    RenglonAInsertar("IdTransaccion") = 2
                    RenglonAInsertar("IdTipoDocumento") = CType(DDTipoDocumento.SelectedValue, Integer)
                    RenglonAInsertar("Serie") = TBSerieDocumento.Text
                    RenglonAInsertar("Folio") = TBFolioDocumento.Text
                    RenglonAInsertar("Fecha") = CDate(TBFechaDocumento.Text)
                    RenglonAInsertar("Descripcion") = "Anticipo"
                    RenglonAInsertar("Observacion") = TBObservacion.Text
                    RenglonAInsertar("IdCajaMovimiento") = 0
                    RenglonAInsertar("MontoTransaccion") = CType(TBCAnticipo.Text, Double)
                    RenglonAInsertar("Impuesto") = 0
                    RenglonAInsertar("IdSucursal") = 1
                    RenglonAInsertar("IdEstado") = 7
                    RenglonAInsertar("IdUsuarioCreacion") = 1
                    RenglonAInsertar("FechaCreacion") = CDate(Now)
                    RenglonAInsertar("IdUsuarioActualizacion") = 1
                    RenglonAInsertar("FechaActualizacion") = CDate(Now)
                    TablaMovimientos.Rows.Add(RenglonAInsertar)

                    'EntidadCCP.IdCCPMovimiento = 0
                    'EntidadCCP.MontoTransaccion = TBCAnticipo.Text
                    'EntidadCCP.IdTransaccion = 2
                    'EntidadCCP.IdTipoDocumento = CType(DDTipoDocumento.SelectedValue, Integer)
                    'EntidadCCP.Serie = TBSerieDocumento.Text
                    'EntidadCCP.Folio = TBFolioDocumento.Text
                    'EntidadCCP.FechaExpedicion = Comprobacion.ValidaFechaFin(TBFechaDocumento.Text)
                    'EntidadCCP.Observacion = TBObservacion.Text
                    'EntidadCCP.Descripcion = "Anticipo"
                    'EntidadCCP.IdCajaMovimiento = "0"
                    'EntidadCCP.IdEstado = 1
                    'EntidadCCP.Impuesto = 0
                    'EntidadCCP.IdSucursal = 1
                    ''EntidadCCP.IdCCP = TIdCCP
                    'NegocioCCP.GuardarCCPMovimiento(EntidadCCP)

                End If
                If Not TBCCargo.Text Is String.Empty And TBCCargo.Text > 0 Then
                    'no vacio
                    Dim RenglonAInsertar As DataRow
                    RenglonAInsertar = TablaMovimientos.NewRow()
                    RenglonAInsertar("IdCCP") = 0
                    RenglonAInsertar("IdTransaccion") = 1
                    RenglonAInsertar("IdTipoDocumento") = CType(DDTipoDocumento.SelectedValue, Integer)
                    RenglonAInsertar("Serie") = TBSerieDocumento.Text
                    RenglonAInsertar("Folio") = TBFolioDocumento.Text
                    RenglonAInsertar("Fecha") = CDate(TBFechaDocumento.Text)
                    RenglonAInsertar("Descripcion") = "Cargo"
                    RenglonAInsertar("Observacion") = TBObservacion.Text
                    RenglonAInsertar("IdCajaMovimiento") = 0
                    RenglonAInsertar("MontoTransaccion") = CType(TBCCargo.Text, Double)
                    RenglonAInsertar("Impuesto") = 0
                    RenglonAInsertar("IdSucursal") = 1
                    RenglonAInsertar("IdEstado") = 7
                    RenglonAInsertar("IdUsuarioCreacion") = 1
                    RenglonAInsertar("FechaCreacion") = CDate(Now)
                    RenglonAInsertar("IdUsuarioActualizacion") = 1
                    RenglonAInsertar("FechaActualizacion") = CDate(Now)
                    TablaMovimientos.Rows.Add(RenglonAInsertar)

                    'EntidadCCP.IdCCPMovimiento = 0
                    'EntidadCCP.MontoTransaccion = TBCCargo.Text
                    'EntidadCCP.IdTransaccion = 1
                    'EntidadCCP.IdTipoDocumento = CType(DDTipoDocumento.SelectedValue, Integer)
                    'EntidadCCP.Serie = TBSerieDocumento.Text
                    'EntidadCCP.Folio = TBFolioDocumento.Text
                    'EntidadCCP.FechaExpedicion = Comprobacion.ValidaFechaFin(TBFechaDocumento.Text)
                    'EntidadCCP.Observacion = TBObservacion.Text
                    'EntidadCCP.Descripcion = "Cargo"
                    'EntidadCCP.IdCajaMovimiento = "0"
                    'EntidadCCP.IdEstado = 1
                    'EntidadCCP.Impuesto = 0
                    'EntidadCCP.IdSucursal = 1
                    'EntidadCCP.IdCCP = TIdCCP
                    'NegocioCCP.GuardarCCPMovimiento(EntidadCCP)
                End If
                EntidadCCP.TablaMovimientos = TablaMovimientos
                'MovimientosCCP
                EntidadCCP.IdTipoDocumento = CType(DDTipoDocumento.SelectedValue, Integer)
                EntidadCCP.Serie = TBSerieDocumento.Text
                EntidadCCP.Folio = TBFolioDocumento.Text
                EntidadCCP.IdPersona = IdProveedor
                EntidadCCP.FechaExpedicion = Comprobacion.ValidaFechaFin(TBFechaDocumento.Text)
                EntidadCCP.FechaVencimiento = Comprobacion.ValidaFechaFin(TBPLFechaFin.Text)
                EntidadCCP.Observacion = TBObservacion.Text
                For Each MiDataRow As DataRow In TablaCompraDetalle.Rows
                    DescripcionCompraDetalle += MiDataRow.Item("Producto") + " "
                Next
                If DescripcionCompraDetalle.Length > 50 Then
                    EntidadCCP.Descripcion = DescripcionCompraDetalle.Substring(0, 50)
                Else
                    EntidadCCP.Descripcion = DescripcionCompraDetalle
                End If

                EntidadCCP.IdEstado = 4
                EntidadCCP.Monto = Monto
                EntidadCCP.IVA = 0
                EntidadCCP.IEPS = 0
                EntidadCCP.Subtotal = TotalL
                EntidadCCP.IdTipoCCP = 2
                NegocioCCP.GuardarCCP(EntidadCCP)
                TIdCCP = EntidadCCP.IdCCP
                'CCP

                EntidadCompra.IdCompraCCP = TIdCCP
            End If
            'CompraCredito
            If CBCompraCredito.Checked = False Then
                EntidadCompra.TipoCompra = 2
            End If
            EntidadCompra.TipoCompraEstado = DDTipoCompraEstado.SelectedValue '6

            NegocioCompra.Guardar(EntidadCompra)
            TBIdCompra.Text = CStr(EntidadCompra.IdCompra)

            MetodoImprimir()
            Call BTNImprimir_Click(sender, e)
        Else
            'Mostrar mensaje de proveedor incorrecto
        End If

    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        LlenarDDsFiltros()
        Try
            Dim Tabla = CType(Session("Tabla"), DataTable)
            Tabla.Rows.Clear()
            GVConsulta.DataBind()
            Session("Tabla") = Tabla
        Catch ex As Exception
        End Try
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
        Try
            MultiView1.SetActiveView(View1)
        Catch ex As Exception
            Response.Redirect("~\Default.aspx")
        End Try
    End Sub

    Protected Sub GVConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsulta.SelectedIndexChanged

        Dim NegocioCompraDetalle As New Negocio.Compra()
        Dim EntidadCompraDetalle As New Entidad.Compra()
        Dim Tabla As New DataTable
        Tabla = CType(Session("Tabla"), DataTable)
        Dim NegocioCompraCredito As New Negocio.Compra()
        Dim EntidadCompraCredito As New Entidad.Compra()
        IBTCancelar.Visible = True
        DDTipoDocumento.SelectedValue = CType(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdTipoDocumento"), String)
        DDFormaPago.SelectedValue = CType(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdFormaPago"), String)
        TBFolioDocumento.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Serie"))
        TBFolioDocumento.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Folio"))
        TBFechaDocumento.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("FechaDocumento"))
        TBIdCompra.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdCompra"))

        wucConProv.AsignarPersona(CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Equivalencia")), CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("RazonSocial")))

        TBObservacion.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Observacion"))
        TBSerieDocumento.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Serie"))
        Monto = CDbl(Tabla.Rows(GVConsulta.SelectedIndex).Item("Monto"))
        TBCAnticipo.Text = CDbl(Tabla.Rows(GVConsulta.SelectedIndex).Item("Anticipo"))
        TBCCargo.Text = CDbl(Tabla.Rows(GVConsulta.SelectedIndex).Item("Cargos"))
        FechaCreacion = Tabla.Rows(GVConsulta.SelectedIndex).Item("FechaCreacion")
        DDTipoCompraEstado.SelectedValue = Tabla.Rows(GVConsulta.SelectedIndex).Item("TipoCompraEstado")
        TipoCompraEstado = Tabla.Rows(GVConsulta.SelectedIndex).Item("TipoCompraEstado")
        Session("FechaCreacion") = FechaCreacion
        Session("TipoCompraEstado") = TipoCompraEstado

        If CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("TipoCompra")) = 1 Then
            CBCompraCredito.Checked = True
            AccordionPane1.Visible = True
        End If
        If CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("TipoCompra")) = 2 Then
            CBCompraCredito.Checked = False
            AccordionPane1.Visible = False
        End If
        Subtotal = CDbl(Tabla.Rows(GVConsulta.SelectedIndex).Item("SubTotal"))





        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVConsulta.SelectedIndex))
        wucDatosAuditoria1.Visible = True

        LlenarSolicitudes()

        '======================================== Orden Detalle ===========================================
        Dim TablaCompraDetalle As New DataTable
        EntidadCompraDetalle.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadCompraDetalle.IdCompra = CType(TBIdCompra.Text, Integer)
        NegocioCompraDetalle.Obtener(EntidadCompraDetalle)

        TablaCompraDetalle = EntidadCompraDetalle.TablaCompraDetalle
        VistaCompraDetalle = TablaCompraDetalle.DefaultView

        Session("TablaCompraDetalle") = TablaCompraDetalle
        Session("VistaCompraDetalle") = VistaCompraDetalle

        GVCompraDetalle.DataSource = VistaCompraDetalle
        GVCompraDetalle.DataBind()

        DDDestino.SelectedValue = TablaCompraDetalle.Rows(0).Item("IdAlmacen")
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index2).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index2).Item("PrecioUnitario")
        Next

        MultiView1.SetActiveView(View1)
        'CompraCredito
        If CBCompraCredito.Checked = True Then
            EntidadCompraCredito.IdCompra = TBIdCompra.Text
            NegocioCompraCredito.ConsultarCredito(EntidadCompraCredito)
            Tabla = EntidadCompraCredito.TablaConsulta
            TBPLInteres.Text = CInt(Tabla.Rows(0).Item("InteresCredito"))
            TBPLCInteres.Text = CInt(Tabla.Rows(0).Item("InteresContado"))
            DDPeriodo.SelectedValue = CInt(Tabla.Rows(0).Item("IdPeriodo"))
            If DDPeriodo.SelectedValue > 0 Then
                RBFechaLimite.Checked = False
                RBPagoPeriodos.Checked = True
                TRPeriodos.Visible = True
                PeriodosPlazoLimiteCorto.Visible = True
                PeriodosPlazoLimite.Visible = True
            End If
            If DDPeriodo.SelectedValue = 0 Then
                RBPagoPeriodos.Checked = False
                RBFechaLimite.Checked = True
                TRPeriodos.Visible = False
                PeriodosPlazoLimiteCorto.Visible = False
                PeriodosPlazoLimite.Visible = False
                TBPLCPeriodos.Text = 0
                TBPLPeriodos.Text = 0
                DDPeriodo.SelectedValue = 0
            End If
            DDPlazoLimite.SelectedValue = CInt(Tabla.Rows(0).Item("IdPlazoCredito"))
            DDPlazoLimiteCorto.SelectedValue = CInt(Tabla.Rows(0).Item("IdPlazoContado"))
            Session("TablaCredito") = Tabla
        End If

        IBTImprimir.Visible = True
        'CalcularTotales()
        MuestraTotales()
        CalcularPeriodosAbonos()
    End Sub

#Region "Orden Detalle========================================================================="


    Protected Sub Wucs()
        wucConsultarProducto1.BusquedaProducto()
        wucConsultarProducto1.RegresarFoco()
    End Sub

    Protected Sub BTNEliminarIdSolicitud_Click(sender As Object, e As EventArgs) Handles BTNEliminarDetalle.Click
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        VistaCompraDetalle = CType(Session("VistaCompraDetalle"), DataView)

        'actualizar renglon
        Dim Renglon As Integer = GVCompraDetalle.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            Try
                If VistaCompraDetalle(Renglon).Item("IdCompraDetalle") = 0 Then
                    VistaCompraDetalle(Renglon).Delete()
                Else
                    VistaCompraDetalle(Renglon).Item("IdActualizar") = 1 'Si   
                    VistaCompraDetalle(Renglon).Item("IdEstado") = 2
                    VistaCompraDetalle(Renglon).Item("Estado") = "INACTIVO"
                End If
            Catch ex As InvalidCastException
                VistaCompraDetalle(Renglon).Delete()
            End Try

            Session("TablaCompraDetalle") = TablaCompraDetalle
            Session("VistaCompraDetalle") = VistaCompraDetalle
            GVCompraDetalle.DataSource = VistaCompraDetalle
            GVCompraDetalle.DataBind()

            'limpiar controles 
            LimpiarDetalle()
        End If
    End Sub

    Protected Sub BTNCancelarIdSolicitud_Click(sender As Object, e As EventArgs) Handles BTNCancelarDetalle.Click
        LimpiarDetalle()
    End Sub

    Private Sub LimpiarDetalle()
        'wucConsultarProducto1.Nuevo()

        TBCantidadDetalle.Text = ""
        TBPrecioUnitario.Text = ""

        DDAlmacen.SelectedIndex = 0
        GVCompraDetalle.SelectedIndex = -1
        BTNEliminarDetalle.Enabled = False
        ControlRegistro(False)





    End Sub

    Private Sub MuestraTotales()
        'LBTotalCantidades.Text = "0"
        'LBTotalPrecioUnitario.Text = Format(0, Formato.Moneda)
        'LBTotalTotal.Text = Format(0, Formato.Moneda)
        'If GVCompraDetalle.Rows.Count > 0 Then
        '    LBTotalProductos.Text = CStr(GVCompraDetalle.Rows.Count)
        '    Dim i As Integer = GVCompraDetalle.Rows.Count - 1
        '    While i > -1 And i < GVCompraDetalle.Rows.Count
        '        LBTotalCantidades.Text = CStr(CInt(LBTotalCantidades.Text) + CInt(GVCompraDetalle.Rows(i).Cells(3).Text))
        '        LBTotalPrecioUnitario.Text = Format(CInt(LBTotalPrecioUnitario.Text) + CInt(GVCompraDetalle.Rows(i).Cells(4).Text), Formato.Moneda)
        '        LBTotalTotal.Text = Format(CInt(LBTotalTotal.Text) + CInt(GVCompraDetalle.Rows(i).Cells(5).Text), Formato.Moneda)
        '        i -= 1
        '    End While
        'End If
        'Dim Index As Integer
        'For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
        '    Index = Convert.ToUInt64(MiDataRow2.RowIndex)
        '    Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
        '    CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("Cantidad")
        '    CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("PrecioUnitario")
        'Next

        If GVCompraDetalle.Rows.Count > 0 Then
            Dim Canti As Integer
            Dim PrecioUnitario As Decimal
            Dim TotalCN As Decimal
            Dim i As Integer = GVCompraDetalle.Rows.Count - 1
            While i > -1 And i < GVCompraDetalle.Rows.Count


                'Canti = CStr(CInt(Canti) + CInt(GVCompraDetalle.Rows(i).Cells(3).Text))
                Canti = CStr(CInt(Canti) + CInt(CType(GVCompraDetalle.Rows(i).FindControl("TBGVCantidad"), TextBox).Text))
                PrecioUnitario = Format(CInt(PrecioUnitario) + CInt(CType(GVCompraDetalle.Rows(i).FindControl("TBGVPrecioUnitario"), TextBox).Text), Formato.Moneda) 'CELDA DE PRECIO UNITARIO ESTABA = 4
                TotalCN = Format(CInt(TotalCN) + CInt(GVCompraDetalle.Rows(i).Cells(5).Text), Formato.Moneda) 'ESTABA EN 5
                i -= 1
            End While
            Monto = TotalCN
        End If
        CalcularTotales()
        CalcularPeriodosAbonos()
    End Sub
#End Region

    Private Sub ComprarOrden()
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        VistaCompraDetalle = CType(Session("VistaCompraDetalle"), DataView)

        Dim RenglonAInsertar As DataRow
        RenglonAInsertar = TablaCompraDetalle.NewRow()
        RenglonAInsertar("IdOrdenDetalle") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IdOrdenDetalle"), String)
        RenglonAInsertar("IdCompra") = 0

        RenglonAInsertar("IdProducto") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IdProducto"), Integer)
        RenglonAInsertar("IdProductoCorto") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IdProductoCorto"), String)
        RenglonAInsertar("Producto") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("Producto"), String)

        RenglonAInsertar("Cantidad") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("Cantidad"), String)
        RenglonAInsertar("PrecioUnitario") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("PrecioUnitario"), String)

        RenglonAInsertar("PorcentajeIva") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("PorcentajeIva"), String)
        RenglonAInsertar("Subtotal") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("Subtotal"), String)
        RenglonAInsertar("IVA") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IVA"), String)
        RenglonAInsertar("Total") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("Total"), String)

        RenglonAInsertar("IdTipoPrioridad") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IdTipoPrioridad"), String)
        RenglonAInsertar("TipoPrioridad") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("TipoPrioridad"), String)
        RenglonAInsertar("IdTipoSolicitudEstado") = 6
        RenglonAInsertar("TipoSolicitudEstado") = "COMPRADO"
        RenglonAInsertar("IdAlmacen") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IdAlmacen"), String)
        RenglonAInsertar("Almacen") = CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("Almacen"), String)
        RenglonAInsertar("IdSucursal") = 1

        RenglonAInsertar("IdUnidad") = 1
        RenglonAInsertar("Descripcion") = ""

        RenglonAInsertar("IdEstado") = 1
        RenglonAInsertar("IdActualizar") = 1
        RenglonAInsertar("Estado") = "ACTIVO"
        RenglonAInsertar("IdUsuarioCreacion") = 1
        RenglonAInsertar("FechaCreacion") = CDate(Now)
        RenglonAInsertar("IdUsuarioActualizacion") = 1
        RenglonAInsertar("FechaActualizacion") = CDate(Now)

        TablaCompraDetalle.Rows.Add(RenglonAInsertar)

        Session("TablaCompraDetalle") = TablaCompraDetalle
        Session("VistaCompraDetalle") = VistaCompraDetalle
        GVCompraDetalle.DataSource = VistaCompraDetalle
        GVCompraDetalle.DataBind()

        'ACTUALIZA LA SOLICITUD
        VistaOrdenDetalle(GVOrden.SelectedIndex).Item("TipoSolicitudEstado") = "COMPRADO"
        VistaOrdenDetalle(GVOrden.SelectedIndex).Item("IdTipoSolicitudEstado") = 6

        Session("TablaOrdenDetalle") = TablaOrdenDetalle
        Session("VistaOrdenDetalle") = VistaOrdenDetalle
        'VistaOrdenDetalle = TablaOrdenDetalle.DefaultView
        VistaOrdenDetalle.RowFilter = "IdTipoSolicitudEstado=3"
        GVOrden.DataSource = VistaOrdenDetalle
        GVOrden.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("PrecioUnitario")
        Next
    End Sub

    Protected Sub GVCompraDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles GVCompraDetalle.SelectedIndexChanged
    End Sub

    Protected Sub BTNOrdenarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        If GVOrden.Rows.Count > 0 Then
            Dim i As Integer = GVOrden.Rows.Count - 1
            While i > -1 And i < GVOrden.Rows.Count
                GVOrden.SelectedIndex = i
                ComprarOrden()
                MuestraTotales()
                i -= 1
            End While
        End If
    End Sub

    Protected Sub BTNOrdenar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVOrden.SelectedIndex = gvrFilaActual.RowIndex
        ComprarOrden()
        MuestraTotales()
    End Sub

    Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        'Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        'GVCompraDetalle.SelectedIndex = gvrFilaActual.RowIndex

        'TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)

        ''wucConsultarProducto1.AsignarProducto(CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("IdProducto"), Integer),
        ''CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("IdProductoCorto"), String),
        ''CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("Producto"), String))

        'TBCantidadDetalle.Text = CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("Cantidad"), String)
        'TBPrecioUnitario.Text = CDbl(CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("PrecioUnitario"), String))
        'DDAlmacen.SelectedValue = CType(TablaCompraDetalle.Rows(GVCompraDetalle.SelectedIndex).Item("IdAlmacen"), String)

        'BTNEliminarDetalle.Enabled = True
        'ControlRegistro(True)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim Renglon As Integer = gvrFilaActual.RowIndex
        TablaCompraDetalle = Session("TablaCompraDetalle")
        VistaCompraDetalle = Session("VistaCompraDetalle")
        If Renglon > -1 Then
            Try
                If VistaCompraDetalle(Renglon).Item("IdCompraDetalle") = 0 Then
                    VistaCompraDetalle(Renglon).Delete()
                Else
                    VistaCompraDetalle(Renglon).Item("IdActualizar") = 1 'Si   
                    VistaCompraDetalle(Renglon).Item("IdEstado") = 2
                    VistaCompraDetalle(Renglon).Item("Estado") = "INACTIVO"
                End If
            Catch ex As InvalidCastException
                VistaCompraDetalle(Renglon).Delete()
            End Try

            Session("TablaCompraDetalle") = TablaCompraDetalle
            Session("VistaCompraDetalle") = VistaCompraDetalle
            GVCompraDetalle.DataSource = VistaCompraDetalle
            GVCompraDetalle.DataBind()

            Dim Index As Integer
            For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("Cantidad")
                CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index).Item("PrecioUnitario")
            Next
            CalcularTotales()
            CalcularPeriodosAbonos()
        End If
    End Sub
    Private Sub ControlRegistro(control As Boolean)
        If control Then
            'PARegistroDetalle.Visible = True
            GVCompraDetalle.Visible = True
        Else
            ' PARegistroDetalle.Visible = False
            GVCompraDetalle.Visible = True
        End If
    End Sub
    Protected Sub BTNCompraDetalle_Click(sender As Object, e As EventArgs)
        LimpiarDetalle()
        ControlRegistro(True)
    End Sub
    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click

        Dim NegocioOrdenCompra As New Negocio.Compra()
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        Dim Tabla As New DataTable
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = CType(IIf(IsNumeric(TBOrdenFiltro.Text), TBOrdenFiltro.Text, -1), Integer)
        EntidadOrdenCompra.IdClasificacion = CType(DDProveedorFiltro.SelectedValue, Integer) '' para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = CType(DDTipoDocumentoFiltro.SelectedValue, Integer) '' para usarse com+o IdTipoDocumento
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicioFiltro.Text)
        EntidadOrdenCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFinFiltro.Text)
        TBFechaInicioFiltro.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioOrdenCompra.ConsultarFiltro(EntidadOrdenCompra)
        Tabla = EntidadOrdenCompra.TablaConsulta
        GVConsulta.Columns.Clear()
        GVConsulta.DataSource = Tabla
        GVConsulta.AutoGenerateColumns = False
        GVConsulta.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsulta.Columns.Add(Columna)
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "ID", "IdCompra")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Proveedor", "Proveedor")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Documento", "TipoDocumento")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Observacion", "Observacion")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Usuario", "UsuarioActualizacion")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Fecha", "FechaActualizacion")
        GVConsulta.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Private Sub LlenarDDsFiltros()

        TBFechaInicioFiltro.Text = "01/01/1900"
        TBFechaFinFiltro.Text = Now.ToString("dd/MM/yyyy")


        ' --------------------------- ---- Tipo Prioridad ---- ---------------------------
        Dim NegocioTipoDocumento = New Negocio.TipoDocumento()
        Dim EntidadTipoDocumento As New Entidad.TipoDocumento()
        EntidadTipoDocumento.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoDocumento.Consultar(EntidadTipoDocumento)
        EntidadTipoDocumento.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        DDTipoDocumentoFiltro.DataSource = EntidadTipoDocumento.TablaConsulta
        DDTipoDocumentoFiltro.DataValueField = "ID"
        DDTipoDocumentoFiltro.DataTextField = "Descripcion"
        DDTipoDocumentoFiltro.DataBind()
        DDTipoDocumentoFiltro.SelectedValue = "-1"

        ' --------------------------- ---- Proveedores cuando estaban en persona ---- ---------------------------
        'Dim NegocioProveedorEstado = New Negocio.Persona()
        'Dim EntidadProveedorEstado As New Entidad.Persona()
        'EntidadProveedorEstado.Tarjeta.Consulta = Consulta.ConsultaProveedor
        'NegocioProveedorEstado.Consultar(EntidadProveedorEstado)
        'EntidadProveedorEstado.TablaConsulta.Rows.Add(-1, "TODO")
        'DDProveedorFiltro.DataSource = EntidadProveedorEstado.TablaConsulta
        'DDProveedorFiltro.DataValueField = "ID"
        'DDProveedorFiltro.DataTextField = "Descripcion"
        'DDProveedorFiltro.DataBind()
        'DDProveedorFiltro.SelectedValue = "-1"


        Dim NegocioProveedor = New Negocio.Proveedor()
        Dim EntidadProveedor As New Entidad.Proveedor()
        EntidadProveedor.Tarjeta.Consulta = Consulta.ConsultaPorFiltro
        NegocioProveedor.Consultar(EntidadProveedor)

        DDProveedorFiltro.DataSource = EntidadProveedor.TablaConsulta
        DDProveedorFiltro.DataValueField = "ID"
        DDProveedorFiltro.DataTextField = "RazonSocial"
        EntidadProveedor.TablaConsulta.Rows.Add(-1, "TODO")
        DDProveedorFiltro.SelectedValue = "-1"
        DDProveedorFiltro.DataBind()

    End Sub

    Protected Sub BTNConsultarOrdenes_Click(sender As Object, e As EventArgs) Handles BTNConsultarOrdenes.Click
        LlenarSolicitudes()
    End Sub

    Protected Sub BTNPerfil_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVCompraDetalle.SelectedIndex = gvrFilaActual.RowIndex
        VistaCompraDetalle = CType(Session("VistaCompraDetalle"), DataView)

        wucConsultarProductoPerfil1.Abrir(CType(VistaCompraDetalle.Item(GVCompraDetalle.SelectedIndex).Item("IdProducto"), Integer),
                                          "Perfil del Producto: " + CType(VistaCompraDetalle.Item(GVCompraDetalle.SelectedIndex).Item("Producto"), String))

    End Sub
    Protected Sub BTNPerfil2_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVOrden.SelectedIndex = gvrFilaActual.RowIndex
        VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)

        wucConsultarProductoPerfil1.Abrir(CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("IdProducto"), Integer),
                                          "Perfil del Producto: " + CType(VistaOrdenDetalle.Item(GVOrden.SelectedIndex).Item("Producto"), String))

    End Sub

    Protected Sub CBCompraCredito_CheckedChanged(sender As Object, e As EventArgs) Handles CBCompraCredito.CheckedChanged
        If CBCompraCredito.Checked = True Then
            AccordionPane1.Visible = True
        Else
            AccordionPane1.Visible = False
        End If
    End Sub
    Protected Sub RBPagoPeriodos_CheckedChanged(sender As Object, e As EventArgs) Handles RBPagoPeriodos.CheckedChanged
        TRPeriodos.Visible = True
        PeriodosPlazoLimiteCorto.Visible = True
        PeriodosPlazoLimite.Visible = True
        CalcularPeriodosAbonos()
    End Sub
    Protected Sub RBFechaLimite_CheckedChanged(sender As Object, e As EventArgs) Handles RBFechaLimite.CheckedChanged
        TRPeriodos.Visible = False
        PeriodosPlazoLimiteCorto.Visible = False
        PeriodosPlazoLimite.Visible = False
        TBPLCPeriodos.Text = 0
        TBPLPeriodos.Text = 0
        DDPeriodo.SelectedValue = 0
        CalcularPeriodosAbonos()
    End Sub

    Protected Sub TBFechaDocumento_TextChanged(sender As Object, e As EventArgs) Handles TBFechaDocumento.TextChanged
        TBPLFechaInicio.Text = TBFechaDocumento.Text
        TBPLCFechaInicio.Text = TBFechaDocumento.Text
        CalcularPeriodosAbonos()
    End Sub
    Protected Sub DDPlazoLimite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDPlazoLimite.SelectedIndexChanged
        CalcularPeriodosAbonos()

    End Sub
    Protected Sub DDPlazoLimiteCorto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDPlazoLimiteCorto.SelectedIndexChanged
        CalcularPeriodosAbonos()


    End Sub
    Protected Sub DDPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDPeriodo.SelectedIndexChanged
        CalcularPeriodosAbonos()
    End Sub
    Protected Sub TBPLInteres_TextChanged(sender As Object, e As EventArgs) Handles TBPLInteres.TextChanged

        CalcularTotales()
        CalcularPeriodosAbonos()
        TBPLTotal.Text = String.Format("{0:c}", TotalL)
    End Sub
    Protected Sub TBPLCInteres_TextChanged(sender As Object, e As EventArgs) Handles TBPLCInteres.TextChanged
        CalcularTotales()
        CalcularPeriodosAbonos()
        TBPLCTotal.Text = String.Format("{0:c}", TotalC)

    End Sub
    Protected Sub TBCCargo_TextChanged(sender As Object, e As EventArgs) Handles TBCCargo.TextChanged
        CalcularTotales()
    End Sub
    Private Sub CalcularTotales()
        If TBCCargo.Text Is String.Empty Then
            TBCCargo.Text = String.Format("{0:c}", 0)
        End If
        If TBCAnticipo.Text Is String.Empty Then
            TBCAnticipo.Text = String.Format("{0:c}", 0)
        End If
        If TBPLInteres.Text Is String.Empty Then
            TBPLInteres.Text = String.Format("{0:c}", 0)
        End If
        If TBPLCInteres.Text Is String.Empty Then
            TBPLCInteres.Text = String.Format("{0:c}", 0)
        End If
        'IVa
        Subtotal = Monto * (1 + 0)
        'Intereses
        TotalL = Subtotal * (1 + (TBPLInteres.Text / 100))
        TotalC = Subtotal * (1 + (TBPLCInteres.Text / 100))

        TBPLTotal.Text = String.Format("{0:c}", TotalL)
        TBPLCTotal.Text = String.Format("{0:c}", TotalC)
        'Saldo
        Saldo = TotalL
        'Cargo
        Saldo = Saldo + CDbl(TBCCargo.Text)
        'Anticipo
        Saldo = Saldo - CDbl(TBCAnticipo.Text)

    End Sub
    Private Sub CalcularPeriodosAbonos()
        Dim CantPeriodo As Integer
        If DDPeriodo.SelectedValue = 1 Then
            CantPeriodo = 7
        End If
        If DDPeriodo.SelectedValue = 2 Then
            CantPeriodo = 15
        End If
        If DDPeriodo.SelectedValue = 3 Then
            CantPeriodo = 30
        End If
        If DDPeriodo.SelectedValue = 4 Then
            CantPeriodo = 360
        End If
        If DDPeriodo.SelectedValue > 0 Then
            TBPLFechaFin.Text = Convert.ToDateTime(TBPLFechaInicio.Text).AddMonths(DDPlazoLimite.SelectedValue).ToString("dd/MM/yyyy")
            TBPLPeriodos.Text = CInt((30 * DDPlazoLimite.SelectedValue) / CantPeriodo)
            TBPLAbonos.Text = String.Format("{0:c}", (CInt(TBPLTotal.Text) / CInt(TBPLPeriodos.Text)))

            If DDPlazoLimiteCorto.SelectedValue > 0 Then
                TBPLCFechaFin.Text = Convert.ToDateTime(TBPLCFechaInicio.Text).AddMonths(DDPlazoLimiteCorto.SelectedValue).ToString("dd/MM/yyyy")
                TBPLCPeriodos.Text = CInt((30 * DDPlazoLimiteCorto.SelectedValue) / CantPeriodo)
                TBPLCAbonos.Text = String.Format("{0:c}", (CInt(TBPLCTotal.Text) / CInt(TBPLCPeriodos.Text)))
            End If
            If DDPlazoLimiteCorto.SelectedValue < 0 Then
                TBPLCFechaFin.Text = Convert.ToDateTime(TBPLCFechaInicio.Text).ToString("dd/MM/yyyy")
                TBPLCPeriodos.Text = 0
            End If
        End If
        If DDPeriodo.SelectedValue = 0 Then
            TBPLFechaFin.Text = Convert.ToDateTime(TBPLFechaInicio.Text).AddMonths(DDPlazoLimite.SelectedValue).ToString("dd/MM/yyyy")
            TBPLPeriodos.Text = 0
            TBPLAbonos.Text = String.Format("{0:c}", 0)

            If DDPlazoLimiteCorto.SelectedValue > 0 Then
                TBPLCFechaFin.Text = Convert.ToDateTime(TBPLCFechaInicio.Text).AddMonths(DDPlazoLimiteCorto.SelectedValue).ToString("dd/MM/yyyy")
                TBPLCPeriodos.Text = 0
                TBPLCAbonos.Text = String.Format("{0:c}", 0)
            End If
            If DDPlazoLimiteCorto.SelectedValue < 0 Then
                TBPLCFechaFin.Text = Convert.ToDateTime(TBPLCFechaInicio.Text).ToString("dd/MM/yyyy")
                TBPLCPeriodos.Text = 0
                TBPLCAbonos.Text = String.Format("{0:c}", 0)
            End If
        End If


    End Sub
    Protected Sub TBCAnticipo_TextChanged(sender As Object, e As EventArgs) Handles TBCAnticipo.TextChanged
        CalcularTotales()
    End Sub
    Protected Sub MetodoImprimir()
        If GVCompraDetalle.Rows.Count > 0 Then
            MultiView1.SetActiveView(Imprimir)
            TablaCompraDetalle = Session("TablaCompraDetalle")
            LIdCompra.Text = TBIdCompra.Text
            LTipoDocumento.Text = DDTipoDocumento.SelectedItem.Text
            LSerieDocumento.Text = TBSerieDocumento.Text
            LFolioDocumento.Text = TBFolioDocumento.Text
            LFechaDocumento.Text = TBFechaDocumento.Text
            LFormaPago.Text = DDFormaPago.SelectedItem.Text
            Dim IdProveedor = 0
            Dim IdEquivalencia = ""
            Dim Nombre = ""

            wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
            'LIdProveedor.Text = IdProveedor.ToString()
            LNombreProveedor.Text = Nombre
            LObservacion.Text = TBObservacion.Text
            LCargos.Text = TBCCargo.Text
            LAnticipo.Text = TBCAnticipo.Text

            GVCompraProducto.Columns.Clear()
            GVCompraProducto.DataSource = TablaCompraDetalle
            GVCompraProducto.AutoGenerateColumns = False
            GVCompraProducto.AllowSorting = True
            GVCompraProducto.Visible = True
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Codigo", "IdProductoCorto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Producto", "Producto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Cantidad", "Cantidad")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Precio Unitario", "PrecioUnitario")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Total", "Total")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Destino", "Almacen")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVCompraProducto, New BoundField(), "Estado Solicitud", "TipoSolicitudEstado")
            GVCompraProducto.DataBind()

            GVCompraProducto.UseAccessibleHeader = True
            GVCompraProducto.HeaderRow.TableSection = TableRowSection.TableHeader

        End If
    End Sub
    Protected Sub IBTImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTImprimir.Click
        MetodoImprimir()
        Call BTNImprimir_Click(sender, e)
    End Sub
    Protected Sub BTNImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles BTNImprimir.Click
        Dim cstype As Type = Me.GetType()
        ''imprSelec('TablaEncabezado','TablaImprimir');
        'ClientScript.RegisterStartupScript(cstype, "ejecutar script", "window.print()", True)
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "scriptkey", "window.print();", True)
    End Sub
    Protected Sub BTIRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BTIRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click

        IBTImprimir.Visible = True
        Dim listo = True
        Dim NegocioCompra As New Negocio.Compra()
        Dim EntidadCompra As New Entidad.Compra()
        Dim DescripcionCompraDetalle As String = ""
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        'TablaMovimientos = CType(Session("TablaMovimientos"), DataTable)
        TablaCredito = CType(Session("TablaCredito"), DataTable)
        FechaCreacion = Session("FechaCreacion")
        TipoCompraEstado = Session("TipoCompraEstado")
        EntidadCompra.TablaCompraDetalle = TablaCompraDetalle
        EntidadCompra.TablaOrdenDetalle = TablaOrdenDetalle
        Dim diferencia As Integer = DateDiff("D", FechaCreacion, Now)

        If diferencia = 0 And TipoCompraEstado <> 5 Then
            For Each MiDataRow As DataRow In EntidadCompra.TablaCompraDetalle.Rows

                If Not IsNumeric(CType(MiDataRow("Cantidad"), String)) Or MiDataRow("Cantidad") = "0" _
                    Or Not IsNumeric(CType(MiDataRow("PrecioUnitario"), String)) Or MiDataRow("PrecioUnitario") = "0" Then
                    listo = False
                End If
            Next
            Dim IdProveedor = 0
            Dim IdEquivalencia = ""
            Dim Nombre = ""

            wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
            'CCP
            Dim NegocioCCP As New Negocio.CCP()
            Dim EntidadCCP As New Entidad.CCP()
            'Dim TIdCCP As Integer

            If IdProveedor > 0 And TBFolioDocumento.Text.Length > 0 And listo Then
                EntidadCompra.IdCompra = CInt(TBIdCompra.Text)

                'compra/compracredito
                EntidadCompra.IdEstado = 1
                EntidadCompra.FechaDocumento = Comprobacion.ValidaFechaFin(TBFechaDocumento.Text)
                'TBFechaInicio.Text = EntidadCompra.FechaDocumento.ToString("dd/MM/yyyy")
                EntidadCompra.IdFormaPago = CType(DDFormaPago.SelectedValue, Integer)
                EntidadCompra.IdTipoDocumento = CType(DDTipoDocumento.SelectedValue, Integer)
                EntidadCompra.Folio = TBFolioDocumento.Text
                EntidadCompra.Serie = TBSerieDocumento.Text
                EntidadCompra.IdPersona = IdProveedor
                EntidadCompra.Observacion = TBObservacion.Text
                EntidadCompra.Monto = Monto
                EntidadCompra.IVA = 0
                EntidadCompra.SubTotal = Subtotal
                EntidadCompra.Cargo = TBCCargo.Text
                EntidadCompra.Anticipo = TBCAnticipo.Text
                EntidadCompra.Total = TotalL

                If CBCompraCredito.Checked = True Then
                    EntidadCCP.IdCCP = TablaCredito.Rows(0).Item("IdCCP")
                    EntidadCCP.IdCompra = TablaCredito.Rows(0).Item("IdCompra")
                    NegocioCCP.CancelarCCP(EntidadCCP)
                    'TIdCCP = EntidadCCP.IdCCP
                    'CCP
                    'EntidadCompra.IdCompraCCP = TIdCCP
                End If
                'si no es credito
                If CBCompraCredito.Checked = False Then
                    EntidadCompra.TipoCompra = 2
                Else
                    EntidadCompra.TipoCompra = 1
                End If
                EntidadCompra.TipoCompraEstado = 5  ' Estado Cancelado
                NegocioCompra.Cancelar(EntidadCompra)
                TBIdCompra.Text = CStr(EntidadCompra.IdCompra)
            Else
                'Mostrar mensaje de proveedor incorrecto
            End If
            MultiView1.SetActiveView(View2)
            Nuevo()
        End If

    End Sub
    Protected Sub IMBackorder_Click(sender As Object, e As ImageClickEventArgs) Handles IMBackorder.Click
        MultiView1.SetActiveView(BackOrder)
        Dim NegocioSolicitudCompra As New Negocio.OrdenCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        Dim TablaSolicitudDetalle As New DataTable()
        EntidadSolicitudCompra.IdProceso = -1
        EntidadSolicitudCompra.IdAlmacen = -1
        EntidadSolicitudCompra.IdClasificacion = -1
        EntidadSolicitudCompra.IdSubclasificacion = -1
        EntidadSolicitudCompra.IdTipoPrioridad = -1
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = -1
        EntidadSolicitudCompra.FechaInicio = "01/01/2016"
        EntidadSolicitudCompra.FechaFin = "01/12/2016"
        NegocioSolicitudCompra.ObtenerSolicitudCompraAutorizada(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta

        GVBackOrder.Columns.Clear()
        GVBackOrder.DataSource = TablaSolicitudDetalle
        GVBackOrder.AutoGenerateColumns = False
        GVBackOrder.AllowSorting = True
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Ver Detalle"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "ID", "IdSolicitud")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "ID Detalle", "IdSolicitudDetalle")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Codigo", "IdProductoCorto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Producto", "Producto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Cantidad", "Cantidad")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Destino", "Almacen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Estado", "TipoSolicitudEstado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Prioridad", "TipoPrioridad")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Usuario", "Usuario")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVBackOrder, New BoundField(), "Fecha", "Fecha")
        GVBackOrder.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
    End Sub
    Protected Sub BTNRegresarBackOrder_Click(sender As Object, e As ImageClickEventArgs) Handles BTNRegresarBackOrder.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub GVICantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBCantidad1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBCantidad1.Text) Then
            If TBCantidad1.Text > 0 Then
            Else
                TBCantidad1.Text = 1
            End If
            actualizarrenglon(TablaCompraDetalle, index, TBCantidad1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVCompraDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(index).Item("Cantidad")
        End If
        'TablaOrdenDetalle.Rows(index).Item("Total") = TablaOrdenDetalle.Rows(index).Item("Cantidad") * TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
        Session("TablaCompraDetalle") = TablaCompraDetalle
        Session("VistaCompraDetalle") = VistaCompraDetalle
        GVCompraDetalle.DataSource = VistaCompraDetalle
        GVCompraDetalle.DataBind()
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index2).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index2).Item("PrecioUnitario")
        Next

        '================================================
        LimpiarDetalle()
        MuestraTotales()
        'End If
    End Sub
    Private Sub actualizarrenglon(ByRef TablaCompraDetalle As DataTable, ByVal index As Integer, ByVal Cantidad1 As Double)
        Dim cantidad As Double = TablaCompraDetalle.Rows(index).Item("Cantidad")
        If Cantidad1 > 0 Then
            VistaCompraDetalle(index).Item("Cantidad") = Cantidad1
            'TablaCompraDetalle.Rows(index).Item("PrecioUnitario") = Cantidad1
            VistaCompraDetalle(index).Item("Subtotal") = Cantidad1 * CDbl(TablaCompraDetalle.Rows(index).Item("PrecioUnitario"))
            VistaCompraDetalle(index).Item("Total") = Cantidad1 * CDbl(TablaCompraDetalle.Rows(index).Item("PrecioUnitario"))
            VistaCompraDetalle(index).Item("IdActualizar") = 1
            'TablaCompraDetalle.AcceptChanges()
            '        VistaCompraDetalle(GVCompraDetalle.SelectedIndex).Item("Cantidad") = CType(TBCantidadDetalle.Text, Integer)
            '        VistaCompraDetalle(GVCompraDetalle.SelectedIndex).Item("PrecioUnitario") = CType(TBPrecioUnitario.Text, Double)
            '        VistaCompraDetalle(GVCompraDetalle.SelectedIndex).Item("Subtotal") = CType(TBPrecioUnitario.Text, Double) *
            '                                                                           CType(TBCantidadDetalle.Text, Double)
            '        VistaCompraDetalle(GVCompraDetalle.SelectedIndex).Item("Total") = CType(TBPrecioUnitario.Text, Double) *
            '                                                                        CType(TBCantidadDetalle.Text, Double)
            '        VistaCompraDetalle(GVCompraDetalle.SelectedIndex).Item("IdActualizar") = 1
        Else
        End If
    End Sub

    Protected Sub GVIPrecio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaCompraDetalle = CType(Session("TablaCompraDetalle"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBPrecio1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBPrecio1.Text) Then
            If TBPrecio1.Text > 0 Then

            Else
                TBPrecio1.Text = 1
            End If
            actualizarrenglon1(TablaCompraDetalle, index, TBPrecio1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVCompraDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(index).Item("PrecioUnitario")
        End If
        Session("TablaCompraDetalle") = TablaCompraDetalle
        Session("VistaCompraDetalle") = VistaCompraDetalle
        GVCompraDetalle.DataSource = VistaCompraDetalle
        GVCompraDetalle.DataBind()
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVCompraDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaCompraDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaCompraDetalle.Rows(Index2).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaCompraDetalle.Rows(Index2).Item("PrecioUnitario")
        Next
        '================================================
        LimpiarDetalle()
        MuestraTotales()
    End Sub
    Private Sub actualizarrenglon1(ByRef TablaOrdenDetalle As DataTable, ByVal index As Integer, ByVal TBPrecio1 As Double)
        Dim cantidad As Double = TablaCompraDetalle.Rows(index).Item("Cantidad")
        If TBPrecio1 > 0 Then
            'VistaCompraDetalle(index).Item("Cantidad") = TBPrecio1
            VistaCompraDetalle(index).Item("PrecioUnitario") = TBPrecio1
            VistaCompraDetalle(index).Item("Subtotal") = TBPrecio1 * CDbl(TablaCompraDetalle.Rows(index).Item("Cantidad"))
            VistaCompraDetalle(index).Item("Total") = TBPrecio1 * CDbl(TablaCompraDetalle.Rows(index).Item("Cantidad"))
            VistaCompraDetalle(index).Item("IdActualizar") = 1
        Else
        End If
    End Sub

    'Protected Sub BTNAceptarDetalle_Click(sender As Object, e As EventArgs) Handles BTNAceptarDetalle.Click
    '    Wucs()
    'End Sub
    'Protected Sub TBPrecioUnitario_TextChanged(sender As Object, e As EventArgs) Handles TBPrecioUnitario.TextChanged
    'Poner el evento del Change péro que no se ejecute 2 veces 
    'End Sub
    Protected Sub BTNAceptarDetalle_Click(sender As Object, e As EventArgs) Handles BTNAceptarDetalle.Click
        Wucs()
    End Sub
End Class
