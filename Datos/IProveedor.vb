Public Interface IProveedor
    Sub Consultar(ByRef EntidadBase As Entidad.EntidadBase)
    Sub Obtener(ByRef EntidadBase As Entidad.Proveedor)
    Sub Insertar(ByRef EntidadBase As Entidad.EntidadBase)
    Sub Actualizar(ByRef EntidadBase As Entidad.EntidadBase)
End Interface
