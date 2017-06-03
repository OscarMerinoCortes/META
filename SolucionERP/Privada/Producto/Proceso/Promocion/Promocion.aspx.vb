Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Drawing
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Imports System.Math

Partial Class _Default
    Inherits Page
    Public TablaProducto As New DataTable()
    Public VistaProducto As New DataView()

    Public TablaPromocionDetalle As New DataTable()
    Public VistaPromocionDetalle As New DataView()

    Public TablaActualizar As New DataTable()
    Public VistaTablaActualizar As New DataView()

    Public TablaRegistro As New DataTable()
    Public VistaTablaRegistro As New DataView()

    Public TablaSucursal As New DataTable()
    Public VistaTablaSucursal As New DataView()

    Public EstadoActualizar As New Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Descuentos"
            Dim EstadoActualizar As Integer = 0
            Session("EstadoActualizar") = EstadoActualizar
            BTNAgregar.Visible = False
            BTNQuitar.Visible = False
            BTNCalcular.Visible = False
            BTNRedondeo.Visible = False
            IBTCopiar.Visible = False
            TBFechaInicio.Text = Now.Date
            TBFechaFin.Text = Now.Date
            TBDescuento.Text = 0
            TBGracia.Text = 0
            TBExtra.Text = 0
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            wucDatosAuditoria1.Visible = False
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
            consultar()

            DDGracia.Items.Add(New ListItem("MES(es)", 1))
            DDGracia.Items.Add(New ListItem("DIA(s)", 0))
            DDGracia.SelectedValue = 1

            DDExtra.Items.Add(New ListItem("MES(es)", 1))
            DDExtra.Items.Add(New ListItem("DIA(s)", 0))
            DDExtra.SelectedValue = 1

            DDDescuento.Items.Add(New ListItem("PORCENTAJE", 1))
            DDDescuento.Items.Add(New ListItem("MONTO", 0))
            DDDescuento.SelectedValue = 1

            Dim NegocioSucursal = New Negocio.Sucursal()
            Dim EntidadSucursal = New Entidad.Sucursal()
            EntidadSucursal.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioSucursal.Consultar(EntidadSucursal)
            DDSucursal.DataSource = EntidadSucursal.TablaConsulta
            DDSucursal.DataValueField = "ID"
            DDSucursal.DataTextField = "Descripcion"
            DDSucursal.DataBind()
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

            TablaProducto.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Existencia", System.Type.GetType("System.String")))
            TablaProducto.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaProducto = TablaProducto.DefaultView
            Session("TablaProducto") = TablaProducto
            Session("VistaProducto") = VistaProducto

            TablaPromocionDetalle.Columns.Add(New DataColumn("IdPromocionDetalle", System.Type.GetType("System.String")))
            TablaPromocionDetalle.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaPromocionDetalle.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaPromocionDetalle.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaPromocionDetalle.Columns.Add(New DataColumn("Descuento", System.Type.GetType("System.String")))
            TablaPromocionDetalle.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaPromocionDetalle.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaPromocionDetalle = TablaPromocionDetalle.DefaultView
            Session("TablaPromocionDetalle") = TablaPromocionDetalle
            Session("VistaPromocionDetalle") = VistaPromocionDetalle

            TablaRegistro.Columns.Add(New DataColumn("IdPromocionDetalle", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("Descuento", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaRegistro.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))
            VistaTablaRegistro = TablaRegistro.DefaultView
            Session("TablaRegistro") = TablaRegistro
            Session("VistaTablaRegistro") = VistaTablaRegistro

            TablaSucursal.Columns.Add(New DataColumn("IdPromocionSucursal", System.Type.GetType("System.String")))
            TablaSucursal.Columns.Add(New DataColumn("IdPromocion", System.Type.GetType("System.String")))
            TablaSucursal.Columns.Add(New DataColumn("IdSucursal", System.Type.GetType("System.String")))
            TablaSucursal.Columns.Add(New DataColumn("NombreSucursal", System.Type.GetType("System.String")))
            VistaTablaSucursal = TablaSucursal.DefaultView
            Session("TablaSucursal") = TablaSucursal
            Session("VistaTablaSucursal") = VistaTablaSucursal
            '----- TABLA GV DE SUCURSALES ---
            GVSucursal.Columns.Clear()
            GVSucursal.DataSource = TablaSucursal
            GVSucursal.AutoGenerateColumns = False
            GVSucursal.AllowSorting = True
            Dim Columna1 As New CommandField()
            Columna1.HeaderText = ""
            Columna1.HeaderText = "Seleccionar"
            Columna1.SelectText = "Seleccionar"
            Columna1.ButtonType = ButtonType.Link
            Columna1.ShowSelectButton = True
            GVSucursal.Columns.Add(Columna1)

            Comun.Presentacion.Cuadricula.AgregarColumna(GVSucursal, New BoundField(), "Sucursal", "NombreSucursal")
            GVSucursal.DataBind()
            divGVProducto.Visible = False
        Else
            TablaProducto = Session("TablaProductos")
            TablaPromocionDetalle = Session("TablaPromocionDetalle")
            TablaRegistro = Session("TablaRegistro")
            EstadoActualizar = Session("EstadoActualizar")
            'If CBGracia.Checked = False Then
            '    TBGracia.Text = "0"
            'End If
            'If CBExtra.Checked = False Then
            '    TBExtra.Text = "0"
            'End If
            'If DDGracia.SelectedValue = 0 Then
            '    TBGracia.Text = "0"
            'End If
            'If DDExtra.SelectedValue = 0 Then
            '    TBGracia.Text = "0"
            'End If
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
    Public Sub limpiar()
        Dim EntidadPromocion = New Entidad.Promocion()
        EntidadPromocion.EstadoActualizar = 0
        TablaProducto = Session("TablaProducto")
        TablaPromocionDetalle = Session("TablaPromocionDetalle")
        TablaRegistro = Session("TablaRegistro")
        EstadoActualizar = Session("EstadoActualizar")
        MultiView1.SetActiveView(VRegistro)
        TBIdPromocion.Text = ""
        TBDescripcion.Text = ""
        TBFechaInicio.Text = ""
        TBFechaFin.Text = ""
        TBObservacion.Text = ""
        TBFechaInicio.Text = Now.Date
        TBFechaFin.Text = Now.Date
        TBDescuento.Text = 0
        TBGracia.Text = 0
        TBExtra.Text = 0
        'CBGracia.Checked = True
        DDGracia.SelectedValue = 1
        DDExtra.SelectedValue = 1
        DDDescuento.SelectedValue = 1
        'CBExtra.Checked = True
        'CBDescuento.Checked = True
        GVProducto.DataSource = Nothing
        GVProducto.Visible = False
        GVProductoDetalle.DataSource = Nothing
        GVProductoDetalle.Visible = False
        BTNQuitar.Visible = False
        BTNAgregar.Visible = False
        BTNRedondeo.Visible = False
        BTNCalcular.Visible = False
        TablaActualizar.Clear()
        TablaProducto.Clear()
        TablaPromocionDetalle.Clear()
        TablaRegistro.Clear()
        EstadoActualizar = 0
        Session("TablaPromocionDetalle") = TablaPromocionDetalle
        Session("TablaProducto") = TablaProducto
        Session("TablaRegistro") = TablaRegistro
        Session("EstadoActualizar") = EstadoActualizar
        EntidadPromocion.EstadoActualizar = 0
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        DDClasificacion.SelectedValue = -1
        ConsultaSubclasificaciones()
        IBTCopiar.Visible = False
        IBTGuardar.Visible = True

        TablaSucursal = Session("TablaSucursal")
        GVSucursal.DataSource = Nothing
        GVSucursal.Visible = False
        TablaSucursal.Clear()
        Session("TablaSucursal") = TablaSucursal
        divGVProducto.Visible = False
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        limpiar()
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        BTNQuitar.Visible = False
        BTNAgregar.Visible = False
        BTNRedondeo.Visible = False
        BTNCalcular.Visible = False
        Dim NegocioPromocion As New Negocio.Promocion()
        Dim EntidadPromocion As New Entidad.Promocion()
        TablaPromocionDetalle = Session("TablaPromocionDetalle")
        TablaRegistro = Session("TablaRegistro")
        EstadoActualizar = Session("EstadoActualizar")
        If TablaPromocionDetalle.Rows.Count = 0 Then
            Exit Sub
        End If

        If TablaPromocionDetalle.Rows.Count = 0 Then
            Exit Sub
        End If
        If TBIdPromocion.Text Is String.Empty Then
            EntidadPromocion.IdPromocion = 0
        Else
            EntidadPromocion.IdPromocion = CInt(TBIdPromocion.Text)
        End If
        EntidadPromocion.TipoPromocion = 1
        If TBDescripcion.Text Is String.Empty Then
            EntidadPromocion.Descripcion = "SIN DESCRIPCION"
        Else
            EntidadPromocion.Descripcion = TBDescripcion.Text
        End If
        If TBGracia.Text Is String.Empty Then
            EntidadPromocion.Gracia = 0
        Else
            EntidadPromocion.Gracia = CInt(TBGracia.Text)
        End If
        If TBExtra.Text Is String.Empty Then
            EntidadPromocion.Extra = 0
        Else
            EntidadPromocion.Extra = CInt(TBExtra.Text)
        End If
        If TBDescuento.Text Is String.Empty Then
            EntidadPromocion.Descuento = 0
        Else
            EntidadPromocion.Descuento = CDbl(TBDescuento.Text)
        End If

        If TBObservacion.Text Is String.Empty Then
            EntidadPromocion.Observacion = "SIN OBSERVACION"
        Else
            EntidadPromocion.Observacion = TBObservacion.Text
        End If

        If TBFechaInicio.Text Is String.Empty Then
            EntidadPromocion.FechaInicio = "01/01/1990"
        Else
            EntidadPromocion.FechaInicio = TBFechaInicio.Text
        End If
        If TBFechaFin.Text Is String.Empty Then
            EntidadPromocion.FechaFin = "01/01/1990"
        Else
            EntidadPromocion.FechaFin = TBFechaFin.Text
        End If
        'EntidadPromocion.TipoGracia = IIf(CBGracia.Checked = True, 1, 0)
        EntidadPromocion.TipoGracia = IIf(DDGracia.SelectedValue = 1, 1, 0)
        'EntidadPromocion.TipoExtra = IIf(CBExtra.Checked = True, 1, 0)
        EntidadPromocion.TipoExtra = IIf(DDExtra.SelectedValue = 1, 1, 0)
        'EntidadPromocion.TipoDescuento = IIf(CBDescuento.Checked, 1, 0)
        EntidadPromocion.TipoDescuento = IIf(DDDescuento.SelectedValue = 1, 1, 0)
        EntidadPromocion.IdEstado = CInt(DDEstado.SelectedValue)
        TablaSucursal = Session("TablaSucursal")
        EntidadPromocion.IndicadorEstado = 1
        EntidadPromocion.TablaSucursal = TablaSucursal

        EntidadPromocion.TablaPromocionDetalle = TablaPromocionDetalle
        NegocioPromocion.Guardar(EntidadPromocion)
        If EstadoActualizar = 1 Then
            EntidadPromocion.IndicadorEstado = 2
            EntidadPromocion.TablaPromocionDetalle = TablaRegistro
            EntidadPromocion.TablaSucursal = TablaSucursal
            NegocioPromocion.Guardar(EntidadPromocion)
        End If
        TBIdPromocion.Text = EntidadPromocion.IdPromocion.ToString()

    End Sub
    Public Sub consultar()
        MultiView1.SetActiveView(VConsulta)
        Dim NegocioPromocion As New Negocio.Promocion()
        Dim EntidadPromocion As New Entidad.Promocion()
        Dim TablaTemporal As New DataTable
        Dim Tabla As New DataTable
        EntidadPromocion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioPromocion.Consultar(EntidadPromocion)
        Tabla = EntidadPromocion.TablaConsulta
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
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDescuento, New BoundField(), "Id Promocion", "IdPromocion")
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
        IBTGuardar.Visible = False
        IBTCopiar.Visible = False

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
    Protected Sub CBGVPromocionItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub IBTSalir_Click(sender As Object, e As ImageClickEventArgs) Handles IBTSalir.Click
        Response.Redirect("~\Default.aspx")
    End Sub


    Protected Sub DDClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDClasificacion.SelectedIndexChanged
        ConsultaSubclasificaciones()
    End Sub

    Protected Sub BTNConsultarProducto_Click(sender As Object, e As EventArgs) Handles BTNConsultarProducto.Click
        ConsultaProducto()
        divGVProducto.Visible = True
    End Sub
    Private Sub ConsultaProducto()
        GVProducto.DataSource = Nothing
        GVProductoDetalle.DataSource = Nothing
        Dim NegocioPromocion As New Negocio.Promocion()
        Dim EntidadPromocion As New Entidad.Promocion()
        Dim TablaProductos As New DataTable()
        EntidadPromocion.IdClasificacion = DDClasificacion.SelectedValue
        EntidadPromocion.IdSubClasificacion = DDSubclasificacion.SelectedValue
        EntidadPromocion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioPromocion.Consultar(EntidadPromocion)
        TablaProductos = EntidadPromocion.TablaConsulta
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
    End Sub
