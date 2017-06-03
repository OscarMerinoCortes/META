Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Drawing
Imports System.Web.Services
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
    Private TablaOrdenDetalle As New DataTable()
    Private VistaOrdenDetalle As New DataView()
    Private TablaSolicitudDetalle As New DataTable()
    Private VistaSolicitudDetalle As New DataView()
    Public Shared ArregloProductos() As String

    Private ListaEstado As New ObservableCollection(Of Entidad.TipoSolicitudEstado)
    Private ListaPrioridad As New ObservableCollection(Of Entidad.TipoPrioridad)
    Private ListaAlmacen As New ObservableCollection(Of Entidad.Almacen)

    Private Clave As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BTNEliminarDetalle.Visible = False
            IBTCancelar.Visible = False
            IBTImprimir.Visible = False
            Session("FechaActualizacion") = ""
            CType(Master.FindControl("LBOpcion"), Label).Text = "Orden de Compra"
            'Hacer invisible la columna de autorizar
            GVSolicitud.Columns(0).HeaderStyle.Width = 60
            GVSolicitud.Columns(1).Visible = False
            GVSolicitud.Columns(2).HeaderStyle.Width = 60
            GVSolicitud.Columns(3).HeaderStyle.Width = 60
            GVSolicitud.Columns(5).HeaderStyle.Width = 60
            LlenarDDs()
            '===========================================================================================================================

            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Seleccionar"
            Columna.SelectText = "Seleccionar"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            '=================================================== Orden detalle =========================================================
            TablaOrdenDetalle.Columns.Clear()
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdOrdenDetalle", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdOrden", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdSolicitudDetalle", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Producto", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("PrecioUnitario", Type.GetType("System.Double")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("PorcentajeIva", Type.GetType("System.Double")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Subtotal", Type.GetType("System.Double")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IVA", Type.GetType("System.Double")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Total", Type.GetType("System.Double")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdTipoPrioridad", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdTipoSolicitudEstado", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("TipoSolicitudEstado", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdSucursal", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdAlmacen", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Almacen", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdUnidad", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Unidad", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdActualizar", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("UsuarioCreacion", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("UsuarioActualizacion", Type.GetType("System.String")))
            TablaOrdenDetalle.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            VistaOrdenDetalle = TablaOrdenDetalle.DefaultView
            'Vista.RowFilter = "IdProdcuto=1"
            'GVOrdenDetalle.Columns.Clear()
            GVOrdenDetalle.DataSource = TablaOrdenDetalle
            GVOrdenDetalle.AutoGenerateColumns = False
            GVOrdenDetalle.AllowSorting = True

            'GVOrdenDetalle.Columns.Add(Columna)

            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Codigo Corto", "IdProductoCorto")
            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Producto", "Producto")
            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Cantidad", "Cantidad")
            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Precio Unitario", "PrecioUnitario")
            ''Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Subtotal", "Subtotal")
            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Total", "Total")
            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Destino", "Almacen")
            'Cuadricula.AgregarColumna(GVOrdenDetalle, New BoundField(), "Estado Solicitud", "TipoSolicitudEstado")
            GVOrdenDetalle.DataBind()

            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle

            '===========================================================================================================================
            'Nuevo()
            LimpiarDetalle()
            'TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            ' TBFechaFin.Text = Now.ToString("dd/MM/yyyy")

            wucDatosAuditoria1.Nuevo()
            wucDatosAuditoria1.Visible = False
            MultiView1.SetActiveView(View1)
            TBCantidadDetalle.Attributes.Add("onFocus", "test(this)")
        Else
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            ListaEstado = CType(Session("ListaEstado"), ObservableCollection(Of Entidad.TipoSolicitudEstado))
            ListaPrioridad = CType(Session("ListaPrioridad"), ObservableCollection(Of Entidad.TipoPrioridad))

            'wucConsultarProducto1.Estadistica()
            'wucEstadistica1.ImprimirTablas()
        End If
        AddHandler wucConsultarProducto1.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub
    Private Sub AgregarProductos()
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = wucConsultarProducto1.ObtenerProductos()
        For Each producto In productosSeleccionados
            Dim bandera = Not TablaOrdenDetalle.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdProducto").ToString() = producto.IdProducto)
            If bandera Then
                Dim RenglonAInsertar As DataRow

                RenglonAInsertar = TablaOrdenDetalle.NewRow()

                Dim IdOrden = 0
                If IsNumeric(TBIdOrdenCompra.Text) Then
                    IdOrden = CType(TBIdOrdenCompra.Text, Integer)
                End If
                If TBCantidadDetalle.Text Is String.Empty Then
                    TBCantidadDetalle.Text = 1
                End If
                If TBPrecioUnitario.Text Is String.Empty Then
                    TBPrecioUnitario.Text = 1
                End If
                RenglonAInsertar("IdOrdenDetalle") = 0
                RenglonAInsertar("IdOrden") = IdOrden
                RenglonAInsertar("IdSolicitudDetalle") = 0

                RenglonAInsertar("IdProducto") = producto.IdProducto   'Aqui es donde saco el id del producto pero como se lo mando javascript
                RenglonAInsertar("IdProductoCorto") = producto.IdProductoCorto
                RenglonAInsertar("Producto") = producto.Producto

                RenglonAInsertar("Cantidad") = CInt(TBCantidadDetalle.Text)
                RenglonAInsertar("PrecioUnitario") = CType(TBPrecioUnitario.Text, Double)

                RenglonAInsertar("PorcentajeIva") = 0
                RenglonAInsertar("Subtotal") = CType(TBPrecioUnitario.Text, Double) * CInt(TBCantidadDetalle.Text)
                RenglonAInsertar("IVA") = 0
                RenglonAInsertar("Total") = CType(TBPrecioUnitario.Text, Double) * CInt(TBCantidadDetalle.Text)

                RenglonAInsertar("IdTipoPrioridad") = DDTipoPrioridad.SelectedValue
                RenglonAInsertar("IdTipoSolicitudEstado") = 2
                RenglonAInsertar("TipoSolicitudEstado") = "ORDENADO"
                RenglonAInsertar("IdAlmacen") = DDDestino.SelectedValue
                RenglonAInsertar("Almacen") = DDDestino.SelectedItem.Text
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

                TablaOrdenDetalle.Rows.Add(RenglonAInsertar)


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
        Session("TablaOrdenDetalle") = TablaOrdenDetalle
        Session("VistaOrdenDetalle") = VistaOrdenDetalle
        GVOrdenDetalle.DataSource = VistaOrdenDetalle
        GVOrdenDetalle.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index).Item("PrecioUnitario")
        Next
        LimpiarDetalle()
    End Sub
    '<WebMethod()> _
    'Public Shared Function ActualizaListaProductos(texto As String) As String
    '    Dim EntidadProducto1 = New Entidad.Producto()
    '    Dim NegocioProducto = New Negocio.Producto
    '    EntidadProducto1.Descripcion = texto
    '    NegocioProducto.WucBusquedaProductoEstadisticas(EntidadProducto1)

    '    Dim total As Integer

    '    total = EntidadProducto1.TablaConsulta.Rows.Count - 1
    '    ReDim ArregloProductos(0 To total)
    '    For i = 0 To total
    '        ArregloProductos(i) = "'" + EntidadProducto1.TablaConsulta.Rows(i)(0) + " ------- " + EntidadProducto1.TablaConsulta.Rows(i)(1) + "'"
    '    Next

    '    Return Join(ArregloProductos, ",")
    'End Function
    <System.Web.Script.Services.ScriptMethod(), _
  System.Web.Services.WebMethod()> _
    Public Shared Function BuscarProductos(ByVal prefixText As String) As List(Of String)
        Dim EntidadProducto1 = New Entidad.Producto()
        Dim NegocioProducto = New Negocio.Producto
        EntidadProducto1.Descripcion = prefixText
        NegocioProducto.WucBusquedaProductoEstadisticas(EntidadProducto1)
        Dim lista As New List(Of String)
        For Each MiDataRow As DataRow In EntidadProducto1.TablaConsulta.Rows
            lista.Add(MiDataRow.Item("IdProductoCorto").ToString() + " ------- " + MiDataRow.Item("Descripcion").ToString())
        Next
        Return lista
    End Function
    Private Sub LlenarSolicitudes()
        Dim NegocioSolicitudCompra As New Negocio.OrdenCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()


        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)


        EntidadSolicitudCompra.IdProceso = -1 'CType(IIf(IsNumeric(TBSolicitud.Text), TBSolicitud.Text, -1), Integer)
        EntidadSolicitudCompra.IdAlmacen = CType(DDDestino.SelectedValue, Integer)
        EntidadSolicitudCompra.IdClasificacion = -1 'CType(DDClasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdSubclasificacion = -1 'CType(DDSubclasificacion.SelectedValue, Integer)
        EntidadSolicitudCompra.IdTipoPrioridad = -1  'TODAS LAS PRIORIDADES 
        EntidadSolicitudCompra.IdEstado = 1 ' Estado ACTIVO
        EntidadSolicitudCompra.IdSolicitudEstado = IdProveedor 'CType(DDEstado.SelectedValue, Integer) 'proveedor
        EntidadSolicitudCompra.FechaInicio = "01/01/2016" 'Comprobacion.ValidaFechaInicio(TBFechaInicio.Text)
        EntidadSolicitudCompra.FechaFin = Now 'Comprobacion.ValidaFechaFin(TBFechaFin.Text)
        'TBFechaInicio.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        'TBFechaFin.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioSolicitudCompra.ObtenerSolicitudCompraAutorizada(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta

        GVSolicitud.DataSource = TablaSolicitudDetalle
        VistaSolicitudDetalle = TablaSolicitudDetalle.DefaultView
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle

    End Sub

    Private Sub LlenarDDs()
        ' --------------------------- ---- Tipo Solicitud Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        DDTipoOrdenEstado.DataSource = EntidadTipoSolicitudEstado.TablaConsulta
        DDTipoOrdenEstado.DataValueField = "ID"
        DDTipoOrdenEstado.DataTextField = "Descripcion"
        DDTipoOrdenEstado.DataBind()
        DDTipoOrdenEstado.SelectedValue = 2

        ' --------------------------- ---- Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado2 = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado2 As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado2.Tarjeta.Consulta = Consulta.Ninguno
        NegocioTipoSolicitudEstado2.Consultar(EntidadTipoSolicitudEstado2)
        EntidadTipoSolicitudEstado2.TablaConsulta.Rows.Add(-1, "TODO")
        'DDEstado.DataSource = EntidadTipoSolicitudEstado2.TablaConsulta
        'DDEstado.DataValueField = "ID"
        'DDEstado.DataTextField = "Descripcion"
        'DDEstado.DataBind()
        'DDEstado.SelectedValue = "3"


        ' --------------------------- ---- Tipo Prioridad ---- ---------------------------
        Dim NegocioTipoPrioridad = New Negocio.TipoPrioridad()
        Dim EntidadTipoPrioridad As New Entidad.TipoPrioridad()
        EntidadTipoPrioridad.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoPrioridad.Consultar(EntidadTipoPrioridad)
        'Esta tabla es una copia de la consulta ya que se le va a gregar el campo todo pero en el prioridad de orden no debe de llevar ese campo
        'por eso se crea esta variable

        Dim tablaTipoPrioridad = EntidadTipoPrioridad.TablaConsulta.Copy()

        EntidadTipoPrioridad.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")

        DDTipoPrioridad.DataSource = tablaTipoPrioridad
        DDTipoPrioridad.DataValueField = "ID"
        DDTipoPrioridad.DataTextField = "Descripcion"
        DDTipoPrioridad.DataBind()
        DDTipoPrioridad.SelectedValue = "0"

        'DDPrioridadSolicitud.DataSource = EntidadTipoPrioridad.TablaConsulta
        'DDPrioridadSolicitud.DataValueField = "ID"
        'DDPrioridadSolicitud.DataTextField = "Descripcion"
        'DDPrioridadSolicitud.DataBind()
        'DDPrioridadSolicitud.SelectedValue = "-1"

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
        'DDDestino.SelectedValue = "-1"

        'DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        'DDAlmacen.DataValueField = "ID"
        'DDAlmacen.DataTextField = "Descripcion"
        'DDAlmacen.DataBind()
        'DDAlmacen.SelectedValue = "-1"

        ' --------------------------- ---- Clasificacion ---- ---------------------------
        Dim NegocioClasificacion = New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioClasificacion.Consultar(EntidadClasificacion)
        EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1)
        'DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
        'DDClasificacion.DataValueField = "ID"
        'DDClasificacion.DataTextField = "Descripcion"
        'DDClasificacion.DataBind()
        'DDClasificacion.SelectedValue = "-1"

        ' ConsultaSubclasificaciones()

    End Sub

    'Protected Sub DDClasificacion_TextChanged(sender As Object, e As EventArgs) Handles DDClasificacion.TextChanged
    '    ConsultaSubclasificaciones()
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
        Try
            Session("FechaActualizacion") = ""
            IBTImprimir.Visible = False
            IBTCancelar.Visible = False
            TBIdOrdenCompra.Text = ""
            DDTipoOrdenEstado.SelectedIndex = 1
            DDTipoPrioridad.SelectedIndex = 0
            'wucConProv.Nuevo()
            DDDestino.SelectedIndex = 0
            wucDatosAuditoria1.Nuevo()
            wucDatosAuditoria1.Visible = False

            'TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            'TBFechaFin.Text = Now.ToString("dd/MM/yyyy")

            LimpiarDetalle()
            '----------------Para limpiar los Gridview ----------------
            LimpiarTablas()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub LimpiarTablas()
        'limpiar tablas y vistas del detalle
        Try
            '----------------------------------------------------------
            'TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            'VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
            'TablaSolicitudDetalle.Rows.Clear()
            'GVSolicitud.DataBind()
            'Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
            'Session("VistaSolicitudDetalle") = VistaSolicitudDetalle


            TablaSolicitudDetalle.Rows.Clear()
            VistaSolicitudDetalle.Table.Rows.Clear()
            GVSolicitud.DataBind()
            Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
            Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
            '----------------------------------------------------------

            '----------------------------------------------------------
            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            TablaOrdenDetalle.Rows.Clear()
            VistaOrdenDetalle.Table.Rows.Clear()
            GVOrdenDetalle.DataBind()
            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle
            '----------------------------------------------------------




            '----------------------------------------------------------
            'TablaSolicitudDetalle
            Dim TablaSugerencia = CType(Session("TablaSugerencia"), DataTable)
            TablaSugerencia.Rows.Clear()
            GVProductoSugerencia.DataSource = TablaSugerencia
            GVProductoSugerencia.DataBind()
            Session("TablaSugerencia") = TablaSugerencia




        Catch ex As Exception
        End Try
        '----------------------------------------------------------
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        CambiarDestino()
        CambiarPrioridad()
        Dim listo = True
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim EntidadOrdenCompra As New Entidad.OrdenCompra()
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
        EntidadOrdenCompra.TablaOrdenDetalle = TablaOrdenDetalle
        EntidadOrdenCompra.TablaSolicitudDetalle = TablaSolicitudDetalle
        For Each MiDataRow As DataRow In EntidadOrdenCompra.TablaOrdenDetalle.Rows
            If Not IsNumeric(CType(MiDataRow("Cantidad"), String)) Or MiDataRow("Cantidad") = "0" _
                Or Not IsNumeric(CType(MiDataRow("PrecioUnitario"), String)) Or MiDataRow("PrecioUnitario") = "0" Then
                listo = False
            End If
            If Not TBIdOrdenCompra.Text Is String.Empty Then  ' Si se quiere modificar y encuentra un producto diferente de ordenado lo va a rechazar 
                If MiDataRow("IdTipoSolicitudEstado") <> 2 Then
                    listo = False
                End If
            End If
        Next
        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
        If IdProveedor = 0 Then
            Exit Sub
        End If
        If IdProveedor > 0 And listo Then

            EntidadOrdenCompra.IdOrden = 0
            If Not TBIdOrdenCompra.Text Is String.Empty Then
                EntidadOrdenCompra.IdOrden = CInt(TBIdOrdenCompra.Text)
                If DDTipoOrdenEstado.SelectedValue <> 2 Then
                    Exit Sub ' Si ya esta autorizado no se puede modificar 
                End If
            End If
            EntidadOrdenCompra.IdEstado = 1
            EntidadOrdenCompra.IdTipoSolicitudEstado = CType(DDTipoOrdenEstado.SelectedValue, Integer)
            EntidadOrdenCompra.IdTipoPrioridad = CType(DDTipoPrioridad.SelectedValue, Integer)
            EntidadOrdenCompra.IdCliente = IdProveedor
            EntidadOrdenCompra.Observacion = TBObservacion.Text
            NegocioOrdenCompra.Guardar(EntidadOrdenCompra)
            TBIdOrdenCompra.Text = CStr(EntidadOrdenCompra.IdOrden)
            MetodoImprimir()
            Call BTNImprimir_Click(sender, e)
        Else

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
        MultiView1.SetActiveView(View1)

    End Sub

    Protected Sub GVConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) _
