Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class WucConsultarPersonaVenta
    Inherits UserControl
    Private TablaConsultarPersona As New DataTable()
    Public Event Seleccionado As EventHandler
    Public Event Cancelado As EventHandler
    Public Shared Property IdPersonaCorto As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub
    Public Sub Buscar(texto As String)
        LimpiarConsulta()
        TBXCodigo.Focus()
    End Sub

    Private Sub LimpiarConsulta()
        Try
            Dim TablaConsulta As DataTable = ViewState("TablaBuscarPersona")
            TablaConsulta.Rows.Clear()
            IdPersonaCorto = ""
            TBXCodigo.Text = ""
            GVBusquedaPersona.DataSource = TablaConsulta
            GVBusquedaPersona.DataBind()
            ViewState("TablaBuscarPersona") = TablaConsulta
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BTNBuscar_Click(sender As Object, e As EventArgs)
        BuscarPersona()
    End Sub

    Protected Sub BTNVCancelar_Click(sender As Object, e As EventArgs)
        LimpiarConsulta()
        RaiseEvent Cancelado(New Object, New EventArgs)
    End Sub
    Protected Sub GVBusquedaPersona_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub
    Protected Sub BTNSeleccionar_Click1(sender As Object, e As EventArgs)
        Dim Tabla As New DataTable
        Tabla = CType(ViewState("TablaBuscarPersona"), DataTable)
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        GVBusquedaPersona.SelectedIndex = gvrFilaActual.RowIndex
        IdPersonaCorto = CInt(Tabla.Rows(GVBusquedaPersona.SelectedIndex).Item("IdPersona"))
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub

    Private Sub BuscarPersona()
        Dim EntidadConsultarPersona As New Entidad.Persona()
        Dim NegocioConsultarPersona As New Negocio.Persona()
        EntidadConsultarPersona.PrimerNombre = TBXCodigo.Text
        EntidadConsultarPersona.Tarjeta.Consulta = Consulta.ConsultaPorDescripcion
        NegocioConsultarPersona.VentaObtener(EntidadConsultarPersona)
        TablaConsultarPersona = EntidadConsultarPersona.TablaConsulta
        GVBusquedaPersona.DataSource = TablaConsultarPersona
        GVBusquedaPersona.DataBind()
        LBCantidadBusqueda.Text = "   Personas: " + TablaConsultarPersona.Rows.Count.ToString()
        ViewState("TablaBuscarPersona") = EntidadConsultarPersona.TablaConsulta
    End Sub
End Class
