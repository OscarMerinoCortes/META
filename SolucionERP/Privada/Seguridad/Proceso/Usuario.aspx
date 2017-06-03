<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Usuario.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Src="~/Wuc/WucConsultarPersona2.ascx" TagName="wucConsultarPersona" TagPrefix="WUCP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td colspan="3" class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
            <td></td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVUsuario" Width="100%" runat="server"
                            AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun"
                            BorderColor="#385c81" PagerStyle-CssClass="pgr" CaptionAlign="Top" HorizontalAlign="Left">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="VRegistro" runat="server">
            <table style="width: 100%; border-collapse: collapse;">

                <tr>
                    <td class="CeroColumna"></td>
                    <td class="PrimeraColumna">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBIdUsuario" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Username
                    </td>
                    <td>
                        <asp:TextBox ID="TBUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVUserName" runat="server" ControlToValidate="TBUsername"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEUserName" runat="server" TargetControlID="RFVUserName"></asp:ValidatorCalloutExtender>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Abreviacion
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBAbreviacion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVAbreviacion" runat="server" ControlToValidate="TBAbreviacion"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEAbreviacion" runat="server" TargetControlID="RFVAbreviacion"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Primer Nombre 
                    </td>
                    <td>
                        <asp:TextBox ID="TBPrimerNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVPrimerNombre" runat="server" ControlToValidate="TBPrimerNombre"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEPrimerNombre" runat="server" TargetControlID="RFVPrimerNombre"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVPrimerNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBPrimerNombre"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEPrimerNombre1" runat="server" TargetControlID="REVPrimerNombre"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Segundo Nombre
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBSegundoNombre" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVSegundoNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBSegundoNombre"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCESegundoNombre1" runat="server" TargetControlID="REVSegundoNombre"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Apellido Paterno
                    </td>
                    <td>
                        <asp:TextBox ID="TBApellidoPaterno" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVApellidoPaterno" runat="server" ControlToValidate="TBApellidoPaterno"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEApellidoPaterno" runat="server" TargetControlID="RFVApellidoPaterno"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVApellidoPaterno" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApellidoPaterno"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEApellidoPaterno1" runat="server" TargetControlID="REVApellidoPaterno"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Apellido Materno
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBApellidoMaterno" runat="server" Height="21px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVApellidoMaterno" runat="server" ControlToValidate="TBApellidoMaterno"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEApellidoMaterno" runat="server" TargetControlID="RFVApellidoMaterno"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVApellidoMaterno" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApellidoMaterno"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEApellidoMaterno1" runat="server" TargetControlID="REVApellidoMaterno"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Fecha Nacimiento
                    </td>
                    <td>Dia&nbsp;
                        <asp:DropDownList ID="DDDia" runat="server" Width="50px"></asp:DropDownList>
                        &nbsp;Mes&nbsp;<asp:DropDownList ID="DDMes" runat="server" Width="100px"></asp:DropDownList>
                        &nbsp;Año&nbsp;<asp:DropDownList ID="DDAño" runat="server" Width="85px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Usuario
                    </td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDTipoUsuario" runat="server" Width="123px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Sucursal
                    </td>
                    <td>
                        <asp:DropDownList ID="DDSucursal" runat="server" Width="123px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Contraseña
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBContraseña" TextMode="Password" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFVContraseña" runat="server" ControlToValidate="TBContraseña"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEContraseña" runat="server" TargetControlID="RFVContraseña"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Vigencia
                    </td>
                    <td>
                        <asp:TextBox ID="TBVigencia" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVVigencia" runat="server" ControlToValidate="TBVigencia"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEVigencia" runat="server" TargetControlID="RFVVigencia"></asp:ValidatorCalloutExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBVigencia" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Correo
                    </td>
                    <td class="SegundaColumna">
                        <asp:TextBox ID="TBCorreo" runat="server" placeholder="your@email.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVCorreo" runat="server" ControlToValidate="TBCorreo"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCECorreo" runat="server" TargetControlID="RFVCorreo"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="TBTelefono" runat="server" placeholder="Numero con 10 digitos "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVTelefono" runat="server" ControlToValidate="TBTelefono"
                            ErrorMessage="&lt;strong>Información requerida</strong> El campo es Obligatorio"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCETelefono" runat="server" TargetControlID="RFVTelefono"></asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator Display="none" ID="REVTelefono" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,10}?$"  ValidationGroup="Guardar" ControlToValidate="TBTelefono"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCETelefono1" runat="server" TargetControlID="REVTelefono"></asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="PrimeraColumna">Estado
                    </td>
                    <td class="SegundaColumna">
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="128px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td />
                    <td colspan="2">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" Visible="false" runat="server" style="width: 100%;" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
