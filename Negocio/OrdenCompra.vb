Public Class OrdenCompra
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadOrdenCompra As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosOrdenCompra As New Datos.OrdenCompra()
        DatosOrdenCompra.Consultar(EntidadOrdenCompra)
    End Sub

    Public Sub ConsultarFiltro(ByRef EntidadSolicitudCompra As Entidad.EntidadBase)
        Dim DatosSolicitudCompra As New Datos.OrdenCompra()
        DatosSolicitudCompra.ConsultarFiltro(EntidadSolicitudCompra)
    End Sub

    Public Sub Guardar(ByRef EntidadOrdenCompra As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadOrdenCompra1 As New Entidad.OrdenCompra()
        Dim DatosOrdenCompra As New Datos.OrdenCompra()
        EntidadOrdenCompra1 = EntidadOrdenCompra
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadOrdenCompra1.idUsuarioCreacion = 1
            'EntidadOrdenCompra1.Tarjeta.IdUsuario
            'EntidadOrdenCompra1.UsuarioCreacion = EntidadOrdenCompra1.Tarjeta.Username.ToUpper()
            EntidadOrdenCompra1.FechaCreacion = Now
            EntidadOrdenCompra1.idUsuarioActualizacion = 1
            'EntidadOrdenCompra1.Tarjeta.IdUsuario
            'EntidadOrdenCompra1.UsuarioActualizacion = EntidadOrdenCompra1.Tarjeta.Username.ToUpper()
            EntidadOrdenCompra1.FechaActualizacion = Now
            If EntidadOrdenCompra1.IdOrden = 0 Then
                DatosOrdenCompra.Insertar(EntidadOrdenCompra1)
            Else
                DatosOrdenCompra.Actualizar(EntidadOrdenCompra1)
            End If

        End If
    End Sub
    Public Sub Autorizar(ByRef EntidadOrdenCompra As Entidad.EntidadBase)
        Dim EntidadOrdenCompra1 As New Entidad.OrdenCompra()
        Dim DatosOrdenCompra As New Datos.OrdenCompra()
        EntidadOrdenCompra1 = EntidadOrdenCompra
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadOrdenCompra1.IdUsuarioCreacion = 1
            'EntidadOrdenCompra1.Tarjeta.IdUsuario
            'EntidadOrdenCompra1.UsuarioCreacion = EntidadOrdenCompra1.Tarjeta.Username.ToUpper()
            EntidadOrdenCompra1.FechaCreacion = Now
            EntidadOrdenCompra1.IdUsuarioActualizacion = 1
            'EntidadOrdenCompra1.Tarjeta.IdUsuario
            'EntidadOrdenCompra1.UsuarioActualizacion = EntidadOrdenCompra1.Tarjeta.Username.ToUpper()
            EntidadOrdenCompra1.FechaActualizacion = Now
            If EntidadOrdenCompra1.IdOrden = 0 Then

            Else
                DatosOrdenCompra.Actualizar(EntidadOrdenCompra1)
            End If

        End If
    End Sub

    Public Sub Obtener(ByRef EntidadOrdenCompra As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosOrdenCompra As New Datos.OrdenCompra()
        DatosOrdenCompra.Obtener(EntidadOrdenCompra)
    End Sub
    Public Sub ObtenerProveedor(ByRef EntidadOrdenCompra As Entidad.OrdenCompra)
        Dim DatosOrdenCompra As New Datos.OrdenCompra()
        DatosOrdenCompra.ObtenerProveedor(EntidadOrdenCompra)
    End Sub
    Public Sub ReporteOrdenCompra(ByRef EntidadReporteOrdenCompra As Entidad.ReporteProcesoCompra)
        Dim DatosReporteOrdenCompra As New Datos.ReportesProcesoCompra()
        DatosReporteOrdenCompra.ReporteOrdenCompra(EntidadReporteOrdenCompra)
    End Sub
    Public Sub ObtenerSolicitud(ByRef ReporteProcesoCompra As Entidad.ReporteProcesoCompra)
        Dim DatosReporteOrdenCompra As New Datos.ReportesProcesoCompra()
        DatosReporteOrdenCompra.ObtenerSolicitudes(ReporteProcesoCompra)
    End Sub
    Public Sub ObtenerSolicitudCompraAutorizada(ByRef EntidadReporteProcesoCompra As Entidad.ReporteProcesoCompra)
        Dim DatosReporteOrdenCompra As New Datos.ReportesProcesoCompra()
        DatosReporteOrdenCompra.ObtenerSolicitudAutorizada(EntidadReporteProcesoCompra)
    End Sub
    Public Sub ObtenerSolicitudCompraOrdenadas(ByRef EntidadReporteProcesoCompra As Entidad.ReporteProcesoCompra)
        Dim DatosReporteOrdenCompra As New Datos.ReportesProcesoCompra()
        DatosReporteOrdenCompra.ObtenerSolicitudesOrdenadas(EntidadReporteProcesoCompra)
    End Sub
    Public Sub PerfilOrdenCompra(ByRef EntidadPerfilOrdenCompra As Entidad.EntidadBase)

    End Sub
    Public Sub ActualizarOrdenDetalle(ByRef EntidadOrdenCompra As Entidad.EntidadBase)
        Dim DatosReporteOrdenCompra As New Datos.OrdenCompra()
        DatosReporteOrdenCompra.ActualizarOrdenDetalle(EntidadOrdenCompra)
    End Sub
    Public Sub ProcesarImprimirReporte(ByVal TablaReporte As DataTable, ByRef cadena As String, empresa As Integer)
        If empresa = 1 Then
        ElseIf empresa = 2 Then 'lalos
            Try
                'Cargar logo y datos de la empresa desde la variable de session
                Dim EmpresaLogo = "<img alt=""logo"" src=""../../../../Imagenes/Lighthouse.jpg"" style=""width: 128px;""/>"
                Dim EmpresaNombre = "Meta"
                Dim EmpresaDireccion = ""

                Dim FechaInicio = CDate(TablaReporte.Rows(0).Item("Fecha"))
                Dim FechaFin = CDate(TablaReporte.Rows(TablaReporte.Rows.Count - 2).Item("Fecha"))

                cadena = cadena.Replace("[Empresa.Logo]", EmpresaLogo)
                cadena = cadena.Replace("[Empresa.Nombre]", EmpresaNombre)
                cadena = cadena.Replace("[Empresa.Direccion]", EmpresaDireccion)
                cadena = cadena.Replace("[Sistema.Fecha]", Now.Date.ToLongDateString.ToUpper())
                cadena = cadena.Replace("[Fecha.Inicio]", FechaInicio.ToLongDateString.ToUpper())
                cadena = cadena.Replace("[Fecha.Fin]", FechaFin.ToLongDateString.ToUpper())
                cadena = cadena.Replace("[Tabla.Reporte]", Comun.Presentacion.Impresion.ConvertDataTableToHTML(TablaReporte))

            Catch ex As Exception
                Dim mensaje = ex.Message
            End Try
        End If
    End Sub
End Class
