Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class Clasificacion
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadClasificacion As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadClasificacion1 As New Entidad.Clasificacion()
        EntidadClasificacion1 = EntidadClasificacion
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActClaCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadClasificacion1.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadClasificacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadClasificacion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadClasificacion1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadClasificacion1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadClasificacion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadClasificacion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadClasificacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadClasificacion = EntidadClasificacion1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadClasificacion As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadClasificacion1 = New Entidad.Clasificacion()
        EntidadClasificacion1 = EntidadClasificacion
        EntidadClasificacion1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadClasificacion1.Tarjeta.Consulta
                Case Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConClaDet", sqlcon1)
                    sqldat1.Fill(EntidadClasificacion1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConClaBas", sqlcon1)
                    sqldat1.Fill(EntidadClasificacion1.TablaConsulta)
            End Select
            EntidadClasificacion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadClasificacion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadClasificacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadClasificacion = EntidadClasificacion1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadClasificacion As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadClasificacion1 As New Entidad.Clasificacion()
        EntidadClasificacion1 = EntidadClasificacion
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsClaCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdClasificacion", EntidadClasificacion1.IdClasificacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadClasificacion1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadClasificacion1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadClasificacion1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadClasificacion1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadClasificacion1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadClasificacion1.FechaActualizacion))
            sqlcom1.Parameters("@INIdClasificacion").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadClasificacion1.IdClasificacion = sqlcom1.Parameters("@INIdClasificacion").Value
            EntidadClasificacion1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadClasificacion1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadClasificacion1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadClasificacion = EntidadClasificacion1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadClasificacion As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
