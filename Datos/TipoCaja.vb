Imports System.Threading
Imports System.Data.SqlClient
Public Class TipoCaja
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadTipoCaja As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadTipoCaja1 As New Entidad.TipoCaja()
        EntidadTipoCaja1 = EntidadTipoCaja
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActTipCajCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCaja", EntidadTipoCaja1.IdTipoCaja))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadTipoCaja1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoCaja1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadTipoCaja1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoCaja1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoCaja1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoCaja1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadTipoCaja1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoCaja1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoCaja = EntidadTipoCaja1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadTipoCaja As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadTipoCaja1 = New Entidad.TipoCaja()
        EntidadTipoCaja1 = EntidadTipoCaja
        EntidadTipoCaja1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadTipoCaja1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCajDet", sqlcon1)
                    sqldat1.Fill(EntidadTipoCaja1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConTipCajBas", sqlcon1)
                    sqldat1.Fill(EntidadTipoCaja1.TablaConsulta)
                Case Else
            End Select
            EntidadTipoCaja1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoCaja1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoCaja = EntidadTipoCaja1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadTipoCaja As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadTipoCaja1 As New Entidad.TipoCaja()
        EntidadTipoCaja1 = EntidadTipoCaja
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsTipCajCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoCaja", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadTipoCaja1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadTipoCaja1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadTipoCaja1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", EntidadTipoCaja1.IdSucursal))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadTipoCaja1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadTipoCaja1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadTipoCaja1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadTipoCaja1.FechaActualizacion))
            sqlcom1.Parameters(EntidadTipoCaja1.IdTipoCaja).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadTipoCaja1.IdTipoCaja = sqlcom1.Parameters(EntidadTipoCaja1.IdTipoCaja).Value

            EntidadTipoCaja1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadTipoCaja1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadTipoCaja1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadTipoCaja = EntidadTipoCaja1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadTipoDomicilio As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
