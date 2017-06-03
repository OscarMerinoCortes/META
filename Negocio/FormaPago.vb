Public Class FormaPago
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadFormaPago As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosFormaPago As New Datos.FormaPago()
        DatosFormaPago.Consultar(EntidadFormaPago)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadFormaPago As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadFormaPago1 As New Entidad.FormaPago()
        Dim DatosFormaPago As New Datos.FormaPago()
        EntidadFormaPago1 = EntidadFormaPago
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadFormaPago1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadFormaPago1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadFormaPago1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadFormaPago1.FechaCreacion = Now
            EntidadFormaPago1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadFormaPago1.FechaActualizacion = Now
            If EntidadFormaPago1.IdFormaPago = 0 Then
                DatosFormaPago.Insertar(EntidadFormaPago1)
            Else
                DatosFormaPago.Actualizar(EntidadFormaPago1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadTipoReferencia As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
