Imports System.Data.SqlClient
Public Class Precio
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadPrecio As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        'Dim EntidadRuta1 As New Entidad.Rutas()
        'EntidadRuta1 = EntidadRuta
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_ActRutCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdRuta", EntidadRuta1.IdRuta))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadRuta1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadRuta1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadRuta1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadRuta1.FechaActualizacion))
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadRuta1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadRuta = EntidadRuta1
        'End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadPrecio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        'Dim EntidadRuta1 = New Entidad.Rutas()
        'EntidadRuta1 = EntidadRuta
        'EntidadRuta1.TablaConsulta = New DataTable()
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Try
        '    sqlcon1.Open()
        '    Select Case EntidadRuta1.Tarjeta.Consulta
        '        Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
        '            Dim sqldat1 As New SqlDataAdapter("ERP_ConRutCod", sqlcon1)
        '            sqldat1.Fill(EntidadRuta1.TablaConsulta)
        '        Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
        '            Dim sqldat1 As New SqlDataAdapter("ERP_ConRutEst", sqlcon1)
        '            sqldat1.Fill(EntidadRuta1.TablaConsulta)
        '        Case Else
        '    End Select
        '    EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadRuta1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadRuta = EntidadRuta1
        'End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadPrecio As Entidad.EntidadBase) Implements ICatalogo.Insertar
        'Dim EntidadRuta1 As New Entidad.Rutas()
        'EntidadRuta1 = EntidadRuta
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("ERP_InsRutCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdRuta", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadRuta1.Descripcion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadRuta1.IdEstado))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadRuta1.idUsuarioCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadRuta1.FechaCreacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadRuta1.idUsuarioActualizacion))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadRuta1.FechaActualizacion))
        '    sqlcom1.Parameters(EntidadRuta1.IdRuta).Direction = ParameterDirection.InputOutput
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadRuta1.IdRuta = sqlcom1.Parameters(EntidadRuta1.IdRuta).Value
        '    EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadRuta1.Tarjeta.Excepcion = ex.Message.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadRuta = EntidadRuta1
        'End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPrecio As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim EntidadPrecio1 As New Entidad.Precio()
        EntidadPrecio1 = EntidadPrecio
        EntidadPrecio1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisProPreCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdProducto", EntidadPrecio1.IdProducto))
            sqldat1.Fill(EntidadPrecio1.TablaConsulta)
            EntidadPrecio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadPrecio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadPrecio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class

