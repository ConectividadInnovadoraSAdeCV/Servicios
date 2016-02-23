<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PJAEstatus.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <img src="tile.png" alt="weon" width="104" style="height: 111px">
    </div>        
        <h2 style="color:MidnightBlue; font-style:italic;">      
            <asp:Label id="EstLabel" runat="server">Seguimiento de unidades proyecto: Punto Jalisco Abierto</asp:Label> 
        </h2>
        <hr width="450" align="left" color="Gainsboro" />
        <asp:Table ID="Estatus" 
            runat="server"
            Font-Size="X-Large"
            Font-Names="Arial"
            BackColor="White"
            BorderColor="DarkRed"
            ForeColor="Black"
            BorderWidth="2"
            CellPadding="5"
            CellSpacing="5"
            >
            <asp:TableHeaderRow ID="TableHeaderRow1" 
                runat="server" 
                ForeColor="Snow"
                BackColor="OliveDrab"
                Font-Bold="true"
                >
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Unidad</asp:TableHeaderCell>
                <asp:TableHeaderCell>Rampa</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E1">E1</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E2">E2</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E3">E3</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E4">E4</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E5">E5</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E6">E6</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="E7">E7</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="Internet">Internet</asp:TableHeaderCell>
                <asp:TableHeaderCell>GPS</asp:TableHeaderCell>
                <asp:TableHeaderCell>Conexiones del día</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </form>
</body>
</html>
