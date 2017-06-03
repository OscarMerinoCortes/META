Imports System.Data
Imports Comun.Presentacion
Imports System.Collections.ObjectModel
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
    Private TablaSolicitudDetalle As New DataTable()
    Private VistaSolicitudDetalle As New DataView()
    Private ListaEstado As New ObservableCollection(Of Entidad.TipoSolicitudEstado)
    Private ListaPrioridad As New ObservableCollection(Of Entidad.TipoPrioridad)
    Private ListaAlmacen As New ObservableCollection(Of Entidad.Almacen)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Solicitud de Compra"
            'AddHandler WucConsultarProducto.se, New EventHandler(AddressOf BusquedaVentaCancelado)
            LlenarDDs()
            LlenarDDsFiltros()
            ControlRegistro(True)

            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.HeaderText = "Seleccionar"
            Columna.SelectText = "Seleccionar"
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True

            '===================================================Detalle=========================================================
            TablaSolicitudDetalle.Columns.Clear()
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdSolicitudDetalle", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdSolicitud", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("Producto", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdTipoPrioridad", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("TipoPrioridad", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdTipoSolicitudEstado", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("TipoSolicitudEstado", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdSucursal", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdAlmacen", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("Almacen", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("CantidadAlterna", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdUnidadAlterna", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdUnidad", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("Unidad", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("CantidadInventario", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdUnidadInventario", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdActualizar", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdUsuarioCreacion", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("UsuarioCreacion", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("FechaCreacion", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("IdUsuarioActualizacion", Type.GetType("System.Int32")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("UsuarioActualizacion", Type.GetType("System.String")))
            TablaSolicitudDetalle.Columns.Add(New DataColumn("FechaActualizacion", Type.GetType("System.String")))

            VistaSolicitudDetalle = TablaSolicitudDetalle.DefaultView
            Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
            Session("VistaSolicitudDetalle") = VistaSolicitudDetalle

            '==========================================================================================
            Nuevo()
            GVSolicitudDetalle.SelectedIndex = -1
            MultiView1.SetActiveView(View1)
            'wucConsultarProducto1.MostrarColumnaCantidad()
        Else
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
            ListaEstado = CType(Session("ListaEstado"), ObservableCollection(Of Entidad.TipoSolicitudEstado))
            ListaPrioridad = CType(Session("ListaPrioridad"), ObservableCollection(Of Entidad.TipoPrioridad))
        End If
        AddHandler wucConsultarProducto1.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub

    Private Sub LlenarDDs()
        ' --------------------------- ---- Tipo Solicitud Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioTipoSolicitudEstado.Consultar(EntidadTipoSolicitudEstado)
        Dim TablaSlEs = EntidadTipoSolicitudEstado.TablaConsulta
        TablaSlEs.Select()
        ListaEstado.Clear()
        Dim _listaEstado As List(Of DataRow) = TablaSlEs.AsEnumerable().ToList()
        For Each rw As DataRow In _listaEstado
            Dim Fila As New Entidad.TipoSolicitudEstado
            Fila.IdTipoSolicitudEstado = rw.ItemArray(0)
            Fila.Descripcion = rw.ItemArray(1)
            Fila.IdEstado = rw.ItemArray(2)
            ListaEstado.Add(Fila)
        Next
        DDTipoSolicitudEstado.DataSource = ListaEstado
        DDTipoSolicitudEstado.DataValueField = "IdTipoSolicitudEstado"
        DDTipoSolicitudEstado.DataTextField = "Descripcion"
        DDTipoSolicitudEstado.DataBind()
        Session("ListaEstado") = ListaEstado


        ' --------------------------- ---- Tipo Prioridad ---- ---------------------------
        Dim NegocioTipoPrioridad = New Negocio.TipoPrioridad()
        Dim EntidadTipoPrioridad As New Entidad.TipoPrioridad()
        EntidadTipoPrioridad.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioTipoPrioridad.Consultar(EntidadTipoPrioridad)
        Dim TablaPr = EntidadTipoPrioridad.TablaConsulta
        TablaPr.Select()
        ListaPrioridad.Clear()
        Dim _listaPrioridad As List(Of DataRow) = TablaPr.AsEnumerable().ToList()
        For Each rw As DataRow In _listaPrioridad
            Dim Fila As New Entidad.TipoPrioridad
            Fila.IdTipoPrioridad = rw.ItemArray(0)
            Fila.Descripcion = rw.ItemArray(1)
            Fila.IdEstado = rw.ItemArray(2)
            ListaPrioridad.Add(Fila)
        Next
        DDTipoPrioridad.DataSource = ListaPrioridad
        DDTipoPrioridad.DataValueField = "IdTipoPrioridad"
        DDTipoPrioridad.DataTextField = "Descripcion"
        DDTipoPrioridad.DataBind()
        Session("ListaPrioridad") = ListaPrioridad

        ' --------------------------- ---- Almacen ---- ---------------------------
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)
        Dim TablaAl = EntidadAlmacen.TablaConsulta
        TablaAl.Select()
        ListaAlmacen.Clear()
        Dim _listaAlmacen As List(Of DataRow) = TablaAl.AsEnumerable().ToList()
        For Each rw As DataRow In _listaAlmacen
            Dim Fila As New Entidad.Almacen
            Fila.IdAlmacen = rw.ItemArray(0)
            Fila.Descripcion = rw.ItemArray(1)
            Fila.IdSucursal = rw.ItemArray(3)
            ListaAlmacen.Add(Fila)
        Next
        DDAlmacen.DataSource = ListaAlmacen
        DDAlmacen.DataValueField = "IdAlmacen"
        DDAlmacen.DataTextField = "Descripcion"
        DDAlmacen.DataBind()
        DDAlmacen.SelectedIndex = 0
        Session("ListaAlmacen") = ListaAlmacen


    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
    End Sub
    Public Sub Nuevo()
        TBIdSolicitudCompra.Text = ""
        DDTipoSolicitudEstado.SelectedIndex = 0
        DDTipoPrioridad.SelectedIndex = 0

        wucDatosAuditoria1.Nuevo()
        wucDatosAuditoria1.Visible = False
        TBObservacion.Text = ""
        'wucConsultarProducto1.Nuevo()
        TBCantidad.Text = ""
        DDAlmacen.SelectedIndex = 0

        '----------------Para limpiar los Gridview ----------------
        LimpiarTablas()
        ControlRegistro(True)
    End Sub
    Public Sub LimpiarTablas()
        'limpiar tablas y vistas del detalle
        '----------------------------------------------------------
        TablaSolicitudDetalle.Rows.Clear()
        VistaSolicitudDetalle.Table.Rows.Clear()
        GVSolicitudDetalle.DataBind()
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
        '----------------------------------------------------------

    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioSolicitudCompra As New Negocio.SolicitudCompra()
        Dim EntidadSolicitudCompra As New Entidad.SolicitudCompra()

        EntidadSolicitudCompra.IdSolicitudCompra = 0
        If Not TBIdSolicitudCompra.Text Is String.Empty Then
            EntidadSolicitudCompra.IdSolicitudCompra = CInt(TBIdSolicitudCompra.Text)
        End If
        EntidadSolicitudCompra.IdEstado = 1
        EntidadSolicitudCompra.IdTipoSolicitudEstado = DDTipoSolicitudEstado.SelectedValue
        EntidadSolicitudCompra.IdTipoPrioridad = DDTipoPrioridad.SelectedValue
        EntidadSolicitudCompra.TablaSolicitudDetalle = TablaSolicitudDetalle
        EntidadSolicitudCompra.Observacion = TBObservacion.Text

        NegocioSolicitudCompra.Guardar(EntidadSolicitudCompra)
        TBIdSolicitudCompra.Text = CStr(EntidadSolicitudCompra.IdSolicitudCompra)

    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        MultiView1.SetActiveView(View2)
    End Sub
    Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
        MultiView1.SetActiveView(View1)
    End Sub
    Protected Sub GVConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsulta.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim NegocioProducto As New Negocio.SolicitudCompra()
        Dim EntidadProducto As New Entidad.SolicitudCompra()
        Tabla = CType(Session("Tabla"), DataTable)


        DDTipoSolicitudEstado.SelectedValue = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdTipoSolicitudEstado"))
        DDTipoPrioridad.SelectedValue = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdTipoPrioridad"))
        TBIdSolicitudCompra.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdSolicitud"))
        TBObservacion.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Observacion"))
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVConsulta.SelectedIndex))
        wucDatosAuditoria1.Visible = True

        '======================================== Solicitud Detalle ===========================================
        Dim TablaSolicitudDetalle As New DataTable
        EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaPorId
        EntidadProducto.IdSolicitudCompra = CType(TBIdSolicitudCompra.Text, Integer)
        NegocioProducto.Obtener(EntidadProducto)

        TablaSolicitudDetalle = EntidadProducto.TablaSolicitudDetalle
        VistaSolicitudDetalle = TablaSolicitudDetalle.DefaultView
        ' VistaSolicitudDetalle.RowFilter = "IdEstado=1"
        DDAlmacen.SelectedValue = TablaSolicitudDetalle.Rows(0).Item("IdAlmacen")
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
        GVSolicitudDetalle.DataSource = VistaSolicitudDetalle
        GVSolicitudDetalle.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVSolicitudDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaSolicitudDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaSolicitudDetalle.Rows(Index).Item("Cantidad")
        Next
        'ControlRegistro(False)
        MultiView1.SetActiveView(View1)
    End Sub
#Region "Solicitud Detalle========================================================================="
    Protected Sub BTNAceptarIdSolicitud_Click(sender As Object, e As EventArgs) Handles BTNAceptarDetalle.Click
        wucConsultarProducto1.BusquedaProducto()
        wucConsultarProducto1.RegresarFoco()
        'AddHandler wucConsultarProducto1.Seleccionado, New EventHandler(AddressOf AgregarProductos)
    End Sub
    Private Sub LimpiarDetalle()
        'wucConsultarProducto1.Nuevo()
        TBCantidad.Text = ""
        'DDAlmacen.SelectedIndex = 0
        BTNAceptarDetalle.Text = "Aceptar"
        GVSolicitudDetalle.SelectedIndex = -1
        'ControlRegistro(False)
    End Sub

#End Region
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Private Sub ControlRegistro(control As Boolean)
        If control Then
            PARegistroDetalle.Visible = True
            GVSolicitudDetalle.Visible = True
        Else
            PARegistroDetalle.Visible = False
            GVSolicitudDetalle.Visible = True
        End If
    End Sub
    Protected Sub BTNSolicitudDetalle_Click(sender As Object, e As EventArgs)
        LimpiarDetalle()
        'ControlRegistro(True)
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

    End Sub

    Protected Sub BTNSeleccionarSolicitudDetalle_Click1(sender As Object, e As EventArgs)
        'Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        'Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        'GVSolicitudDetalle.SelectedIndex = gvrFilaActual.RowIndex

        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim Renglon As Integer = gvrFilaActual.RowIndex

        TablaSolicitudDetalle = Session("TablaSolicitudDetalle")
        VistaSolicitudDetalle = Session("VistaSolicitudDetalle")

        'actualizar renglon
        'Dim Renglon As Integer = GVSolicitudDetalle.SelectedIndex
        If Renglon > -1 Then
            'si es nuevo eliminar del datatable
            If VistaSolicitudDetalle(Renglon).Item("IdSolicitudDetalle") = 0 Then
                VistaSolicitudDetalle(Renglon).Delete()
            Else
                VistaSolicitudDetalle(Renglon).Item("IdActualizar") = 1 'Si   
                VistaSolicitudDetalle(Renglon).Item("IdEstado") = 2
                VistaSolicitudDetalle(Renglon).Item("Estado") = "INACTIVO"
            End If

            Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
            Session("VistaSolicitudDetalle") = VistaSolicitudDetalle


            GVSolicitudDetalle.DataSource = VistaSolicitudDetalle
            GVSolicitudDetalle.DataBind()
            Dim Index As Integer
            For Each MiDataRow2 As GridViewRow In GVSolicitudDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaSolicitudDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaSolicitudDetalle.Rows(Index).Item("Cantidad")
            Next

            'limpiar controles 
            LimpiarDetalle()
        End If
    End Sub

    Protected Sub BTNPerfil2_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVSolicitudDetalle.SelectedIndex = gvrFilaActual.RowIndex
        VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)

        wucConsultarProductoPerfil1.Abrir(CType(VistaSolicitudDetalle.Item(GVSolicitudDetalle.SelectedIndex).Item("IdProducto"), Integer),
                                          "Perfil del Producto: " + CType(VistaSolicitudDetalle.Item(GVSolicitudDetalle.SelectedIndex).Item("Producto"), String))

    End Sub
    Protected Sub TBIdSolicitudCompra_TextChanged(sender As Object, e As EventArgs) Handles TBIdSolicitudCompra.TextChanged

    End Sub

    Private Sub AgregarProductos()
        TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
        VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
        Dim productosSeleccionados As New ObservableCollection(Of Entidad.WucProductoSeleccion)
        productosSeleccionados = wucConsultarProducto1.ObtenerProductos()
        For Each producto In productosSeleccionados
            Dim bandera = Not TablaSolicitudDetalle.Rows.Cast(Of DataRow)().Any(Function(fila) fila.Item("IdProducto").ToString() = producto.IdProducto)
            If bandera Then
                Dim RenglonAInsertar As DataRow
                RenglonAInsertar = TablaSolicitudDetalle.NewRow()
                RenglonAInsertar("IdSolicitudDetalle") = 0
                RenglonAInsertar("IdSolicitud") = 0

                RenglonAInsertar("IdProducto") = producto.IdProducto
                RenglonAInsertar("IdProductoCorto") = producto.IdProductoCorto
                RenglonAInsertar("Producto") = producto.Producto
                RenglonAInsertar("IdTipoSolicitudEstado") = 1
                RenglonAInsertar("TipoSolicitudEstado") = "SOLICITADO"
                RenglonAInsertar("IdAlmacen") = DDAlmacen.SelectedValue

                RenglonAInsertar("Almacen") = DDAlmacen.SelectedItem.Text
                RenglonAInsertar("IdSucursal") = 1

                RenglonAInsertar("Cantidad") = TBCantidad.Text
                RenglonAInsertar("IdUnidad") = 1

                RenglonAInsertar("Descripcion") = ""

                RenglonAInsertar("CantidadAlterna") = 0
                RenglonAInsertar("IdUnidadAlterna") = 0
                RenglonAInsertar("CantidadInventario") = 0
                RenglonAInsertar("IdUnidadInventario") = 0

                RenglonAInsertar("IdEstado") = 1
                RenglonAInsertar("IdActualizar") = 1
                RenglonAInsertar("Estado") = "ACTIVO"
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = CDate(Now)
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = CDate(Now)

                TablaSolicitudDetalle.Rows.Add(RenglonAInsertar)

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
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
        Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
        GVSolicitudDetalle.DataSource = VistaSolicitudDetalle
        GVSolicitudDetalle.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVSolicitudDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaSolicitudDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaSolicitudDetalle.Rows(Index).Item("Cantidad")
        Next
        LimpiarDetalle()
    End Sub

    Protected Sub DDAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDAlmacen.SelectedIndexChanged
        If GVSolicitudDetalle.Rows.Count > 0 Then
            TablaSolicitudDetalle = Session("TablaSolicitudDetalle")
            VistaSolicitudDetalle = Session("VistaSolicitudDetalle")
            Dim index As Integer
            For Each MiDataRow As GridViewRow In GVSolicitudDetalle.Rows
                index = Convert.ToUInt64(MiDataRow.RowIndex)
                TablaSolicitudDetalle.Rows(index).Item("IdAlmacen") = DDAlmacen.SelectedValue
                TablaSolicitudDetalle.Rows(index).Item("Almacen") = DDAlmacen.SelectedItem.Text
                VistaSolicitudDetalle(index).Item("IdAlmacen") = DDAlmacen.SelectedValue
                VistaSolicitudDetalle(index).Item("Almacen") = DDAlmacen.SelectedItem.Text
                If TablaSolicitudDetalle.Rows(index).Item("IdSolicitudDetalle") <> 0 Then
                    TablaSolicitudDetalle.Rows(index).Item("IdActualizar") = 1
                    VistaSolicitudDetalle(index).Item("IdActualizar") = 1
                End If


            Next
            Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
            Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
            GVSolicitudDetalle.DataSource = VistaSolicitudDetalle
            GVSolicitudDetalle.DataBind()
            'Dim Index As Integer
            For Each MiDataRow2 As GridViewRow In GVSolicitudDetalle.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaSolicitudDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaSolicitudDetalle.Rows(index).Item("Cantidad")
            Next
        End If
    End Sub
    Protected Sub DDTipoPrioridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDTipoPrioridad.SelectedIndexChanged
        If GVSolicitudDetalle.Rows.Count > 0 Then
            TablaSolicitudDetalle = Session("TablaSolicitudDetalle")
            VistaSolicitudDetalle = Session("VistaSolicitudDetalle")
            Dim index As Integer
            For Each MiDataRow As GridViewRow In GVSolicitudDetalle.Rows
                index = Convert.ToUInt64(MiDataRow.RowIndex)
                TablaSolicitudDetalle.Rows(index).Item("IdTipoPrioridad") = DDTipoPrioridad.SelectedValue
                VistaSolicitudDetalle(index).Item("TipoPrioridad") = DDTipoPrioridad.SelectedItem.Text
                If TablaSolicitudDetalle.Rows(index).Item("IdSolicitudDetalle") <> 0 Then
                    TablaSolicitudDetalle.Rows(index).Item("IdActualizar") = 1
                    VistaSolicitudDetalle(index).Item("IdActualizar") = 1
                End If
            Next
            Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
            Session("VistaSolicitudDetalle") = VistaSolicitudDetalle
            GVSolicitudDetalle.DataSource = VistaSolicitudDetalle
            GVSolicitudDetalle.DataBind()
            For Each MiDataRow2 As GridViewRow In GVSolicitudDetalle.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaSolicitudDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaSolicitudDetalle.Rows(index).Item("Cantidad")
            Next
        End If
    End Sub
    Protected Sub GVICantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBCantidad1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBCantidad1.Text) Then
            If TBCantidad1.Text > 0 Then

            Else
                TBCantidad1.Text = 1
            End If
            actualizarrenglon(TablaSolicitudDetalle, index, TBCantidad1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVSolicitudDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaSolicitudDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVCantidad"), TextBox).Text = TablaSolicitudDetalle.Rows(index).Item("Cantidad")
        End If
        Session("TablaSolicitudDetalle") = TablaSolicitudDetalle
    End Sub
    Private Sub actualizarrenglon(ByRef TablaSolicitudDetalle As DataTable, ByVal index As Integer, ByVal Cantidad1 As Double)
        Dim cantidad As Double = TablaSolicitudDetalle.Rows(index).Item("Cantidad")
        If Cantidad1 > 0 Then
            VistaSolicitudDetalle(index).Item("Cantidad") = Cantidad1
            VistaSolicitudDetalle(index).Item("IdActualizar") = 1
            'TablaSolicitudDetalle.AcceptChanges()
        Else
            'TablaSolicitudDetalle.Rows(index).Item("Cantidad") = cantidad
            'TablaSolicitudDetalle.AcceptChanges()
        End If
    End Sub
    Protected Sub BTNConsultarSolicitud_Click(sender As Object, e As ImageClickEventArgs) Handles BTNConsultarSolicitud.Click
        Dim NegocioSolicitudCompra As New Negocio.SolicitudCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()
        Dim Tabla As New DataTable
        EntidadSolicitudCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadSolicitudCompra.IdProceso = CType(IIf(IsNumeric(TBSolicitudFiltro.Text), TBSolicitudFiltro.Text, -1), Integer)
        EntidadSolicitudCompra.IdTipoPrioridad = CType(DDPrioridadFiltro.SelectedValue, Integer)
        EntidadSolicitudCompra.IdEstado = -1
        EntidadSolicitudCompra.IdSolicitudEstado = CType(DDEstadoFiltro.SelectedValue, Integer)
        EntidadSolicitudCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicioFiltro.Text)
        EntidadSolicitudCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFinFiltro.Text)
        TBFechaInicioFiltro.Text = EntidadSolicitudCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadSolicitudCompra.FechaFin.ToString("dd/MM/yyyy")
        NegocioSolicitudCompra.ConsultarFiltro(EntidadSolicitudCompra)
        Tabla = EntidadSolicitudCompra.TablaConsulta
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
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "ID", "IdSolicitud")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Prioridad", "TipoPrioridad")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Estado", "TipoSolicitudEstado")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Usuario", "UsuarioActualizacion")
        Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Fecha", "FechaActualizacion")
        GVConsulta.DataBind()
        Session("Tabla") = Tabla
    End Sub
End Class