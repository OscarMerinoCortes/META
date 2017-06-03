Public Class CalculoPlazoCompra
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadCalculoPlazoCompra As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCalculoPlazoCompra As New Datos.CalculoPlazoCompra()
        DatosCalculoPlazoCompra.Consultar(EntidadCalculoPlazoCompra)
    End Sub
    Public Overridable Sub Guardar(ByRef EntidadCalculoPlazoCompra As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadCalculoPlazoCompra1 As New Entidad.CalculoPlazoCompra()
        Dim DatosCalculoPlazoCompra As New Datos.CalculoPlazoCompra()
        EntidadCalculoPlazoCompra1 = EntidadCalculoPlazoCompra
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCalculoPlazoCompra1.IdConfiguracionCalculo), "El Campo [Plazo] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCalculoPlazoCompra1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCalculoPlazoCompra1.IdUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadCalculoPlazoCompra1.FechaCreacion = Now
            EntidadCalculoPlazoCompra1.IdUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadCalculoPlazoCompra1.FechaActualizacion = Now
            DatosCalculoPlazoCompra.InsertarActualizar(EntidadCalculoPlazoCompra1)
        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
