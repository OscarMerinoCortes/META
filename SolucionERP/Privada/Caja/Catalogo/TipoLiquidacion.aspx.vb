Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Tipo Liquidacion"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            wucDatosAuditoria1.Visible = False
            SeleccionarView(0)
        End If
    End Sub

    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then
            Consultar()
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub

    Public Sub Consultar()
        Dim NegocioTipoLiquidacion As New Negocio.TipoLiquidacion()
        Dim EntidadTipoLiquidacion As New Entidad.TipoLiquidacion()
        Dim Tabla As New DataTable
        EntidadTipoLiquidacion.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioTipoLiquidacion.Consultar(EntidadTipoLiquidacion)
        Tabla = EntidadTipoLiquidacion.TablaConsulta
        GVTipoLiquidacion.Columns.Clear()
        GVTipoLiquidacion.DataSource = Tabla
        GVTipoLiquidacion.AutoGenerateColumns = False
        GVTipoLiquidacion.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVTipoLiquidacion.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoLiquidacion, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoLiquidacion, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVTipoLiquidacion, New BoundField(), "Estado", "Estado")
        GVTipoLiquidacion.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdTipoLiquidacion.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False

        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioTipoLiquidacion As New Negocio.TipoLiquidacion()
        Dim EntidadTipoLiquidacion As New Entidad.TipoLiquidacion()
        If TBIdTipoLiquidacion.Text Is String.Empty Then
            EntidadTipoLiquidacion.IdTipoLiquidacion = 0
        Else
            EntidadTipoLiquidacion.IdTipoLiquidacion = CInt(TBIdTipoLiquidacion.Text)
        End If
        EntidadTipoLiquidacion.Descripcion = TBDescripcion.Text
        EntidadTipoLiquidacion.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioTipoLiquidacion.Guardar(EntidadTipoLiquidacion)
        Consultar()
        TBIdTipoLiquidacion.Text = ""
        TBDescripcion.Text = ""
        DDEstado.SelectedValue = 1
        wucDatosAuditoria1.Visible = False
        SeleccionarView(0)
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub GVTipoLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVTipoLiquidacion.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdTipoLiquidacion.Text = Tabla.Rows(GVTipoLiquidacion.SelectedIndex).Item("ID")
        TBDescripcion.Text = Tabla.Rows(GVTipoLiquidacion.SelectedIndex).Item("Descripcion")
        DDEstado.SelectedValue = Tabla.Rows(GVTipoLiquidacion.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVTipoLiquidacion.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class