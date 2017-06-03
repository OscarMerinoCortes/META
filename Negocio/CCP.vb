Public Class CCP
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadCCP As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCCP As New Datos.CCP()
        DatosCCP.Consultar(EntidadCCP)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadCCP As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadCCP1 As New Entidad.CCP()
        Dim DatosCCP As New Datos.CCP()
        EntidadCCP1 = EntidadCCP
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCCP1.IdPersona), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.PagoAbono), "El Campo [Abono] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.PagoAbono), "El Campo [Abono] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.PagoAbono), "El Campo [Abono] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.PagoAbono), "El Campo [Abono] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCCP1.idUsuarioCreacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaCreacion = Now
            EntidadCCP1.idUsuarioActualizacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaActualizacion = Now
            DatosCCP.Insertar(EntidadCCP1)
            DatosCCP.InsertarActualizar(EntidadCCP1)
        End If
    End Sub
    Public Sub GuardarCCP(ByRef EntidadCCP As Entidad.EntidadBase)
        Dim EntidadCCP1 As New Entidad.CCP()
        Dim DatosCCP As New Datos.CCP()
        EntidadCCP1 = EntidadCCP
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCCP1.IdPersona), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.Descripcion), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.FechaActual), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.FechaExpedicion), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.IdSucursal), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.IdTipoCCP), "El Campo [IdPersona] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadCCP1.IdTipoDocumento), "El Campo [IdPersona] esta Vacio")

        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCCP1.idUsuarioCreacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaCreacion = Now
            EntidadCCP1.idUsuarioActualizacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaActualizacion = Now
            If EntidadCCP1.IdCCP = 0 Then
                DatosCCP.Insertar(EntidadCCP1)
            Else
                DatosCCP.Actualizar(EntidadCCP1)
            End If
        End If
    End Sub
    Public Sub GuardarCCPMovimiento(ByRef EntidadCCP As Entidad.EntidadBase)
        Dim EntidadCCP1 As New Entidad.CCP()
        Dim DatosCCP As New Datos.CCP()
        EntidadCCP1 = EntidadCCP
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCCP1.IdCCP), "El Campo [IdCCP] esta Vacio")

        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCCP1.IdUsuarioCreacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaCreacion = Now
            EntidadCCP1.IdUsuarioActualizacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaActualizacion = Now
            If EntidadCCP1.IdCCPMovimiento = 0 Then
                DatosCCP.InsertarMovimiento(EntidadCCP1)

            End If
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadCCP As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim DatosCCP As New Datos.CCP()
        DatosCCP.Obtener(EntidadCCP)
    End Sub
    Public Sub Liquidacion(ByRef EntidadCCP As Entidad.EntidadBase)
        Dim DatosCCP As New Datos.CCP()
        DatosCCP.Liquidacion(EntidadCCP)
    End Sub
    Public Sub ReporteCCP(ByRef EntidadCCP As Entidad.EntidadBase)
        Dim DatosCCP As New Datos.CCP()
        DatosCCP.ReporteCCP(EntidadCCP)
    End Sub
    Public Sub CancelarMovimiento(ByRef EntidadCCP As Entidad.EntidadBase)
        Dim DatosCCP As New Datos.CCP()
        DatosCCP.CancelarMovimiento(EntidadCCP)
    End Sub
    Public Sub CancelarCCP(ByRef EntidadCCP As Entidad.EntidadBase)
        Dim EntidadCCP1 As New Entidad.CCP()
        Dim DatosCCP As New Datos.CCP()
        EntidadCCP1 = EntidadCCP
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCCP1.IdPersona), "El Campo [IdPersona] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCCP1.IdUsuarioCreacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaCreacion = Now
            EntidadCCP1.IdUsuarioActualizacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadCCP1.FechaActualizacion = Now

            DatosCCP.CancelarCCPCompra(EntidadCCP1)

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

                Dim FechaInicio = CDate(TablaReporte.Rows(0).Item("FechaExpedicion"))
                Dim FechaFin = CDate(TablaReporte.Rows(TablaReporte.Rows.Count - 1).Item("FechaExpedicion"))

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
