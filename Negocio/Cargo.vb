Public Class Cargo
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosCargo As New Datos.Cargo()
        DatosCargo.Consultar(EntidadCargo)

    End Sub

    Public Sub ConsultarVenta(ByRef EntidadCargo As Entidad.EntidadBase)
        Dim DatosCargo As New Datos.Cargo()
        DatosCargo.ConsultarVenta(EntidadCargo)

    End Sub

    Public Overridable Sub Guardar(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Guardar
        Dim DatosCargo As New Datos.Cargo()
        Dim EntidadCargo1 As New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCargo1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCargo1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCargo1.idUsuarioCreacion = 1
            'EntidadCargo1.Tarjeta.IdUsuario
            'EntidadCargo1.UsuarioCreacion = EntidadCargo.Tarjeta.Username.ToUpper()
            EntidadCargo1.FechaCreacion = Now
            EntidadCargo1.idUsuarioActualizacion = 1
            'EntidadCargo1.Tarjeta.IdUsuario
            'EntidadCargo1.UsuarioActualizacion = EntidadCargo.Tarjeta.Username.ToUpper()
            EntidadCargo1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadCargo1.IdCargo), "El Campo [ID] esta Vacio")
            If EntidadCargo1.IdCargo = 0 Then
                DatosCargo.Insertar(EntidadCargo1)
            Else
                DatosCargo.Actualizar(EntidadCargo1)
            End If
        End If
    End Sub

    Public Overridable Sub GuardarVenta(ByRef EntidadCargo As Entidad.EntidadBase)
        Dim DatosCargo As New Datos.Cargo()
        Dim EntidadCargo1 As New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        Dim DSResRul As String = ""
        AddRul(DSResRul, Vacio(EntidadCargo1.Descripcion), "El Campo [Descripcion] esta Vacio")
        AddRul(DSResRul, Vacio(EntidadCargo1.IdEstado), "El Campo [Estado] esta Vacio")
        If Not Vacio(DSResRul) Then
            Exit Sub
        Else
            EntidadCargo1.IdUsuarioCreacion = 1
            'EntidadCargo1.Tarjeta.IdUsuario
            'EntidadCargo1.UsuarioCreacion = EntidadCargo.Tarjeta.Username.ToUpper()
            EntidadCargo1.FechaCreacion = Now
            EntidadCargo1.IdUsuarioActualizacion = 1
            'EntidadCargo1.Tarjeta.IdUsuario
            'EntidadCargo1.UsuarioActualizacion = EntidadCargo.Tarjeta.Username.ToUpper()
            EntidadCargo1.FechaActualizacion = Now
            AddRul(DSResRul, Vacio(EntidadCargo1.IdCargo), "El Campo [ID] esta Vacio")
            DatosCargo.InsertarActualizarVenta(EntidadCargo1)
        End If
    End Sub

    Public Sub Obtener(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
