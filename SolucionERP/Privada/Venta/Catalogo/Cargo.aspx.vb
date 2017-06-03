Imports System.Data
Imports Operacion.Configuracion.Constante

Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Cargo"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", "1"))
            DDEstado.Items.Add(New ListItem("INACTIVO", "2"))
            DDEstado.SelectedValue = "1"


            DDTipoMonto.Items.Add(New ListItem("MONTO", "0"))
            DDTipoMonto.Items.Add(New ListItem("PORCENTAJE", "1"))
            DDTipoMonto.SelectedValue = "1"

            DDAgregaAuto.Items.Add(New ListItem("NO", "0"))
            DDAgregaAuto.Items.Add(New ListItem("SI", "1"))
            DDAgregaAuto.SelectedValue = "0"

            Dim NegocioTipoCargo = New Negocio.TipoCargo()
            Dim EntidadTipoCargo As New Entidad.TipoCargo()
            EntidadTipoCargo.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioTipoCargo.Consultar(EntidadTipoCargo)
            DDTipoCargo.DataSource = EntidadTipoCargo.TablaConsulta
            DDTipoCargo.DataValueField = "ID"
            DDTipoCargo.DataTextField = "Descripcion"
            DDTipoCargo.DataBind()

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
        Dim NegocioCargo As New Negocio.Cargo()
        Dim EntidadCargo As New Entidad.Cargo()
        Dim Tabla As New DataTable
        EntidadCargo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioCargo.ConsultarVenta(EntidadCargo)
        Tabla = EntidadCargo.TablaConsulta
        GVCargo.Columns.Clear()
        GVCargo.DataSource = Tabla
        GVCargo.AutoGenerateColumns = False
        GVCargo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVCargo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "Equivalencia", "Equivalencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "Descripcion", "Descripcion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "Monto", "Monto")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVCargo, New BoundField(), "Estado", "Estado")
        GVCargo.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Limpiar()
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioCargo As New Negocio.Cargo()
        Dim EntidadCargo As New Entidad.Cargo()
        If TBIdCargo.Text Is String.Empty Then
            EntidadCargo.IdCargo = 0
        Else
            EntidadCargo.IdCargo = CInt(TBIdCargo.Text)
        End If
        If TBMonto.Text Is String.Empty Then
            EntidadCargo.Monto = 0
        Else
            EntidadCargo.Monto = CDbl(TBMonto.Text)
        End If
        EntidadCargo.Descripcion = TBDescripcion.Text.ToUpper()
        EntidadCargo.Equivalencia = TBEquivalencia.Text.ToUpper()
        EntidadCargo.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadCargo.IdAutomatico = CInt(DDAgregaAuto.SelectedValue)
        EntidadCargo.IdTipoMonto = CInt(DDTipoMonto.SelectedValue)
        EntidadCargo.IdTipoCargo = CInt(DDTipoCargo.SelectedValue)
        NegocioCargo.GuardarVenta(EntidadCargo)
        Consultar()
        Limpiar()
        SeleccionarView(0)
    End Sub

    Private Sub Limpiar()
        TBIdCargo.Text = ""
        TBDescripcion.Text = ""
        TBEquivalencia.Text = ""
        TBMonto.Text = "0"
        DDEstado.SelectedValue = "1"
        DDTipoMonto.SelectedValue = "1"
        DDAgregaAuto.SelectedValue = "0"
        wucDatosAuditoria1.Visible = False
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
    End Sub

    Protected Sub GVCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCargo.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = CType(Session("Tabla"), DataTable)
        TBIdCargo.Text = Tabla.Rows(GVCargo.SelectedIndex).Item("ID").ToString()
        TBEquivalencia.Text = Tabla.Rows(GVCargo.SelectedIndex).Item("Equivalencia").ToString()
        TBDescripcion.Text = Tabla.Rows(GVCargo.SelectedIndex).Item("Descripcion").ToString()
        TBMonto.Text = Tabla.Rows(GVCargo.SelectedIndex).Item("Monto").ToString()
        DDTipoMonto.SelectedValue = Tabla.Rows(GVCargo.SelectedIndex).Item("IdTipoMonto").ToString()
        DDTipoCargo.SelectedValue = Tabla.Rows(GVCargo.SelectedIndex).Item("IdTipoCargo").ToString()
        DDAgregaAuto.SelectedValue = Tabla.Rows(GVCargo.SelectedIndex).Item("IdAutomatico").ToString()
        DDEstado.SelectedValue = Tabla.Rows(GVCargo.SelectedIndex).Item("IdEstado").ToString()

        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVCargo.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class