Handles GVConsulta.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim NegocioOrdenDetalle As New Negocio.OrdenCompra()
        Dim EntidadOrdenDetalle As New Entidad.OrdenCompra()
        Tabla = CType(Session("Tabla"), DataTable)
        IBTCancelar.Visible = True

        Dim FechaActualizacion As String = Tabla.Rows(GVConsulta.SelectedIndex).Item("FechaActualizacion").ToString()
        Session("FechaActualizacion") = FechaActualizacion
        DDTipoOrdenEstado.SelectedValue = CType(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdTipoSolicitudEstado"), String)
        DDTipoPrioridad.SelectedValue = CType(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdTipoPrioridad"), String)
        TBIdOrdenCompra.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdOrden"))

        wucConProv.AsignarPersona(CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Equivalencia")), CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("RazonSocial")))
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVConsulta.SelectedIndex))
        wucDatosAuditoria1.Visible = True

        LlenarSolicitudes()

        '======================================== Orden Detalle ===========================================
        Dim TablaOrdenDetalle As New DataTable
        EntidadOrdenDetalle.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadOrdenDetalle.IdOrden = CType(TBIdOrdenCompra.Text, Integer)
        NegocioOrdenDetalle.Obtener(EntidadOrdenDetalle)

        TablaOrdenDetalle = EntidadOrdenDetalle.TablaOrdenDetalle
        VistaOrdenDetalle = TablaOrdenDetalle.DefaultView
        DDDestino.SelectedValue = TablaOrdenDetalle.Rows(0).Item("IdAlmacen")
        Session("TablaOrdenDetalle") = TablaOrdenDetalle
        Session("VistaOrdenDetalle") = VistaOrdenDetalle
        GVOrdenDetalle.DataSource = VistaOrdenDetalle
        GVOrdenDetalle.DataBind()

        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("PrecioUnitario")
        Next
        MultiView1.SetActiveView(View1)
        IBTImprimir.Visible = True

    End Sub

#Region "Orden Detalle========================================================================="

    Protected Sub BTNAceptarIdSolicitud_Click(sender As Object, e As EventArgs) Handles BTNAceptarDetalle.Click
        wucConsultarProducto1.BusquedaProducto()
        wucConsultarProducto1.RegresarFoco()
        wucEstadistica1.LimpiarTablas()
    End Sub

    Protected Sub BTNEliminarIdSolicitud_Click(sender As Object, e As EventArgs) Handles BTNEliminarDetalle.Click
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)

        'actualizar renglon
        Dim Renglon As Integer = GVOrdenDetalle.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            Try
                If VistaOrdenDetalle(Renglon).Item("IdOrdenDetalle") = 0 Then
                    VistaOrdenDetalle(Renglon).Delete()
                Else
                    VistaOrdenDetalle(Renglon).Item("IdActualizar") = 1 'Si   
                    VistaOrdenDetalle(Renglon).Item("IdEstado") = 2
                    VistaOrdenDetalle(Renglon).Item("Estado") = "INACTIVO"
                End If
            Catch ex As InvalidCastException
                VistaOrdenDetalle(Renglon).Delete()
            End Try
            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle
            GVOrdenDetalle.DataSource = VistaOrdenDetalle
            GVOrdenDetalle.DataBind()

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
        DDDestino.SelectedIndex = 0
        GVOrdenDetalle.SelectedIndex = -1
        BTNEliminarDetalle.Enabled = False
        ControlRegistro(True)

    End Sub

