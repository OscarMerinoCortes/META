Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim Tarjeta As New Entidad.Tarjeta()
            Tarjeta = Session("Tarjeta")
            If Session("Tarjeta") Is Nothing Then
                Response.Redirect("~/Account/Login.aspx")
            End If

            Tarjeta.IdOpcion = Operacion.Configuracion.Constante.Opcion.Almacen
            'Tarjeta.IdTransaccion = Operacion.Configuracion.Constante.Transaccion.CargarPagina
            'Session("Tarjeta") = Tarjeta
            If Not Seguridad.Autorizacion.Opcion.Validar(Tarjeta) Then
                Response.Redirect("~/Default.aspx")
            Else
                
                CType(Master.FindControl("LBOpcion"), Label).Text = "Almacen"
                Consultar()
                ConsultarSucursal()
                DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
                DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
                DDSucursal.SelectedValue = "1"
                DDEstado.SelectedValue = "1"
                wucDatosAuditoria1.Visible = False
                SeleccionarView(0)

            End If
        End If
    End Sub

    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then
            Consultar()
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub

    Private Sub ConsultarSucursal()
        Dim NegocioSucursal = New Negocio.Sucursal()
        Dim EntidadSucursal As New Entidad.Sucursal()
        EntidadSucursal.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioSucursal.Consultar(EntidadSucursal)
        DDSucursal.DataSource = EntidadSucursal.TablaConsulta
        DDSucursal.DataValueField = "ID"
        DDSucursal.DataTextField = "Descripcion"
        DDSucursal.DataBind()
    End Sub


    Public Sub Consultar()
        wucDatosAuditoria1.Visible = False
        Dim NegocioAlmacen = New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        Dim Tabla As New DataTable
        EntidadAlmacen.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioAlmacen.Consultar(EntidadAlmacen)
        Tabla = EntidadAlmacen.TablaConsulta
        GVAlmacen.Columns.Clear()
        GVAlmacen.DataSource = Tabla
        GVAlmacen.AutoGenerateColumns = False
        GVAlmacen.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVAlmacen.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAlmacen, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAlmacen, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAlmacen, New BoundField(), "Descripcion Sucursal", "Descripcion Sucursal")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAlmacen, New BoundField(), "Almacen Prederminado", "Predeterminado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAlmacen, New BoundField(), "Estado", "Estado")
        GVAlmacen.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdAlmacen.Text = ""
        TBDescripcion.Text = ""
        DDSucursal.SelectedValue = CType(1, String)
        DDEstado.SelectedValue = CType(1, String)
        CBAlmacen.Checked = False
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub
    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioAlmacen As New Negocio.Almacen()
        Dim EntidadAlmacen As New Entidad.Almacen()
        If TBIdAlmacen.Text Is String.Empty Then
            EntidadAlmacen.IdAlmacen = 0
        Else
            EntidadAlmacen.IdAlmacen = CInt(TBIdAlmacen.Text)
        End If
        EntidadAlmacen.Descripcion = TBDescripcion.Text
        EntidadAlmacen.IdSucursal = CInt(DDSucursal.SelectedValue)
        EntidadAlmacen.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadAlmacen.Devolucion = IIf(CBAlmacen.Checked = True, 1, 0)
        EntidadAlmacen.Predetermiando = IIf(CBPredeterminado.Checked = True, 1, 2)
        NegocioAlmacen.Guardar(EntidadAlmacen)
        wucDatosAuditoria1.Guardar(EntidadAlmacen)
        Consultar()
        TBIdAlmacen.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = CType(1, String)
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub GVAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVAlmacen.SelectedIndexChanged
        Dim Tabla = Session("Tabla")
        TBIdAlmacen.Text = CType(Tabla.Rows(GVAlmacen.SelectedIndex).Item("ID"), String)
        TBDescripcion.Text = CType(Tabla.Rows(GVAlmacen.SelectedIndex).Item("Descripcion"), String)
        CBAlmacen.Checked = IIf(CType(Tabla.Rows(GVAlmacen.SelectedIndex).Item("Devolucion"), Integer) = 0, False, True)
        DDSucursal.SelectedValue = CType(Tabla.Rows(GVAlmacen.SelectedIndex).Item("ID Sucursal"), String)
        DDEstado.SelectedValue = CType(Tabla.Rows(GVAlmacen.SelectedIndex).Item("IdEstado"), String)
        CBPredeterminado.Checked = IIf(CType(Tabla.Rows(GVAlmacen.SelectedIndex).Item("IdPredeterminado"), Integer) = 2, False, True)
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVAlmacen.SelectedIndex))
        SeleccionarView(1)
    End Sub

    Protected Sub GVAlmacen_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVAlmacen.Sorting
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        Dim Vista As DataView = Tabla.DefaultView
        Vista.Sort = e.SortExpression + Space(1) + IIf(e.SortDirection = SortDirection.Ascending, "ASC", "DESC")
        GVAlmacen.DataSource = Vista
        GVAlmacen.DataBind()
        SeleccionarView(1)
    End Sub
End Class