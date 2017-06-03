Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Drawing
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Imports System.Math

Partial Class _Default
    Inherits Page
    'TABLAS PRINSIPALES
    Public IdSucursal As Int32
    Public TipoMontoPorcentaje As Int32
    Public TablaProducto As New DataTable()
    Public VistaProducto As New DataView()

    Public TablaPromocionObsequioDetalle As New DataTable()
    Public VistaPromocionObsequioDetalle As New DataView()

    Public TablaRegistro As New DataTable()
    Public VistaTablaRegistro As New DataView()

    Public TablaProductoObsequio As New DataTable()
    Public VistaProductoObsequio As New DataView()

    Public TablaPromocionObsequioProducto As New DataTable()
    Public VistaPromocionObsequioProducto As New DataView()

    Public TablaRegistroObsequio As New DataTable()
    Public VistaTablaRegistroObsequio As New DataView()

    Public TablaObsequioDetalleCantidad As New DataTable()
    Public VistaObsequioDetalleCantidad As New DataView()

    Public TablaProductoObsequio1 As New DataTable()
    Public VistaTablaProductoObsequio1 As New DataView()

    Public TablaSucursal As New DataTable()
    Public VistaTablaSucursal As New DataView()


    'TABLAS DEL SISTEMA
    Public TablaActualizar As New DataTable()
    Public VistaTablaActualizar As New DataView()

    Public EstadoActualizar As New Integer

    Public TablaActualizarObsequio As New DataTable()
    Public VistaTablaActualizarObsequio As New DataView()
    Public EstadoActualizarObsequio As New Integer
    Public Redondeo As New Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            IdSucursal = 1
            Dim EstadoActualizar As Integer = 0
            Dim Redondeo As Integer = 1 '1 no aplico descuento 2 si aplico descuento  
            Session("EstadoActualizar") = EstadoActualizar
            Session("EstadoActualizarObsequio") = EstadoActualizarObsequio
            Session("Redondeo") = Redondeo
            BTNAgregar.Visible = False
            BTNQuitar.Visible = False
            BtnCalcular.Visible = False
            TBFechaInicio.Text = Now.Date
            TBFechaFin.Text = Now.Date
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            wucDatosAuditoria1.Visible = False
            MultiView1.SetActiveView(VConsulta)
            consultar()
            BTNQuitarObsequio.Visible = False
            BTNAgregarObsequio.Visible = False
            LMonto.Text = "Monto"
            'CBMonto.Checked = False
            BTNCalcular2.Enabled = False
            BTNRedondeo0.Enabled = False
            BTNRedondeo.Visible = False

            IBTCopiar.Visible = False
            IBTGuardar.Visible = False
            DDOpcion.Items.Add(New ListItem("PORCENTAJE", 0))
            DDOpcion.Items.Add(New ListItem("MONTO", 1))
            DDOpcion.Items.Add(New ListItem("PRECIO CERO", 2))
            'DDOpcion.Items.Add(New ListItem("PRECIO CERO", 3))
            DDOpcion.SelectedValue = 2
            If DDOpcion.SelectedValue = 2 Then
                TipoMontoPorcentaje = 1
                TBMonto.Text = 100
            Else
                TipoMontoPorcentaje = IIf(DDOpcion.SelectedValue = 0, 1, 0)
            End If
            Session("TipoMontoPorcentaje") = TipoMontoPorcentaje
            '--------------------------- ---- Clasificacion ---- ---------------------------
            Dim NegocioClasificacion = New Negocio.Clasificacion()
            Dim EntidadClasificacion As New Entidad.Clasificacion()
            EntidadClasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioClasificacion.Consultar(EntidadClasificacion)
            EntidadClasificacion.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
            DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
            DDClasificacion.DataValueField = "ID"
            DDClasificacion.DataTextField = "Descripcion"
            DDClasificacion.DataBind()
            DDClasificacion.SelectedValue = -1
            ConsultaSubclasificaciones()

            Dim NegocioClasificacionObsequio = New Negocio.Clasificacion()
            Dim EntidadClasificacionObsequio As New Entidad.Clasificacion()
            EntidadClasificacionObsequio.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioClasificacionObsequio.Consultar(EntidadClasificacionObsequio)
            EntidadClasificacionObsequio.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
            DDClasificacionObsequio.DataSource = EntidadClasificacionObsequio.TablaConsulta
            DDClasificacionObsequio.DataValueField = "ID"
            DDClasificacionObsequio.DataTextField = "Descripcion"
            DDClasificacionObsequio.DataBind()
            DDClasificacionObsequio.SelectedValue = -1
            ConsultaSubclasificacionesObsequio()

            'TABLA PARA LA CONSULTA PRODUCTO
            TablaProducto.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Existencia", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaProducto = TablaProducto.DefaultView
            Session("TablaProducto") = TablaProducto
            Session("VistaProducto") = VistaProducto

            'TABLA DEL PRODUCTO PRINCIPAL
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaPromocionObsequioDetalle = TablaPromocionObsequioDetalle.DefaultView
            Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
            Session("VistaPromocionObsequioDetalle") = VistaPromocionObsequioDetalle
            'TABLA REGISTRO PARA LA ACTUALIZACION DE PRODUCTOS INABILITADOS 
            TablaRegistro.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaTablaRegistro = TablaRegistro.DefaultView
            Session("TablaRegistro") = TablaRegistro
            Session("VistaTablaRegistro") = VistaTablaRegistro
            'TABLA PARA LA CONSULTA DE PRODUCTO O0BSEQUIO
            TablaProductoObsequio.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaProductoObsequio.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaProductoObsequio.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaProductoObsequio.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaProductoObsequio.Columns.Add(New DataColumn("Existencia", System.Type.GetType("System.String")))
            TablaProductoObsequio.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaProductoObsequio.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaProductoObsequio = TablaProductoObsequio.DefaultView
            Session("TablaProductoObsequio") = TablaProductoObsequio
            Session("VistaProductoObsequio") = VistaProductoObsequio
            'TABLA DEL PRODUCTO A OBSEQUIAR
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdPromocionObsequioProducto", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("PrecioBase", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaPromocionObsequioProducto.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
            VistaPromocionObsequioProducto = TablaPromocionObsequioProducto.DefaultView
            Session("TablaPromocionObsequioProducto") = TablaPromocionObsequioProducto
            Session("VistaPromocionObsequioProducto") = VistaPromocionObsequioProducto

            'TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdPromocionDetalle", System.Type.GetType("System.String")))
            'TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            'TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            'TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            'TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            'TablaPromocionObsequioDetalle.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            'VistaPromocionObsequioDetalle = TablaPromocionObsequioDetalle.DefaultView
            'Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
            'Session("VistaPromocionDetalleObsequio") = VistaPromocionObsequioDetalle

            'TABLA PARA ACTUALIZAR LOS REGISTROS A INABILITADOS 
            TablaRegistroObsequio.Columns.Add(New DataColumn("IdPromocionObsequioProducto", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("PrecioBase", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaRegistroObsequio.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
            VistaTablaRegistroObsequio = TablaRegistroObsequio.DefaultView
            Session("TablaRegistroObsequio") = TablaRegistroObsequio
            Session("VistaTablaRegistroObsequio") = VistaTablaRegistroObsequio

            TablaObsequioDetalleCantidad.Columns.Add(New DataColumn("IdPromocionObsequioDetalleCantidad", Type.GetType("System.String")))
            TablaObsequioDetalleCantidad.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", Type.GetType("System.String")))
            TablaObsequioDetalleCantidad.Columns.Add(New DataColumn("IdSucursal", Type.GetType("System.String")))
            TablaObsequioDetalleCantidad.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
            TablaObsequioDetalleCantidad.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.String")))
            VistaObsequioDetalleCantidad = TablaObsequioDetalleCantidad.DefaultView
            Session("TablaObsequioDetalleCantidad") = TablaObsequioDetalleCantidad
            Session("VistaObsequioDetalleCantidad") = VistaObsequioDetalleCantidad

            'TABLA PARA EL CALCULO '
            'TablaProductoObsequio1.Columns.Add(New DataColumn("IdPromocionProductoObsequio", System.Type.GetType("System.String")))
            'TablaProductoObsequio1.Columns.Add(New DataColumn("IdPromocionDetalleObsequio", System.Type.GetType("System.String")))
            'TablaProductoObsequio1.Columns.Add(New DataColumn("IdPromocionEncabezado", System.Type.GetType("System.String")))
            'TablaProductoObsequio1.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("IdProductoEncabezado", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("ProductoEncabezado", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("CantidadExistencia", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("PrecioEncabezado", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("IdProductoObsequio", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("ProductoObsequio", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("CantidadObsequio", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("PrecioObsequio", System.Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("IdPromocionObsequioProducto", Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", Type.GetType("System.String")))
            TablaProductoObsequio1.Columns.Add(New DataColumn("PrecioCalculado", System.Type.GetType("System.String")))
            VistaTablaProductoObsequio1 = TablaProductoObsequio1.DefaultView
            Session("TablaProductoObsequio1") = TablaProductoObsequio1
            Session("VistaTablaProductoObsequio1") = VistaTablaProductoObsequio1

            TablaSucursal.Columns.Add(New DataColumn("IdPromocionSucursal", System.Type.GetType("System.String")))
            TablaSucursal.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            TablaSucursal.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaSucursal.Columns.Add(New DataColumn("NombreSucursal", System.Type.GetType("System.String")))
            VistaTablaSucursal = TablaSucursal.DefaultView
            Session("TablaSucursal") = TablaSucursal
            Session("VistaTablaSucursal") = VistaTablaSucursal
            '----- TABLA GV DE SUCURSALES ---
            'GVSucursal.Columns.Clear()
            'GVSucursal.DataSource = TablaSucursal
            'GVSucursal.AutoGenerateColumns = False
            'GVSucursal.AllowSorting = True

            'Dim Columna1 As New CommandField()
            'Columna1.HeaderText = ""
            'Columna1.HeaderText = "Seleccionar"
            'Columna1.SelectText = "Seleccionar"
            'Columna1.ButtonType = ButtonType.Link
            'Columna1.ShowSelectButton = True
            'GVSucursal.Columns.Add(Columna1)

            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSucursal, New BoundField(), "Sucursal", "NombreSucursal")
            'GVSucursal.DataBind()
        Else
            IdSucursal = 1
            TablaProducto = Session("TablaProducto")
            TablaPromocionObsequioDetalle = Session("TablaPromocionObsequioDetalle")
            TablaRegistro = Session("TablaRegistro")
            TablaProductoObsequio = Session("TablaProductoObsequio")
            TablaPromocionObsequioProducto = Session("TablaPromocionObsequioProducto")
            TablaRegistroObsequio = Session("TablaRegistroObsequio")
            TablaObsequioDetalleCantidad = Session("TablaObsequioDetalleCantidad")
            EstadoActualizar = Session("EstadoActualizar")
            TablaProductoObsequio1 = Session("TablaProductoObsequio1")

            'variables 
            TipoMontoPorcentaje = Session("TipoMontoPorcentaje")
        End If
        '-------------------------------- tablas para el boton agregar -----------------------
    End Sub
#Region "lol"
    Private Sub ConsultaSubclasificaciones()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
        If DDClasificacion.SelectedValue = -1 Then
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        Else
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaPorId

        End If
        EntidadSubclasificacion.IdClasificacion = CType(DDClasificacion.SelectedValue, Integer)
        NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
        If EntidadSubclasificacion.TablaConsulta.Rows.Count = 0 Then
            DDSubclasificacion.Items.Clear()
            DDSubclasificacion.Items.Add(New ListItem("TODO", "-1"))
        Else
            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1)
            DDSubclasificacion.DataSource = EntidadSubclasificacion.TablaConsulta
            DDSubclasificacion.DataValueField = "ID"
            DDSubclasificacion.DataTextField = "Descripcion"
        End If
        DDSubclasificacion.DataBind()
        DDSubclasificacion.SelectedValue = -1
    End Sub
    Private Sub ConsultaSubclasificacionesObsequio()
        Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
        Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
        If DDClasificacionObsequio.SelectedValue = -1 Then
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaBasica
        Else
            EntidadSubclasificacion.Tarjeta.Consulta = Consulta.ConsultaPorId
        End If
        EntidadSubclasificacion.IdClasificacion = CType(DDClasificacionObsequio.SelectedValue, Integer)
        NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
        If EntidadSubclasificacion.TablaConsulta.Rows.Count = 0 Then
            DDSubclasificacionObsequio.Items.Clear()
            DDSubclasificacionObsequio.Items.Add(New ListItem("TODO", "-1"))
        Else
            EntidadSubclasificacion.TablaConsulta.Rows.Add(-1, "TODO", "ACTIVO", -1)
            DDSubclasificacionObsequio.DataSource = EntidadSubclasificacion.TablaConsulta
            DDSubclasificacionObsequio.DataValueField = "ID"
            DDSubclasificacionObsequio.DataTextField = "Descripcion"
        End If
        DDSubclasificacionObsequio.DataBind()
        DDSubclasificacionObsequio.SelectedValue = -1
    End Sub
    Public Sub limpiar()
        Dim EntidadObsequio = New Entidad.Obsequio()
        EntidadObsequio.EstadoActualizar = 0
        'Tablas que se tienen que limpiar   **************************************** 
        TablaProducto.Clear()
        Session("TablaProducto") = TablaProducto
        TablaPromocionObsequioDetalle.Clear()
        Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
        TablaProductoObsequio.Clear()
        Session("TablaProductoObsequio") = TablaProductoObsequio
        TablaObsequioDetalleCantidad.Clear()
        Session("TablaObsequioDetalleCantidad") = TablaObsequioDetalleCantidad
        TablaPromocionObsequioProducto.Clear()
        Session("TablaPromocionObsequioProducto") = TablaPromocionObsequioProducto
        TablaRegistro.Clear()
        Session("TablaRegistro") = TablaRegistro
        TablaRegistroObsequio.Clear()
        Session("TablaRegistroObsequio") = TablaRegistroObsequio
        TablaProductoObsequio1.Clear()
        Session("TablaProductoObsequio1") = TablaProductoObsequio1
        '************************************************************************* 
        Session("EstadoActualizar") = 0
        Session("EstadoActualizarObsequio") = 0
        MultiView1.SetActiveView(VRegistro)
        TBIdPromocion.Text = ""
        TBDescripcion.Text = ""
        TBFechaInicio.Text = ""
        TBFechaFin.Text = ""
        TBObservacion.Text = ""
        TBFechaInicio.Text = Now.Date
        TBFechaFin.Text = Now.Date
        GVProducto.DataSource = Nothing
        GVProductoDetalle.DataSource = Nothing
        GVProducto.Visible = False
        GVProductoDetalle.Visible = False
        GVProductoObsequiar.DataSource = Nothing
        GVProductoDetalleObsequio.DataSource = Nothing
        GVProductoObsequiar.Visible = False
        GVProductoDetalleObsequio.Visible = False
        GVProductoObsequio.DataSource = Nothing
        GVProductoObsequio.Visible = False
        'GVSucursal.DataSource = Nothing
        'GVSucursal.Visible = False
        BTNQuitar.Visible = False
        BTNQuitarObsequio.Visible = False
        BTNAgregar.Visible = False
        BTNAgregarObsequio.Visible = False
        BtnCalcular.Visible = False
        BTNRedondeo.Visible = False
        DDClasificacion.SelectedValue = -1
        ConsultaSubclasificaciones()
        DDClasificacionObsequio.SelectedValue = -1
        ConsultaSubclasificacionesObsequio()
        wucDatosAuditoria1.Visible = False

        EntidadObsequio.EstadoActualizar = 0
        DDEstado.SelectedValue = 1
        'CBMonto.Checked = False
        DDOpcion.SelectedValue = 2
        If DDOpcion.SelectedValue = 2 Then
            TipoMontoPorcentaje = 1
            TBMonto.Text = 100
        Else
            TipoMontoPorcentaje = IIf(DDOpcion.SelectedValue = 0, 1, 0)
        End If
        Session("TipoMontoPorcentaje") = TipoMontoPorcentaje
        BTNCalcular2.Enabled = False
        BTNRedondeo0.Enabled = False
        IBTCopiar.Visible = False
        IBTGuardar.Visible = True
        divGVProducto.Visible = False
        divGVProducto2.Visible = False
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        limpiar()
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        BTNQuitar.Visible = False
        BTNAgregar.Visible = False
        Dim NegocioObsequio As New Negocio.Obsequio()
        Dim EntidadObsequio As New Entidad.Obsequio()
        'TablaProductoObsequio1 = Session("TablaProductoObsequio1")
        'TablaRegistro = Session("TablaRegistro")
        'TablaRegistroObsequio = Session("TablaRegistroObsequio")
        'EstadoActualizar = Session("EstadoActualizar")
        'TablaSucursal = Session("TablaSucursal")
        Dim Redondeo As Integer
        Redondeo = Session("Redondeo")

        If TablaPromocionObsequioDetalle.Rows.Count = 0 Then
            Exit Sub
        End If
        If TablaPromocionObsequioProducto.Rows.Count = 0 Then
            Exit Sub
        End If
        Calcular()
        EntidadObsequio.AplicarRedondeo = Redondeo

        If TBIdPromocion.Text Is String.Empty Then
            EntidadObsequio.IdPromocion = 0
        Else
            EntidadObsequio.IdPromocion = CInt(TBIdPromocion.Text)
        End If
        If TBFechaInicio.Text Is String.Empty Then
            EntidadObsequio.FechaInicio = "01/01/1990"
        Else
            EntidadObsequio.FechaInicio = TBFechaInicio.Text
        End If
        If TBFechaFin.Text Is String.Empty Then
            EntidadObsequio.FechaFin = "01/01/1990"
        Else
            EntidadObsequio.FechaFin = TBFechaFin.Text
        End If
        If TBDescripcion.Text = String.Empty Then
            EntidadObsequio.Descripcion = "NINGUNO"
        Else
            EntidadObsequio.Descripcion = TBDescripcion.Text
        End If
        If TBObservacion.Text = String.Empty Then
            EntidadObsequio.Observacion = "NINGUNO"
        Else
            EntidadObsequio.Observacion = TBObservacion.Text
        End If
        If TBMonto.Text = String.Empty Then
            EntidadObsequio.MontoPorcentaje = 0
        Else
            EntidadObsequio.MontoPorcentaje = CDbl(TBMonto.Text)
        End If

        EntidadObsequio.IdEstado = CInt(DDEstado.SelectedValue)

        EntidadObsequio.TipoMontoPorcentaje = TipoMontoPorcentaje    '0 es para monto y 1 para porcentaje 2 para segundo producto 
        EntidadObsequio.IndicadorEstado = EstadoActualizar
        If EstadoActualizar = 1 Then
            EntidadObsequio.TablaPromocionObsequioDetalle = TablaPromocionObsequioDetalle
            EntidadObsequio.TablaPromocionObsequioProducto = TablaPromocionObsequioProducto
            EntidadObsequio.TablaObsequioDetalleCantidad = TablaObsequioDetalleCantidad
            EntidadObsequio.TablaRegistro = TablaRegistro
            EntidadObsequio.TablaRegistroObsequio = TablaRegistroObsequio
            EntidadObsequio.TablaProductoObsequio1 = TablaProductoObsequio1
            NegocioObsequio.Guardar(EntidadObsequio)
        Else
            EntidadObsequio.TablaPromocionObsequioDetalle = TablaPromocionObsequioDetalle
            EntidadObsequio.TablaPromocionObsequioProducto = TablaPromocionObsequioProducto
            EntidadObsequio.TablaObsequioDetalleCantidad = TablaObsequioDetalleCantidad
            NegocioObsequio.Guardar(EntidadObsequio)
        End If


        'EntidadObsequio.TablaPromocionDetalle = TablaPromocionDetalle
        'EntidadObsequio.TablaPromocionDetalleObsequio = TablaPromocionDetalleObsequio
        'EntidadObsequio.TablaProductoObsequio1 = TablaProductoObsequio1
        'EntidadObsequio.TablaSucursal = TablaSucursal

        TBIdPromocion.Text = EntidadObsequio.IdPromocion.ToString()
    End Sub
    Public Sub consultar()
        MultiView1.SetActiveView(VConsulta)
        Dim NegocioObsequio As New Negocio.Obsequio()
        Dim EntidadObsequio As New Entidad.Obsequio()
        Dim TablaTemporal As New DataTable
        Dim Tabla As New DataTable
        EntidadObsequio.Tarjeta.Consulta = Consulta.ConsultaDetallada
        NegocioObsequio.Consultar(EntidadObsequio)
        Tabla = EntidadObsequio.TablaConsulta
        GVDescuento.Columns.Clear()
        GVDescuento.DataSource = Tabla
        GVDescuento.AutoGenerateColumns = False
        GVDescuento.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVDescuento.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Id Promocion", "IdPromocionObsequio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Fecha Inicio", "FechaInicio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Fecha Fin", "FechaFin")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Estado", "Estado")
        GVDescuento.DataBind()
        Session("Tabla") = Tabla
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        limpiar()
        consultar()
        IBTCopiar.Visible = False
        IBTGuardar.Visible = False
    End Sub

    Protected Sub CBGVPromocionHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If CType(GVProducto.HeaderRow.FindControl("CBGVPromocionHeader"), CheckBox).Checked Then
            For Each MiDataRow As GridViewRow In GVProducto.Rows
                CType(MiDataRow.FindControl("CBGVPromocionItem"), CheckBox).Checked = True
            Next
        Else
            For Each MiDataRow As GridViewRow In GVProducto.Rows
                CType(MiDataRow.FindControl("CBGVPromocionItem"), CheckBox).Checked = False
            Next
        End If

    End Sub
    Protected Sub CBGVPromocionObsequioHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(GVProductoObsequiar.HeaderRow.FindControl("CBGVPromocionObsequioHeader"), CheckBox).Checked Then
            For Each MiDataRow As GridViewRow In GVProductoObsequiar.Rows
                CType(MiDataRow.FindControl("CBGVPromocionObsequioItem"), CheckBox).Checked = True
            Next
        Else
            For Each MiDataRow As GridViewRow In GVProductoObsequiar.Rows
                CType(MiDataRow.FindControl("CBGVPromocionObsequioItem"), CheckBox).Checked = False
            Next
        End If

    End Sub
    Protected Sub CBGVPromocionDetalleHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(GVProductoDetalle.HeaderRow.FindControl("CBGVPromocionDetalleHeader"), CheckBox).Checked Then
            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                CType(MiDataRow.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True
            Next
        Else
            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                CType(MiDataRow.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub CBGVPromocionDetalleObsequioHeader_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(GVProductoDetalleObsequio.HeaderRow.FindControl("CBGVPromocionDetalleObsequioHeader"), CheckBox).Checked Then
            For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
                CType(MiDataRow.FindControl("CBGVPromocionDetalleObsequioItem"), CheckBox).Checked = True
            Next
        Else
            For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
                CType(MiDataRow.FindControl("CBGVPromocionDetalleObsequioItem"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub CBGVPromocionItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub


    Protected Sub DDClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacion.SelectedIndexChanged
        ConsultaSubclasificaciones()
    End Sub

    Protected Sub BTNConsultarProducto_Click(sender As Object, e As EventArgs) Handles BTNConsultarProducto.Click
        GVProducto.DataSource = Nothing
        GVProductoDetalle.DataSource = Nothing
        Dim NegocioObsequio As New Negocio.Obsequio()
        Dim EntidadObsequio As New Entidad.Obsequio()
        Dim TablaProductos As New DataTable()
        EntidadObsequio.IdClasificacion = DDClasificacion.SelectedValue
        EntidadObsequio.IdSubClasificacion = DDSubclasificacion.SelectedValue
        EntidadObsequio.Sucursal = IdSucursal
        EntidadObsequio.Tarjeta.Consulta = Consulta.Ninguno
        NegocioObsequio.Consultar(EntidadObsequio)
        TablaProductos = EntidadObsequio.TablaConsulta
        GVProducto.DataSource = TablaProductos
        GVProducto.AutoGenerateColumns = False
        GVProducto.AllowSorting = True
        GVProducto.DataBind()
        If GVProducto.Rows.Count > 0 Then
            BTNAgregar.Visible = True
            GVProducto.Visible = True
            Session("TablaProducto") = TablaProductos
        Else
            BTNAgregar.Visible = False
            GVProducto.Visible = False
        End If
        If GVProductoDetalle.Rows.Count > 0 Then

        End If
        divGVProducto.Visible = True
    End Sub
#End Region
    Protected Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
        'TablaProducto = Session("TablaProducto")
        ''TablaPromocionDetalle = Session("TablaPromocionDetalle")
        'TablaActualizar = Session("TablaActualizar")
        BTNQuitar.Visible = True

        Dim RenglonAInsertar As DataRow
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVProducto.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            If CType(MiDataRow.FindControl("CBGVPromocionItem"), CheckBox).Checked = True Then
                'Validar que el producto serleccionado ya no este en la lista de TablaPromocionObsequioDetalle
                Dim validar = 0
                For Each RowValidar As DataRow In TablaPromocionObsequioDetalle.Rows
                    If RowValidar.Item("IdProducto") = TablaProducto.Rows(Index).Item("IdProducto") Then
                        validar = 1
                    End If
                Next
                If validar = 0 Then
                    RenglonAInsertar = TablaPromocionObsequioDetalle.NewRow()
                    RenglonAInsertar("IdPromocionObsequioDetalle") = 0
                    RenglonAInsertar("IdPromocionObsequio") = 0
                    RenglonAInsertar("IdProducto") = TablaProducto.Rows(Index).Item("IdProducto")
                    RenglonAInsertar("IdProductoCorto") = TablaProducto.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertar("Descripcion") = TablaProducto.Rows(Index).Item("Descripcion")
                    RenglonAInsertar("PrecioBase") = TablaProducto.Rows(Index).Item("PrecioBase")
                    RenglonAInsertar("Cantidad") = TablaProducto.Rows(Index).Item("Existencia")
                    RenglonAInsertar("IdSucursal") = IdSucursal
                    RenglonAInsertar("IdEstado") = TablaProducto.Rows(Index).Item("IdEstado")
                    RenglonAInsertar("Estado") = TablaProducto.Rows(Index).Item("Estado")
                    TablaPromocionObsequioDetalle.Rows.Add(RenglonAInsertar)
                End If
            End If
        Next
        For Each MiDataRow As GridViewRow In GVProducto.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            If CType(MiDataRow.FindControl("CBGVPromocionItem"), CheckBox).Checked = True Then
                RenglonAInsertar = TablaObsequioDetalleCantidad.NewRow()
                RenglonAInsertar("IdPromocionObsequioDetalleCantidad") = 0
                RenglonAInsertar("IdPromocionObsequioDetalle") = 0
                RenglonAInsertar("IdSucursal") = IdSucursal
                RenglonAInsertar("Cantidad") = TablaProducto.Rows(Index).Item("Existencia")
                RenglonAInsertar("IdEstado") = TablaProducto.Rows(Index).Item("IdEstado")
                TablaObsequioDetalleCantidad.Rows.Add(RenglonAInsertar)
            End If
        Next

        'GVProductoDetalle.Columns.Clear()
        'GVProductoDetalle.DataSource = TablaPromocionObsequioDetalle
        'GVProductoDetalle.AutoGenerateColumns = False
        'GVProductoDetalle.AllowSorting = True
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoDetalle, New BoundField(), "IdPromocionObsequioDetalle", "IdPromocionObsequioDetalle")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoDetalle, New BoundField(), "IdProducto", "IdProducto")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoDetalle, New BoundField(), "Producto", "Descripcion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoDetalle, New BoundField(), "PrecioBase", "PrecioBase")
        ''Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoDetalle, New BoundField(), "TBGVCantidadExistencia", "Cantidad")
        'GVProductoDetalle.DataBind()
        'GVProductoDetalle.Visible = True
        If TablaPromocionObsequioDetalle.Rows.Count > 0 Then
            GVProductoDetalle.DataSource = TablaPromocionObsequioDetalle
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVProductoDetalle.AutoGenerateColumns = False
            GVProductoDetalle.AllowSorting = True
            GVProductoDetalle.DataBind()
            GVProductoDetalle.Visible = True
            'Session("TablaProducto") = TablaProducto
            For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaPromocionObsequioDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidadExistencia"), TextBox).Text = TablaPromocionObsequioDetalle.Rows(Index).Item("Cantidad")
            Next
        End If

        Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
        Session("TablaObsequioDetalleCantidad") = TablaObsequioDetalleCantidad
        BTNQuitar.Visible = True
    End Sub
    Protected Sub BTNQuitar_Click(sender As Object, e As EventArgs) Handles BTNQuitar.Click
        Dim EstadoActualizar As Integer
        EstadoActualizar = Session("EstadoActualizar")
        BTNAgregar.Visible = True

        If EstadoActualizar = 0 Then
            Dim TablaActualizacionPOD As New DataTable()
            TablaActualizacionPOD.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaActualizacionPOD.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))

            Dim TablaActualizacionODC As New DataTable()
            TablaActualizacionODC.Columns.Add(New DataColumn("IdPromocionObsequioDetalleCantidad", System.Type.GetType("System.String")))
            TablaActualizacionODC.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            TablaActualizacionODC.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaActualizacionODC.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaActualizacionODC.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))

            Dim RenglonAInsertarActualizar As DataRow
            Dim Index As Integer
            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True Then

                Else
                    RenglonAInsertarActualizar = TablaActualizacionPOD.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionObsequioDetalle") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequioDetalle")
                    RenglonAInsertarActualizar("IdPromocionObsequio") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequio")
                    RenglonAInsertarActualizar("IdProducto") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdProducto")
                    RenglonAInsertarActualizar("IdProductoCorto") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertarActualizar("Descripcion") = TablaPromocionObsequioDetalle.Rows(Index).Item("Descripcion")
                    RenglonAInsertarActualizar("PrecioBase") = TablaPromocionObsequioDetalle.Rows(Index).Item("PrecioBase")
                    RenglonAInsertarActualizar("Cantidad") = TablaPromocionObsequioDetalle.Rows(Index).Item("Cantidad")
                    RenglonAInsertarActualizar("IdSucursal") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdSucursal")
                    RenglonAInsertarActualizar("IdEstado") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdEstado")
                    RenglonAInsertarActualizar("Estado") = TablaPromocionObsequioDetalle.Rows(Index).Item("Estado")
                    TablaActualizacionPOD.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next
            For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                If CType(MiDataRow2.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True Then
                Else
                    RenglonAInsertarActualizar = TablaActualizacionODC.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionObsequioDetalleCantidad") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdPromocionObsequioDetalleCantidad")
                    RenglonAInsertarActualizar("IdPromocionObsequioDetalle") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdPromocionObsequioDetalle")
                    RenglonAInsertarActualizar("IdSucursal") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdSucursal")
                    RenglonAInsertarActualizar("Cantidad") = TablaObsequioDetalleCantidad.Rows(Index).Item("Cantidad")
                    RenglonAInsertarActualizar("IdEstado") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdEstado")
                    TablaActualizacionODC.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next

            If TablaPromocionObsequioDetalle.Rows.Count > 0 Then
                GVProductoDetalle.DataSource = TablaActualizacionPOD
                Dim Columna As New CommandField()
                Columna.HeaderText = ""
                Columna.ButtonType = ButtonType.Link
                Columna.ShowSelectButton = True
                GVProductoDetalle.AutoGenerateColumns = False
                GVProductoDetalle.AllowSorting = True
                GVProductoDetalle.DataBind()
                GVProductoDetalle.Visible = True
                'Session("TablaProducto") = TablaProducto
                For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
                    Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                    Dim NuevoRow As DataRow = TablaActualizacionPOD.NewRow()
                    CType(MiDataRow2.FindControl("TBGVCantidadExistencia"), TextBox).Text = TablaActualizacionPOD.Rows(Index).Item("Cantidad")
                Next
            End If
            TablaPromocionObsequioDetalle = TablaActualizacionPOD
            TablaObsequioDetalleCantidad = TablaActualizacionODC
            Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
            Session("TablaObsequioDetalleCantidad") = TablaObsequioDetalleCantidad
        Else ' Aqui para la actualizacion                                                                  ##########################################################################################################################################

            'TablaPromocionDetalle = Session("TablaPromocionDetalle") 'tiene todos producto detalle
            TablaRegistro = Session("TablaRegistro")
            Dim TablaActualizacion As New DataTable()
            TablaActualizacion.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))

            Dim RenglonAInsertarActualizar As DataRow
            Dim RenglonAInsertarActualizar2 As DataRow
            Dim Index As Integer
            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True Then
                    RenglonAInsertarActualizar2 = TablaRegistro.NewRow()
                    If TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequioDetalle") = 0 Then
                    Else
                        RenglonAInsertarActualizar2("IdPromocionObsequioDetalle") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequioDetalle")
                        RenglonAInsertarActualizar2("IdPromocionObsequio") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequio")
                        RenglonAInsertarActualizar2("IdProducto") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdProducto")
                        RenglonAInsertarActualizar2("IdProductoCorto") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdProductoCorto")
                        RenglonAInsertarActualizar2("Descripcion") = TablaPromocionObsequioDetalle.Rows(Index).Item("Descripcion")
                        RenglonAInsertarActualizar2("PrecioBase") = TablaPromocionObsequioDetalle.Rows(Index).Item("PrecioBase")
                        RenglonAInsertarActualizar2("Cantidad") = TablaPromocionObsequioDetalle.Rows(Index).Item("Cantidad")
                        RenglonAInsertarActualizar2("IdSucursal") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdSucursal")
                        RenglonAInsertarActualizar2("IdEstado") = 2
                        RenglonAInsertarActualizar2("Estado") = "INACTIVO"
                        TablaRegistro.Rows.Add(RenglonAInsertarActualizar2)
                    End If
                Else
                    RenglonAInsertarActualizar = TablaActualizacion.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionObsequioDetalle") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequioDetalle")
                    RenglonAInsertarActualizar("IdPromocionObsequio") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequio")
                    RenglonAInsertarActualizar("IdProducto") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdProducto")
                    RenglonAInsertarActualizar("IdProductoCorto") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertarActualizar("Descripcion") = TablaPromocionObsequioDetalle.Rows(Index).Item("Descripcion")
                    RenglonAInsertarActualizar("PrecioBase") = TablaPromocionObsequioDetalle.Rows(Index).Item("PrecioBase")
                    RenglonAInsertarActualizar("Cantidad") = TablaPromocionObsequioDetalle.Rows(Index).Item("Cantidad")
                    RenglonAInsertarActualizar("IdSucursal") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdSucursal")
                    RenglonAInsertarActualizar("IdEstado") = TablaPromocionObsequioDetalle.Rows(Index).Item("IdEstado")
                    RenglonAInsertarActualizar("Estado") = TablaPromocionObsequioDetalle.Rows(Index).Item("Estado")
                    TablaActualizacion.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next

            'For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
            '    Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            '    If CType(MiDataRow2.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True Then
            '    Else
            '        RenglonAInsertarActualizar = TablaActualizacionODC.NewRow() 'datos que no se selccionaron
            '        RenglonAInsertarActualizar("IdPromocionObsequioDetalleCantidad") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdPromocionObsequioDetalleCantidad")
            '        RenglonAInsertarActualizar("IdPromocionObsequioDetalle") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdPromocionObsequioDetalle")
            '        RenglonAInsertarActualizar("IdSucursal") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdSucursal")
            '        RenglonAInsertarActualizar("Cantidad") = TablaObsequioDetalleCantidad.Rows(Index).Item("Cantidad")
            '        RenglonAInsertarActualizar("IdEstado") = TablaObsequioDetalleCantidad.Rows(Index).Item("IdEstado")
            '        TablaActualizacionODC.Rows.Add(RenglonAInsertarActualizar)
            '    End If
            'Next

            GVProductoDetalle.DataSource = Nothing
            GVProductoDetalle.DataSource = TablaActualizacion
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVProductoDetalle.AutoGenerateColumns = False
            GVProductoDetalle.AllowSorting = True
            GVProductoDetalle.DataBind()
            GVProductoDetalle.Visible = True
            For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaActualizacion.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidadExistencia"), TextBox).Text = TablaActualizacion.Rows(Index).Item("Cantidad")
            Next
            'TablaPromocionDetalle = TablaActualizacion
            'Session("TablaProducto") = TablaProducto

            'TablaRegistro = TablaActualizacion2
            Session("TablaPromocionObsequioDetalle") = TablaActualizacion
            Session("TablaRegistro") = TablaRegistro
        End If
    End Sub

    Protected Sub GVDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVDescuento.SelectedIndexChanged
        BTNQuitar.Visible = True
        BTNQuitarObsequio.Visible = True
        BtnCalcular.Visible = True
        IBTCopiar.Visible = True
        'BTNCalcular2.Visible = True
        BTNRedondeo.Visible = True
        Dim NegocioObsequio As New Negocio.Obsequio()
        Dim EntidadObsequio As New Entidad.Obsequio()
        Dim EstadoActualizar As Integer = 1
        Session("EstadoActualizar") = EstadoActualizar
        Dim Tabla As New DataTable
        'TablaPromocionDetalle = Session("TablaPromocionDetalle")
        'TablaPromocionDetalleObsequio = Session("TablaPromocionDetalleObsequio")
        TablaProductoObsequio1 = Session("TablaProductoObsequio1")
        TablaSucursal = Session("TablaSucursal")
        VistaTablaSucursal = Session("VistaTablaSucursal")
        Tabla = Session("Tabla")
        TBIdPromocion.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("IdPromocionObsequio")
        TBDescripcion.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Descripcion")
        TBObservacion.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Observacion")
        TBFechaInicio.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("FechaInicio")
        TBFechaFin.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("FechaFin")
        TBMonto.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("MontoPorcentaje")

        If TBMonto.Text = 100 And Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoMontoPorcentaje") = 1 Then
            DDOpcion.SelectedValue = 2
        Else
            DDOpcion.SelectedValue = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoMontoPorcentaje") = 1, 0, 1)
        End If


        'CBMonto.Checked = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoMontoPorcentaje") = 1, False, True)
        'LMonto.Text = IIf(CBMonto.Checked = True, "Porsentaje", "Monto")
        DDEstado.SelectedValue = Tabla.Rows(GVDescuento.SelectedIndex).Item("IdEstado")
        

        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVDescuento.SelectedIndex))
        MultiView1.SetActiveView(VRegistro)

        EntidadObsequio.IdPromocion = Tabla.Rows(GVDescuento.SelectedIndex).Item("IdPromocionObsequio")
        EntidadObsequio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        'EntidadObsequio.IndicadorConsulta = 3
        'NegocioObsequio.Consultar(EntidadObsequio)
        'Tabla = EntidadObsequio.TablaConsulta
        ''GVSucursal.DataSource = Tabla
        'Dim Columna22 As New CommandField()
        'Columna22.HeaderText = ""
        'Columna22.ButtonType = ButtonType.Link
        'Columna22.ShowSelectButton = True
        ''GVSucursal.AutoGenerateColumns = False
        ''GVSucursal.AllowSorting = True
        ''GVSucursal.DataBind()
        ''GVSucursal.Visible = True
        'TablaSucursal = Tabla
        'Session("TablaSucursal") = TablaSucursal
        'VistaTablaSucursal = Tabla.DefaultView
        'Session("VistaTablaSucursal") = VistaTablaSucursal
        EntidadObsequio.IndicadorConsulta = 0
        EntidadObsequio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioObsequio.Consultar(EntidadObsequio)

        Tabla = EntidadObsequio.TablaConsulta
        'GVDescuento.Columns.Clear()
        ''############################################################################################################################################################################################################
        GVProductoDetalle.DataSource = Tabla
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVProductoDetalle.AutoGenerateColumns = False
        GVProductoDetalle.AllowSorting = True
        GVProductoDetalle.DataBind()
        GVProductoDetalle.Visible = True

        Dim index As Integer
        Dim RenglonAInsertar As DataRow
        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            index = Convert.ToUInt64(MiDataRow.RowIndex)
            RenglonAInsertar = TablaPromocionObsequioDetalle.NewRow()
            RenglonAInsertar("IdPromocionObsequioDetalle") = Tabla.Rows(index).Item("IdPromocionObsequioDetalle")
            RenglonAInsertar("IdPromocionObsequio") = Tabla.Rows(index).Item("IdPromocionObsequio")
            RenglonAInsertar("IdProducto") = Tabla.Rows(index).Item("IdProducto")
            RenglonAInsertar("IdProductoCorto") = Tabla.Rows(index).Item("IdProductoCorto")
            RenglonAInsertar("Descripcion") = Tabla.Rows(index).Item("Descripcion")
            RenglonAInsertar("PrecioBase") = Tabla.Rows(index).Item("PrecioBase")
            RenglonAInsertar("Cantidad") = Tabla.Rows(index).Item("Cantidad")
            RenglonAInsertar("IdSucursal") = Tabla.Rows(index).Item("IdSucursal")
            RenglonAInsertar("IdEstado") = Tabla.Rows(index).Item("IdEstado")
            RenglonAInsertar("Estado") = Tabla.Rows(index).Item("Estado")
            TablaPromocionObsequioDetalle.Rows.Add(RenglonAInsertar)
        Next
        For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
            index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaPromocionObsequioDetalle.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidadExistencia"), TextBox).Text = TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad")
        Next

        EntidadObsequio.IndicadorConsulta = 1
        EntidadObsequio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioObsequio.Consultar(EntidadObsequio)
        Tabla = EntidadObsequio.TablaConsulta
        'GVProductoDetalleObsequio.DataSource = Tabla
        'Dim Columna2 As New CommandField()
        'Columna2.HeaderText = ""
        'Columna2.ButtonType = ButtonType.Link
        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            index = Convert.ToUInt64(MiDataRow.RowIndex)
            RenglonAInsertar = TablaObsequioDetalleCantidad.NewRow()
            RenglonAInsertar("IdPromocionObsequioDetalleCantidad") = Tabla.Rows(index).Item("IdPromocionObsequioDetalleCantidad")
            RenglonAInsertar("IdPromocionObsequioDetalle") = Tabla.Rows(index).Item("IdPromocionObsequioDetalle")
            RenglonAInsertar("IdSucursal") = Tabla.Rows(index).Item("IdSucursal")
            RenglonAInsertar("Cantidad") = Tabla.Rows(index).Item("Cantidad")
            RenglonAInsertar("IdEstado") = Tabla.Rows(index).Item("IdEstado")
            TablaObsequioDetalleCantidad.Rows.Add(RenglonAInsertar)
        Next
        'Dim RenglonAInsertarActualizar1 As DataRow
        'For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
        '    Index2 = Convert.ToUInt64(MiDataRow.RowIndex)
        '    RenglonAInsertarActualizar1 = TablaPromocionDetalleObsequio.NewRow()
        '    RenglonAInsertarActualizar1("IdPromocionDetalle") = Tabla.Rows(Index2).Item("IdPromocionDetalle")
        '    RenglonAInsertarActualizar1("IdPromocionObsequio") = Tabla.Rows(Index2).Item("IdPromocionObsequio")
        '    RenglonAInsertarActualizar1("IdProducto") = Tabla.Rows(Index2).Item("IdProducto")
        '    RenglonAInsertarActualizar1("Descripcion") = Tabla.Rows(Index2).Item("Descripcion")
        '    RenglonAInsertarActualizar1("PrecioBase") = Tabla.Rows(Index2).Item("PrecioBase")
        '    RenglonAInsertarActualizar1("Estado") = Tabla.Rows(Index2).Item("Estado")
        '    TablaPromocionDetalleObsequio.Rows.Add(RenglonAInsertarActualizar1)
        'Next
        'Session("TablaPromocionDetalleObsequio") = TablaPromocionDetalleObsequio
        EntidadObsequio.IndicadorConsulta = 2
        EntidadObsequio.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioObsequio.Consultar(EntidadObsequio)
        Tabla = EntidadObsequio.TablaConsulta

        GVProductoDetalleObsequio.DataSource = Tabla
        Dim Columna2 As New CommandField()
        Columna2.HeaderText = ""
        Columna2.ButtonType = ButtonType.Link
        Columna2.ShowSelectButton = True
        GVProductoDetalleObsequio.AutoGenerateColumns = False
        GVProductoDetalleObsequio.AllowSorting = True
        GVProductoDetalleObsequio.DataBind()
        GVProductoDetalleObsequio.Visible = True
        'GVProductoObsequio.Columns.Clear()
        'TablaProductoObsequio1 = Tabla
        'GVProductoObsequio.DataSource = Tabla
        'GVProductoObsequio.AutoGenerateColumns = False
        'GVProductoObsequio.AllowSorting = True
        'GVProductoObsequio.Visible = True
        For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
            index = Convert.ToUInt64(MiDataRow.RowIndex)
            RenglonAInsertar = TablaPromocionObsequioProducto.NewRow()
            RenglonAInsertar("IdPromocionObsequioProducto") = Tabla.Rows(index).Item("Identificador")
            RenglonAInsertar("IdPromocionObsequioDetalle") = 0  'Tabla.Rows(index).Item("IdPromocionObsequioDetalle")
            RenglonAInsertar("IdProducto") = Tabla.Rows(index).Item("IdProducto")
            RenglonAInsertar("IdProductoCorto") = Tabla.Rows(index).Item("IdProductoCorto")
            RenglonAInsertar("Descripcion") = Tabla.Rows(index).Item("Descripcion")
            RenglonAInsertar("PrecioBase") = Tabla.Rows(index).Item("PrecioBase")
            RenglonAInsertar("Cantidad") = Tabla.Rows(index).Item("Cantidad")
            RenglonAInsertar("IdEstado") = Tabla.Rows(index).Item("IdEstado")
            RenglonAInsertar("Estado") = Tabla.Rows(index).Item("Estado")
            TablaPromocionObsequioProducto.Rows.Add(RenglonAInsertar)
        Next
        '/*
        'For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
        '    index = Convert.ToUInt64(MiDataRow.RowIndex)
        '    TablaPromocionObsequioProducto.Rows(index).Item("IdPromocionObsequioDetalle") = TablaObsequioDetalleCantidad.Rows(index).Item("IdPromocionObsequioDetalle")
        'Next
        '*/
        For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
            index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = TablaPromocionObsequioProducto.NewRow()
            CType(MiDataRow2.FindControl("TBGVCantidadObsequio"), TextBox).Text = TablaPromocionObsequioProducto.Rows(index).Item("Cantidad")
        Next

        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Producto", "ProductoEncabezado")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio del Producto", "PrecioEncabezado")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Obsequio", "ProductoObsequio")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio del Obsequio", "PrecioObsequio")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio Total", "PrecioCalculado")
        'GVProductoObsequio.DataBind()
        'Session("TablaProductoObsequio1") = TablaProductoObsequio1
        BTNCalcular2.Enabled = True
        BTNRedondeo0.Enabled = True
        IBTGuardar.Visible = True
        Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
        Session("TablaObsequioDetalleCantidad") = TablaObsequioDetalleCantidad
        Session("TablaPromocionObsequioProducto") = TablaPromocionObsequioProducto
        Calcular()
        divGVProducto.Visible = False
        divGVProducto2.Visible = False
    End Sub

    Protected Sub DDClasificacionObsequio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacionObsequio.SelectedIndexChanged
        ConsultaSubclasificacionesObsequio()
    End Sub
    Protected Sub BTNAgregarObsequio_Click(sender As Object, e As EventArgs) Handles BTNAgregarObsequio.Click
        'Dim EntidadObsequio As New Entidad.Obsequio()
        'TablaProductoObsequio = Session("TablaProductoObsequio")
        'TablaPromocionDetalleObsequio = Session("TablaPromocionDetalleObsequio")
        'TablaActualizarObsequio = Session("TablaActualizarObsequio")
        BTNQuitarObsequio.Visible = True
        BTNRedondeo.Visible = True
        BtnCalcular.Visible = True

        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdPromocionObsequioProducto", Type.GetType("System.String")))
        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", Type.GetType("System.String")))
        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.String")))
        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("PrecioBase", Type.GetType("System.String")))
        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
        'TablaPromocionObsequioProducto.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))
        Dim RenglonAInsertar As DataRow
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVProductoObsequiar.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            If CType(MiDataRow.FindControl("CBGVPromocionObsequioItem"), CheckBox).Checked = True Then
                'Validar que el producto serleccionado ya no este en la lista de TablaPromocionObsequioProducto
                Dim validar = 0
                For Each RowValidar As DataRow In TablaPromocionObsequioProducto.Rows
                    If RowValidar.Item("IdProducto") = TablaProductoObsequio.Rows(Index).Item("IdProducto") Then
                        validar = 1
                    End If
                Next
                If validar = 0 Then
                    RenglonAInsertar = TablaPromocionObsequioProducto.NewRow()
                    RenglonAInsertar("IdPromocionObsequioProducto") = 0
                    RenglonAInsertar("IdPromocionObsequioDetalle") = 0
                    RenglonAInsertar("IdProducto") = TablaProductoObsequio.Rows(Index).Item("IdProducto")
                    RenglonAInsertar("IdProductoCorto") = TablaProductoObsequio.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertar("Descripcion") = TablaProductoObsequio.Rows(Index).Item("Descripcion")
                    RenglonAInsertar("PrecioBase") = TablaProductoObsequio.Rows(Index).Item("PrecioBase")
                    RenglonAInsertar("Cantidad") = TablaProductoObsequio.Rows(Index).Item("Existencia")
                    RenglonAInsertar("IdEstado") = TablaProductoObsequio.Rows(Index).Item("IdEstado")
                    RenglonAInsertar("Estado") = TablaProductoObsequio.Rows(Index).Item("Estado")
                    TablaPromocionObsequioProducto.Rows.Add(RenglonAInsertar)
                End If
            End If
        Next
        If TablaPromocionObsequioProducto.Rows.Count > 0 Then
            GVProductoDetalleObsequio.DataSource = TablaPromocionObsequioProducto
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVProductoDetalleObsequio.AutoGenerateColumns = False
            GVProductoDetalleObsequio.AllowSorting = True
            GVProductoDetalleObsequio.DataBind()
            GVProductoDetalleObsequio.Visible = True
            For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaPromocionObsequioProducto.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidadObsequio"), TextBox).Text = TablaPromocionObsequioProducto.Rows(Index).Item("Cantidad")
            Next
        End If
        Session("TablaPromocionObsequioProducto") = TablaPromocionObsequioProducto

        BTNQuitarObsequio.Visible = True
        BTNCalcular2.Enabled = True
        BTNRedondeo0.Enabled = True
    End Sub

    Protected Sub BTNQuitarObsequio_Click(sender As Object, e As EventArgs) Handles BTNQuitarObsequio.Click
        'Dim EntidadObsequio As New Entidad.Obsequio()
        Dim EstadoActualizar As Integer
        EstadoActualizar = Session("EstadoActualizar")
        BTNAgregarObsequio.Visible = True
        If EstadoActualizar = 0 Then
            'TablaPromocionDetalleObsequio = Session("TablaPromocionDetalleObsequio") 'tiene todos producto detalle
            Dim TablaActualizacionPOP As New DataTable()
            TablaActualizacionPOP.Columns.Add(New DataColumn("IdPromocionObsequioProducto", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("Cantidad", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaActualizacionPOP.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))

            Dim RenglonAInsertarActualizar As DataRow
            Dim Index As Integer
            For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVPromocionDetalleObsequioItem"), CheckBox).Checked = True Then

                Else
                    RenglonAInsertarActualizar = TablaActualizacionPOP.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionObsequioProducto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioProducto")
                    RenglonAInsertarActualizar("IdPromocionObsequioDetalle") = TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioDetalle")
                    RenglonAInsertarActualizar("IdProducto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdProducto")
                    RenglonAInsertarActualizar("IdProductoCorto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertarActualizar("Descripcion") = TablaPromocionObsequioProducto.Rows(Index).Item("Descripcion")
                    RenglonAInsertarActualizar("PrecioBase") = TablaPromocionObsequioProducto.Rows(Index).Item("PrecioBase")
                    RenglonAInsertarActualizar("Cantidad") = TablaPromocionObsequioProducto.Rows(Index).Item("Cantidad")
                    RenglonAInsertarActualizar("IdEstado") = TablaPromocionObsequioProducto.Rows(Index).Item("IdEstado")
                    RenglonAInsertarActualizar("Estado") = TablaPromocionObsequioProducto.Rows(Index).Item("Estado")
                    TablaActualizacionPOP.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next
            If TablaPromocionObsequioProducto.Rows.Count > 0 Then
                GVProductoDetalleObsequio.DataSource = TablaActualizacionPOP
                Dim Columna As New CommandField()
                Columna.HeaderText = ""
                Columna.ButtonType = ButtonType.Link
                Columna.ShowSelectButton = True
                GVProductoDetalleObsequio.AutoGenerateColumns = False
                GVProductoDetalleObsequio.AllowSorting = True
                GVProductoDetalleObsequio.DataBind()
                GVProductoDetalleObsequio.Visible = True
                'Session("TablaProducto") = TablaProducto
                For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
                    Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                    Dim NuevoRow As DataRow = TablaActualizacionPOP.NewRow()
                    CType(MiDataRow2.FindControl("TBGVCantidadObsequio"), TextBox).Text = TablaActualizacionPOP.Rows(Index).Item("Cantidad")
                Next
            End If
            TablaPromocionObsequioProducto = TablaActualizacionPOP

            Session("TablaPromocionObsequioProducto") = TablaPromocionObsequioProducto
        Else
            'PARTE DE ACTUALIZAR   ##############################################################################################################################################################################3
            'TablaPromocionDetalleObsequio = Session("TablaPromocionDetalleObsequio") 'tiene todos producto detalle
            TablaRegistroObsequio = Session("TablaRegistroObsequio")
            Dim TablaActualizacion As New DataTable()

            TablaActualizacion.Columns.Add(New DataColumn("IdPromocionObsequioProducto", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProductoCorto", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("PrecioBase", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdEstado", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Estado", Type.GetType("System.String")))

            Dim RenglonAInsertarActualizar As DataRow
            Dim RenglonAInsertarActualizar2 As DataRow
            Dim Index As Integer

            For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVPromocionDetalleObsequioItem"), CheckBox).Checked = True Then
                    RenglonAInsertarActualizar2 = TablaRegistroObsequio.NewRow()
                    If TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioProducto") = 0 Then
                    Else
                        RenglonAInsertarActualizar2("IdPromocionObsequioProducto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioProducto")
                        RenglonAInsertarActualizar2("IdPromocionObsequioDetalle") = TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioDetalle")
                        RenglonAInsertarActualizar2("IdProducto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdProducto")
                        RenglonAInsertarActualizar2("IdProductoCorto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdProductoCorto")
                        RenglonAInsertarActualizar2("Descripcion") = TablaPromocionObsequioProducto.Rows(Index).Item("Descripcion")
                        RenglonAInsertarActualizar2("PrecioBase") = TablaPromocionObsequioProducto.Rows(Index).Item("PrecioBase")
                        RenglonAInsertarActualizar2("Cantidad") = TablaPromocionObsequioProducto.Rows(Index).Item("Cantidad")
                        RenglonAInsertarActualizar2("IdEstado") = 2
                        RenglonAInsertarActualizar2("Estado") = "INACTIVO"
                        TablaRegistroObsequio.Rows.Add(RenglonAInsertarActualizar2)
                    End If
                Else
                    RenglonAInsertarActualizar = TablaActualizacion.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionObsequioProducto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioProducto")
                    RenglonAInsertarActualizar("IdPromocionObsequioDetalle") = TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioDetalle")
                    RenglonAInsertarActualizar("IdProducto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdProducto")
                    RenglonAInsertarActualizar("IdProductoCorto") = TablaPromocionObsequioProducto.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertarActualizar("Descripcion") = TablaPromocionObsequioProducto.Rows(Index).Item("Descripcion")
                    RenglonAInsertarActualizar("PrecioBase") = TablaPromocionObsequioProducto.Rows(Index).Item("PrecioBase")
                    RenglonAInsertarActualizar("Cantidad") = TablaPromocionObsequioProducto.Rows(Index).Item("Cantidad")
                    RenglonAInsertarActualizar("IdEstado") = TablaPromocionObsequioProducto.Rows(Index).Item("IdEstado")
                    RenglonAInsertarActualizar("Estado") = TablaPromocionObsequioProducto.Rows(Index).Item("Estado")
                    TablaActualizacion.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next

            GVProductoDetalleObsequio.DataSource = Nothing
            GVProductoDetalleObsequio.DataSource = TablaActualizacion
            Dim Columna As New CommandField()
            Columna.HeaderText = ""
            Columna.ButtonType = ButtonType.Link
            Columna.ShowSelectButton = True
            GVProductoDetalleObsequio.AutoGenerateColumns = False
            GVProductoDetalleObsequio.AllowSorting = True
            GVProductoDetalleObsequio.DataBind()
            GVProductoDetalleObsequio.Visible = True
            For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
                Index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim NuevoRow As DataRow = TablaActualizacion.NewRow()
                CType(MiDataRow2.FindControl("TBGVCantidadObsequio"), TextBox).Text = TablaActualizacion.Rows(Index).Item("Cantidad")
            Next
            'TablaPromocionDetalleObsequio = TablaActualizacion
            ''Session("TablaProducto") = TablaProducto
            'Session("TablaPromocionDetalleObsequio") = TablaPromocionDetalleObsequio
            ''TablaRegistro = TablaActualizacion2
            'Session("TablaRegistroObsequio") = TablaRegistroObsequio
            Session("TablaPromocionObsequioProducto") = TablaActualizacion
            Session("TablaRegistroObsequio") = TablaRegistroObsequio
        End If
    End Sub

    Protected Sub BTNConsultarObsequio_Click(sender As Object, e As EventArgs) Handles BTNConsultarObsequio.Click
        GVProductoObsequiar.DataSource = Nothing
        GVProductoDetalleObsequio.DataSource = Nothing
        Dim NegocioObsequio As New Negocio.Obsequio()
        Dim EntidadObsequio As New Entidad.Obsequio()
        Dim TablaProductos As New DataTable()
        EntidadObsequio.IdClasificacion = DDClasificacionObsequio.SelectedValue
        EntidadObsequio.IdSubClasificacion = DDSubclasificacionObsequio.SelectedValue
        EntidadObsequio.Sucursal = IdSucursal
        EntidadObsequio.Tarjeta.Consulta = Consulta.Ninguno
        NegocioObsequio.Consultar(EntidadObsequio)
        TablaProductos = EntidadObsequio.TablaConsulta
        GVProductoObsequiar.DataSource = TablaProductos
        GVProductoObsequiar.AutoGenerateColumns = False
        GVProductoObsequiar.AllowSorting = True
        GVProductoObsequiar.DataBind()
        If GVProductoObsequiar.Rows.Count > 0 Then
            BTNAgregarObsequio.Visible = True
            GVProductoObsequiar.Visible = True
            Session("TablaProductoObsequio") = TablaProductos
        Else
            BTNAgregarObsequio.Visible = False
            GVProductoObsequiar.Visible = False
        End If
        divGVProducto2.Visible = True
    End Sub
    Protected Sub BtnCalcular_Click1(sender As Object, e As EventArgs) Handles BtnCalcular.Click
        Calcular()
    End Sub

    Private Sub Calcular()
        If GVProductoDetalle.Rows.Count > 0 Or GVProductoDetalleObsequio.Rows.Count > 0 Then
            If TBMonto.Text = String.Empty Then
                TBMonto.Text = 0
            End If
            'Dim Redondeo As Integer
            'Redondeo = Session("Redondeo")
            'TablaProductoObsequio1 = Session("TablaProductoObsequio1")
            'Redondeo = 1
            'Session("Redondeo") = Redondeo

            ''TablaPromocionDetalle = Session("TablaPromocionDetalle")
            ''TablaPromocionDetalleObsequio = Session("TablaPromocionDetalleObsequio")
            'TablaProductoObsequio1 = Session("TablaProductoObsequio1")
            'EstadoActualizar = Session("EstadoActualizar")
            Dim Tabla As New DataTable
            'Tabla.Columns.Add(New DataColumn("IdPromocionProductoObsequio", System.Type.GetType("System.String")))
            'Tabla.Columns.Add(New DataColumn("IdPromocionDetalleObsequio", System.Type.GetType("System.String")))
            'Tabla.Columns.Add(New DataColumn("IdPromocionEncabezado", System.Type.GetType("System.String")))
            'Tabla.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("IdProductoEncabezado", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("ProductoEncabezado", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("CantidadExistencia", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("PrecioEncabezado", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("IdProductoObsequio", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("ProductoObsequio", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("CantidadObsequio", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("PrecioObsequio", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("IdPromocionObsequioProducto", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("IdPromocionObsequioDetalle", System.Type.GetType("System.String")))
            Tabla.Columns.Add(New DataColumn("PrecioCalculado", System.Type.GetType("System.String")))
            ''---------------------------------- mODIFICAR 
            Dim index As Integer
            Dim Renglon As DataRow
            'If EstadoActualizar = 0 Then
            '    'If CBPrecioCero.Checked = True Then
            If DDOpcion.SelectedValue = 2 Then
                For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                    index = Convert.ToUInt64(MiDataRow.RowIndex)
                    Dim index2 As Integer
                    For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
                        index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
                        Renglon = Tabla.NewRow()
                        Renglon("IdProductoEncabezado") = TablaPromocionObsequioDetalle.Rows(index).Item("IdProducto")
                        Renglon("ProductoEncabezado") = TablaPromocionObsequioDetalle.Rows(index).Item("Descripcion")
                        Renglon("CantidadExistencia") = TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad")
                        Renglon("PrecioEncabezado") = CDbl(TablaPromocionObsequioDetalle.Rows(index).Item("PrecioBase"))
                        Renglon("IdProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("IdProducto")
                        Renglon("ProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Descripcion")
                        Renglon("CantidadObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Cantidad")
                        Renglon("PrecioObsequio") = CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("PrecioBase"))
                        Renglon("ProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Descripcion")
                        Renglon("ProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Descripcion") 'IdPromocionObsequioProducto  IdPromocionObsequioDetalle
                        Renglon("IdPromocionObsequioProducto") = TablaPromocionObsequioProducto.Rows(index2).Item("IdPromocionObsequioProducto")
                        Renglon("IdPromocionObsequioDetalle") = TablaPromocionObsequioProducto.Rows(index2).Item("IdPromocionObsequioDetalle")
                        Renglon("PrecioCalculado") = CDbl(TablaPromocionObsequioDetalle.Rows(index).Item("PrecioBase")) + (CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("PrecioBase")) * CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("Cantidad")))
                        Tabla.Rows.Add(Renglon)
                    Next
                Next
            ElseIf DDOpcion.SelectedValue = 1 Then
                'If TBMonto.Text = 0 Then
                For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                    index = Convert.ToUInt64(MiDataRow.RowIndex)
                    Dim index2 As Integer
                    For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
                        index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
                        Renglon = Tabla.NewRow()
                        Renglon("IdProductoEncabezado") = TablaPromocionObsequioDetalle.Rows(index).Item("IdProducto")
                        Renglon("ProductoEncabezado") = TablaPromocionObsequioDetalle.Rows(index).Item("Descripcion")
                        Renglon("CantidadExistencia") = TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad")
                        Renglon("PrecioEncabezado") = CDbl(TablaPromocionObsequioDetalle.Rows(index).Item("PrecioBase"))
                        Renglon("IdProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("IdProducto")
                        Renglon("ProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Descripcion")
                        Renglon("CantidadObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Cantidad")
                        Renglon("PrecioObsequio") = CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("PrecioBase"))
                        Renglon("IdPromocionObsequioProducto") = TablaPromocionObsequioProducto.Rows(index2).Item("IdPromocionObsequioProducto")
                        Renglon("IdPromocionObsequioDetalle") = TablaPromocionObsequioProducto.Rows(index2).Item("IdPromocionObsequioDetalle")
                        Renglon("PrecioCalculado") = CDbl(TablaPromocionObsequioDetalle.Rows(index).Item("PrecioBase")) + (CDbl(TBMonto.Text) * CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("Cantidad")))
                        Tabla.Rows.Add(Renglon)
                    Next
                Next
            Else
                For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                    Index = Convert.ToUInt64(MiDataRow.RowIndex)
                    Dim index2 As Integer
                    For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
                        index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
                        Renglon = Tabla.NewRow()
                        Renglon("IdProductoEncabezado") = TablaPromocionObsequioDetalle.Rows(index).Item("IdProducto")
                        Renglon("ProductoEncabezado") = TablaPromocionObsequioDetalle.Rows(index).Item("Descripcion")
                        Renglon("CantidadExistencia") = TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad")
                        Renglon("PrecioEncabezado") = CDbl(TablaPromocionObsequioDetalle.Rows(index).Item("PrecioBase"))
                        Renglon("IdProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("IdProducto")
                        Renglon("ProductoObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Descripcion")
                        Renglon("CantidadObsequio") = TablaPromocionObsequioProducto.Rows(index2).Item("Cantidad")
                        Renglon("PrecioObsequio") = CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("PrecioBase"))
                        Renglon("IdPromocionObsequioProducto") = TablaPromocionObsequioProducto.Rows(index2).Item("IdPromocionObsequioProducto")
                        Renglon("IdPromocionObsequioDetalle") = TablaPromocionObsequioProducto.Rows(index2).Item("IdPromocionObsequioDetalle")
                        Renglon("PrecioCalculado") = CDbl(TablaPromocionObsequioDetalle.Rows(index).Item("PrecioBase")) + ((CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("PrecioBase")) * (CDbl(TBMonto.Text) / 100)) * CDbl(TablaPromocionObsequioProducto.Rows(index2).Item("Cantidad")))
                        Tabla.Rows.Add(Renglon)
                        'Renglon("PrecioCalculado") = CDbl(TablaPromocionDetalle.Rows(Index).Item("PrecioBase")) + IIf(DDOpcion.SelectedValue = 1, CDbl(TBMonto.Text), CDbl(TBMonto.Text) / 100 * TablaPromocionDetalle.Rows(Index).Item("PrecioBase"))

                    Next
                Next
                'End If
            End If
            '                'End If

            '            Else
            '                ''If CBPrecioCero.Checked = True Then
            '                If DDOpcion.SelectedValue = 3 Then
            '                        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            '                            index = Convert.ToUInt64(MiDataRow.RowIndex)
            '                            Dim index2 As Integer
            '                            For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
            '                                index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            '                                Renglon = Tabla.NewRow()
            '                                Dim Encabezado As Integer = TablaPromocionDetalle.Rows(index).Item("IdPromocionDetalle")
            '                                Dim Obsequio As Integer = TablaPromocionDetalleObsequio.Rows(index2).Item("IdPromocionDetalle")
            '                                Dim EncabezadoPrincipal As Integer = TablaPromocionDetalle.Rows(index).Item("IdPromocionObsequio")
            '                                Renglon("IdPromocionProductoObsequio") = 0
            '                                Renglon("IdPromocionDetalleObsequio") = IIf(Obsequio <> 0, Obsequio, 0)
            '                                Renglon("IdPromocionEncabezado") = IIf(Encabezado <> 0, Encabezado, 0)
            '                                Renglon("IdPromocionObsequio") = IIf(EncabezadoPrincipal <> 0, EncabezadoPrincipal, 0)
            '                                Renglon("ProductoEncabezado") = TablaPromocionDetalle.Rows(index).Item("Descripcion")
            '                                Renglon("PrecioEncabezado") = CDbl(TablaPromocionDetalle.Rows(index).Item("PrecioBase"))
            '                                Renglon("ProductoObsequio") = TablaPromocionDetalleObsequio.Rows(index2).Item("Descripcion")
            '                                Renglon("PrecioObsequio") = CDbl(TablaPromocionDetalleObsequio.Rows(index2).Item("PrecioBase"))
            '                                Renglon("PrecioCalculado") = CDbl(TablaPromocionDetalle.Rows(index).Item("PrecioBase"))
            '                                Tabla.Rows.Add(Renglon)
            '                            Next
            '                        Next
            '                    Else


            '                    'If TBMonto.Text = 0 Then
            '                    If DDOpcion.SelectedValue = 2 Then
            '                            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            '                                index = Convert.ToUInt64(MiDataRow.RowIndex)
            '                                Dim index2 As Integer
            '                                For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
            '                                    index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            '                                    Renglon = Tabla.NewRow()
            '                                    Dim Encabezado As Integer = TablaPromocionDetalle.Rows(index).Item("IdPromocionDetalle")
            '                                    Dim Obsequio As Integer = TablaPromocionDetalleObsequio.Rows(index2).Item("IdPromocionDetalle")
            '                                    Dim EncabezadoPrincipal As Integer = TablaPromocionDetalle.Rows(index).Item("IdPromocionObsequio")
            '                                    Renglon("IdPromocionProductoObsequio") = 0
            '                                    Renglon("IdPromocionDetalleObsequio") = IIf(Obsequio <> 0, Obsequio, 0)
            '                                    Renglon("IdPromocionEncabezado") = IIf(Encabezado <> 0, Encabezado, 0)
            '                                    Renglon("IdPromocionObsequio") = IIf(EncabezadoPrincipal <> 0, EncabezadoPrincipal, 0)
            '                                    Renglon("ProductoEncabezado") = TablaPromocionDetalle.Rows(index).Item("Descripcion")
            '                                    Renglon("PrecioEncabezado") = CDbl(TablaPromocionDetalle.Rows(index).Item("PrecioBase"))
            '                                    Renglon("ProductoObsequio") = TablaPromocionDetalleObsequio.Rows(index2).Item("Descripcion")
            '                                    Renglon("PrecioObsequio") = CDbl(TablaPromocionDetalleObsequio.Rows(index2).Item("PrecioBase"))
            '                                    Renglon("PrecioCalculado") = CDbl(TablaPromocionDetalle.Rows(index).Item("PrecioBase")) + CDbl(TablaPromocionDetalleObsequio.Rows(index2).Item("PrecioBase"))
            '                                    Tabla.Rows.Add(Renglon)
            '                                Next
            '                            Next
            '                        Else
            '                            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            '                            index = Convert.ToUInt64(MiDataRow.RowIndex)
            '                            Dim index2 As Integer
            '                            For Each MiDataRow2 As GridViewRow In GVProductoDetalleObsequio.Rows
            '                                index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
            '                                Renglon = Tabla.NewRow()
            '                                Renglon("IdPromocionProductoObsequio") = 0
            '                                Renglon("IdPromocionDetalleObsequio") = 0
            '                                Renglon("IdPromocionEncabezado") = 0
            '                                Renglon("IdPromocionObsequio") = 0
            '                                Renglon("ProductoEncabezado") = TablaPromocionDetalle.Rows(index).Item("Descripcion")
            '                                Renglon("PrecioEncabezado") = CDbl(TablaPromocionDetalle.Rows(index).Item("PrecioBase"))
            '                                Renglon("ProductoObsequio") = TablaPromocionDetalleObsequio.Rows(index2).Item("Descripcion")
            '                                Renglon("PrecioObsequio") = CDbl(TablaPromocionDetalleObsequio.Rows(index2).Item("PrecioBase"))
            '                                Renglon("PrecioCalculado") = CDbl(TablaPromocionDetalle.Rows(index).Item("PrecioBase")) + IIf(DDOpcion.SelectedValue = 1, CDbl(TBMonto.Text), CDbl(TBMonto.Text) / 100 * TablaPromocionDetalle.Rows(index).Item("PrecioBase"))
            '                                Tabla.Rows.Add(Renglon)
            '                            Next
            '                        Next
            '                    End If

            '                End If


            GVProductoObsequio.Columns.Clear()
            TablaProductoObsequio1 = Tabla
            GVProductoObsequio.DataSource = Tabla
            GVProductoObsequio.AutoGenerateColumns = False
            GVProductoObsequio.AllowSorting = True
            GVProductoObsequio.Visible = True

            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Producto", "ProductoEncabezado")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Cantidad en Existencia", "CantidadExistencia")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio del Producto", "PrecioEncabezado")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Obsequio", "ProductoObsequio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Cantidad de Obsequio(s)", "CantidadObsequio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio del Obsequio", "PrecioObsequio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio Total", "PrecioCalculado")
            GVProductoObsequio.DataBind()
            Session("TablaProductoObsequio1") = TablaProductoObsequio1
        End If
    End Sub

    Protected Sub BTNCalcular2_Click(sender As Object, e As EventArgs) Handles BTNCalcular2.Click
        Calcular()
    End Sub
    Private Sub Mredondeo()
        If GVProductoObsequio.Rows.Count > 0 Then
            Dim index As Integer
            ''''Dim Redondeo As Integer
            ''''Redondeo = Session("Redondeo")
            ''''TablaProductoObsequio1 = Session("TablaProductoObsequio1")
            ''''Redondeo = 2
            ''''Session("Redondeo") = Redondeo

            'Dim Tabla As New DataTable
            'Tabla.Columns.Add(New DataColumn("IdPromocionProductoObsequio", System.Type.GetType("System.String")))
            'Tabla.Columns.Add(New DataColumn("IdPromocionDetalleObsequio", System.Type.GetType("System.String")))
            'Tabla.Columns.Add(New DataColumn("IdPromocionEncabezado", System.Type.GetType("System.String")))
            'Tabla.Columns.Add(New DataColumn("IdPromocionObsequio", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("ProductoEncabezado", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("CantidadExistencia", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("PrecioEncabezado", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("ProductoObsequio", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("CantidadObsequio", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("PrecioObsequio", System.Type.GetType("System.String")))
            ''Tabla.Columns.Add(New DataColumn("PrecioCalculado", System.Type.GetType("System.String")))
            ''Tabla = TablaProductoObsequio1
            For Each MiDataRow2 As GridViewRow In GVProductoObsequio.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                TablaProductoObsequio1.Rows(index).Item("PrecioCalculado") = Round(CDbl(TablaProductoObsequio1.Rows(index).Item("PrecioCalculado")))
            Next

            GVProductoObsequio.Columns.Clear()
            TablaProductoObsequio1 = TablaProductoObsequio1
            GVProductoObsequio.DataSource = TablaProductoObsequio1
            GVProductoObsequio.AutoGenerateColumns = False
            GVProductoObsequio.AllowSorting = True
            GVProductoObsequio.Visible = True

            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Producto", "ProductoEncabezado")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Cantidad en Existencia", "CantidadExistencia")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio del Producto", "PrecioEncabezado")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Obsequio", "ProductoObsequio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Cantidad de Obsequio(s)", "CantidadObsequio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio del Obsequio", "PrecioObsequio")
            Comun.Presentacion.Cuadricula.AgregarColumna(GVProductoObsequio, New BoundField(), "Precio Total", "PrecioCalculado")
            GVProductoObsequio.DataBind()
            Session("TablaProductoObsequio1") = TablaProductoObsequio1
        End If
    End Sub
    Protected Sub BTNRedondeo_Click(sender As Object, e As EventArgs) Handles BTNRedondeo.Click
        Mredondeo()
    End Sub

    '''''Protected Sub BTNEliminarDuplicado_Click(sender As Object, e As EventArgs) Handles BTNEliminarDuplicado.Click
    '''''    'TablaPromocionDetalle = Session("TablaPromocionDetalle")
    '''''    TablaProducto = Session("TablaProducto")
    '''''    'DDCBSucursal.r()
    '''''    Dim TablaTemporal As New DataTable()
    '''''    TablaTemporal.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
    '''''    TablaTemporal.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
    '''''    TablaTemporal.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
    '''''    TablaTemporal.Columns.Add(New DataColumn("Existencia", System.Type.GetType("System.String")))
    '''''    TablaTemporal.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))

    '''''    Dim index As Integer
    '''''    Dim index2 As Integer
    '''''    Dim Renglon As DataRow
    '''''    'For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
    '''''    '    index = Convert.ToUInt64(MiDataRow.RowIndex)
    '''''    '    For Each MiDataRow2 As GridViewRow In GVProducto.Rows
    '''''    '        index2 = Convert.ToUInt64(MiDataRow2.RowIndex)
    '''''    '        Dim principal As Integer = TablaPromocionDetalle.Rows(index).Item("IdProducto")
    '''''    '        Dim secundario As Integer = TablaProducto.Rows(index2).Item("IdProducto")
    '''''    '        If principal <> secundario Then
    '''''    '            Renglon = TablaTemporal.NewRow()
    '''''    '            Renglon("IdProducto") = TablaProducto.Rows(index2).Item("IdProducto")
    '''''    '            Renglon("Descripcion") = TablaProducto.Rows(index2).Item("Descripcion")
    '''''    '            Renglon("PrecioBase") = TablaProducto.Rows(index2).Item("PrecioBase")
    '''''    '            Renglon.Item("Existencia") = TablaProducto.Rows(index2).Item("Existencia")
    '''''    '            Renglon("Estado") = TablaProducto.Rows(index2).Item("Estado")
    '''''    '            TablaTemporal.Rows.Add(Renglon)
    '''''    '        End If
    '''''    '    Next
    '''''    'Next
    '''''End Sub

    'Protected Sub GVSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSucursal.SelectedIndexChanged
    '    'PASucursal.Visible = True
    '    'BTNEliminarSucursal.Visible = True

    '    'Dim TablaIdentificacion As New DataTable
    '    'TablaSucursal = Session("TablaSucursal")
    '    'DDSucursal.SelectedValue = TablaSucursal.Rows(GVSucursal.SelectedIndex).Item("IdSucursal")
    '    'PASucursal.Visible = True
    '    'GVSucursal.Visible = False
    'End Sub

    'Protected Sub BTNAceptarSucursal_Click(sender As Object, e As EventArgs) Handles BTNAceptarSucursal.Click
    '    TablaSucursal = Session("TablaSucursal")
    '    VistaTablaSucursal = Session("VistaTablaSucursal")
    '    EstadoActualizar = Session("EstadoActualizar")
    '    'If EstadoActualizar = 1 Then
    '    '    VistaTablaSucursal = TablaSucursal
    '    'End If

    '    Dim bandera As Boolean = True

    '    For Each fila As DataRow In TablaSucursal.Rows
    '        If fila.Item("IdSucursal").ToString() = DDSucursal.SelectedValue.ToString() Then
    '            bandera = False
    '            Exit For
    '        End If
    '    Next

    '    If bandera Then
    '        Dim Renglon As DataRow
    '        Renglon = TablaSucursal.NewRow
    '        Renglon("IdPromocionSucursal") = 0
    '        Renglon("IdPromocionObsequio") = 0 'Int32.Parse(TBIdPromocion.Text)
    '        Renglon("IdSucursal") = DDSucursal.SelectedValue
    '        Renglon("NombreSucursal") = DDSucursal.SelectedItem

    '        TablaSucursal.Rows.Add(Renglon)

    '        Session("TablaSucursal") = TablaSucursal
    '        Session("VistaTablaSucursal") = VistaTablaSucursal
    '        GVSucursal.DataSource = VistaTablaSucursal
    '        GVSucursal.DataBind()

    '        PASucursal.Visible = False
    '        GVSucursal.Visible = True
    '    End If
    'End Sub

    'Protected Sub BTNEliminarSucursal_Click(sender As Object, e As EventArgs) Handles BTNEliminarSucursal.Click
    '    TablaSucursal = Session("TablaSucursal")
    '    VistaTablaSucursal = Session("VistaTablaSucursal")
    '    EstadoActualizar = Session("EstadoActualizar")

    '    Dim Renglon As Integer = GVSucursal.SelectedIndex
    '    'If EstadoActualizar = 1 Then
    '    '    VistaTablaSucursal = TablaSucursal
    '    'End If
    '    If VistaTablaSucursal(Renglon).Item("Idsucursal") = DDSucursal.SelectedValue Then
    '        VistaTablaSucursal(Renglon).Delete()
    '        'Else
    '        '    VistaTablaSucursal(Renglon).Item("idActualizar") = 1 'Si   
    '        '    VistaIdentificacion(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
    '    End If

    '    If EstadoActualizar = 1 Then
    '        TablaSucursal = VistaTablaSucursal.ToTable
    '        VistaTablaSucursal = TablaSucursal.DefaultView
    '    End If
    '    Session("TablaSucursal") = TablaSucursal
    '    Session("VistaTablaSucursal") = VistaTablaSucursal
    '    GVSucursal.DataSource = VistaTablaSucursal
    '    GVSucursal.DataBind()
    '    PASucursal.Visible = False
    '    GVSucursal.Visible = True
    'End Sub

    'Protected Sub BTNuevaSucursal_Click(sender As Object, e As EventArgs) Handles BTNuevaSucursal.Click
    '    PASucursal.Visible = True
    '    BTNEliminarSucursal.Visible = False
    'End Sub

    Protected Sub BTNRedondeo0_Click(sender As Object, e As EventArgs) Handles BTNRedondeo0.Click
        Mredondeo()
    End Sub

    Protected Sub IBTCopiar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCopiar.Click
        BTNQuitar.Visible = False
        BTNAgregar.Visible = False
        Dim NegocioObsequio As New Negocio.Obsequio()
        Dim EntidadObsequio As New Entidad.Obsequio()

        EstadoActualizar = 2
        Dim Redondeo As Integer
        Redondeo = Session("Redondeo")

        If TablaPromocionObsequioDetalle.Rows.Count = 0 Then
            Exit Sub
        End If
        If TablaPromocionObsequioProducto.Rows.Count = 0 Then
            Exit Sub
        End If
        Calcular()
        EntidadObsequio.AplicarRedondeo = Redondeo

        If TBIdPromocion.Text Is String.Empty Then
            EntidadObsequio.IdPromocion = 0
        Else
            EntidadObsequio.IdPromocion = 0
        End If
        If TBFechaInicio.Text Is String.Empty Then
            EntidadObsequio.FechaInicio = "01/01/1990"
        Else
            EntidadObsequio.FechaInicio = TBFechaInicio.Text
        End If
        If TBFechaFin.Text Is String.Empty Then
            EntidadObsequio.FechaFin = "01/01/1990"
        Else
            EntidadObsequio.FechaFin = TBFechaFin.Text
        End If
        If TBDescripcion.Text = String.Empty Then
            EntidadObsequio.Descripcion = "NINGUNO"
        Else
            EntidadObsequio.Descripcion = TBDescripcion.Text
        End If
        If TBObservacion.Text = String.Empty Then
            EntidadObsequio.Observacion = "NINGUNO"
        Else
            EntidadObsequio.Observacion = TBObservacion.Text
        End If
        If TBMonto.Text = String.Empty Then
            EntidadObsequio.MontoPorcentaje = 0
        Else
            EntidadObsequio.MontoPorcentaje = CDbl(TBMonto.Text)
        End If

        EntidadObsequio.IdEstado = CInt(DDEstado.SelectedValue)

        EntidadObsequio.TipoMontoPorcentaje = TipoMontoPorcentaje    '0 es para monto y 1 para porcentaje 2 para segundo producto 
        EntidadObsequio.IndicadorEstado = EstadoActualizar

        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequioDetalle") = 0
            TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequio") = 0
        Next
        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            TablaObsequioDetalleCantidad.Rows(Index).Item("IdPromocionObsequioDetalleCantidad") = 0
            TablaPromocionObsequioDetalle.Rows(Index).Item("IdPromocionObsequioDetalle") = 0
        Next
        For Each MiDataRow As GridViewRow In GVProductoDetalleObsequio.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioProducto") = 0
            TablaPromocionObsequioProducto.Rows(Index).Item("IdPromocionObsequioDetalle") = 0
        Next
        EntidadObsequio.TablaPromocionObsequioDetalle = TablaPromocionObsequioDetalle
            EntidadObsequio.TablaPromocionObsequioProducto = TablaPromocionObsequioProducto
            EntidadObsequio.TablaObsequioDetalleCantidad = TablaObsequioDetalleCantidad
            NegocioObsequio.Guardar(EntidadObsequio)

            TBIdPromocion.Text = EntidadObsequio.IdPromocion.ToString()
    End Sub
    Protected Sub GVICantidadExistencia(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaPromocionObsequioDetalle = CType(Session("TablaPromocionObsequioDetalle"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBCantidad1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBCantidad1.Text) Then
            actualizarrenglonP(TablaPromocionObsequioDetalle, index, TBCantidad1.Text)
            actualizarrenglonPC(TablaObsequioDetalleCantidad, index, TBCantidad1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVProductoDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaPromocionObsequioDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVCantidadExistencia"), TextBox).Text = TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad")
        End If
        Session("TablaPromocionObsequioDetalle") = TablaPromocionObsequioDetalle
    End Sub
    Private Sub actualizarrenglonP(ByRef TablaPromocionObsequioDetalle As DataTable, ByVal index As Integer, ByVal _Cantidad As Double)
        Dim cantidad As Double = TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad")
        'If Descuento <= cantidad Then
        TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad") = _Cantidad
        TablaPromocionObsequioDetalle.AcceptChanges()
    End Sub
    Private Sub actualizarrenglonPC(ByRef TablaPromocionObsequioDetalle As DataTable, ByVal index As Integer, ByVal _Cantidad As Double)
        Dim cantidad As Double = TablaObsequioDetalleCantidad.Rows(index).Item("Cantidad")
        'If Descuento <= cantidad Then
        TablaPromocionObsequioDetalle.Rows(index).Item("Cantidad") = _Cantidad
        TablaPromocionObsequioDetalle.AcceptChanges()
    End Sub
    Protected Sub GVICantidadObsequio(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaPromocionObsequioProducto = CType(Session("TablaPromocionObsequioProducto"), DataTable)
        Dim TBCantidad As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBCantidad.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBCantidad1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBCantidad1.Text) Then
            actualizarrenglonCantidadObsequio(TablaPromocionObsequioProducto, index, TBCantidad1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVProductoDetalleObsequio.Rows(index)
            Dim NuevoRow As DataRow = TablaPromocionObsequioProducto.NewRow()
            CType(MiDataRow.FindControl("TBGVCantidadObsequio"), TextBox).Text = TablaPromocionObsequioProducto.Rows(index).Item("Cantidad")
        End If
        Session("TablaPromocionObsequioProducto") = TablaPromocionObsequioProducto
    End Sub
    Private Sub actualizarrenglonCantidadObsequio(ByRef TablaPromocionObsequioProducto As DataTable, ByVal index As Integer, ByVal _Cantidad As Double)
        Dim cantidad As Double = TablaPromocionObsequioProducto.Rows(index).Item("Cantidad")
        'If Descuento <= cantidad Then
        TablaPromocionObsequioProducto.Rows(index).Item("Cantidad") = _Cantidad
        TablaPromocionObsequioProducto.AcceptChanges()
    End Sub
    Protected Sub DDOpcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDOpcion.SelectedIndexChanged
        If DDOpcion.SelectedValue = 2 Then
            TipoMontoPorcentaje = 1
            TBMonto.Text = 100
        Else
            TipoMontoPorcentaje = IIf(DDOpcion.SelectedValue = 0, 1, 0)
        End If
        Session("TipoMontoPorcentaje") = TipoMontoPorcentaje
    End Sub
End Class

