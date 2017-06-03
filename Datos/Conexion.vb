Module Conexion
    Public ReadOnly Cadena As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("MMunozConnectionString").ToString()
End Module
