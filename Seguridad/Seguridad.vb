Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports System.Text

Namespace Autorizacion
    Public Class Opcion

        Shared Function PermisosOpcion(ByRef EntidadSeguridad As Entidad.EntidadBase) As Boolean
            Dim EntidadSeguridad1 As New Entidad.Seguridad
            EntidadSeguridad1 = EntidadSeguridad
            Dim sqlcon1 As New SqlConnection(Cadena)
            Dim sqlcom1 As SqlCommand
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ActSegOpc", sqlcon1)

                For Each MiTableRow As DataRow In EntidadSeguridad1.TablaOpciones.Rows
                    sqlcom1.CommandText = "ERP_ActSegOpc"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()

                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAcceso", MiTableRow("IdAcceso")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", 1))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", MiTableRow("IdTipoUsuario")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdOpcion", MiTableRow("IdOpcion")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(Now)))
                    sqlcom1.ExecuteNonQuery()
                Next
                For Each MiTableRow As DataRow In EntidadSeguridad1.TablaModulos.Rows
                    sqlcom1.CommandText = "ERP_ActSegMod"
                    sqlcom1.CommandType = CommandType.StoredProcedure
                    sqlcom1.Parameters.Clear()
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdAcceso", MiTableRow("IdAcceso")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", 1))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", MiTableRow("IdTipoUsuario")))
                    sqlcom1.Parameters.Add(New SqlParameter("@INIdModulo", MiTableRow("IdModulo")))
                    sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate(Now)))
                    sqlcom1.ExecuteNonQuery()
                Next
                EntidadSeguridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadSeguridad1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadSeguridad1.Tarjeta.Excepcion = ex.Message.ToString()
            Finally
                sqlcon1.Close()
                EntidadSeguridad = EntidadSeguridad1
            End Try
            Return True
        End Function


        Shared Function Validar(ByVal Tarjeta As Entidad.Tarjeta) As Boolean
            Dim EntidadSeguridadOpcion As New Entidad.Seguridad()
            EntidadSeguridadOpcion.Tarjeta = Tarjeta
            EntidadSeguridadOpcion.idAcceso = Consultar(EntidadSeguridadOpcion)
            If EntidadSeguridadOpcion.idAcceso = Operacion.Configuracion.Constante.Acceso.Habilitado Then
                '  Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
                Return True
            Else
                '  Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
                Return False
            End If
            Return True
        End Function
        Shared Function Consultar(ByVal EntidadSeguridadOpcion As Entidad.Seguridad) As Integer
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            'EntidadSeguridadOpcion.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Seguridad
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ConSegOpcCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@idTipoUsuario", EntidadSeguridadOpcion.Tarjeta.IdTipoUsuario))
                sqlcom1.Parameters.Add(New SqlParameter("@idOpcion", EntidadSeguridadOpcion.Tarjeta.IdOpcion))
                sqlcom1.Parameters.Add(New SqlParameter("@idAcceso", 0))
                sqlcom1.Parameters("@idAcceso").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                EntidadSeguridadOpcion.idAcceso = sqlcom1.Parameters("@idAcceso").Value
                EntidadSeguridadOpcion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadSeguridadOpcion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadSeguridadOpcion.Tarjeta.Excepcion = ex.ToString()
            Finally
                sqlcon1.Close()
                'Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
            End Try
            Return EntidadSeguridadOpcion.idAcceso
        End Function

    End Class
    Public Class Transaccion



        Shared Function Validar(ByVal Tarjeta As Entidad.Tarjeta) As Boolean
            Dim EntidadSeguridadTransaccion As New Entidad.Seguridad()
            EntidadSeguridadTransaccion.Tarjeta = Tarjeta
            EntidadSeguridadTransaccion.idAcceso = Consultar(EntidadSeguridadTransaccion)
            If EntidadSeguridadTransaccion.idAcceso = Operacion.Configuracion.Constante.Acceso.Habilitado Then
                '  Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
                Return True
            Else
                '  Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
                Return False
            End If
            Return True
        End Function


        Shared Function Consultar(ByVal EntidadSeguridadTransaccion As Entidad.Seguridad) As Integer
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            'EntidadSeguridadOpcion.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Seguridad
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ConSegTranCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", EntidadSeguridadTransaccion.Tarjeta.IdTipoUsuario))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdOpcion", EntidadSeguridadTransaccion.Tarjeta.IdOpcion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTransaccion", EntidadSeguridadTransaccion.Tarjeta.IdTransaccion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAcceso", 0))
                sqlcom1.Parameters("@INIdAcceso").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                EntidadSeguridadTransaccion.idAcceso = sqlcom1.Parameters("@INIdAcceso").Value
                EntidadSeguridadTransaccion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadSeguridadTransaccion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadSeguridadTransaccion.Tarjeta.Excepcion = ex.ToString()
            Finally
                sqlcon1.Close()
                'Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
            End Try
            Return EntidadSeguridadTransaccion.idAcceso
        End Function



        Private Function PermisosTransaccion(ByRef EntidadUsuario As Entidad.EntidadBase) As Boolean
            Dim EntidadUsuario1 As New Entidad.Usuario()
            EntidadUsuario1 = EntidadUsuario
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_InsPerUsuOpc", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioPermiso", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadUsuario1.IdUsuario))
                sqlcom1.Parameters.Add(New SqlParameter("@INGuardar", EntidadUsuario1.Guardar))
                sqlcom1.Parameters.Add(New SqlParameter("@INActualizar", EntidadUsuario1.Actualizar))
                sqlcom1.Parameters.Add(New SqlParameter("@INConsultar", EntidadUsuario1.Consultar))
                sqlcom1.Parameters.Add(New SqlParameter("@INCancelar", EntidadUsuario1.Cancelar))
                sqlcom1.Parameters.Add(New SqlParameter("@INExportar", EntidadUsuario1.Exportar))
                sqlcom1.Parameters.Add(New SqlParameter("@INImprimir", EntidadUsuario1.Imprimir))
                sqlcom1.Parameters.Add(New SqlParameter("@INAplicar", EntidadUsuario1.Aplicar))
                sqlcom1.Parameters.Add(New SqlParameter("@INCatalogos", EntidadUsuario1.Catalogo))
                sqlcom1.Parameters.Add(New SqlParameter("@INProceso", EntidadUsuario1.Proceso))
                sqlcom1.Parameters.Add(New SqlParameter("@INReporte", EntidadUsuario1.Reporte))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", EntidadUsuario1.IdUsuarioCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", EntidadUsuario1.FechaCreacion))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", EntidadUsuario1.IdUsuarioActualizacion))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", EntidadUsuario1.FechaActualizacion))
                sqlcom1.Parameters(EntidadUsuario1.IdTipoUsuario).Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                EntidadUsuario1.IdTipoUsuario = sqlcom1.Parameters(EntidadUsuario1.IdTipoUsuario).Value
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
            Finally
                sqlcon1.Close()
                EntidadUsuario = EntidadUsuario1
            End Try
            Return True
        End Function
    End Class
