Public Class ReferenciaComercial
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosReferenciaComercial As New Datos.ReferenciaComercial()
        DatosReferenciaComercial.Consultar(EntidadReferenciaComercial)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim EntidadReferenciaComercial1 As New Entidad.ReferenciaComercial()
        Dim DatosReferenciaComercial As New Datos.ReferenciaComercial()
        EntidadReferenciaComercial1 = EntidadReferenciaComercial
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadReferenciaComercial1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadReferenciaComercial1.Domicilio), "El Campo [Domicilio] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadReferenciaComercial1.Telefono), "El Campo [Telefono] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadReferenciaComercial1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadReferenciaComercial1.idUsuarioCreacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioCreacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadReferenciaComercial1.FechaCreacion = Now
            EntidadReferenciaComercial1.idUsuarioActualizacion = 1
            'EntidadTipoDomicilio1.Tarjeta.IdUsuario
            'EntidadTipoDomicilio1.UsuarioActualizacion = EntidadTipoDomicilio1.Tarjeta.Username.ToUpper()
            EntidadReferenciaComercial1.FechaActualizacion = Now
            If EntidadReferenciaComercial1.IdReferenciaComercial = 0 Then
                DatosReferenciaComercial.Insertar(EntidadReferenciaComercial1)
            Else
                DatosReferenciaComercial.Actualizar(EntidadReferenciaComercial1)
            End If

        End If
    End Sub


    Public Sub Obtener(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
