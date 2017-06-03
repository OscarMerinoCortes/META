Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class WucConsultarProveedor
    Inherits UserControl
    Private TablaConsultarPersona As New DataTable()
    Public Event Seleccionado As EventHandler
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Public Event CerarClick()
    Private Sub Buscar()
        LimpiarConsulta()
        MPEConsultarPersona.Show()
    End Sub
    Public Sub Nuevo()
        TBIdPersona.Text = ""
        TBEquivalencia.Text = ""
        TBNombre.Text = ""
    End Sub
    Public Sub ObtenerPersona(ByRef IdPersona As Integer, ByRef Equivalencia As String, ByRef Nombre As String)
        Try

            'IdPersona = CInt(TBIdPersona.Text)
            'Equivalencia = TBEquivalencia.Text
            'Nombre = TBNombre.Text
            IdPersona = CInt(IIf(TBIdPersona.Text Is String.Empty, 0, TBIdPersona.Text))
            Equivalencia = IIf(TBEquivalencia.Text Is String.Empty, "0", TBEquivalencia.Text)
            Nombre = IIf(TBNombre.Text Is String.Empty, 0, TBNombre.Text)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub AsignarPersona(IdPersona As Integer, Equivalencia As String, Nombre As String)
        TBIdPersona.Text = CStr(IdPersona)
        TBEquivalencia.Text = Equivalencia
        TBNombre.Text = Nombre
    End Sub

    Protected Sub BTBuscarPersona_Click(sender As Object, e As EventArgs) Handles BTNBuscarPersona.Click
        Dim EntidadConsultarProveedor As New Entidad.Proveedor()
        Dim NegocioConsultarProveedor As New Negocio.Proveedor()
        EntidadConsultarProveedor.IdProveedor = CInt(IIf(Not IsNumeric(TBBIdPersona.Text), 0, TBBIdPersona.Text))
        EntidadConsultarProveedor.Equivalencia = TBBEquivalencia.Text
        EntidadConsultarProveedor.PrimerNombre = TBBNombrePersona.Text
        'EntidadConsultarPersona.IdEstado = IdEstadoCredito
        NegocioConsultarProveedor.ConsultarProveedor(EntidadConsultarProveedor)
        TablaConsultarPersona = EntidadConsultarProveedor.TablaConsulta
        GVConsultaPersona.Columns.Clear()
        GVConsultaPersona.DataSource = TablaConsultarPersona
        Dim Columna As New CommandField()
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsultaPersona.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Proveedor", "Proveedor")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Segundo Nombre", "SegundoNombre")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Apellido Paterno", "ApellidoPaterno")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Apellido Materno", "ApellidoMaterno")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Fecha de Nacimiento", "FechaNacimiento", "{0:d}")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultaPersona, New BoundField(), "Observaciones", "Observaciones")
        GVConsultaPersona.DataBind()
        Session("TablaConsultarPersona") = TablaConsultarPersona
        LabelRegistrosBuscarPersona.Text = "   Personas: " + TablaConsultarPersona.Rows.Count.ToString()
    End Sub

    Private Sub LimpiarConsulta()
        Try
            TablaConsultarPersona = CType(Session("TablaConsultarPersona"), DataTable)
            TablaConsultarPersona.Clear()
            Session("TablaConsultarPersona") = New DataTable()
            LabelRegistrosBuscarPersona.Text = ""
            TBBIdPersona.Text = ""
            TBBEquivalencia.Text = ""
            TBBNombrePersona.Text = ""
            GVConsultaPersona.DataSource = Nothing
            GVConsultaPersona.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GVConsultaPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsultaPersona.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim NegocioPersona As New Negocio.SolicitudCompra()
        Dim EntidadPersona As New Entidad.SolicitudCompra()
        Tabla = CType(Session("TablaConsultarPersona"), DataTable)

        TBIdPersona.Text = CInt(Tabla.Rows(GVConsultaPersona.SelectedIndex).Item("ID"))
        'TBEquivalencia.Text = CStr(Tabla.Rows(GVConsultaPersona.SelectedIndex).Item("Equivalencia"))
        TBNombre.Text = CStr(Tabla.Rows(GVConsultaPersona.SelectedIndex).Item("Proveedor"))

        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MPEConsultarPersona.Hide()
    End Sub
    Protected Sub TBEquivalencia_TextChanged(sender As Object, e As EventArgs) Handles TBEquivalencia.TextChanged
        TBIdPersona.Text = ""
        ObtenerPersona()
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub

    Private Sub ObtenerPersona()
        If IsNumeric(TBIdPersona.Text) Or TBEquivalencia.Text.Length > 1 Then
            Dim NegocioProveedor = New Negocio.Proveedor()
            Dim EntidadProveedor As New Entidad.Proveedor()
            EntidadProveedor.Tarjeta.Consulta = Consulta.ConsultaDetalladaPorId
            Dim IdProveedor = 0
            If IsNumeric(TBIdPersona.Text) Then
                IdProveedor = CInt(TBIdPersona.Text)
            End If
            EntidadProveedor.IdProveedor = IdProveedor
            EntidadProveedor.Equivalencia = TBEquivalencia.Text
            EntidadProveedor.PrimerNombre = ""
            NegocioProveedor.ConsultarProveedor(EntidadProveedor)
            Dim TablaPersona As New DataTable()
            TablaPersona = EntidadProveedor.TablaConsulta
            If EntidadProveedor.TablaConsulta.Rows.Count > 0 Then
                Try
                    TablaPersona.Select()
                    Dim _listaPersona As List(Of DataRow) = TablaPersona.AsEnumerable().ToList()
                    For Each rw As DataRow In _listaPersona
                        TBIdPersona.Text = CInt(rw.ItemArray(0))
                        TBEquivalencia.Text = rw.ItemArray(1)
                        TBNombre.Text = rw.ItemArray(2)
                    Next
                Catch ex As Exception
                    Dim a = ex.Message
                End Try
            Else
                TBIdPersona.Text = "0"
                TBEquivalencia.Text = ""
                TBNombre.Text = ""
            End If
        End If
    End Sub
    Protected Sub IBTNBuscarPersona_OnClick(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Buscar()
    End Sub
    Protected Sub TBIdPersona_TextChanged(sender As Object, e As EventArgs)
        TBEquivalencia.Text = ""
        ObtenerPersona()
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub

    Protected Sub IBTNCerrar_OnClick(sender As Object, e As EventArgs) Handles BTNCancelarBusqueda.Click
        LimpiarConsulta()
        MPEConsultarPersona.Hide()
        RaiseEvent CerarClick()
    End Sub
End Class
