Imports System
Imports System.Data
Imports System.DBNull
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Module Module1
    'Proceso
    Public Const ActVal = 1 'Actuliza Valores 
    Public Const SolInp = 2 'Solo Parametros Input

    'Costantes
    Public FechaCero = "01/01/1900"

    'Conexion
    Public SSStrCon(2) As String
    Public SSSqlCon(2) As SqlConnection
    Public SSSqlTra(2) As SqlTransaction
    Public SSUtiTra(2) As Boolean

    'Codigo
    Public SACodDir() As String = {"I", "O", "U"}
    Public SAValDir() As String = {ParameterDirection.Input, ParameterDirection.Output, ParameterDirection.InputOutput}
    Public SACodTip() As String = {"T", "I", "N", "V", "D", "B", "X"} ''{"T", "N", "V", "D"}
    Public SAValTip() As String = {SqlDbType.TinyInt, SqlDbType.Int, SqlDbType.Decimal, SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.Binary, SqlDbType.Image} ''{SqlDbType.TinyInt, SqlDbType.Decimal, SqlDbType.VarChar, SqlDbType.DateTime}
    Public SACodTipUsu() As String = {"A", "G", "V", "C"}
    Public SAValTipUsu() As String = {"ADMINISTRADOR", "GERENTE", "VALUADOR", "CAJERO"}
    Public SACodErr() As String = {547, 2627, 2601, 8145, 8114, 201, 8144, 8162, 207, 2812, 8146}
    Public SAValErr() As String = {"Error por relacion de datos", "El Registro no se puede guardar porque ya existe la clave.", "El Registro no se puede guardar porque ya existe la clave.", "Un Parametro declarado en el Programa no existe en el Procedimiento.", "Un Parametro declarado contine un tipo de dato erroneo.", "Un Parametro declarado en el Procedimiento no existe en el Programa.", "Existen Demasiados Parametros declarados en el Programa.", "Parametro definido como Output en el Programa no esta definido como Output en el Procedimiento.", "Nombre de columna no valido.", "No se encontro el Procedimiento.", "El Procedimiento no tiene parametros y el programa si especifica parametros."}
    Public SSErrGen As Boolean = False
    Public SSMsgPro As String
    Public SAIndLis() As String = {0, 1, 2}
    Public SACodLis() As String = {"S", "N", ""}
    Public SAValLis() As String = {"SI", "NO", ""}
    Public SAIndLisSol() As String = {0, 1, 2}
    Public SSEstSol As String = "S"
    Public SSEstVenPro As String
    'Parametros empresa
    Public SSPreAut As String
    Public SSHrsPagFac As String
    Public SSDiaPagFac As String
    Public SSVerPreOrd As String 'Precio visible en orden
    Public SSFecPro As DateTime 'Fecha Proceso del Sistema
    Public SSTipCamDol As Decimal = 0
    Public SSPorCarVal As Decimal = 0
    Public SSPerCre As String 'Perido de cobro en credito
    Public SSPlaCre As Integer 'Plazo de cobro en credito
    Public SSPerApa As String 'Periodo de cobro en apartado
    Public SSPlaApa As Integer 'Plazo de cobro en apartado
    Public SSRutaBD As String 'Ruta de almacenamiento de la BD
    Public SSForCieCaj As String 'Tipo de cierre caja
    Public SSFonCajAut As String 'INSERTAR FONDO DE CAJA DEL DIA ANTERIOR AUTOMATICAMENTE
    Public SSDiaBloVenCre As Integer 'DIAS DESPUES DEL VENCIMIENTO PARA BLOQUEO AUTOMATICO EN CREDITO
    Public SSDiaBloVenApa As Integer 'DIAS DESPUES DEL VENCIMIENTO PARA BLOQUEO AUTOMATICO EN APARTADO
    Public SSDiaBloIna As Integer 'DIAS DE INACTIVIDAD PARA BLOQUEO AUTOMATICO
    Public SSHabEmaCli As String 'HABILITAR E-MAIL EN EL CATALOGO DE CLIENTES
    Public SSRepDetCxc As String 'REPORTE DETALLADO DE CXC
    Public SSAbrVarFor As String 'ABRIR VARIAS FORMAR DE LA MISMA
    Public SSTicCanVen As String 'TICKET EN CANCELACION DE VENTA
    Public SSTicNotCre As String 'TICKET EN CANCELACION DE VENTA

    'POR SUCURSAL
    Public SSNumCopImp As Integer = 0  'NUMERO DE COPIAS AL IMPRIMIR
    Public SSTitTic01 As String = "" 'TITULO DEL TICKET 1
    Public SSTitTic02 As String = "" 'TITULO DEL TICKET 2
    Public SSTitTic03 As String = "" 'TITULO DEL TICKET 3
    Public SSTitTic04 As String = "" 'TITULO DEL TICKET 4
    Public SSTitTic05 As String = "" 'TITULO DEL TICKET 5
    Public SSLimDesVen As Decimal = 0 'LIMITE DE DESCUENTO DE VENDEDORAS EN VENTA
    Public SSLimTieHue As Decimal = 2 'LIMITE DE TIEMPO VISIBLE DE LA VENTANA DE BUSQUEDA DE HUELLA DIGITAL

    'IMPRESORAS
    Public SSImpTic As String 'IMPRESORA DE TICKETS
    Public SSImpRec As String 'IMPRESORA DE RECIBOS
    Public SSImpFac As String 'IMPRESORA DE FACTURA
    Public SSImpRep As String 'IMPRESORA DE REPORTES
    'FORMATOS DE IMPRESION
    Public SSForTic As String 'FORMATO TICKET
    Public SSForRec As String 'FORMATO RECIBO
    Public SSForFac As String 'FORMATO FACTURA
    Public SSForFacCon As String 'FORMATO FACTURA PARA CONCEPTO DE VENTA

    'FORMATOS DE IMPRESION
    Public SSVisPreTic As String 'FORMATO TICKET

    'PARAMETROS POR GRUPO
    Public SSPagEfeVen As String 'PAGO EN EFECTIVO EN VENTA
    ''Public SSPagDolVen As String 'PAGO EN DOLARES EN VENTA
    Public SSPagCheVen As String 'PAGO CON CHEQUE EN VENTA
    Public SSPagTarVen As String 'PAGO CON ATRGETA EN VENTA
    Public SSPagCreVen As String 'PAGO A CREDITO EN VENTA
    Public SSPagNotCreVen As String = "S" 'PAGO A CREDITO EN VENTA
    Public SSDesProVen As String 'DESCUENTO POR PRODUCTO EN VENTA
    Public SSDesVenVen As String 'DESCUENTO POR VENTA EN VENTA
    Public SSDepRetEfe As String 'DEPOSITO Y RETIRO EN EFECTIVO EN VENTA
    Public SSDepRetDol As String 'DEPOSITO Y RETIRO EN DOLARES EN VENTA 
    Public SSDepRetChe As String 'DEPOSITO Y RETITO EN CHECHE EN VENTA
    Public SSVerDatVen As String 'VER DATOS ADICIONALES EN VENTA
    Public SSHabConVen As String 'HABILITAR CONCEPTO DE VENTA
    Public SSHabDesCliVen As String 'HABILITAR DESCUENOT POR CLIENTE EN VENTA 
    Public SSDiasParaDev As Integer 'DIAS PERMITIDOS PARA LA DEVOLUCION
    Public SSDiasParaDes As Integer 'DIAS PERMITIDOS PARA EL DESCUENTO
    Public SSHabSelVenVen As String 'SELECCIONAR VENDEDOR EN VENTA

    'Folios
    Public SSFolio10 As Decimal = 900000
    Public SSFolio05 As Decimal = 90000

    'Usuario
    Public SSCodUsu As String
    Public SSNomUsu As String
    Public SSClaUsu As String
    Public SSDesUsu As String
    Public SSTipUsu As String
    Public SSEstUsu As String
    Public SSZonUsu As String
    Public SSSucUsu As String
    Public SSDesSucUsu As String  'DESCRIPCION DE LA SUCURSAL DEL USUARIO
    Public SSDepUsu As String
    Public SSCajUsu As String
    Public SSAlmCajUsu As String 'ALMACEN DE LA CAJA DEL USUARIO
    Public SSDesAlmUsu As String 'DESCRIPCION DEL ALMACEN DE LA CAJA DEL USUARIO
    Public SSDesCajUsu As String 'DESCRIPCION DE LA CAJA DEL USUARIO
    Public SSFecCajUsu As String 'FECHA DE TRABAJO ACTUAL DE LA CAJA
    Public SSEstCajUsu As String 'ESTADO DE LA CAJA DEL USUARIO
    Public SSEmpUsu As String
    Public SSCodAut As String 'CODIGO DE AUTORIZADO
    Public SSTipCorEqu As String 'TIPO DE CORTE DEL EQUIPO
    Public SSVerCorVen As Boolean 'TIPO DE CORTE DEL EQUIPO

    'Variables de Ambiente
    Public SSFecVac As DateTime = CDate("01/01/1900")
    'Public SSMenPri As MainMenu 'menu principal - menu principal
    Public SSDesEmp As String 'menu principal - descripcion de la empresa
    Public SSDesSuc As String 'menu principal - descripcion de la sucursal
    Public SSDesTip As String 'menu principal - descripcion del grupo
    Public SSAvaPro As Integer 'ventana de proceso - avance del proceso
    Public SSLimPro As Integer 'ventana de proceso - limite del proceso
    'Public SSRepCat As ReportDocument
    Public SSVisPreFac As String 'vista preliminar de factura
    Public SSVisPreRep As String 'vista preliminar de reportes
    Public SSRamUsu As Integer

    'Catalogos
    Public SSCodCla As String  'Clasificacion
    Public SSCodCd As Decimal 'ciudad
    Public SSCodCli As Decimal 'cliente
    Public SSCodBurCre As Decimal 'buro de credito
    Public SSDesCli As String 'Descripcion cliente
    Public SSCodEmp As String 'empresa
    Public SSCodGru As String 'Grupo
    Public SSCodEle As String  'Elemento
    Public SSCodPro As Integer  'Producto
    Public SSCodCorPro As String  'Producto Codigo Corto
    Public SSCodProPaq As Integer  'Producto paquete
    Public SSCodCorPaq As String  'Producto Codigo Corto paquete
    Public SSDesPro As String 'Descripcion
    Public SSCanPro As Integer 'Cantidad
    Public SSCodDes As Integer 'Destino
    Public SSCodDep As String 'Departamento
    Public SSCodZon As String 'Zona
    Public SSCodTipoCodBarra As Integer 'Codigo de Barras
    Public SSCodFol As Decimal  'Folio
    Public SSCodVal As Decimal  'Valor
    Public SSCodProv As Decimal  'Proveedor
    Public SSDesProv As String 'Descripcion Proveedor
    Public SSCodSol As String   'Solicitud
    Public SSCodSte As String 'Solicitante
    Public SSParGru As String 'parametros por empresa
    Public SSParCod As String 'parametros por empresa
    Public SSParSub As String 'parametros por empresa
    Public SSCodSolDet As String 'Soliditud detalle
    Public SSFolSolDet As Integer 'Soliditud detalle
    Public SSCodDoc As Decimal 'Documento Folio
    Public SSFolDocDet As Integer 'Documento detalle
    Public SSFolSolVal As Integer 'Soliditud Valor
    Public SSDesSolVal As String 'Descripcion Valor
    Public SSCodOrd As Decimal  'Orden
    Public SSFolOrd As Integer 'Orden Detalle
    Public SSTipOri As String 'Tipo de Origen
    Public SSImpPro As Double 'Importe Producto
    Public SSVarPro As Double  'Descuento Producto
    Public SSCodIva As Double  'Descuento Producto
    Public SSImpIva As Double  'Descuento Producto
    Public SSPrePro As Double 'Precio Producto
    Public SSIvaPro As Double 'Tipo de Origen
    Public SSConIva As Double 'COnfiguracion de Iva
    Public SSFolCom As Integer 'Folio compra
    Public SSCodCom As Double 'Codigo de compra
    Public SSCodCos As Integer 'Costos
    Public SSCarMas As String 'Tipo de Origen
    Public SSDepDef As String 'Departamento de Fault
    Public SSObsDes As String ' req destino
    Public SSObsDep As String ' departamento en factura
    Public SSDesDep As String ' Destino en Factura
    Public SSCodAlm As String 'Codigo del Almacen
    Public SSDesAlm As String 'Descripcion Almacen
    Public SSCodRec As Integer 'Codigo de Recepcion de Mercancia
    Public SSCodMovInv As Integer 'Codigo de Movimiento de Inventario
    Public SSCodConRec As Integer 'Codogo de Contra Recibo
    Public SSCodEquipo As Integer 'CATALOGO DE EQUIPOS
    Public SSCodBan As Integer
    Public SSCodSuc As String 'sucursal
    Public SSCodUsuCat As String  'usuario
    Public SSCodEmpFac As Decimal 'usuario
    Public SSIngreso As String 'seguridad
    Public SSOpcion As String 'seguridad


    Public SSCodSer As String 'codigo de serie
    Public SSParEmp As String 'parametros por empresa
    Public SSParSucSuc As String 'parametros por sucursal - sucursal
    Public SSParSucPar As String 'parametros por sucursal - parametro
    Public SSParIngIng As String 'parametros por ingreso - ingreso
    Public SSParIngPar As String 'parametros por ingreso - parametro
    Public SSCodOpe As Decimal 'codigo de operacion
    Public SSCodCon As Decimal 'codigo de contrato
    Public SSCodMov As Decimal      'Caja
    Public SSCodAutMov As Decimal   'Autorizacion
    Public SSSolAut As String       'Autorizacion
    Public SSCodPreAutMov As String 'PreAutorizacion

    'Datos de Conexiones 
    Public SSSerCon1 As String
    Public SSSerCon2 As String
    Public SSSerCon3 As String
    Public SSBasCon1 As String
    Public SSBasCon2 As String
    Public SSBasCon3 As String
    Public SSNomCon1 As String
    Public SSNomCon2 As String
    Public SSNomCon3 As String
    Public SSClaCon1 As String
    Public SSClaCon2 As String
    Public SSClaCon3 As String
    Public SSVerSis As String


    Public SSAltRen As Integer = 32 'TAMANO DEL RENGLON DEL GRID EN VENTA
    Public SSHabFecVen As Boolean   'MODIFICAR FECHA EN VENTA
    Public SSTipVen As String 'TIPO DE VENTA EVENTO/VENTA NORMAL

    Public SSCodVen As Integer = 0 'CODIGO DE VENTA
    Public SSCodVenDev As Integer = 0 'CODIGO DE VENTA EN DEVOLUCION
    Public SSCodDev As Integer = 0 'CODIGO DE DEVOLUCION
    Public SSCodInvFis As Integer = 0 'CODIGO DE INVENTARIO FISICO

    'IDENTIFICACION 
    Public SSCliUsuCuo As String = "" 'Codigo de Club Predeterminado
    Public SSEmpUsuCuo As String = "" 'Codigo de la Empresa en Cuotas
    'CAJA
    Public SSCodTerCre As String    'CODIGO DE TERCERO EN CREDITO
    Public SSCodDepCre As Integer   'CODIGO DE DEPENDIENTE EN CREDTITO
    Public SSNomTerDepCre As String 'NOMBRE DEL TERCERO O DEPENDIENTE
    Public SSCarPagTar As Decimal 'CARGO POR PAGO CON TARJETA
    Public SSForMil As String = "#,###,##0.00"
    Public SSPorIva As Integer

    Public SSTitTic As String 'INFORMACION DEL ENCABEZADO DEL TICKET DATOS FISCALES, DIRECCION, ETC.
    Public SSImpSalSucTicCre As String 'IMPRIMIR SALDO POR SUCURSAL EN TICKET DE CREDITO.
    Public SSGruUsuValTem As String 'GRUPO DE USUSARIO EN VALIDACIONES DE NIVEL TEMPORAL
    Public SSExpRegVerVal As String 'EXPRECION REGULAR PARA VALIDAR FOLIO DE VALE
    Public SSPerVenCliSalVen As String 'PERMITIR VENTA A CLIENTE CON SALDO VENCIDO TODOS LOS USUARIOS
    Public SSPerVenCliSalVenAdm As String 'PERMITIR VENTA A CLIENTE CON SALDO VENCIDO SOLO ADMINISTRADORES

    'CODIGO DE BARRAS
    Public SSGenCodBarAut As String 'GENERACION AUTOMATICA DEL CODIGO DE BARRAS EN PRODUCTO
    Public SSLarCadCodBar As Integer 'LARGO DE LA CADENA DEL CODIGO DE BARRA

    'HELLA DIGITAL (V1)
    'Public PTHueDig As New DPFP.Template 'Patrón de Huella Digital
    'Public PSMueHue As DPFP.Sample 'Muestra de Huella Digital
    Public PBHueVal As Boolean = False 'Huella Válida
    Public PSResVer As String 'Mensaje con la descripción del resultado de la Verifricacion
    Public PSResReg As String 'Mensaje con la descripción del resultado del Registro
    Public PBHueReg As Boolean 'Registro correcto
    Public SSNomAut As String 'Nombre del autorizado para la pantalla de Biometria

    'BITACORA DE ESTADO DE CREDITO CLIENTES
    Public SSDetCamEstCredito As String

    Public Enum Pantalla
        Producto = 1
        MovimientoInventario = 2
        Compras = 3
    End Enum

    '-----------------------------------------------------------------------------------------------------
    'CREAR PARAMETROS
    '-----------------------------------------------------------------------------------------------------
    Public SSPreIva As String = "S"  'USAR EL PRECIO CON IVA O SIN IVA

End Module