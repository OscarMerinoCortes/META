Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante
Public Class Municipio
    Implements ICatalogo

    Public Overridable Sub Consultar(ByRef EntidadMunicipio As Entidad.EntidadBase) Implements ICatalogo.Consultar
        Dim EntidadMunicipio1 As New Entidad.Municipio()
        EntidadMunicipio1 = EntidadMunicipio
        EntidadMunicipio1.TablaConsulta = New DataTable()
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Try
            sqlcon1.Open()
            Select Case EntidadMunicipio1.Tarjeta.Consulta
                Case Operacion.Configuracion.Constante.Consulta.Ninguno
                    sqldat1 = New SqlDataAdapter("ERP_LisMunDet", sqlcon1)
                    sqldat1.Fill(EntidadMunicipio1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaBasica
                    sqldat1 = New SqlDataAdapter("ERP_LisMunBas", sqlcon1)
                    sqldat1.Fill(EntidadMunicipio1.TablaConsulta)
                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorId
                    sqlcom1 = New SqlCommand("ERP_LisMunCodPId", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadMunicipio1.IdEntidadFederativa))
                    sqldat1.Fill(EntidadMunicipio1.TablaConsulta)

                Case Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
                    sqlcom1 = New SqlCommand("ERP_LisMunFilEntFed", sqlcon1)
                    sqldat1 = New SqlDataAdapter(sqlcom1)
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadMunicipio1.IdEntidadFederativa))
                    sqldat1.Fill(EntidadMunicipio1.TablaConsulta)
                    'por entidad federativa

            End Select
            EntidadMunicipio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMunicipio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMunicipio1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
            EntidadMunicipio = EntidadMunicipio1
        End Try
    End Sub

    Public Overridable Sub Insertar(ByRef EntidadMunicipio As Entidad.EntidadBase) Implements ICatalogo.Insertar
        Dim EntidadMunicipio1 As New Entidad.Municipio()
        EntidadMunicipio1 = EntidadMunicipio
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_InsMunCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", 0))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadMunicipio1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", EntidadMunicipio1.IdPais))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadMunicipio1.IdEntidadFederativa))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalecia", EntidadMunicipio1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadMunicipio1.IdUsuarioCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadMunicipio1.FechaCreacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadMunicipio1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMunicipio1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMunicipio1.IdEstado))
            sqlcom1.Parameters("@INIdMunicipio").Direction = ParameterDirection.InputOutput
            sqlcom1.ExecuteNonQuery()
            EntidadMunicipio1.IdMunicipio = sqlcom1.Parameters("@INIdMunicipio").Value
            EntidadMunicipio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMunicipio1.Tarjeta.Resultado = Resultado.Incorrecto
            EntidadMunicipio1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadMunicipio = EntidadMunicipio1
        End Try
    End Sub

    Public Overridable Sub Actualizar(ByRef EntidadMunicipio As Entidad.EntidadBase) Implements ICatalogo.Actualizar
        Dim EntidadMunicipio1 As New Entidad.Municipio()
        EntidadMunicipio1 = EntidadMunicipio
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_ActMunCod", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqlcom1.Parameters.Clear()
            sqlcom1.Parameters.Add(New SqlParameter("@INIdMunicipio", EntidadMunicipio1.IdMunicipio))
            sqlcom1.Parameters.Add(New SqlParameter("@IVDescripcion", EntidadMunicipio1.Descripcion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdPais", EntidadMunicipio1.IdPais))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEntidadFederativa", EntidadMunicipio1.IdEntidadFederativa))
            sqlcom1.Parameters.Add(New SqlParameter("@IVEquivalencia", EntidadMunicipio1.Equivalencia))
            sqlcom1.Parameters.Add(New SqlParameter("@INidUsuarioActualizacion", EntidadMunicipio1.IdUsuarioActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadMunicipio1.FechaActualizacion))
            sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", EntidadMunicipio1.IdEstado))
            sqlcom1.ExecuteNonQuery()
            EntidadMunicipio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadMunicipio1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadMunicipio1.Tarjeta.Excepcion = ex.ToString()
        Finally
            sqlcon1.Close()
            EntidadMunicipio = EntidadMunicipio1
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
