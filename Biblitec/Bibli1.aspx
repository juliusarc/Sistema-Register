<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bibli1.aspx.cs" Inherits="Biblitec.Bibli1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informações do Livro</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        form {
            max-width: 400px;
            margin: 20px auto;
            background: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #333;
        }

        label {
            display: block;
            margin-bottom: 8px;
            color: #555;
        }

        input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            box-sizing: border-box;
        }

        button {
            background-color: #4caf50;
            color: #fff;
            padding: 10px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        button:hover {
            background-color: #45a049;
        }

        #lblResult {
            margin-top: 10px;
            color: #333;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Informações do Livro</h2>
            <asp:Label ID="lblResult" runat="server" EnableViewState="false"></asp:Label>
            <asp:Label ID="lblTitle" runat="server" Text="Título do Livro:"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAuthor" runat="server" Text="Autor:"></asp:Label>
            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblYear" runat="server" Text="Ano de Lançamento:"></asp:Label>
            <br />
            
            <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblId" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text=" Salvar Livro" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Atualizar Livro" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Excluir Livro" OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>
