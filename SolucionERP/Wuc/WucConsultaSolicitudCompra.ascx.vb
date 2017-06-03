Imports System.Data
Partial Class WucConsultaSolicitudCompra
    Inherits System.Web.UI.UserControl
    Private TablaConsultarPersona As New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Public Sub Abrir()
        MPEConsultarCliente.Show()
    End Sub

    Protected Sub BTBuscarPersona_Click(sender As Object, e As EventArgs) Handles BTBuscarPersona.Click
        Dim EntidadConsultarPersona As New Entidad.ConsultarPersona()
        Dim NegocioConsultarPersona As New Negocio.ConsultarPersona()
        EntidadConsultarPersona.IdPersona = CInt(IIf(TBIdPersona.Text = "" Or Not IsNumeric(TBIdPersona.Text), 0, TBIdPersona.Text))
        EntidadConsultarPersona.Nombre = CStr(IIf(TBNombrePersona.Text = "", "Vacio", TBNombrePersona.Text))
        NegocioConsultarPersona.Consultar(EntidadConsultarPersona)
        TablaConsultarPersona = EntidadConsultarPersona.TablaConsulta
        GVConsultarPersona.Columns.Clear()
        GVConsultarPersona.DataSource = TablaConsultarPersona
        GVConsultarPersona.AutoGenerateColumns = False
        GVConsultarPersona.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsultarPersona.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarPersona, New BoundField(), "ID", "IdPersona")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarPersona, New BoundField(), "Nombre", "Nombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarPersona, New BoundField(), "Estado", "Descripcion")
        GVConsultarPersona.DataBind()
        Session("TablaConsultarPersona") = TablaConsultarPersona
    End Sub
End Class