#End Region
    Protected Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click
        Dim EntidadPromocion As New Entidad.Promocion()
        TablaProducto = Session("TablaProducto")
        TablaPromocionDetalle = Session("TablaPromocionDetalle")
        TablaActualizar = Session("TablaActualizar")
        BTNQuitar.Visible = True

        Dim RenglonAInsertar As DataRow
        'Dim RenglonAInsertarActualizar As DataRow
        Dim Index As Integer

        For Each MiDataRow As GridViewRow In GVProducto.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            If CType(MiDataRow.FindControl("CBGVPromocionItem"), CheckBox).Checked = True Then
                'Validar que el producto serleccionado ya no este en la lista de promocion detalle
                Dim validar = 0
                For Each RowValidar As DataRow In TablaPromocionDetalle.Rows
                    If RowValidar.Item("IdProducto") = TablaProducto.Rows(Index).Item("IdProducto") Then
                        validar = 1
                    End If
                Next
                If validar = 0 Then
                    RenglonAInsertar = TablaPromocionDetalle.NewRow()
                    RenglonAInsertar("IdPromocionDetalle") = 0
                    RenglonAInsertar("IdProducto") = TablaProducto.Rows(Index).Item("IdProducto")
                    RenglonAInsertar("IdProductoCorto") = TablaProducto.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertar("Descripcion") = TablaProducto.Rows(Index).Item("Descripcion")
                    RenglonAInsertar("Descuento") = IIf(DDDescuento.SelectedValue = 1, (TablaProducto.Rows(Index).Item("PrecioBase")) - (CDbl(TBDescuento.Text) / 100 * TablaProducto.Rows(Index).Item("PrecioBase")), (TablaProducto.Rows(Index).Item("PrecioBase")) - (CDbl(TBDescuento.Text)))
                    RenglonAInsertar("PrecioBase") = TablaProducto.Rows(Index).Item("PrecioBase")
                    RenglonAInsertar("Estado") = TablaProducto.Rows(Index).Item("Estado")
                    TablaPromocionDetalle.Rows.Add(RenglonAInsertar)
                End If
            End If
        Next
        If TablaPromocionDetalle.Rows.Count > 0 Then
            GVProductoDetalle.DataSource = TablaPromocionDetalle
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
                Dim NuevoRow As DataRow = TablaPromocionDetalle.NewRow()
                CType(MiDataRow2.FindControl("TBGVPrecioDescuento"), TextBox).Text = TablaPromocionDetalle.Rows(Index).Item("Descuento")
            Next

            Session("TablaProducto") = TablaProducto
        End If
        Session("TablaPromocionDetalle") = TablaPromocionDetalle
        BTNQuitar.Visible = True
        BTNCalcular.Visible = True
        BTNRedondeo.Visible = True
    End Sub
    'Protected Sub GVProducto_RowDataBound(sender As Object, e As GridViewRowEventArgs)
    '    If e.Row.RowType = DataControlRowType.Header Then
    '        e.Row.TableSection = TableRowSection.TableHeader
    '    End If
    'End Sub
    Protected Sub BTNQuitar_Click(sender As Object, e As EventArgs) Handles BTNQuitar.Click
        Dim EntidadPromocion As New Entidad.Promocion()
        Dim EstadoActualizar As Integer
        EstadoActualizar = Session("EstadoActualizar")
        If GVProducto.Rows.Count > 0 Then
            BTNAgregar.Visible = True
        End If
        If EstadoActualizar = 0 Then
            TablaPromocionDetalle = Session("TablaPromocionDetalle") 'tiene todos producto detalle
            Dim TablaActualizacion As New DataTable()
            TablaActualizacion.Columns.Add(New DataColumn("IdPromocionDetalle", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Descuento", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))

            Dim RenglonAInsertarActualizar As DataRow
            Dim Index As Integer
            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True Then
                Else
                    RenglonAInsertarActualizar = TablaActualizacion.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionDetalle") = TablaPromocionDetalle.Rows(Index).Item("IdPromocionDetalle")
                    RenglonAInsertarActualizar("IdProducto") = TablaPromocionDetalle.Rows(Index).Item("IdProducto")
                    RenglonAInsertarActualizar("IdProductoCorto") = TablaPromocionDetalle.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertarActualizar("Descripcion") = TablaPromocionDetalle.Rows(Index).Item("Descripcion")
                    RenglonAInsertarActualizar("Descuento") = TablaPromocionDetalle.Rows(Index).Item("Descuento")
                    RenglonAInsertarActualizar("PrecioBase") = TablaPromocionDetalle.Rows(Index).Item("PrecioBase")
                    RenglonAInsertarActualizar("Estado") = TablaPromocionDetalle.Rows(Index).Item("Estado")
                    TablaActualizacion.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next

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
                CType(MiDataRow2.FindControl("TBGVPrecioDescuento"), TextBox).Text = TablaActualizacion.Rows(Index).Item("Descuento")
            Next
            TablaPromocionDetalle = TablaActualizacion
            'Session("TablaProducto") = TablaProducto
            Session("TablaPromocionDetalle") = TablaPromocionDetalle
        Else
            TablaPromocionDetalle = Session("TablaPromocionDetalle") 'tiene todos producto detalle
            TablaRegistro = Session("TablaRegistro")
            Dim TablaActualizacion As New DataTable()
            TablaActualizacion.Columns.Add(New DataColumn("IdPromocionDetalle", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProducto", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("IdProductoCorto", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Descripcion", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Descuento", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("PrecioBase", System.Type.GetType("System.String")))
            TablaActualizacion.Columns.Add(New DataColumn("Estado", System.Type.GetType("System.String")))

            Dim RenglonAInsertarActualizar As DataRow
            Dim RenglonAInsertarActualizar2 As DataRow
            Dim Index As Integer
            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVPromocionDetalleItem"), CheckBox).Checked = True Then
                    RenglonAInsertarActualizar2 = TablaRegistro.NewRow()
                    If TablaPromocionDetalle.Rows(Index).Item("IdPromocionDetalle") = 0 Then
                    Else
                        RenglonAInsertarActualizar2("IdPromocionDetalle") = TablaPromocionDetalle.Rows(Index).Item("IdPromocionDetalle")
                        RenglonAInsertarActualizar2("IdProducto") = TablaPromocionDetalle.Rows(Index).Item("IdProducto")
                        RenglonAInsertarActualizar2("IdProductoCorto") = TablaPromocionDetalle.Rows(Index).Item("IdProductoCorto")
                        RenglonAInsertarActualizar2("Descripcion") = TablaPromocionDetalle.Rows(Index).Item("Descripcion")
                        RenglonAInsertarActualizar2("Descuento") = TablaPromocionDetalle.Rows(Index).Item("Descuento")
                        RenglonAInsertarActualizar2("PrecioBase") = TablaPromocionDetalle.Rows(Index).Item("PrecioBase")
                        RenglonAInsertarActualizar2("Estado") = "INACTIVO"
                        TablaRegistro.Rows.Add(RenglonAInsertarActualizar2)
                    End If
                Else
                    RenglonAInsertarActualizar = TablaActualizacion.NewRow() 'datos que no se selccionaron
                    RenglonAInsertarActualizar("IdPromocionDetalle") = TablaPromocionDetalle.Rows(Index).Item("IdPromocionDetalle")
                    RenglonAInsertarActualizar("IdProducto") = TablaPromocionDetalle.Rows(Index).Item("IdProducto")
                    RenglonAInsertarActualizar("IdProductoCorto") = TablaPromocionDetalle.Rows(Index).Item("IdProductoCorto")
                    RenglonAInsertarActualizar("Descripcion") = TablaPromocionDetalle.Rows(Index).Item("Descripcion")
                    RenglonAInsertarActualizar("Descuento") = TablaPromocionDetalle.Rows(Index).Item("Descuento")
                    RenglonAInsertarActualizar("PrecioBase") = TablaPromocionDetalle.Rows(Index).Item("PrecioBase")
                    RenglonAInsertarActualizar("Estado") = TablaPromocionDetalle.Rows(Index).Item("Estado")
                    TablaActualizacion.Rows.Add(RenglonAInsertarActualizar)
                End If
            Next

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
                CType(MiDataRow2.FindControl("TBGVPrecioDescuento"), TextBox).Text = TablaActualizacion.Rows(Index).Item("Descuento")
            Next
            TablaPromocionDetalle = TablaActualizacion
            'Session("TablaProducto") = TablaProducto
            Session("TablaPromocionDetalle") = TablaPromocionDetalle
            'TablaRegistro = TablaActualizacion2
            Session("TablaRegistro") = TablaRegistro
        End If
    End Sub

    Protected Sub GVDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVDescuento.SelectedIndexChanged
        IBTCopiar.Visible = True
        IBTGuardar.Visible = True
        BTNQuitar.Visible = True
        BTNRedondeo.Visible = True
        BTNCalcular.Visible = True
        Dim NegocioPromocion As New Negocio.Promocion()
        Dim EntidadPromocion As New Entidad.Promocion()
        Dim EstadoActualizar As Integer = 1
        Session("EstadoActualizar") = EstadoActualizar
        Dim Tabla As New DataTable
        TablaPromocionDetalle = Session("TablaPromocionDetalle")
        TablaSucursal = Session("TablaSucursal")
        VistaTablaSucursal = Session("VistaTablaSucursal")
        Tabla = Session("Tabla")
        TBIdPromocion.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("IdPromocion")
        TBDescripcion.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Descripcion")
        TBGracia.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Gracia")
        TBExtra.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Extra")
        TBDescuento.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Descuento")
        TBObservacion.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("Observacion")
        TBFechaInicio.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("FechaInicio")
        TBFechaFin.Text = Tabla.Rows(GVDescuento.SelectedIndex).Item("FechaFin")
        'CBGracia.Checked = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoGracia") = "1", True, False)
        'CBExtra.Checked = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoExtra") = "1", True, False)
        'CBDescuento.Checked = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoDescuento") = "1", True, False)
        DDGracia.SelectedValue = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoGracia") = "1", 1, 0)
        DDExtra.SelectedValue = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoExtra") = "1", 1, 0)
        DDDescuento.SelectedValue = IIf(Tabla.Rows(GVDescuento.SelectedIndex).Item("TipoDescuento") = "1", 1, 0)

        DDEstado.SelectedValue = Tabla.Rows(GVDescuento.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVDescuento.SelectedIndex))
        MultiView1.SetActiveView(VRegistro)

        EntidadPromocion.IdPromocion = Tabla.Rows(GVDescuento.SelectedIndex).Item("IdPromocion")
        EntidadPromocion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioPromocion.Consultar(EntidadPromocion)
        'Detalles
        Tabla = EntidadPromocion.TablaConsulta
        'GVDescuento.Columns.Clear()
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
        For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
            index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = Tabla.NewRow()
            CType(MiDataRow2.FindControl("TBGVPrecioDescuento"), TextBox).Text = Tabla.Rows(index).Item("TBGVPrecioDescuento")
        Next

        Dim Index2 As Integer
        Dim RenglonAInsertarActualizar As DataRow
        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            Index2 = Convert.ToUInt64(MiDataRow.RowIndex)
            RenglonAInsertarActualizar = TablaPromocionDetalle.NewRow() 'datos que no se selccionaron
            RenglonAInsertarActualizar("IdPromocionDetalle") = Tabla.Rows(Index2).Item("IdPromocionDetalle")
            RenglonAInsertarActualizar("IdProducto") = Tabla.Rows(Index2).Item("IdProducto")
            RenglonAInsertarActualizar("IdProductoCorto") = Tabla.Rows(Index2).Item("IdProductoCorto")
            RenglonAInsertarActualizar("Descripcion") = Tabla.Rows(Index2).Item("Descripcion")
            RenglonAInsertarActualizar("Descuento") = Tabla.Rows(Index2).Item("TBGVPrecioDescuento")
            RenglonAInsertarActualizar("PrecioBase") = Tabla.Rows(Index2).Item("PrecioBase")
            RenglonAInsertarActualizar("Estado") = Tabla.Rows(Index2).Item("Estado")
            TablaPromocionDetalle.Rows.Add(RenglonAInsertarActualizar)
        Next

        EntidadPromocion.IndicadorConsulta = 3
        NegocioPromocion.Consultar(EntidadPromocion)
        Tabla = EntidadPromocion.TablaConsulta
        GVSucursal.DataSource = Tabla
        Dim Columna22 As New CommandField()
        Columna22.HeaderText = ""
        Columna22.ButtonType = ButtonType.Link
        Columna22.ShowSelectButton = True
        GVSucursal.AutoGenerateColumns = False
        GVSucursal.AllowSorting = True
        GVSucursal.DataBind()
        GVSucursal.Visible = True
        TablaSucursal = Tabla
        Session("TablaSucursal") = TablaSucursal
        VistaTablaSucursal = Tabla.DefaultView
        Session("VistaTablaSucursal") = VistaTablaSucursal
        Session("TablaPromocionDetalle") = TablaPromocionDetalle
        divGVProducto.Visible = False
    End Sub

    
    Private Sub calcular()
        If GVProductoDetalle.Rows.Count > 0 Then
            Dim EntidadPromocion As New Entidad.Promocion()
            Dim index As Integer
            TablaPromocionDetalle = Session("TablaPromocionDetalle")
            For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim Base As Double = CDbl(MiDataRow2.Cells.Item(4).Text.ToString())
                CType(MiDataRow2.FindControl("TBGVPrecioDescuento"), TextBox).Text = IIf(DDDescuento.SelectedValue = 1, Base - (CDbl(TBDescuento.Text) / 100 * Base), Base - (TBDescuento.Text))
            Next

            'Dim RenglonAInsertar As DataRow


            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                index = Convert.ToUInt64(MiDataRow.RowIndex)
                Dim base As Double = CDbl(MiDataRow.Cells.Item(4).Text.ToString())
                TablaPromocionDetalle.Rows(index).Item("Descuento") = IIf(DDDescuento.SelectedValue = 1, base - (CDbl(TBDescuento.Text) / 100 * base), base - (TBDescuento.Text))
            Next
            Session("TablaPromocionDetalle") = TablaPromocionDetalle
        End If
    End Sub
    Protected Sub BTNCalcular_Click(sender As Object, e As EventArgs) Handles BTNCalcular.Click
        calcular()
    End Sub
    Private Sub redondeo()
        If GVProductoDetalle.Rows.Count > 0 Then
            Dim EntidadPromocion As New Entidad.Promocion()
            Dim index As Integer
            TablaPromocionDetalle = Session("TablaPromocionDetalle")
            EntidadPromocion.Descuento = TBDescuento.Text
            For Each MiDataRow2 As GridViewRow In GVProductoDetalle.Rows
                index = Convert.ToUInt64(MiDataRow2.RowIndex)
                Dim Base As Double = CDbl(MiDataRow2.Cells.Item(4).Text.ToString())
                CType(MiDataRow2.FindControl("TBGVPrecioDescuento"), TextBox).Text = Round(IIf(DDDescuento.SelectedValue = 1, Base - (CDbl(TBDescuento.Text) / 100 * Base), Base - (TBDescuento.Text)))
            Next

            For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
                index = Convert.ToUInt64(MiDataRow.RowIndex)
                Dim base As Double = CDbl(MiDataRow.Cells.Item(4).Text.ToString())
                TablaPromocionDetalle.Rows(index).Item("Descuento") = Round(IIf(DDDescuento.SelectedValue = 1, base - (CDbl(TBDescuento.Text) / 100 * base), base - (TBDescuento.Text)))
            Next
            Session("TablaPromocionDetalle") = TablaPromocionDetalle
        End If
    End Sub
    Protected Sub BTNRedondeo_Click(sender As Object, e As EventArgs) Handles BTNRedondeo.Click
        redondeo()
    End Sub

    Protected Sub IBTCopiar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCopiar.Click
        BTNQuitar.Visible = False
        BTNAgregar.Visible = False
        BTNRedondeo.Visible = False
        BTNCalcular.Visible = False
        Dim NegocioPromocion As New Negocio.Promocion()
        Dim EntidadPromocion As New Entidad.Promocion()
        TablaPromocionDetalle = Session("TablaPromocionDetalle")

        Dim index As Integer
        For Each MiDataRow As GridViewRow In GVProductoDetalle.Rows
            index = Convert.ToUInt64(MiDataRow.RowIndex)
            TablaPromocionDetalle.Rows(index).Item("IdPromocionDetalle") = 0
        Next
        TablaRegistro = Session("TablaRegistro")
        EntidadPromocion.IdPromocion = 0
        EntidadPromocion.TipoPromocion = 1
        If TBDescripcion.Text Is String.Empty Then
            EntidadPromocion.Descripcion = "SIN DESCRIPCION"
        Else
            EntidadPromocion.Descripcion = TBDescripcion.Text
        End If
        If TBGracia.Text Is String.Empty Then
            EntidadPromocion.Gracia = 0
        Else
            EntidadPromocion.Gracia = CInt(TBGracia.Text)
        End If
        If TBExtra.Text Is String.Empty Then
            EntidadPromocion.Extra = 0
        Else
            EntidadPromocion.Extra = CInt(TBExtra.Text)
        End If
        If TBDescuento.Text Is String.Empty Then
            EntidadPromocion.Descuento = 0
        Else
            EntidadPromocion.Descuento = CDbl(TBDescuento.Text)
        End If

        If TBObservacion.Text Is String.Empty Then
            EntidadPromocion.Observacion = "SIN OBSERVACION"
        Else
            EntidadPromocion.Observacion = TBObservacion.Text
        End If

        If TBFechaInicio.Text Is String.Empty Then
            EntidadPromocion.FechaInicio = "01/01/1990"
        Else
            EntidadPromocion.FechaInicio = TBFechaInicio.Text
        End If
        If TBFechaFin.Text Is String.Empty Then
            EntidadPromocion.FechaFin = "01/01/1990"
        Else
            EntidadPromocion.FechaFin = TBFechaFin.Text
        End If
        'EntidadPromocion.TipoGracia = IIf(CBGracia.Checked = True, 1, 0)
        EntidadPromocion.TipoGracia = IIf(DDGracia.SelectedValue = 1, 1, 0)
        'EntidadPromocion.TipoExtra = IIf(CBExtra.Checked = True, 1, 0)
        EntidadPromocion.TipoExtra = IIf(DDExtra.SelectedValue = 1, 1, 0)
        'EntidadPromocion.TipoDescuento = IIf(CBDescuento.Checked, 1, 0)
        EntidadPromocion.TipoDescuento = IIf(DDDescuento.SelectedValue = 1, 1, 0)
        EntidadPromocion.IdEstado = CInt(DDEstado.SelectedValue)

        TablaSucursal = Session("TablaSucursal")
        EntidadPromocion.IndicadorEstado = 1

        For Each MiDataRow As GridViewRow In GVSucursal.Rows
            index = Convert.ToUInt64(MiDataRow.RowIndex)
            TablaSucursal.Rows(index).Item("IdPromocionSucursal") = 0
        Next
        EntidadPromocion.TablaSucursal = TablaSucursal

       
        EntidadPromocion.TablaPromocionDetalle = TablaPromocionDetalle
        NegocioPromocion.Guardar(EntidadPromocion)
        TBIdPromocion.Text = EntidadPromocion.IdPromocion.ToString()
    End Sub

    Protected Sub BTNuevaSucursal_Click(sender As Object, e As EventArgs) Handles BTNuevaSucursal.Click
        PASucursal.Visible = True
        BTNEliminarSucursal.Visible = False
    End Sub

    Protected Sub BTNAceptarSucursal_Click(sender As Object, e As EventArgs) Handles BTNAceptarSucursal.Click
        TablaSucursal = Session("TablaSucursal")
        VistaTablaSucursal = Session("VistaTablaSucursal")
        EstadoActualizar = Session("EstadoActualizar")
        'If EstadoActualizar = 1 Then
        '    VistaTablaSucursal = TablaSucursal
        'End If

        Dim bandera As Boolean = True

        For Each fila As DataRow In TablaSucursal.Rows
            If fila.Item("IdSucursal").ToString() = DDSucursal.SelectedValue.ToString() Then
                bandera = False
                Exit For
            End If
        Next

        If bandera Then
            Dim Renglon As DataRow
            Renglon = TablaSucursal.NewRow
            Renglon("IdPromocionSucursal") = 0
            Renglon("IdPromocion") = 0 'Int32.Parse(TBIdPromocion.Text)
            Renglon("IdSucursal") = DDSucursal.SelectedValue
            Renglon("NombreSucursal") = DDSucursal.SelectedItem

            TablaSucursal.Rows.Add(Renglon)

            Session("TablaSucursal") = TablaSucursal
            Session("VistaTablaSucursal") = VistaTablaSucursal
            GVSucursal.DataSource = VistaTablaSucursal
            GVSucursal.DataBind()

            PASucursal.Visible = False
            GVSucursal.Visible = True
        End If
    End Sub

    Protected Sub BTNEliminarSucursal_Click(sender As Object, e As EventArgs) Handles BTNEliminarSucursal.Click
        TablaSucursal = Session("TablaSucursal")
        VistaTablaSucursal = Session("VistaTablaSucursal")
        EstadoActualizar = Session("EstadoActualizar")

        Dim Renglon As Integer = GVSucursal.SelectedIndex
        'If EstadoActualizar = 1 Then
        '    VistaTablaSucursal = TablaSucursal
        'End If
        If VistaTablaSucursal(Renglon).Item("Idsucursal") = DDSucursal.SelectedValue Then
            VistaTablaSucursal(Renglon).Delete()
            'Else
            '    VistaTablaSucursal(Renglon).Item("idActualizar") = 1 'Si   
            '    VistaIdentificacion(Renglon).Item("IdEstado") = 2 'Cancelar <--la linea de cambio de idEstado al final de la actualizacion de todos los campos, de lo contrario marca error
        End If

        If EstadoActualizar = 1 Then
            TablaSucursal = VistaTablaSucursal.ToTable
            VistaTablaSucursal = TablaSucursal.DefaultView
        End If
        Session("TablaSucursal") = TablaSucursal
        Session("VistaTablaSucursal") = VistaTablaSucursal
        GVSucursal.DataSource = VistaTablaSucursal
        GVSucursal.DataBind()
        PASucursal.Visible = False
        GVSucursal.Visible = True
    End Sub

    Protected Sub GVSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSucursal.SelectedIndexChanged
        PASucursal.Visible = True
        BTNEliminarSucursal.Visible = True
        Dim TablaIdentificacion As New DataTable
        TablaSucursal = Session("TablaSucursal")
        DDSucursal.SelectedValue = TablaSucursal.Rows(GVSucursal.SelectedIndex).Item("IdSucursal")
        PASucursal.Visible = True
        GVSucursal.Visible = False
    End Sub

    Protected Sub BTNRedondeo0_Click(sender As Object, e As EventArgs) Handles BTNRedondeo0.Click
        redondeo()
    End Sub

    Protected Sub BTNCalcular2_Click(sender As Object, e As EventArgs) Handles BTNCalcular2.Click
        calcular()
    End Sub

    Protected Sub GVProducto_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVProducto.PageIndexChanging
        GVProducto.PageIndex = e.NewPageIndex
        ConsultaProducto()
    End Sub
    Protected Sub GVIPrecio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        TablaPromocionDetalle = CType(Session("TablaPromocionDetalle"), DataTable)
        Dim TBDescuento As TextBox = CType(sender, TextBox)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBDescuento.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim TBDescuento1 As TextBox = CType(sender, TextBox)

        If IsNumeric(TBDescuento1.Text) Then
            actualizarrenglon(TablaPromocionDetalle, index, TBDescuento1.Text)
        Else
            Dim MiDataRow As GridViewRow = GVProductoDetalle.Rows(index)
            Dim NuevoRow As DataRow = TablaPromocionDetalle.NewRow()
            CType(MiDataRow.FindControl("TBGVPrecioDescuento"), TextBox).Text = TablaPromocionDetalle.Rows(index).Item("Descuento")
        End If
        Session("TablaPromocionDetalle") = TablaPromocionDetalle
    End Sub
    Private Sub actualizarrenglon(ByRef TablaPromocionDetalle As DataTable, ByVal index As Integer, ByVal Descuento As Double)
        Dim cantidad As Double = TablaPromocionDetalle.Rows(index).Item("Descuento")
        'If Descuento <= cantidad Then
        TablaPromocionDetalle.Rows(index).Item("Descuento") = Descuento
        TablaPromocionDetalle.AcceptChanges()
    End Sub
End Class