Imports System.Data
Imports Entidad.Tarjeta
Imports Operacion.Configuracion.Constante
Imports System.Collections.ObjectModel

Partial Class _Default
    Inherits Page
    Public TablaInventarioDetalle As New DataTable()
    Public VistaInventarioDetalle As New DataView()
    Private TablaPendientes As New DataTable()
    Private VistaPendientes As New DataView()
    Public TablaPendientes2 As New DataTable()
    Public VistaPendientes2 As New DataView()
    Public fecha As Date
    Private ListaEstado As New ObservableCollection(Of Entidad.TipoSolicitudEstado)
    Private ListaPrioridad As New ObservableCollection(Of Entidad.TipoPrioridad)
    Private ListaAlmacen As New ObservableCollection(Of Entidad.Almacen)
    Public band As Boolean
    Public local As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            IBTCancelar.Visible = False
            IBTImprimir.Visible = False
            TBFechaInicio.Text = "01/01/" + Now.ToString("yyyy")
            TBFechaFin.Text = Now.ToString("dd/MM/yyyy")
            CType(Master.FindControl("LBOpcion"), Label).Text = "Movimiento de Inventario"
            wucDatosAuditoria1.Visible = True
            LlenarDDs()
            LLenarDDsPendientes()
            wucDatosAuditoria1.Visible = False
            divAvanzado.Visible = False
            divAvanzado2.Visible = False
            '===========Tabla Pendientes 2====================================
            TablaPendientes2.Columns.Add(New DataColumn("IdEntrega", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("Recibi", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("IdAlmacenOrigen", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("IdAlmacenDestino", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("CantidadFaltante", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("Fecha", System.Type.GetType("System.String")))
            TablaPendientes2.Columns.Add(New DataColumn("IdProductoEntregaEstatus", System.Type.GetType("System.String")))
            VistaPendientes2 = TablaPendientes2.DefaultView
            Session("TablaPendientes2") = TablaPendientes2
            Session("VistaPendientes2") = VistaPendientes2
            '=======================Tabla Invetario Detalle====================
            TablaInventarioDetalle.Columns.Clear()
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdInventarioMovimientoDetalle", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdInventarioMovimiento", System.Type.GetType("System.Int32")))            
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.Int32")))
            TablaInventarioDetalle.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))            

            VistaInventarioDetalle = TablaInventarioDetalle.DefaultView            
            GVInventario.AutoGenerateColumns = False           

            Session("TablaInventarioDetalle") = TablaInventarioDetalle
            Session("VistaInventarioDetalle") = VistaInventarioDetalle
            MultiView1.SetActiveView(View1)           
        Else
            TablaInventarioDetalle = Session("TablaInventarioDetalle")
            VistaInventarioDetalle = Session("VistaInventarioDetalle")
        End If
        AddHandler wucConsultarProducto.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub
    Private Sub AgregarProductos()
        TablaInventarioDetalle = CType(Session("TablaInventarioDetalle"), DataTable)
        VistaInventarioDetalle = CType(Session("VistaInventarioDetalle"), DataView)        
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = wucConsultarProducto.ObtenerProductos()
        For Each producto In productosSeleccionados
            Dim bandera = Not TablaInventarioDetalle.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdProducto").ToString() = producto.IdProducto)
            If bandera Then
                If producto.IdProducto = 0 Or CInt(producto.Cantidad) < 1 Then
                    Continue For
                End If
                'Validar que el producto en el el almacen origen exista ----
                Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario
                Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario
                Dim TablaExistenciaProducto = New DataTable
                EntidadMovimientoInventario.IdProducto = producto.IdProducto
                EntidadMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigen.SelectedValue
                EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
                NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
                TablaExistenciaProducto = EntidadMovimientoInventario.TablaConsulta

                If DDTipo.SelectedValue = 2 Or DDTipo.SelectedValue = 3 Then 'SI ES SALIDA
                    If TablaExistenciaProducto.Rows.Count = 0 Then ' si el producto no existe en el almacen
                        Exit Sub
                    End If
                    If TablaExistenciaProducto.Rows(0).Item("Cantidad") < CInt(TBCantidad.Text) Then
                        local = TablaExistenciaProducto.Rows(0).Item("Cantidad")
                        band = True
                    End If
                End If
                Dim RenglonAInsertar As DataRow
                RenglonAInsertar = TablaInventarioDetalle.NewRow()
                RenglonAInsertar("IdInventarioMovimientoDetalle") = 0
                If TBIdMovimientoInventario.Text Is String.Empty Then
                    RenglonAInsertar("IdInventarioMovimiento") = 0
                Else
                    RenglonAInsertar("IdInventarioMovimiento") = CInt(TBIdMovimientoInventario.Text)
                End If

                RenglonAInsertar("IdProducto") = producto.IdProducto
                RenglonAInsertar("IdProductoCorto") = producto.IdProductoCorto
                RenglonAInsertar("Descripcion") = producto.Producto
                If TBCantidad.Text Is String.Empty Then
                    RenglonAInsertar("Cantidad") = 0
                ElseIf band = True Then
                    RenglonAInsertar("Cantidad") = CInt(local)
                Else
                    RenglonAInsertar("Cantidad") = CInt(TBCantidad.Text)
                End If

                RenglonAInsertar("IdEstado") = DDEstado.SelectedValue
                RenglonAInsertar("Estado") = DDEstado.SelectedItem.ToString()
                TablaInventarioDetalle.Rows.Add(RenglonAInsertar)

                band = False
                GVInventario.DataSource = TablaInventarioDetalle
                GVInventario.AutoGenerateColumns = False
                GVInventario.AllowSorting = True
                GVInventario.DataBind()
                Session("TablaListaProducto") = TablaInventarioDetalle
            End If
        Next
    End Sub
    Private Sub Limpiar()
        TBIdMovimientoInventario.Text = ""       
        TBObservacion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False        
        DDTipo.SelectedValue = 1             
        TBCantidad.Text = ""
        GVInventario.DataSource = Nothing
        GVInventario.DataBind()
        TablaInventarioDetalle.Clear()
        Session("TablaInventarioDetalle") = TablaInventarioDetalle      
        DDAlmacenDestino.Enabled = False
    End Sub
    Protected Sub ConsultaAlmacenPendienteOrigen()
        Dim tablaAlmacen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda       
        NegocioAlmacen.Consultar(EntidadAlmacen)   
        DDAlmacenOrigenPendiente.Items.Clear()
        DDAlmacenOrigenPendiente.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenOrigenPendiente.DataValueField = "ID"
        DDAlmacenOrigenPendiente.DataTextField = "Descripcion"
        DDAlmacenOrigenPendiente.DataBind()        
    End Sub
    Protected Sub ConsultaAlmacenPendienteDestino()
        Dim tablaAlmacen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda        
        NegocioAlmacen.Consultar(EntidadAlmacen)       
        DDAlmacenDestinoPendiente.Items.Clear()
        DDAlmacenDestinoPendiente.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenDestinoPendiente.DataValueField = "ID"
        DDAlmacenDestinoPendiente.DataTextField = "Descripcion"
        DDAlmacenDestinoPendiente.DataBind()        
    End Sub
    Private Sub LLenarDDsPendientes()      
        DDEstatus.Items.Add(New ListItem("PENDIENTE", 1))
        DDEstatus.Items.Add(New ListItem("ENTREGADO", 2))
        DDEstatus.Items.Add(New ListItem("CANCELADO", 3))
        DDEstatus.Items.Add(New ListItem("TODOS", -1))
        DDEstatus.SelectedValue = 1       
        TBFechaInicioPendiente.Text = "01/01/" + Now.ToString("yyyy")
        TBFechaFinPendiente.Text = Now.ToString("dd/MM/yyyy")
        ConsultaAlmacenPendienteDestino()
        ConsultaAlmacenPendienteOrigen()
    End Sub
    Private Sub LlenarDDs()
        DDAlmacenDestino.Enabled = False
        'Estado
        DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
        DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
        DDEstado.SelectedValue = "1"
        'Estado para filtro
        DDEstadoBusq.Items.Add(New ListItem("ACTIVO", "1"))
        DDEstadoBusq.Items.Add(New ListItem("INACTIVO", "2"))
        DDEstadoBusq.Items.Add(New ListItem("TODOS", "-1"))
        DDEstadoBusq.SelectedValue = "-1"
        'Fecha
        'TBFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
        'DD Sucursal Origen-----------------------------------
        Dim tabla = New DataTable
        Dim NegocioSucursal As New Negocio.Sucursal()
        Dim EntidadSucursal As New Entidad.Sucursal()
        EntidadSucursal.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioSucursal.Consultar(EntidadSucursal)       
        ConsultaAlmacenOrigen()
        ConsultaAlmacenDestino()
        ConsultaAlmacenBusqueda()        
        'DD Sucursal Destino-----------------------------------
        Dim NegocioSucursalDestino = New Negocio.Sucursal()
        Dim EntidadSucursalDestino As New Entidad.Sucursal()
        EntidadSucursalDestino.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioSucursalDestino.Consultar(EntidadSucursalDestino)       
        'DD Tipo-------------------------------------------------
        DDTipo.Items.Add(New ListItem("ENTRADA", 1))
        DDTipo.Items.Add(New ListItem("SALIDA", 2))
        DDTipo.Items.Add(New ListItem("TRASPASO", 3))
        ObtenerSubtipo()        
    End Sub
    Protected Sub ConsultaAlmacenOrigen()
        Dim tablaAlmacenOrigen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)
        DDAlmacenOrigen.Items.Clear()
        DDAlmacenOrigen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenOrigen.DataValueField = "ID"
        DDAlmacenOrigen.DataTextField = "Descripcion"
        DDAlmacenOrigen.DataBind()
        DDAlmacenOrigen.SelectedValue = 2
        tablaAlmacenOrigen = EntidadAlmacen.TablaConsulta
        Session("tablaAlmacenOrigen") = tablaAlmacenOrigen       
    End Sub
    Protected Sub ConsultaAlmacenDestino()
        Dim tablaAlmacen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()        
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)
        DDAlmacenDestino.Items.Clear()
        DDAlmacenDestino.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenDestino.DataValueField = "ID"
        DDAlmacenDestino.DataTextField = "Descripcion"
        DDAlmacenDestino.DataBind()    
    End Sub
    Protected Sub ConsultaAlmacenBusqueda()
        Dim tablaAlmacen = New DataTable
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()       
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda     
        NegocioAlmacen.Consultar(EntidadAlmacen)       
        DDAlmacenBusq.Items.Clear()
        DDAlmacenBusq.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacenBusq.DataValueField = "ID"
        DDAlmacenBusq.DataTextField = "Descripcion"
        DDAlmacenBusq.DataBind()
        DDAlmacenBusq.SelectedValue = 2
        Dim TablaAlmacenBusqueda As DataTable = EntidadAlmacen.TablaConsulta
        Session("TablaAlmacenBusqueda") = TablaAlmacenBusqueda       
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdMovimientoInventario.Text = ""  
        TBObservacion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False           
        TBCantidad.Text = ""
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        habilitar()
        TablaInventarioDetalle.Clear()
        GVInventario.DataSource = TablaInventarioDetalle
        GVInventario.DataBind()
        IBTCancelar.Visible = False
        IBTImprimir.Visible = False
        IBTGuardar.Visible = True
        GVInventario.Columns(0).Visible = True     
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        TablaInventarioDetalle = Session("TablaInventarioDetalle")
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        If TablaInventarioDetalle.Rows.Count > 0 Then
            If DDAlmacenOrigen.SelectedValue = -1 Or DDAlmacenDestino.SelectedValue = -1 Then ' validar que se valla o entre a un almacen 
                Exit Sub
            End If
            EntidadMovimientoInventario.IdMovimientoInventario = IIf(Not TBIdMovimientoInventario.Text Is String.Empty, TBIdMovimientoInventario.Text, 0)      
            EntidadMovimientoInventario.Observacion = TBObservacion.Text
            EntidadMovimientoInventario.IdSucursalOrigen = tablaAlmacenOrigen.Rows(DDAlmacenOrigen.SelectedIndex).Item("IdSucursal")
            EntidadMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigen.SelectedValue
            EntidadMovimientoInventario.IdSucursalDestino = tablaAlmacenOrigen.Rows(DDAlmacenDestino.SelectedIndex).Item("IdSucursal")
            EntidadMovimientoInventario.IdAlmacenDestino = DDAlmacenDestino.SelectedValue
            EntidadMovimientoInventario.IdTipo = DDTipo.SelectedValue
            EntidadMovimientoInventario.IdSubTipo = DDSubTipo.SelectedValue
            EntidadMovimientoInventario.IdEstado = CInt(DDEstado.SelectedValue)

            EntidadMovimientoInventario.TablaMovimientoDetalle = TablaInventarioDetalle
            NegocioMovimientoInventario.Guardar(EntidadMovimientoInventario)            
            wucDatosAuditoria1.Visible = True            
            TBIdMovimientoInventario.Text = EntidadMovimientoInventario.IdMovimientoInventario

            '##################   QUITAR CONSULTA CUANDO SE USE TARJETA PARA LOS DATOS DE AUDITORIA   ####################
            EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
            NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
            wucDatosAuditoria1.SeleccionarIndice(EntidadMovimientoInventario.TablaConsulta.Rows(0))
            '#######################################################################################################                   
            Limpiar()
            TablaInventarioDetalle.Clear()
            GVInventario.DataSource = TablaInventarioDetalle
            GVInventario.DataBind()
        End If
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click        
        MultiView1.SetActiveView(View2)        
        GVInventario.Columns(0).Visible = False
    End Sub
    Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub habilitar()
        TBIdMovimientoInventario.Enabled = False    
        TBObservacion.Enabled = True
        DDEstado.Enabled = True      
        DDAlmacenOrigen.Enabled = True
        DDAlmacenDestino.Enabled = False
        DDTipo.Enabled = True
        DDSubTipo.Enabled = True
        TBCantidad.Enabled = True        
        BTNAgregar.Enabled = True        
    End Sub
    Protected Sub Inhabilitar()
        TBIdMovimientoInventario.Enabled = False    
        TBObservacion.Enabled = False
        DDEstado.Enabled = False      
        DDAlmacenOrigen.Enabled = False
        DDAlmacenDestino.Enabled = False
        DDTipo.Enabled = False
        DDSubTipo.Enabled = False
        TBCantidad.Enabled = False     
        BTNAgregar.Enabled = False        
        wucDatosAuditoria1.Visible = False
    End Sub
    Protected Sub IBTAplicar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTAplicar.Click
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        EntidadMovimientoInventario.TablaMovimientoDetalle = TablaInventarioDetalle
        NegocioMovimientoInventario.Aplicar(EntidadMovimientoInventario)
        Limpiar()
        TablaInventarioDetalle.Clear()
    End Sub
    Protected Sub ObtenerSubtipo()
        Dim tabla = New DataTable
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tarjeta As New Entidad.Tarjeta()
        EntidadMovimientoInventario.Tarjeta = tarjeta
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
        EntidadMovimientoInventario.IdTipo = DDTipo.SelectedValue
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        DDSubTipo.DataSource = EntidadMovimientoInventario.TablaConsulta
        DDSubTipo.DataValueField = "Id"
        DDSubTipo.DataTextField = "Descripcion"
        DDSubTipo.DataBind()       
        DDAlmacenDestino.Enabled = False
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub DDTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDTipo.SelectedIndexChanged         
        ObtenerSubtipo()
        If DDTipo.SelectedValue = 3 Then
            DDAlmacenDestino.Enabled = True
        Else
            DDAlmacenDestino.Enabled = False
        End If
    End Sub
    Protected Sub DDSubTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDSubTipo.SelectedIndexChanged

    End Sub
    Protected Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click    
        wucConsultarProducto.BusquedaProducto()
        wucConsultarProducto.RegresarFoco()
        TBCantidad.Text = ""
    End Sub
    Protected Sub BTNEliminar_OnClick(sender As Object, e As EventArgs)
        TablaInventarioDetalle = Session("TablaInventarioDetalle")
        VistaInventarioDetalle = Session("VistaInventarioDetalle")        
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim Renglon As Integer = gvrFilaActual.RowIndex        
        VistaInventarioDetalle(Renglon).Delete()        
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        GVInventario.DataSource = VistaInventarioDetalle
        GVInventario.DataBind()       
    End Sub

    Protected Sub GVInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVInventario.SelectedIndexChanged
       
    End Sub
    Protected Sub Eliminar()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        GVInventario.DataSource = Nothing
        GVInventario.DataBind()
        Dim Tabla As New DataTable
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Tabla = Session("Tabla")
        TBIdMovimientoInventario.Text = CStr(Tabla.Rows(GridView1.SelectedIndex).Item("ID"))     
        TBObservacion.Text = CStr(Tabla.Rows(GridView1.SelectedIndex).Item("Observacion"))
        DDEstado.SelectedValue = (Tabla.Rows(GridView1.SelectedIndex)).Item("IdEstado")  
        ConsultaAlmacenOrigen()
        DDAlmacenOrigen.SelectedValue = (Tabla.Rows(GridView1.SelectedIndex)).Item("IdAlmacenOrigen")
        DDTipo.SelectedValue = (Tabla.Rows(GridView1.SelectedIndex)).Item("IdTipo")
        ObtenerSubtipo()
        DDSubTipo.SelectedValue = (Tabla.Rows(GridView1.SelectedIndex)).Item("IdSubTipo")
        ConsultaAlmacenDestino()
        DDAlmacenDestino.SelectedValue = (Tabla.Rows(GridView1.SelectedIndex)).Item("IdAlmacenDestino")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GridView1.SelectedIndex))
        wucDatosAuditoria1.Visible = True
        fecha = CDate(Tabla.Rows(GridView1.SelectedIndex).Item("FechaCreacion"))
        Session("fecha") = fecha
        '=======================================Movimiento Inventario Detalle=========================================        
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadMovimientoInventario.IdMovimientoInventario = TBIdMovimientoInventario.Text
        NegocioMovimientoInventario.Obtener(EntidadMovimientoInventario)
        TablaInventarioDetalle = EntidadMovimientoInventario.TablaMovimientoDetalle
        VistaInventarioDetalle = TablaInventarioDetalle.DefaultView
        GVInventario.DataSource = VistaInventarioDetalle
        GVInventario.DataBind()    
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        IBTCancelar.Visible = True
        IBTImprimir.Visible = True
        IBTGuardar.Visible = False
        MultiView1.SetActiveView(View1)
        Inhabilitar()
        wucDatosAuditoria1.Visible = True
    End Sub
    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadMovimientoInventario.IdMovimientoInventario = IIf(Not TBIdMovimientoInventario.Text Is String.Empty, TBIdMovimientoInventario.Text, 0)    
        EntidadMovimientoInventario.Observacion = TBObservacion.Text
        EntidadMovimientoInventario.IdSucursalOrigen = tablaAlmacenOrigen.Rows(DDAlmacenOrigen.SelectedIndex).Item("IdSucursal")
        EntidadMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigen.SelectedValue
        EntidadMovimientoInventario.IdSucursalDestino = tablaAlmacenOrigen.Rows(DDAlmacenDestino.SelectedIndex).Item("IdSucursal")
        EntidadMovimientoInventario.IdAlmacenDestino = DDAlmacenDestino.SelectedValue
        EntidadMovimientoInventario.IdTipo = DDTipo.SelectedValue
        EntidadMovimientoInventario.IdSubTipo = DDSubTipo.SelectedValue
        EntidadMovimientoInventario.IdEstado = 2
        EntidadMovimientoInventario.TablaMovimientoDetalle = TablaInventarioDetalle   
        If DDTipo.SelectedValue = 3 And DDSubTipo.SelectedValue = 2 Then
            EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultarPorIdPersonas
            NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
            If EntidadMovimientoInventario.validar = False Then
                Exit Sub
            End If
        End If
        '=============
        'Si todo salio bien continua con la cancelacion
        NegocioMovimientoInventario.Cancelar(EntidadMovimientoInventario)
        Limpiar()
    End Sub
    Private Sub LlenarSolicitudes()
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadMovimientoInventario.IdAlmacenOrigen = CType(DDAlmacenOrigenPendiente.SelectedValue, Integer)
        EntidadMovimientoInventario.IdAlmacenDestino = CType(DDAlmacenDestinoPendiente.SelectedValue, Integer)
        EntidadMovimientoInventario.Estatus = CType(DDEstatus.SelectedValue, Integer)
        EntidadMovimientoInventario.FechaInicio = CDate(TBFechaInicioPendiente.Text)
        EntidadMovimientoInventario.FechaFin = CDate(TBFechaFinPendiente.Text)
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaPendientes = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaPendientes
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()      
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVSolicitud.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            Dim NuevoRow As DataRow = TablaPendientes.NewRow()
            CType(MiDataRow.FindControl("GVTBCantidad"), TextBox).Text = TablaPendientes.Rows(Index).Item("Recibi")
        Next
        Session("TablaPendientes") = TablaPendientes
        Session("VistaPendientes") = VistaPendientes
    End Sub
    Protected Sub BTNAutorizarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)      
        Try
            TablaPendientes = CType(Session("TablaPendientes"), DataTable)
            Dim nMovimientoInventario = New Negocio.MovimientoInventario()
            Dim eMovimientoInventario = New Entidad.MovimientoInventario()
            eMovimientoInventario.TablaPendientes = TablaPendientes
            nMovimientoInventario.ActualizarPendientes(eMovimientoInventario)
            LlenarSolicitudes()          
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BTNAutorizar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Autorizar(index)
    End Sub
    Private Sub GuardaFila(index As Integer, cantidad As String, idEstado As Integer)
        Try
            TablaPendientes = CType(Session("TablaPendientes"), DataTable)
            Dim nMovimientoInventario = New Negocio.MovimientoInventario()
            Dim eMovimientoInventario = New Entidad.MovimientoInventario()
            eMovimientoInventario.IdMovimientoInventario = CType(TablaPendientes.Rows(index).Item("IdEntrega"), Integer)
            eMovimientoInventario.TablaPendientes = TablaPendientes
            nMovimientoInventario.ActualizarPendientes(eMovimientoInventario)
            LlenarSolicitudes()         
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Autorizar(index As Integer)
        Try
            TablaPendientes2 = Session("TablaPendientes2")
            TablaPendientes = CType(Session("TablaPendientes"), DataTable)
            Dim RenglonAInsertar As DataRow
            Dim nMovimientoInventario = New Negocio.MovimientoInventario()
            Dim eMovimientoInventario = New Entidad.MovimientoInventario()

            RenglonAInsertar = TablaPendientes2.NewRow()
            RenglonAInsertar("IdEntrega") = TablaPendientes.Rows(index).Item("IdEntrega")
            RenglonAInsertar("IdProducto") = TablaPendientes.Rows(index).Item("IdProducto")
            RenglonAInsertar("Cantidad") = TablaPendientes.Rows(index).Item("Cantidad")
            RenglonAInsertar("Recibi") = TablaPendientes.Rows(index).Item("Recibi")
            RenglonAInsertar("IdAlmacenOrigen") = TablaPendientes.Rows(index).Item("IdAlmacenOrigen")
            RenglonAInsertar("IdAlmacenDestino") = TablaPendientes.Rows(index).Item("IdAlmacenDestino")
            RenglonAInsertar("CantidadFaltante") = TablaPendientes.Rows(index).Item("CantidadFaltante")
            RenglonAInsertar("IdProductoEntregaEstatus") = TablaPendientes.Rows(index).Item("IdProductoEntregaEstatus")

            TablaPendientes2.Rows.Add(RenglonAInsertar)
            Session("TablaPendientes2") = TablaPendientes2
            eMovimientoInventario.TablaPendientes = TablaPendientes2
            nMovimientoInventario.ActualizarPendientes(eMovimientoInventario)
            LlenarSolicitudes()
            TablaPendientes2.Clear()   
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GVICantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaPendientes = CType(Session("TablaPendientes"), DataTable)
        Dim TBResponsable As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim Recibi As TextBox = CType(sender, TextBox)
        If IsNumeric(Recibi.Text) Then
            actualizarrenglon(TablaPendientes, index, Recibi.Text)
        End If
        Session("TablaPendientes") = TablaPendientes
    End Sub

    Protected Sub TBCantidadActualizarItem_TextChanged(sender As Object, e As EventArgs)
        TablaInventarioDetalle = Session("TablaInventarioDetalle")
        VistaInventarioDetalle = Session("VistaInventarioDetalle")       
        Dim id As Integer = 0
        Dim TXBResponsable As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TXBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim eltextbox As TextBox = CType(gvrFilaActual.FindControl("TBCantidadActualizar"), TextBox)
        id = Convert.ToUInt64(gvrFilaActual.RowIndex)        
        'Validar que el producto en el el almacen origen exista ----
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario
        Dim TablaExistenciaProducto = New DataTable
        EntidadMovimientoInventario.IdProducto = TablaInventarioDetalle.Rows(id).Item("IdProducto")
        EntidadMovimientoInventario.IdAlmacenOrigen = DDAlmacenOrigen.SelectedValue
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        TablaExistenciaProducto = EntidadMovimientoInventario.TablaConsulta
        'If DDTipo.SelectedValue = 2 Then 'SI ES SALIDA
        If DDTipo.SelectedValue = 2 Or DDTipo.SelectedValue = 3 Then 'SI ES SALIDA
            If TablaExistenciaProducto.Rows.Count = 0 Then ' si el producto no existe en el almacen
                Exit Sub
            End If
            If TablaExistenciaProducto.Rows(0).Item("Cantidad") < CInt(eltextbox.Text) Then
                local = TablaExistenciaProducto.Rows(0).Item("Cantidad")
                band = True
            End If
        End If
        ''-----------###############################################################        
        VistaInventarioDetalle(id).Item("IdProducto") = TablaInventarioDetalle.Rows(id).Item("IdProducto")
        VistaInventarioDetalle(id).Item("IdProductoCorto") = TablaInventarioDetalle.Rows(id).Item("IdProductoCorto")
        VistaInventarioDetalle(id).Item("Descripcion") = TablaInventarioDetalle.Rows(id).Item("Descripcion")
        If eltextbox.Text Is String.Empty Then
            VistaInventarioDetalle(id).Item("Cantidad") = 0
        ElseIf band = True Then
            VistaInventarioDetalle(id).Item("Cantidad") = CInt(local)
        Else
            VistaInventarioDetalle(id).Item("Cantidad") = CInt(eltextbox.Text)
        End If        
        Session("TablaInventarioDetalle") = TablaInventarioDetalle
        Session("VistaInventarioDetalle") = VistaInventarioDetalle
        GVInventario.DataSource = VistaInventarioDetalle
        GVInventario.DataBind()
        band = False        
        TBCantidad.Text = ""
        BTNAgregar.Enabled = True        
    End Sub
    Private Sub actualizarrenglon(ByRef TablaPendientes As DataTable, ByVal index As Integer, ByVal Recibi As Integer)
        Dim cantidadFaltante As Integer = TablaPendientes.Rows(index).Item("CantidadFaltante")
        If Recibi <= cantidadFaltante Then
            TablaPendientes.Rows(index).Item("Recibi") = Recibi
            TablaPendientes.AcceptChanges()
        Else

            Dim MiDataRow As GridViewRow = GVSolicitud.Rows(index)
            Dim NuevoRow As DataRow = TablaPendientes.NewRow()
            CType(MiDataRow.FindControl("GVTBCantidad"), TextBox).Text = TablaPendientes.Rows(index).Item("CantidadFaltante")
        End If
    End Sub    
    Protected Sub IBTPendientes_Click(sender As Object, e As ImageClickEventArgs) Handles IBTPendientes.Click
        MultiView1.SetActiveView(View3)
    End Sub
    Protected Sub BTNRegresarPendiente_Click(sender As Object, e As ImageClickEventArgs) Handles BTNRegresarPendiente.Click
        MultiView1.SetActiveView(View1)
        Limpiar()
        habilitar()
    End Sub
    Protected Sub IBTImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTImprimir.Click
        MetodoImprimir()
        Call BTNImprimir_Click(sender, e)
    End Sub

    Protected Sub MetodoImprimir()
        If GVInventario.Rows.Count > 0 Then
            LSucursalDestino.Visible = False
            LAlmacenDestino.Visible = False
            MultiView1.SetActiveView(View4)
            TablaInventarioDetalle = Session("TablaInventarioDetalle")
            fecha = Session("fecha")
            LIdMovimientoInventario.Text = TBIdMovimientoInventario.Text
            LBObservacion.Text = TBObservacion.Text            
            LAlmacenOrigen.Text = DDAlmacenOrigen.SelectedItem.Text            
            LAlmacenDestino.Text = DDAlmacenDestino.SelectedItem.Text
            LFecha.Text = fecha
            LTipo.Text = DDTipo.SelectedItem.Text
            LSubTipo.Text = DDSubTipo.SelectedItem.Text

            If DDSubTipo.SelectedValue = 6 Or DDSubTipo.SelectedValue = 2 Then
                LSucursalDestino.Visible = True
                LAlmacenDestino.Visible = True
                LSucursalDestinoP.Visible = True
                LAlmacenDestinoP.Visible = True
            Else
                LSucursalDestino.Visible = False
                LAlmacenDestino.Visible = False
                LSucursalDestinoP.Visible = False
                LAlmacenDestinoP.Visible = False
            End If

            Dim IdProveedor = 0
            Dim IdEquivalencia = ""
            Dim Nombre = ""

            GVImprimirMovimiento.Columns.Clear()
            GVImprimirMovimiento.DataSource = TablaInventarioDetalle
            GVImprimirMovimiento.AutoGenerateColumns = False
            GVImprimirMovimiento.AllowSorting = True
            GVImprimirMovimiento.Visible = True
            Comun.Presentacion.Cuadricula.AgregarColumna(GVImprimirMovimiento, New BoundField(), "Codigo", "IdProductoCorto")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVImprimirMovimiento, New BoundField(), "Producto", "Descripcion")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVImprimirMovimiento, New BoundField(), "Cantidad", "Cantidad")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVImprimirMovimiento, New BoundField(), "Estado", "Estado")
            GVImprimirMovimiento.DataBind()

            GVImprimirMovimiento.UseAccessibleHeader = True
            GVImprimirMovimiento.HeaderRow.TableSection = TableRowSection.TableHeader

        End If
    End Sub
    Protected Sub BTNImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles BTNImprimir.Click
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "scriptkey", "window.print();", True) ' Linea que se ejecuta junto con el UpdatePanel
    End Sub
    Protected Sub BTIRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BTIRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub    
    Protected Sub GVInventario_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVInventario.Sorting
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaInventarioDetalle"), DataTable)
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = CType((e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")), String)
        GVInventario.DataSource = Vista
        GVInventario.DataBind()
        MultiView1.SetActiveView(View1)
    End Sub

    Protected Sub BTNRegresar_Click(sender As Object, e As ImageClickEventArgs) Handles BTNRegresar.Click
        Limpiar()
        habilitar()
    End Sub

    Protected Sub BTNHoy_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim Tabla As New DataTable
        EntidadMovimientoInventario.IdSucursalOrigen = -1
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdEstado = -1
        EntidadMovimientoInventario.FechaInicio = Now
        EntidadMovimientoInventario.FechaFin = Now
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        Tabla = EntidadMovimientoInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = Tabla
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Sucursal", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Almacen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Movimiento", "FechaCreacion")
        GridView1.DataBind()
        Session("Tabla") = Tabla
        Inhabilitar()
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNSemana_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim Tabla As New DataTable
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While
        EntidadMovimientoInventario.IdSucursalOrigen = -1
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdEstado = -1
        EntidadMovimientoInventario.FechaInicio = CDate(fechainicio)
        EntidadMovimientoInventario.FechaFin = Now
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        Tabla = EntidadMovimientoInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = Tabla
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Sucursal", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Almacen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Movimiento", "FechaCreacion")
        GridView1.DataBind()
        Session("Tabla") = Tabla
        Inhabilitar()
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNMes_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim Tabla As New DataTable
        EntidadMovimientoInventario.IdSucursalOrigen = -1
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdEstado = -1
        EntidadMovimientoInventario.FechaInicio = CDate("02/" + Now.Date.ToString("MM/yyyy"))
        EntidadMovimientoInventario.FechaFin = Now
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        Tabla = EntidadMovimientoInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = Tabla
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Sucursal", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Almacen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Movimiento", "FechaCreacion")
        GridView1.DataBind()
        Session("Tabla") = Tabla
        Inhabilitar()
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNAno_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim Tabla As New DataTable
        EntidadMovimientoInventario.IdSucursalOrigen = -1
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdEstado = -1
        EntidadMovimientoInventario.FechaInicio = CDate("02/01/" + Now.Date.ToString("yyyy"))
        EntidadMovimientoInventario.FechaFin = Now
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        Tabla = EntidadMovimientoInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = Tabla
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Sucursal", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Almacen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Movimiento", "FechaCreacion")
        GridView1.DataBind()
        Session("Tabla") = Tabla
        Inhabilitar()
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs)
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
    Protected Sub BTNAvanzadoConsultar_Click(sender As Object, e As EventArgs)
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim Tabla As New DataTable
        EntidadMovimientoInventario.IdSucursalOrigen = -1
        EntidadMovimientoInventario.IdAlmacenOrigen = CInt(DDAlmacenOrigen.SelectedValue)
        EntidadMovimientoInventario.IdEstado = CInt(DDEstadoBusq.SelectedValue)
        EntidadMovimientoInventario.FechaInicio = CDate(TBFechaInicio.Text)
        EntidadMovimientoInventario.FechaFin = CDate(TBFechaFin.Text)
        EntidadMovimientoInventario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioMovimientoInventario.Consultar(EntidadMovimientoInventario)
        Tabla = EntidadMovimientoInventario.TablaConsulta
        GridView1.Columns.Clear()
        GridView1.DataSource = Tabla
        GridView1.AutoGenerateColumns = False
        GridView1.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GridView1.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Sucursal", "SucursalOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Almacen", "AlmacenOrigen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GridView1, New BoundField(), "Fecha Movimiento", "FechaCreacion")
        GridView1.DataBind()
        Session("Tabla") = Tabla
        Inhabilitar()
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNAvanzadoConsultar2_Click(sender As Object, e As EventArgs)
        LlenarSolicitudes()
    End Sub

    Protected Sub BTNHoy2_Click(sender As Object, e As EventArgs)
        If divAvanzado2.Visible = True Then
            divAvanzado2.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdAlmacenDestino = -1
        EntidadMovimientoInventario.Estatus = 1
        EntidadMovimientoInventario.FechaInicio = Now
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaPendientes = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaPendientes
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVSolicitud.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            Dim NuevoRow As DataRow = TablaPendientes.NewRow()
            CType(MiDataRow.FindControl("GVTBCantidad"), TextBox).Text = TablaPendientes.Rows(Index).Item("Recibi")
        Next
        Session("TablaPendientes") = TablaPendientes
        Session("VistaPendientes") = VistaPendientes
    End Sub

    Protected Sub BTNSemana2_Click(sender As Object, e As EventArgs)
        If divAvanzado2.Visible = True Then
            divAvanzado2.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim fechainicio As DateTime = Now
        While fechainicio.DayOfWeek <> DayOfWeek.Monday
            fechainicio = fechainicio.AddDays(-1)
        End While
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdAlmacenDestino = -1
        EntidadMovimientoInventario.Estatus = 1
        EntidadMovimientoInventario.FechaInicio = CDate(fechainicio)
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaPendientes = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaPendientes
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVSolicitud.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            Dim NuevoRow As DataRow = TablaPendientes.NewRow()
            CType(MiDataRow.FindControl("GVTBCantidad"), TextBox).Text = TablaPendientes.Rows(Index).Item("Recibi")
        Next
        Session("TablaPendientes") = TablaPendientes
        Session("VistaPendientes") = VistaPendientes
    End Sub

    Protected Sub BTNMes2_Click(sender As Object, e As EventArgs)
        If divAvanzado2.Visible = True Then
            divAvanzado2.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdAlmacenDestino = -1
        EntidadMovimientoInventario.Estatus = 1
        EntidadMovimientoInventario.FechaInicio = CDate("02/" + Now.Date.ToString("MM/yyyy"))
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaPendientes = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaPendientes
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVSolicitud.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            Dim NuevoRow As DataRow = TablaPendientes.NewRow()
            CType(MiDataRow.FindControl("GVTBCantidad"), TextBox).Text = TablaPendientes.Rows(Index).Item("Recibi")
        Next
        Session("TablaPendientes") = TablaPendientes
        Session("VistaPendientes") = VistaPendientes
    End Sub

    Protected Sub BTNAno2_Click(sender As Object, e As EventArgs)
        If divAvanzado2.Visible = True Then
            divAvanzado2.Visible = False
        End If
        Dim NegocioMovimientoInventario As New Negocio.MovimientoInventario()
        Dim EntidadMovimientoInventario As New Entidad.MovimientoInventario()
        Dim tablaAlmacenOrigen As DataTable = Session("tablaAlmacenOrigen")
        EntidadMovimientoInventario.IdAlmacenOrigen = -1
        EntidadMovimientoInventario.IdAlmacenDestino = -1
        EntidadMovimientoInventario.Estatus = 1
        EntidadMovimientoInventario.FechaInicio = CDate("02/01/" + Now.Date.ToString("yyyy"))
        EntidadMovimientoInventario.FechaFin = Now
        NegocioMovimientoInventario.ObtenerPendientes(EntidadMovimientoInventario)
        TablaPendientes = EntidadMovimientoInventario.TablaConsulta
        GVSolicitud.DataSource = TablaPendientes
        GVSolicitud.AutoGenerateColumns = False
        GVSolicitud.AllowSorting = True
        GVSolicitud.DataBind()
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVSolicitud.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            Dim NuevoRow As DataRow = TablaPendientes.NewRow()
            CType(MiDataRow.FindControl("GVTBCantidad"), TextBox).Text = TablaPendientes.Rows(Index).Item("Recibi")
        Next
        Session("TablaPendientes") = TablaPendientes
        Session("VistaPendientes") = VistaPendientes
    End Sub

    Protected Sub BTNAvanzado2_Click(sender As Object, e As EventArgs)
        If divAvanzado2.Visible = True Then
            divAvanzado2.Visible = False
        Else
            divAvanzado2.Visible = True
        End If
    End Sub
End Class