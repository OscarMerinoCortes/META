Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Drawing
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Imports System.Web.Services

Partial Class _Default
    Inherits Page
    Private TablaOrdenDetalle As New DataTable()
    Private VistaOrdenDetalle As New DataView()
    Private TablaSolicitudDetalle As New DataTable()
    Private VistaSolicitudDetalle As New DataView()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            IBTCancelar.Visible = False
            IBTImprimir.Visible = False
            Session("FechaActualizacion") = ""
            CType(Master.FindControl("LBOpcion"), Label).Text = "Autorizacion de orden de compra"
            'Hacer invisible la columna de autorizar
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
            wucDatosAuditoria1.Nuevo()
            wucDatosAuditoria1.Visible = False



            LlenarDDsFiltros()
            Try
                Dim Tabla = CType(Session("Tabla"), DataTable)
                Tabla.Rows.Clear()
                GVConsulta.DataBind()
                Session("Tabla") = Tabla
            Catch ex As Exception
            End Try
            MultiView1.SetActiveView(View2)
            divAvanzado.Visible = False
        Else
            TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)
            TablaSolicitudDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
            VistaSolicitudDetalle = CType(Session("VistaOrdenDetalle"), DataView)
        End If

    End Sub

    Private Sub LlenarSolicitudes()
        Dim NegocioSolicitudCompra As New Negocio.OrdenCompra()
        Dim EntidadSolicitudCompra As New Entidad.ReporteProcesoCompra()


        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)

        NegocioSolicitudCompra.ObtenerSolicitudCompraAutorizada(EntidadSolicitudCompra)
        TablaSolicitudDetalle = EntidadSolicitudCompra.TablaConsulta

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
        DDTipoOrdenEstado.SelectedIndex = 1

        ' --------------------------- ---- Estado ---- ---------------------------
        Dim NegocioTipoSolicitudEstado2 = New Negocio.TipoSolicitudEstado()
        Dim EntidadTipoSolicitudEstado2 As New Entidad.TipoSolicitudEstado()
        EntidadTipoSolicitudEstado2.Tarjeta.Consulta = Consulta.Ninguno
        NegocioTipoSolicitudEstado2.Consultar(EntidadTipoSolicitudEstado2)
        EntidadTipoSolicitudEstado2.TablaConsulta.Rows.Add(-1, "TODO")


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

        ' --------------------------- ---- Almacen ---- ---------------------------
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioAlmacen.Consultar(EntidadAlmacen)
        EntidadAlmacen.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", 1, "TODO")



        ' --------------------------- ---- Clasificacion ---- ---------------------------
        Dim NegocioClasificacion = New Negocio.Clasificacion()
        Dim EntidadClasificacion As New Entidad.Clasificacion()
        EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        NegocioClasificacion.Consultar(EntidadClasificacion)
        EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1)

    End Sub

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


            wucDatosAuditoria1.Nuevo()
            wucDatosAuditoria1.Visible = False

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
            Session("TablaSugerencia") = TablaSugerencia




        Catch ex As Exception
        End Try
        '----------------------------------------------------------
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim EntidadOrdenCompra As New Entidad.OrdenCompra()
        EntidadOrdenCompra.IdOrden = CInt(TBIdOrdenCompra.Text)
        'NegocioOrdenCompra.Guardar(EntidadOrdenCompra)

        Dim listo = True
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)
        TablaSolicitudDetalle = CType(Session("TablaSolicitudDetalle"), DataTable)
        For Each MiDataRow As DataRow In TablaOrdenDetalle.Rows
            If Not IsNumeric(CType(MiDataRow("Cantidad"), String)) Or MiDataRow("Cantidad") = "0" _
                Or Not IsNumeric(CType(MiDataRow("PrecioUnitario"), String)) Or MiDataRow("PrecioUnitario") = "0" Then
                listo = False
            End If
            If MiDataRow("IdTipoSolicitudEstado") <> 2 Then 'SI ES DIRENTE DE ORDENADO 
                listo = False
            End If
        Next
        For Each MiDataRow As DataRow In TablaOrdenDetalle.Rows
            MiDataRow("IdTipoSolicitudEstado") = 3 'AUTORIZADO
            MiDataRow("TipoSolicitudEstado") = "AUTORIZADO"
            MiDataRow("IdActualizar") = 1
        Next
        For Each MiDataRow As DataRow In TablaSolicitudDetalle.Rows
            MiDataRow("IdTipoSolicitudEstado") = 3
            MiDataRow("TipoSolicitudEstado") = "AUTORIZADO"
            MiDataRow("IdActualizar") = 1
        Next
        EntidadOrdenCompra.TablaOrdenDetalle = TablaOrdenDetalle
        EntidadOrdenCompra.TablaSolicitudDetalle = TablaSolicitudDetalle
        Dim IdProveedor = 0
        Dim IdEquivalencia = ""
        Dim Nombre = ""

        wucConProv.ObtenerPersona(IdProveedor, IdEquivalencia, Nombre)
        If IdProveedor = 0 Then 'SI EL PROVEEDOR ES 0
            Exit Sub
        End If
        If DDTipoOrdenEstado.SelectedValue <> 2 Then ' SI ES DIRERENTE DE ORDENADO
            Exit Sub
        End If
        If IdProveedor > 0 And listo Then

            EntidadOrdenCompra.IdOrden = 0
            If Not TBIdOrdenCompra.Text Is String.Empty Then
                EntidadOrdenCompra.IdOrden = CInt(TBIdOrdenCompra.Text)
            End If
            EntidadOrdenCompra.IdEstado = 1
            EntidadOrdenCompra.IdTipoSolicitudEstado = 3 'autorizado
            EntidadOrdenCompra.IdTipoPrioridad = CType(DDTipoPrioridad.SelectedValue, Integer)
            EntidadOrdenCompra.IdCliente = IdProveedor
            EntidadOrdenCompra.Observacion = TBObservacion.Text

            NegocioOrdenCompra.Guardar(EntidadOrdenCompra)   '<==========================================
            TBIdOrdenCompra.Text = CStr(EntidadOrdenCompra.IdOrden)
            Nuevo()
            LlenarDDsFiltros()
            GVConsulta.Columns.Clear()
            Try
                Dim Tabla = CType(Session("Tabla"), DataTable)
                Tabla.Rows.Clear()
                GVConsulta.DataBind()
                Session("Tabla") = Tabla
            Catch ex As Exception
            End Try

            MultiView1.SetActiveView(View2)
            ' MetodoImprimir()
            ' Call BTNImprimir_Click(sender, e)
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
        GVConsulta.Columns.Clear()
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
        Response.Redirect("~\Default.aspx")
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

        'Dim Index2 As Integer
        'For Each MiDataRow2 As GridViewRow In GVOrdenDetalle.Rows
        '    Index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
        '    Dim NuevoRow As DataRow = TablaOrdenDetalle.NewRow()
        '    CType(MiDataRow2.FindControl("TBGVCantidad"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("Cantidad")
        '    CType(MiDataRow2.FindControl("TBGVPrecioUnitario"), TextBox).Text = TablaOrdenDetalle.Rows(Index2).Item("PrecioUnitario")
        'Next
        MultiView1.SetActiveView(View1)
        IBTImprimir.Visible = True
    End Sub

