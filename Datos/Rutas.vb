Imports System.Threading
Imports System.Data.SqlClient
Public Class Rutas
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadRuta1 As New Entidad.Rutas()
        EntidadRuta1 = EntidadRuta
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActRutCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdRuta", EntidadRuta1.IdRuta))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadRuta1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadRuta1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadRuta1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadRuta1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRuta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRuta = EntidadRuta1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadRuta1 = New Entidad.Rutas()
        EntidadRuta1 = EntidadRuta
        EntidadRuta1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadRuta1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConRutDet", sqlcon1)
                    sqldat1.Fill(EntidadRuta1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConRutBas", sqlcon1)
                    sqldat1.Fill(EntidadRuta1.TablaConsulta)
                Case Else
            End Select
            EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRuta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRuta = EntidadRuta1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadRuta1 As New Entidad.Rutas()
        EntidadRuta1 = EntidadRuta
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsRutCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdRuta", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadRuta1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadRuta1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadRuta1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadRuta1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadRuta1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadRuta1.FechaActualizacion))
            sqlcom1.Parameters(EntidadRuta1.IdRuta).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadRuta1.IdRuta = sqlcom1.Parameters(EntidadRuta1.IdRuta).Value
            EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadRuta1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadRuta1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadRuta = EntidadRuta1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadRuta As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
