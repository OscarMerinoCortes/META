Imports System.Data
Partial Class _Default
    Inherits Page
    Public TablaArqueo As New DataTable()
    Public VistaArqueo As New DataView()
    Public TablaArqueoDetalle As New DataTable()
    Public VistaArqueoDetalle As New DataView()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Arqueo"
            '====================================================Referencia========================================================
            TablaArqueo.Columns.Clear()
            TablaArqueo.Columns.Add(New DataColumn("IdArqueo", Type.GetType("System.Int32")))
            TablaArqueo.Columns.Add(New DataColumn("IdArqueoDetalle", Type.GetType("System.Int32")))
            TablaArqueo.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.Int32")))
            TablaArqueo.Columns.Add(New DataColumn("Valor", Type.GetType("System.Double")))
            TablaArqueo.Columns.Add(New DataColumn("Total", Type.GetType("System.Double")))
            TablaArqueo.Columns.Add(New DataColumn("IdActualizar", Type.GetType("System.Int32")))
            Session("TablaArqueo") = TablaArqueo
            Session("VistaArqueo") = VistaArqueo
            InicializarLabel()
            InicializarTextBox()
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            wucDatosAuditoria1.Visible = True
            SeleccionarView(0)
        End If
        TBBillete1000.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBBillete500.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBBillete200.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBBillete100.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBBillete50.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBBillete20.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda20.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda10.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda5.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda2.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda1.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda050.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda020.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda010.Attributes("onchange") = "if (IsValid(this)=false)return;"
        TBMoneda005.Attributes("onchange") = "if (IsValid(this)=false)return;"
    End Sub
    Public Sub InicializarLabel()
        LBB1000.Text = 0
        LBB500.Text = 0
        LBB200.Text = 0
        LBB100.Text = 0
        LBB50.Text = 0
        LBB20.Text = 0
        LBM20.Text = 0
        LBM10.Text = 0
        LBM5.Text = 0
        LBM2.Text = 0
        LBM1.Text = 0
        LBM050.Text = 0
        LBM020.Text = 0
        LBM010.Text = 0
        LBM005.Text = 0
        LBDLL.Text = 0
        LBTOTAL.Text = 0
    End Sub
    Public Sub InicializarTextBox()
        TBBillete1000.Text = 0
        TBBillete500.Text = 0
        TBBillete200.Text = 0
        TBBillete100.Text = 0
        TBBillete50.Text = 0
        TBBillete20.Text = 0
        TBMoneda20.Text = 0
        TBMoneda10.Text = 0
        TBMoneda5.Text = 0
        TBMoneda2.Text = 0
        TBMoneda1.Text = 0
        TBMoneda050.Text = 0
        TBMoneda020.Text = 0
        TBMoneda010.Text = 0
        TBMoneda005.Text = 0
        TBDolares.Text = 0
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
        Dim NegocioArqueo As New Negocio.Arqueo()
        Dim EntidadArqueo As New Entidad.Arqueo()
        Dim Tabla As New DataTable
        EntidadArqueo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        NegocioArqueo.Consultar(EntidadArqueo)
        Tabla = EntidadArqueo.TablaConsulta
        GVArqueo.Columns.Clear()
        GVArqueo.DataSource = Tabla
        GVArqueo.AutoGenerateColumns = False
        GVArqueo.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVArqueo.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVArqueo, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVArqueo, New BoundField(), "Observacion", "Observacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVArqueo, New BoundField(), "Sucursal", "Sucursal")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVArqueo, New BoundField(), "Caja", "Caja")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVArqueo, New BoundField(), "Estado", "Estado")
        GVArqueo.DataBind()
        Session("Tabla") = Tabla
        BTNSumar.CssClass = "BotonCorrecto"
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        TBIdArqueo.Text = ""
        TBObservacion.Text = ""
        DDEstado.SelectedValue = 1
        TablaArqueo = Session("TablaArqueo")
        TablaArqueo.Rows.Clear()
        Session("TablaArqueo") = TablaArqueo
        wucDatosAuditoria1.Visible = False
        InicializarTextBox()
        InicializarLabel()
        SeleccionarView(1)
        BTNSumar.CssClass = "BotonCorrecto"
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioArqueo As New Negocio.Arqueo()
        Dim EntidadArqueo As New Entidad.Arqueo()
        TablaArqueo = Session("TablaArqueo")

        If TablaArqueo.Rows.Count = 0 Then
            BTNSumar.CssClass = "BotonError"
            Exit Sub
        End If
        If TBIdArqueo.Text Is String.Empty Then
            EntidadArqueo.IdArqueo = 0
        Else
            EntidadArqueo.IdArqueo = CInt(TBIdArqueo.Text)
        End If
        EntidadArqueo.IdSucursal = 1
        EntidadArqueo.IdCaja = 1
        EntidadArqueo.Observacion = TBObservacion.Text
        EntidadArqueo.IdEstado = CInt(DDEstado.SelectedValue)
        EntidadArqueo.TablaArqueo = TablaArqueo        
        NegocioArqueo.Guardar(EntidadArqueo)
        Consultar()       
        SeleccionarView(0)
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub
    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
        Consultar()
    End Sub

    Protected Sub GVRuta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVArqueo.SelectedIndexChanged
        Dim EntidadArqueo As New Entidad.Arqueo()
        Dim NegocioArqueo As New Negocio.Arqueo()
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdArqueo.Text = Tabla.Rows(GVArqueo.SelectedIndex).Item("ID")
        TBObservacion.Text = Tabla.Rows(GVArqueo.SelectedIndex).Item("Observacion")
        DDEstado.SelectedValue = Tabla.Rows(GVArqueo.SelectedIndex).Item("IdEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVArqueo.SelectedIndex))
        '========================================================================        
        EntidadArqueo.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadArqueo.IdArqueo = TBIdArqueo.Text
        NegocioArqueo.Obtener(EntidadArqueo)
        TablaArqueo = EntidadArqueo.TablaArqueo
        VistaArqueo = TablaArqueo.DefaultView
        '========================================================================
        TBBillete1000.Text = TablaArqueo.Rows(0).Item("Cantidad")
        LBB1000.Text = TablaArqueo.Rows(0).Item("Total")
        TBBillete500.Text = TablaArqueo.Rows(1).Item("Cantidad")
        LBB500.Text = TablaArqueo.Rows(1).Item("Total")
        TBBillete200.Text = TablaArqueo.Rows(2).Item("Cantidad")
        LBB200.Text = TablaArqueo.Rows(2).Item("Total")
        TBBillete100.Text = TablaArqueo.Rows(3).Item("Cantidad")
        LBB100.Text = TablaArqueo.Rows(3).Item("Total")
        TBBillete50.Text = TablaArqueo.Rows(4).Item("Cantidad")
        LBB50.Text = TablaArqueo.Rows(4).Item("Total")
        TBBillete20.Text = TablaArqueo.Rows(5).Item("Cantidad")
        LBB20.Text = TablaArqueo.Rows(5).Item("Total")
        TBMoneda20.Text = TablaArqueo.Rows(6).Item("Cantidad")
        LBM20.Text = TablaArqueo.Rows(6).Item("Total")
        TBMoneda10.Text = TablaArqueo.Rows(7).Item("Cantidad")
        LBM10.Text = TablaArqueo.Rows(7).Item("Total")
        TBMoneda5.Text = TablaArqueo.Rows(8).Item("Cantidad")
        LBM5.Text = TablaArqueo.Rows(8).Item("Total")
        TBMoneda2.Text = TablaArqueo.Rows(9).Item("Cantidad")
        LBM2.Text = TablaArqueo.Rows(9).Item("Total")
        TBMoneda1.Text = TablaArqueo.Rows(10).Item("Cantidad")
        LBM1.Text = TablaArqueo.Rows(10).Item("Total")
        TBMoneda050.Text = TablaArqueo.Rows(11).Item("Cantidad")
        LBM050.Text = TablaArqueo.Rows(11).Item("Total")
        TBMoneda020.Text = TablaArqueo.Rows(12).Item("Cantidad")
        LBM020.Text = TablaArqueo.Rows(12).Item("Total")
        TBMoneda010.Text = TablaArqueo.Rows(13).Item("Cantidad")
        LBM010.Text = TablaArqueo.Rows(13).Item("Total")
        TBMoneda005.Text = TablaArqueo.Rows(14).Item("Cantidad")
        LBM005.Text = TablaArqueo.Rows(14).Item("Total")
        TBDolares.Text = TablaArqueo.Rows(15).Item("Cantidad")
        LBDLL.Text = TablaArqueo.Rows(15).Item("Total")
        LBTOTAL.Text = (CDbl(LBB1000.Text) + CDbl(LBB500.Text) + CDbl(LBB200.Text) + CDbl(LBB100.Text) + CDbl(LBB50.Text) + CDbl(LBB20.Text) + CDbl(LBM20.Text) + CDbl(LBM10.Text) + CDbl(LBM5.Text) + CDbl(LBM2.Text) + CDbl(LBM1.Text) + CDbl(LBM050.Text) + CDbl(LBM020.Text) + CDbl(LBM010.Text) + CDbl(LBM005.Text) + CDbl(LBDLL.Text))
        '========================================================================
        Session("TablaArqueo") = TablaArqueo
        Session("VistaArqueo") = VistaArqueo
        SeleccionarView(1)
    End Sub
    Protected Sub TBBillete1000_TextChanged(sender As Object, e As EventArgs) Handles TBBillete1000.TextChanged
        If TBBillete1000.Text Is String.Empty Then
            TBBillete1000.Text = 0
        Else
            LBB1000.Text = CInt(TBBillete1000.Text * 1000)
        End If
    End Sub
    Protected Sub TBBillete500_TextChanged(sender As Object, e As EventArgs) Handles TBBillete500.TextChanged
        If TBBillete500.Text Is String.Empty Then
            TBBillete500.Text = 0
        Else
            LBB500.Text = CDbl(TBBillete500.Text * 500)
        End If
    End Sub
    Protected Sub TBBillete200_TextChanged(sender As Object, e As EventArgs) Handles TBBillete200.TextChanged
        If TBBillete200.Text Is String.Empty Then
            TBBillete200.Text = 0
        Else
            LBB200.Text = CDbl(TBBillete200.Text * 200)
        End If
    End Sub
    Protected Sub TBBillete100_TextChanged(sender As Object, e As EventArgs) Handles TBBillete100.TextChanged
        If TBBillete100.Text Is String.Empty Then
            TBBillete100.Text = 0
        Else
            LBB100.Text = CDbl(TBBillete100.Text * 100)
        End If
    End Sub
    Protected Sub TBBillete50_TextChanged(sender As Object, e As EventArgs) Handles TBBillete50.TextChanged
        If TBBillete50.Text Is String.Empty Then
            TBBillete50.Text = 0
        Else
            LBB50.Text = CDbl(TBBillete50.Text * 50)
        End If
    End Sub
    Protected Sub TBBillete20_TextChanged(sender As Object, e As EventArgs) Handles TBBillete20.TextChanged
        If TBBillete20.Text Is String.Empty Then
            TBBillete20.Text = 0
        Else
            LBB20.Text = CDbl(TBBillete20.Text * 20)
        End If
    End Sub
    Protected Sub TBMoneda20_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda20.TextChanged
        If TBMoneda20.Text Is String.Empty Then
            TBMoneda20.Text = 0
        Else
            LBM20.Text = CDbl(TBMoneda20.Text * 20)
        End If
    End Sub
    Protected Sub TBMoneda10_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda10.TextChanged
        If TBMoneda10.Text Is String.Empty Then
            TBMoneda10.Text = 0
        Else
            LBM10.Text = CDbl(TBMoneda10.Text * 10)
        End If
    End Sub
    Protected Sub TBMoneda5_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda5.TextChanged
        If TBMoneda5.Text Is String.Empty Then
            TBMoneda5.Text = 0
        Else
            LBM5.Text = CDbl(TBMoneda5.Text * 5)
        End If
    End Sub
    Protected Sub TBMoneda2_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda2.TextChanged
        If TBMoneda2.Text Is String.Empty Then
            TBMoneda2.Text = 0
        Else
            LBM2.Text = CDbl(TBMoneda2.Text * 2)
        End If
    End Sub
    Protected Sub TBMoneda1_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda1.TextChanged
        If TBMoneda1.Text Is String.Empty Then
            TBMoneda1.Text = 0
        Else
            LBM1.Text = CDbl(TBMoneda1.Text * 1)
        End If
    End Sub
    Protected Sub TBMoneda050_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda050.TextChanged
        If TBMoneda050.Text Is String.Empty Then
            TBMoneda050.Text = 0
        Else
            LBM050.Text = CDbl(TBMoneda050.Text * 0.5)
        End If
    End Sub
    Protected Sub TBMoneda020_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda020.TextChanged
        If TBMoneda020.Text Is String.Empty Then
            TBMoneda020.Text = 0
        Else
            LBM020.Text = CDbl(TBMoneda020.Text * 0.2)
        End If
    End Sub
    Protected Sub TBMoneda010_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda010.TextChanged
        If TBMoneda010.Text Is String.Empty Then
            TBMoneda010.Text = 0
        Else
            LBM010.Text = CDbl(TBMoneda010.Text * 0.1)
        End If
    End Sub
    Protected Sub TBMoneda005_TextChanged(sender As Object, e As EventArgs) Handles TBMoneda005.TextChanged
        If TBMoneda005.Text Is String.Empty Then
            TBMoneda005.Text = 0
        Else
            LBM005.Text = CDbl(TBMoneda005.Text * 0.05)
        End If
    End Sub
    Protected Sub TBDolares_TextChanged(sender As Object, e As EventArgs) Handles TBDolares.TextChanged
        If TBDolares.Text Is String.Empty Then
            TBDolares.Text = 0
        Else
            LBDLL.Text = CDbl(TBDolares.Text * 17.3581)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNSumar.Click
        LBTOTAL.Text = (CDbl(LBB1000.Text) + CDbl(LBB500.Text) + CDbl(LBB200.Text) + CDbl(LBB100.Text) + CDbl(LBB50.Text) + CDbl(LBB20.Text) + CDbl(LBM20.Text) + CDbl(LBM10.Text) + CDbl(LBM5.Text) + CDbl(LBM2.Text) + CDbl(LBM1.Text) + CDbl(LBM050.Text) + CDbl(LBM020.Text) + CDbl(LBM010.Text) + CDbl(LBM005.Text) + CDbl(LBDLL.Text))
        '-------------------------------------------------------------------------------       
        TablaArqueo = Session("TablaArqueo")
        'TablaArqueo.Clear()
        BTNSumar.CssClass = "BotonCorrecto"
        Dim EntidadArqueo As New Entidad.Arqueo()
        If TBIdArqueo.Text Is String.Empty Then
            agregarrenglon(TablaArqueo, CInt(TBBillete1000.Text), 1000, CDbl(LBB1000.Text))
            agregarrenglon(TablaArqueo, CInt(TBBillete500.Text), 500, CDbl(LBB500.Text))
            agregarrenglon(TablaArqueo, CInt(TBBillete200.Text), 200, CDbl(LBB200.Text))
            agregarrenglon(TablaArqueo, CInt(TBBillete100.Text), 100, CDbl(LBB100.Text))
            agregarrenglon(TablaArqueo, CInt(TBBillete50.Text), 50, CDbl(LBB50.Text))
            agregarrenglon(TablaArqueo, CInt(TBBillete20.Text), 20, CDbl(LBB20.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda20.Text), 20, CDbl(LBM20.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda10.Text), 10, CDbl(LBM10.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda5.Text), 5, CDbl(LBM5.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda2.Text), 2, CDbl(LBM2.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda1.Text), 1, CDbl(LBM1.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda050.Text), 0.5, CDbl(LBM050.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda020.Text), 0.2, CDbl(LBM020.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda010.Text), 0.1, CDbl(LBM010.Text))
            agregarrenglon(TablaArqueo, CInt(TBMoneda005.Text), 0.05, CDbl(LBM005.Text))
            agregarrenglon(TablaArqueo, CInt(TBDolares.Text), 17.3581, CDbl(LBDLL.Text))

        Else
            actualizarrenglon(TablaArqueo, 0, CInt(TBBillete1000.Text), 1000, CDbl(LBB1000.Text))
            actualizarrenglon(TablaArqueo, 1, CInt(TBBillete500.Text), 500, CDbl(LBB500.Text))
            actualizarrenglon(TablaArqueo, 2, CInt(TBBillete200.Text), 200, CDbl(LBB200.Text))
            actualizarrenglon(TablaArqueo, 3, CInt(TBBillete100.Text), 100, CDbl(LBB100.Text))
            actualizarrenglon(TablaArqueo, 4, CInt(TBBillete50.Text), 50, CDbl(LBB50.Text))
            actualizarrenglon(TablaArqueo, 5, CInt(TBBillete20.Text), 20, CDbl(LBB20.Text))
            actualizarrenglon(TablaArqueo, 6, CInt(TBMoneda20.Text), 20, CDbl(LBM20.Text))
            actualizarrenglon(TablaArqueo, 7, CInt(TBMoneda10.Text), 10, CDbl(LBM10.Text))
            actualizarrenglon(TablaArqueo, 8, CInt(TBMoneda5.Text), 5, CDbl(LBM5.Text))
            actualizarrenglon(TablaArqueo, 9, CInt(TBMoneda2.Text), 2, CDbl(LBM2.Text))
            actualizarrenglon(TablaArqueo, 10, CInt(TBMoneda1.Text), 1, CDbl(LBM1.Text))
            actualizarrenglon(TablaArqueo, 11, CInt(TBMoneda050.Text), 0.5, CDbl(LBM050.Text))
            actualizarrenglon(TablaArqueo, 12, CInt(TBMoneda020.Text), 0.2, CDbl(LBM020.Text))
            actualizarrenglon(TablaArqueo, 13, CInt(TBMoneda010.Text), 0.1, CDbl(LBM010.Text))
            actualizarrenglon(TablaArqueo, 14, CInt(TBMoneda005.Text), 0.05, CDbl(LBM005.Text))
            actualizarrenglon(TablaArqueo, 15, CInt(TBDolares.Text), 17.3581, CDbl(LBDLL.Text))
        End If
        Session("TablaArqueo") = TablaArqueo
    End Sub

    Private Sub agregarrenglon(ByRef TablaArqueo As DataTable, p1 As Integer, p2 As Double, p3 As Double)
        Dim RenglonAInsertar As DataRow
        RenglonAInsertar = TablaArqueo.NewRow()
        If TBIdArqueo.Text Is String.Empty Then
            RenglonAInsertar("IdArqueoDetalle") = 0
            RenglonAInsertar("IdArqueo") = 0
            RenglonAInsertar("Cantidad") = p1
            RenglonAInsertar("Valor") = p2
            RenglonAInsertar("Total") = p3
            TablaArqueo.Rows.Add(RenglonAInsertar)
        End If
    End Sub
    Private Sub actualizarrenglon(ByRef TablaArqueo As DataTable, ByVal id As Integer, ByVal col1 As Integer, col2 As Double, col3 As Double)
        TablaArqueo.Rows(id).Item("Cantidad") = col1
        TablaArqueo.Rows(id).Item("Valor") = col2
        TablaArqueo.Rows(id).Item("Total") = col3
        TablaArqueo.AcceptChanges()
    End Sub
End Class