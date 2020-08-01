<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WACandidates._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bienvenido a la aplicaicón de candidatos</h1>
    </div>

    <div class="row">
        <p class="lead">
            Selecciona la tecnología a consultar
        </p>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="DDLOptionsLanguage" AutoPostBack="true" runat="server"
                    OnSelectedIndexChanged="DDLOptionsLanguage_SelectedIndexChanged">
                    <asp:ListItem Value="" Selected="True">Selecciona una opción</asp:ListItem>
                    <asp:ListItem Value="1">Java</asp:ListItem>
                    <asp:ListItem Value="2">.NET</asp:ListItem>
                </asp:DropDownList>
                <asp:CheckBoxList ID="CLFramework" AutoPostBack="true" runat="server">
                </asp:CheckBoxList>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="BTNCadidates" Text="Consultar candidatos" runat="server"
            OnClick="BTNCadidates_Click" />
        <hr />
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <h1>Candidatos disponibles</h1>
                <asp:CheckBoxList ID="CLCandidates" AutoPostBack="true" runat="server">
                </asp:CheckBoxList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
