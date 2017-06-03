Imports System.Data
Imports Operacion.Configuracion.Constante
Public Class WucConsultarPersonaCaja
    Inherits System.Web.UI.UserControl
    Private TablaConsultarPersona As New DataTable()
    Private Persona As New Entidad.Persona
    Public Event CerrarClick()
    Public Event ElementoSeleccionado(ByVal sender As Object, ByVal e As EventArgs)


    Protected Sub BTBuscarPersona_Click(sender As Object, e As EventArgs) Handles BTBuscarPersona.Click
        Dim EntidadConsultarPersona As New Entidad.Persona()
        Dim NegocioConsultarPersona As New Negocio.Persona()
        EntidadConsultarPersona.IdPersona = CInt(IIf(Not IsNumeric(TBIdPersona.Text), 0, TBIdPersona.Text))
        EntidadConsultarPersona.Equivalencia = TBEquivalencia.Text
        EntidadConsultarPersona.PrimerNombre = TBNombrePersona.Text
        'EntidadConsultarPersona.IdEstado = IdEstadoCredito
        EntidadConsultarPersona.Tarjeta.Consulta = Consulta.Ninguno
        NegocioConsultarPersona.Consultar(EntidadConsultarPersona)
        TablaConsultarPersona = EntidadConsultarPersona.TablaConsulta
        GVConsultaPersona.Columns.Clear()
        GVConsultaPersona.DataSource = TablaConsultarPersona
        Dim Columna As New CommandField()
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsultaPersona.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Primer Nombre", "PrimerNombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Segundo Nombre", "SegundoNombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Apellido Paterno", "ApellidoPaterno")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Apellido Materno", "ApellidoMaterno")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Fecha de Nacimiento", "FechaNacimiento", "{0:d}")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Observaciones", "Observaciones")
        GVConsultaPersona.DataBind()
        Session("TablaConsultarPersona") = TablaConsultarPersona
        LabelRegistrosBuscarPersona.Text = "   Personas: " + TablaConsultarPersona.Rows.Count.ToString()
    End Sub


    Protected Sub GVConsultaPersona_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GVConsultaPersona.SelectedIndexChanged 
        TablaConsultarPersona = Session("TablaConsultarPersona")
        Persona.IdPersona = TablaConsultarPersona.Rows(GVConsultaPersona.SelectedIndex).Item("ID")
        Persona.Equivalencia = TablaConsultarPersona.Rows(GVConsultaPersona.SelectedIndex).Item("Equivalencia")
        Persona.PrimerNombre = TablaConsultarPersona.Rows(GVConsultaPersona.SelectedIndex).Item("PrimerNombre")
        Persona.SegundoNombre = TablaConsultarPersona.Rows(GVConsultaPersona.SelectedIndex).Item("SegundoNombre")
        Persona.ApellidoPaterno = TablaConsultarPersona.Rows(GVConsultaPersona.SelectedIndex).Item("ApellidoPaterno")
        Persona.ApellidoMaterno = TablaConsultarPersona.Rows(GVConsultaPersona.SelectedIndex).Item("ApellidoMaterno")
        Dim ValueEventArgs1 As New Entidad.PersonaEventArgs(Persona, GVConsultaPersona.SelectedIndex)
        RaiseEvent ElementoSeleccionado(Me, ValueEventArgs1)
        GVConsultaPersona.DataSource = Nothing
        GVConsultaPersona.DataBind()

    End Sub

    Protected Sub IBCerrar_OnClick(sender As Object, e As EventArgs) Handles BTCancelarBusqueda.Click
        RaiseEvent CerrarClick()
    End Sub
End Class
