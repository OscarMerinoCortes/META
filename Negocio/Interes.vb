﻿Public Class Interes
    Implements ICatalogo

    Public Sub Consultar(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim DatosProducto As New Datos.Interes()
        DatosProducto.Consultar(EntidadInteres)
    End Sub

    Public Overridable Sub Guardar(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Guardar
        'Dim EntidadRuta1 As New Entidad.Rutas()
        'Dim DatosRutas As New Datos.Rutas()
        'EntidadRuta1 = EntidadRuta
        'Dim DSResRul As String = ""
        'AddRul(DSResRul, Vacio(EntidadRuta1.Descripcion), "El Campo [Descripcion] esta Vacio")
        'AddRul(DSResRul, Vacio(EntidadRuta1.IdEstado), "El Campo [Estado] esta Vacio")
        'If Not Vacio(DSResRul) Then
        '    Exit Sub
        'Else
        '    EntidadRuta1.idUsuarioCreacion = 1
        '    'EntidadRuta1.Tarjeta.IdUsuario
        '    'EntidadRuta1.UsuarioCreacion = EntidadRuta1.Tarjeta.Username.ToUpper()
        '    EntidadRuta1.FechaCreacion = Now
        '    EntidadRuta1.idUsuarioActualizacion = 1
        '    'EntidadRuta1.Tarjeta.IdUsuario
        '    'EntidadRuta1.UsuarioActualizacion = EntidadRuta1.Tarjeta.Username.ToUpper()
        '    EntidadRuta1.FechaActualizacion = Now

        '    If EntidadRuta1.IdRuta = 0 Then
        '        DatosRutas.Insertar(EntidadRuta1)
        '    Else
        '        DatosRutas.Actualizar(EntidadRuta1)
        '    End If

        'End If
    End Sub
    Public Sub Obtener(ByRef EntidadInteres As Entidad.EntidadBase) Implements ICatalogo.Obtener

    End Sub
End Class
