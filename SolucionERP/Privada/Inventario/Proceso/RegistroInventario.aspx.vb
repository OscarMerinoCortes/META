Imports System.Data
Imports Entidad
Imports Operacion.Configuracion.Constante
Imports System.Collections.ObjectModel
Partial Class _Default
    Inherits Page
    Public TablaInventarioDetalle As New DataTable()
    Public VistaInventarioDetalle As New DataView()
    Public TablaListaProducto As New DataTable()
    Public VistaListaProducto As New DataView()
    Private ListaEstado As New ObservableCollection(Of Entidad.TipoSolicitudEstado)
    Private ListaPrioridad As New ObservableCollection(Of Entidad.TipoPrioridad)
    Private ListaAlmacen As New ObservableCollection(Of Entidad.Almacen)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            CType(Master.FindControl("LBOpcion"), Label).Text = "Registro Inventario"
            IBTAplicar.Visible = False
            IBTCancelar.Visible = False        
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            '----------------------------
            divAvanzado.Visible = False
            '--Boton Busqueda
            DDEstadoBusq.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstadoBusq.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstadoBusq.Items.Add(New ListItem("TODOS", "-1"))
            DDEstadoBusq.SelectedValue = "-1"
            LlenarDDs()
            DDSubClasificacion.SelectedValue = -1
            '=======================Tabla Inventario Fisico ====================
            TablaInventarioDetalle.Columns.Clear()
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdEncabezado", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdDetalle", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Observacion", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdAlmacen", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Almacen", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdClasificacion", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdSubClasificacion", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("DescripcionProducto", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("CantidadSistema", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("CantidadReal", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Diferencia", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdUsuarioCreacion", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("FechaCreacion", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdUsuarioActualizacion", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("FechaActualizacion", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("idActualizar", System.Type.GetType("System.Int32")))

            VistaInventarioDetalle = TablaInventarioDetalle.DefaultView
            TablaListaProducto.Columns.Clear()
            TablaListaProducto.Columns.Add(New DataColumn("IdDetalle", System.Type.GetType("System.Int32")))          
            TablaListaProducto.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.Int32")))
            TablaListaProducto.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaListaProducto.Columns.Add(New DataColumn("DescripcionProducto", System.Type.GetType("System.String")))
            TablaListaProducto.Columns.Add(New DataColumn("CantidadSistema", System.Type.GetType("System.String")))
            TablaListaProducto.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaListaProducto.Columns.Add(New DataColumn("IdAlmacen", System.Type.GetType("System.Int32")))
            TablaListaProducto.Columns.Add(New DataColumn("Almacen", System.Type.GetType("System.String")))
            TablaListaProducto.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            TablaListaProducto.Columns.Add(New DataColumn("CantidadReal", System.Type.GetType("System.Int32")))
            TablaListaProducto.Columns.Add(New DataColumn("Diferencia", System.Type.GetType("System.Int32")))
            TablaListaProducto.Columns.Add(New DataColumn("idActualizar", System.Type.GetType("System.Int32")))
            VistaListaProducto = TablaListaProducto.DefaultView
            Session("TablaListaProducto") = TablaListaProducto
            Session("VistaListaProducto") = VistaListaProducto

            VistaListaProducto = TablaListaProducto.DefaultView
            GVInventario.DataSource = VistaListaProducto

            GVInventario.AutoGenerateColumns = False
            GVInventario.AllowSorting = True
            GVInventario.DataBind()

            Session("TablaInventarioDetalle") = TablaInventarioDetalle
            Session("VistaInventarioDetalle") = VistaInventarioDetalle
            MultiView1.SetActiveView(View1)
            DDAlmacen.SelectedValue = 2
            DDAlmacenBusq.SelectedValue = -1
        Else
            TablaInventarioDetalle = Session("TablaInventarioDetalle")
            VistaInventarioDetalle = Session("VistaInventarioDetalle")
            TablaListaProducto = Session("TablaListaProducto")
            VistaListaProducto = Session("VistaListaProducto")
        End If
        AddHandler wucConsultarProducto.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub

    Private Sub AgregarProductos(sender As Object, e As EventArgs)
        TablaListaProducto = CType(Session("TablaListaProducto"), DataTable)
        VistaListaProducto = CType(Session("VistaListaProducto"), DataView)
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = wucConsultarProducto.ObtenerProductos()
        For Each producto In productosSeleccionados
            Dim bandera = Not TablaListaProducto.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdProducto").ToString() = producto.IdProducto)
            If bandera Then
                Dim ObtenerExistencia As Integer = 0
                Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
                Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
                EntidadRegistroInventario.IdProducto = producto.IdProducto
                EntidadRegistroInventario.IdAlmacen = DDAlmacen.SelectedValue
                EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
                NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
                If EntidadRegistroInventario.TablaConsulta.Rows.Count > 0 And EntidadRegistroInventario.TablaConsulta.Rows.Count < 2 Then
                    ObtenerExistencia = EntidadRegistroInventario.TablaConsulta.Rows(0).Item(0)
                End If
                Dim RenglonAInsertar As DataRow
                    RenglonAInsertar = TablaListaProducto.NewRow()
                    If TBIdInventario.Text.Length > 0 Then
                        RenglonAInsertar("IdDetalle") = 0
                    End If
                RenglonAInsertar("IDProducto") = producto.IdProducto
                RenglonAInsertar("IdProductoCorto") = CStr(producto.IdProductoCorto)
                RenglonAInsertar("DescripcionProducto") = producto.Producto
                RenglonAInsertar("CantidadSistema") = ObtenerExistencia
                RenglonAInsertar("IdEstado") = IIf(TBIdInventario.Text.Length > 0, 2, 1)
                RenglonAInsertar("IdAlmacen") = DDAlmacen.SelectedValue
                RenglonAInsertar("Almacen") = DDAlmacen.SelectedItem.ToString()
                RenglonAInsertar("Estado") = "ACTIVO"
                RenglonAInsertar("CantidadReal") = 0
                RenglonAInsertar("Diferencia") = 0
                RenglonAInsertar("idActualizar") = 0
                TablaListaProducto.Rows.Add(RenglonAInsertar)                
            End If
        Next
        Session("TablaListaProducto") = TablaListaProducto
        Session("VistaListaProducto") = VistaListaProducto
        VistaListaProducto = TablaListaProducto.DefaultView
        GVInventario.DataSource = VistaListaProducto
        GVInventario.AutoGenerateColumns = False
        GVInventario.AllowSorting = True
        GVInventario.DataBind()               
    End Sub
    Private Sub LimpiarDetalle()
        wucConsultarProducto.Nuevo()
    End Sub
    Protected Sub BTNPerfil2_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub   
    Private Sub Limpiar()
        TBIdInventario.Text = ""
        TBDescripcion.Text = ""
        TBObservaciones.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        DDSucursal.SelectedValue = 1
        DDAlmacen.SelectedValue = 2
        DDClasificacion.SelectedValue = 1
        TablaInventarioDetalle.Rows.Clear()
        VistaInventarioDetalle.Table.Rows.Clear()
        TablaListaProducto.Rows.Clear()
        VistaListaProducto.Table.Rows.Clear()
        GVInventario.DataSource = Nothing
        GVInventario.DataBind()
        BTNConsultar.Enabled = True
        BTNAgregar.Enabled = True
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        Session("TablaListaProducto") = TablaListaProducto
        Session("VistaListaProducto") = VistaListaProducto
    End Sub
    Private Sub Guardar()     
        Dim Permiso As Boolean
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        EntidadRegistroInventario.IdInventario = IIf(Not TBIdInventario.Text Is String.Empty, TBIdInventario.Text, 0)
        EntidadRegistroInventario.Descripcion = TBDescripcion.Text
        EntidadRegistroInventario.Observaciones = TBObservaciones.Text
        EntidadRegistroInventario.IdEstado = CInt(DDEstado.SelectedValue)
        If GVInventario.Rows.Count <> 0 Then
            If EntidadRegistroInventario.IdInventario = 0 Then
                AgregarTabla()
                Permiso = True
            Else
                ActualizarTabla()
                Permiso = True
            End If
        Else
            Permiso = False
        End If
        If Permiso = True Then
            EntidadRegistroInventario.TablaInventarioDetalle = TablaInventarioDetalle
            Dim autorizar As Boolean = True
            For Each midata In EntidadRegistroInventario.TablaInventarioDetalle.Rows
                If CInt(midata("IdEstado")) = 1 Then
                    autorizar = False
                    Exit For
                End If
            Next
            If TBIdInventario.Text.Length = 0 Then
                autorizar = True
            End If
            If autorizar = True Then
                NegocioRegistroInventario.Guardar(EntidadRegistroInventario)
                wucDatosAuditoria1.Guardar(EntidadRegistroInventario)
                wucDatosAuditoria1.Visible = True
                TBIdInventario.Text = EntidadRegistroInventario.IdInventario
            End If
        Else
            Response.Write("<SCRIPT LANGUAGE=javascript>")
            Response.Write("alert('No hay productos')")
            Response.Write("</SCRIPT>")
        End If
        wucConsultarProducto.Nuevo()
    End Sub
    Private Sub LlenarDDs()                
        '--------------------------- ---- Sucursal -------------------------------
        Dim tabla = New DataTable
        Dim NegocioSucursal As New Negocio.Sucursal()
        Dim EntidadSucursal As New Entidad.Sucursal()
        Dim tarjeta As New Tarjeta()
        EntidadSucursal.Tarjeta = tarjeta
        EntidadSucursal.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioSucursal.Consultar(EntidadSucursal)
        DDSucursal.DataSource = EntidadSucursal.TablaConsulta
        DDSucursal.DataValueField = "ID"
        DDSucursal.DataTextField = "Descripcion"
        DDSucursal.DataBind()
        DDSucursal.Items.Add(New ListItem("TODO", -1))
        DDSucursal.SelectedValue = 1
        '-------------------------------ALMACEN.----------------------------------------
        ConsultaAlmacen()
        '' --------------------------- ---- Clasificacion ---- ---------------------------
        Dim NegocioClasificacion = New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        EntidadClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioClasificacion.Consultar(EntidadClasificacion)
        DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
        DDClasificacion.DataValueField = "ID"
        DDClasificacion.DataTextField = "Descripcion"
        DDClasificacion.DataBind()
        DDClasificacion.SelectedValue = 1
        ''--------------------------- ----SubClasificacion ---- ---------------------------
        Dim NegocioSubClasificacion = New Negocio.Subclasificacion()
        Dim EntidadSubClasificacion As New Entidad.Subclasificacion()
        EntidadSubClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioSubClasificacion.Consultar(EntidadSubClasificacion)
        DDSubClasificacion.DataSource = EntidadSubClasificacion.TablaConsulta
        DDSubClasificacion.DataValueField = "ID"
        DDSubClasificacion.DataTextField = "Descripcion"
        DDSubClasificacion.DataBind()
        SubClasificacion()
        DDSubClasificacion.SelectedValue = 1
    End Sub
    Private Sub ConsultaAlmacen()
        Dim tablaAlmacenOrigen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)       
        DDAlmacen.Items.Clear()
        DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacen.DataValueField = "ID"
        DDAlmacen.DataTextField = "Descripcion"   
        DDAlmacen.DataBind()
        tablaAlmacenOrigen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenOrigen") = tablaAlmacenOrigen
    End Sub
    Private Sub ConsultaAlmacenBusqueda()
        Dim tablaAlmacenOrigen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)        
        DDAlmacenBusq.Items.Clear()
        DDAlmacenBusq.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenBusq.DataValueField = "ID"
        DDAlmacenBusq.DataTextField = "Descripcion"
        DDAlmacenBusq.DataBind()
        tablaAlmacenOrigen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenOrigen") = tablaAlmacenOrigen
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdInventario.Text = ""
        TBDescripcion.Text = ""
        TBObservaciones.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        wucConsultarProducto.Nuevo()
        DDSucursal.SelectedValue = 1
        DDAlmacen.SelectedValue = 2
        DDClasificacion.SelectedValue = 1
        GVInventario.DataSource = Nothing
        GVInventario.DataBind()
        TablaInventarioDetalle.Clear()
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        IBTAplicar.Visible = False
        IBTCancelar.Visible = False
        BTNConsultar.Enabled = True
        BTNAgregar.Enabled = True
        IBTGuardar.Visible = True
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        If DDEstado.SelectedValue = 1 Then
            Guardar()
        End If
        Limpiar()
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click        
        MultiView1.SetActiveView(View2)
    End Sub
    Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        IBTAplicar.Visible = True
        IBTCancelar.Visible = True
        Dim Tabla As New DataTable
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Tabla = Session("Tabla")
        TBIdInventario.Text = CStr(Tabla.Rows(GridView1.SelectedIndex).Item("IdEncabezado"))
        TBDescripcion.Text = CStr(Tabla.Rows(GridView1.SelectedIndex).Item("Descripcion"))
        TBObservaciones.Text = CStr(Tabla.Rows(GridView1.SelectedIndex).Item("Observacion"))
        DDEstado.SelectedValue = (Tabla.Rows(GridView1.SelectedIndex)).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GridView1.SelectedIndex))
        wucDatosAuditoria1.Visible = True
        '=======================================Inventario Detalle=========================================
        Dim TablaInventarioDetalle As New DataTable()
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId       
        EntidadRegistroInventario.IdInventario = CInt(TBIdInventario.Text)
        NegocioRegistroInventario.Obtener(EntidadRegistroInventario)
        TablaInventarioDetalle = EntidadRegistroInventario.TablaInventarioDetalle
        VistaInventarioDetalle = TablaInventarioDetalle.DefaultView       
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        TablaListaProducto = Session("TablaListaProducto")
        Dim RenglonAInsertar As DataRow
        Dim index As Integer = 0
        For Each Midata In TablaInventarioDetalle.Rows           
            RenglonAInsertar = TablaListaProducto.NewRow()
            RenglonAInsertar("IDProducto") = TablaInventarioDetalle.Rows(index).Item("IdProducto")
            RenglonAInsertar("IdProductoCorto") = TablaInventarioDetalle.Rows(index).Item("IdProductoCorto")
            RenglonAInsertar("DescripcionProducto") = TablaInventarioDetalle.Rows(index).Item("DescripcionProducto")
            RenglonAInsertar("CantidadSistema") = TablaInventarioDetalle.Rows(index).Item("CantidadSistema")
            RenglonAInsertar("IdEstado") = TablaInventarioDetalle.Rows(index).Item("IdEstado")
            RenglonAInsertar("IdAlmacen") = TablaInventarioDetalle.Rows(index).Item("IdAlmacen")
            RenglonAInsertar("Almacen") = TablaInventarioDetalle.Rows(index).Item("Almacen")
            RenglonAInsertar("Estado") = TablaInventarioDetalle.Rows(index).Item("Estado")
            RenglonAInsertar("CantidadReal") = TablaInventarioDetalle.Rows(index).Item("CantidadReal")
            RenglonAInsertar("Diferencia") = TablaInventarioDetalle.Rows(index).Item("Diferencia")
            RenglonAInsertar("idActualizar") = TablaInventarioDetalle.Rows(index).Item("idActualizar")
            If index = 0 Then
                DDSucursal.SelectedValue = CInt(TablaInventarioDetalle.Rows(index).Item("IdSucursal"))
                ConsultaAlmacen()
                DDAlmacen.SelectedValue = CInt(TablaInventarioDetalle.Rows(index).Item("IdAlmacen"))
                DDClasificacion.SelectedValue = 1
                SubClasificacion()
                DDSubClasificacion.SelectedValue = -1
                TablaListaProducto.Rows.Add(RenglonAInsertar)
            End If
            index = index + 1
        Next
        GVInventario.DataSource = VistaInventarioDetalle
        GVInventario.DataBind()
        GVInventario.Columns(6).Visible = False
        GVInventario.Columns(7).Visible = True
        MultiView1.SetActiveView(View1)
        BTNConsultar.Enabled = False
        IBTGuardar.Visible = False
        BTNAgregar.Enabled = False
    End Sub

    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click       
        GVInventario.DataSource = Nothing
        GVInventario.DataBind()
        Dim tabla = New DataTable
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim tarjeta As New Entidad.Tarjeta()
        EntidadRegistroInventario.Tarjeta = tarjeta
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorIdProducto
        EntidadRegistroInventario.IdAlmacen = DDAlmacen.SelectedValue
        EntidadRegistroInventario.IdSubClasificacion = -1
        EntidadRegistroInventario.IdClasificacion = -1
        NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
        tabla = EntidadRegistroInventario.TablaConsulta
        GVInventario.DataSource = tabla
        GVInventario.AutoGenerateColumns = False
        GVInventario.AllowSorting = True
        GVInventario.DataBind()
        Session("TablaListaProducto") = tabla       
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub TBCantidadItem_TextChanged(sender As Object, e As EventArgs)
        TablaListaProducto = Session("TablaListaProducto")
        VistaListaProducto = Session("VistaListaProducto")
        VistaListaProducto = TablaListaProducto.DefaultView
        Dim id As Integer = 0
        Dim acceso As Double
        Dim TXBResponsable As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TXBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim eltextbox As TextBox = CType(gvrFilaActual.FindControl("TBCantidad"), TextBox)
        If Not IsNumeric(eltextbox.Text) Then
            eltextbox.Text = ""
            Exit Sub
        End If
        Dim eltextbox2 As TextBox = CType(gvrFilaActual.FindControl("TBDiferencia"), TextBox)
        id = Convert.ToUInt64(gvrFilaActual.RowIndex)
        acceso = CDbl(eltextbox.Text) - CInt(TablaListaProducto.Rows(id).Item("CantidadSistema"))
        eltextbox2.Text = acceso
        VistaListaProducto(id).Item("IdProducto") = TablaListaProducto.Rows(id).Item("IdProducto")
        VistaListaProducto(id).Item("DescripcionProducto") = TablaListaProducto.Rows(id).Item("DescripcionProducto")
        VistaListaProducto(id).Item("CantidadSistema") = TablaListaProducto.Rows(id).Item("CantidadSistema")
        VistaListaProducto(id).Item("CantidadReal") = CInt(eltextbox.Text)
        VistaListaProducto(id).Item("Diferencia") = acceso
        VistaListaProducto(id).Item("IdActualizar") = 1
        VistaListaProducto(id).Item("Almacen") = TablaListaProducto.Rows(id).Item("Almacen")
        VistaListaProducto(id).Item("Estado") = TablaListaProducto.Rows(id).Item("Estado")
        Session("TablaListaProducto") = TablaListaProducto
        Session("VistaListaProducto") = VistaListaProducto
        GVInventario.DataSource = VistaListaProducto
        GVInventario.DataBind()
    End Sub
    Protected Sub IBTAplicar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTAplicar.Click
        If DDEstado.SelectedValue = 1 Then
            Dim TablaInventarioDetalle As New DataTable()
            Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
            Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
            Dim validar As Boolean = True
            TablaInventarioDetalle = Session("TablaInventarioDetalle")
            VistaInventarioDetalle = Session("VistaInventarioDetalle")
            For Each midata In TablaInventarioDetalle.Rows
                If CInt(midata("IdEstado")) = 1 Then
                    validar = False
                    Exit For
                End If
            Next
            If validar = True Then
                GVInventario.DataSource = VistaInventarioDetalle
                GVInventario.DataBind()
                EntidadRegistroInventario.TablaInventarioDetalle = TablaInventarioDetalle
                EntidadRegistroInventario.TablaInventarioDetalle = TablaInventarioDetalle
                NegocioRegistroInventario.Aplicar(EntidadRegistroInventario)
                GVInventario.Columns(5).Visible = False
                GVInventario.Columns(6).Visible = True
                Limpiar()
            End If
        End If
    End Sub

    Private Sub AgregarTabla()
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        Dim tablalistaproducto As DataTable = Session("TablaListaProducto")
        EntidadRegistroInventario.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadRegistroInventario.IdSucursal = tablaAlmacenOrigen.Rows(DDAlmacen.SelectedIndex).Item("IdSucursal")
        EntidadRegistroInventario.IdAlmacen = CInt(DDAlmacen.SelectedValue)
        EntidadRegistroInventario.IdClasificacion = CInt(DDClasificacion.SelectedValue)
        EntidadRegistroInventario.IdSubClasificacion = CInt(DDSubClasificacion.SelectedValue)
        For Each row As GridViewRow In GVInventario.Rows
            Dim renglon As Integer = CInt(CType(row.FindControl("TBCantidad"), TextBox).Text)
            Dim vacio As String = CStr(CType(row.FindControl("TBCantidad"), TextBox).Text)
            If IsNumeric(vacio) Then
                If renglon = 1 Then
                    Dim RenglonAInsertar As DataRow
                    RenglonAInsertar = TablaInventarioDetalle.NewRow()
                    RenglonAInsertar("IdDetalle") = 0
                    RenglonAInsertar("IdEncabezado") = EntidadRegistroInventario.IdInventario
                    RenglonAInsertar("IdSucursal") = tablaAlmacenOrigen.Rows(DDAlmacen.SelectedIndex).Item("IdSucursal")
                    RenglonAInsertar("IdAlmacen") = EntidadRegistroInventario.IdAlmacen
                    RenglonAInsertar("IdClasificacion") = 1
                    RenglonAInsertar("IdSubClasificacion") = 1
                    RenglonAInsertar("IdProducto") = Convert.ToDouble(tablalistaproducto.Rows(row.RowIndex).Item("IdProducto"))
                    RenglonAInsertar("IdProductoCorto") = Convert.ToString(tablalistaproducto.Rows(row.RowIndex).Item("IdProductoCorto"))
                    RenglonAInsertar("DescripcionProducto") = Convert.ToString(tablalistaproducto.Rows(row.RowIndex).Item("DescripcionProducto"))
                    RenglonAInsertar("CantidadSistema") = Convert.ToInt64(tablalistaproducto.Rows(row.RowIndex).Item("CantidadSistema"))
                    RenglonAInsertar("CantidadReal") = CInt(CType(row.FindControl("TBCantidad"), TextBox).Text)
                    RenglonAInsertar("Diferencia") = CInt(CType(row.FindControl("TBDiferencia"), TextBox).Text)
                    RenglonAInsertar("IdUsuarioCreacion") = 1
                    RenglonAInsertar("FechaCreacion") = Now
                    RenglonAInsertar("IdUsuarioActualizacion") = 1
                    RenglonAInsertar("FechaActualizacion") = CDate(Now)
                    RenglonAInsertar("idEstado") = DDEstado.SelectedValue
                    RenglonAInsertar("IdActualizar") = Convert.ToDouble(tablalistaproducto.Rows(row.RowIndex).Item("IdActualizar"))
                    RenglonAInsertar("Almacen") = Convert.ToString(row.Cells(6).Text)
                    TablaInventarioDetalle.Rows.Add(RenglonAInsertar)
                End If
            End If
        Next
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        GVInventario.DataSource = VistaInventarioDetalle
        GVInventario.DataBind()
    End Sub

    Private Sub ActualizarTabla()
        TablaInventarioDetalle.Clear()
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()

        EntidadRegistroInventario.IdInventario = IIf(Not TBIdInventario.Text Is String.Empty, TBIdInventario.Text, 0)
        EntidadRegistroInventario.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadRegistroInventario.IdSucursal = CInt(DDSucursal.SelectedValue)
        EntidadRegistroInventario.IdAlmacen = CInt(DDAlmacen.SelectedValue)
        EntidadRegistroInventario.IdClasificacion = CInt(DDClasificacion.SelectedValue)
        EntidadRegistroInventario.IdSubClasificacion = CInt(DDSubClasificacion.SelectedValue)
        '====================  LLENAR LAS TABLAS TEMPORALES  =====================================
        For Each row As GridViewRow In Me.GVInventario.Rows
            Dim RenglonAInsertar As DataRow
            RenglonAInsertar = TablaInventarioDetalle.NewRow()
            RenglonAInsertar("IdEncabezado") = EntidadRegistroInventario.IdInventario
            RenglonAInsertar("IdSucursal") = EntidadRegistroInventario.IdSucursal
            RenglonAInsertar("IdAlmacen") = EntidadRegistroInventario.IdAlmacen
            RenglonAInsertar("IdClasificacion") = EntidadRegistroInventario.IdClasificacion
            RenglonAInsertar("IdSubClasificacion") = EntidadRegistroInventario.IdSubClasificacion
            RenglonAInsertar("IdProducto") = Convert.ToInt64(row.Cells(0).Text)
            RenglonAInsertar("DescripcionProducto") = Convert.ToString(row.Cells(1).Text)
            RenglonAInsertar("CantidadSistema") = Convert.ToInt64(row.Cells(2).Text)
            RenglonAInsertar("CantidadReal") = CInt(CType(row.FindControl("TBCantidad"), TextBox).Text)
            RenglonAInsertar("Diferencia") = CInt(CType(row.FindControl("TBDiferencia"), TextBox).Text)
            RenglonAInsertar("IdUsuarioCreacion") = 1
            RenglonAInsertar("FechaCreacion") = Now
            RenglonAInsertar("IdUsuarioActualizacion") = 1
            RenglonAInsertar("FechaActualizacion") = CDate(Now)
            RenglonAInsertar("idEstado") = DDEstado.SelectedValue
            RenglonAInsertar("IdActualizar") = 1
            TablaInventarioDetalle.Rows.Add(RenglonAInsertar)
        Next
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        GVInventario.DataSource = VistaInventarioDetalle
        GVInventario.DataBind()
    End Sub

    Protected Sub DDSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDSucursal.SelectedIndexChanged
        ConsultaAlmacen()
    End Sub
    Protected Sub SubClasificacion()
        Dim tabla = New DataTable
        Dim NegocioSubClasificacion As New Negocio.Subclasificacion()
        Dim EntidadSubClasificacion As New Entidad.Subclasificacion()
        Dim tarjeta As New Entidad.Tarjeta()
        EntidadSubClasificacion.Tarjeta = tarjeta
        EntidadSubClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadSubClasificacion.IdClasificacion = DDClasificacion.SelectedValue
        NegocioSubClasificacion.Consultar(EntidadSubClasificacion)
        DDSubClasificacion.DataSource = EntidadSubClasificacion.TablaConsulta
        DDSubClasificacion.DataValueField = "Id"
        DDSubClasificacion.DataTextField = "Descripcion"
        DDSubClasificacion.DataBind()
        DDSubClasificacion.Items.Add(New ListItem("TODOS", -1))
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub DDClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacion.SelectedIndexChanged
        SubClasificacion()
    End Sub
    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        If DDEstado.SelectedValue = 1 Then
            Dim TablaInventarioDetalle As New DataTable()
            Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
            Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
            Dim tabla As DataTable
            tabla = Session("TablaListaProducto")
            Dim autorizar As Boolean = True
            For Each midata In tabla.Rows
                If CInt(midata("IdEstado")) = 1 Then
                    autorizar = False
                    Exit For
                End If
            Next
            If autorizar = True Then
                TablaInventarioDetalle = Session("TablaInventarioDetalle")
                VistaInventarioDetalle = Session("VistaInventarioDetalle")
                GVInventario.DataSource = VistaInventarioDetalle
                GVInventario.DataBind()
                EntidadRegistroInventario.TablaInventarioDetalle = TablaInventarioDetalle
                EntidadRegistroInventario.IdInventario = IIf(Not TBIdInventario.Text Is String.Empty, TBIdInventario.Text, 0)
                EntidadRegistroInventario.Descripcion = TBDescripcion.Text
                EntidadRegistroInventario.Observaciones = TBObservaciones.Text
                EntidadRegistroInventario.IdEstado = 2
                NegocioRegistroInventario.Guardar(EntidadRegistroInventario)
                GVInventario.Columns(5).Visible = False
                GVInventario.Columns(6).Visible = True
                Limpiar()
            End If
        End If
    End Sub
    Protected Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
        wucConsultarProducto.BusquedaProducto()
        wucConsultarProducto.RegresarFoco()
    End Sub   
    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim TablaConsulta As New DataTable
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadRegistroInventario.IdSucursal = -1
        EntidadRegistroInventario.IdAlmacen = -1
        EntidadRegistroInventario.IdEstado = -1
        EntidadRegistroInventario.FechaInicio = Now
        EntidadRegistroInventario.FechaFin = Now
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
        TablaConsulta = EntidadRegistroInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = TablaConsulta
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "IdEncabezado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observaciones", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Creacion", "FechaCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        GridView1.DataBind()
        Session("Tabla") = TablaConsulta
    End Sub

    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim TablaConsulta As New DataTable
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadRegistroInventario.IdSucursal = -1
        EntidadRegistroInventario.IdAlmacen = -1
        EntidadRegistroInventario.IdEstado = -1
        EntidadRegistroInventario.FechaInicio = CDate(fechainicio)
        EntidadRegistroInventario.FechaFin = Now
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
        TablaConsulta = EntidadRegistroInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = TablaConsulta
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "IdEncabezado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observaciones", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Creacion", "FechaCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        GridView1.DataBind()
        Session("Tabla") = TablaConsulta
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim TablaConsulta As New DataTable
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadRegistroInventario.IdSucursal = -1
        EntidadRegistroInventario.IdAlmacen = -1
        EntidadRegistroInventario.IdEstado = -1
        EntidadRegistroInventario.FechaInicio = CDate("02/" + Now.Date.ToString("MM/yyyy"))
        EntidadRegistroInventario.FechaFin = Now
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
        TablaConsulta = EntidadRegistroInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = TablaConsulta
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "IdEncabezado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observaciones", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Creacion", "FechaCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        GridView1.DataBind()
        Session("Tabla") = TablaConsulta
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim TablaConsulta As New DataTable
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadRegistroInventario.IdSucursal = -1
        EntidadRegistroInventario.IdAlmacen = -1
        EntidadRegistroInventario.IdEstado = -1
        EntidadRegistroInventario.FechaInicio = CDate("02/01/" + Now.Date.ToString("yyyy"))
        EntidadRegistroInventario.FechaFin = Now
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
        TablaConsulta = EntidadRegistroInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = TablaConsulta
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "IdEncabezado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observaciones", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Creacion", "FechaCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        GridView1.DataBind()
        Session("Tabla") = TablaConsulta
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub

    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        Dim NegocioRegistroInventario As New Negocio.RegistroInventario()
        Dim EntidadRegistroInventario As New Entidad.RegistroInventario()
        Dim TablaConsulta As New DataTable
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadRegistroInventario.IdSucursal = -1
        EntidadRegistroInventario.IdAlmacen = DDAlmacenBusq.SelectedValue
        EntidadRegistroInventario.IdEstado = DDEstadoBusq.SelectedValue
        EntidadRegistroInventario.FechaInicio = CDate(TBFechaInicio.Text)
        EntidadRegistroInventario.FechaFin = CDate(TBFechaFin.Text)
        EntidadRegistroInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioRegistroInventario.Consultar(EntidadRegistroInventario)
        TablaConsulta = EntidadRegistroInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = TablaConsulta
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "IdEncabezado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observaciones", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Creacion", "FechaCreacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        GridView1.DataBind()
        Session("Tabla") = TablaConsulta
    End Sub
End Class