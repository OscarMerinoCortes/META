Imports System.Data.SqlClient
Imports Operacion.Configuracion.Constante

Public Class ListaProductos
    Implements ICatalogo

    Public Overridable Sub Actualizar(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Actualizar

    End Sub

    Public Overridable Sub Consultar(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Consultar

    End Sub

    Public Overridable Sub Insertar(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Insertar

    End Sub

    Public Overridable Sub Obtener(ByRef EntidadListaProductos As Entidad.EntidadBase) Implements ICatalogo.Obtener
        Dim sqlcon1 As New SqlConnection(Conexion.Cadena)
        Dim sqlcom1 As SqlCommand
        Dim sqldat1 As SqlDataAdapter
        Dim EntidadListaProductos1 As New Entidad.ListaProductos()
        EntidadListaProductos1 = EntidadListaProductos
        EntidadListaProductos.TablaConsulta = New DataTable()
        Try
            sqlcon1.Open()
            sqlcom1 = New SqlCommand("ERP_LisProFil", sqlcon1)
            sqlcom1.CommandType = CommandType.StoredProcedure
            sqldat1 = New SqlDataAdapter(sqlcom1)
            sqlcom1.Parameters.Clear()
            If EntidadListaProductos1.Id = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdIni", EntidadListaProductos1.Id))
                sqlcom1.Parameters.Add(New SqlParameter("@IdFin", EntidadListaProductos1.Id))
            End If            
            If EntidadListaProductos1.CodigoCorto = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@CodigoCortoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@CodigoCortoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@CodigoCortoIni", EntidadListaProductos1.CodigoCorto))
                sqlcom1.Parameters.Add(New SqlParameter("@CodigoCortoFin", EntidadListaProductos1.CodigoCorto))
            End If
            sqlcom1.Parameters.Add(New SqlParameter("@Descripcion", EntidadListaProductos1.Descripcion))

            If EntidadListaProductos1.IdSucursal = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalIni", EntidadListaProductos1.IdSucursal))
                sqlcom1.Parameters.Add(New SqlParameter("@idSucursalFin", EntidadListaProductos1.IdSucursal))
            End If
            If EntidadListaProductos1.IdAlmacen = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenIni", EntidadListaProductos1.IdAlmacen))
                sqlcom1.Parameters.Add(New SqlParameter("@IdAlmacenFin", EntidadListaProductos1.IdAlmacen))
            End If
            If EntidadListaProductos1.IdClasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionIni", EntidadListaProductos1.IdClasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@idClasificacionFin", EntidadListaProductos1.IdClasificacion))
            End If
            If EntidadListaProductos1.IdSubClasificacion = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionIni", EntidadListaProductos1.IdSubClasificacion))
                sqlcom1.Parameters.Add(New SqlParameter("@idSubClasificacionFin", EntidadListaProductos1.IdSubClasificacion))
            End If
            If EntidadListaProductos1.IdEstado = -1 Then
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", 0))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", 1000000))
            Else
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoIni", EntidadListaProductos1.IdEstado))
                sqlcom1.Parameters.Add(New SqlParameter("@idEstadoFin", EntidadListaProductos1.IdEstado))
            End If

            sqldat1.Fill(EntidadListaProductos1.TablaConsulta)
            EntidadListaProductos1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Correcto
        Catch ex As Exception
            EntidadListaProductos1.Tarjeta.Resultado = Operacion.Configuracion.Constante.Resultado.Incorrecto
            EntidadListaProductos1.Tarjeta.Excepcion = ex.Message.ToString()
        Finally
            sqlcon1.Close()
        End Try
    End Sub
End Class
