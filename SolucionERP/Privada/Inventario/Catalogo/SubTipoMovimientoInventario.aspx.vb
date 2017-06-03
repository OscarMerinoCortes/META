Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Subtipo Movimiento de Inventario"
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            DDEstadoFiltro.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstadoFiltro.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstadoFiltro.Items.Add(New ListItem("TODOS", "-1"))
            DDEstadoFiltro.SelectedValue = -1
            DDTipo.Items.Add(New ListItem("ENTRADA", "1"))
            DDTipo.Items.Add(New ListItem("SALIDA", "2"))
            DDTipo.Items.Add(New ListItem("TRASPASO", "3"))
            DDTipo.SelectedValue = "1"
            DDTipoFiltro.Items.Add(New ListItem("ENTRADA", "1"))
            DDTipoFiltro.Items.Add(New ListItem("SALIDA", "2"))
            DDTipoFiltro.Items.Add(New ListItem("TRASPASO", "3"))
            DDTipoFiltro.Items.Add(New ListItem("TODOS", "-1"))
            DDTipoFiltro.SelectedValue = -1
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
    Public Sub Consultar()
        Dim NegocioSubTipoMovimientoInventario As New Negocio.SubTipoMovimientoInventario()
        Dim EntidadSubTipoMovimientoInventario As New Entidad.SubTipoMovimientoInventario()

        Dim Tabla As New DataTable
        If (TBIdSubTipoFiltro.Text Is String.Empty) Then
            EntidadSubTipoMovimientoInventario.IdSubTipoFiltro = -1
        Else
            EntidadSubTipoMovimientoInventario.IdSubTipoFiltro = TBIdSubTipoFiltro.Text
        End If                
        EntidadSubTipoMovimientoInventario.DescripcionFiltro = TBDescripcionFiltro.Text
        EntidadSubTipoMovimientoInventario.IdTipoFiltro = DDTipoFiltro.SelectedValue
        EntidadSubTipoMovimientoInventario.IdEstadoFiltro = DDEstadoFiltro.SelectedValue
        NegocioSubTipoMovimientoInventario.Obtener(EntidadSubTipoMovimientoInventario)
        Tabla = EntidadSubTipoMovimientoInventario.TablaSubTipoMovimientoInventario
        GVSubTipoMovimientoInventario.Columns.Clear()
        GVSubTipoMovimientoInventario.DataSource = Tabla
        GVSubTipoMovimientoInventario.AutoGenerateColumns = False
        GVSubTipoMovimientoInventario.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVSubTipoMovimientoInventario.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubTipoMovimientoInventario, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubTipoMovimientoInventario, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubTipoMovimientoInventario, New BoundField(), "Tipo", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVSubTipoMovimientoInventario, New BoundField(), "Estado", "Estado")

        GVSubTipoMovimientoInventario.DataBind()
        Session("Tabla") = Tabla
        SeleccionarView(0)
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdSubTipo.Text = ""
        TBDescripcion.Text = ""
        DDTipo.SelectedValue = 1
        DDEstado.SelectedValue = 1
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioSubTipoMovimientoInventario As New Negocio.SubTipoMovimientoInventario()
        Dim EntidadSubTipoMovimientoInventario As New Entidad.SubTipoMovimientoInventario()
        If TBIdSubTipo.Text Is String.Empty Then
            EntidadSubTipoMovimientoInventario.IdSubTipo = 0
        Else
            EntidadSubTipoMovimientoInventario.IdSubTipo = CInt(TBIdSubTipo.Text)
        End If
        EntidadSubTipoMovimientoInventario.Descripcion = TBDescripcion.Text
        EntidadSubTipoMovimientoInventario.IdTipo = CInt(DDTipo.SelectedValue)        
        EntidadSubTipoMovimientoInventario.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioSubTipoMovimientoInventario.Guardar(EntidadSubTipoMovimientoInventario)
        wucDatosAuditoria1.Guardar(EntidadSubTipoMovimientoInventario)
        TBIdSubTipo.Text = EntidadSubTipoMovimientoInventario.IdSubTipo
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
        Try
            Dim Tabla = CType(Session("Tabla"), DataTable)
            Tabla.Rows.Clear()
            GVSubTipoMovimientoInventario.DataBind()
            Session("Tabla") = Tabla
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub GVSubTipoMovimientoInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSubTipoMovimientoInventario.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdSubTipo.Text = Tabla.Rows(GVSubTipoMovimientoInventario.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVSubTipoMovimientoInventario.SelectedIndex).Item("Descripcion")
        DDTipo.Text = Tabla.Rows(GVSubTipoMovimientoInventario.SelectedIndex).Item("IdTipo")
        DDEstado.SelectedValue = Tabla.Rows(GVSubTipoMovimientoInventario.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVSubTipoMovimientoInventario.SelectedIndex))
        SeleccionarView(1)
    End Sub

    Protected Sub BTNConsultar_Click(sender As Object, e As EventArgs) Handles BTNConsultar.Click
        Consultar()
    End Sub
End Class