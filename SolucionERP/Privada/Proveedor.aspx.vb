Imports System.Data

Namespace Catalogos
    Partial Class _Default
        Inherits Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                'Consultar()
                'ConsultarClasificacion()
                'DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
                'DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
                'DDClasificacion.SelectedValue = "1"
                'DDEstado.SelectedValue = "1"
                'MultiView1.SetActiveView(View1)
            End If
        End Sub

        Private Sub ConsultarClasificacion()
            'Dim NegocioClasificacion = New Negocio.Clasificacion()
            'Dim EntidadClasificacion As New Entidad.Clasificacion()
            'EntidadClasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            'NegocioClasificacion.Consultar(EntidadClasificacion)
            'DDClasificacion.DataSource = EntidadClasificacion.TablaConsulta
            'DDClasificacion.DataValueField = "ID"
            'DDClasificacion.DataTextField = "Descripcion"
            'DDClasificacion.DataBind()
        End Sub

        Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSubclasificacion.SelectedIndexChanged
            '    Dim Tabla = Session("Tabla")
            '    TBIdSubclasificacion.Text = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("ID"), String)
            '    TBDesSubclasificacion.Text = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("Descripcion"), String)
            '    DDClasificacion.SelectedValue = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("IDClasificacion"), String)
            '    TBGanancia.Text = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("Ganancia"), Double)
            '    CBGanancia.Checked = IIf(CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("Porcentaje"), Integer) = 1, True, False)
            '    DDEstado.SelectedValue = CType(Tabla.Rows(GVSubclasificacion.SelectedIndex).Item("IdEstado"), String)
            'End Sub
            'Public Sub Consultar()
            'Dim NegocioSubclasificacion = New Negocio.Subclasificacion()
            'Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
            'Dim Tabla As New DataTable
            'EntidadSubclasificacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
            'NegocioSubclasificacion.Consultar(EntidadSubclasificacion)
            'Tabla = EntidadSubclasificacion.TablaConsulta
            'GVSubclasificacion.Columns.Clear()
            'GVSubclasificacion.DataSource = Tabla
            'GVSubclasificacion.AutoGenerateColumns = False
            'GVSubclasificacion.AllowSorting = True
            'Dim Columna As New CommandField()
            'Columna.HeaderText = ""
            'Columna.HeaderText = "Seleccionar"
            'Columna.ButtonType = ButtonType.Link
            'Columna.ShowSelectButton = True
            'GVSubclasificacion.Columns.Add(Columna)
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "ID", "ID")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Subclasificacion", "Descripcion")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Clasificacion", "Clasificacion")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Fecha Creacion", "FechaCreacion")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Fecha Actualizacion", "FechaActualizacion")
            'Comun.Presentacion.Cuadricula.AgregarColumna(GVSubclasificacion, New BoundField(), "Estado", "Estado")
            'GVSubclasificacion.DataBind()
            'Session("Tabla") = Tabla
        End Sub

        Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
            'TBIdSubclasificacion.Text = ""
            'TBDesSubclasificacion.Text = ""
            'DDClasificacion.SelectedValue = "1"
            'DDEstado.SelectedValue = "1"
        End Sub

        Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
            'Dim NegocioSubclasificacion As New Negocio.Subclasificacion()
            'Dim EntidadSubclasificacion As New Entidad.Subclasificacion()
            'EntidadSubclasificacion.IdSubclasificacion = CInt(IIf(TBIdSubclasificacion.Text Is String.Empty, 0, TBIdSubclasificacion.Text))
            'EntidadSubclasificacion.Descripcion = TBDesSubclasificacion.Text
            'EntidadSubclasificacion.Ganancia = CDbl(TBGanancia.Text)
            'EntidadSubclasificacion.Porcentaje = IIf(CBGanancia.Checked = True, 1, 0)
            'EntidadSubclasificacion.IdClasificacion = CInt(DDClasificacion.SelectedValue)
            'EntidadSubclasificacion.IdEstado = CInt(DDEstado.SelectedValue)
            'NegocioSubclasificacion.Guardar(EntidadSubclasificacion)
            'Consultar()
            'TBIdSubclasificacion.Text = ""
            'TBDesSubclasificacion.Text = ""
            'TBGanancia.Text = ""
            'CBGanancia.Checked = False
            'DDEstado.SelectedValue = "1"
        End Sub

        Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
            ''codigo
        End Sub
    End Class
End Namespace