Public Class Caja
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCaja As New Datos.Caja()
        DatosCaja.Consultar(EntidadCaja)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadCaja1 As New Entidad.Caja()
        Dim DatosCaja As New Datos.Caja()

        EntidadCaja1 = EntidadCaja
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCaja1.IdPersona), "El Campo [IdPersona] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCaja1.PagoAbono), "El Campo [Abono] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else

            'EntidadCaja1.IdUsuarioCreacion = EntidadCaja1.Tarjeta.IdUsuario
            ''EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            'EntidadCaja1.FechaCreacion = Now
            'EntidadCaja1.IdUsuarioActualizacion = EntidadCaja1.Tarjeta.IdUsuario
            ''EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            'EntidadCaja1.FechaActualizacion = Now
            DatosCaja.InsertarActualizar(EntidadCaja1)
        End If
    End Sub
    Public Sub Obtener(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
    Public Sub Liquidacion(ByRef EntidadCaja As Entidad.EntidadBase)
        Dim DatosCaja As New Datos.Caja()
        DatosCaja.Liquidacion(EntidadCaja)
    End Sub
    Public Sub ReporteMovimientosCaja(ByRef EntidadCaja As Entidad.EntidadBase)
        Dim DatosCaja As New Datos.Caja()
        DatosCaja.ReporteMovimientoCaja(EntidadCaja)
    End Sub
    Public Sub Cancelar(ByRef EntidadCaja As Entidad.EntidadBase)
        Dim DatosCaja As New Datos.Caja()
        DatosCaja.Cancelar(EntidadCaja)
    End Sub
End Class
