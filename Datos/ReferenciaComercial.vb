Imports System.Threading
Imports System.Data.SqlClient
Public Class ReferenciaComercial
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadReferenciaComercial1 As New Entidad.ReferenciaComercial()
        EntidadReferenciaComercial1 = EntidadReferenciaComercial
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        EntidadReferenciaComercial1.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Datos
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActRefComCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdReferenciaComercial", EntidadReferenciaComercial1.IdReferenciaComercial))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadReferenciaComercial1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", EntidadReferenciaComercial1.Domicilio))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", EntidadReferenciaComercial1.Telefono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadReferenciaComercial1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadReferenciaComercial1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadReferenciaComercial1.FechaActualizacion))
            sqlcom1.ExecuteNonQuery()
            EntidadReferenciaComercial1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReferenciaComercial1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReferenciaComercial1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadReferenciaComercial = EntidadReferenciaComercial1
        End Try
    End Sub

    Public Overridable Sub Consultar(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadReferenciaComercial1 = New Entidad.ReferenciaComercial()
        EntidadReferenciaComercial1 = EntidadReferenciaComercial
        EntidadReferenciaComercial1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Try
            sqlcon1.Open()
            Select Case EntidadReferenciaComercial1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.ConsultaDetallada
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConRefComDet", sqlcon1)
                    sqldat1.Fill(EntidadReferenciaComercial1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    Dim sqldat1 As New SqlDataAdapter("ERP_ConRefComBas", sqlcon1)
                    sqldat1.Fill(EntidadReferenciaComercial1.TablaConsulta)
                Case Else
            End Select
            EntidadReferenciaComercial1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReferenciaComercial1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReferenciaComercial1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadReferenciaComercial = EntidadReferenciaComercial1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadReferenciaComercial1 As New Entidad.ReferenciaComercial()
        EntidadReferenciaComercial1 = EntidadReferenciaComercial
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsRefComCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdReferenciaComercial", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadReferenciaComercial1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDomicilio", EntidadReferenciaComercial1.Domicilio))
            sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", EntidadReferenciaComercial1.Telefono))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadReferenciaComercial1.IdEstado))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadReferenciaComercial1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadReferenciaComercial1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadReferenciaComercial1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadReferenciaComercial1.FechaActualizacion))
            sqlcom1.Parameters(EntidadReferenciaComercial1.IdReferenciaComercial).Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadReferenciaComercial1.IdReferenciaComercial = sqlcom1.Parameters(EntidadReferenciaComercial1.IdReferenciaComercial).Value
            EntidadReferenciaComercial1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadReferenciaComercial1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadReferenciaComercial1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadReferenciaComercial = EntidadReferenciaComercial1
        End Try

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadReferenciaComercial As Entidad.EntidadBase) Implements ICatalogo.Obtener
    End Sub
End Class
