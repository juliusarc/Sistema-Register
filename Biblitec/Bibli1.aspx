<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bibli1.aspx.cs" Inherits="Biblitec.Bibli1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informações do Livro</title>
    <style>
body {
    background: linear-gradient(90deg,  #000000 0%, #5E17EB 100%);
    color: #ffffff;
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    display: flex;
    justify-content: center; 
    align-items: center; 
    min-height: 100vh; 

#right-section {
    padding: 20px;
    width: 50%; 
    background: rgba(0, 0, 0, 0.6); 
    border-radius: 10px;
    box-shadow: 0 0 20px rgba(255, 255, 255, 0.1); 
}

.container {
    margin: 0 auto; 
}

h2 {
    text-align: center;
    margin-bottom: 20px;
}

label {
    display: block;
    margin-bottom: 10px;
}

input[type="text"] {
    width: calc(100% - 24px); 
    padding: 12px;
    margin-bottom: 20px;
    border: 1px solid #cccccc;
    border-radius: 5px;
    box-sizing: border-box;
    background-color: #333333; 
    color: #ffffff; 
}

button {
    background-color: #8a2be2; 
    color: #ffffff;
    padding: 15px 20px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    display: block;
    width: 100%;
    margin-top: 20px;
    transition: background-color 0.3s ease;
}

button:hover {
    background-color: #5E17EB; 
}

#btnSubmit {
    background-color: #8a2be2; 
}

#btnUpdate {
    background-color: #5E17EB; 

#btnDelete {
    background-color: #8a2be2; 
}

#btnViewBooks {
    background-color: #5E17EB; 

#lblResult {
    margin-top: 20px;
    color: #ffffff; 
    font-weight: bold;
}

.gridview {
    margin-top: 20px;
}



</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>BibliTec</h2>
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
            <asp:Button ID="btnViewBooks" runat="server" Text="Ver Livros" OnClick="btnViewBooks_Click" />
            <br />
            <asp:Label ID="lblBooks" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </form>
</body>

</html>
