Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class Cargo
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadCargo1 As New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActCarCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCargo", EntidadCargo1.IdCargo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadCargo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCargo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCargo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCargo1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadCargo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCargo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCargo = EntidadCargo1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadCargo1 = New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        EntidadCargo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadCargo1.Tarjeta.Consulta
                Case Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConCarDet", sqlcon1)
                    sqldat1.Fill(EntidadCargo1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConCarBas", sqlcon1)
                    sqldat1.Fill(EntidadCargo1.TablaConsulta)
            End Select
            EntidadCargo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCargo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCargo = EntidadCargo1
        End Try
    End Sub

    Public Sub ConsultarVenta(ByRef EntidadCargo As Entidad.EntidadBase)
        Dim EntidadCargo1 = New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        EntidadCargo1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadCargo1.Tarjeta.Consulta
                Case Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCarVenDet", sqlcon1)
                    sqldat1.Fill(EntidadCargo1.TablaConsulta)
                Case Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCarVenBas", sqlcon1)
                    sqldat1.Fill(EntidadCargo1.TablaConsulta)
                Case Consulta.Ninguno
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCarVenAut", sqlcon1)
                    sqldat1.Fill(EntidadCargo1.TablaConsulta)
            End Select
            EntidadCargo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCargo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCargo = EntidadCargo1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadCargo1 As New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsCarCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdCargo", EntidadCargo1.IdCargo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadCargo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCargo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCargo1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCargo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCargo1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCargo1.FechaActualizacion))
            sqlcom1.Parameters("@INIdCargo").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadCargo1.IdCargo = sqlcom1.Parameters("@INIdCargo").Value
            EntidadCargo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCargo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCargo = EntidadCargo1
        End Try

    End Sub

    Public Sub InsertarActualizarVenta(ByRef EntidadCargo As Entidad.EntidadBase)
        Dim EntidadCargo1 As New Entidad.Cargo()
        EntidadCargo1 = EntidadCargo
        Dim sqlcon1 As New SqlConnection(Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsActTipCarVen", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCargoVenta", EntidadCargo1.IdCargo))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadCargo1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion ", EntidadCargo1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INMonto", EntidadCargo1.Monto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoMonto", EntidadCargo1.IdTipoMonto))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCargo", EntidadCargo1.IdTipoCargo))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdAutomatico", EntidadCargo1.IdAutomatico))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadCargo1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadCargo1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadCargo1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadCargo1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadCargo1.FechaActualizacion))
            sqlcom1.Parameters("@INIdTipoCargoVenta").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadCargo1.IdCargo = sqlcom1.Parameters("@INIdTipoCargoVenta").Value
            EntidadCargo1.Tarjeta.Resultado = Resultado.Correcto
        Catch ex As Exception
            EntidadCargo1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadCargo1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadCargo = EntidadCargo1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadCargo As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
    'Public Sub ObtenerVenta(ByRef EntidadCargo As Entidad.EntidadBase)
    '    Dim EntidadCargo1 = New Entidad.Cargo()
    '    EntidadCargo1 = EntidadCargo
    '    EntidadCargo1.TablaConsulta = New DataTable()
    '    Dim sqlcom1 As SqlCommand
    '    Dim sqldat1 As SqlDataAdapter
    '    Dim sqlcon1 As New SqlConnection(Cadena)
    '    Try
    '        sqlcon1.Open()
    '        sqlcom1 = New SqlCommand("ERP_ObtUltVen", sqlcon1)
    '        sqlcom1.CommandType = CommandType.StoredProcedure
    '        sqlcom1.Parameters.Clear()
    '        sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadCargo1.IdSucursal))
    '        sqldat1 = New SqlDataAdapter(sqlcom1)
    '        sqldat1.Fill(EntidadCargo1.TablaConsulta)
    '        EntidadCargo1.Tarjeta.Resultado = Resultado.Correcto
    '    Catch ex As Exception
    '        EntidadCargo1.Tarjeta.Resultado = Resultado.Incorrecto
    '        EntidadCargo1.Tarjeta.Excepcion = ex.Message.ToString()
    '    Finally
    '        sqlcon1.Close()
    '        EntidadCargo = EntidadCargo1
    '    End Try
    'End Sub
End Class
