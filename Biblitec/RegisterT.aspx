<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterT.aspx.cs" Inherits="Biblitec.Bibli1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registros de Cadastros</title>
    <style>
        body {
            background: linear-gradient(90deg, #000000 0%, #5E17EB 100%);
            color: #ffffff;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .container {
            padding: 20px;
            width: 60%;
            background: rgba(0, 0, 0, 0.6);
            border-radius: 10px;
            box-shadow: 0 0 20px rgba(255, 255, 255, 0.1);
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            width: 100%;
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"], 
        .form-group asp:TextBox {
            width: calc(100% - 24px);
            padding: 12px;
            border: 1px solid #cccccc;
            border-radius: 5px;
            box-sizing: border-box;
            background-color: #333333;
            color: #ffffff;
        }

        .buttons-group {
            width: 100%;
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
        }

        .buttons-group asp:Button {
            flex: 1;
            margin: 5px;
        }

        .buttons-group asp:Button {
            background-color: #8a2be2;
            color: #ffffff;
            padding: 15px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: calc(25% - 10px);
            margin: 5px;
            transition: background-color 0.3s ease;
        }

        .buttons-group asp:Button:hover {
            background-color: #5E17EB;
        }

        .btnUpdate {
            background-color: #5E17EB;
        }

        .btnDelete {
            background-color: #d9534f;
        }

        .btnViewBooks {
            background-color: #5bc0de;
        }

        #lblResult {
            margin-top: 20px;
            color: #ffffff;
            font-weight: bold;
            text-align: center;
        }

        .gridview {
            margin-top: 20px;
            width: 100%;
        }

        .gridview table {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th, .gridview td {
            border: 1px solid #cccccc;
            padding: 10px;
            text-align: left;
        }

        .gridview th {
            background-color: #5E17EB;
        }

        .search-group {
            display: flex;
            width: 100%;
            margin-top: 20px;
            align-items: center;
        }

        .search-group asp:TextBox {
            flex: 3;
            margin-right: 10px;
        }

        .search-group asp:Button {
            flex: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>REGISTROS</h2>
            <asp:Label ID="lblResult" runat="server" EnableViewState="false"></asp:Label>

            <div class="form-group">
                <asp:Label ID="lblName" runat="server" Text="Nome:"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCPF" runat="server" Text="CPF:"></asp:Label>
                <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblGenerationDate" runat="server" Text="Data de Geração:"></asp:Label>
                <asp:TextBox ID="txtGenerationDate" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPaymentDate" runat="server" Text="Data de Pagamento:"></asp:Label>
                <asp:TextBox ID="txtPaymentDate" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblValor" runat="server" Text="Valor:"></asp:Label>
                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblObservation" runat="server" Text="Observação:"></asp:Label>
                <asp:TextBox ID="txtObservation" runat="server"></asp:TextBox>
            </div>

            <div class="buttons-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Salvar Registro" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Atualizar Registro" OnClick="btnUpdate_Click" CssClass="btnUpdate" />
                <asp:Button ID="btnDelete" runat="server" Text="Excluir Registro" OnClick="btnDelete_Click" CssClass="btnDelete" />
                <asp:Button ID="btnViewBooks" runat="server" Text="Ver Registros" OnClick="btnViewBooks_Click" CssClass="btnViewBooks" />
            </div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="CPF" HeaderText="CPF" />
                    <asp:BoundField DataField="DataGerado" HeaderText="Data de Geração" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="DataPagamento" HeaderText="Data de Pagamento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Observacao" HeaderText="Observação" />
                </Columns>
            </asp:GridView>

            <div class="search-group">
                <asp:Label ID="lblSearchCPF" runat="server" Text="Buscar por CPF:" AssociatedControlID="txtSearchCPF"></asp:Label>
                <asp:TextBox ID="txtSearchCPF" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearchCPF" runat="server" Text="Buscar" OnClick="btnSearchCPF_Click" CssClass="btnViewBooks" />
            </div>
        </div>
    </form>
</body>
</html>
