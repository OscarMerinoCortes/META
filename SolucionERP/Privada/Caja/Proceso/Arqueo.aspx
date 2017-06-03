<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Arqueo.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="StyleSheet" href="../CSS/StyleSheet.css" type="text/css" />
    <script>
        function IsValid(args) {
            if (args.value.length == 0) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <style>
        .BotonError{
            border-style: none;
            border: solid 2px #ff0000;
            background: #82A7CD;
            color: black;
            font-size: 15px;
            border-radius: 5px;
            position: relative;
            box-sizing: border-box;
            transition: all 500ms ease;
            top: 0px;
            left: 0px;
        }
        .BotonCorrecto{
            border-style: none;
            border: solid 2px #385c81;
            background: #82A7CD;
            color: black;
            font-size: 15px;
            border-radius: 5px;
            position: relative;
            box-sizing: border-box;
            transition: all 500ms ease;
            top: 0px;
            left: 0px;
        }
        .auto-style32 {
            width: 101px;
        }
        .auto-style33 {
            min-width: 200px;
            max-width: 200px;
            width: 101px;
        }
        .auto-style34 {
            width: 50px;
        }
        .auto-style35 {
            min-width: 200px;
            max-width: 200px;
            width: 50px;
        }
    </style>
    <table style="width: 100%;">
        <tr>
            <td class="MenuHead">
                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="VConsulta" runat="server">
            <table style="width: 100%;">
                <tr style="text-align: center;">
                    <td style="width: 100%;">
                        <asp:GridView ID="GVArqueo" Width="100%" runat="server"
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
                    <td style="padding-right: 10px;"></td>
                    <td class="auto-style34">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBIdArqueo" runat="server" Enabled="False" Width="150px" Height="22px" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style34">
                        <asp:Label ID="Label3" runat="server" Text="Observaciones" />
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TBObservacion" runat="server" Width="150px" />
                        <asp:RequiredFieldValidator ID="RFVObservacion" runat="server" ControlToValidate="TBObservacion"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Observacion es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEObservacion" runat="server" TargetControlID="RFVObservacion"></asp:ValidatorCalloutExtender>
                    </td>
                    <td class="auto-style18"></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style34">
                        <asp:Label ID="Label2" runat="server" Text="Estado" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DDEstado" runat="server" Height="22px" Width="155px" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width: 100%;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="4"><strong>&nbsp;&nbsp;&nbsp; Arqueo</strong></td>

                </tr>
                <tr>
                    <td></td>
                    <td  ></td>
                    <td ><strong>Billetes</strong></td>
                    <td><strong>Monedas</strong></td>
                    <td ><strong>Dolares</strong></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TBBillete1000" runat="server" Width="150" OnTextChanged="TBBillete1000_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVBillete1000" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBBillete1000"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERBillete1000" runat="server" TargetControlID="REVBillete1000"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVBillete1000a" runat="server" ControlToValidate="TBBillete1000"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEBillete1000a" runat="server" TargetControlID="RFVREVBillete1000a"></asp:ValidatorCalloutExtender>
                        * 1000 =
                        <asp:Label ID="LBB1000" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBMoneda20" runat="server" Width="150" OnTextChanged="TBMoneda20_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda20" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda20"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda20" runat="server" TargetControlID="REVMoneda20"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda20a" runat="server" ControlToValidate="TBMoneda20"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda20a" runat="server" TargetControlID="RFVREVMoneda20a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 20 =
                        <asp:Label ID="LBM20" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBDolares" runat="server" Width="150" OnTextChanged="TBDolares_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVDolares" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBDolares"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERDolares" runat="server" TargetControlID="REVDolares"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVDolares1" runat="server" ControlToValidate="TBDolares"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEDolares1" runat="server" TargetControlID="RFVREVDolares1"></asp:ValidatorCalloutExtender>
                        &nbsp;*
                        <asp:Label ID="Label18" runat="server" Text="17.3581"></asp:Label>
                        &nbsp;=
                        <asp:Label ID="LBDLL" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBBillete500" runat="server" Width="150" OnTextChanged="TBBillete500_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVBillete500" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBBillete500"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERBillete500" runat="server" TargetControlID="REVBillete500"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVBillete500a" runat="server" ControlToValidate="TBBillete500"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEBillete500a" runat="server" TargetControlID="RFVREVBillete500a"></asp:ValidatorCalloutExtender>
                        * 500 =
                        <asp:Label ID="LBB500" runat="server"></asp:Label>
                    </td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBMoneda10" runat="server" Width="150" OnTextChanged="TBMoneda10_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda10" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda10"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda10" runat="server" TargetControlID="REVMoneda10"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda10a" runat="server" ControlToValidate="TBMoneda10"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda10a" runat="server" TargetControlID="RFVREVMoneda10a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 10 =
                        <asp:Label ID="LBM10" runat="server"></asp:Label>
                    </td>
                    <td class="SegundaColumna">&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td >&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TBBillete200" runat="server" Width="150" OnTextChanged="TBBillete200_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVBillete200" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBBillete200"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERBillete200" runat="server" TargetControlID="REVBillete200"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVBillete200a" runat="server" ControlToValidate="TBBillete200"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEBillete200a" runat="server" TargetControlID="RFVREVBillete200a"></asp:ValidatorCalloutExtender>
                        * 200 =
                        <asp:Label ID="LBB200" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBMoneda5" runat="server" Width="150" OnTextChanged="TBMoneda5_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda5" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda5"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda5" runat="server" TargetControlID="REVMoneda5"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda5a" runat="server" ControlToValidate="TBMoneda5"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda5a" runat="server" TargetControlID="RFVREVMoneda5a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 5 =
                        <asp:Label ID="LBM5" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td ></td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBBillete100" runat="server" Width="150" OnTextChanged="TBBillete100_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVBillete100" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBBillete100"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERBillete100" runat="server" TargetControlID="REVBillete100"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVBillete100a" runat="server" ControlToValidate="TBBillete100"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEBillete100a" runat="server" TargetControlID="RFVREVBillete100a"></asp:ValidatorCalloutExtender>
                        * 100 =
                        <asp:Label ID="LBB100" runat="server"></asp:Label>
                    </td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBMoneda2" runat="server" Width="150" OnTextChanged="TBMoneda2_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda2" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda2"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda2" runat="server" TargetControlID="REVMoneda2"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda2a" runat="server" ControlToValidate="TBMoneda2"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda2a" runat="server" TargetControlID="RFVREVMoneda2a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 2 =
                        <asp:Label ID="LBM2" runat="server"></asp:Label>
                    </td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                    <td><%--vdfg--%>
                        <asp:TextBox ID="TBBillete50" runat="server" Width="150" OnTextChanged="TBBillete50_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVBillete50" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBBillete50"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERBillete50" runat="server" TargetControlID="REVBillete50"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVBillete50a" runat="server" ControlToValidate="TBBillete50"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEBillete50a" runat="server" TargetControlID="RFVREVBillete50a"></asp:ValidatorCalloutExtender>

                        * 50 =
                        <asp:Label ID="LBB50" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBMoneda1" runat="server" Width="150" OnTextChanged="TBMoneda1_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda1" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda1"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda1" runat="server" TargetControlID="REVMoneda1"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda1a" runat="server" ControlToValidate="TBMoneda1"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda1a" runat="server" TargetControlID="RFVREVMoneda1a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 1 =
                        <asp:Label ID="LBM1" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBBillete20" runat="server" Width="150" OnTextChanged="TBBillete20_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVBillete20" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBBillete20"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERBillete20" runat="server" TargetControlID="REVBillete20"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVBillete20a" runat="server" ControlToValidate="TBBillete20"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEBillete20a" runat="server" TargetControlID="RFVREVBillete20a"></asp:ValidatorCalloutExtender>
                        * 20 =
                        <asp:Label ID="LBB20" runat="server"></asp:Label>
                    </td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBMoneda050" runat="server" Width="150" OnTextChanged="TBMoneda050_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda050" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda050"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda050" runat="server" TargetControlID="REVMoneda050"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda050a" runat="server" ControlToValidate="TBMoneda050"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda050a" runat="server" TargetControlID="RFVREVMoneda050a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 0.50 =
                        <asp:Label ID="LBM050" runat="server"></asp:Label>
                    </td>
                    <td class="SegundaColumna"></td>
                </tr>
                <tr>
                    <td></td>
                    <td ></td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TBMoneda020" runat="server" Width="150" OnTextChanged="TBMoneda020_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda020" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda020"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda020" runat="server" TargetControlID="REVMoneda020"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda020a" runat="server" ControlToValidate="TBMoneda020"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda020a" runat="server" TargetControlID="RFVREVMoneda020a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 0.20 =
                        <asp:Label ID="LBM020" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="PrimeraColumna">&nbsp;</td>
                    <td class="PrimeraColumna">
                        <asp:TextBox ID="TBMoneda010" runat="server" Width="150" OnTextChanged="TBMoneda010_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda010" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda010"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda010" runat="server" TargetControlID="REVMoneda010"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda010a" runat="server" ControlToValidate="TBMoneda010"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda010a" runat="server" TargetControlID="RFVREVMoneda010a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 0.10 =
                        <asp:Label ID="LBM010" runat="server"></asp:Label>
                    </td>
                    <td class="SegundaColumna">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td >&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TBMoneda005" runat="server" Width="150px" OnTextChanged="TBMoneda005_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="none" ID="REVMoneda005" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros" ValidationExpression="[0-9]{1,9}?$" ValidationGroup="Guardar" ControlToValidate="TBMoneda005"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="VCEERMoneda005" runat="server" TargetControlID="REVMoneda005"></asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="RFVREVMoneda005a" runat="server" ControlToValidate="TBMoneda005"
                            ErrorMessage="&lt;strong>Información requerida</strong> La Cantidad es Obligatoria"
                            Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="VCEMoneda005a" runat="server" TargetControlID="RFVREVMoneda005a"></asp:ValidatorCalloutExtender>
                        &nbsp;* 0.05 =
                        <asp:Label ID="LBM005" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td ></td>
                    <td class="PrimeraColumna"></td>
                    <td class="PrimeraColumna"></td>
                    <td class="SegundaColumna"><strong>TOTAL = </strong>
                        <asp:Label ID="LBTOTAL" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button CssClass="BotonCorrecto" ID="BTNSumar" runat="server" Text="Sumar" Width="150" ValidationGroup="Guardar" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style18 {
            width: 25%;
        }

        </style>
</asp:Content>

