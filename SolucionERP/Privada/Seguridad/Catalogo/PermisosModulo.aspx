<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="PermisosModulo.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Wuc/WUCDatosAuditoria2.ascx" TagName="wucDatosAuditoria" TagPrefix="WUCDA" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divBotonesPrincipales" class="row">
        <table style="width: 100%;">
            <tr>
                <td colspan="3" class="MenuHead">
                    <asp:ImageButton ID="IBTNuevo" runat="server" Visible="false" ImageUrl="~/Imagenes/IMNuevo.png" />
                    <asp:ImageButton ID="IBTGuardar" runat="server" ImageUrl="~/Imagenes/IMGuardar.png" />
                    <asp:ImageButton ID="IBTConsultar" runat="server" Visible="false" ImageUrl="~/Imagenes/IMConsultar.png" />
                    <asp:ImageButton ID="IBTCancelar" runat="server" ImageUrl="~/Imagenes/IMSalir.png" />
                </td>
            </tr>
        </table>
    </div>
    <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2" style="padding: 0;">
            <div class="input-group">
                <span class="input-group-addon" style="padding-right: 0px; text-align: right;">Tipo de Usuario</span>
                <asp:DropDownList ID="DDTipoUsuario" runat="server" AutoPostBack="True" CssClass="form-control" Style="direction: ltr;" />
            </div>
        </div>
    </div>
    <div class="row" style="margin-top: 0px; padding-left: 0px; padding-right: 0px;">
        <div id="divconsultamodulo" class="panel-body col-xs-4" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
           
           <asp:GridView ID="GVModulos" runat="server" AutoGenerateColumns="False" AllowPaging="false" CaptionAlign="Top" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" Width="100%" PagerStyle-CssClass="pgr" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                             Seleccionar
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="BTNSeleccionar" runat="server" AutoPostBack="true"
                                ForeColor="Blue" Text="Seleccionar" ShowSelectButton="True" OnClick="BTNSeleccionarModulo_OnClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Acceso</HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CBGVAccesoModulo" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVAccesoModulo_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DescripcionModulo" HeaderText="Modulo" Visible="true" />
                </Columns>
                <EmptyDataTemplate>
                    <label>Sin coincidencia</label>
                </EmptyDataTemplate>
            </asp:GridView>
                      
            
        </div>
        <div id="divconsultaopcion" class="panel-body col-xs-4" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
           
            <asp:GridView ID="GVOpcion" runat="server" AutoGenerateColumns="False" AllowPaging="false" CaptionAlign="Top" AlternatingRowStyle-CssClass="alt" CssClass="GridComun" Width="100%" PagerStyle-CssClass="pgr" GridLines="None" HorizontalAlign="Center" Style="margin: 0 auto;">
                <Columns>
                    <%--<asp:TemplateField>
                        <HeaderTemplate>
                             Seleccionar
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="BTNSeleccionar" runat="server" AutoPostBack="true"
                                ForeColor="Blue" Text="Seleccionar" ShowSelectButton="True" OnClick="BTNSeleccionarModulo_OnClick" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField>
                        <HeaderTemplate>Acceso</HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CBGVAccesoOpcion" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="CBGVAccesoOpcion_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Opcion" Visible="true" />
                </Columns>
                <EmptyDataTemplate>
                    <label>Sin coincidencia</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div id="divconsultaaccion" class="panel-body col-xs-4" style="overflow: auto; padding: 5px; font-size: medium; text-align: center;">
            <asp:GridView ID="GVAccion" Style="margin: 0 auto;" runat="server" AutoGenerateColumns="false"
                AlternatingRowStyle-CssClass="alt" CssClass="GridComun table table-responsive" Width="100%"
                BorderColor="#385c81" PagerStyle-CssClass="pgr" GridLines="None">
                <EmptyDataTemplate>
                    <label>Sin coincidencia</label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

    
      <style type="text/css">
        .color{
            background-color:#B9D6FC;
        }
    </style>
    
</asp:Content>
