Imports System.Data
Partial Class _Default
    Inherits Page    
    Public TablaVentaDetalle As New DataTable
    Public TablaGarantiaDetalle As New DataTable
    Public TablaProductosGarantia As New DataTable
    Public Tabla As New DataTable
    Public Tabla2 As New DataTable
    Public Tabla3 As New DataTable
    Public Tabla4 As New DataTable
    Public VistaProductosGarantia As New DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Servicio y Garantia"
            'TablaProductosgarantia--------------------------------------------------------------------------------
            TablaProductosGarantia.Columns.Add(New DataColumn("IdGarantia", Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdGarantiaDetalle", Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdCliente", Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("Folio", Type.GetType("System.String")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdSucursal", Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("Telefono", Type.GetType("System.String")))
            TablaProductosGarantia.Columns.Add(New DataColumn("Falla", System.Type.GetType("System.String")))
            TablaProductosGarantia.Columns.Add(New DataColumn("Observacion", System.Type.GetType("System.String")))
            TablaProductosGarantia.Columns.Add(New DataColumn("Accesorios", System.Type.GetType("System.String")))
            TablaProductosGarantia.Columns.Add(New DataColumn("FechaEstimada", System.Type.GetType("System.DateTime")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdUsuarioCreacion", System.Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("FechaCreacion", System.Type.GetType("System.DateTime")))
            TablaProductosGarantia.Columns.Add(New DataColumn("IdUsuarioActualizacion", System.Type.GetType("System.Int32")))
            TablaProductosGarantia.Columns.Add(New DataColumn("FechaActualizacion", System.Type.GetType("System.DateTime")))
            VistaProductosGarantia = TablaProductosGarantia.DefaultView
            Session("TablaProductosGarantia") = TablaProductosGarantia
            Session("VistaProductosGarantia") = VistaProductosGarantia
            '-------------------------------------------------------------------------------------------------------
            CargarDropDownList()
            wucDatosAuditoria1.Visible = False
            SeleccionarView(0)
        End If      
    End Sub
    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub
    Public Sub CargarDropDownList()
        'DDSucursal...
        Dim NegocioSucursal = New Negocio.Sucursal()
        Dim EntidadSucursal As New Entidad.Sucursal()
        EntidadSucursal.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioSucursal.Consultar(EntidadSucursal)
        DDSucursalGarantia.DataSource = EntidadSucursal.TablaConsulta
        DDSucursalGarantia.DataValueField = "ID"
        DDSucursalGarantia.DataTextField = "Descripcion"
        DDSucursalGarantia.DataBind()
        DDSucursalGarantia.SelectedValue = 1
        'DDEstado...
        DDEstado.Items.Add(New ListItem("ACTIVO", 1))
        DDEstado.Items.Add(New ListItem("INACTIVO", 2))
        DDEstado.SelectedValue = 1
    End Sub
    Public Sub Limpiar()
        TBIdGarantia.Text = ""
        TBFolio.Text = ""
        TBTelefono.Text = ""
        TBFalla.Text = ""
        Tabla.Clear()
        Session("Tabla") = Tabla
        TablaGarantiaDetalle.Clear()
        Session("TablaGarantiaDetalle") = TablaGarantiaDetalle
        TablaVentaDetalle.Clear()
        Session("TablaVentaDetalle") = TablaVentaDetalle        
        TBObservacion.Text = ""
        TBAccesorios.Text = ""
        TBFechaEstimada.Text = ""        
        GVConsulta.DataSource = Nothing
        GVConsulta.DataBind()
        GVDetalleVenta.DataSource = Nothing
        GVDetalleVenta.DataBind()
        GVVenta.DataSource = Nothing
        GVVenta.DataBind()
        wucConsultarPersona.Visible = True
        wucConsultarPersona.Nuevo()
        GVDetalleVenta.Columns(0).Visible = True
    End Sub
    Public Sub Habilitar()
        GVDetalleVenta.Enabled = True
        BTNConsultar.Enabled = True        
    End Sub
    Public Sub Consultar()
        GVVenta.DataSource = Nothing
        GVVenta.DataBind()
        Dim NegocioGarantia As New Negocio.Garantia()
        Dim EntidadGarantia As New Entidad.Garantia()
        EntidadGarantia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioGarantia.Consultar(EntidadGarantia)
        Tabla2 = EntidadGarantia.TablaConsulta
        GVConsulta.Columns.Clear()
        GVConsulta.DataSource = Tabla2
        GVConsulta.AutoGenerateColumns = False
        GVConsulta.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsulta.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "ID", "IdGarantia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Cliente", "Cliente")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Falla", "Falla")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Estado", "Estado")
        GVConsulta.DataBind()
        Session("Tabla2") = Tabla2
    End Sub
    Public Sub ConsultarVentas()
        Tabla.Clear()
        Session("Tabla") = Tabla
        Dim NegocioGarantia As New Negocio.Garantia()
        Dim EntidadGarantia As New Entidad.Garantia()
        Dim IdCliente As Integer
        Dim Equivalencia As String
        Dim Nombre As String
        wucConsultarPersona.ObtenerPersona(IdCliente, Equivalencia, Nombre)
        EntidadGarantia.IdCliente = IdCliente
        EntidadGarantia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioGarantia.Consultar(EntidadGarantia)
        Tabla = EntidadGarantia.TablaConsulta
        GVVenta.Columns.Clear()
        GVVenta.DataSource = Tabla
        GVVenta.AutoGenerateColumns = False
        GVVenta.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVVenta.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVVenta, New BoundField(), "Folio", "Folio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVVenta, New BoundField(), "Producto", "Producto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVVenta, New BoundField(), "Fecha", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVVenta, New BoundField(), "Sucursal", "Sucursal")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVVenta, New BoundField(), "Total", "Total")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVVenta, New BoundField(), "Estado", "Estado")
        GVVenta.DataBind()
        Session("Tabla") = Tabla
    End Sub
    Public Sub VerificarCheckBox()
        Dim EntidadGarantia As New Entidad.Garantia()
        Dim RenglonAInsertar As DataRow
        Dim Index As Integer
        Dim TablaProductosGarantia = Session("TablaProductosGarantia")
        Dim TablaTemp = Session("TablaGarantiaDetalle")        
        Dim IdCliente As Integer
        Dim Equivalencia As String
        Dim Nombre As String       
        wucConsultarPersona.ObtenerPersona(IdCliente, Equivalencia, Nombre)
        EntidadGarantia.IdCliente = IdCliente
        For Each MiDataRow As GridViewRow In GVDetalleVenta.Rows
            Index = Convert.ToUInt64(MiDataRow.RowIndex)
            If CType(MiDataRow.FindControl("RDBTNVentaDetalleItem"), RadioButton).Checked = True Then
                RenglonAInsertar = TablaProductosGarantia.NewRow()
                If TBIdGarantia.Text Is String.Empty Then
                    RenglonAInsertar("IdGarantia") = 0
                Else
                    RenglonAInsertar("IdGarantia") = TBIdGarantia.Text
                End If
                RenglonAInsertar("IdGarantiaDetalle") = 0
                RenglonAInsertar("IdCliente") = EntidadGarantia.IdCliente
                RenglonAInsertar("IdProducto") = TablaTemp.Rows(Index).Item("IdProducto")
                RenglonAInsertar("Folio") = TBFolio.Text
                RenglonAInsertar("IdSucursal") = DDSucursalGarantia.SelectedValue
                RenglonAInsertar("Telefono") = TBTelefono.Text
                RenglonAInsertar("Falla") = TBFalla.Text
                RenglonAInsertar("Observacion") = TBObservacion.Text
                RenglonAInsertar("Accesorios") = TBAccesorios.Text
                If TBFechaEstimada.Text Is String.Empty Then
                    TBFechaEstimada.Text = Now
                    RenglonAInsertar("FechaEstimada") = TBFechaEstimada.Text
                Else
                    RenglonAInsertar("FechaEstimada") = TBFechaEstimada.Text
                End If
                RenglonAInsertar("IdEstado") = DDEstado.SelectedValue
                RenglonAInsertar("IdUsuarioCreacion") = 1
                RenglonAInsertar("FechaCreacion") = Now
                RenglonAInsertar("IdUsuarioActualizacion") = 1
                RenglonAInsertar("FechaActualizacion") = Now
                TablaProductosGarantia.Rows.Add(RenglonAInsertar)
            End If
        Next
        Session("TablaProductosGarantia") = TablaProductosGarantia
    End Sub
    'Protected Sub CBGVDetalleVentaItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim TablaGarantiaDetalle As New DataTable()
    '    TablaGarantiaDetalle = Session("TablaGarantiaDetalle")
    '    Dim Cont As Integer = 0
    '    For Each MiDataRow As GridViewRow In GVDetalleVenta.Rows
    '        If CType(MiDataRow.FindControl("CBGVDetalleVentaItem"), CheckBox).Checked = True Then
    '            Cont += 1
    '            If CType(MiDataRow.FindControl("CBGVDetalleVentaItem"), CheckBox).Checked = True Then
    '                CType(MiDataRow.FindControl("CBGVDetalleVentaItem"), CheckBox).Checked = False
    '            End If
    '        End If
    '    Next       
    'End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Limpiar()
        Habilitar()
        SeleccionarView(1)
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioGarantia As New Negocio.Garantia()
        Dim EntidadGarantia As New Entidad.Garantia()
        If TBIdGarantia.Text Is String.Empty Then
            VerificarCheckBox()
            Dim IdCliente As Integer
            Dim Equivalencia As String
            Dim Nombre As String
            wucConsultarPersona.ObtenerPersona(IdCliente, Equivalencia, Nombre)
            EntidadGarantia.IdCliente = IdCliente
            EntidadGarantia.TablaGarantiaDetalle = Session("TablaProductosGarantia")

            EntidadGarantia.IdGarantiaDetalle = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("IdGarantiaDetalle")
            EntidadGarantia.IdProducto = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("IdProducto")
            EntidadGarantia.Falla = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("Falla")
            EntidadGarantia.Observacion = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("Observacion")
            EntidadGarantia.Accesorios = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("Accesorios")
            EntidadGarantia.FechaEstimada = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("FechaEstimada")

            TablaVentaDetalle = Session("Tabla")
            EntidadGarantia.IdVenta = TablaVentaDetalle.Rows(GVVenta.SelectedIndex).Item("ID")
        Else
            EntidadGarantia.TablaGarantiaDetalle = Session("Tabla4")
            EntidadGarantia.IdCliente = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("IdPersona")
            EntidadGarantia.IdProducto = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("IdProducto")
            EntidadGarantia.IdVenta = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("IdVenta")
            EntidadGarantia.IdGarantiaDetalle = EntidadGarantia.TablaGarantiaDetalle.Rows(0).Item("IdGarantiaDetalle")
        End If
        If TBIdGarantia.Text Is String.Empty Then
            EntidadGarantia.IdGarantia = 0
        Else
            EntidadGarantia.IdGarantia = CInt(TBIdGarantia.Text)
        End If        
        EntidadGarantia.Folio = TBFolio.Text
        EntidadGarantia.IdSucursal = DDSucursalGarantia.SelectedValue
        EntidadGarantia.Telefono = TBTelefono.Text
        EntidadGarantia.Falla = TBFalla.Text
        EntidadGarantia.Observacion = TBObservacion.Text
        EntidadGarantia.Accesorios = TBAccesorios.Text
        EntidadGarantia.FechaEstimada = TBFechaEstimada.Text
        EntidadGarantia.IdEstado = DDEstado.SelectedValue
        NegocioGarantia.Guardar(EntidadGarantia)
        Limpiar()
        Consultar()
        TablaProductosGarantia.Clear()
        Session("TablaProductosGarantia") = TablaProductosGarantia
        SeleccionarView(0)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub  
    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click
        GVVenta.DataSource = Nothing
        GVVenta.DataBind()
        ConsultarVentas()
    End Sub
    Protected Sub GVVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVVenta.SelectedIndexChanged
        Dim EntidadGarantia As New Entidad.Garantia()
        Dim NegocioGarantia As New Negocio.Garantia()        
        TablaVentaDetalle = Session("Tabla")
        EntidadGarantia.IdVenta = TablaVentaDetalle.Rows(GVVenta.SelectedIndex).Item("ID")
        TBFolio.Text = TablaVentaDetalle.Rows(GVVenta.SelectedIndex).Item("Folio")
        EntidadGarantia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetalladaPorId
        NegocioGarantia.Consultar(EntidadGarantia)
        TablaGarantiaDetalle = EntidadGarantia.TablaConsulta
        GVDetalleVenta.DataSource = TablaGarantiaDetalle
        GVDetalleVenta.AutoGenerateColumns = False
        GVDetalleVenta.AllowSorting = True  
        GVDetalleVenta.DataBind()        
        Session("TablaGarantiaDetalle") = TablaGarantiaDetalle
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub
    Protected Sub GVConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsulta.SelectedIndexChanged        
        Dim EntidadGarantia As New Entidad.Garantia()
        Dim NegocioGarantia As New Negocio.Garantia()
        Tabla3 = Session("Tabla2")
        TBIdGarantia.Text = CInt(Tabla3.Rows(GVConsulta.SelectedIndex).Item("IdGarantia"))
        EntidadGarantia.IdGarantia = CInt(Tabla3.Rows(GVConsulta.SelectedIndex).Item("IdGarantia"))
        EntidadGarantia.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioGarantia.Consultar(EntidadGarantia)
        Tabla4 = EntidadGarantia.TablaConsulta
        DDSucursalGarantia.SelectedValue = CInt(Tabla4.Rows(0).Item("IdSucursal"))
        TBFolio.Text = CStr(Tabla4.Rows(0).Item("Folio"))
        TBTelefono.Text = CStr(Tabla4.Rows(0).Item("Telefono"))
        TBFalla.Text = CStr(Tabla4.Rows(0).Item("Falla"))
        TBObservacion.Text = CStr(Tabla4.Rows(0).Item("Observacion"))
        TBAccesorios.Text = CStr(Tabla4.Rows(0).Item("Accesorios"))
        TBFechaEstimada.Text = CStr(Tabla4.Rows(0).Item("FechaEstimada"))
        GVDetalleVenta.DataSource = Tabla4
        GVDetalleVenta.AutoGenerateColumns = False
        GVDetalleVenta.AllowSorting = True
        GVDetalleVenta.DataBind()
        Session("Tabla4") = Tabla4
        wucConsultarPersona.Visible = False
        GVDetalleVenta.Enabled = False
        GVDetalleVenta.Columns(0).Visible = False
        BTNConsultar.Enabled = False
        SeleccionarView(1)
    End Sub
End Class


