Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Sucursal
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadSucursal1 As New Entidad.Sucursal()
        EntidadSucursal1 = EntidadSucursal
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActSucCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadSucursal1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadSucursal1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSucursal1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadSucursal1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSucursal1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadSucursal1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSucursal1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSucursal1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSucursal = EntidadSucursal1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadSucursal1 = New Entidad.Sucursal()
        EntidadSucursal1 = EntidadSucursal
        EntidadSucursal1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadSucursal1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSucDet", sqlcon1)
                    sqldat1.Fill(EntidadSucursal1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConSucBas", sqlcon1)
                    sqldat1.Fill(EntidadSucursal1.TablaConsulta)
            End Select
            EntidadSucursal1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSucursal1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSucursal1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSucursal = EntidadSucursal1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadSucursal1 As New Entidad.Sucursal()
        EntidadSucursal1 = EntidadSucursal
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsSucCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadSucursal1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadSucursal1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadSucursal1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadSucursal1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadSucursal1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadSucursal1.FechaActualizacion))
            sqlcom1.Parameters("@INIdSucursal").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadSucursal1.IdSucursal = sqlcom1.Parameters("@INIdSucursal").Value
            EntidadSucursal1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadSucursal1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadSucursal1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadSucursal = EntidadSucursal1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadSucursal As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
