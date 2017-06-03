Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class TipoDescuento
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoDescuento1 As New Entidad.TipoDescuento()
        EntidadTipoDescuento1 = EntidadTipoDescuento
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipDesCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDescuento", EntidadTipoDescuento1.IdTipoDescuento))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadTipoDescuento1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoDescuento1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDescuento1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDescuento1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoDescuento1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDescuento1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadTipoDescuento1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDescuento = EntidadTipoDescuento1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoDescuento1 = New Entidad.TipoDescuento()
        EntidadTipoDescuento1 = EntidadTipoDescuento
        EntidadTipoDescuento1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoDescuento1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDesDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoDescuento1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipDesBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoDescuento1.TablaConsulta)
            End Select
            EntidadTipoDescuento1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDescuento1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadTipoDescuento1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDescuento = EntidadTipoDescuento1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoDescuento1 As New Entidad.TipoDescuento()
        EntidadTipoDescuento1 = EntidadTipoDescuento
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipDesCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoDescuento", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadTipoDescuento1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoDescuento1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoDescuento1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoDescuento1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoDescuento1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoDescuento1.FechaActualizacion))
            sqlcom1.Parameters("@INIdTipoDescuento").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoDescuento1.IdTipoDescuento = sqlcom1.Parameters("@INIdTipoDescuento").Value
            EntidadTipoDescuento1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadTipoDescuento1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadTipoDescuento1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoDescuento = EntidadTipoDescuento1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDescuento As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
