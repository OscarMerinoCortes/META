<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" CodeFile="RegistroPersonas.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">  /*--METODO PARA DETECTAR UNA TECLA PRESIONADA (REVISAR MASTER) */
        function ObtenerTecla(key) {
            if (key == 13) {
                return false;
            }
            return true;
        }
    </script>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="container-fluid">
                <div id="divBotonesPrincipales" class="row">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td colspan="5" class="MenuHead">
                                <asp:ImageButton ID="IBTNuevo" runat="server" ImageUrl="~/Imagenes/IMNuevo.png" />
                                <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" ValidationGroup="Guardar" />
                                <asp:ImageButton ID="IBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                                <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" class="MenuHead"></td>
                        </tr>
                    </table>
                    <div id="DivBotonesPrincipales1" visible="true" runat="server" class="row">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/IMGeneralesPress.png" />
                        <asp:ImageButton ID="BTNReferencias" runat="server" ImageUrl="~/Imagenes/IMOtro.png" />

                    </div>
                    <div id="divBotonesPrincipales2" visible="false" runat="server" class="row">

                        <asp:ImageButton ID="BTNDatosGenerales" runat="server" ImageUrl="~/Imagenes/IMGenerales.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/IMReferenciaPress.png" />
                    </div>
                </div>
                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" runat="server" id="DatosTablaDatosGenerales">

                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" id="divDatosCliente">
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">ID</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBIdPersona" runat="server" Enabled="False"></asp:TextBox>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Equivalencia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBEquivalencia" runat="server" Enabled="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBEquivalencia" runat="server" ControlToValidate="TBEquivalencia"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Equivalencia es Obligatoria"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEquivalencia" runat="server" TargetControlID="RFVTBEquivalencia"></asp:ValidatorCalloutExtender>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Tipo Persona</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDTipoPersona" runat="server" Width="97%" CssClass="form-control" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Razon Social</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBRazonSocial" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Primer Nombre</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBNombre" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="TBNombre"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Primer Nombre es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCENombre" runat="server" TargetControlID="RFVNombre"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBNombre"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERNombre" runat="server" TargetControlID="REVNombre"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Segundo Nombre</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBSegNombre" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="none" ID="REVSegNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBSegNombre"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERSegNombre" runat="server" TargetControlID="REVSegNombre"></asp:ValidatorCalloutExtender>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Apellido Paterno</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBAPaterno" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVAPaterno" runat="server" ControlToValidate="TBAPaterno"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Paterno es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEAPaterno" runat="server" TargetControlID="RFVAPaterno"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVAPaterno" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBAPaterno"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERAPaterno" runat="server" TargetControlID="REVAPaterno"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Apellido Materno</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBAMaterno" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVAMaterno" runat="server" ControlToValidate="TBAMaterno"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Materno es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEAMaterno" runat="server" TargetControlID="RFVAMaterno"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVAMaterno" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBAMaterno"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERAMaterno" runat="server" TargetControlID="REVAMaterno"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">RFC</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRFC" runat="server"></asp:TextBox>
                            <asp:TextBox Width="150px" ID="TBIdPersonaIdentificacionRFC" Visible="false" runat="server"></asp:TextBox>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">CURP</span>                           
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                             <div class=" col-xs-11 col-sm-11 col-md-11 col-lg-11" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="100%" CssClass="form-control" ID="TBCURP" runat="server"></asp:TextBox>
                                 <asp:TextBox Width="150px" ID="TBIdPersonaIdentificacionCURP" Visible="false" runat="server"></asp:TextBox>
                                 </div>
                              <div class=" col-xs-1 col-sm-1 col-md-1 col-lg-1" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">                            
                            <a href="https://consultas.curp.gob.mx/CurpSP/" target="_blank"><img src="../../../../Imagenes/zoom.png" /></a>
                                  </div>
                        </div>
                    </div>


                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" id="divDatosCliente1">
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Fecha de Nacimiento</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBFecha" CssClass="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFecha" />

                            <asp:RequiredFieldValidator ID="RFVFecha" runat="server" ControlToValidate="TBFecha"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Fecha es Obligatoria"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEFecha" runat="server" TargetControlID="RFVFecha"></asp:ValidatorCalloutExtender>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Genero</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDGenero" runat="server" CssClass="form-control" AutoPostBack="True" Width="97%">
                            </asp:DropDownList>
                            <asp:TextBox Width="97%" ID="TBIdPersonaDomicilio" Visible="false" runat="server"></asp:TextBox>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Estado Civil</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDEstadoCivil" runat="server" AutoPostBack="True" Width="97%" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Celular</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBCelular" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RFVTBCelular" runat="server" ControlToValidate="TBCelular"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Celular es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBCelular" runat="server" TargetControlID="RFVTBCelular"></asp:ValidatorCalloutExtender>

                            <asp:FilteredTextBoxExtender ID="FTBECelular" runat="server" FilterType="Numbers" TargetControlID="TBCelular" />
                            <asp:TextBox Width="150px" ID="TBIdPersonaMedioCelular" Visible="false" runat="server"></asp:TextBox>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">E-Mail</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBEmail" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RFVTBEmail" runat="server" ControlToValidate="TBEmail"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Email es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEmail" runat="server" TargetControlID="RFVTBEmail"></asp:ValidatorCalloutExtender>

                            <asp:TextBox Width="150px" ID="TBIdPersonaMedioEMAIL" Visible="false" runat="server"></asp:TextBox>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Limite de Credito</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBLimiteCredito" runat="server"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FTBELimiteCredito" runat="server" FilterType="Numbers" TargetControlID="TBLimiteCredito" />
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Estado</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDEstado" runat="server" Width="97%" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Observaciones</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBObservaciones" runat="server" TextMode="MultiLine" />
                        </div>
                    </div>


                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" id="divDomicilio">
                        <div class=" col-xs-12 visible-xs" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style=" padding-right: 0px; text-align: left;"><strong>Domicilio</strong></span>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Tipo Domicilio</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDTipoDomicilio" runat="server" Width="97%" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Calle</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox ID="TBCalle" Width="97%" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBCalle" runat="server" ControlToValidate="TBCalle"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Calle es Obligatoria"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBCalle" runat="server" TargetControlID="RFVTBCalle"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Número Exterior</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBDomNumExterior" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBDomNumExterior" runat="server" ControlToValidate="TBDomNumExterior"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Numero es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBDomNumExterior" runat="server" TargetControlID="RFVTBDomNumExterior"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBENumExterior" runat="server" FilterType="Numbers" TargetControlID="TBDomNumExterior" />
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Número Interior</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" ID="TBDomNumInterior" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Telefono</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBDomTelefono" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RFVTBDomTelefono" runat="server" ControlToValidate="TBDomTelefono"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBDomTelefono" runat="server" TargetControlID="RFVTBDomTelefono"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBEDomTelefono" runat="server" FilterType="Numbers" TargetControlID="TBDomTelefono" />
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Antigüedad</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <div class=" col-xs-8 col-sm-8 col-md-8 col-lg-8" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                                <asp:TextBox Width="98%" CssClass="form-control" ID="TBDomAntiguedad" runat="server"></asp:TextBox>
                            </div>
                            <div class=" col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                                <asp:RequiredFieldValidator ID="RFVTBDomAntiguedad" runat="server" ControlToValidate="TBDomAntiguedad"
                                    ErrorMessage="&lt;strong>Información requerida</strong> La Antigüedad es Obligatoria"
                                    Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="VCETBDomAntiguedad" runat="server" TargetControlID="RFVTBDomAntiguedad"></asp:ValidatorCalloutExtender>
                                <asp:FilteredTextBoxExtender ID="FTBEAntiguedad" runat="server" FilterType="Numbers" TargetControlID="TBDomAntiguedad" />
                                <asp:DropDownList Width="96%" CssClass="form-control" ID="DDDomTipoAntiuedad" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Entidad Federativa</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDEntidadFederativa" runat="server" Enabled="false" Width="97%" CssClass="form-control" OnSelectedIndexChanged="DDEntidadFederativa_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Municipio</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList Width="97%" CssClass="form-control" ID="DDDomMunicipio" runat="server" OnSelectedIndexChanged="DDDomMunicipio_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Colonia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDDomColonia" runat="server" Width="97%" CssClass="form-control" OnSelectedIndexChanged="DDDomColonia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Codigo Postal</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBDomCodigoPostal" runat="server" AutoPostBack="true" OnTextChanged="TBDomicilioCodigoPostal_TextChanged" />
                            <asp:RequiredFieldValidator ID="RFVTBDomCodigoPostal" runat="server" ControlToValidate="TBDomCodigoPostal"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Codigo Postal es Obligatorio"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBDomCodigoPostal" runat="server" TargetControlID="RFVTBDomCodigoPostal"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBEDomCodigoPostal" runat="server" FilterType="Numbers" TargetControlID="TBDomCodigoPostal" />
                        </div>
                    </div>

                </div>
                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" runat="server" id="DatosTablaConyugue">
                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" id="d">
                        <div class=" col-xs-12 visible-xs" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style=" padding-right: 0px; text-align: left;"><strong>Conyuue</strong></span>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">ID</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBIdPerConyugue" runat="server" Enabled="False">
                            </asp:TextBox>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Equivalencia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBEquivalenciaConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBEquivalenciaConyugue" runat="server" ControlToValidate="TBEquivalenciaConyugue"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Equivalencia es Obligatoria"
                                Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEquivalenciaConyugue" runat="server" TargetControlID="RFVTBEquivalenciaConyugue"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Primer Nombre</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBPriNomConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFNomConyugue" runat="server" ControlToValidate="TBPriNomConyugue" ErrorMessage="&lt;strong>Información requerida</strong> El Primer Nombre es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERPriNomConyugue1" runat="server" TargetControlID="RFNomConyugue"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVPriNomConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBPriNomConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERPriNomConyugue" runat="server" TargetControlID="REVPriNomConyugue"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Segundo Nombre</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBSegNomConyugue" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="none" ID="REVSegNomConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBSegNomConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERSegNomConyugue" runat="server" TargetControlID="REVSegNomConyugue"></asp:ValidatorCalloutExtender>
                        </div>

                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Apellido Paterno</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBApePatConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFApePatConyugue" runat="server" ControlToValidate="TBApePatConyugue" ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Paterno es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApePatConyugue1" runat="server" TargetControlID="RFApePatConyugue"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVApePatConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApePatConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApePatConyugue" runat="server" TargetControlID="REVApePatConyugue"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Apellido Materno</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBApeMatConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFApeMatConyugue" runat="server" ControlToValidate="TBApeMatConyugue" ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Materno es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApeMatConyugue1" runat="server" TargetControlID="RFApeMatConyugue"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVApeMatConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApeMatConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApeMatConyugue" runat="server" TargetControlID="REVApeMatConyugue"></asp:ValidatorCalloutExtender>
                        </div>



                    </div>
                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Fecha de Nacimiento</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBFechaConyugue" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaConyugue" />
                            <asp:RequiredFieldValidator ID="RFFechaConyugue" runat="server" ControlToValidate="TBFechaConyugue" ErrorMessage="&lt;strong>Información requerida</strong> La Fecha de Nacimiento es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEFechaConyugue" runat="server" TargetControlID="RFFechaConyugue"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Genero</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDGeneroConyugue" runat="server" Width="97%" CssClass="form-control" />
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Estado Civil</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDEstCivConyugue" runat="server" Width="97%" CssClass="form-control" Enabled="False"></asp:DropDownList>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Estado</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDEstadoConyugue" runat="server" Width="97%" CssClass="form-control"></asp:DropDownList>
                        </div>



                    </div>
                </div>
                <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;" runat="server" id="DatosTablaReferencias">
                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                       <div class=" col-xs-12 visible-xs" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style=" padding-right: 0px; text-align: left;"><strong>Referencia 1</strong></span>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Tipo Referencia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDTipoReferencia" runat="server" Width="97%" CssClass="form-control"></asp:DropDownList>
                            <asp:TextBox Width="150px" ID="TBIdPersonaReferencia1" Visible="false" runat="server"></asp:TextBox>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Nombre</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefNombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefNombre" runat="server" ControlToValidate="TBRefNombre"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Nombre es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefNombre" runat="server" TargetControlID="RFVRefNombre"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVRefNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBRefNombre"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERRefNombre" runat="server" TargetControlID="REVRefNombre"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Ocupacion</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefOcupacion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefOcupacion" runat="server" ControlToValidate="TBRefOcupacion"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Ocupacion es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefOcupacion" runat="server" TargetControlID="RFVTBRefOcupacion"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Compañia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefEmpresa" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefEmpresa" runat="server" ControlToValidate="TBRefEmpresa"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Compañia es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefEmpresa" runat="server" TargetControlID="RFVTBRefEmpresa"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Antigüedad</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">

                              <div class=" col-xs-8 col-sm-8 col-md-8 col-lg-8" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                                <asp:TextBox Width="97%" CssClass="form-control" ID="TBRef1Antiguedad" runat="server"></asp:TextBox>
                            </div>
                            <div class=" col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                              <asp:RequiredFieldValidator ID="RFVTBRef1Antiguedad" runat="server" ControlToValidate="TBRef1Antiguedad"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Antiüedad es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRef1Antiguedad" runat="server" TargetControlID="RFVTBRef1Antiguedad"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBETBRef1Antiguedad" runat="server" FilterType="Numbers" TargetControlID="TBRef1Antiguedad" />
                            <asp:DropDownList ID="DDRef1TipoAntiguedad" runat="server" Width="96%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                         <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Domicilio</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                           <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefDomicilio" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefDomicilio" runat="server" ControlToValidate="TBRefDomicilio"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefDomicilio" runat="server" TargetControlID="RFVRefDomicilio"></asp:ValidatorCalloutExtender>
                        </div>
                           <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Telefono/Cel.</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                           <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefTelCel" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefTelCel" runat="server" ControlToValidate="TBRefTelCel"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefTelCel" runat="server" TargetControlID="RFVRefTelCel"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBERefTelCel" runat="server" FilterType="Numbers" TargetControlID="TBRefTelCel" />
                        </div>

                    </div>

                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                       <div class=" col-xs-12 visible-xs" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style=" padding-right: 0px; text-align: left;"><strong>Referencia2</strong></span>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Tipo Referencia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDTipoReferencia2" runat="server" Width="97%" CssClass="form-control"></asp:DropDownList>
                            <asp:TextBox Width="150px" ID="TBIdPersonaReferencia2" Visible="false" runat="server"></asp:TextBox>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Nombre</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefNombre2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefNombre2" runat="server" ControlToValidate="TBRefNombre2"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Nombre es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefNombre2" runat="server" TargetControlID="RFVTBRefNombre2"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Ocupacion</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefOcupacion2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefOcupacion2" runat="server" ControlToValidate="TBRefOcupacion2"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Ocupacion es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefOcupacion2" runat="server" TargetControlID="RFVTBRefOcupacion2"></asp:ValidatorCalloutExtender>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Compañia</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefEmpresa2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefEmpresa2" runat="server" ControlToValidate="TBRefEmpresa2"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Compañia es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERFVTBRefEmpresa2" runat="server" TargetControlID="RFVTBRefEmpresa2"></asp:ValidatorCalloutExtender>
                        </div>
                         <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Antigüedad</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                             <div class=" col-xs-8 col-sm-8 col-md-8 col-lg-8" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                                 <asp:TextBox Width="97%" CssClass="form-control" ID="TBRef2Antiguedad" runat="server"></asp:TextBox>
                            </div>
                            <div class=" col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                              <asp:RequiredFieldValidator ID="RFVTBRef2Antiguedad" runat="server" ControlToValidate="TBRef2Antiguedad"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Antiüedad es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRef2Antiguedad" runat="server" TargetControlID="RFVTBRef2Antiguedad"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBETBRef2Antiguedad" runat="server" FilterType="Numbers" TargetControlID="TBRef2Antiguedad" />
                            <asp:DropDownList ID="DDRef2TipoAntiguedad" runat="server" Width="96%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                          <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Domicilio</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBRefDomicilio2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefDomicilio2" runat="server" ControlToValidate="TBRefDomicilio2"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefDomicilio2" runat="server" TargetControlID="RFVRefDomicilio2"></asp:ValidatorCalloutExtender>
                        </div>
                          <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Telefono/Cel.</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                             <asp:TextBox Width="97%" CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBRefTelCel2"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVTBRefTelCel2"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="TBRefTelCel2" />
                        </div>
                    </div>

                    <div class=" col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                       <div class=" col-xs-12 visible-xs" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style=" padding-right: 0px; text-align: left;"><strong>Empleo</strong></span>
                        </div>
                        <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Tipo Empleo</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:DropDownList ID="DDTipoEmpleos" runat="server" Width="97%" CssClass="form-control"></asp:DropDownList>
                            <asp:TextBox Width="150px" ID="TBIdPersonaEmpleo" Visible="false" runat="server"></asp:TextBox>
                        </div>
                         <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Ocupacion</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                             <asp:TextBox Width="97%" CssClass="form-control" ID="TBEmpOcupacion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmpOcupacion" runat="server" ControlToValidate="TBEmpOcupacion"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Empleo es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEmpOcupacion" runat="server" TargetControlID="RFVEmpOcupacion"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVEmpOcupacion" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBEmpOcupacion">
                            </asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEEREmpOcupacion" runat="server" TargetControlID="REVEmpOcupacion"></asp:ValidatorCalloutExtender>
                        </div>
                         <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Empresa</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                             <asp:TextBox Width="97%" CssClass="form-control" ID="TBEmpEmpresa" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmpEmpresa" runat="server" ControlToValidate="TBEmpEmpresa"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Empresa es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEmpEmpresa" runat="server" TargetControlID="RFVEmpEmpresa"></asp:ValidatorCalloutExtender>
                        </div>
                          <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Antigüedad</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <div class=" col-xs-8 col-sm-8 col-md-8 col-lg-8" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                                 <asp:TextBox Width="97%" CssClass="form-control" ID="TBEmpAntiguedad" runat="server"></asp:TextBox>
                            </div>
                            <div class=" col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                               <asp:RequiredFieldValidator ID="RFVTBEmpAntiguedad" runat="server" ControlToValidate="TBEmpAntiguedad"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Antiüedad es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEmpAntiguedad" runat="server" TargetControlID="RFVTBEmpAntiguedad"></asp:ValidatorCalloutExtender>

                            <asp:FilteredTextBoxExtender ID="FTBEEmpAntiguedad" runat="server" FilterType="Numbers" TargetControlID="TBEmpAntiguedad" />
                            <asp:DropDownList ID="DDEmpTipoAntiguedad" runat="server" Width="96%" CssClass="form-control"></asp:DropDownList>
                            </div>
                            
                        </div>
                         <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Domicilio</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <asp:TextBox Width="97%" CssClass="form-control" ID="TBEmpDomicilio" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBEmpDomicilio" runat="server" ControlToValidate="TBEmpDomicilio"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEmpDomicilio" runat="server" TargetControlID="RFVTBEmpDomicilio"></asp:ValidatorCalloutExtender>
                        </div>
                         <div class=" col-xs-12 col-sm-3 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                            <span class="input-group-addon" style="padding-right: 0px; text-align: left;">Telefono/Cel.</span>
                        </div>
                        <div class=" col-xs-12 col-sm-9 col-md-6 col-lg-6" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
                           <asp:TextBox Width="97%" CssClass="form-control" ID="TBEmpTelefono" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmpTelefono" runat="server" ControlToValidate="TBEmpTelefono"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEmpTelefono" runat="server" TargetControlID="RFVEmpTelefono"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBEEmpTelefono" runat="server" FilterType="Numbers" TargetControlID="TBEmpTelefono" />
                        </div>


                    </div>



                </div>
                <table visible="false" style="width: 100%; border-collapse: collapse;" runat="server" id="DatosTablaConyugue1">
                    <tr>
                        <td colspan="8">&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="8" style="text-align: center"><strong>Conyugue</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td class="">ID</td>
                        <td class="">
                            <%--  <asp:TextBox Width="150px" ID="TBIdPerConyugue" runat="server" Enabled="False">
                            </asp:TextBox>--%></td>
                        <td class="">Fecha de Nacimiento</td>
                        <td class="">
                            <%-- <asp:TextBox Width="150px" ID="TBFechaConyugue" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaConyugue" />
                            <asp:RequiredFieldValidator ID="RFFechaConyugue" runat="server" ControlToValidate="TBFechaConyugue" ErrorMessage="&lt;strong>Información requerida</strong> La Fecha de Nacimiento es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEFechaConyugue" runat="server" TargetControlID="RFFechaConyugue"></asp:ValidatorCalloutExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>Equivalencia</td>
                        <td>
                            <%--  <asp:TextBox Width="150px" ID="TBEquivalenciaConyugue" runat="server"></asp:TextBox>--%>
                        </td>
                        <td>Genero</td>
                        <td>
                            <%-- <asp:DropDownList ID="DDGeneroConyugue" runat="server" Height="22px" Width="155px" />--%></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td class="">Primer Nombre</td>
                        <td class="">
                            <%-- <asp:TextBox Width="150px" ID="TBPriNomConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFNomConyugue" runat="server" ControlToValidate="TBPriNomConyugue" ErrorMessage="&lt;strong>Información requerida</strong> El Primer Nombre es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERPriNomConyugue1" runat="server" TargetControlID="RFNomConyugue"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVPriNomConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBPriNomConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERPriNomConyugue" runat="server" TargetControlID="REVPriNomConyugue"></asp:ValidatorCalloutExtender>--%>
                        </td>

                        <td class="">Estado Civil</td>
                        <td class="">
                            <%--  <asp:DropDownList ID="DDEstCivConyugue" runat="server" Height="22px" Width="155px" Enabled="False"></asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>Segundo Nombre</td>
                        <td>
                            <%--    <asp:TextBox Width="150px" ID="TBSegNomConyugue" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="none" ID="REVSegNomConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBSegNomConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERSegNomConyugue" runat="server" TargetControlID="REVSegNomConyugue"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td>Estado</td>
                        <td>
                            <%--<asp:DropDownList ID="DDEstadoConyugue" runat="server" Height="22px" Width="155px"></asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td class="">Apellido Paterno</td>
                        <td class="">
                            <%--<asp:TextBox Width="150px" ID="TBApePatConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFApePatConyugue" runat="server" ControlToValidate="TBApePatConyugue" ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Paterno es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApePatConyugue1" runat="server" TargetControlID="RFApePatConyugue"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVApePatConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApePatConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApePatConyugue" runat="server" TargetControlID="REVApePatConyugue"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td class=""></td>
                        <td class=""></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>Apellido Materno</td>
                        <td>
                            <%--<asp:TextBox Width="150px" ID="TBApeMatConyugue" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFApeMatConyugue" runat="server" ControlToValidate="TBApeMatConyugue" ErrorMessage="&lt;strong>Información requerida</strong> El Apellido Materno es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApeMatConyugue1" runat="server" TargetControlID="RFApeMatConyugue"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVApeMatConyugue" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBApeMatConyugue"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERApeMatConyugue" runat="server" TargetControlID="REVApeMatConyugue"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td colspan="4">
                            <asp:Button ID="BTNConsultarConyugue" Visible="false" runat="server" Text="Consultar" />&nbsp;
                                                                    <asp:Button ID="BTNAceptarConyugue" runat="server" Visible="false" Text="Aceptar" ValidationGroup="GuardarConyugue" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarConyugue" runat="server" Visible="false" Text="Actualizar" ValidationGroup="GuardarConyugue" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarConyugue" runat="server" Visible="false" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarConyugue" runat="server" Visible="false" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaConyugue" Visible="false" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%; border-collapse: collapse;" runat="server" visible="false" id="DatosTablaReferencias1">
                    <tr>
                        <td class="CeroColumna"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna2"></td>
                    </tr>
                    <tr>
                        <td colspan="8">&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <%--  <asp:ImageButton ID="BTNDatosGenerales" runat="server" ImageUrl="~/Imagenes/IMDatosGenerales.png" />--%></td>
                        <td>Referencia 1</td>
                        <td></td>
                        <td>Referencia 2</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <%--  <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/IMReferenciaPress.png" />--%></td>
                        <td>Tipo Referencia</td>
                        <td>
                            <%--  <asp:DropDownList ID="DDTipoReferencia" runat="server" Height="22px" Width="155px"></asp:DropDownList>
                            <asp:TextBox Width="150px" ID="TBIdPersonaReferencia1" Visible="false" runat="server"></asp:TextBox>--%>
                        </td>
                        <td>Tipo Referencia 2</td>
                        <td>
                            <%-- <asp:DropDownList ID="DDTipoReferencia2" runat="server" Height="22px" Width="155px"></asp:DropDownList>
                            <asp:TextBox Width="150px" ID="TBIdPersonaReferencia2" Visible="false" runat="server"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Nombre</td>
                        <td>
                            <%--   <asp:TextBox Width="150px" ID="TBRefNombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefNombre" runat="server" ControlToValidate="TBRefNombre"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Nombre es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefNombre" runat="server" TargetControlID="RFVRefNombre"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVRefNombre" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBRefNombre"></asp:RegularExpressionValidator>
                            <asp:ValidatorCalloutExtender ID="VCEERRefNombre" runat="server" TargetControlID="REVRefNombre"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td>Nombre 2</td>
                        <td>
                            <%--  <asp:TextBox Width="150px" ID="TBRefNombre2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefNombre2" runat="server" ControlToValidate="TBRefNombre2"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Nombre es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefNombre2" runat="server" TargetControlID="RFVTBRefNombre2"></asp:ValidatorCalloutExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Ocupacion</td>
                        <td>
                            <%--  <asp:TextBox Width="150px" ID="TBRefOcupacion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefOcupacion" runat="server" ControlToValidate="TBRefOcupacion"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Ocupacion es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefOcupacion" runat="server" TargetControlID="RFVTBRefOcupacion"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td>Ocupacion 2</td>
                        <td>
                            <%--<asp:TextBox Width="150px" ID="TBRefOcupacion2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefOcupacion2" runat="server" ControlToValidate="TBRefOcupacion2"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Ocupacion es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefOcupacion2" runat="server" TargetControlID="RFVTBRefOcupacion2"></asp:ValidatorCalloutExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Compañia</td>
                        <td>
                            <%--  <asp:TextBox Width="150px" ID="TBRefEmpresa" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RFVTBRefEmpresa" runat="server" ControlToValidate="TBRefEmpresa"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Compañia es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefEmpresa" runat="server" TargetControlID="RFVTBRefEmpresa"></asp:ValidatorCalloutExtender>--%>

                        </td>
                        <td>Compañia 2</td>
                        <td>
                            <%--  <asp:TextBox Width="150px" ID="TBRefEmpresa2" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RFVTBRefEmpresa2" runat="server" ControlToValidate="TBRefEmpresa2"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Compañia es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERFVTBRefEmpresa2" runat="server" TargetControlID="RFVTBRefEmpresa2"></asp:ValidatorCalloutExtender>--%>

                        </td>
                    </tr>
                    <tr>
                        <td class="CeroColumna"></td>
                        <td class="Columna1">&nbsp;</td>
                        <td class="Columna1">Antigüedad</td>
                        <td>
                            <%--<asp:TextBox Width="90px" ID="TBRef1Antiguedad" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRef1Antiguedad" runat="server" ControlToValidate="TBRef1Antiguedad"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Antiüedad es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRef1Antiguedad" runat="server" TargetControlID="RFVTBRef1Antiguedad"></asp:ValidatorCalloutExtender>

                            <asp:FilteredTextBoxExtender ID="FTBETBRef1Antiguedad" runat="server" FilterType="Numbers" TargetControlID="TBRef1Antiguedad" />
                            <asp:DropDownList ID="DDRef1TipoAntiguedad" runat="server" Height="22px" Width="60px"></asp:DropDownList>--%>
                        </td>
                        <td class="Columna1">Antigüedad</td>
                        <td>
                           <%-- <asp:TextBox Width="90px" ID="TBRef2Antiguedad" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRef2Antiguedad" runat="server" ControlToValidate="TBRef2Antiguedad"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Antiüedad es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRef2Antiguedad" runat="server" TargetControlID="RFVTBRef2Antiguedad"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBETBRef2Antiguedad" runat="server" FilterType="Numbers" TargetControlID="TBRef2Antiguedad" />
                            <asp:DropDownList ID="DDRef2TipoAntiguedad" runat="server" Height="22px" Width="60px"></asp:DropDownList>--%>
                        </td>
                        <td class="Columna1"></td>
                        <td class="Columna2"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Domicilio</td>
                        <td>
                           <%-- <asp:TextBox Width="150px" ID="TBRefDomicilio" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefDomicilio" runat="server" ControlToValidate="TBRefDomicilio"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefDomicilio" runat="server" TargetControlID="RFVRefDomicilio"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td>Domicilio 2</td>
                        <td>
                           <%-- <asp:TextBox Width="150px" ID="TBRefDomicilio2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefDomicilio2" runat="server" ControlToValidate="TBRefDomicilio2"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefDomicilio2" runat="server" TargetControlID="RFVRefDomicilio2"></asp:ValidatorCalloutExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Telefono/Cel.</td>
                        <td>
                           <%-- <asp:TextBox Width="150px" ID="TBRefTelCel" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVRefTelCel" runat="server" ControlToValidate="TBRefTelCel"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCERefTelCel" runat="server" TargetControlID="RFVRefTelCel"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBERefTelCel" runat="server" FilterType="Numbers" TargetControlID="TBRefTelCel" />--%>
                        </td>
                        <td>Telefono/Cel. 2</td>
                        <td>
                            <asp:TextBox Width="150px" ID="TBRefTelCel2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBRefTelCel2" runat="server" ControlToValidate="TBRefTelCel2"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBRefTelCel2" runat="server" TargetControlID="RFVTBRefTelCel2"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBETBRefTelCel2" runat="server" FilterType="Numbers" TargetControlID="TBRefTelCel2" />

                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="CeroColumna"></td>
                        <td class="Columna1">&nbsp;</td>
                        <td class="Columna1">Empleo</td>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Tipo Empleo</td>
                        <td>
                            <%--<asp:DropDownList ID="DDTipoEmpleos" runat="server" Height="22px" Width="155px"></asp:DropDownList>
                            <asp:TextBox Width="150px" ID="TBIdPersonaEmpleo" Visible="false" runat="server"></asp:TextBox>--%>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Ocupacion</td>
                        <td>
                           <%-- <asp:TextBox Width="150px" ID="TBEmpOcupacion" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmpOcupacion" runat="server" ControlToValidate="TBEmpOcupacion"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Empleo es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEmpOcupacion" runat="server" TargetControlID="RFVEmpOcupacion"></asp:ValidatorCalloutExtender>
                            <asp:RegularExpressionValidator Display="none" ID="REVEmpOcupacion" runat="server" ErrorMessage="Este Campo Solo Admite Letras" ValidationExpression="^[A-Z a-z]*$" ValidationGroup="Guardar" ControlToValidate="TBEmpOcupacion">
                            </asp:RegularExpressionValidator><asp:ValidatorCalloutExtender ID="VCEEREmpOcupacion" runat="server" TargetControlID="REVEmpOcupacion"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Empresa</td>
                        <td>
                           <%-- <asp:TextBox Width="150px" ID="TBEmpEmpresa" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmpEmpresa" runat="server" ControlToValidate="TBEmpEmpresa"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Empresa es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEmpEmpresa" runat="server" TargetControlID="RFVEmpEmpresa"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="CeroColumna"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1">Antigüedad</td>
                        <td>
                          <%--  <asp:TextBox Width="90px" ID="TBEmpAntiguedad" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBEmpAntiguedad" runat="server" ControlToValidate="TBEmpAntiguedad"
                                ErrorMessage="&lt;strong>Información requerida</strong> La Antiüedad es Obligatoria" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEmpAntiguedad" runat="server" TargetControlID="RFVTBEmpAntiguedad"></asp:ValidatorCalloutExtender>

                            <asp:FilteredTextBoxExtender ID="FTBEEmpAntiguedad" runat="server" FilterType="Numbers" TargetControlID="TBEmpAntiguedad" />
                            <asp:DropDownList ID="DDEmpTipoAntiguedad" runat="server" Height="22px" Width="60px"></asp:DropDownList>--%>
                        </td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna1"></td>
                        <td class="Columna2"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Domicilio</td>
                        <td>
                            <%--<asp:TextBox Width="150px" ID="TBEmpDomicilio" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVTBEmpDomicilio" runat="server" ControlToValidate="TBEmpDomicilio"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Domicilio es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCETBEmpDomicilio" runat="server" TargetControlID="RFVTBEmpDomicilio"></asp:ValidatorCalloutExtender>--%>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Telefono/Cel</td>
                        <td>
                            <%--<asp:TextBox Width="150px" ID="TBEmpTelefono" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVEmpTelefono" runat="server" ControlToValidate="TBEmpTelefono"
                                ErrorMessage="&lt;strong>Información requerida</strong> El Telefono es Obligatorio" Display="None" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="VCEEmpTelefono" runat="server" TargetControlID="RFVEmpTelefono"></asp:ValidatorCalloutExtender>
                            <asp:FilteredTextBoxExtender ID="FTBEEmpTelefono" runat="server" FilterType="Numbers" TargetControlID="TBEmpTelefono" />--%>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
                <table style="width: 100%; border-collapse: collapse;" runat="server" visible="false" id="Acordeon">
                    <tr>
                        <td colspan="2"></td>
                        <td colspan="4">
                            <WUCDA:wucDatosAuditoria ID="wucDatosAuditoria1" style="width: 100%; border-collapse: collapse;" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="4">
                            <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" Height="3752px" Width="100%">
                                <Panes>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane0" runat="server" ContentCssClass="" HeaderCssClass="" Visible="false">
                                        <Header>Conyugue</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="PAConyugue" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td colspan="4"></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp; </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td colspan="2">
                                                        <asp:GridView ID="GVConyugue" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Width="100%">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Button ID="BTNConyugue" runat="server" Text="+ Conyugue" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Identificacion</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="PAIdentificacion" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td class="PrimeraColumna">Tipo Identificacion</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:DropDownList ID="DDTipoIdentificacion" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                    <td class="PrimeraColumna" />
                                                                    <td class="SegundaColumna" />
                                                                </tr>
                                                                <tr>
                                                                    <td>Numero Identificacion</td>
                                                                    <td>
                                                                        <asp:TextBox Width="150px" ID="TBNumIdentificacion" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVNumIdentificacion" runat="server" ControlToValidate="TBNumIdentificacion" ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio" Display="None" ValidationGroup="GuardarIdentificacion"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="VCENumIdentificacion" runat="server" TargetControlID="RFVNumIdentificacion"></asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td />
                                                                    <td />
                                                                </tr>
                                                                <tr>
                                                                    <td class="SegundaColumna" colspan="4">
                                                                        <asp:Button ID="BTNAceptarIdentificacion" runat="server" Text="Aceptar" ValidationGroup="GuardarIdentificacion" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarIdentificacion" runat="server" Text="Actualizar" ValidationGroup="GuardarIdentificacion" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarIdentificacion" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarIdentificacion" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdIdentificacion" Visible="False" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp; </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td colspan="2">
                                                        <asp:GridView ID="GVIdentificacion" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr" Width="100%">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Button ID="BTNuevaIdentificacion" runat="server" Text="+ Nueva Identificacion" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Contacto</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="PanelMedio" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td class="PrimeraColumna">Tipo Medio</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:DropDownList ID="DDTipoMedio" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Medio</td>
                                                                    <td>
                                                                        <asp:TextBox Width="150px" ID="TBValorMedio" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVValorMedio" runat="server" ControlToValidate="TBValorMedio" ErrorMessage="&lt;strong>Información requerida</strong> El Tipo Medio es Obligatorio" Display="None" ValidationGroup="GuardarValorMedio">
                                                                        </asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEValorMedio" runat="server" TargetControlID="RFVValorMedio"></asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SegundaColumna" colspan="4">
                                                                        <asp:Button ID="BTNAceptarMedio" runat="server" Text="Aceptar" ValidationGroup="GuardarValorMedio" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarMedio" runat="server" Text="Actualizar" ValidationGroup="GuardarValorMedio" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarMedio" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarMedio" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdMedio" Visible="False" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp; </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td colspan="2">
                                                        <asp:GridView Width="100%" ID="GVMedio" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Button ID="BTNMedio" runat="server" Text="+ Nueva Medio" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Domicilio</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="PanelDomicilio" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td class="PrimeraColumna">Tipo Domicilio</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:DropDownList ID="DDTipoDomicilio1" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Antiguedad</td>
                                                                    <td>
                                                                        <asp:TextBox Width="150px" ID="TBDomAntiguedad1" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVDomAntiguedad" runat="server" ControlToValidate="TBDomAntiguedad1"
                                                                            ErrorMessage="&lt;strong>Información requerida</strong> La Antiguedad es Obligatoria"
                                                                            Display="None" ValidationGroup="GuardarDomicilio"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="VCEDomAntiguedad1" runat="server" TargetControlID="RFVDomAntiguedad"></asp:ValidatorCalloutExtender>

                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="RBAnos" Text="Años" GroupName="Antiguedad" Value="1" runat="server" OnCheckedChanged="RBAnos_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                        <asp:RadioButton GroupName="Antiguedad" Value="2" ID="RBMeses" Text="Meses" runat="server" OnCheckedChanged="RBMeses_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                        <asp:RadioButton Value="3" GroupName="Antiguedad" ID="RBDias" Text="Dias" runat="server" OnCheckedChanged="RBDias_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna">Propietario</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:TextBox Width="150px" ID="TBDomPropietario" runat="server"></asp:TextBox></td>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr runat="server" id="ControlPais">
                                                                    <td class="PrimeraColumna">País</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:DropDownList ID="DDPais" runat="server" Height="22px" Width="155px" OnSelectedIndexChanged="DDPais_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr runat="server" id="ControlEntidadFederativa">
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:Button ID="BTNAceptarDomicilio" runat="server" Text="Aceptar" ValidationGroup="GuardarDomicilio" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarDomicilio" runat="server" Text="Actualizar" ValidationGroup="GuardarDomicilio" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarDomicilio" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelar" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdDomicilio" Visible="False" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td>
                                                        <asp:GridView Width="100%" ID="GVDomicilio" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" colspan="2">
                                                        <asp:Button ID="BTNDomicilio" runat="server" Text="+ Nuevo Domicilio" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Empleos</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="PanelEmpleo" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Antiguedad</td>
                                                                    <td>
                                                                        <asp:TextBox Width="150px" ID="TBEmpAntiguedad1" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVEmpAntiguedad" runat="server" ControlToValidate="TBEmpAntiguedad1" ErrorMessage="&lt;strong>Información requerida</strong> La Antiguedad es Obligatoria" Display="None" ValidationGroup="GuardarOcupacion"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="VCEEmpAntiguedad" runat="server" TargetControlID="RFVEmpAntiguedad"></asp:ValidatorCalloutExtender>

                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SegundaColumna" colspan="4">
                                                                        <asp:Button ID="BTNAceptarEmpleo" runat="server" Text="Aceptar" ValidationGroup="GuardarOcupacion" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarEmpleo" runat="server" Text="Actualizar" ValidationGroup="GuardarOcupacion" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarEmpleo" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarEmpleo" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaEmpleo1" Visible="False" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td>
                                                        <asp:GridView Width="100%" ID="GVEmpleo" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" colspan="4">
                                                        <asp:Button ID="BTNEmpleo" runat="server" Text="+ Nuevo Empleo" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Referencias</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="PanelReferencia" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna">Antiguedad</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:TextBox Width="150px" ID="TBRefAntiguedad" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFVRefAntiguedad" runat="server" ControlToValidate="TBRefAntiguedad" ErrorMessage="&lt;strong>Información requerida</strong> La Antiguedad es Obligatoria" Display="None" ValidationGroup="GuardarReferencias"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="VCERefAntiguedad" runat="server" TargetControlID="RFVRefAntiguedad"></asp:ValidatorCalloutExtender>
                                                                        <asp:FilteredTextBoxExtender ID="FTBERefAntiguedad" runat="server" FilterType="Numbers" TargetControlID="TBRefAntiguedad" />
                                                                    </td>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:Button ID="BTNAceptarReferencia" runat="server" Text="Aceptar" ValidationGroup="GuardarReferencias" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarReferencia" runat="server" Text="Actualizar" ValidationGroup="GuardarReferencias" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarReferencia" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarReferencia" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaReferencia" Visible="False" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td>
                                                        <asp:GridView Width="100%" ID="GVReferencia" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" colspan="4">
                                                        <asp:Button ID="BTNReferencia" runat="server" Text="+ Nueva Referencia" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <%-- <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server" ContentCssClass="" HeaderCssClass="">
                                    <Header>Linea de Credito</Header>
                                    <Content>
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PanelLineaCredito" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                        <table style="width: 100%; border-collapse: collapse;">
                                                            <tr>
                                                                <td class="PrimeraColumna">Fecha</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBFechaLineaCredito" runat="server"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Enabled="True" runat="server" PopupPosition="BottomRight" Format="dd/MM/yyyy" TargetControlID="TBFechaLineaCredito" />
                                                                    <asp:RequiredFieldValidator ID="RFFechaLineaCredito" runat="server" ControlToValidate="TBFechaLineaCredito" ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio" Display="None" ValidationGroup="GuardarCredito"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEFechaLineaCredito" runat="server" TargetControlID="RFFechaLineaCredito"></asp:ValidatorCalloutExtender>
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Credito</td>
                                                                <td>
                                                                    <asp:TextBox Width="150px" ID="TBLineaCredito" runat="server"></asp:TextBox></td>
                                                                    <asp:RequiredFieldValidator ID="RFLineaCredito" runat="server" ControlToValidate="TBLineaCredito" ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio" Display="None" ValidationGroup="GuardarCredito"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCELineaCredito" runat="server" TargetControlID="RFLineaCredito"></asp:ValidatorCalloutExtender>  
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="PrimeraColumna">Monto</td>
                                                                <td class="PrimeraColumna">
                                                                    <asp:TextBox Width="150px" ID="TBMontoLineaCredito" runat="server"></asp:TextBox>
                                                                     <asp:RegularExpressionValidator Display="none" ID="REVMontoLineaCredito" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ControlToValidate="TBMontoLineaCredito" ValidationGroup="GuardarCredito"></asp:RegularExpressionValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEERImpuesto" runat="server" TargetControlID="REVMontoLineaCredito"></asp:ValidatorCalloutExtender> 
                                                                    <asp:RequiredFieldValidator ID="RFMontoLineaCredito" runat="server" ControlToValidate="TBMontoLineaCredito" ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio" Display="None" ValidationGroup="GuardarCredito"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCEMontoLineaCredito" runat="server" TargetControlID="RFMontoLineaCredito"></asp:ValidatorCalloutExtender>  
                                                                <td></td> 
                                                                </td>
                                                                <td class="PrimeraColumna"></td>
                                                                <td class="SegundaColumna"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="BTNAceptarLineaCredito" runat="server" Text="Aceptar" ValidationGroup="GuardarCredito" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarLineaCredito" runat="server" Text="Actualizar" ValidationGroup="GuardarCredito" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarLineaCredito" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarLineaCredito" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaLineaCredito" Visible="false" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr style="text-align: center;">
                                                <td>
                                                    <asp:GridView Width="100%" ID="GVLineaCredito" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" colspan="4">
                                                    <asp:Button ID="BTNLineaCredito" runat="server" Text="+ Nueva Linea de credito" /></td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>--%>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Limite de Credito</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="PanelLimiteCredito" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td>Limite de Credito
                                                                    <asp:TextBox Width="150px" ID="TBLimiteCredito1" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <%--<asp:RequiredFieldValidator ID="RFLineaCredito" runat="server" ControlToValidate="TBLineaCredito" ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio" Display="None" ValidationGroup="GuardarCredito"></asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="VCELineaCredito" runat="server" TargetControlID="RFLineaCredito"></asp:ValidatorCalloutExtender>--%>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:Button ID="BTNAceptarLimiteCredito" runat="server" Text="Aceptar" ValidationGroup="GuardarCredito" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarLimiteCredito" runat="server" Text="Actualizar" ValidationGroup="GuardarCredito" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarLimiteCredito" runat="server" Text="Cancelar" />
                                                                    &nbsp;                                                                    
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td>
                                                        <asp:GridView Width="100%" ID="GVLimiteCredito" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" colspan="4">
                                                        <asp:Button ID="BTNLimiteCredito" runat="server" Text="Modificar limite de credito" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                    <ajaxToolkit:AccordionPane ID="AccordionPane7" runat="server" ContentCssClass="" HeaderCssClass="">
                                        <Header>Indicadores</Header>
                                        <Content>
                                            <table style="width: 100%; border-collapse: collapse;">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="PanelIndicadores" runat="server" Width="100%" BackColor="#FDFDFD" Visible="False">
                                                            <table style="width: 100%; border-collapse: collapse;">
                                                                <tr>
                                                                    <td class="PrimeraColumna">Indicador</td>
                                                                    <td class="PrimeraColumna">
                                                                        <asp:DropDownList ID="DDTipoIndicador" runat="server" Height="22px" Width="155px"></asp:DropDownList></td>
                                                                    <td class="PrimeraColumna"></td>
                                                                    <td class="SegundaColumna"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Monto</td>
                                                                    <td>
                                                                        <asp:TextBox Width="150px" ID="TBMontoIndicador" runat="server"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator Display="none" ID="REVMontoIndicador" runat="server" ErrorMessage="Este Campo Solo Admite Numeros Enteros y Decimales Con 2 Digitos" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ControlToValidate="TBMontoIndicador" ValidationGroup="GuardarIndicador"></asp:RegularExpressionValidator>
                                                                        <asp:ValidatorCalloutExtender ID="VCEERMontoIndicador" runat="server" TargetControlID="REVMontoIndicador"></asp:ValidatorCalloutExtender>
                                                                        <asp:RequiredFieldValidator ID="RFMontoIndicador" runat="server" ControlToValidate="TBMontoIndicador" ErrorMessage="&lt;strong>Información requerida</strong> El Numero de Identificacion es Obligatorio" Display="None" ValidationGroup="GuardarIndicador"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="VCEMontoIndicador" runat="server" TargetControlID="RFMontoIndicador"></asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="SegundaColumna" colspan="4">
                                                                        <asp:Button ID="BTNAceptarIndicador" runat="server" Text="Aceptar" ValidationGroup="GuardarIndicador" />&nbsp;
                                                                    <asp:Button ID="BTNActualizarIndicador" runat="server" Text="Actualizar" ValidationGroup="GuardarIndicador" />&nbsp;
                                                                    <asp:Button ID="BTNEliminarIndicador" runat="server" Text="Eliminar" />&nbsp;
                                                                    <asp:Button ID="BTNCancelarIndicador" runat="server" Text="Cancelar" />&nbsp;
                                                                    <asp:TextBox Width="150px" ID="TBIdPersonaIndicador" Visible="False" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center;">
                                                    <td>
                                                        <asp:GridView Width="100%" ID="GVIndicador" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                            CssClass="GridComun" GridLines="None" PagerStyle-CssClass="pgr">
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" colspan="4">
                                                        <asp:Button ID="BTNIndicador" runat="server" Text="+ Nueva Indicador" /></td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajaxToolkit:AccordionPane>
                                </Panes>
                            </ajaxToolkit:Accordion>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="IBTRegresar" runat="server" ImageUrl="~/Imagenes/IMRegresar.png" />
                        <asp:ImageButton ID="IMBTConsultar" runat="server" ImageUrl="~/Imagenes/IMConsultar.png" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10%">Id</td>
                    <td>
                        <asp:TextBox ID="TBIdPersonaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Equivalencia</td>
                    <td>
                        <asp:TextBox ID="TBEquivalenciaConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Nombre Cliente</td>
                    <td>
                        <asp:TextBox ID="TBNombreClienteConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <!--Solo poner en true para que se puedab ver las fechas de inicio y verificar si otras empresas lo usan si no para quitarlos definitivamente-->
                <tr runat="server" visible="false">
                    <td>Fecha Inicio</td>
                    <td>
                        <asp:TextBox ID="TBFechaInicioConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaInicioConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <!--Solo poner en true para que se puedab ver las fechas de inicio -->
                <tr runat="server" visible="false">
                    <td>Fecha Fin</td>
                    <td>
                        <asp:TextBox ID="TBFechaFinConsultar" runat="server" Visible="true" Width="150px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Enabled="True" runat="server" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="TBFechaFinConsultar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Genero</td>
                    <td>
                        <asp:DropDownList ID="DDGeneroConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tipo Persona</td>
                    <td>
                        <asp:DropDownList ID="DDTipoPersonaConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Estado</td>
                    <td>
                        <asp:DropDownList ID="DDEstadoConsulta" runat="server" Height="22px" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="text-align: center;">
                    <td colspan="3">
                        <asp:GridView Width="100%" ID="GVPersona" Style="margin: 0 auto;" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" PagerStyle-CssClass="pgr">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            padding-right: 10px;
            height: 28px;
        }

        .auto-style2 {
            height: 28px;
        }
    </style>
</asp:Content>