#End Region

    Private Sub OrdenarSolicitud()
        If GVSolicitud.SelectedIndex > -1 Then
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            Dim Validar = 0

            For Each MiDataRow As DataRow In TablaOrdenDetalle.Rows
                If MiDataRow("IdProducto") = VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("IdProducto") Then
                    Validar = 1
                End If
            Next


            If Validar = 0 Then
                Dim RenglonAInsertar As DataRow
                RenglonAInsertar = TablaOrdenDetalle.NewRow()

                RenglonAInsertar("IdSolicitudDetalle") = CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("IdSolicitudDetalle"), String)
                RenglonAInsertar("IdOrden") = 0
                RenglonAInsertar("IdOrdenDetalle") = 0
                RenglonAInsertar("IdProducto") = CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("IdProducto"), Integer)
                RenglonAInsertar("IdProductoCorto") = CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("IdProductoCorto"), String)
                RenglonAInsertar("Producto") = CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("Producto"), String)

                RenglonAInsertar("Cantidad") = CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("Cantidad"), String)
                RenglonAInsertar("PrecioUnitario") = 0

                RenglonAInsertar("PorcentajeIva") = 0
                RenglonAInsertar("Subtotal") = 0
                RenglonAInsertar("IVA") = 0
                RenglonAInsertar("Total") = 0

                RenglonAInsertar("IdTipoPrioridad") = DDTipoPrioridad.SelectedValue
                RenglonAInsertar("IdTipoSolicitudEstado") = 2
                RenglonAInsertar("TipoSolicitudEstado") = "ORDENADO"
                RenglonAInsertar("IdAlmacen") = DDDestino.SelectedValue 'CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("IdAlmacen"), String)
                RenglonAInsertar("Almacen") = DDDestino.SelectedItem.Text 'CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("Almacen"), String)
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

                TablaOrdenDetalle.Rows.Add(RenglonAInsertar)

                Session("TablaOrdenDetalle") = TablaOrdenDetalle
                Session("VistaOrdenDetalle") = VistaOrdenDetalle
                GVOrdenDetalle.DataSource = VistaOrdenDetalle
                GVOrdenDetalle.DataBind()
                Dim Index As Integer
                For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
                    Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                    Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
                    CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index).Item("Cantidad")
                    CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index).Item("PrecioUnitario")
                Next

                'ACTUALIZA LA SOLICITUD
                GuardaFila(2)
                GVSolicitud.SelectedIndex = -1
            End If

        End If
    End Sub

    Protected Sub GVOrdenDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles GVOrdenDetalle.SelectedIndexChanged

    End Sub

    Protected Sub BTNOrdenarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        If GVSolicitud.Rows.Count > 0 Then
            Dim i As Integer = GVSolicitud.Rows.Count - 1
            While i > -1 And i < GVSolicitud.Rows.Count
                GVSolicitud.SelectedIndex = i
                OrdenarSolicitud()
                i -= 1
            End While
        End If
    End Sub

    Protected Sub BTNOrdenar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVSolicitud.SelectedIndex = gvrFilaActual.RowIndex
        OrdenarSolicitud()
    End Sub
    Protected Sub BTNAutorizarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        For i = 0 To GVSolicitud.Rows.Count - 1
            GVSolicitud.SelectedIndex = i
            GuardaFila(3)
        Next

    End Sub

    Protected Sub BTNAutorizar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVSolicitud.SelectedIndex = gvrFilaActual.RowIndex
        GuardaFila(3)

    End Sub
    Protected Sub BTNEsperaTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        For i = 0 To GVSolicitud.Rows.Count - 1
            GVSolicitud.SelectedIndex = i
            GuardaFila(4)
        Next

    End Sub

    Protected Sub BTNEspera_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVSolicitud.SelectedIndex = gvrFilaActual.RowIndex
        GuardaFila(4)

    End Sub

    Protected Sub BTNCancelarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        For i = 0 To GVSolicitud.Rows.Count - 1
            GVSolicitud.SelectedIndex = i
            GuardaFila(5)
        Next

    End Sub

    Protected Sub BTNCancelar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVSolicitud.SelectedIndex = gvrFilaActual.RowIndex
        GuardaFila(5)

    End Sub
    Private Sub GuardaFila(idEstado As Integer)
        Try
            If GVSolicitud.SelectedIndex > -1 Then
                TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
                VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
                VistaSolicitudDetalle = TablaSolicitudDetalle.DefaultView
                If idEstado = 2 Then
                    VistaSolicitudDetalle(GVSolicitud.SelectedIndex).Item("TipoSolicitudEstado") = "ORDENADO"
                ElseIf idEstado = 3 Then
                    VistaSolicitudDetalle(GVSolicitud.SelectedIndex).Item("TipoSolicitudEstado") = "AUTORIZADO"
                ElseIf idEstado = 4 Then
                    VistaSolicitudDetalle(GVSolicitud.SelectedIndex).Item("TipoSolicitudEstado") = "EN ESPERA"
                ElseIf idEstado = 5 Then
                    VistaSolicitudDetalle(GVSolicitud.SelectedIndex).Item("TipoSolicitudEstado") = "RECHAZADO"
                End If
                VistaSolicitudDetalle(GVSolicitud.SelectedIndex).Item("IdTipoSolicitudEstado") = idEstado
                VistaSolicitudDetalle.RowFilter = "IdTipoSolicitudEstado<>2"
                Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
                Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
                GVSolicitud.DataSource = VistaSolicitudDetalle
                GVSolicitud.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        'Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        'GVOrdenDetalle.SelectedIndex = gvrFilaActual.RowIndex
        'TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)

        'wucConsultarProducto1.AsignarProducto(CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("IdProducto"), String),
        '                                      CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("IdProductoCorto"), String),
        '                                      CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("Producto"), String))

        'TBCantidadDetalle.Text = CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("Cantidad"), String)
        'TBPrecioUnitario.Text = CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("PrecioUnitario"),
        '                              String)
        'DDDestino.SelectedValue = CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("IdAlmacen"), String)

        'BTNEliminarDetalle.Enabled = True
        'ControlRegistro(True)


        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim Renglon As Integer = gvrFilaActual.RowIndex

        TablaOrdenDetalle = Session("TablaOrdenDetalle")
        VistaOrdenDetalle = Session("VistaOrdenDetalle")

        'actualizar renglon
        'Dim Renglon As Integer = GVSolicitudDetalle.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            If VistaOrdenDetalle(Renglon).Item("IdOrdenDetalle") = 0 Then
                VistaOrdenDetalle(Renglon).Delete()
            Else
                VistaOrdenDetalle(Renglon).Item("IdActualizar") = 1 'Si   
                VistaOrdenDetalle(Renglon).Item("IdEstado") = 2
                VistaOrdenDetalle(Renglon).Item("Estado") = "INACTIVO"
            End If

            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle


            GVOrdenDetalle.DataSource = VistaOrdenDetalle
            GVOrdenDetalle.DataBind()
            Dim Index As Integer
            For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index).Item("Cantidad")
                CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index).Item("PrecioUnitario")
            Next

            'limpiar controles 
            LimpiarDetalle()
        End If
    End Sub


    Private Sub ControlRegistro(control As Boolean)
        If control Then
            PARegistroDetalle.Visible = True
            GVOrdenDetalle.Visible = True
        Else
            PARegistroDetalle.Visible = False
            GVOrdenDetalle.Visible = True
        End If

    End Sub
    Protected Sub BTNSolicitudDetalle_Click(sender As Object, e As EventArgs)
        LimpiarDetalle()
        ControlRegistro(True)
    End Sub
    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        Dim Tabla As New DataTable
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = CType(IIf(IsNumeric(TBOrdenFiltro.Text), TBOrdenFiltro.Text, -1), Integer)
        EntidadOrdenCompra.IdClasificacion = CType(DDProveedorFiltro.SelectedValue, Integer) ''Para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = CType(DDPrioridadFiltro.SelectedValue, Integer)
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = CType(DDEstadoFiltro.SelectedValue, Integer)
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
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "ID", "IdOrden")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Proveedor", "Proveedor")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Prioridad", "TipoPrioridad")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Estado", "TipoSolicitudEstado")
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
        Dim NegocioTipoPrioridad = New Negocio.TipoPrioridad()
        Dim EntidadTipoPrioridad As New Entidad.TipoPrioridad()
        EntidadTipoPrioridad.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoPrioridad.Consultar(EntidadTipoPrioridad)
        EntidadTipoPrioridad.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
        DDPrioridadFiltro.DataSource = EntidadTipoPrioridad.TablaConsulta
        DDPrioridadFiltro.DataValueField = "ID"
        DDPrioridadFiltro.DataTextField = "Descripcion"
        DDPrioridadFiltro.DataBind()
        DDPrioridadFiltro.SelectedValue = "-1"

        ' --------------------------- ---- Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado.Tarjeta.Consulta = Consulta.Ninguno
        NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        EntidadTipoSolicitudEstado.TablaConsulta.Rows.Add(-1, "TODO")
        DDEstadoFiltro.DataSource = EntidadTipoSolicitudEstado.TablaConsulta
        DDEstadoFiltro.DataValueField = "ID"
        DDEstadoFiltro.DataTextField = "Descripcion"
        DDEstadoFiltro.DataBind()
        DDEstadoFiltro.SelectedValue = "-1"

        ' --------------------------- ---- Proveedores ---- ---------------------------
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
    Protected Sub BTNPerfil_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVOrdenDetalle.SelectedIndex = gvrFilaActual.RowIndex
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)

        wucConsultarProductoPerfil1.Abrir(CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("IdProducto"), Integer), "Perfil del Producto: " + CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("Producto"), String))

    End Sub
    Protected Sub BTNPerfil2_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVSolicitud.SelectedIndex = gvrFilaActual.RowIndex
        VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)

        wucConsultarProductoPerfil1.Abrir(CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("IdProducto"), Integer),
                                          "Perfil del Producto: " + CType(VistaSolicitudDetalle.Item(GVSolicitud.SelectedIndex).Item("Producto"), String))

    End Sub

    Protected Sub BTNConsultarSolicitudes_Click(sender As Object, e As EventArgs) Handles BTNConsultarSolicitudes.Click
        LlenarSolicitudes()
    End Sub



    Protected Sub BTNConsultaSugererncia_Click(sender As Object, e As EventArgs)
        Dim NegocioProducto As New Negocio.Producto()
        Dim EntidadProducto As New Entidad.Producto()
        Dim Tabla As New DataTable
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultarPorIdPersona

        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
        EntidadProducto.IdProducto = IdProveedor
        NegocioProducto.Consultar(EntidadProducto)
        Tabla = EntidadProducto.TablaConsulta
        GVProductoSugerencia.DataSource = Tabla
        GVProductoSugerencia.AutoGenerateColumns = False
        GVProductoSugerencia.AllowSorting = True
        GVProductoSugerencia.DataBind()
        Session("TablaSugerencia") = Tabla

    End Sub

    Protected Sub GVProductoSugerencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVProductoSugerencia.SelectedIndexChanged
        OrdenarSugerencia()
    End Sub

    Protected Sub BTNOrdenarSugerencia_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVProductoSugerencia.SelectedIndex = gvrFilaActual.RowIndex
        OrdenarSugerencia()
    End Sub

    Private Sub OrdenarSugerencia()
        If GVProductoSugerencia.SelectedIndex > -1 Then
            'TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            'VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
            TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaOrdenDetalle = CType(Session("VistaOrdenDetalle"), DataView)
            Dim TablaSugerencia = CType(Session("TablaSugerencia"), DataTable)

            Dim Validar = 0
            For Each MiDataRow As DataRow In TablaOrdenDetalle.Rows
                If MiDataRow("IdProducto") = TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("IdProducto") Then
                    Validar = 1
                End If
            Next
            If CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("IdAlmacen"), String) <> DDDestino.SelectedValue Then 'si es diferente del destino que no se agregue
                Validar = 1
            End If

            If Validar = 0 Then



                    Dim RenglonAInsertar As DataRow
                    RenglonAInsertar = TablaOrdenDetalle.NewRow()

                    RenglonAInsertar("IdSolicitudDetalle") = 0
                    RenglonAInsertar("IdOrden") = 0
                    RenglonAInsertar("IdOrdenDetalle") = 0

                    RenglonAInsertar("IdProducto") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("IdProducto"), Integer)
                    RenglonAInsertar("IdProductoCorto") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("IdProductoCorto"), String)
                    RenglonAInsertar("Producto") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("Producto"), String)

                    RenglonAInsertar("Cantidad") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("Sugerido"), String)
                    RenglonAInsertar("PrecioUnitario") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("PrecioUnitario"), String)

                    RenglonAInsertar("PorcentajeIva") = 0
                    RenglonAInsertar("Subtotal") = 0
                    RenglonAInsertar("IVA") = 0
                    RenglonAInsertar("Total") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("PrecioUnitario"), Integer) *
                                        CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("Sugerido"), Integer)

                    RenglonAInsertar("IdTipoPrioridad") = DDTipoPrioridad.SelectedValue
                    RenglonAInsertar("IdTipoSolicitudEstado") = 2
                    RenglonAInsertar("TipoSolicitudEstado") = "ORDENADO"
                    RenglonAInsertar("IdAlmacen") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("IdAlmacen"), String)
                    RenglonAInsertar("Almacen") = CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("Almacen"), String)
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

                    TablaOrdenDetalle.Rows.Add(RenglonAInsertar)

                    Session("TablaOrdenDetalle") = TablaOrdenDetalle
                    Session("VistaOrdenDetalle") = VistaOrdenDetalle
                    GVOrdenDetalle.DataSource = VistaOrdenDetalle
                    GVOrdenDetalle.DataBind()
                    Dim index As Integer
                    For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
                        index = Convert.ToUInt64(MiDataRow2.RowIndex)
                        Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
                        CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("Cantidad")
                        CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
                    Next

                    'ACTUALIZA LA SOLICITUD
                    TablaSugerencia.Rows.RemoveAt(GVProductoSugerencia.SelectedIndex)
                    GVProductoSugerencia.DataSource = TablaSugerencia
                    GVProductoSugerencia.DataBind()
                    Session("TablaSugerencia") = TablaSugerencia
                    GVProductoSugerencia.SelectedIndex = -1
                End If
            End If

    End Sub

    Protected Sub BTNPerfil3_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVProductoSugerencia.SelectedIndex = gvrFilaActual.RowIndex
        Dim TablaSugerencia = CType(Session("TablaSugerencia"), DataTable)

        wucConsultarProductoPerfil1.Abrir(CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("IdProducto"), Integer),
                                          "Perfil del Producto: " + CType(TablaSugerencia.Rows(GVProductoSugerencia.SelectedIndex).Item("Producto"), String))

    End Sub
    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")

    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim EntidadOrdenCompra As New Entidad.OrdenCompra()
        TablaOrdenDetalle = Session("TablaOrdenDetalle")


        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
        If IdProveedor = 0 Then
            Exit Sub
        End If
        If IdProveedor > 0 Then
            Dim validar As Boolean = True

            For Each MIDATA In TablaOrdenDetalle.Rows
                If MIDATA("IdTipoSolicitudEstado") <> 2 Then
                    validar = False
                    Exit For
                End If
            Next
            If DDTipoOrdenEstado.SelectedValue <> 2 Then 'si es diferente de ordenado
                validar = False
            End If
            If validar = False Then ' validar que el detalle de la orden todavia este ordenada, si un producto fue comprado no se puede cancelar la orden 
                Exit Sub
            End If

            EntidadOrdenCompra.IdOrden = 0
            If Not TBIdOrdenCompra.Text Is String.Empty Then
                EntidadOrdenCompra.IdOrden = CInt(TBIdOrdenCompra.Text)
            End If
            EntidadOrdenCompra.IdEstado = 1
            EntidadOrdenCompra.IdTipoSolicitudEstado = 5  ' estado cancelado
            EntidadOrdenCompra.IdTipoPrioridad = CType(DDTipoPrioridad.SelectedValue, Integer)
            EntidadOrdenCompra.IdCliente = IdProveedor
            EntidadOrdenCompra.Observacion = TBObservacion.Text
            EntidadOrdenCompra.Cancelar = 1
            EntidadOrdenCompra.TablaOrdenDetalle = TablaOrdenDetalle
            NegocioOrdenCompra.Guardar(EntidadOrdenCompra)
            TBIdOrdenCompra.Text = CStr(EntidadOrdenCompra.IdOrden)
            Nuevo()

        End If

    End Sub
    Protected Sub IBTImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTImprimir.Click
        MetodoImprimir()
        Call BTNImprimir_Click(sender, e)

    End Sub
    Protected Sub MetodoImprimir()
        If GVOrdenDetalle.Rows.Count > 0 Then
            MultiView1.SetActiveView(Imprimir)
            TablaOrdenDetalle = Session("TablaOrdenDetalle")
            LIdOrdenCompra.Text = TBIdOrdenCompra.Text
            LEstado.Text = DDTipoOrdenEstado.SelectedItem.Text
            LPrioridad.Text = DDTipoPrioridad.SelectedItem.Text
            Dim fecha As String = Session("FechaActualizacion")
            If fecha Is String.Empty Then
                LFecha.Text = Now.Date.Date
            Else
                LFecha.Text = fecha
            End If
            'If TBIdOrdenCompra =

            Dim IdProveedor = 0
            Dim IdEquivalencia = ""
            Dim Nombre = ""

            wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
            'LIdProveedor.Text = IdProveedor.ToString()
            LNombreProveedor.Text = Nombre

            GVOrdenProducto.Columns.Clear()
            GVOrdenProducto.DataSource = TablaOrdenDetalle
            GVOrdenProducto.AutoGenerateColumns = False
            GVOrdenProducto.AllowSorting = True
            GVOrdenProducto.Visible = True
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Codigo", "IdProductoCorto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Producto", "Producto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Cantidad", "Cantidad")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Precio Unitario", "PrecioUnitario")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Total", "Total")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Destino", "Almacen")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVOrdenProducto, New BoundField(), "Estado Solicitud", "TipoSolicitudEstado")
            GVOrdenProducto.DataBind()

            GVOrdenProducto.UseAccessibleHeader = True
            GVOrdenProducto.HeaderRow.TableSection = TableRowSection.TableHeader

        End If
    End Sub
    Protected Sub BTNImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles BTNImprimir.Click


        Dim cstype As Type = Me.GetType()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "scriptkey", "window.print();", True)

    End Sub
    Protected Sub BTIRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BTIRegresar.Click
        MultiView1.SetActiveView(View1)

    End Sub
    Protected Sub CambiarDestino()
        If GVOrdenDetalle.Rows.Count > 0 Then
            TablaOrdenDetalle = Session("TablaOrdenDetalle")
            VistaOrdenDetalle = Session("VistaOrdenDetalle")
            Dim index As Integer
            For Each MiDataRow As GridViewRow In GVOrdenDetalle.Rows
                index = Convert.ToUInt64(MiDataRow.RowIndex)
                TablaOrdenDetalle.Rows(index).Item("IdAlmacen") = DDDestino.SelectedValue
                VistaOrdenDetalle(index).Item("Almacen") = DDDestino.SelectedItem.Text
                If TablaOrdenDetalle.Rows(index).Item("IdOrdenDetalle") <> 0 Then
                    TablaOrdenDetalle.Rows(index).Item("IdActualizar") = 1
                    VistaOrdenDetalle(index).Item("IdActualizar") = 1
                End If
            Next
            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle
            GVOrdenDetalle.DataSource = VistaOrdenDetalle
            GVOrdenDetalle.DataBind()
            For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("Cantidad")
                CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
            Next
        End If

    End Sub
    Protected Sub CambiarPrioridad()
        If GVOrdenDetalle.Rows.Count > 0 Then
            TablaOrdenDetalle = Session("TablaOrdenDetalle")
            VistaOrdenDetalle = Session("VistaOrdenDetalle")
            Dim index As Integer
            For Each MiDataRow As GridViewRow In GVOrdenDetalle.Rows
                index = Convert.ToUInt64(MiDataRow.RowIndex)
                TablaOrdenDetalle.Rows(index).Item("IdTipoPrioridad") = DDTipoPrioridad.SelectedValue
                'VistaOrdenDetalle(index).Item("TipoPrioridad") = DDTipoPrioridad.SelectedItem.Text
                If TablaOrdenDetalle.Rows(index).Item("IdOrdenDetalle") <> 0 Then
                    TablaOrdenDetalle.Rows(index).Item("IdActualizar") = 1
                    VistaOrdenDetalle(index).Item("IdActualizar") = 1
                End If
            Next
            Session("TablaOrdenDetalle") = TablaOrdenDetalle
            Session("VistaOrdenDetalle") = VistaOrdenDetalle
            GVOrdenDetalle.DataSource = VistaOrdenDetalle
            GVOrdenDetalle.DataBind()
            For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("Cantidad")
                CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
            Next

        End If

    End Sub
    Protected Sub GVICantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBCantidad1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBCantidad1.Text) Then
            If TBCantidad1.Text > 0 Then

            Else
                TBCantidad1.Text = 1
            End If
            actualizarrenglon(TablaOrdenDetalle, index, TBCantidad1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVOrdenDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("Cantidad")
        End If
        TablaOrdenDetalle.Rows(index).Item("Total") = TablaOrdenDetalle.Rows(index).Item("Cantidad") * TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
        Session("TablaOrdenDetalle") = TablaOrdenDetalle
        Session("VistaOrdenDetalle") = VistaOrdenDetalle
        GVOrdenDetalle.DataSource = VistaOrdenDetalle
        GVOrdenDetalle.DataBind()
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("PrecioUnitario")
        Next

    End Sub
    Private Sub actualizarrenglon(ByRef TablaOrdenDetalle As DataTable, ByVal index As Integer, ByVal Cantidad1 As Double)
        Dim cantidad As Double = TablaOrdenDetalle.Rows(index).Item("Cantidad")
        If Cantidad1 > 0 Then
            VistaOrdenDetalle(index).Item("Cantidad") = Cantidad1
            VistaOrdenDetalle(index).Item("IdActualizar") = 1
            'TablaOrdenDetalle.AcceptChanges()
        Else
            'TablaOrdenDetalle.Rows(index).Item("Cantidad") = cantidad
            'TablaOrdenDetalle.AcceptChanges()
        End If

    End Sub

    Protected Sub GVIPrecio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBPrecio1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBPrecio1.Text) Then
            If TBPrecio1.Text > 0 Then

            Else
                TBPrecio1.Text = 1
            End If
            actualizarrenglon1(TablaOrdenDetalle, index, TBPrecio1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVOrdenDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
        End If
        TablaOrdenDetalle.Rows(index).Item("Total") = TablaOrdenDetalle.Rows(index).Item("Cantidad") * TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
        Session("TablaOrdenDetalle") = TablaOrdenDetalle
        Session("VistaOrdenDetalle") = VistaOrdenDetalle
        GVOrdenDetalle.DataSource = VistaOrdenDetalle
        GVOrdenDetalle.DataBind()
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("Cantidad")
            CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("PrecioUnitario")
        Next

    End Sub
    Private Sub actualizarrenglon1(ByRef TablaOrdenDetalle As DataTable, ByVal index As Integer, ByVal TBPrecio1 As Double)
        Dim precio As Double = TablaOrdenDetalle.Rows(index).Item("PrecioUnitario")
        If TBPrecio1 > 0 Then
            VistaOrdenDetalle(index).Item("PrecioUnitario") = TBPrecio1
            VistaOrdenDetalle(index).Item("IdActualizar") = 1
            'TablaOrdenDetalle.AcceptChanges()
        Else
            'TablaOrdenDetalle.Rows(index).Item("PrecioUnitario") = precio
            'TablaOrdenDetalle.AcceptChanges()
        End If

    End Sub

    Protected Sub ObtenerWucEstadisticas(ByVal sender As Object, ByVal e As System.EventArgs)
        wucConsultarProducto1.Estadistica()
        wucEstadistica1.ImprimirTablas()
        TBPrecioUnitario.Focus()
        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)

        Dim EntidadProveedor As New Entidad.Proveedor
        Dim NegocioProveedor As New Negocio.Proveedor
        Dim IdProducto = 0
        wucConsultarProducto1.ObtenerProducto(IdProducto)


        EntidadProveedor.IdProducto = IdProducto
        EntidadProveedor.IdProveedor = IdProveedor
        EntidadProveedor.Tarjeta.Consulta = Consulta.ConsultaProveedorIdPro
        NegocioProveedor.Consultar(EntidadProveedor)
        Dim Precio As Double = 0
        If EntidadProveedor.TablaConsulta.Rows.Count > 0 Then
            If EntidadProveedor.TablaConsulta.Rows(0).Item("PrecioUltimaEntrada") > 0 Then
                BTNAceptarDetalle.Enabled = True
                Precio = EntidadProveedor.TablaConsulta.Rows(0).Item("PrecioUltimaEntrada")
            End If
        Else
            BTNAceptarDetalle.Enabled = False
        End If
        TBPrecioUnitario.Text = Precio
        Precio = 0
    End Sub

End Class

