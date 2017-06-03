Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class EntidadFederativa
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadEntidadFederativa As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadEntidadFederativa1 As New Entidad.EntidadFederativa()
        EntidadEntidadFederativa1 = EntidadEntidadFederativa
        EntidadEntidadFederativa1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadEntidadFederativa1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_LisEntFedDet", sqlcon1)
                    sqldat1.Fill(EntidadEntidadFederativa1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisEntFedBas", sqlcon1)
                    sqldat1.Fill(EntidadEntidadFederativa1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_LisEntFedCodPId ", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", EntidadEntidadFederativa1.IdPais))
                    sqldat1.Fill(EntidadEntidadFederativa1.TablaConsulta)
            End Select
            EntidadEntidadFederativa1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadEntidadFederativa1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadEntidadFederativa1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadEntidadFederativa = EntidadEntidadFederativa1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadEntidadFederativa As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadEntidadFederativa1 As New Entidad.EntidadFederativa()
        EntidadEntidadFederativa1 = EntidadEntidadFederativa
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsEntFedCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadEntidadFederativa1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", EntidadEntidadFederativa1.IdPais))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalecia", EntidadEntidadFederativa1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadEntidadFederativa1.idUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadEntidadFederativa1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadEntidadFederativa1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadEntidadFederativa1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadEntidadFederativa1.IdEstado))
            sqlcom1.Parameters("@INIdEntidadFederativa").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadEntidadFederativa1.IdEntidadFederativa = sqlcom1.Parameters("@INIdEntidadFederativa").Value
            EntidadEntidadFederativa1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadEntidadFederativa1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadEntidadFederativa1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadEntidadFederativa = EntidadEntidadFederativa1
        End Try
    End Sub

    Public Overridable Sub Actualizar(ByRef EntidadEntidadFederativa As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadEntidadFederativa1 As New Entidad.EntidadFederativa()
        EntidadEntidadFederativa1 = EntidadEntidadFederativa
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActEntFedCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadEntidadFederativa1.IdEntidadFederativa))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadEntidadFederativa1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", EntidadEntidadFederativa1.IdPais))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadEntidadFederativa1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INidUsuarioActualizacion", EntidadEntidadFederativa1.idUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadEntidadFederativa1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadEntidadFederativa1.IdEstado))
            sqlcom1.ExecuteNonQuery()
            EntidadEntidadFederativa1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadEntidadFederativa1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadEntidadFederativa1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadEntidadFederativa = EntidadEntidadFederativa1
        End Try
    End Sub

    Public Overridable Sub Obtener(ByRef EntidadPais As Entidad.EntidadBase) Implements ICatalogo.Obtener
        'Dim EntidadPais1 As New Entidad.Pais()
        'EntidadPais1 = EntidadPais
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqlcom1 As SqlCommand
        'Try
        '    sqlcon1.Open()
        '    sqlcom1 = New SqlCommand("pld_ExiPaiCod", sqlcon1)
        '    sqlcom1.CommandType = CommandType.StoredProcedure
        '    sqlcom1.Parameters.Clear()
        '    sqlcom1.Parameters.Add(New SqlParameter("@IdPais", EntidadPais1.IdPais))
        '    sqlcom1.Parameters.Add(New SqlParameter("@CodigoUIF", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@Gentilicio", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@Equivalencia", String.Empty))
        '    sqlcom1.Parameters.Add(New SqlParameter("@IdEstado", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioCreacion", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@FechaCreacion", CDate("01/01/1900")))
        '    sqlcom1.Parameters.Add(New SqlParameter("@idUsuarioActualizacion", 0))
        '    sqlcom1.Parameters.Add(New SqlParameter("@FechaActualizacion", CDate("01/01/1900")))
        '    sqlcom1.Parameters("@CodigoUIF").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@Descripcion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@Gentilicio").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@Equivalencia").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@IdEstado").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@idUsuarioCreacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@FechaCreacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@idUsuarioActualizacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@FechaActualizacion").Direction = ParameterDirection.InputOutput
        '    sqlcom1.Parameters("@CodigoUIF").Size = 50
        '    sqlcom1.Parameters("@Descripcion").Size = 100
        '    sqlcom1.Parameters("@Gentilicio").Size = 100
        '    sqlcom1.Parameters("@Equivalencia").Size = 100
        '    sqlcom1.ExecuteNonQuery()
        '    EntidadPais1.IdPais = sqlcom1.Parameters("@idPais").Value
        '    EntidadPais1.CodigoUIF = sqlcom1.Parameters("@CodigoUIF").Value
        '    ' EntidadPais1.idEsGafi = sqlcom1.Parameters("@idEsGafi").Value
        '    'EntidadPais1.idEsParaisoFiscal = sqlcom1.Parameters("@idEsParaisoFiscal").Value
        '    EntidadPais1.Descripcion = sqlcom1.Parameters("@Descripcion").Value
        '    EntidadPais1.Gentilicio = sqlcom1.Parameters("@Gentilicio").Value
        '    EntidadPais1.Equivalencia = sqlcom1.Parameters("@Equivalencia").Value
        '    EntidadPais1.IdEstado = sqlcom1.Parameters("@IdEstado").Value
        '    EntidadPais1.idUsuarioCreacion = sqlcom1.Parameters("@idUsuarioCreacion").Value
        '    EntidadPais1.FechaCreacion = sqlcom1.Parameters("@FechaCreacion").Value
        '    EntidadPais1.idUsuarioActualizacion = sqlcom1.Parameters("@idUsuarioActualizacion").Value
        '    EntidadPais1.FechaActualizacion = sqlcom1.Parameters("@FechaActualizacion").Value
        '    EntidadPais1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadPais1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadPais1.Tarjeta.Excepcion = ex.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadPais = EntidadPais1
        '    Bitacora.Insertar(EntidadPais1.Tarjeta)
        '    'End Try
    End Sub
    Public Sub ConsultarNoEsGafi(ByRef EntidadBase As Entidad.EntidadBase)
        'Dim EntidadPais As New Entidad.Pais()
        'EntidadPais = EntidadBase
        'EntidadPais.TablaConsulta = New DataTable()
        'Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        'Dim sqldat1 As SqlDataAdapter
        'Try
        '    sqlcon1.Open()
        '    sqldat1 = New SqlDataAdapter("pld_LisPaiCodGaf", sqlcon1)
        '    sqldat1.Fill(EntidadPais.TablaConsulta)
        '    EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        'Catch ex As Exception
        '    EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '    EntidadPais.Tarjeta.Excepcion = ex.ToString()
        'Finally
        '    sqlcon1.Close()
        '    EntidadBase = EntidadPais
        '    Bitacora.Insertar(EntidadPais.Tarjeta)
        'End Try
    End Sub

    Public Sub ConsultarEsParaiso(ByRef EntidadBase As Entidad.EntidadBase)
        '    Dim EntidadPais As New Entidad.Pais()
        '    EntidadPais = EntidadBase
        '    EntidadPais.TablaConsulta = New DataTable()
        '    Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        '    Dim sqldat1 As SqlDataAdapter
        '    EntidadPais.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Datos
        '    Dim Bitacora As New Seguridad.Bitacora()
        '    Try
        '        sqlcon1.Open()
        '        sqldat1 = New SqlDataAdapter("pld_LisPaiCodPar", sqlcon1)
        '        sqldat1.Fill(EntidadPais.TablaConsulta)
        '        EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        '    Catch ex As Exception
        '        EntidadPais.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
        '        EntidadPais.Tarjeta.Excepcion = ex.ToString()
        '    Finally
        '        sqlcon1.Close()
        '        EntidadBase = EntidadPais
        '        Bitacora.Insertar(EntidadPais.Tarjeta)
        '    End Try
    End Sub
End Class
