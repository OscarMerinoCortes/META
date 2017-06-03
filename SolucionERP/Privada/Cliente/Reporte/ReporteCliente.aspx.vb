Imports System.Data
Partial Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Reporte Cliente"
            DDTipoPersona.Items.Add(New ListItem("TODOS", -1))
            DDTipoPersona.Items.Add(New ListItem("FISICO", 1))
            DDTipoPersona.Items.Add(New ListItem("MORAL", 2))
            DDTipoPersona.SelectedValue = -1

            DDGenero.Items.Add(New ListItem("TODOS", -1))
            DDGenero.Items.Add(New ListItem("MASCULINO", 1))
            DDGenero.Items.Add(New ListItem("FEMENINO", 2))
            DDGenero.SelectedValue = -1

            DDEstado.Items.Add(New ListItem("TODOS", -1))
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = -1

            MultiView1.SetActiveView(View1)
        Else

        End If
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadReportePersona As New Entidad.ReportePersona()
        Dim TablaConsulta As New DataTable

        EntidadReportePersona.IdTipoPersona = DDTipoPersona.SelectedValue
        EntidadReportePersona.IdGenero = DDGenero.SelectedValue
        EntidadReportePersona.IdEstado = DDEstado.SelectedValue

        EntidadReportePersona.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        NegocioPersona.ReportePersona(EntidadReportePersona)
        TablaConsulta = EntidadReportePersona.TablaConsulta
        GVReporteCliente.Columns.Clear()
        GVReporteCliente.DataSource = TablaConsulta
        GVReporteCliente.AutoGenerateColumns = False
        GVReporteCliente.AllowSorting = True
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteCliente, New BoundField(), "ID", "IdPersona")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteCliente, New BoundField(), "Cliente", "Nombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteCliente, New BoundField(), "Genero", "Genero")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteCliente, New BoundField(), "Estado", "Estado")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVReporteCliente, New BoundField(), "Tipo Persona", "TipoPersona")
        GVReporteCliente.DataBind()
        Session("TablaConsulta") = TablaConsulta
    End Sub

    Protected Sub IBTReporte_Click(sender As Object, e As ImageClickEventArgs) Handles IBTReporte.Click
        Dim TablaReportePersona As New DataTable()
        Dim NegocioPersona As New Negocio.Persona()
        Dim EntidadReportePersona As New Entidad.ReportePersona()
        EntidadReportePersona.IdEstado = DDEstado.SelectedValue

        EntidadReportePersona.IdGenero = DDGenero.SelectedValue
        EntidadReportePersona.IdTipoPersona = DDTipoPersona.SelectedValue
        NegocioPersona.ReportePersona(EntidadReportePersona)
        TablaReportePersona = EntidadReportePersona.TablaConsulta
        Dim FileResponse As String = Comun.Presentacion.Cuadricula.ExportarTabla(TablaReportePersona, False, _
                                                                                 "Id,Cliente,Genero,Estado,TipoPersona", _
                                                                                 "IdPersona,Nombre,Genero,Estado,TipoPersona,")

        Dim Region As String = Request.QueryString("Region")
        Response.AddHeader("Content-disposition", "attachment; filename=ReporteCliente.csv")
        Response.ContentType = "text/csv"
        Response.Write(FileResponse)
        Response.End()
    End Sub

    Protected Sub IBTExportar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTExportar.Click

    End Sub

    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
End Class