#Region "Orden Detalle========================================================================="




    Private Sub LimpiarDetalle()
        ControlRegistro(False)
    End Sub

#End Region

    Private Sub OrdenarSolicitud()

    End Sub

    Protected Sub GVOrdenDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles GVOrdenDetalle.SelectedIndexChanged

    End Sub

    Protected Sub BTNOrdenarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub BTNOrdenar_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub BTNAutorizarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub BTNAutorizar_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub BTNEsperaTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub BTNEspera_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)

    End Sub

    Protected Sub BTNCancelarTodo_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub BTNCancelar_OnClick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub


    Protected Sub BTNSeleccionar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVOrdenDetalle.SelectedIndex = gvrFilaActual.RowIndex
        TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)

        ControlRegistro(True)
    End Sub


    Private Sub ControlRegistro(control As Boolean)
        If control Then
            GVOrdenDetalle.Visible = False
        Else
            GVOrdenDetalle.Visible = True
        End If
    End Sub
    Protected Sub BTNSolicitudDetalle_Click(sender As Object, e As EventArgs)
        LimpiarDetalle()
        ControlRegistro(True)
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
    'Protected Sub BTNPerfil_OnClick(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim TBResponsable As LinkButton = CType(sender, LinkButton)
    '    Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
    '    GVOrdenDetalle.SelectedIndex = gvrFilaActual.RowIndex
    '    TablaOrdenDetalle = CType(Session("TablaOrdenDetalle"), DataTable)

    '    wucConsultarProductoPerfil1.Abrir(CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("IdProducto"), Integer), "Perfil del Producto: " + CType(TablaOrdenDetalle.Rows(GVOrdenDetalle.SelectedIndex).Item("Producto"), String))

    'End Sub
    Protected Sub BTNPerfil2_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)

        VistaSolicitudDetalle = CType(Session("VistaSolicitudDetalle"), DataView)

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
        Session("TablaSugerencia") = Tabla
    End Sub


    Protected Sub BTNOrdenarSugerencia_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)

    End Sub


    Protected Sub BTNPerfil3_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)

        Dim TablaSugerencia = CType(Session("TablaSugerencia"), DataTable)

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
                If MIDATA("IdTipoSolicitudEstado") <> 3 Then 'si es autorizado va a poder cancelar
                    validar = False
                    Exit For
                End If
            Next
            If DDTipoOrdenEstado.SelectedValue <> 3 Then 'si es diferente de autorizado
                validar = False
            End If
            If validar = False Then ' validar que el detalle de la orden todavia este autorizado, si un producto fue comprado no se puede cancelar la orden 
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
    Protected Sub LlenarSolicitudConsulta(EntidadOrdenCompra As Entidad.ReporteProcesoCompra)
        Dim NegocioOrdenCompra As New Negocio.OrdenCompra()
        Dim Tabla As New DataTable
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
        DDTipoPrioridad.Enabled = False
        wucConProv.EnableViewState = False
        TBObservacion.Enabled = False
        DDDestino.Enabled = False
        DDTipoOrdenEstado.Enabled = False
    End Sub
    Protected Sub BTNConsultarAvanzado_Click(sender As Object, e As EventArgs) Handles BTNConsultarAvanzado.Click
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = CType(IIf(IsNumeric(TBOrdenFiltro.Text), TBOrdenFiltro.Text, -1), Integer)
        EntidadOrdenCompra.IdClasificacion = CType(DDProveedorFiltro.SelectedValue, Integer) 'Para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = CType(DDPrioridadFiltro.SelectedValue, Integer)
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = CType(DDEstadoFiltro.SelectedValue, Integer)
        EntidadOrdenCompra.FechaInicio = Comprobacion.ValidaFechaInicio(TBFechaInicioFiltro.Text)
        EntidadOrdenCompra.FechaFin = Comprobacion.ValidaFechaFin(TBFechaFinFiltro.Text)
        TBFechaInicioFiltro.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudConsulta(EntidadOrdenCompra)
    End Sub
    Protected Sub BTNBaja_Click(sender As Object, e As EventArgs) Handles BTNBaja.Click
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdClasificacion = -1 'Para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = 1 'Baja
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = 2 'Ordenado
        EntidadOrdenCompra.FechaInicio = CDate("01/01/1900")
        EntidadOrdenCompra.FechaFin = CDate(Now())
        TBFechaInicioFiltro.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudConsulta(EntidadOrdenCompra)
    End Sub
    Protected Sub BTNMedia_Click(sender As Object, e As EventArgs) Handles BTNMedia.Click
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdClasificacion = -1 'Para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = 2 'Media
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = 2 'Ordenado
        EntidadOrdenCompra.FechaInicio = CDate("01/01/1900")
        EntidadOrdenCompra.FechaFin = CDate(Now())
        TBFechaInicioFiltro.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudConsulta(EntidadOrdenCompra)
    End Sub
    Protected Sub BTNAlta_Click(sender As Object, e As EventArgs) Handles BTNAlta.Click
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdClasificacion = -1 'Para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = 3 'Alta
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = 2 'Ordenado
        EntidadOrdenCompra.FechaInicio = CDate("01/01/1900")
        EntidadOrdenCompra.FechaFin = CDate(Now())
        TBFechaInicioFiltro.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudConsulta(EntidadOrdenCompra)
    End Sub
    Protected Sub BTNTodo_Click(sender As Object, e As EventArgs) Handles BTNTodo.Click
        divAvanzado.Visible = False
        Dim EntidadOrdenCompra As New Entidad.ReporteProcesoCompra()
        EntidadOrdenCompra.Tarjeta.Consulta = Consulta.ConsultaBasica
        EntidadOrdenCompra.IdProceso = -1
        EntidadOrdenCompra.IdClasificacion = -1 'Para usarse como IdPersona
        EntidadOrdenCompra.IdTipoPrioridad = -1 'TODO
        EntidadOrdenCompra.IdEstado = -1
        EntidadOrdenCompra.IdSolicitudEstado = 2 'Ordenado
        EntidadOrdenCompra.FechaInicio = CDate("01/01/1900")
        EntidadOrdenCompra.FechaFin = CDate(Now())
        TBFechaInicioFiltro.Text = EntidadOrdenCompra.FechaInicio.ToString("dd/MM/yyyy")
        TBFechaFinFiltro.Text = EntidadOrdenCompra.FechaFin.ToString("dd/MM/yyyy")
        LlenarSolicitudConsulta(EntidadOrdenCompra)
    End Sub
    Protected Sub BTNAvanzado_Click(sender As Object, e As EventArgs) Handles BTNAvanzado.Click
        If divAvanzado.Visible = True Then
            divAvanzado.Visible = False
        Else
            divAvanzado.Visible = True
        End If
    End Sub
End Class

