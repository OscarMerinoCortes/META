Imports System.Data
Partial Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CType(Master.FindControl("LBOpcion"), Label).Text = "Usuario"
            Consultar()
            DDEstado.Items.Add(New ListItem("ACTIVO", 1))
            DDEstado.Items.Add(New ListItem("INACTIVO", 2))
            DDEstado.SelectedValue = 1
            TBVigencia.Text = Now.Date
            'Año
            For number As Double = CDbl(Date.Now.Year) To 1900 Step -1
                DDAño.Items.Add(number)
            Next

            ''Mes
            DDMes.Items.Add(New ListItem("ENERO", 1))
            DDMes.Items.Add(New ListItem("FEBRERO", 2))
            DDMes.Items.Add(New ListItem("MARZO", 3))
            DDMes.Items.Add(New ListItem("ABRIL", 4))
            DDMes.Items.Add(New ListItem("MAYO", 5))
            DDMes.Items.Add(New ListItem("JUNIO", 6))
            DDMes.Items.Add(New ListItem("JULIO", 7))
            DDMes.Items.Add(New ListItem("AGOSTO", 8))
            DDMes.Items.Add(New ListItem("SEPTIEMBRE", 9))
            DDMes.Items.Add(New ListItem("OCTUBRE", 10))
            DDMes.Items.Add(New ListItem("NOVIEMBRE", 11))
            DDMes.Items.Add(New ListItem("DICIEMBRE", 12))
            ''Dia
            For number2 As Double = 1 To 31
                DDDia.Items.Add(number2)
            Next number2
            'Usuario
            Dim tabla = New DataTable
            Dim NegocioUsuario As New Negocio.TipoUsuario()
            Dim EntidadUsuario As New Entidad.TipoUsuario()
            EntidadUsuario.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioUsuario.Consultar(EntidadUsuario)
            DDTipoUsuario.DataSource = EntidadUsuario.TablaConsulta
            DDTipoUsuario.DataValueField = "ID"
            DDTipoUsuario.DataTextField = "Descripcion"
            DDTipoUsuario.DataBind()
            DDTipoUsuario.SelectedIndex = 0

            Dim NegocioSucursal As New Negocio.Sucursal()
            Dim EntidadSucursal As New Entidad.Sucursal()
            EntidadSucursal.Tarjeta.Consulta = Operacion.Configuracion.Constante.Consulta.ConsultaBasica
            NegocioSucursal.Consultar(EntidadSucursal)
            DDSucursal.DataSource = EntidadSucursal.TablaConsulta
            DDSucursal.DataValueField = "ID"
            DDSucursal.DataTextField = "Descripcion"
            DDSucursal.DataBind()
            DDSucursal.SelectedIndex = 0
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
        TBUsername.Text = ""
        TBAbreviacion.Text = ""
        TBPrimerNombre.Text = ""
        TBSegundoNombre.Text = ""
        TBApellidoPaterno.Text = ""
        TBApellidoMaterno.Text = ""
        DDDia.SelectedValue = 1
        DDMes.SelectedValue = 1
        DDAño.SelectedValue = Date.Now.Year
        DDTipoUsuario.SelectedValue = 1
        DDSucursal.SelectedValue = 1
        TBContraseña.Text = ""
        TBVigencia.Text = ""
        TBCorreo.Text = ""
        TBTelefono.Text = ""
        DDEstado.SelectedValue = 1
        TBVigencia.Text = Now.Date
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
        If TBIdUsuario.Text Is String.Empty Then
            EntidadUsuario.IdUsuario = 0
        Else
            EntidadUsuario.IdUsuario = CInt(TBIdUsuario.Text)
        End If
        EntidadUsuario.Username = TBUsername.Text
        EntidadUsuario.Abreviacion = TBAbreviacion.Text
        EntidadUsuario.PrimerNombre = TBPrimerNombre.Text
        If TBSegundoNombre.Text Is String.Empty Then
            EntidadUsuario.SegundoNombre = " "
        Else
            EntidadUsuario.SegundoNombre = TBSegundoNombre.Text
        End If
        EntidadUsuario.ApellidoPaterno = TBApellidoPaterno.Text
        EntidadUsuario.ApellidoMaterno = TBApellidoMaterno.Text
        EntidadUsuario.Dia = CInt(DDDia.SelectedValue)
        EntidadUsuario.Mes = CInt(DDMes.SelectedValue)
        EntidadUsuario.Ano = CInt(DDAño.SelectedValue)
        EntidadUsuario.IdTipoUsuario = CInt(DDTipoUsuario.SelectedValue)
        EntidadUsuario.IdSucursal = CInt(DDSucursal.SelectedValue)
        EntidadUsuario.Clave = TBContraseña.Text
        EntidadUsuario.Vigencia = CDate(TBVigencia.Text)
        EntidadUsuario.Correo = TBCorreo.Text
        EntidadUsuario.Telefono = TBTelefono.Text
        EntidadUsuario.IdEstado = CInt(DDEstado.SelectedValue)
        NegocioUsuario.Guardar(EntidadUsuario)
        DDEstado.SelectedValue = 1
        Nuevo()
        SeleccionarView(0)
        Consultar()
    End Sub

    Protected Sub GVTipoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVUsuario.SelectedIndexChanged
        Dim Tabla As New DataTable
        Tabla = Session("Tabla")
        TBIdUsuario.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("ID")
        TBUsername.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Username")
        TBAbreviacion.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Abreviacion")
        TBPrimerNombre.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("PrimerNombre")
        TBSegundoNombre.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("SegundoNombre")
        TBApellidoPaterno.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("ApellidoPaterno")
        TBApellidoMaterno.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("ApellidoMaterno")
        DDDia.SelectedValue = Tabla.Rows(GVUsuario.SelectedIndex).Item("Dia")
        DDMes.SelectedValue = Tabla.Rows(GVUsuario.SelectedIndex).Item("Mes")
        DDAño.SelectedValue = Tabla.Rows(GVUsuario.SelectedIndex).Item("Ano")
        DDTipoUsuario.SelectedValue = Tabla.Rows(GVUsuario.SelectedIndex).Item("IdTipoUsuario")
        DDSucursal.SelectedValue = Tabla.Rows(GVUsuario.SelectedIndex).Item("IdSucursal")
        'TBContraseña.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Clave")
        TBVigencia.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Vigencia")
        TBCorreo.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Correo")
        TBTelefono.Text = Tabla.Rows(GVUsuario.SelectedIndex).Item("Telefono")
        DDEstado.SelectedValue = Tabla.Rows(GVUsuario.SelectedIndex).Item("idEstado")
        wucDatosAuditoria1.Visible = True
        wucDatosAuditoria1.SeleccionarIndice(Tabla.Rows(GVUsuario.SelectedIndex))

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