End Namespace
Namespace Autenticacion

    Public Class Session
        Public Shared Sub Abrir(ByRef EntidadSesion As Entidad.Sesion)
            Dim Bitacora As New Bitacora()
            ' EntidadSesion.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Seguridad
            ' EntidadSesion.Tarjeta.IdTransaccion = Operacion.Configuracion.Constante.Transaccion.SessionAbrir
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_InsActBitSes", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSesion", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IVNombreEquipo", My.Computer.Name.ToString))
                sqlcom1.Parameters.Add(New SqlParameter("@IVIPV6", EntidadSesion.IPV6))
                sqlcom1.Parameters.Add(New SqlParameter("@IVIPV4", EntidadSesion.IPV4))
                sqlcom1.Parameters.Add(New SqlParameter("@IVDireccionMac", getMacAddress()))
                sqlcom1.Parameters.Add(New SqlParameter("@INLatitud", EntidadSesion.Latitud)) 'EntidadSesion.Latitud
                sqlcom1.Parameters.Add(New SqlParameter("@INLongitud", EntidadSesion.Longitud)) 'EntidadSesion.Longitud
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadSesion.IdUsuario))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", CDate(Now)))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", ""))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 1))
                sqlcom1.Parameters("@INIdSesion").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                EntidadSesion.IdSesion = sqlcom1.Parameters("@INIdSesion").Value
                EntidadSesion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadSesion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadSesion.Tarjeta.Excepcion = ex.Message.ToString()
            Finally
                sqlcon1.Close()
            End Try
        End Sub

        Public Shared Sub Cerrar(ByRef EntidadSesion As Entidad.Sesion)
            Dim Bitacora As New Bitacora()
            'EntidadSesion.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Seguridad
            'EntidadSesion.Tarjeta.IdTransaccion = Operacion.Configuracion.Constante.Transaccion.Actualizar
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_InsActBitSes", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSesion", EntidadSesion.IdSesion))
                sqlcom1.Parameters.Add(New SqlParameter("@IVNombreEquipo", My.Computer.Name.ToString))
                sqlcom1.Parameters.Add(New SqlParameter("@IVIPV6", ""))
                sqlcom1.Parameters.Add(New SqlParameter("@IVIPV4", ""))
                sqlcom1.Parameters.Add(New SqlParameter("@IVDireccionMac", getMacAddress()))
                sqlcom1.Parameters.Add(New SqlParameter("@INLatitud", 1))
                sqlcom1.Parameters.Add(New SqlParameter("@INLongitud", 1))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", EntidadSesion.IdUsuario))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaInicio", ""))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaFin", CDate(Now)))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 2))
                'sqlcom1.Parameters("@INIdSesion").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                'EntidadSesion.Tarjeta.IdSesion = sqlcom1.Parameters("@INIdSesion").Value
                EntidadSesion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadSesion.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadSesion.Tarjeta.Excepcion = ex.Message.ToString()
            Finally
                sqlcon1.Close()
            End Try
        End Sub



        Shared Function getMacAddress() As String
            Try
                Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
                Dim adapter As NetworkInterface
                Dim myMac As String = String.Empty

                For Each adapter In adapters
                    Select Case adapter.NetworkInterfaceType
                'Exclude Tunnels, Loopbacks and PPP
                        Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                        Case Else
                            If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                                myMac = adapter.GetPhysicalAddress.ToString
                                Exit For ' Got a mac so exit for
                            End If
                    End Select
                Next adapter
                Return myMac
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function
    End Class

    Public Class Usuario

        Public Sub ValidarUsuario1(ByRef EntidadUsuario As Entidad.EntidadBase)
            Dim EntidadUsuario1 = New Entidad.Usuario()
            EntidadUsuario1 = EntidadUsuario
            EntidadUsuario1.TablaConsulta = New DataTable()
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            Dim sqldat1 As SqlDataAdapter
            Try
                sqlcon1.Open()
                Select Case EntidadUsuario1.Tarjeta.Consulta
                    'inicio sesion
                    Case Operacion.Configuracion.Constante.Consulta.ConsultaPorFiltro
                        sqlcom1 = New SqlCommand("ERP_ConUsuSes", sqlcon1)
                        sqldat1 = New SqlDataAdapter(sqlcom1)
                        sqlcom1.CommandType = CommandType.StoredProcedure
                        sqlcom1.Parameters.Clear()
                        sqlcom1.Parameters.Add(New SqlParameter("@IVUsuario", EntidadUsuario1.Username))
                        sqlcom1.Parameters.Add(New SqlParameter("@IVClave", EntidadUsuario1.Clave))
                        sqldat1.Fill(EntidadUsuario1.TablaConsulta)
                    Case Else
                End Select
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
            Finally
                sqlcon1.Close()
                EntidadUsuario = EntidadUsuario1
            End Try
        End Sub

        'cuanto
        Shared Function Validar(ByVal Tarjeta As Entidad.Tarjeta) As Boolean
            Dim EntidadSeguridadUsuario As New Entidad.Seguridad
            EntidadSeguridadUsuario.Tarjeta = Tarjeta
            EntidadSeguridadUsuario.idAcceso = Consultar(EntidadSeguridadUsuario)
            If EntidadSeguridadUsuario.idAcceso = Operacion.Configuracion.Constante.Acceso.Habilitado Then
                '  Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
                Return True
            Else
                '  Bitacora.Insertar(EntidadSeguridadOpcion.Tarjeta)
                Return False
            End If
            Return True
        End Function

        Public Shared Sub Obtener(ByRef EntidadUsuario As Entidad.Usuario)
            Dim EntidadUsuario1 As New Entidad.Usuario()
            Dim Bitacora As New Bitacora()
            EntidadUsuario1 = EntidadUsuario
            'EntidadUsuario1.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Seguridad
            'EntidadUsuario1.Tarjeta.IdTransaccion = Operacion.Configuracion.Constante.Transaccion.UsuarioConsultar
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ConUsuCod", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@IVUsername", EntidadUsuario1.Username)) 'EntidadUsuario1.Username
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuario", 0))
                'sqlcom1.Parameters.Add(New SqlParameter("@Userid", String.Empty))
                sqlcom1.Parameters.Add(New SqlParameter("@IVAbreviacion", String.Empty))
                sqlcom1.Parameters.Add(New SqlParameter("@IVNombre", String.Empty))
                'sqlcom1.Parameters.Add(New SqlParameter("@idEmpresa", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdTipoUsuario", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IDVigencia", CDate("01/01/1900")))
                sqlcom1.Parameters.Add(New SqlParameter("@IVCorreo", String.Empty))
                sqlcom1.Parameters.Add(New SqlParameter("@IVTelefono", String.Empty))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdEstado", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioCreacion", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaCreacion", CDate("01/01/1900")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdUsuarioActualizacion", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFechaActualizacion", CDate("01/01/1900")))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdSucursal", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IVSucursal", String.Empty))
                sqlcom1.Parameters("@INIdUsuario").Direction = ParameterDirection.InputOutput
                'sqlcom1.Parameters("@Userid").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IVAbreviacion").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IVNombre").Direction = ParameterDirection.InputOutput
                'sqlcom1.Parameters("@idEmpresa").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@INIdTipoUsuario").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IDVigencia").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IVCorreo").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IVTelefono").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@INIdEstado").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@INIdUsuarioCreacion").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IDFechaCreacion").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@INIdUsuarioActualizacion").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IDFechaActualizacion").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@INIdSucursal").Direction = ParameterDirection.InputOutput
                sqlcom1.Parameters("@IVSucursal").Direction = ParameterDirection.InputOutput
                'sqlcom1.Parameters("@Userid").Size = 100
                sqlcom1.Parameters("@IVAbreviacion").Size = 100
                sqlcom1.Parameters("@IVNombre").Size = 100
                sqlcom1.Parameters("@IVCorreo").Size = 100
                sqlcom1.Parameters("@IVTelefono").Size = 100
                sqlcom1.Parameters("@IVSucursal").Size = 100
                sqlcom1.ExecuteNonQuery()
                EntidadUsuario1.IdUsuario = sqlcom1.Parameters("@INIdUsuario").Value
                'EntidadUsuario1.UserId = sqlcom1.Parameters("@Userid").Value
                EntidadUsuario1.Abreviacion = sqlcom1.Parameters("@IVAbreviacion").Value
                EntidadUsuario1.PrimerNombre = sqlcom1.Parameters("@IVNombre").Value
                'EntidadUsuario1.IdEmpresa = sqlcom1.Parameters("@idEmpresa").Value
                EntidadUsuario1.IdTipoUsuario = sqlcom1.Parameters("@INIdTipoUsuario").Value
                EntidadUsuario1.Vigencia = sqlcom1.Parameters("@IDVigencia").Value
                EntidadUsuario1.Correo = sqlcom1.Parameters("@IVCorreo").Value
                EntidadUsuario1.Telefono = sqlcom1.Parameters("@IVTelefono").Value
                EntidadUsuario1.IdEstado = sqlcom1.Parameters("@INIdEstado").Value
                EntidadUsuario1.IdUsuarioCreacion = sqlcom1.Parameters("@INIdUsuarioCreacion").Value
                EntidadUsuario1.FechaCreacion = sqlcom1.Parameters("@IDFechaCreacion").Value
                EntidadUsuario1.IdUsuarioActualizacion = sqlcom1.Parameters("@INIdUsuarioActualizacion").Value
                EntidadUsuario1.FechaActualizacion = sqlcom1.Parameters("@IDFechaActualizacion").Value
                EntidadUsuario1.IdSucursal = sqlcom1.Parameters("@INIdSucursal").Value
                EntidadUsuario1.Sucursal = sqlcom1.Parameters("@IVSucursal").Value
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadUsuario1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadUsuario1.Tarjeta.Excepcion = ex.Message.ToString()
            Finally
                sqlcon1.Close()
                EntidadUsuario = EntidadUsuario1
                'Bitacora.Insertar(EntidadUsuario1.Tarjeta)
            End Try
        End Sub


        Shared Function Consultar(ByVal EntidadSeguridadUsuario As Entidad.Seguridad) As Integer
            Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
            Dim sqlcom1 As SqlCommand
            EntidadSeguridadUsuario.Tarjeta.IdCapa = Operacion.Configuracion.Constante.Capa.Seguridad
            Try
                sqlcon1.Open()
                sqlcom1 = New SqlCommand("ERP_ConLogUsu", sqlcon1)
                sqlcom1.CommandType = CommandType.StoredProcedure
                sqlcom1.Parameters.Clear()
                sqlcom1.Parameters.Add(New SqlParameter("@IVUserName", EntidadSeguridadUsuario.Tarjeta.Username))
                sqlcom1.Parameters.Add(New SqlParameter("@IVClave", EntidadSeguridadUsuario.Tarjeta.Clave))
                sqlcom1.Parameters.Add(New SqlParameter("@INIdAcceso", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IDFecha", Now))
                sqlcom1.Parameters("@INIdAcceso").Direction = ParameterDirection.InputOutput
                sqlcom1.ExecuteNonQuery()
                EntidadSeguridadUsuario.idAcceso = sqlcom1.Parameters("@INIdAcceso").Value
                EntidadSeguridadUsuario.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
            Catch ex As Exception
                EntidadSeguridadUsuario.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
                EntidadSeguridadUsuario.Tarjeta.Excepcion = ex.ToString()
            Finally
                sqlcon1.Close()
                'Bitacora.Insertar(EntidadSeguridadUsuario.Tarjeta)
            End Try
            Return EntidadSeguridadUsuario.idAcceso
        End Function
        ''cuanto



        Shared Function GetSha512Hash(ByVal md5Hash As SHA512, ByVal input As String) As String

            ' Convert the input string to a byte array and compute the hash.
            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

            ' Create a new Stringbuilder to collect the bytes
            ' and create a string.
            Dim sBuilder As New StringBuilder()

            ' Loop through each byte of the hashed data 
            ' and format each one as a hexadecimal string.
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string.
            Return sBuilder.ToString()

        End Function 'GetMd5Hash
        'Iniciar Sesion
        Shared Function ValidarUsuario(ByVal Usuario As String, ByVal Contrasena As String) As Boolean


            Return True

        End Function 'IniciarSesion
    End Class
End Namespace
Public Class Bitacora

End Class

