Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Pais"
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"
            SeleccionarView(0)
            Consultar()
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
    Protected Sub GVPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVPais.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdPais.Text = Tabla.Rows(GVPais.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVPais.SelectedIndex).Item("Descripcion")
        TBGentilicio.Text = Tabla.Rows(GVPais.SelectedIndex).Item("Gentilicio")
        TBEquivalencia.Text = Tabla.Rows(GVPais.SelectedIndex).Item("Equivalencia")
        DDEstado.SelectedValue = Tabla.Rows(GVPais.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVPais.SelectedIndex))
        SeleccionarView(1)
    End Sub
    Public Sub Consultar()
        Dim NegocioPais As New Negocio.Pais()
        Dim EntidadPais As New Entidad.Pais()

        Dim Tabla As New DataTable
        EntidadPais.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.Ninguno
        NegocioPais.Consultar(EntidadPais)
        Tabla = EntidadPais.TablaConsulta
        GVPais.Columns.Clear()
        GVPais.DataSource = Tabla
        GVPais.AutoGenerateColumns = False
        GVPais.AllowSorting = True

        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVPais.Columns.Add(Columna)

        Comun.Presentacion.Cuadricula.AgregarColumna(GVPais, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPais, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPais, New BoundField(), "Gentilicio", "Gentilicio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPais, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVPais, New BoundField(), "Estado", "Estado")

        GVPais.DataBind()
        Session("Tabla") = Tabla
        SeleccionarView(0)
    End Sub
    Protected Sub nuevo()
        TBIdPais.Text = ""
        TBDescripcion.Text = ""
        TBGentilicio.Text = ""
        TBEquivalencia.Text = ""
        DDEstado.SelectedValue = 1
    End Sub
    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        nuevo()
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioPais As New Negocio.Pais()
        Dim EntidadPais As New Entidad.Pais()
        If TBIdPais.Text Is String.Empty Then
            EntidadPais.IdPais = 0
        Else
            EntidadPais.IdPais = CInt(TBIdPais.Text)
        End If
        EntidadPais.Descripcion = TBDescripcion.Text
        EntidadPais.Gentilicio = TBGentilicio.Text.ToUpper()
        EntidadPais.Equivalencia = TBEquivalencia.Text
        EntidadPais.idEstado = CInt(DDEstado.SelectedValue)
        NegocioPais.Guardar(EntidadPais)
        wucDatosAuditoria1.Guardar(EntidadPais)
        TBIdPais.Text = EntidadPais.IdPais
        nuevo()
        Consultar()
        SeleccionarView(0)
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
        Consultar()
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    'Protected Sub BTNRegresar_Click(sender As Object, e As EventArgs) Handles BTNRegresar.Click
    '    MultiView1.SetActiveView(View1)
    'End Sub
End Class