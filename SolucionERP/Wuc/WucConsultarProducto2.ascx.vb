Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class WucConsultarProducto2
    Inherits System.Web.UI.UserControl
    Private TablaConsultarProducto As New DataTable()
    Public Event Seleccionado As EventHandler

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub
    Private Sub Buscar()
        LimpiarConsulta()
        MPEConsultarProducto.Show()
    End Sub
    Public Sub Nuevo()
        TBIdProducto.Text = ""
        TBIdProductoCorto.Text = ""
        TBDescripcion.Text = ""
    End Sub
    Public Sub ObtenerProducto(ByRef IdProducto As Integer, ByRef IdProductoCorto As String, ByRef Producto As String)
        'IdProducto = CInt(TBIdProducto.Text)
        'IdProductoCorto = TBIdProductoCorto.Text
        'Producto = TBDescripcion.Text
        IdProducto = CInt(IIf(TBIdProducto.Text Is String.Empty, 0, TBIdProducto.Text))
        IdProductoCorto = IIf(TBIdProductoCorto.Text Is String.Empty, 0, TBIdProductoCorto.Text)
        Producto = IIf(TBDescripcion.Text Is String.Empty, "0", TBDescripcion.Text)
    End Sub
    Public Sub AsignarProducto(IdProducto As Integer, IdProductoCorto As String, Producto As String)
        TBIdProducto.Text = CStr(IdProducto)
        TBIdProductoCorto.Text = IdProductoCorto
        TBDescripcion.Text = Producto
    End Sub
    Protected Sub GVBusquedaProducto_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub BTBuscarProducto_Click(sender As Object, e As EventArgs) Handles BTNBuscarProducto.Click
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()
        EntidadConsultarProducto.IdProducto = CInt(IIf(TBBIdProducto.Text = "" Or Not IsNumeric(TBBIdProducto.Text), 0, TBBIdProducto.Text))
        EntidadConsultarProducto.IdProductoCorto = CInt(IIf(TBBIdProducto.Text = "" Or Not IsNumeric(TBBIdProductoCorto.Text), 0, TBBIdProductoCorto.Text))
        EntidadConsultarProducto.Descripcion = CStr(IIf(TBBNombreProducto.Text = "", "", TBBNombreProducto.Text))
        EntidadConsultarProducto.Tarjeta.Consulta = Consulta.Ninguno
        NegocioConsultarProducto.Consultar(EntidadConsultarProducto)
        TablaConsultarProducto = EntidadConsultarProducto.TablaConsulta
        GVConsultarProducto.Columns.Clear()
        GVConsultarProducto.DataSource = TablaConsultarProducto
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConsultarProducto.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarProducto, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarProducto, New BoundField(), "Codigo", "ID Corto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarProducto, New BoundField(), "Descripcion", "Descripcion")
        GVConsultarProducto.DataBind()
        Session("TablaConsultarProducto") = TablaConsultarProducto
        LabelRegistrosBuscarProducto.Text = "   Productos: " + TablaConsultarProducto.Rows.Count.ToString()
    End Sub

    Private Sub LimpiarConsulta()
        Try
            TablaConsultarProducto = CType(Session("TablaConsultarProducto"), DataTable)
            TablaConsultarProducto.Clear()
            Session("TablaConsultarProducto") = New DataTable()
            LabelRegistrosBuscarProducto.Text = ""
            TBBIdProducto.Text = ""
            TBBIdProductoCorto.Text = ""
            TBBNombreProducto.Text = ""
            GVConsultarProducto.DataSource = Nothing
            GVConsultarProducto.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GVConsultarProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsultarProducto.SelectedIndexChanged
        Dim Tabla As New DataTable
        Dim NegocioProducto As New Negocio.SolicitudCompra()
        Dim EntidadProducto As New Entidad.SolicitudCompra()
        Tabla = CType(Session("TablaConsultarProducto"), DataTable)

        TBIdProducto.Text = CInt(Tabla.Rows(GVConsultarProducto.SelectedIndex).Item("ID"))
        TBIdProductoCorto.Text = CStr(Tabla.Rows(GVConsultarProducto.SelectedIndex).Item("ID Corto"))
        TBDescripcion.Text = CStr(Tabla.Rows(GVConsultarProducto.SelectedIndex).Item("Descripcion"))

        RaiseEvent Seleccionado(New Object, New EventArgs)
        LimpiarConsulta()
        MPEConsultarProducto.Hide()
    End Sub
    Protected Sub TBIdProductoCorto_TextChanged(sender As Object, e As EventArgs) Handles TBIdProductoCorto.TextChanged
        TBIdProducto.Text = "0"
        ObtenerProducto()
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub

    Private Sub ObtenerProducto()
        If IsNumeric(TBIdProducto.Text) Or TBIdProductoCorto.Text.Length > 1 Then
            Dim NegocioProducto = New Negocio.Producto()
            Dim EntidadProducto As New Entidad.Producto()
            EntidadProducto.Tarjeta.Consulta = Consulta.Ninguno
            EntidadProducto.IdProducto = TBIdProducto.Text
            EntidadProducto.IdProductoCorto = TBIdProductoCorto.Text
            EntidadProducto.Descripcion = ""
            NegocioProducto.Consultar(EntidadProducto)
            Dim TablaProducto As New DataTable()
            TablaProducto = EntidadProducto.TablaConsulta
            If EntidadProducto.TablaConsulta.Rows.Count > 0 Then
                Try
                    TablaProducto.Select()
                    Dim _listaProducto As List(Of DataRow) = TablaProducto.AsEnumerable().ToList()
                    For Each rw As DataRow In _listaProducto
                        TBIdProducto.Text = rw.ItemArray(0)
                        TBIdProductoCorto.Text = rw.ItemArray(1)
                        TBDescripcion.Text = rw.ItemArray(2)
                    Next
                Catch ex As Exception
                    Dim a = ex.Message
                End Try
            Else
                TBIdProducto.Text = "0"
                TBIdProductoCorto.Text = ""
                TBDescripcion.Text = ""
            End If
        End If
    End Sub
    Protected Sub IBTNBuscarProducto_OnClick(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Buscar()
    End Sub
    Protected Sub TBIdProducto_TextChanged(sender As Object, e As EventArgs)
        TBIdProductoCorto.Text = ""
        ObtenerProducto()
        RaiseEvent Seleccionado(New Object, New EventArgs)
    End Sub
    Protected Sub BTNCancelarBusqueda_Click(sender As Object, e As EventArgs)
        LimpiarConsulta()
        MPEConsultarProducto.Hide()
    End Sub
End Class
