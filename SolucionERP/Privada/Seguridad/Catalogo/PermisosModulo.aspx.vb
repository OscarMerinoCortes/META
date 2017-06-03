Imports System.Data
Imports System.Drawing.Color
Partial Class _Default
    Inherits Page
    Public TablaOpcionesTotales As New DataTable()
    'Private VistaSeguridadOpciones As New DataView()
    'Public TablaSeguridadAcciones As New DataTable()
    'Private VistaSeguridadAcciones As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Permisos Por Rol"
            Dim NegocioUsuario As New Negocio.TipoUsuario()
            Dim EntidadUsuario As New Entidad.TipoUsuario()
            EntidadUsuario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioUsuario.Consultar(EntidadUsuario)
            DDTipoUsuario.DataSource = EntidadUsuario.TablaConsulta
            DDTipoUsuario.DataValueField = "ID"
            DDTipoUsuario.DataTextField = "Descripcion"
            DDTipoUsuario.DataBind()
            DDTipoUsuario.SelectedIndex = 0

            TablaOpcionesTotales.Columns.Clear()
            TablaOpcionesTotales.Columns.Add(New DataColumn("IdTipoUsuario", Type.GetType("System.Int32")))
            TablaOpcionesTotales.Columns.Add(New DataColumn("IdOpcion", Type.GetType("System.Int32")))
            TablaOpcionesTotales.Columns.Add(New DataColumn("IdAcceso", Type.GetType("System.Int32")))

            Session("TablaOpcionesTotales") = TablaOpcionesTotales

            If DDTipoUsuario.SelectedValue = 1 Then
                IBTGuardar.Enabled = False
            Else
                IBTGuardar.Enabled = True
            End If
            ConsultarModulo()
            ' ConsultarOpcionesTotales()
        End If
    End Sub
    Public Sub ConsultarModulo()
        Dim NegocioModulo As New Negocio.MenuModulo()
        Dim EntidadModulo As New Entidad.MenuModulo()
        Dim Tabla As New DataTable
        EntidadModulo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        EntidadModulo.IdTipoUsuario = DDTipoUsuario.SelectedValue
        NegocioModulo.Obtener(EntidadModulo)
        Tabla = EntidadModulo.TablaConsulta
        'GVModulos1.Columns.Clear()
        GVModulos.DataSource = Tabla
        GVModulos.AutoGenerateColumns = False
        GVModulos.AllowSorting = True
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Seleccionar"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        'GVModulos1.Columns.Add(Columna)
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVModulos, New BoundField(), "ID", "IdModulo")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVModulos, New BoundField(), "Modulo", "DescripcionModulo")
        GVModulos.DataBind()
        Session("TablaModulo") = Tabla
        GVModulos.DataSource = Tabla
        GVModulos.DataBind()
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVModulos.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = Tabla.NewRow()
            If Tabla.Rows(Index).Item("IdAcceso") = 1 Then
                CType(MiDataRow2.FindControl("CBGVAccesoModulo"), CheckBox).Checked = True
            Else
                CType(MiDataRow2.FindControl("CBGVAccesoModulo"), CheckBox).Checked = False
            End If
        Next
    End Sub
    Public Sub ConsultarOpcionesTotales()
        'Dim NegocioModulo As New Negocio.MenuModulo()
        'Dim EntidadModulo As New Entidad.MenuModulo()
        'Dim Tabla As New DataTable
        'EntidadModulo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        'EntidadModulo.IdTipoUsuario = DDTipoUsuario.SelectedValue
        'NegocioModulo.Obtener(EntidadModulo)
        'Tabla = EntidadModulo.TablaConsulta
        'Session("TablaOpcionesTotales") = Tabla

    End Sub
    Public Sub ConsultarOpcion(IdModulo As Integer)
        Dim NegocioModulo As New Negocio.MenuModulo()
        Dim EntidadModulo As New Entidad.MenuModulo()
        Dim Tabla As New DataTable
        EntidadModulo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
        EntidadModulo.IdModulo = IdModulo
        EntidadModulo.IdTipoUsuario = DDTipoUsuario.SelectedValue
        NegocioModulo.Obtener(EntidadModulo)
        Tabla = EntidadModulo.TablaConsulta
        'GVOpcion.Columns.Clear()
        GVOpcion.DataSource = Tabla
        GVOpcion.AutoGenerateColumns = False
        GVOpcion.AllowSorting = True
        'Dim Columna As New CommandField()
        'Columna.HeaderText = ""
        'Columna.HeaderText = "Seleccionar"
        'Columna.ButtonType = ButtonType.Link
        'Columna.ShowSelectButton = True
        ''GVOpcion.Columns.Add(Columna)
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVOpcion, New BoundField(), "ID", "IdOpcion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVOpcion, New BoundField(), "Opcion", "Descripcion")
        GVOpcion.DataBind()
        Session("TablaOpcion") = Tabla
        Dim Index As Integer
        For Each MiDataRow2 As GridViewRow In GVOpcion.Rows
            Index = Convert.ToUInt64(MiDataRow2.RowIndex)
            Dim NuevoRow As DataRow = Tabla.NewRow()
            If Tabla.Rows(Index).Item("IdAcceso") = 1 Then
                CType(MiDataRow2.FindControl("CBGVAccesoOpcion"), CheckBox).Checked = True
            Else
                CType(MiDataRow2.FindControl("CBGVAccesoOpcion"), CheckBox).Checked = False
            End If
        Next
    End Sub
    Public Sub ConsultarAccion(IdOpcion As Integer)
        Dim NegocioModulo As New Negocio.MenuModulo()
        Dim EntidadModulo As New Entidad.MenuModulo()
        Dim Tabla As New DataTable
        EntidadModulo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
        EntidadModulo.IdOpcion = IdOpcion
        NegocioModulo.Obtener(EntidadModulo)
        Tabla = EntidadModulo.TablaConsulta
        GVAccion.Columns.Clear()
        GVAccion.DataSource = Tabla
        GVAccion.AutoGenerateColumns = False
        GVAccion.AllowSorting = True
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAccion, New BoundField(), "ID", "IdTransaccion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVAccion, New BoundField(), "Transaccion", "Descripcion")
        GVAccion.DataBind()
        Session("TablaAccion") = Tabla
    End Sub
    Protected Sub BTNSeleccionarModulo_OnClick(sender As Object, e As EventArgs)
        'Dim TablaOpciones As New DataTable
        'Dim TablaOpcionesTotales As New DataTable
        'TablaOpciones = Session("TablaOpcion")
        'TablaOpcionesTotales = Session("TablaOpcionesTotales")


        'Dim Index As Integer
        'For Each MiDataRow As GridViewRow In GVOpcion.Rows
        '    If CType(MiDataRow.FindControl("CBGVAccesoModulo"), CheckBox).Checked = True Then
        '        Index = Convert.ToUInt64(MiDataRow.RowIndex)
        '        TablaOpcionesTotales.Rows(Index).Item("IdAcceso") = 1
        '    Else
        '        Index = Convert.ToUInt64(MiDataRow.RowIndex)
        '        TablaOpcionesTotales.Rows(Index).Item("IdAcceso") = 0
        '    End If
        'Next
        Dim TBResponsable As LinkButton = CType(sender, LinkButton)
        Dim gvrFilaActual As GridViewRow = DirectCast(DirectCast(TBResponsable.Parent, DataControlFieldCell).Parent, GridViewRow)
        Dim index As Integer = gvrFilaActual.RowIndex
        Dim Renglon As Integer = GVModulos.SelectedIndex

        ''GVModulos.SelectedRowStyle.CssClass = Drawing.Color.Gold

        For Each MiDataRow As GridViewRow In GVModulos.Rows
            GVModulos.Rows(MiDataRow.RowIndex).CssClass = "alt"
        Next
        'GVModulos.CssClass = "GridComun"
        GVModulos.Rows(index).CssClass = "color"

        Dim Tabla As New DataTable
        Tabla = Session("TablaModulo")
        ConsultarOpcion(Tabla.Rows(index).Item("IdModulo"))
    End Sub
    'Protected Sub GVOpcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVOpcion.SelectedIndexChanged
    '    Dim Renglon As Integer = GVOpcion.SelectedIndex
    '    Dim Tabla As New DataTable
    '    Tabla = Session("TablaOpcion")
    '    ConsultarAccion(Tabla.Rows(Renglon).Item("IdOpcion"))
    'End Sub
    Protected Sub DDTipoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDTipoUsuario.SelectedIndexChanged
        ConsultarModulo()
        TablaOpcionesTotales = CType(Session("TablaOpcionesTotales"), DataTable)
        TablaOpcionesTotales.Rows.Clear()
        Session("TablaOpcionesTotales") = TablaOpcionesTotales
        If DDTipoUsuario.SelectedValue = 1 Then
            IBTGuardar.Enabled = False
        Else
            IBTGuardar.Enabled=True
        End If
        'ConsultarOpcionesTotales()
    End Sub

    Protected Sub CBGVAccesoModulo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Tabla As New DataTable
        Tabla = CType(Session("TablaModulo"), DataTable)
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVModulos.Rows
            If CType(MiDataRow.FindControl("CBGVAccesoModulo"), CheckBox).Checked = True Then
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                Tabla.Rows(Index).Item("IdAcceso") = 1
            Else
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                Tabla.Rows(Index).Item("IdAcceso") = 0
            End If
        Next

        Session("TablaModulo") = Tabla
    End Sub
    Protected Sub CBGVAccesoOpcion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Tabla As New DataTable
        Dim TablaOpcion As New DataTable

        Dim dr As DataRow
        Tabla = CType(Session("TablaOpcionesTotales"), DataTable)
        TablaOpcion = Session("TablaOpcion")

        Tabla.PrimaryKey = New DataColumn() {Tabla.Columns("IdOpcion")}
        'Dim Tabla1 As DataRow()
        'Tabla1 = Tabla.Select("IdOpcion=100")
        Dim Index As Integer
        For Each MiDataRow As GridViewRow In GVOpcion.Rows
            If CType(MiDataRow.FindControl("CBGVAccesoOpcion"), CheckBox).Checked = True Then
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                dr = Tabla.Rows.Find(TablaOpcion.Rows(Index).Item("IdOpcion"))
                If dr Is Nothing Then
                    'No se encontró la fila. Crear nueva fila
                    dr = Tabla.NewRow()
                    dr("IdOpcion") = TablaOpcion.Rows(Index).Item("IdOpcion")
                    dr("IdTipoUsuario") = DDTipoUsuario.SelectedValue
                    dr("IdAcceso") = 1
                    Tabla.Rows.Add(dr)
                Else
                    'Fila encontrada
                    dr("IdAcceso") = 1
                End If
            Else
                Index = Convert.ToUInt64(MiDataRow.RowIndex)
                dr = Tabla.Rows.Find(TablaOpcion.Rows(Index).Item("IdOpcion"))
                If dr Is Nothing Then
                    'No se encontró la fila. Crear nueva fila
                    dr = Tabla.NewRow()
                    dr("IdOpcion") = TablaOpcion.Rows(Index).Item("IdOpcion")
                    dr("IdTipoUsuario") = DDTipoUsuario.SelectedValue
                    dr("IdAcceso") = 0
                    Tabla.Rows.Add(dr)
                Else
                    'Fila encontrada
                    dr("IdAcceso") = 0
                End If
            End If
        Next
        Session("TablaOpcionesTotales") = Tabla
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim EntidadSeguridad As New Entidad.Seguridad()
        Dim TablaOpciones As DataTable
        Dim TablaModulos As DataTable
        TablaOpciones = Session("TablaOpcionesTotales")
        TablaModulos = Session("TablaModulo")
        EntidadSeguridad.TablaOpciones = TablaOpciones
        EntidadSeguridad.TablaModulos = TablaModulos
        Seguridad.Autorizacion.Opcion.PermisosOpcion(EntidadSeguridad)
    End Sub
    Protected Sub GVModulos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVModulos.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    If e.Row.Cells(12).Text = "R" Then
        '        e.Row.CssClass = "Rojo"
        '    ElseIf e.Row.Cells(12).Text = "B" Then
        '        e.Row.CssClass = "Azul"
        '    ElseIf e.Row.Cells(12).Text = "Y" Then
        '        e.Row.CssClass = "Amarillo"
        '    Else
        '        e.Row.CssClass = "Verde"
        '    End If
        'End If
    End Sub
End Class