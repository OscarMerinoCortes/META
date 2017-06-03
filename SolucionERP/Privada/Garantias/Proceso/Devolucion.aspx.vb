Imports System.Data
Partial Class _Default
    Inherits Page    
    Public TablaDevolucion As New DataTable
    Public VistaDevolucion As New DataView

    Public TablaDevolucionDetalle As New DataTable
    Public VistaDevolucionDetalle As New DataView

    Public TablaProductosDevueltos As New DataTable
    Public VistaProductosDevueltos As New DataView

    Dim TablaProductosDevueltos2 As DataTable

    Public TablaConsulta As New DataTable
    Public VistaConsulta As New DataView

    Public Tabla As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Devoluciones"
            RBTNCargo.Checked = True
            IBTAplicar.Visible = False
            TBConcepto.Text = Format(0, Operacion.Configuracion.Constante.Formato.Moneda)
            TBMonto.Text = Format(0, Operacion.Configuracion.Constante.Formato.Moneda)
            TBMonto.Enabled = False
            Consultar()
            'TablaProductosgarantia--------------------------------------------------------------------------------
            TablaProductosDevueltos.Columns.Add(New DataColumn("IdDevolucionDetalle", Type.GetType("System.Int32")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("IdDevolucion", Type.GetType("System.Int32")))          
            TablaProductosDevueltos.Columns.Add(New DataColumn("IdProducto", Type.GetType("System.Int32")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("Id", Type.GetType("System.Int32")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("Folio", Type.GetType("System.String")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("Total", Type.GetType("System.Double")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("IdEstado", Type.GetType("System.Int32")))
            TablaProductosDevueltos.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
     
            VistaProductosDevueltos = TablaProductosDevueltos.DefaultView
            Session("TablaProductosDevueltos") = TablaProductosDevueltos
            Session("VistaProductosDevueltos") = VistaProductosDevueltos

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
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBusqueda
        NegocioAlmacen.Consultar(EntidadAlmacen)
        DDAlmacen.DataSource = EntidadAlmacen.TablaConsulta
        DDAlmacen.DataValueField = "ID"
        DDAlmacen.DataTextField = "Descripcion"
        DDAlmacen.DataBind()
        DDAlmacen.SelectedValue = 1
        'DDEstado...
        DDEstado.Items.Add(New ListItem("ACTIVO", 1))
        DDEstado.Items.Add(New ListItem("INACTIVO", 2))
        DDEstado.SelectedValue = 1
        'DDTipoDevolucion
        DDTipoDevolucion.Items.Add(New ListItem("TOTAL", 1))
        DDTipoDevolucion.Items.Add(New ListItem("PARCIAL", 2))
        DDTipoDevolucion.SelectedValue = 1
        'DDDevolucion
        DDDevolucion.Items.Add(New ListItem("VENTA", 1))
        DDDevolucion.Items.Add(New ListItem("COMPRA", 2))
        DDDevolucion.SelectedValue = 1
    End Sub
    Public Sub Limpiar()
        TBIdDevolucion.Text = ""
        DDTipoDevolucion.SelectedValue = 1
        TBFolio.Text = ""        
        DDDevolucion.SelectedValue = 1
        TBMonto.Text = Format(0, Operacion.Configuracion.Constante.Formato.Moneda)
        TBConcepto.Text = Format(0, Operacion.Configuracion.Constante.Formato.Moneda)
        DDAlmacen.SelectedIndex = 0
        DDEstado.SelectedValue = 1
        TBObservacion.Text = ""
        RBTNCargo.Checked = True
        IBTAplicar.Visible = False

        GVConsulta.DataSource = Nothing
        GVConsulta.DataBind()
        GVDevolucion.DataSource = Nothing
        GVDevolucion.DataBind()
        GVDevolucion.Visible = True
        GVDevolucionDetalle.DataSource = Nothing
        GVDevolucionDetalle.DataBind()

        GVDevolucionDetalle.Columns(0).Visible = True
        TablaConsulta.Clear()
        Session("TablaConsulta") = TablaConsulta
        TablaDevolucion.Clear()
        Session("TablaDevolucion") = TablaDevolucion
        TablaDevolucionDetalle.Clear()
        Session("TablaDevolucionDetalle") = TablaDevolucionDetalle    
    End Sub
    Public Sub Habilitar()
        GVDevolucionDetalle.Enabled = True
        BTNConsultar.Enabled = True
        wucDatosAuditoria1.Visible = False
        DDTipoDevolucion.Enabled = True
        DDDevolucion.Enabled = True
        TBConcepto.Enabled = True
        RBTNAbono.Enabled = True
        RBTNCargo.Enabled = True
        DDAlmacen.Enabled = True
        DDEstado.Enabled = True
        RBTNCargo.Checked = True
        RBTNAbono.Checked = False
    End Sub
    Public Sub Inhabilitar()
        DDTipoDevolucion.Enabled = False
        DDDevolucion.Enabled = False
        TBConcepto.Enabled = False
        RBTNAbono.Enabled = False
        RBTNCargo.Enabled = False
        DDAlmacen.Enabled = False
        DDEstado.Enabled = False
    End Sub
    Public Sub Consultar()
        GVDevolucion.DataSource = Nothing
        GVDevolucion.DataBind()
        Dim NegocioDevolucion As New Negocio.Devolucion()
        Dim EntidadDevolucion As New Entidad.Devolucion()
        EntidadDevolucion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioDevolucion.Consultar(EntidadDevolucion)
        TablaConsulta = EntidadDevolucion.TablaConsulta
        GVConsulta.Columns.Clear()
        GVConsulta.DataSource = TablaConsulta
        GVConsulta.AutoGenerateColumns = False
        GVConsulta.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Ver Detalle"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsulta.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "ID", "IdDevolucion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Fecha", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Tipo de devolución", "TipoDevolucion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Devolución", "DevolucionOperacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Almacén", "Almacen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsulta, New BoundField(), "Estado", "Estado")
        GVConsulta.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub
    Public Sub ConsultarCompraVenta()
        Dim NegocioDevolucion As New Negocio.Devolucion()
        Dim EntidadDevolucion As New Entidad.Devolucion()
        EntidadDevolucion.IdDevolucionOperacion = DDDevolucion.SelectedValue
        Dim Monto As Double
        If TBFolio.Text Is String.Empty Then
            Exit Sub
        Else
            EntidadDevolucion.Folio = TBFolio.Text
        End If
        If DDDevolucion.SelectedValue = 2 Then
            EntidadDevolucion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaCompra
            NegocioDevolucion.Consultar(EntidadDevolucion)
            TablaDevolucion = EntidadDevolucion.TablaDevolucion
            TablaDevolucionDetalle = EntidadDevolucion.TablaDevolucionDetalle
            Session("TablaDevolucion") = TablaDevolucion
            Session("TablaDevolucionDetalle") = TablaDevolucionDetalle            
            Asignar()
        Else
            EntidadDevolucion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaVenta
            NegocioDevolucion.Consultar(EntidadDevolucion)
            TablaDevolucion = EntidadDevolucion.TablaDevolucion
            TablaDevolucionDetalle = EntidadDevolucion.TablaDevolucionDetalle
            Session("TablaDevolucion") = TablaDevolucion
            Session("TablaDevolucionDetalle") = TablaDevolucionDetalle            
            Asignar()
        End If
        If DDTipoDevolucion.SelectedValue = 1 Then
            GVDevolucionDetalle.Columns(0).Visible = False
            For Each MiDataRow As GridViewRow In GVDevolucion.Rows
                Monto += Convert.ToDouble(TablaDevolucionDetalle.Rows(MiDataRow.RowIndex).Item("Total"))
            Next
        Else
            GVDevolucionDetalle.Columns(0).Visible = True
            TBMonto.Text = ""
        End If
        TBMonto.Text = Format(Monto, Operacion.Configuracion.Constante.Formato.Moneda)
        Session("TablaDevolucion") = TablaDevolucion
        Session("TablaDevolucionDetalle") = TablaDevolucionDetalle
    End Sub
    Public Sub Asignar()
        TablaDevolucion = Session("TablaDevolucion")
        VistaDevolucion = TablaDevolucion.DefaultView
        TablaDevolucionDetalle = Session("TablaDevolucionDetalle")
        VistaDevolucionDetalle = TablaDevolucionDetalle.DefaultView
        GVDevolucionDetalle.DataSource = VistaDevolucionDetalle
        GVDevolucionDetalle.DataBind()
        GVDevolucion.Columns.Clear()
        GVDevolucion.DataSource = VistaDevolucion
        GVDevolucion.AutoGenerateColumns = False
        GVDevolucion.AllowSorting = True
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDevolucion, New BoundField(), "Folio", "Folio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDevolucion, New BoundField(), "Fecha", "Fecha")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDevolucion, New BoundField(), "Nombre", "Nombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDevolucion, New BoundField(), "Total", "Total")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVDevolucion, New BoundField(), "Estado", "Estado")
        GVDevolucion.DataBind()
    End Sub
    Public Sub VerificarCheckBox()
        Dim EntidadGarantia As New Entidad.Garantia()
        Dim RenglonAInsertar As DataRow
        Dim Index As Integer
        Dim TablaDevolucion2 As DataTable = Session("TablaDevolucion")             
        TablaProductosDevueltos2 = Session("TablaProductosDevueltos")
        Dim TablaDevolucionDetalle As DataTable = Session("TablaDevolucionDetalle")
        If DDTipoDevolucion.SelectedValue = 2 Then
            For Each MiDataRow As GridViewRow In GVDevolucionDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                If CType(MiDataRow.FindControl("CBGVDevolucionItem"), CheckBox).Checked = True Then
                    RenglonAInsertar = TablaProductosDevueltos2.NewRow()
                    If TBIdDevolucion.Text Is String.Empty Then
                        RenglonAInsertar("IdDevolucion") = 0
                    Else
                        RenglonAInsertar("IdDevolucion") = TBIdDevolucion.Text
                    End If
                    RenglonAInsertar("IdDevolucionDetalle") = 0           
                    RenglonAInsertar("IdProducto") = TablaDevolucionDetalle.Rows(Index).Item("IdProducto")
                    RenglonAInsertar("Id") = TablaDevolucion2.Rows(0).Item("Id")
                    RenglonAInsertar("Folio") = TBFolio.Text
                    RenglonAInsertar("Precio") = TablaDevolucionDetalle.Rows(Index).Item("Precio")
                    RenglonAInsertar("Cantidad") = TablaDevolucionDetalle.Rows(Index).Item("Cantidad")
                    RenglonAInsertar("Total") = TablaDevolucionDetalle.Rows(Index).Item("Total")
                    RenglonAInsertar("Observacion") = Convert.ToString(CType(MiDataRow.FindControl("TBGVObservacion"), TextBox).Text)
                    RenglonAInsertar("IdEstado") = DDEstado.SelectedValue
                    TablaProductosDevueltos2.Rows.Add(RenglonAInsertar)
                    Session("TablaProductosDevueltos2") = TablaProductosDevueltos2
                End If
            Next
        Else
            For Each MiDataRow As GridViewRow In GVDevolucionDetalle.Rows
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                RenglonAInsertar = TablaProductosDevueltos2.NewRow()
                If TBIdDevolucion.Text Is String.Empty Then
                    RenglonAInsertar("IdDevolucion") = 0
                Else
                    RenglonAInsertar("IdDevolucion") = TBIdDevolucion.Text
                End If
                RenglonAInsertar("IdDevolucionDetalle") = 0
                RenglonAInsertar("IdProducto") = TablaDevolucionDetalle.Rows(Index).Item("IdProducto")
                RenglonAInsertar("Id") = TablaDevolucion2.Rows(0).Item("Id")
                RenglonAInsertar("Folio") = TBFolio.Text
                RenglonAInsertar("Precio") = TablaDevolucionDetalle.Rows(Index).Item("Precio")
                RenglonAInsertar("Cantidad") = TablaDevolucionDetalle.Rows(Index).Item("Cantidad")
                RenglonAInsertar("Total") = TablaDevolucionDetalle.Rows(Index).Item("Total")
                RenglonAInsertar("Observacion") = Convert.ToString(CType(MiDataRow.FindControl("TBGVObservacion"), TextBox).Text)
                RenglonAInsertar("IdEstado") = DDEstado.SelectedValue
                TablaProductosDevueltos2.Rows.Add(RenglonAInsertar)
                Session("TablaProductosDevueltos2") = TablaProductosDevueltos2          
            Next
        End If
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Limpiar()
        Habilitar()
        SeleccionarView(1)
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioDevolucion As New Negocio.Devolucion()
        Dim EntidadDevolucion As New Entidad.Devolucion() 
        If TBIdDevolucion.Text Is String.Empty Then
            VerificarCheckBox()
            EntidadDevolucion.TablaDevolucionDetalle = Session("TablaProductosDevueltos2")
            EntidadDevolucion.IdDevolucion = 0
            EntidadDevolucion.IdTipoDevolucion = DDTipoDevolucion.SelectedValue
            EntidadDevolucion.IdDevolucionOperacion = DDDevolucion.SelectedValue
            EntidadDevolucion.Monto = TBMonto.Text
            If RBTNCargo.Checked = True Then
                EntidadDevolucion.IdBandera = 1
            Else
                EntidadDevolucion.IdBandera = 2
            End If
            EntidadDevolucion.Concepto = TBConcepto.Text
            EntidadDevolucion.IdAlmacen = DDAlmacen.SelectedValue
            EntidadDevolucion.IdEstado = DDEstado.SelectedValue
            EntidadDevolucion.Observacion = TBObservacion.Text
        Else
            EntidadDevolucion.TablaDevolucionDetalle = Session("TablaId")
            EntidadDevolucion.IdDevolucion = TBIdDevolucion.Text
            EntidadDevolucion.IdTipoDevolucion = DDTipoDevolucion.SelectedValue
            EntidadDevolucion.IdDevolucionOperacion = DDDevolucion.SelectedValue
            EntidadDevolucion.Monto = TBMonto.Text
            If RBTNCargo.Checked = True Then
                EntidadDevolucion.IdBandera = 1
            Else
                EntidadDevolucion.IdBandera = 2
            End If
            EntidadDevolucion.Concepto = TBConcepto.Text
            EntidadDevolucion.IdAlmacen = DDAlmacen.SelectedValue
            EntidadDevolucion.IdEstado = DDEstado.SelectedValue
            EntidadDevolucion.Observacion = TBObservacion.Text
        End If
        If TBIdDevolucion.Text Is String.Empty Then
            EntidadDevolucion.IdDevolucion = 0
        Else
            EntidadDevolucion.IdDevolucion = CInt(TBIdDevolucion.Text)
        End If       
        NegocioDevolucion.Guardar(EntidadDevolucion)
        wucDatosAuditoria1.Guardar(EntidadDevolucion)
        TablaProductosDevueltos2.Clear()
        Limpiar()
        Consultar()      
        SeleccionarView(0)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click
        GVDevolucion.DataSource = Nothing
        GVDevolucion.DataBind()
        ConsultarCompraVenta()
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub
    Protected Sub CBGVDevolucionItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Monto As Double        
        TBMonto.Text = ""
        Dim tabla As DataTable = Session("TablaDevolucionDetalle")
        For Each MiDataRow As GridViewRow In GVDevolucionDetalle.Rows
            If CType(MiDataRow.FindControl("CBGVDevolucionItem"), CheckBox).Checked = True Then
                Monto += Convert.ToDouble(tabla.Rows(MiDataRow.RowIndex).Item("Total"))
            End If
        Next
        TBMonto.Text = Format(Monto, Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub
    Protected Sub GVConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsulta.SelectedIndexChanged
        Dim EntidadDevolucion As New Entidad.Devolucion()
        Dim NegocioDevolucion As New Negocio.Devolucion()
        Dim Tabla As DataTable = Session("TablaConsulta")
        TBIdDevolucion.Text = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdDevolucion"))
        DDTipoDevolucion.SelectedValue = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdTipoDevolucion"))
        DDDevolucion.SelectedValue = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdDevolucionOperacion"))
        TBMonto.Text = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("Monto"))
        TBConcepto.Text = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("Concepto"))
        RBTNAbono.Checked = False
        RBTNCargo.Checked = False
        If CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdCargoAbono")) = 1 Then
            RBTNCargo.Checked = True
        Else
            RBTNAbono.Checked = True
        End If
        DDAlmacen.SelectedValue = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdAlmacen"))
        DDEstado.SelectedValue = CInt(Tabla.Rows(GVConsulta.SelectedIndex).Item("IdEstado"))
        TBObservacion.Text = CStr(Tabla.Rows(GVConsulta.SelectedIndex).Item("Observacion"))
        EntidadDevolucion.IdDevolucion = CInt(TBIdDevolucion.Text)
        EntidadDevolucion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioDevolucion.Consultar(EntidadDevolucion)
        Dim TablaId As DataTable = EntidadDevolucion.TablaConsulta
        GVDevolucionDetalle.DataSource = TablaId
        GVDevolucionDetalle.AutoGenerateColumns = False
        GVDevolucionDetalle.AllowSorting = True
        GVDevolucionDetalle.DataBind()
        Session("TablaId") = TablaId
        GVDevolucionDetalle.Enabled = False
        GVDevolucionDetalle.Columns(0).Visible = False                                        
        BTNConsultar.Enabled = False
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVConsulta.SelectedIndex))
        wucDatosAuditoria1.Visible = True
        GVDevolucion.Visible = False
        Inhabilitar()
        IBTAplicar.Visible = True
        SeleccionarView(1)
    End Sub

    Protected Sub DDTipoDevolucion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDTipoDevolucion.SelectedIndexChanged
        Dim tabla As DataTable
        tabla = Session("TablaDevolucionDetalle")
        Dim Monto As Double
        If DDTipoDevolucion.SelectedValue = 1 Then
            GVDevolucionDetalle.Columns(0).Visible = False
            For Each MiDataRow As GridViewRow In GVDevolucion.Rows
                Monto += Convert.ToDouble(tabla.Rows(MiDataRow.RowIndex).Item("Total"))
            Next
        Else
            GVDevolucionDetalle.Columns(0).Visible = True
            TBMonto.Text = ""
        End If
        TBMonto.Text = Format(Monto, Operacion.Configuracion.Constante.Formato.Moneda)
    End Sub

    Protected Sub RBTNCargo_CheckedChanged(sender As Object, e As EventArgs) Handles RBTNCargo.CheckedChanged
        If RBTNAbono.Checked = True Then
            RBTNAbono.Checked = False
        End If
    End Sub

    Protected Sub RBTNAbono_CheckedChanged(sender As Object, e As EventArgs) Handles RBTNAbono.CheckedChanged
        If RBTNCargo.Checked = True Then
            RBTNCargo.Checked = False
        End If
    End Sub
    Protected Sub IBTAplicar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTAplicar.Click
        Dim NegocioDevolucion As New Negocio.Devolucion()
        Dim EntidadDevolucion As New Entidad.Devolucion()
        EntidadDevolucion.TablaDevolucionDetalle = Session("TablaId")
        EntidadDevolucion.IdAlmacen = DDAlmacen.SelectedValue
        EntidadDevolucion.IdEstado = DDEstado.SelectedValue
        EntidadDevolucion.IdUsuarioCreacion = 1
        EntidadDevolucion.FechaCreacion = Now
        EntidadDevolucion.IdUsuarioActualizacion = 1
        EntidadDevolucion.FechaActualizacion = Now
        NegocioDevolucion.Aplicar(EntidadDevolucion)
        Limpiar()
        Habilitar()
    End Sub
End Class


