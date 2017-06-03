Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "IVA"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
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
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVIVA.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdIva.Text = Tabla.Rows(GVIva.SelectedIndex).Item("ID")
        TBDescripcionIVA.Text = Tabla.Rows(GVIva.SelectedIndex).Item("IVA")
        DDEstado.SelectedValue = Tabla.Rows(GVIva.SelectedIndex).Item("IdEstado")
        SeleccionarView(1)
    End Sub
    Public Sub Consultar()
        Dim NegocioIVA As New Negocio.IVA()
        Dim EntidadIVA As New Entidad.IVA()
        Dim Tabla As New DataTable
        EntidadIVA.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioIVA.Consultar(EntidadIVA)
        Tabla = EntidadIVA.TablaConsulta
        GVIVA.Columns.Clear()
        GVIVA.DataSource = Tabla
        GVIVA.AutoGenerateColumns = False
        GVIVA.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVIVA.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVIVA, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVIVA, New BoundField(), "IVA", "IVA")        
        Comun.Presentacion.Cuadricula.AgregarColumna(GVIVA, New BoundField(), "Estado", "Estado")
        GVIVA.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdIva.Text = ""
        TBDescripcionIVA.Text = ""
        DDEstado.SelectedValue = 1
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioIVA As New Negocio.IVA()
        Dim EntidadIVA As New Entidad.IVA()
        EntidadIVA.IdIva = IIf(TBIdIva.Text Is String.Empty, 0, TBIdIva.Text)
        EntidadIVA.IVA = TBDescripcionIVA.Text
        EntidadIVA.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioIVA.Guardar(EntidadIVA)
        Consultar()
        TBIdIva.Text = ""
        TBDescripcionIVA.Text = ""
        DDEstado.SelectedValue = 1
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
    End Sub
End Class