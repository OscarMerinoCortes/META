Public Class SolicitudCompra
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosSolicitudCompra As New Datos.SolicitudCompra()
        DatosSolicitudCompra.Consultar(EntidadSolicitudCompra)
    End Sub
    Public Sub ConsultarFiltro(ByRef EntidadSolicitudCompra As Entidad.EntidadBase)
        Dim DatosSolicitudCompra As New Datos.SolicitudCompra()
        DatosSolicitudCompra.ConsultarFiltro(EntidadSolicitudCompra)
    End Sub

    Public Sub Guardar(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadSolicitudCompra1 As New Entidad.SolicitudCompra()
        Dim DatosSolicitudCompra As New Datos.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadSolicitudCompra1.idUsuarioCreacion = 1
            'EntidadSolicitudCompra1.Tarjeta.IdUsuario
            'EntidadSolicitudCompra1.UsuarioCreacion = EntidadSolicitudCompra1.Tarjeta.Username.ToUpper()
            EntidadSolicitudCompra1.FechaCreacion = Now
            EntidadSolicitudCompra1.idUsuarioActualizacion = 1
            'EntidadSolicitudCompra1.Tarjeta.IdUsuario
            'EntidadSolicitudCompra1.UsuarioActualizacion = EntidadSolicitudCompra1.Tarjeta.Username.ToUpper()
            EntidadSolicitudCompra1.FechaActualizacion = Now
            If EntidadSolicitudCompra1.IdSolicitudCompra = 0 Then
                DatosSolicitudCompra.Insertar(EntidadSolicitudCompra1)
            Else
                DatosSolicitudCompra.Actualizar(EntidadSolicitudCompra1)
            End If

        End If
    End Sub
    Public Sub ActualizarSolicitudDetalle(ByRef EntidadSolicitudCompra As Entidad.EntidadBase)
        Dim EntidadSolicitudCompra1 As New Entidad.SolicitudCompra()
        Dim DatosSolicitudCompra As New Datos.SolicitudCompra()
        EntidadSolicitudCompra1 = EntidadSolicitudCompra
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadSolicitudCompra1.idUsuarioCreacion = 1
            'EntidadSolicitudCompra1.Tarjeta.IdUsuario
            'EntidadSolicitudCompra1.UsuarioCreacion = EntidadSolicitudCompra1.Tarjeta.Username.ToUpper()
            EntidadSolicitudCompra1.FechaCreacion = Now
            EntidadSolicitudCompra1.idUsuarioActualizacion = 1
            'EntidadSolicitudCompra1.Tarjeta.IdUsuario
            'EntidadSolicitudCompra1.UsuarioActualizacion = EntidadSolicitudCompra1.Tarjeta.Username.ToUpper()
            EntidadSolicitudCompra1.FechaActualizacion = Now
            DatosSolicitudCompra.ActualizarSolicitudDetalle(EntidadSolicitudCompra1)
        End If
    End Sub

    Public Sub Obtener(ByRef EntidadSolicitudCompra As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosSolicitudCompra As New Datos.SolicitudCompra()
        DatosSolicitudCompra.Obtener(EntidadSolicitudCompra)
    End Sub
    Public Sub ReporteSolicitudCompra(ByRef EntidadReporteSolicitudCompra As Entidad.ReporteProcesoCompra)
        Dim DatosReporteSolicitudCompra As New Datos.ReportesProcesoCompra()
        DatosReporteSolicitudCompra.ReporteSolicitudCompra(EntidadReporteSolicitudCompra)
    End Sub
    Public Sub ProcesarImprimirReporte(ByVal TablaReporte As DataTable, ByRef cadena As String, empresa As Integer)
        If empresa = 1 Then
        ElseIf empresa = 2 Then 'lalos
            Try
                'Cargar logo y datos de la empresa desde la variable de session
                Dim EmpresaLogo = "<img alt=""logo"" src=""../../../../Imagenes/Lighthouse.jpg"" style=""width: 128px;""/>"
                Dim EmpresaNombre = "Meta"
                Dim EmpresaDireccion = ""

                Dim FechaInicio = CDate(TablaReporte.Rows(0).Item("FechaCreacion"))
                Dim FechaFin = CDate(TablaReporte.Rows(TablaReporte.Rows.Count - 1).Item("FechaCreacion"))

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
