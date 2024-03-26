using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblitec
{
    public partial class Bibli1 : Page
    {
        // Ligação com o banco de dados
        string connectionString = "server=localhost;uid=root;pwd=ghoull18;database=Biblib";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDados();
            }
        }
         //parte dos botões
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SalvarLivro();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AtualizarLivro();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ExcluirLivro();
        }


        protected void btnViewBooks_Click(object sender, EventArgs e)
        {
            ExibirLivros();
        }


        // parte chata, aqi fica onde carrega as coisas...  futuros selects
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Livros";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            //  carregar os dados em um controle, como um GridView
                            // gridViewLivros.DataSource = reader; gridViewLivros.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao carregar dados: {ex.Message}";
            }
        }

        // teoria da parte do CRUD
        private void SalvarLivro()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Livros (Titulo, Autor, AnoLancamento) VALUES (@Titulo, @Autor, @AnoLancamento)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Titulo", txtTitle.Text);
                        command.Parameters.AddWithValue("@Autor", txtAuthor.Text);
                        command.Parameters.AddWithValue("@AnoLancamento", Convert.ToInt32(txtYear.Text));
                        command.ExecuteNonQuery();
                    }

                    lblResult.Text = "Livro salvo com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao salvar livro: {ex.Message}";
            }
        }

        private void AtualizarLivro()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Livros SET Titulo = @Titulo, Autor = @Autor, AnoLancamento = @AnoLancamento WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Titulo", txtTitle.Text);
                        command.Parameters.AddWithValue("@Autor", txtAuthor.Text);
                        command.Parameters.AddWithValue("@AnoLancamento", Convert.ToInt32(txtYear.Text));
                        command.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
                        command.ExecuteNonQuery();
                    }

                    lblResult.Text = "Livro atualizado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao atualizar livro: {ex.Message}";
            }
        }

        


        private void ExcluirLivro()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Livros WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
                        command.ExecuteNonQuery();
                    }

                    lblResult.Text = "Livro excluído com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao excluir livro: {ex.Message}";
            }
        }

        private void ExibirLivros()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Livros";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            string booksInfo = "Livros Disponíveis:<br/>";
                            while (reader.Read())
                            {
                                booksInfo += $"ID: {reader["Id"]}, Título: {reader["Titulo"]}, Autor: {reader["Autor"]}, Ano de Lançamento: {reader["AnoLancamento"]}<br/><br/>";
                            }
                            lblBooks.Text = booksInfo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao exibir livros: {ex.Message}";
            }
        }






    }
}
