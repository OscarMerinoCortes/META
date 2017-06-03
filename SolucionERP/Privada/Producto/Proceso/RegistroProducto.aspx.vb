Imports System.Data
Imports System.Drawing
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Imports System.Collections.ObjectModel

Partial Class _Default
    Inherits Page
    Private TablaCodigoBarra As New DataTable()
    Private VistaCodigoBarra As New DataView()
    Private TablaMaxMin As New DataTable()
    Private VistaMaxMin As New DataView()
    Public TablaPrecio As New DataTable()
    Private TablaSub As New DataTable()
    Public VistaPrecio As New DataView()
    Public TablaPrecioPlazo As New DataTable()
    Private _listaPlazos As New ObservableCollection(Of Entidad.TipoPlazo)
    Private _PorcentajeSubclasificacion As New ObservableCollection(Of Entidad.Subclasificacion)
    Public IVA As Double
    Public Interes As Double
    Public TablaProveedor As New DataTable()
    Public VistaProveedor As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Registro Producto"
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"

            DDEstadoPlazo.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstadoPlazo.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstadoPlazo.SelectedValue = "1"
            LlenarDDs()

            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Seleccionar"
            Columna.SelectText = "Seleccionar"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True

            Dim NegocioClasificacion = New Negocio.Clasificacion()
            Dim EntidadClasificacion As New Entidad.Clasificacion()
            EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioClasificacion.Consultar(EntidadClasificacion)
            'EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
            DDClasificacionConsulta.DataSource = EntidadClasificacion.TablaConsulta
            DDClasificacionConsulta.DataValueField = "ID"
            DDClasificacionConsulta.DataTextField = "Descripcion"
            DDClasificacionConsulta.DataBind()
            DDClasificacionConsulta.SelectedValue = 2
            ConsultaFiltroSubclasificacion()

            DDEstadoConsulta.Items.Add(New ListItem("TODO", -1))
            DDEstadoConsulta.Items.Add(New ListItem("ACTIVO", 1))
            DDEstadoConsulta.Items.Add(New ListItem("INACTIVO", 2))
            DDEstadoConsulta.SelectedIndex = -1
            '===================================================IVA=====================================================================
            Dim EntidadProducto As New Entidad.Producto()
            Dim NegocioProducto As New Negocio.Producto()
            EntidadProducto.IVA = 1
            EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioProducto.Consultar(EntidadProducto)
            Session("IVA") = EntidadProducto.TablaConsulta.Rows(1).Item(0)
            Session("Interes") = EntidadProducto.TablaConsulta.Rows(0).Item(0)
            '===================================================Codigo de barras=========================================================
            TablaCodigoBarra.Columns.Clear()
            TablaCodigoBarra.Columns.Add(New DataColumn("IdProductoCodigoBarra", Type.GetType("System.Int32")))
            TablaCodigoBarra.Columns.Add(New DataColumn("CodigoBarra", Type.GetType("System.String")))
            TablaCodigoBarra.Columns.Add(New DataColumn("IdProdcuto", Type.GetType("System.Int32")))
            TablaCodigoBarra.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaCodigoBarra.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaCodigoBarra.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaCodigoBarra.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaCodigoBarra.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaCodigoBarra.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaCodigoBarra = TablaCodigoBarra.DefaultView
            'Vista.RowFilter = "IdProdcuto=1"

            GVCodigoBarra.Columns.Clear()
            GVCodigoBarra.DataSource = TablaCodigoBarra
            GVCodigoBarra.AutoGenerateColumns = False
            GVCodigoBarra.AllowSorting = True

            GVCodigoBarra.Columns.Add(Columna)

            'Cuadricula.AgregarColumna(GVCodigoBarra, New BoundField(), "ID", "IdProductoCodigoBarra")
            Cuadricula.AgregarColumna(GVCodigoBarra, New BoundField(), "Codigo de Barras", "CodigoBarra")
            GVCodigoBarra.DataBind()

            Session("TablaCodigoBarra") = TablaCodigoBarra
            Session("VistaCodigoBarra") = VistaCodigoBarra



            '=================================================== Proveedor =========================================================

            TablaProveedor.Columns.Clear()
            TablaProveedor.Columns.Add(New DataColumn("IdProveedor_Producto", Type.GetType("System.Int32")))
            TablaProveedor.Columns.Add(New DataColumn("IdProveedor", Type.GetType("System.Int32")))
            TablaProveedor.Columns.Add(New DataColumn("Equivalencia", Type.GetType("System.String")))
            TablaProveedor.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            TablaProveedor.Columns.Add(New DataColumn("Precio", Type.GetType("System.String")))
            TablaProveedor.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaProveedor.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaProveedor.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaProveedor.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaProveedor.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaProveedor.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaProveedor = TablaProveedor.DefaultView
            VistaProveedor.RowFilter = "IdEstado=1"

            'GVProveedor.Columns.Clear()
            'GVProveedor.DataSource = TablaProveedor
            'GVProveedor.AutoGenerateColumns = False
            'GVProveedor.AllowSorting = True

            'Dim Columna5 As New CommandField()
            'Columna5.HeaderText = ""
            'Columna5.HeaderText = "Eliminar"
            'Columna5.SelectText = "Eliminar"
            'Columna5.ButtonType = ButtonType.Link
            'Columna5.ShowSelectButton = True
            'GVProveedor.Columns.Add(Columna5)
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "IdProveedor", "IdProveedor")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Equivalencia", "Equivalencia")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Nombre", "Nombre")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVProveedor, New BoundField(), "Precio", "Precio")
            'GVProveedor.DataBind()

            Session("TablaProveedor") = TablaProveedor
            Session("VistaProveedor") = VistaProveedor

            '=================================================== Maximos y Minimos =========================================================
            TablaMaxMin.Columns.Clear()
            TablaMaxMin.Columns.Add(New DataColumn("IdProductoMaximoMinimo", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("IdAlmacen", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("Almacen", Type.GetType("System.String")))
            TablaMaxMin.Columns.Add(New DataColumn("Maximo", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("Minimo", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaMaxMin.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaMaxMin.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))
            TablaMaxMin.Columns.Add(New DataColumn("idActualizar", Type.GetType("System.Int32")))

            VistaMaxMin = TablaMaxMin.DefaultView
            'Vista.RowFilter = "IdProdcuto=1"

            GVMaxMin.Columns.Clear()
            GVMaxMin.DataSource = TablaMaxMin
            GVMaxMin.AutoGenerateColumns = False
            GVMaxMin.AllowSorting = True

            GVMaxMin.Columns.Add(Columna)

            'Cuadricula.AgregarColumna(GVMaxMin, New BoundField(), "IdProductoMaximoMinimo", "ID")
            Cuadricula.AgregarColumna(GVMaxMin, New BoundField(), "Almacen", "Almacen")
            Cuadricula.AgregarColumna(GVMaxMin, New BoundField(), "Maximo", "Maximo")
            Cuadricula.AgregarColumna(GVMaxMin, New BoundField(), "Minimo", "Minimo")
            GVMaxMin.DataBind()

            Session("TablaMaxMin") = TablaMaxMin
            Session("VistaMaxMin") = VistaMaxMin

            '=================================================== Precios =========================================================
            TablaPrecio.Columns.Clear()
            TablaPrecio.Columns.Add(New DataColumn("IdProductoPrecio", System.Type.GetType("System.Int32")))
            TablaPrecio.Columns.Add(New DataColumn("IdTipoPlazo", System.Type.GetType("System.Int32")))
            TablaPrecio.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaPrecio.Columns.Add(New DataColumn("Plazo", System.Type.GetType("System.Double")))
            TablaPrecio.Columns.Add(New DataColumn("Precio", System.Type.GetType("System.Double")))
            TablaPrecio.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.Int32")))
            TablaPrecio.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.Int32")))
            TablaPrecio.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            TablaPrecio.Columns.Add(New DataColumn("IdUsuarioCreacion", System.Type.GetType("System.Int32")))
            TablaPrecio.Columns.Add(New DataColumn("FechaCreacion", System.Type.GetType("System.String")))
            TablaPrecio.Columns.Add(New DataColumn("IdUsuarioActualizacion", System.Type.GetType("System.Int32")))
            TablaPrecio.Columns.Add(New DataColumn("FechaActualizacion", System.Type.GetType("System.String")))
            TablaPrecio.Columns.Add(New DataColumn("idActualizar", System.Type.GetType("System.Int32")))

            VistaPrecio = TablaPrecio.DefaultView
            'Vista.RowFilter = "IdProdcuto=1"

            GVPrecio.Columns.Clear()
            GVPrecio.DataSource = TablaPrecio
            GVPrecio.AutoGenerateColumns = False
            GVPrecio.AllowSorting = True

            GVPrecio.Columns.Add(Columna)

            Cuadricula.AgregarColumna(GVPrecio, New BoundField(), "Descripcion", "Descripcion")
            Cuadricula.AgregarColumna(GVPrecio, New BoundField(), "Precio", "Precio")
            Cuadricula.AgregarColumna(GVPrecio, New BoundField(), "Estado", "Estado")
            GVPrecio.DataBind()

            Session("TablaPrecio") = TablaPrecio
            Session("VistaPrecio") = VistaPrecio
            '==========================================================================================
            Nuevo()
            MultiView1.SetActiveView(View1)

        Else
            TablaCodigoBarra = CType(Session("TablaCodigoBarra"), DataTable)
            VistaCodigoBarra = CType(Session("VistaCodigoBarra"), DataView)
            TablaMaxMin = CType(Session("TablaMaxMin"), DataTable)
            VistaMaxMin = CType(Session("VistaMaxMin"), DataView)
            TablaPrecio = Session("TablaPrecio")
            VistaPrecio = Session("VistaPrecio")
            TablaProveedor = Session("TablaProveedor")
            VistaProveedor = Session("VistaProveedor")


            _listaPlazos = Session("listaPlazos")
            _PorcentajeSubclasificacion = Session("PorcentajeSubclasificacion")
            TablaSub = Session("TablaSub")
        End If
        'AddHandler wucConsultarProducto1.Seleccionado, New EventHandler(AddressOf ProductoSeleccionado)
    End Sub


    Private Sub LlenarDDs()
        ' --------------------------- ---- Tipo producto ---- ---------------------------
        Dim NegocioTipoProducto = New Negocio.TipoProducto()
        Dim EntidadTipoProducto As New Entidad.TipoProducto()
        EntidadTipoProducto.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoProducto.Consultar(EntidadTipoProducto)
        DDTipo.DataSource = EntidadTipoProducto.TablaConsulta
        DDTipo.DataValueField = "ID"
        DDTipo.DataTextField = "Descripcion"
        DDTipo.DataBind()
        ' --------------------------- ---- Unidad ---- ---------------------------
        Dim NegocioUnidad = New Negocio.Unidad()
        Dim EntidadUnidad As New Entidad.Unidad()
        EntidadUnidad.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioUnidad.Consultar(EntidadUnidad)
        DDUnidad.DataSource = EntidadUnidad.TablaConsulta
        DDUnidad.DataValueField = "ID"
        DDUnidad.DataTextField = "Descripcion"
        DDUnidad.DataBind()
        ' --------------------------- ---- Clasificacion ---- ---------------------------
        Dim NegocioClasificacion = New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioClasificacion.Consultar(EntidadClasificacion)
        DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
        DDClasificacion.DataValueField = "ID"
        DDClasificacion.DataTextField = "Descripcion"
        DDClasificacion.DataBind()
        ' --------------------------- ---- Subclasificacion ---- ---------------------------
        ConsultaSubclasificaciones()
        ' --------------------------- ---- Almacen ---- ---------------------------
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBasica
        If DDAlmacen.Items.Count > 0 Then EntidadAlmacen.IdAlmacen = CInt(DDAlmacen.SelectedValue)
        NegocioAlmacen.Consultar(EntidadAlmacen)
        DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacen.DataValueField = "ID"
        DDAlmacen.DataTextField = "Descripcion"
        DDAlmacen.DataBind()
        ' --------------------------- ---- Plazo ---- ---------------------------
        Dim EntidadTipoPlazo As New Entidad.TipoPlazo()
        Dim NegocioTipoPlazo As New Negocio.TipoPlazo()
        EntidadTipoPlazo.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioTipoPlazo.Consultar(EntidadTipoPlazo)
        Dim TablaPl = EntidadTipoPlazo.TablaConsulta
        TablaPl.Select()
        _listaPlazos.Clear()
        Dim listaPlazo As List(Of DataRow) = TablaPl.AsEnumerable().ToList()
        For Each rw As DataRow In listaPlazo
            Dim Fila As New Entidad.TipoPlazo
            Fila.IdTipoPlazo = rw.ItemArray(0)
            Fila.Descripcion = rw.ItemArray(2)
            Fila.Plazo = rw.ItemArray(1)
            Fila.IdEstado = rw.ItemArray(3)
            _listaPlazos.Add(Fila)
        Next
        DDPlazo.DataSource = _listaPlazos
        DDPlazo.DataBind()
        Session("listaPlazos") = _listaPlazos


    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
    End Sub
    Public Sub Nuevo()
        TBIdProducto.Text = ""
        TBIdProductoCorto.Text = ""
        TBDesProducto.Text = ""
        DDTipo.SelectedValue = "1"
        DDUnidad.SelectedValue = "1"
        DDClasificacion.SelectedValue = "1"
        If DDSubclasificacion.Items.Count > 0 Then DDSubclasificacion.SelectedIndex = 0
        CBVenPreCero.Checked = False
        CBVenExiCero.Checked = False
        CBAfeInv.Checked = False
        '----------------------------------------------------------
        TBCodigoBarra.Text = ""
        '----------------------------------------------------------
        DDAlmacen.SelectedIndex = 0
        TBMax.Text = ""
        TBMin.Text = ""
        '----------------------------------------------------------
        TBPrecio.Text = ""
        DDPlazo.SelectedValue = "1"
        TBPrecio.Text = ""
        TBPrecioUltimaEntrada.Text = ""
        TBGanancia.Text = ""
        TBPrecioBase.Text = ""
        CBGanancia.Checked = False
        '----------------------------------------------------------
        TBIdProveedor.Text = "0"
        '----------------Para limpiar los Gridview ----------------
        LimpiarTablas()
    End Sub
    Public Sub LimpiarTablas()
        'limpiar tablas y vistas del detalle

        '--------------------------------------------------------
        TablaCodigoBarra.Rows.Clear()
        VistaCodigoBarra.Table.Rows.Clear()
        GVCodigoBarra.DataBind()
        Session("TablaCodigoBarra") = TablaCodigoBarra
        Session("VistaCodigoBarra") = VistaCodigoBarra
        '--------------------------------------------------------
        TablaMaxMin.Rows.Clear()
        VistaMaxMin.Table.Rows.Clear()
        GVMaxMin.DataBind()
        Session("TablaMaxMin") = TablaMaxMin
        Session("VistaMaxMin") = VistaMaxMin
        '------------------------------------------------------
        TablaPrecio.Rows.Clear()
        VistaPrecio.Table.Rows.Clear()
        GVPrecio.DataBind()
        Session("TablaPrecio") = TablaPrecio
        Session("VistaPrecio") = VistaPrecio
        '------------------------------------------------------
        TablaProveedor.Rows.Clear()
        VistaProveedor.Table.Rows.Clear()
        GVProveedor.DataBind()
        Session("TablaProveedor") = TablaProveedor
        Session("VistaProveedor") = VistaProveedor


    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioProducto As New Negocio.Producto()
        Dim EntidadProducto As New Entidad.Producto()
        EntidadProducto.IdProducto = IIf(TBIdProducto.Text Is String.Empty, 0, TBIdProducto.Text)
        EntidadProducto.IdProductoCorto = CStr(TBIdProductoCorto.Text)
        EntidadProducto.Descripcion = TBDesProducto.Text
        EntidadProducto.IdTipo = CInt(DDTipo.SelectedValue)
        EntidadProducto.IdUnidad = CInt(DDUnidad.SelectedValue)
        EntidadProducto.IdSubclasificacion = CInt(DDSubclasificacion.SelectedValue)
        EntidadProducto.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadProducto.VentaExistenciaCero = 0
        EntidadProducto.VentaPrecioCero = 0
        EntidadProducto.AfectaInventario = 0
        EntidadProducto.PrecioUltimaEntrada = CDbl(TBPrecioUltimaEntrada.Text)
        If CBVenPreCero.Checked Then
            EntidadProducto.VentaPrecioCero = 1
        End If
        If CBVenExiCero.Checked Then
            EntidadProducto.VentaExistenciaCero = 1
        End If
        If CBAfeInv.Checked Then
            EntidadProducto.AfectaInventario = 1
        End If
        EntidadProducto.Ganancia = CDbl(TBGanancia.Text)
        EntidadProducto.Porcentaje = IIf(CBGanancia.Checked = True, 1, 0)
        EntidadProducto.PrecioBase = CDbl(TBPrecioBase.Text)
        'EntidadProducto.Proveedor = CInt(DDProveedor.SelectedValue = "1")
        EntidadProducto.Proveedor = 1
        EntidadProducto.TablaCodigoBarra = TablaCodigoBarra
        EntidadProducto.TablaMaximoMinimo = TablaMaxMin
        EntidadProducto.TablaPrecio = TablaPrecio
        EntidadProducto.TablaProveedor = TablaProveedor

        NegocioProducto.Guardar(EntidadProducto)
        Nuevo()
    End Sub
    'Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
    '    MultiView1.SetActiveView(View2)
    'End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim NegocioProducto As New Negocio.Producto()
        Dim EntidadProducto As New Entidad.Producto()
        Tabla = CType(Session("Tabla"), DataTable)

        'Dim index = (ViewState("IndexSeleccionado") * 20) + GridView1.SelectedIndex
        Dim index = GridView1.SelectedIndex

        TBIdProducto.Text = CStr(Tabla.Rows(index).Item("ID"))
        TBIdProductoCorto.Text = CStr(Tabla.Rows(index).Item("ID Corto"))
        TBDesProducto.Text = CStr(Tabla.Rows(index).Item("Descripcion"))
        DDTipo.SelectedValue = CStr(Tabla.Rows(index).Item("IdTipo"))
        DDUnidad.SelectedValue = CStr(Tabla.Rows(index).Item("IdUnidad"))
        DDClasificacion.SelectedValue = CStr(Tabla.Rows(index).Item("IdClasificacion"))
        ConsultaSubclasificaciones()
        DDSubclasificacion.SelectedValue = CStr(Tabla.Rows(index).Item("IdSubclasificacion"))
        TBPrecioUltimaEntrada.Text = CStr(Tabla.Rows(index).Item("UltimaEntrada"))
        CBVenPreCero.Checked = False
        CBVenExiCero.Checked = False
        CBAfeInv.Checked = False
        If CInt(Tabla.Rows(index).Item("VentaPrecioCero")) = 1 Then
            CBVenPreCero.Checked = True
        End If
        If CInt(Tabla.Rows(index).Item("VentaExistenciaCero")) = 1 Then
            CBVenExiCero.Checked = True
        End If
        If CInt(Tabla.Rows(index).Item("AfectaInventario")) = 1 Then
            CBAfeInv.Checked = True
        End If

        'TBPrecioUltimaEntrada.Text = Tabla.Rows(index).Item("VentaPrecioCero")
        TBGanancia.Text = Tabla.Rows(index).Item("Ganancia")
        CBGanancia.Checked = IIf(Tabla.Rows(index).Item("Porcentaje") = 1, True, False)
        TBPrecioBase.Text = Tabla.Rows(index).Item("PrecioBase")

        DDEstado.SelectedValue = CStr(Tabla.Rows(index).Item("IdEstado"))
        '======================================== Codigo de Barras ===========================================
        Dim TablaCodigoBarra As New DataTable
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadProducto.IdProducto = CType(TBIdProducto.Text, Integer)
        NegocioProducto.Obtener(EntidadProducto)

        TablaCodigoBarra = EntidadProducto.TablaCodigoBarra
        VistaCodigoBarra = TablaCodigoBarra.DefaultView
        ' VistaCodigoBarra.RowFilter = "IdEstado=1"

        Session("TablaCodigoBarra") = TablaCodigoBarra
        Session("VistaCodigoBarra") = VistaCodigoBarra
        GVCodigoBarra.DataSource = VistaCodigoBarra
        GVCodigoBarra.DataBind()
        '======================================== Maximo y Minimo ============================================
        Dim TablaMaxMin As New DataTable

        TablaMaxMin = EntidadProducto.TablaMaximoMinimo
        VistaMaxMin = TablaMaxMin.DefaultView
        'VistaMaxMin.RowFilter = "IdEstado=1"

        Session("TablaMaxMin") = TablaMaxMin
        Session("VistaMaxMin") = VistaMaxMin
        GVMaxMin.DataSource = VistaMaxMin
        GVMaxMin.DataBind()
        '======================================== Precio ============================================
        Dim TablaPrecio As New DataTable
        TablaPrecio = EntidadProducto.TablaPrecio
        VistaPrecio = TablaPrecio.DefaultView
        'VistaPrecio.RowFilter = "IdEstado=1"

        Session("TablaPrecio") = TablaPrecio
        Session("VistaPrecio") = VistaPrecio
        GVPrecio.DataSource = VistaPrecio
        GVPrecio.DataBind()
        '======================================== Proveedor ============================================
        Dim TablaProveedor As New DataTable()

        TablaProveedor = EntidadProducto.TablaProveedor
        VistaProveedor = TablaProveedor.DefaultView
        VistaProveedor.RowFilter = "idEstado=1"

        Session("TablaProveedor") = TablaProveedor
        Session("VistaProveedor") = VistaProveedor
        GVProveedor.DataSource = VistaProveedor
        GVProveedor.DataBind()
        Dim Index1 As Integer
        For Each MiDataRow2 As GridViewRow In GVProveedor.Rows
            Index1 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProveedor.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProveedor.Rows(Index1).Item("Precio")
        Next
        MultiView1.SetActiveView(View1)
    End Sub
#Region "Codigo de Barras========================================================================="
    Protected Sub BTNCodigoBarra_Click(sender As Object, e As EventArgs) Handles BTNuevoCodigoBarra.Click
        TBCodigoBarra.Text = ""
        PACodigoBarra.Visible = True
        TBCodigoBarra.Visible = True
        GVCodigoBarra.SelectedIndex = -1
    End Sub
    Protected Sub BTNCancelarCodigoBarra_Click(sender As Object, e As EventArgs) Handles BTNCancelarCodigoBarra.Click
        TBCodigoBarra.Text = ""
        BTNAceptarCodigoBarra.Text = "Aceptar"
        PACodigoBarra.Visible = False
    End Sub
    Protected Sub BTNAceptarCodigoBarra_Click(sender As Object, e As EventArgs) Handles BTNAceptarCodigoBarra.Click
        TablaCodigoBarra = CType(Session("TablaCodigoBarra"), DataTable)
        VistaCodigoBarra = CType(Session("VistaCodigoBarra"), DataView)
        If Not "".Equals(TBCodigoBarra.Text) Then
            If GVCodigoBarra.SelectedIndex = -1 Then
                Dim bandera = Not TablaCodigoBarra.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("CodigoBarra").ToString() = TBCodigoBarra.Text)
                If bandera Then
                    Dim RenglonAInsertar As DataRow
                    RenglonAInsertar = TablaCodigoBarra.NewRow()
                    RenglonAInsertar("IdProductoCodigoBarra") = 0
                    RenglonAInsertar("CodigoBarra") = TBCodigoBarra.Text
                    RenglonAInsertar("IdEstado") = 1
                    RenglonAInsertar("IdUsuarioCreacion") = 1
                    RenglonAInsertar("FechaCreacion") = Now
                    RenglonAInsertar("IdUsuarioActualizacion") = 1
                    RenglonAInsertar("FechaActualizacion") = CDate(Now)
                    RenglonAInsertar("idActualizar") = 1
                    TablaCodigoBarra.Rows.Add(RenglonAInsertar)
                    Session("TablaCodigoBarra") = TablaCodigoBarra
                    Session("VistaCodigoBarra") = VistaCodigoBarra
                    GVCodigoBarra.DataSource = VistaCodigoBarra
                    GVCodigoBarra.DataBind()
                    'limpiar Codigo de barras
                    PACodigoBarra.Visible = True
                End If
            Else
                'actualizar renglon
                VistaCodigoBarra(GVCodigoBarra.SelectedIndex).Item("CodigoBarra") = TBCodigoBarra.Text
                VistaCodigoBarra(GVCodigoBarra.SelectedIndex).Item("IdEstado") = 1
                VistaCodigoBarra(GVCodigoBarra.SelectedIndex).Item("IdUsuarioActualizacion") = 1
                VistaCodigoBarra(GVCodigoBarra.SelectedIndex).Item("FechaActualizacion") = Now
                VistaCodigoBarra(GVCodigoBarra.SelectedIndex).Item("idActualizar") = 1

                Session("TablaCodigoBarra") = TablaCodigoBarra
                Session("VistaCodigoBarra") = VistaCodigoBarra
                GVCodigoBarra.DataSource = VistaCodigoBarra
                GVCodigoBarra.DataBind()
            End If
            TBCodigoBarra.Text = ""
            BTNAceptarCodigoBarra.Text = "Aceptar"
            BTNEliminarCodigoBarra.Enabled = False
        End If
    End Sub
    Protected Sub GVCodigoBarra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCodigoBarra.SelectedIndexChanged
        PACodigoBarra.Visible = True
        TBCodigoBarra.Visible = True
        Dim TablaCodigoBarra As New DataTable
        TablaCodigoBarra = CType(Session("TablaCodigoBarra"), DataTable)
        TBCodigoBarra.Text = CType(TablaCodigoBarra.Rows(GVCodigoBarra.SelectedIndex).Item("CodigoBarra"), String)
        If CType(TablaCodigoBarra.Rows(GVCodigoBarra.SelectedIndex).Item("IdEstado"), String) = "1" Then
            BTNAceptarCodigoBarra.Text = "Actualizar"
            BTNEliminarCodigoBarra.Enabled = True
        Else
            BTNAceptarCodigoBarra.Text = "Aceptar y Activar"
            BTNEliminarCodigoBarra.Enabled = False
        End If
    End Sub
    Protected Sub BTNEliminarCodigoBarra_Click(sender As Object, e As EventArgs) Handles BTNEliminarCodigoBarra.Click
        TablaCodigoBarra = CType(Session("TablaCodigoBarra"), DataTable)
        VistaCodigoBarra = CType(Session("VistaCodigoBarra"), DataView)

        'actualizar renglon
        Dim Renglon As Integer = GVCodigoBarra.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            If Not DBNull.Value.Equals(VistaCodigoBarra(Renglon).Item("CodigoBarra")) Then
                VistaCodigoBarra(Renglon).Delete()
            Else
                VistaCodigoBarra(Renglon).Item("idActualizar") = 1 'Si   
                VistaCodigoBarra(Renglon).Item("IdEstado") = 2
            End If
            Session("TablaCodigoBarra") = TablaCodigoBarra
            Session("VistaCodigoBarra") = VistaCodigoBarra
            GVCodigoBarra.DataSource = VistaCodigoBarra
            GVCodigoBarra.DataBind()
            'limpiar controles 
            TBCodigoBarra.Text = ""
            BTNAceptarCodigoBarra.Text = "Aceptar"
            BTNEliminarCodigoBarra.Enabled = False
        End If
    End Sub
#End Region
#Region "Maximos y Minimos ========================================================================================================="
    Protected Sub BTNAceptarMaxMin_Click(sender As Object, e As EventArgs) Handles BTNAceptarMaxMin.Click
        TablaMaxMin = CType(Session("TablaMaxMin"), DataTable)
        VistaMaxMin = CType(Session("VistaMaxMin"), DataView)
        If Not "".Equals(TBMax.Text) And Not "".Equals(TBMin.Text) Then
            If GVMaxMin.SelectedIndex = -1 Then
                'Dim bandera = Not TablaMaxMin.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("Maximo").ToString() = TBMax.Text)
                'Dim bandera2 = Not TablaMaxMin.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("Minimo").ToString() = TBMin.Text)

                'If bandera And bandera2 Then
                Dim RenglonAInsertar As DataRow
                RenglonAInsertar = TablaMaxMin.NewRow()
                RenglonAInsertar("IdProductoMaximoMinimo") = 0
                RenglonAInsertar("Maximo") = CInt(TBMax.Text)
                RenglonAInsertar("Minimo") = CInt(TBMin.Text)
                RenglonAInsertar("IdAlmacen") = CInt(DDAlmacen.SelectedValue)
                RenglonAInsertar("Almacen") = CStr(DDAlmacen.SelectedItem.Text)
                RenglonAInsertar("IdEstado") = 1
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = CDate(Now)
                RenglonAInsertar("idActualizar") = 1
                TablaMaxMin.Rows.Add(RenglonAInsertar)

                Session("TablaMaxMin") = TablaMaxMin
                Session("VistaMaxMin") = VistaMaxMin
                GVMaxMin.DataSource = VistaMaxMin
                GVMaxMin.DataBind()

                'limpiar Codigo de barras
                PAMaxMin.Visible = True
                ' End If
            Else
                'actualizar renglon
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("Maximo") = TBMax.Text
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("Minimo") = TBMin.Text
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("IdAlmacen") = CInt(DDAlmacen.SelectedValue)
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("Almacen") = CStr(DDAlmacen.SelectedItem.Text)
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("IdEstado") = 1
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("IdUsuarioActualizacion") = 1
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("FechaActualizacion") = Now
                VistaMaxMin(GVMaxMin.SelectedIndex).Item("idActualizar") = 1

                Session("TablaMaxMin") = TablaMaxMin
                Session("VistaMaxMin") = VistaMaxMin
                GVMaxMin.DataSource = VistaMaxMin
                GVMaxMin.DataBind()
            End If
            TBMax.Text = ""
            TBMin.Text = ""
            If DDAlmacen.Items.Count > 0 Then DDAlmacen.SelectedIndex = 0
            BTNAceptarMaxMin.Text = "Aceptar"
            BTNEliminarMaxMin.Enabled = False
        End If
    End Sub
    Protected Sub BTNEliminarMaxMin_Click(sender As Object, e As EventArgs) Handles BTNEliminarMaxMin.Click
        TablaMaxMin = CType(Session("TablaMaxMin"), DataTable)
        VistaMaxMin = CType(Session("VistaMaxMin"), DataView)

        'actualizar renglon
        Dim Renglon As Integer = GVMaxMin.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            If Not DBNull.Value.Equals(VistaMaxMin(Renglon).Item("IdProductoMaximoMinimo")) Then
                VistaMaxMin(Renglon).Delete()
            Else
                VistaMaxMin(Renglon).Item("idActualizar") = 1 'Si   
                VistaMaxMin(Renglon).Item("IdEstado") = 2
            End If

            Session("TablaMaxMin") = TablaMaxMin
            Session("VistaMaxMin") = VistaMaxMin
            GVMaxMin.DataSource = VistaMaxMin
            GVMaxMin.DataBind()

            'limpiar controles 
            TBMax.Text = ""
            TBMin.Text = ""
            If DDAlmacen.Items.Count > 0 Then DDAlmacen.SelectedIndex = 0
            BTNAceptarMaxMin.Text = "Aceptar"
            BTNEliminarMaxMin.Enabled = False
        End If
    End Sub
    Protected Sub BTNCancelarMaxMin_Click(sender As Object, e As EventArgs) Handles BTNCancelarMaxMin.Click
        TBMax.Text = ""
        TBMin.Text = ""
        If DDAlmacen.Items.Count > 0 Then DDAlmacen.SelectedIndex = 0
        BTNAceptarMaxMin.Text = "Aceptar"
        PAMaxMin.Visible = False
    End Sub
    Protected Sub BTNMaxMin_Click(sender As Object, e As EventArgs) Handles BTNMaxMin.Click, BTNMaxMin.Click
        TBMax.Text = ""
        TBMin.Text = ""
        PAMaxMin.Visible = True
        TBMax.Visible = True
        TBMin.Visible = True
        DDAlmacen.Visible = True
        If DDAlmacen.Items.Count > 0 Then DDAlmacen.SelectedIndex = 0
        GVMaxMin.SelectedIndex = -1
    End Sub
    Protected Sub GVMaxMin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVMaxMin.SelectedIndexChanged
        PAMaxMin.Visible = True
        TBMax.Visible = True
        TBMin.Visible = True
        DDAlmacen.Visible = True
        Dim TablaMaxMin As New DataTable
        TablaMaxMin = CType(Session("TablaMaxMin"), DataTable)
        TBMax.Text = CType(TablaMaxMin.Rows(GVMaxMin.SelectedIndex).Item("Maximo"), String)
        TBMin.Text = CType(TablaMaxMin.Rows(GVMaxMin.SelectedIndex).Item("Minimo"), String)
        DDAlmacen.SelectedValue = CType(TablaMaxMin.Rows(GVMaxMin.SelectedIndex).Item("IdAlmacen"), String)
        If CType(TablaMaxMin.Rows(GVMaxMin.SelectedIndex).Item("IdEstado"), String) = "1" Then
            BTNAceptarMaxMin.Text = "Actualizar"
            BTNEliminarMaxMin.Enabled = True
        Else
            BTNAceptarMaxMin.Text = "Aceptar y Activar"
            BTNEliminarMaxMin.Enabled = False
        End If
    End Sub
#End Region
#Region "Precio ========================================================================================================="
    Protected Sub BTNAceptarPrecio_Click(sender As Object, e As EventArgs) Handles BTNAceptarPrecio.Click
        TablaPrecio = Session("TablaPrecio")
        VistaPrecio = Session("VistaPrecio")


        Dim bandera As Boolean = True
        'For Each fila As DataRow In TablaPrecio.Rows
        If BTNAceptarPrecio.Text = "Actualizar" Or BTNAceptarPrecio.Text = "Aceptar y Activar" Then
            bandera = False
            'Exit For
        End If
        'Next
        If bandera Then
            Dim bandera2 As Boolean = Not TablaPrecio.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdTipoPlazo").ToString() = CInt(DDPlazo.SelectedValue))
            If bandera2 Then
                Dim RenglonAInsertar As DataRow
                RenglonAInsertar = TablaPrecio.NewRow()
                RenglonAInsertar("IdProductoPrecio") = TBIdPlazo.Text
                RenglonAInsertar("Precio") = TBPrecio.Text
                RenglonAInsertar("IdProducto") = IIf(TBIdProducto.Text Is String.Empty, 0, TBIdProducto.Text)
                RenglonAInsertar("IdTipoPlazo") = CInt(DDPlazo.SelectedValue)
                RenglonAInsertar("Descripcion") = DDPlazo.SelectedItem.Text
                RenglonAInsertar("Plazo") = _listaPlazos(DDPlazo.SelectedIndex).Plazo
                RenglonAInsertar("IdEstado") = IIf(DDEstadoPlazo.SelectedIndex = 0, 1, 2)
                RenglonAInsertar("Estado") = IIf(DDEstadoPlazo.SelectedIndex = 0, "ACTIVO", "INACTIVO")
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = CDate(Now)
                RenglonAInsertar("idActualizar") = 1
                TablaPrecio.Rows.Add(RenglonAInsertar)
                PAPrecio.Visible = True
            End If
        Else
            Dim bandera2 As Boolean = Not TablaPrecio.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdTipoPlazo").ToString() = CInt(DDPlazo.SelectedValue))
            If bandera2 Or VistaPrecio(GVPrecio.SelectedIndex).Item("IdTipoPlazo") = CInt(DDPlazo.SelectedValue) Then
                VistaPrecio(GVPrecio.SelectedIndex).Item("Precio") = TBPrecio.Text
                VistaPrecio(GVPrecio.SelectedIndex).Item("IdTipoPlazo") = CInt(DDPlazo.SelectedValue)
                VistaPrecio(GVPrecio.SelectedIndex).Item("Plazo") = _listaPlazos(DDPlazo.SelectedIndex).Plazo
                VistaPrecio(GVPrecio.SelectedIndex).Item("Descripcion") = DDPlazo.SelectedItem.Text
                VistaPrecio(GVPrecio.SelectedIndex).Item("IdEstado") = IIf(DDEstadoPlazo.SelectedIndex = 0, 1, 2)
                VistaPrecio(GVPrecio.SelectedIndex).Item("Estado") = IIf(DDEstadoPlazo.SelectedIndex = 0, "ACTIVO", "INACTIVO")
                VistaPrecio(GVPrecio.SelectedIndex).Item("IdUsuarioActualizacion") = 1
                VistaPrecio(GVPrecio.SelectedIndex).Item("FechaActualizacion") = Now
                VistaPrecio(GVPrecio.SelectedIndex).Item("idActualizar") = 1
            End If
           
        End If
        Session("TablaPrecio") = TablaPrecio
        Session("VistaPrecio") = VistaPrecio
        GVPrecio.DataSource = VistaPrecio
        GVPrecio.DataBind()
        TBPrecio.Text = TBPrecioBase.Text
        If DDPlazo.Items.Count > 0 Then DDPlazo.SelectedIndex = 0
        BTNAceptarPrecio.Text = "Aceptar"
        BTNEliminarPrecio.Enabled = False
        PAPrecio.Visible = False

    End Sub
    Protected Sub BTNEliminarPrecio_Click(sender As Object, e As EventArgs) Handles BTNEliminarPrecio.Click
        TablaPrecio = CType(Session("TablaPrecio"), DataTable)
        VistaPrecio = CType(Session("VistaPrecio"), DataView)
        'actualizar renglon
        Dim Renglon As Integer = GVPrecio.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            If Not DBNull.Value.Equals(VistaPrecio(Renglon).Item("IdProductoPrecio")) Then
                VistaPrecio(Renglon).Delete()
            Else
                VistaPrecio(Renglon).Item("idActualizar") = 1 'Si   
                VistaPrecio(Renglon).Item("IdEstado") = 2
            End If
            Session("TablaPrecio") = TablaPrecio
            Session("VistaPrecio") = VistaPrecio
            GVPrecio.DataSource = VistaPrecio
            GVPrecio.DataBind()
            'limpiar controles 
            TBPrecio.Text = ""
            If DDPlazo.Items.Count > 0 Then DDPlazo.SelectedIndex = 0
            BTNAceptarPrecio.Text = "Aceptar"
            BTNEliminarPrecio.Enabled = False
        End If
    End Sub
    Protected Sub BTNCancelar_Click(sender As Object, e As EventArgs) Handles BTNCancelar.Click
        'TBPrecio.Text = ""
        If DDPlazo.Items.Count > 0 Then DDPlazo.SelectedIndex = 0
        BTNAceptarPrecio.Text = "Aceptar"
        PAPrecio.Visible = False
    End Sub
    Protected Sub GVPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPrecio.SelectedIndexChanged
        PAPrecio.Visible = True
        TBPrecio.Visible = True
        DDPlazo.Visible = True
        Dim TablaPrecio As New DataTable
        TablaPrecio = CType(Session("TablaPrecio"), DataTable)
        TBIdPlazo.Text = CType(TablaPrecio.Rows(GVPrecio.SelectedIndex).Item("IdProductoPrecio"), String)
        TBPrecio.Text = CType(TablaPrecio.Rows(GVPrecio.SelectedIndex).Item("Precio"), String)
        DDPlazo.SelectedValue = CType(TablaPrecio.Rows(GVPrecio.SelectedIndex).Item("IdTipoPlazo"), String)
        DDEstadoPlazo.SelectedValue = CType(TablaPrecio.Rows(GVPrecio.SelectedIndex).Item("IdEstado"), Integer)
        If CType(TablaPrecio.Rows(GVPrecio.SelectedIndex).Item("IdEstado"), String) = "1" Then
            BTNAceptarPrecio.Text = "Actualizar"
            BTNEliminarPrecio.Enabled = True
        Else
            BTNAceptarPrecio.Text = "Aceptar y Activar"
            BTNEliminarPrecio.Enabled = False
        End If
    End Sub
    Protected Sub BTNPrecio_Click(sender As Object, e As EventArgs) Handles BTNPrecio.Click
        TBPrecio.Text = ""
        TBPrecio.Text = TBPrecioBase.Text
        BTNAceptarPrecio.Text = "Aceptar"
        PAPrecio.Visible = True
        TBPrecio.Visible = True
        DDPlazo.Visible = True
        TBIdPlazo.Text = 0
        If DDPlazo.Items.Count > 0 Then DDPlazo.SelectedIndex = 0
        GVPrecio.SelectedIndex = -1
    End Sub
#End Region
    Protected Sub DDClasificacion_TextChanged(sender As Object, e As EventArgs) Handles DDClasificacion.TextChanged
        ConsultaSubclasificaciones()
    End Sub
    Private Sub ConsultaSubclasificaciones()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
        EntidadSubclasificacion.IdClasificacion = DDClasificacion.SelectedValue
        EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaDetalladaPorId
        NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
        TablaSub = EntidadSubclasificacion.TablaConsulta
        DDSubclasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
        DDSubclasificacion.DataValueField = "ID"
        DDSubclasificacion.DataTextField = "Descripcion"
        DDSubclasificacion.DataBind()
        If TablaSub.Rows.Count <> 0 Then
            TBGanancia.Text = TablaSub.Rows(0).Item("Ganancia")
            CBGanancia.Checked = IIf(TablaSub.Rows(0).Item("Porcentaje") = 1, True, False)
        End If
        Session("TablaSub") = TablaSub
    End Sub

    'Protected Sub TBPrecioUltimaEntrada_TextChanged(sender As Object, e As EventArgs) Handles TBPrecioUltimaEntrada.TextChanged
    '    Precio()
    '    TBPrecioUltimaEntrada.Focus()
    'End Sub
    'Protected Sub TBGanancia_TextChanged(sender As Object, e As EventArgs) Handles TBGanancia.TextChanged
    '    Precio()
    '    TBGanancia.Focus()
    'End Sub
    Public Sub Precio()
        'Try

        '    Dim _PrecioBase As Double
        '    If CBGanancia.Checked Then
        '        _PrecioBase = CDbl(TBPrecioUltimaEntrada.Text) + (CDbl(TBPrecioUltimaEntrada.Text) * CDbl(TBGanancia.Text / 100))
        '    Else
        '        _PrecioBase = CDbl(TBPrecioUltimaEntrada.Text) + CDbl(IIf(TBGanancia.Text Is String.Empty, 0, TBGanancia.Text))
        '    End If
        '    TBPrecioBase.Text = _PrecioBase
        'Catch ex As Exception

        'End Try
        Dim IVA As Double = Session("IVA")
        Try
            Dim _PrecioBase As Double
            If CBGanancia.Checked Then
                _PrecioBase = (CDbl(TBPrecioUltimaEntrada.Text) / (1 - (CDbl(TBGanancia.Text / 100)))) * (1 + (IVA / 100))
            Else
                _PrecioBase = (CDbl(TBPrecioUltimaEntrada.Text) + CDbl(IIf(TBGanancia.Text Is String.Empty, 0, TBGanancia.Text))) * (1 + (IVA / 100))
            End If
            TBPrecioBase.Text = _PrecioBase
            TBPrecio.Text = _PrecioBase
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub CBGanancia_CheckedChanged(sender As Object, e As EventArgs) Handles CBGanancia.CheckedChanged
        Precio()
        TBGanancia.Focus()
    End Sub

    Protected Sub DDPlazo_TextChanged(sender As Object, e As EventArgs) Handles DDPlazo.TextChanged
        Dim Interes As Double = Session("Interes")
        TBPrecio.Text = TBPrecioBase.Text
        TBPrecio.Text = TBPrecio.Text + (TBPrecio.Text * (Interes / 100) * _listaPlazos(DDPlazo.SelectedIndex).Plazo)
    End Sub

    Protected Sub TBGanancia_TextChanged(sender As Object, e As EventArgs) Handles TBGanancia.TextChanged
        Precio()
    End Sub

    Protected Sub TBPrecioUltimaEntrada_TextChanged(sender As Object, e As EventArgs) Handles TBPrecioUltimaEntrada.TextChanged
        Precio()
    End Sub

    Protected Sub DDSubclasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDSubclasificacion.SelectedIndexChanged
        TablaSub = Session("TablaSub")
        TBGanancia.Text = TablaSub.Rows(DDSubclasificacion.SelectedIndex).Item("Ganancia")
        CBGanancia.Checked = IIf(TablaSub.Rows(DDSubclasificacion.SelectedIndex).Item("Porcentaje") = 1, True, False)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub


    Private Sub ProductoSeleccionado(sender As Object, e As EventArgs)
        Dim Tabla As New DataTable
        Dim NegocioProducto As New Negocio.Producto()
        Dim EntidadProducto As New Entidad.Producto()
        Dim IdProducto = 0
        Dim IdProductoCorto = ""
        Dim Descripcion = ""
        ' wucConsultarProducto1.ObtenerProducto(IdProducto, IdProductoCorto, Descripcion)
        EntidadProducto.IdProducto = IdProducto
        EntidadProducto.IdProductoCorto = IdProductoCorto
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaDetalladaPorId
        NegocioProducto.Consultar(EntidadProducto)
        Tabla = EntidadProducto.TablaConsulta

        DDTipo.SelectedValue = CStr(Tabla.Rows(0).Item("IdTipoProducto"))
        DDUnidad.SelectedValue = CStr(Tabla.Rows(0).Item("IdUnidad"))
        DDClasificacion.SelectedValue = CStr(Tabla.Rows(0).Item("IdClasificacion"))
        ConsultaSubclasificaciones()
        DDSubclasificacion.SelectedValue = CStr(Tabla.Rows(0).Item("IdSubclasificacion"))
        CBVenPreCero.Checked = False
        CBVenExiCero.Checked = False
        CBAfeInv.Checked = False
        If CInt(Tabla.Rows(0).Item("VentaPrecioCero")) = 1 Then
            CBVenPreCero.Checked = True
        End If
        If CInt(Tabla.Rows(0).Item("VentaExistenciaCero")) = 1 Then
            CBVenExiCero.Checked = True
        End If
        If CInt(Tabla.Rows(0).Item("AfectaInventario")) = 1 Then
            CBAfeInv.Checked = True
        End If

        'TBPrecioUltimaEntrada.Text = Tabla.Rows(0).Item("VentaPrecioCero")
        TBGanancia.Text = Tabla.Rows(0).Item("Ganancia")
        CBGanancia.Checked = IIf(Tabla.Rows(0).Item("Porcentaje") = 1, True, False)
        TBPrecioBase.Text = Tabla.Rows(0).Item("PrecioBase")

        DDEstado.SelectedValue = CStr(Tabla.Rows(0).Item("IdEstado"))
        '======================================== Codigo de Barras ===========================================
        Dim TablaCodigoBarra As New DataTable
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadProducto.IdProducto = IdProducto
        NegocioProducto.Obtener(EntidadProducto)

        TablaCodigoBarra = EntidadProducto.TablaCodigoBarra
        VistaCodigoBarra = TablaCodigoBarra.DefaultView
        ' VistaCodigoBarra.RowFilter = "IdEstado=1"

        Session("TablaCodigoBarra") = TablaCodigoBarra
        Session("VistaCodigoBarra") = VistaCodigoBarra
        GVCodigoBarra.DataSource = VistaCodigoBarra
        GVCodigoBarra.DataBind()
        '======================================== Maximo y Minimo ============================================
        Dim TablaMaxMin As New DataTable

        TablaMaxMin = EntidadProducto.TablaMaximoMinimo
        VistaMaxMin = TablaMaxMin.DefaultView
        'VistaMaxMin.RowFilter = "IdEstado=1"

        Session("TablaMaxMin") = TablaMaxMin
        Session("VistaMaxMin") = VistaMaxMin
        GVMaxMin.DataSource = VistaMaxMin
        GVMaxMin.DataBind()
        '======================================== Precio ============================================
        Dim TablaPrecio As New DataTable

        TablaPrecio = EntidadProducto.TablaPrecio
        VistaPrecio = TablaPrecio.DefaultView
        'VistaPrecio.RowFilter = "IdEstado=1"

        Session("TablaPrecio") = TablaPrecio
        Session("VistaPrecio") = VistaPrecio
        GVPrecio.DataSource = VistaPrecio
        GVPrecio.DataBind()

        MultiView1.SetActiveView(View1)
    End Sub

    

    Protected Sub IBTConsultarRegistroProducto_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultarRegistroProducto.Click
        Consultar()
    End Sub
    Private Sub ConsultaFiltroSubclasificacion()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
        If DDClasificacionConsulta.SelectedValue = "-1" Then
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        Else
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaPorId

        End If
        EntidadSubclasificacion.IdClasificacion = CInt(DDClasificacionConsulta.SelectedValue)
        NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
        If EntidadSubclasificacion.TablaConsulta.Rows.Count = 0 Then
            DDSubclasificacionConsulta.Items.Clear()
            DDSubclasificacionConsulta.Items.Add(New ListItem("TODO", "-1"))
        Else
            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1)
            DDSubclasificacionConsulta.DataSource = EntidadSubclasificacion.TablaConsulta
            DDSubclasificacionConsulta.DataValueField = "ID"
            DDSubclasificacionConsulta.DataTextField = "Descripcion"
        End If
        DDSubclasificacionConsulta.DataBind()
        DDSubclasificacionConsulta.SelectedValue = "-1"
    End Sub

    Protected Sub DDClasificacionConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacionConsulta.SelectedIndexChanged
        ConsultaFiltroSubclasificacion()
    End Sub

    Protected Sub IBTConsultare_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultare.Click
        MultiView1.SetActiveView(View2)
    End Sub

    'Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    '    GridView1.PageIndex = e.NewPageIndex
    '    ViewState("IndexSeleccionado") = e.NewPageIndex
    '    Consultar()
    'End Sub
    Public Sub Consultar()
        Dim NegocioProducto As New Negocio.Producto()
        Dim EntidadProducto As New Entidad.Producto()
        Dim Tabla As New DataTable
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaPorFiltro
        EntidadProducto.IdProducto = IIf(TBIdProductoConsultar.Text Is String.Empty, 0, TBIdProductoConsultar.Text)
        EntidadProducto.IdProductoCorto = IIf(TBCodigoCortoConsultar.Text Is String.Empty, "0", TBCodigoCortoConsultar.Text)
        EntidadProducto.Descripcion = IIf(TBProductoDescripcionConsultar.Text Is String.Empty, "", TBProductoDescripcionConsultar.Text)
        EntidadProducto.IdClasificacion = DDClasificacionConsulta.SelectedValue
        EntidadProducto.IdSubclasificacion = DDSubclasificacionConsulta.SelectedValue
        EntidadProducto.IdEstado = DDEstadoConsulta.SelectedValue
        NegocioProducto.ObtenerFiltro(EntidadProducto)
        Tabla = EntidadProducto.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = Tabla
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = False
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "ID")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID Corto", "ID Corto")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "Descripcion", "Descripcion")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "Tipo", "Tipo")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "Unidad", "Unidad")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "Clasificacion", "Clasificacion")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "Subclasificacion", "Subclasificacion")
        Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        GridView1.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTCancelarConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelarConsultar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTConsultarNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultarNuevo.Click
        Nuevo()
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub BTNActualizarProducto_Click(sender As Object, e As EventArgs) Handles BTNActualizarProveedor.Click
        TablaProveedor = Session("TablaProveedor")
        VistaProveedor = Session("VistaProveedor")


        Dim IdProveedor = 0
        Dim Equivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, Equivalencia, Nombre)
        Dim Renglon As Integer = GVProveedor.SelectedIndex
        VistaProveedor(Renglon).Item("IdProveedor") = IdProveedor
        VistaProveedor(Renglon).Item("Equivalencia") = Equivalencia
        VistaProveedor(Renglon).Item("Nombre") = Nombre
        VistaProveedor(Renglon).Item("Precio") = CType(TBProveedorPrecio.Text, Double)
        VistaProveedor(Renglon).Item("IdEstado") = 1
        VistaProveedor(Renglon).Item("idActualizar") = 1 'Si

        Session("TablaProducto") = TablaProveedor
        Session("VistaProducto") = VistaProveedor
        GVProveedor.DataSource = VistaProveedor
        GVProveedor.DataBind()

        'limpiar controles 
        'wucConProv.AsignarPersona(0, "", "")
        TBProveedorPrecio.Text = "0"
        ' TBIdProveedor.Text = 0
        ControlesProveedor(False)

    End Sub
    Protected Sub BTNProveedor_Click(sender As Object, e As EventArgs) Handles BTNProveedor.Click
        wucConProv.Visible = True
        ' TBIdProveedor.Text = 0
        TBProveedorPrecio.Text = 0
        BTNAceptarProveedor.Enabled = True
        BTNEliminarProveedor.Enabled = False
        BTNActualizarProveedor.Enabled = False
        ControlesProveedor(True)
    End Sub
    Private Sub ControlesProveedor(control As Boolean)
        If control Then
            'Proveedores.Visible = True
            GVProveedor.Visible = False
        Else
            'Proveedores.Visible = False
            GVProveedor.Visible = True
        End If
    End Sub
    Protected Sub BTNCancelarProveedor_Click(sender As Object, e As EventArgs) Handles BTNCancelarProveedor.Click
        ' wucConProv.AsignarPersona(0, "", "")
        TBProveedorPrecio.Text = "0"
        ' TBIdProveedor.Text = 0
        ControlesProveedor(False)
    End Sub
    Protected Sub BTNEliminarProveedor_Click(sender As Object, e As EventArgs) Handles BTNEliminarProveedor.Click
        TablaProveedor = Session("TablaProveedor")
        VistaProveedor = Session("VistaProveedor")
        'actualizar renglon
        Dim Renglon As Integer = GVProveedor.SelectedIndex
        'si es nuevo eliminar del datatable
        If VistaProveedor(Renglon).Item("IdProveedor_Producto") = 0 Then
            VistaProveedor(Renglon).Delete()
        Else
            VistaProveedor(Renglon).Item("idActualizar") = 1 'Si   
            VistaProveedor(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If
        Session("TablaProducto") = TablaProveedor
        Session("VistaProducto") = VistaProveedor
        GVProveedor.DataSource = VistaProveedor
        GVProveedor.DataBind()
        ' wucConProv.AsignarPersona(0, "", "")
        TBProveedorPrecio.Text = "0"
        TBIdProveedor.Text = 0
        ControlesProveedor(False)
    End Sub
    Protected Sub BTNAceptarProveedor_Click(sender As Object, e As EventArgs) Handles BTNAceptarProveedor.Click
        TablaProveedor = Session("TablaProveedor")
        VistaProveedor = Session("VistaProveedor")
        Dim bandera As Boolean = True
        If bandera Then
            Dim IdProveedor = 0
            Dim Equivalencia = ""
            Dim Nombre = ""
            wucConProv.ObtenerPersona(IdProveedor, Equivalencia, Nombre)
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaProveedor.NewRow()
            RenglonAInsertar("IdProveedor_Producto") = Int32.Parse(TBIdProveedor.Text)
            RenglonAInsertar("IdProveedor") = IdProveedor
            RenglonAInsertar("Equivalencia") = Equivalencia
            RenglonAInsertar("Nombre") = Nombre
            RenglonAInsertar("Precio") = CType(TBProveedorPrecio.Text, Double)
            RenglonAInsertar("IdEstado") = 1
            RenglonAInsertar("IdActualizar") = 1
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = CDate(Now)
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            TablaProveedor.Rows.Add(RenglonAInsertar)
            Session("TablaProducto") = TablaProveedor
            Session("VistaProducto") = TablaProveedor
            GVProveedor.DataSource = VistaProveedor
            GVProveedor.DataBind()
            'limpiar Identificacion
            'wucConProv.AsignarPersona(0, "", "")
            TBProveedorPrecio.Text = ""
            TBIdProveedor.Text = 0
        End If
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVProveedor.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProveedor.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProveedor.Rows(Index).Item("Precio")
        Next
        TBProveedorPrecio.Text = "0"
        TBIdProveedor.Text = 0
        ControlesProveedor(False)
    End Sub
    Protected Sub BTNEliminarProducto_Click1(ByVal sender As Object, ByVal e As EventArgs)

        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim Renglon As Integer = gvrFilaActual.RowIndex
        TablaProveedor = Session("TablaProveedor")
        VistaProveedor = Session("VistaProveedor")
        'si es nuevo eliminar del datatable
        If VistaProveedor(Renglon).Item("IdProveedor_Producto") = 0 Then
            VistaProveedor(Renglon).Delete()
        Else
            VistaProveedor(Renglon).Item("idActualizar") = 1 'Si   
            VistaProveedor(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If
        'Dim Renglon As Integer = GVSolicitudDetalle.SelectedIndex
        Session("TablaProveedor") = TablaProveedor
        Session("VistaProveedor") = VistaProveedor
        GVProveedor.DataSource = VistaProveedor
        GVProveedor.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVProveedor.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProveedor.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProveedor.Rows(Index).Item("Precio")
        Next
        TBProveedorPrecio.Text = "0"
        TBIdProveedor.Text = 0

    End Sub


    Protected Sub GVProveedor_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles GVProveedor.SelectedIndexChanged
        'Dim Renglon As Integer = GVProveedor.SelectedIndex
        'TablaProveedor = Session("TablaProveedor")
        'VistaProveedor = Session("VistaProveedor")
        ''si es nuevo eliminar del datatable
        'If VistaProveedor(Renglon).Item("IdProveedor_Producto") = 0 Then
        '    VistaProveedor(Renglon).Delete()
        'Else
        '    VistaProveedor(Renglon).Item("idActualizar") = 1 'Si   
        '    VistaProveedor(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        'End If
        ''Dim Renglon As Integer = GVSolicitudDetalle.SelectedIndex
        'Session("TablaProveedor") = TablaProveedor
        'Session("VistaProveedor") = VistaProveedor
        'GVProveedor.DataSource = VistaProveedor
        'GVProveedor.DataBind()
        'Dim Index As Integer


        'For Each MiDataRow2 As GridViewRow In GVProveedor.Rows
        '    Index = Convert.ToUInt64(MiDataRow2.RowIndex)
        '    Dim NuevoRow As DataRow = TablaProveedor.NewRow()
        '    CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProveedor.Rows(Index).Item("Precio")
        'Next
        'TBProveedorPrecio.Text = "0"
        'TBIdProveedor.Text = 0
    End Sub
    Protected Sub GVIPrecio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaProveedor = CType(Session("TablaProveedor"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBPrecio1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBPrecio1.Text) Then
            If TBPrecio1.Text > 0 Then

            Else
                TBPrecio1.Text = 1
            End If
            actualizarrenglon1(TablaProveedor, index, TBPrecio1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVProveedor.Rows(index)
            Dim NuevoRow As DataRow = TablaProveedor.NewRow()
            CType(MiDataRow.FindControl("TBGVPrecio"), TextBox).Text = TablaProveedor.Rows(index).Item("Precio")
        End If
        Session("TablaProveedor") = TablaProveedor
        Session("VistaProveedor") = VistaProveedor
        GVProveedor.DataSource = VistaProveedor
        GVProveedor.DataBind()
        Dim Index2 As Integer
        For Each MiDataRow2 As GridViewRow In GVProveedor.Rows
            Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaProveedor.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecio"), TextBox).Text = TablaProveedor.Rows(Index2).Item("Precio")
        Next
    End Sub
    Private Sub actualizarrenglon1(ByRef TablaProveedor As DataTable, ByVal index As Integer, ByVal TBPrecio1 As Double)
        VistaProveedor(index).Item("Precio") = TBPrecio1
        VistaProveedor(index).Item("IdActualizar") = 1
    End Sub
End Class