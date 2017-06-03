Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class TipoProducto
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoProducto1 As New Entidad.TipoProducto()
        EntidadTipoProducto1 = EntidadTipoProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipProCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoProducto", EntidadTipoProducto1.IdTipoProducto))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadTipoProducto1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoProducto1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoProducto1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoProducto1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadTipoProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadTipoProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoProducto = EntidadTipoProducto1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoProducto1 = New Entidad.TipoProducto()
        EntidadTipoProducto1 = EntidadTipoProducto
        EntidadTipoProducto1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoProducto1.Tarjeta.Consulta
                Case Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipProDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoProducto1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipProBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoProducto1.TablaConsulta)
            End Select
            EntidadTipoProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadTipoProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadTipoProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoProducto = EntidadTipoProducto1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoProducto1 As New Entidad.TipoProducto()
        EntidadTipoProducto1 = EntidadTipoProducto
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipProCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoProducto", EntidadTipoProducto1.IdTipoProducto))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadTipoProducto1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoProducto1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoProducto1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoProducto1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoProducto1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoProducto1.FechaActualizacion))
            sqlcom1.Parameters("@INIdTipoProducto").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoProducto1.IdTipoProducto = sqlcom1.Parameters("@INIdTipoProducto").Value
            EntidadTipoProducto1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadTipoProducto1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadTipoProducto1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoProducto = EntidadTipoProducto1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoProducto As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
