Imports System.Web.UI.MasterPage
Imports System.Data
Imports Operacion.Configuracion.Constante

Public Class WucConsultarProductoDetalle
    Inherits System.Web.UI.UserControl
    Private TablaConsultarProducto As New DataTable()
    Private PIdProducto As Integer
    Public Property IdProducto As Integer
        Get
            Return PIdProducto
        End Get
        Set(ByVal value As Integer)
            PIdProducto = value
            LBIDProducto.Text = value
        End Set
    End Property
    Public Event CerarClick()

    'Public Property IdProductoCorto As String
    '    Get
    '        Return PIdProductoCorto
    '    End Get
    '    Set(ByVal value As String)
    '        PIdProductoCorto = value
    '        TBIdProductoCorto.Text = value
    '    End Set
    'End Property

    'Public Property Descripcion As String
    '    Get
    '        Return PDescripcion
    '    End Get
    '    Set(ByVal value As String)
    '        PDescripcion = value
    '        TBDescripcion.Text = value
    '    End Set
    'End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If

    End Sub
    Private Sub Buscar()
       
    End Sub
    Public Sub Nuevo()
        IdProducto = 0
        'IdProductoCorto = ""
        'Descripcion = ""
    End Sub
    Public Sub ObtenerInformacion()
        Dim EntidadConsultarProducto As New Entidad.Producto()
        Dim NegocioConsultarProducto As New Negocio.Producto()

        EntidadConsultarProducto.IdProducto = CInt(PIdProducto)
        EntidadConsultarProducto.Tarjeta.Consulta = Consulta.ConsultaPorIdProducto
        NegocioConsultarProducto.Consultar(EntidadConsultarProducto)

        TablaConsultarProducto = EntidadConsultarProducto.TablaConsulta
        GVConsultarProductoDetalle.Columns.Clear()
        GVConsultarProductoDetalle.DataSource = TablaConsultarProducto

        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarProductoDetalle, New BoundField(), "Sucursal", "Sucursal")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarProductoDetalle, New BoundField(), "Almacen", "Almacen")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConsultarProductoDetalle, New BoundField(), "Existencia", "Existencia")

        GVConsultarProductoDetalle.DataBind()
        Session("TablaConsultarProducto") = TablaConsultarProducto
        AsignarValores()
        MPEConsultarProductoDetalle.Show()
    End Sub

    Private Sub AsignarValores()
        Dim tabla As New DataTable()
        tabla = CType(Session("TablaConsultarProducto"), DataTable)
        LBIdProductoCorto.Text = tabla.Rows(0).Item("IdProductoCorto")
        LBDescripcion.Text = tabla.Rows(0).Item("Descripcion")
        LBClasificacion.Text = tabla.Rows(0).Item("Clasificacion")
        LBSubClasificacion.Text = tabla.Rows(0).Item("SubClasificacion")
    End Sub

    Protected Sub IBTNCerrar_OnClick(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        'LimpiarConsulta()
        'MPEConsultarProducto.Hide()
    End Sub
    'Protected Sub GVConsultarProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConsultarProducto.SelectedIndexChanged
    '    'Dim Tabla As New DataTable
    '    'Dim NegocioProducto As New Negocio.SolicitudCompra()
    '    'Dim EntidadProducto As New Entidad.SolicitudCompra()
    '    'Tabla = CType(Session("TablaConsultarProducto"), DataTable)

    '    'IdProducto = CInt(Tabla.Rows(GVConsultarProducto.SelectedIndex).Item("ID"))
    '    'IdProductoCorto = CStr(Tabla.Rows(GVConsultarProducto.SelectedIndex).Item("ID Corto"))
    '    'Descripcion = CStr(Tabla.Rows(GVConsultarProducto.SelectedIndex).Item("Descripcion"))

    '    'LimpiarConsulta()
    '    'MPEConsultarProducto.Hide()
    'End Sub
    'Protected Sub TBIdProductoCorto_TextChanged(sender As Object, e As EventArgs) Handles TBIdProductoCorto.TextChanged
    '    IdProducto = 0
    '    ObtenerProducto()
    'End Sub

    Private Sub ObtenerProducto()
        'If IsNumeric(LBIDProducto.Text) Then
        '    Dim NegocioProducto = New Negocio.Producto()
        '    Dim EntidadProducto As New Entidad.Producto()

        '    EntidadProducto.Tarjeta.Consulta = Consulta.ConsultaPorIdProducto
        '    IdProducto = IIf(IsNumeric(LBIDProducto.Text), CInt(LBIDProducto.Text), 0)
        '    'IdProductoCorto = TBIdProductoCorto.Text
        '    EntidadProducto.IdProducto = IdProducto
        '    'EntidadProducto.IdProductoCorto = IdProductoCorto
        '    EntidadProducto.Descripcion = ""
        '    NegocioProducto.Consultar(EntidadProducto)
        '    Dim TablaProducto As New DataTable()
        '    TablaProducto = EntidadProducto.TablaConsulta
        '    If EntidadProducto.TablaConsulta.Rows.Count > 0 Then
        '        Try
        '            TablaProducto.Select()
        '            Dim _listaProducto As List(Of DataRow) = TablaProducto.AsEnumerable().ToList()
        '            For Each rw As DataRow In _listaProducto
        '                LBIDProducto.Text = CInt(rw.ItemArray(0))
        '                'IdProductoCorto = rw.ItemArray(1)
        '                'Descripcion = rw.ItemArray(2)
        '            Next
        '        Catch ex As Exception
        '            Dim a = ex.Message
        '        End Try
        '    Else
        '        'TBIdProducto.Text = "0"
        '        'TBIdProductoCorto.Text = ""
        '        'TBDescripcion.Text = ""
        '    End If
        'End If
    End Sub
    'Protected Sub IBTNBuscarProducto_OnClick(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
    '    Buscar()
    'End Sub
    Protected Sub TBIdProducto_TextChanged(sender As Object, e As EventArgs)
        'IdProductoCorto = ""
        'ObtenerProducto()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        RaiseEvent CerarClick()
    End Sub
End Class
