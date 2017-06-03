Public Class Compra
    Implements ICatalogo
    Public Sub Consultar(ByRef EntidadCompra As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCompra As New Datos.Compra()
        DatosCompra.Consultar(EntidadCompra)
    End Sub
    Public Sub ConsultarFiltro(ByRef EntidadSolicitudCompra As Entidad.EntidadBase)
        Dim DatosSolicitudCompra As New Datos.Compra()
        DatosSolicitudCompra.ConsultarFiltro(EntidadSolicitudCompra)
    End Sub
    Public Sub ConsultarCredito(ByRef EntidadCompraCredito As Entidad.EntidadBase)
        Dim DatosCompraCredito As New Datos.Compra()
        DatosCompraCredito.ConsultarID(EntidadCompraCredito)
    End Sub
    Public Sub WucEstadistica(ByRef EntidadCompra As Entidad.EntidadBase)
        Dim DatosCompra As New Datos.Compra()
        DatosCompra.WucEstadistica(EntidadCompra)
    End Sub
    Public Sub Guardar(ByRef EntidadCompra As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadCompra1 As New Entidad.Compra()
        Dim DatosCompra As New Datos.Compra()
        EntidadCompra1 = EntidadCompra
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCompra1.idUsuarioCreacion = 1
            'EntidadCompra1.Tarjeta.IdUsuario
            'EntidadCompra1.UsuarioCreacion = EntidadCompra1.Tarjeta.Username.ToUpper()
            EntidadCompra1.FechaCreacion = Now
            EntidadCompra1.idUsuarioActualizacion = 1
            'EntidadCompra1.Tarjeta.IdUsuario
            'EntidadCompra1.UsuarioActualizacion = EntidadCompra1.Tarjeta.Username.ToUpper()
            EntidadCompra1.FechaActualizacion = Now
            If EntidadCompra1.IdCompra = 0 Then
                DatosCompra.Insertar(EntidadCompra1)
            Else
                ' DatosCompra.Actualizar(EntidadCompra1)
            End If

        End If
    End Sub

    Public Sub Obtener(ByRef EntidadCompra As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosCompra As New Datos.Compra()
        DatosCompra.Obtener(EntidadCompra)
    End Sub
    Public Sub ReporteCompra(ByRef EntidadReporteProcesoCompra As Entidad.ReporteProcesoCompra)
        If EntidadReporteProcesoCompra.Identificador = 1 Then
            Dim DatosReporteCompras As New Datos.ReportesProcesoCompra()
            DatosReporteCompras.ReporteCompras(EntidadReporteProcesoCompra)
        Else
            Dim DatosReporteCompra As New Datos.ReportesProcesoCompra()
            DatosReporteCompra.ReporteCompra(EntidadReporteProcesoCompra)
        End If
    End Sub
    Public Sub PerfilCompra(ByRef EntidadPerfilCompra As Entidad.EntidadBase)

    End Sub
    Public Sub Cancelar(ByRef EntidadCancelar As Entidad.EntidadBase)
        Dim EntidadCompra1 As New Entidad.Compra()
        Dim DatosCompra As New Datos.Compra()
        EntidadCompra1 = EntidadCancelar
        Dim DSResRul As String = ""
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCompra1.IdUsuarioCreacion = 1
            'EntidadCompra1.Tarjeta.IdUsuario
            'EntidadCompra1.UsuarioCreacion = EntidadCompra1.Tarjeta.Username.ToUpper()
            EntidadCompra1.FechaCreacion = Now
            EntidadCompra1.IdUsuarioActualizacion = 1
            'EntidadCompra1.Tarjeta.IdUsuario
            'EntidadCompra1.UsuarioActualizacion = EntidadCompra1.Tarjeta.Username.ToUpper()
            EntidadCompra1.FechaActualizacion = Now

            DatosCompra.Cancelar(EntidadCompra1)
        End If
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
