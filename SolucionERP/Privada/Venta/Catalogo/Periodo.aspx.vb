Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Periodo"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"

            DDEquivalencia.Items.Add(New ListItem("DIA", "1"))
            DDEquivalencia.Items.Add(New ListItem("SEMANA", "2"))
            DDEquivalencia.Items.Add(New ListItem("MES", "3"))
            DDEquivalencia.Items.Add(New ListItem("AÑO", "4"))
            DDEquivalencia.SelectedValue = "1"
            wucDatosAuditoria1.Visible = False
            SeleccionarView(0)
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
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPeriodo.SelectedIndexChanged
        Dim Tabla = Session("Tabla")
        TBIdPeriodo.Text = CType(Tabla.Rows(GVPeriodo.SelectedIndex).Item("ID"), String)
        TBDescripcion.Text = CType(Tabla.Rows(GVPeriodo.SelectedIndex).Item("Descripcion"), String)
        TBCantidad.Text = CType(Tabla.Rows(GVPeriodo.SelectedIndex).Item("Cantidad"), Integer)
        DDEquivalencia.SelectedValue = CType(Tabla.Rows(GVPeriodo.SelectedIndex).Item("IdTipoEquivalenciaPeriodo"), Integer)
        DDEstado.SelectedValue = CType(Tabla.Rows(GVPeriodo.SelectedIndex).Item("IdEstado"), String)
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVPeriodo.SelectedIndex))
        SeleccionarView(1)
    End Sub
    Public Sub Consultar()
        Dim NegocioPeriodo = New Negocio.Periodo()
        Dim EntidadPeriodo As New Entidad.Periodo()
        Dim Tabla As New DataTable
        EntidadPeriodo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioPeriodo.Consultar(EntidadPeriodo)
        Tabla = EntidadPeriodo.TablaConsulta
        GVPeriodo.Columns.Clear()
        GVPeriodo.DataSource = Tabla
        GVPeriodo.AutoGenerateColumns = False
        GVPeriodo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPeriodo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPeriodo, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPeriodo, New BoundField(), "Periodo", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPeriodo, New BoundField(), "Cantidad", "Cantidad")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPeriodo, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPeriodo, New BoundField(), "Estado", "Estado")
        GVPeriodo.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioPeriodo As New Negocio.Periodo()
        Dim EntidadPeriodo As New Entidad.Periodo()
        If TBIdPeriodo.Text Is String.Empty Then
            EntidadPeriodo.IdPeriodo = 0
        Else
            EntidadPeriodo.IdPeriodo = CInt(TBIdPeriodo.Text)
        End If
        EntidadPeriodo.Descripcion = TBDescripcion.Text
        EntidadPeriodo.IdTipoEquivalenciaPeriodo = CInt(DDEquivalencia.SelectedValue)
        EntidadPeriodo.Cantidad = TBCantidad.Text
        EntidadPeriodo.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioPeriodo.Guardar(EntidadPeriodo)
        Consultar()
        Nuevo()
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Public Sub Nuevo()
        TBIdPeriodo.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = "1"
        TBCantidad.Text = ""
        DDEquivalencia.SelectedValue = "1"
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub
End Class