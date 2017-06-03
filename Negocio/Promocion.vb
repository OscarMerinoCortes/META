Public Class Promocion
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadPromocion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosPromocion As New Datos.Promocion()
        DatosPromocion.Consultar(EntidadPromocion)

    End Sub

    Public Sub VentaConsultar(ByRef EntidadPromocion As Entidad.EntidadBase)
        Dim DatosPromocion As New Datos.Promocion()
        DatosPromocion.VentaConsultar(EntidadPromocion)

    End Sub
    Public Sub ObtenerPromocion(ByRef EntidadPromocion As Entidad.EntidadBase)
        Dim DatosPromocion As New Datos.Promocion()
        DatosPromocion.ObtenerPromocion(EntidadPromocion)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadPromocion As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadPromocion1 As New Entidad.Promocion()
        Dim DatosPromocion As New Datos.Promocion()
        EntidadPromocion1 = EntidadPromocion
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadPromocion1.IdPromocion), "El Campo [IdPromocion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadPromocion1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadPromocion1.idUsuarioCreacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioCreacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadPromocion1.FechaCreacion = Now
            EntidadPromocion1.idUsuarioActualizacion = 1
            'EntidadCredito1.Tarjeta.IdUsuario
            'EntidadCredito1.UsuarioActualizacion = EntidadCredito1.Tarjeta.Username.ToUpper()
            EntidadPromocion1.FechaActualizacion = Now
            DatosPromocion.InsertarActualizar(EntidadPromocion1)

        End If
    End Sub
    Public Sub Obtener(ByRef EntidadCaja As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
