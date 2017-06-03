Imports System.Data
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports Comun.Presentacion
Imports Operacion.Configuracion.Constante
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Calculo Plazo"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            'OBTENER LOS PALZOS DE LA TABLA ERP_TIPO_PLAZO
            Dim NegocioCalculoPlazo = New Negocio.CalculoPlazoCompra()
            Dim EntidadCalculoPlazo As New Entidad.CalculoPlazoCompra()
            EntidadCalculoPlazo.Tarjeta.Consulta = Consulta.ConsultaBasica
            NegocioCalculoPlazo.Consultar(EntidadCalculoPlazo)
            'EntidadCalculoPlazo.TablaConsulta.Rows.Add(-1, "TODO", 1, "ACTIVO")
            DDIdTipoPlazoContado.DataSource = EntidadCalculoPlazo.TablaConsulta
            DDIdTipoPlazoContado.DataValueField = "IdTipoPlazo"
            DDIdTipoPlazoContado.DataTextField = "Descripcion"
            DDIdTipoPlazoContado.DataBind()
            DDIdTipoPlazoContado.SelectedValue = -1
            'para el DD de credito
            DDIdTipoPlazoCredito.DataSource = EntidadCalculoPlazo.TablaConsulta
            DDIdTipoPlazoCredito.DataValueField = "IdTipoPlazo"
            DDIdTipoPlazoCredito.DataTextField = "Descripcion"
            DDIdTipoPlazoCredito.DataBind()
            DDIdTipoPlazoCredito.SelectedValue = -1
            wucDatosAuditoria1.Visible = False
            SeleccionarView(0)
        End If
    End Sub
    Private Sub SeleccionarView(v As Integer)
        If v = 0 Then
            MultiView1.SetActiveView(VConsulta)
            IBTGuardar.Visible = False
        Else
            MultiView1.SetActiveView(VRegistro)
            IBTGuardar.Visible = True
        End If
    End Sub
    Public Sub Consultar()
        Dim NegocioCalculoPlazo As New Negocio.CalculoPlazoCompra()
        Dim EntidadCalculoPlazo As New Entidad.CalculoPlazoCompra()
        Dim Tabla As New DataTable
        EntidadCalculoPlazo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioCalculoPlazo.Consultar(EntidadCalculoPlazo)
        Tabla = EntidadCalculoPlazo.TablaConsulta
        GVConfiguracionPlazo.Columns.Clear()
        GVConfiguracionPlazo.DataSource = Tabla
        GVConfiguracionPlazo.AutoGenerateColumns = False
        GVConfiguracionPlazo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVConfiguracionPlazo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConfiguracionPlazo, New BoundField(), "ID", "IdConfiguracionCalculoPlazo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConfiguracionPlazo, New BoundField(), "Precio Inicio", "PrecioInicio")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConfiguracionPlazo, New BoundField(), "Precio Fin", "PrecioFin")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConfiguracionPlazo, New BoundField(), "Plazo Contado", "PlazoContado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConfiguracionPlazo, New BoundField(), "Plazo Credito", "PlazoCredito")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVConfiguracionPlazo, New BoundField(), "Estado", "Estado")
        GVConfiguracionPlazo.DataBind()
        Session("Tabla") = Tabla
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdCalculoPlazo.Text = ""
        TBPrecioInicio.Text = ""
        TBPrecioFin.Text = ""
        DDIdTipoPlazoContado.SelectedValue = 1
        DDIdTipoPlazoCredito.SelectedValue = 1
        DDEstado.SelectedValue = 1
        SeleccionarView(1)
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioCalculoPlazo As New Negocio.CalculoPlazoCompra()
        Dim EntidadCalculoPlazo As New Entidad.CalculoPlazoCompra()
        EntidadCalculoPlazo.IdConfiguracionCalculo = IIf(TBIdCalculoPlazo.Text Is String.Empty, 0, TBIdCalculoPlazo.Text)
        EntidadCalculoPlazo.PrecioInicio = CInt(TBPrecioInicio.Text)
        EntidadCalculoPlazo.PrecioFin = CInt(TBPrecioFin.Text)
        EntidadCalculoPlazo.IdTipoPlazoContado = CInt(DDIdTipoPlazoContado.SelectedValue)
        EntidadCalculoPlazo.IdTipoPlazoCredito = CInt(DDIdTipoPlazoCredito.SelectedValue)
        EntidadCalculoPlazo.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioCalculoPlazo.Guardar(EntidadCalculoPlazo)
        Consultar()
        SeleccionarView(0)
        TBIdCalculoPlazo.Text = EntidadCalculoPlazo.IdConfiguracionCalculo
        TBPrecioInicio.Text = ""
        TBPrecioFin.Text = ""
        DDIdTipoPlazoContado.SelectedValue = 1
        DDIdTipoPlazoCredito.SelectedValue = 1
        DDEstado.SelectedValue = 1
    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Consultar()
        SeleccionarView(0)
    End Sub

    Protected Sub GVImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVConfiguracionPlazo.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdCalculoPlazo.Text = Tabla.Rows(GVConfiguracionPlazo.SelectedIndex).Item("IdConfiguracionCalculoPlazo")
        TBPrecioInicio.Text = Tabla.Rows(GVConfiguracionPlazo.SelectedIndex).Item("PrecioInicio")
        TBPrecioFin.Text = Tabla.Rows(GVConfiguracionPlazo.SelectedIndex).Item("PrecioFin")
        DDIdTipoPlazoContado.SelectedValue = Tabla.Rows(GVConfiguracionPlazo.SelectedIndex).Item("IdTipoPlazoContado")
        DDIdTipoPlazoCredito.SelectedValue = Tabla.Rows(GVConfiguracionPlazo.SelectedIndex).Item("IdTipoPlazoCredito")
        DDEstado.SelectedValue = Tabla.Rows(GVConfiguracionPlazo.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVConfiguracionPlazo.SelectedIndex))
        SeleccionarView(1)
    End Sub
End Class