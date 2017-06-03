<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="InicioCXP.aspx.vb" Inherits="_Default" %>
<%@ Register Src="~/Wuc/WUCGraficaCXP.ascx" TagName="wucGraficaCXP" TagPrefix="WUCGC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <WUCGC:wucGraficaCXP ID="wucGraficaCXP1" runat="server" />
</asp:Content>
