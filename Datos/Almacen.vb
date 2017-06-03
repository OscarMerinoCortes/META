Imports System.Data.SqlClient
Imports Entidad
Imports Operacion.Configuracion.Constante

Public Class Almacen
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadAlmacen As EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadAlmacen1 As New Entidad.Almacen()
        EntidadAlmacen1 = EntidadAlmacen
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActAlmCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", EntidadAlmacen1.IdAlmacen))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadAlmacen1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadAlmacen1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INDevolucion", EntidadAlmacen1.Devolucion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadAlmacen1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadAlmacen1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadAlmacen1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INPredeterminado", EntidadAlmacen1.Predetermiando))
            sqlcom1.ExecuteNonQuery()
            EntidadAlmacen1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadAlmacen1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadAlmacen1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadAlmacen = EntidadAlmacen1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadAlmacen As EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadAlmacen1 = New Entidad.Almacen()
        EntidadAlmacen1 = EntidadAlmacen
        EntidadAlmacen1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadAlmacen1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConAlmDet", sqlcon1)
                    sqldat1.Fill(EntidadAlmacen1.TablaConsulta)

                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConAlmBas", sqlcon1)
                    sqldat1.Fill(EntidadAlmacen1.TablaConsulta)
                Case Consulta.ConsultaBusqueda
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConAlmSucBas", sqlcon1)
                    sqldat1.Fill(EntidadAlmacen1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorIdPadre
                    Dim sqlcom1 = New SqlCommand("ERP_ConAlmIdPad", sqlcon1)
                    Dim sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    If EntidadAlmacen1.IdSucursal = 1 Then
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadAlmacen1.IdSucursal))
                    Else
                        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadAlmacen1.IdSucursal))
                    End If
                    sqldat1.Fill(EntidadAlmacen1.TablaConsulta)
            End Select
            EntidadAlmacen1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadAlmacen1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadAlmacen1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadAlmacen = EntidadAlmacen1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadAlmacen As EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadAlmacen1 As New Entidad.Almacen()
        EntidadAlmacen1 = EntidadAlmacen
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsAlmCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAlmacen", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadAlmacen1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadAlmacen1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDevolucion", EntidadAlmacen1.Devolucion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadAlmacen1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadAlmacen1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadAlmacen1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadAlmacen1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadAlmacen1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INPredeterminado", EntidadAlmacen1.Predetermiando))
            sqlcom1.Parameters("@INIdAlmacen").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadAlmacen1.IdAlmacen = sqlcom1.Parameters("@INIdAlmacen").Value
            EntidadAlmacen1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadAlmacen1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadAlmacen1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadAlmacen = EntidadAlmacen1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadAlmacen As EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
