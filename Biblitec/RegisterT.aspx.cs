using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;

namespace Biblitec
{
    public partial class Bibli1 : Page
    {
        // Ligação com o banco de dados
        string connectionString = "server=localhost;uid=root;pwd=ghoull18;database=Register";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Não carregar dados aqui
                lblResult.Text = "Por favor, clique em 'Ver Registros' para exibir os dados.";
            }
        }

        // Parte dos botões
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SalvarRegistro();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AtualizarRegistro();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ExcluirRegistro();
        }

        protected void btnViewBooks_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        protected void btnSearchCPF_Click(object sender, EventArgs e)
        {
            string cpf = txtSearchCPF.Text;
            BuscarRegistroPorCPF(cpf);
        }

        // Parte chata, aqui fica onde carrega as coisas... futuros selects
        private void CarregarDados()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Nome, CPF, DataGerado, DataPagamento, Valor, Observacao FROM Registros";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao carregar dados: {ex.Message}";
            }
        }

        // Da parte do CRUD
        private void SalvarRegistro()
        {
            try
            {
                string cpf = txtCPF.Text;

                if (!IsCpfValid(cpf))
                {
                    lblResult.Text = "CPF inválido!";
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Registros (Nome, CPF, DataGerado, DataPagamento, Valor, Observacao) VALUES (@Nome, @CPF, @DataGerado, @DataPagamento, @Valor , @Observacao)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", txtName.Text);
                        command.Parameters.AddWithValue("@CPF", cpf);
                        command.Parameters.AddWithValue("@DataGerado", Convert.ToDateTime(txtGenerationDate.Text));
                        command.Parameters.AddWithValue("@DataPagamento", Convert.ToDateTime(txtPaymentDate.Text));

                        // Substituir vírgula por ponto e formatar corretamente
                        decimal valor = decimal.Parse(txtValor.Text, new CultureInfo("pt-BR"));
                        command.Parameters.AddWithValue("@Valor", valor);

                        command.Parameters.AddWithValue("@Observacao", txtObservation.Text);
                        command.ExecuteNonQuery();
                    }

                    lblResult.Text = "Registro salvo com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao salvar registro: {ex.Message}";
            }
        }

        private void AtualizarRegistro()
        {
            try
            {
                string cpf = txtCPF.Text;

                if (!IsCpfValid(cpf))
                {
                    lblResult.Text = "CPF inválido!";
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Registros SET Nome = @Nome, DataGerado = @DataGerado, DataPagamento = @DataPagamento, Valor = @Valor , Observacao = @Observacao WHERE CPF = @CPF";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", txtName.Text);
                        command.Parameters.AddWithValue("@CPF", cpf);
                        command.Parameters.AddWithValue("@DataGerado", Convert.ToDateTime(txtGenerationDate.Text));
                        command.Parameters.AddWithValue("@DataPagamento", Convert.ToDateTime(txtPaymentDate.Text));

                        // Substituir vírgula por ponto e formatar corretamente
                        decimal valor = decimal.Parse(txtValor.Text, new CultureInfo("pt-BR"));
                        command.Parameters.AddWithValue("@Valor", valor);

                        command.Parameters.AddWithValue("@Observacao", txtObservation.Text);
                        command.ExecuteNonQuery();
                    }

                    lblResult.Text = "Registro atualizado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao atualizar registro: {ex.Message}";
            }
        }

        private void ExcluirRegistro()
        {
            try
            {
                string cpf = txtCPF.Text;

                if (!IsCpfValid(cpf))
                {
                    lblResult.Text = "CPF inválido!";
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Registros WHERE CPF = @CPF";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CPF", cpf);
                        command.ExecuteNonQuery();
                    }

                    lblResult.Text = "Registro excluído com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao excluir registro: {ex.Message}";
            }
        }

        private void BuscarRegistroPorCPF(string cpf)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Nome, CPF, DataGerado, DataPagamento, Valor, Observacao FROM Registros WHERE CPF = @CPF";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CPF", cpf);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erro ao buscar registros por CPF: {ex.Message}";
            }
        }

        // Função para validar CPF
        private bool IsCpfValid(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (cpf.Equals(new string(j.ToString()[0], 11)))
                    return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
