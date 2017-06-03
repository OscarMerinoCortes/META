Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Permisos de Usuario por Opciones"
            Consultar()


           
            SeleccionarView(0)
            wucDatosAuditoria1.Visible = False
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
    Public Sub Nuevo()
        TBIdUsuario.Text = ""
        TBIdUsuarioPermiso.Text = ""
        TBUsername.Text = ""
        TBAbreviacion.Text = ""
        TBNombre.Text = ""


        CBGuardar.Checked = False
        CBActualizar.Checked = False
        CBCancelar.Checked = False
        CBConsultar.Checked = False
        CBExportar.Checked = False
        CBImprimir.Checked = False
        CBAplicar.Checked = False
        CBCataloos.Checked = False
        CBProceso.Checked = False
        CBReportes.Checked = False
        wucDatosAuditoria1.Visible = False

    End Sub
    Public Sub Consultar()
        Dim NegocioUsuario As New Negocio.Usuario()
        Dim EntidadUsuario As New Entidad.Usuario()
        Dim Tabla As New DataTable
        EntidadUsuario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        NegocioUsuario.Consultar(EntidadUsuario)
        Tabla = EntidadUsuario.TablaConsulta
        GVUsuario.Columns.Clear()
        GVUsuario.DataSource = Tabla
        GVUsuario.AutoGenerateColumns = False
        GVUsuario.AllowSorting = True
        Dim Columna As New CommandField()
        Columna.HeaderText = ""
        Columna.HeaderText = "Seleccionar"
        Columna.ButtonType = ButtonType.Link
        Columna.ShowSelectButton = True
        GVUsuario.Columns.Add(Columna)
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "ID", "ID")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Username", "Username")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Abreviacion", "Abreviacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Nombre", "Nombre")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Tipo de Usuario", "Tipo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Vigencia", "Vigencia")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Correo", "Correo")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Telefono", "Telefono")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Sucursal", "Sucursal")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Usuario Creacion", "UsuarioCreacion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Fecha Creacion", "Fecha Creacion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Usuario Actualizacion", "UsuarioActualizacion")
        'Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Fecha Actualizacion", "Fecha Actualizacion")
        Comun.Presentacion.Cuadricula.AgregarColumna(GVUsuario, New BoundField(), "Estado", "Estado")
        GVUsuario.DataBind()
        Session("Tabla") = Tabla
        wucDatosAuditoria1.Visible = True
    End Sub

    Protected Sub IBTNuevo_Click(sender As Object, e As ImageClickEventArgs) Handles IBTNuevo.Click
        Nuevo()
        SeleccionarView(1)
        wucDatosAuditoria1.Visible = False
    End Sub

    Protected Sub IBTGuardar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTGuardar.Click
        Dim NegocioUsuario As New Negocio.Usuario()
        Dim EntidadUsuario As New Entidad.Usuario()
        If TBIdUsuarioPermiso.Text Is String.Empty Then
            EntidadUsuario.IdTipoUsuario = 0
        Else
            EntidadUsuario.IdTipoUsuario = CInt(TBIdUsuarioPermiso.Text)
        End If
        If TBIdUsuario.Text Is String.Empty Then
            Return
        End If
        EntidadUsuario.IdUsuario = CInt(TBIdUsuario.Text)

        If CBGuardar.Checked = True Then
            EntidadUsuario.Guardar = 1
        Else
            EntidadUsuario.Guardar = 0
        End If
        If CBActualizar.Checked = True Then
            EntidadUsuario.Actualizar = 1
        Else
            EntidadUsuario.Actualizar = 0
        End If
        If CBConsultar.Checked = True Then
            EntidadUsuario.Consultar = 1
        Else
            EntidadUsuario.Consultar = 0
        End If
        If CBCancelar.Checked = True Then
            EntidadUsuario.Cancelar = 1
        Else
            EntidadUsuario.Cancelar = 0
        End If
        If CBExportar.Checked = True Then
            EntidadUsuario.Exportar = 1
        Else
            EntidadUsuario.Exportar = 0
        End If
        If CBImprimir.Checked = True Then
            EntidadUsuario.Imprimir = 1
        Else
            EntidadUsuario.Imprimir = 0
        End If
        If CBAplicar.Checked = True Then
            EntidadUsuario.Aplicar = 1
        Else
            EntidadUsuario.Aplicar = 0
        End If
        If CBCataloos.Checked = True Then
            EntidadUsuario.Catalogo = 1
        Else
            EntidadUsuario.Catalogo = 0
        End If
        If CBProceso.Checked = True Then
            EntidadUsuario.Proceso = 1
        Else
            EntidadUsuario.Proceso = 0
        End If
        If CBReportes.Checked = True Then
            EntidadUsuario.Reporte = 1
        Else
            EntidadUsuario.Reporte = 0
        End If

        ' NegocioUsuario.GuardarPermisoOpcion(EntidadUsuario)
        'DDEstado.SelectedValue = 1
        'Nuevo()
        'SeleccionarView(0)
        'Consultar()
    End Sub

    Protected Sub GVTipoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVUsuario.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdUsuario.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("ID")
        TBUsername.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Username")
        TBAbreviacion.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Abreviacion")
        TBNombre.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("PrimerNombre") + " " + Tabla.Rows(GVUsuario.SelectedIndex).Item("SegundoNombre") + " " + Tabla.Rows(GVUsuario.SelectedIndex).Item("ApellidoPaterno") + " " + Tabla.Rows(GVUsuario.SelectedIndex).Item("ApellidoMaterno")

        Dim NegocioUsuario As New Negocio.Usuario()
        Dim EntidadUsuario As New Entidad.Usuario()
        Dim Tabla1 As New DataTable
        EntidadUsuario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaPorId
        EntidadUsuario.IdUsuario = TBIdUsuario.Text
        NegocioUsuario.Consultar(EntidadUsuario)
        Tabla1 = EntidadUsuario.TablaConsulta
        TBIdUsuarioPermiso.Text = Tabla1.Rows(0).Item("IdUsuarioPermisoTransaccion")
        If Tabla1.Rows(0).Item("Guardar") = 1 Then
            CBGuardar.Checked = True
        Else
            CBGuardar.Checked = False
        End If
        If Tabla1.Rows(0).Item("Actualizar") = 1 Then
            CBActualizar.Checked = True
        Else
            CBActualizar.Checked = False
        End If
        If Tabla1.Rows(0).Item("Cancelar") = 1 Then
            CBCancelar.Checked = True
        Else
            CBCancelar.Checked = False
        End If
        If Tabla1.Rows(0).Item("Consultar") = 1 Then
            CBConsultar.Checked = True
        Else
            CBConsultar.Checked = False
        End If
        If Tabla1.Rows(0).Item("Exportar") = 1 Then
            CBExportar.Checked = True
        Else
            CBExportar.Checked = False
        End If
        If Tabla1.Rows(0).Item("Imprimir") = 1 Then
            CBImprimir.Checked = True
        Else
            CBImprimir.Checked = False
        End If
        If Tabla1.Rows(0).Item("Aplicar") = 1 Then
            CBAplicar.Checked = True
        Else
            CBAplicar.Checked = False
        End If
        If Tabla1.Rows(0).Item("Catalogos") = 1 Then
            CBCataloos.Checked = True
        Else
            CBCataloos.Checked = False
        End If
        If Tabla1.Rows(0).Item("Proceso") = 1 Then
            CBProceso.Checked = True
        Else
            CBProceso.Checked = False
        End If
        If Tabla1.Rows(0).Item("Reporte") = 1 Then
            CBReportes.Checked = True
        Else
            CBReportes.Checked = False
        End If


        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla1.Rows(0))

        SeleccionarView(1)
    End Sub

    Protected Sub IBTConsultar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTConsultar.Click
        SeleccionarView(0)
        Consultar()
    End Sub
    Protected Sub IBTCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles IBTCancelar.Click
        Response.Redirect("~\Default.aspx")
    End Sub

End Class