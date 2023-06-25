using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CsvHelper;

namespace LocadoraJogos
{
    internal class Utilitarios
    {
        private static string Url { get; set; } = "http://localhost:3000/";

        #region Requisição Apis


        public static async Task<string> GetApi(string rota, int produtoID = 0)
        {
            string urlCompleta = $"{Url}{rota}";

            if (produtoID == 0)
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage resposta = await cliente.GetAsync(urlCompleta);

                        if (resposta.IsSuccessStatusCode)
                        {
                            var conteudo = await resposta.Content.ReadAsStringAsync();
                            return conteudo;
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao fazer a requisição. STATUS: " + resposta.StatusCode);
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                        throw;
                    }
                }
            }
            else
            {
                string urlBuscaProduto = $"{urlCompleta}/{produtoID}";

                using (HttpClient cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage resposta = await cliente.GetAsync(urlBuscaProduto);

                        if (resposta.IsSuccessStatusCode)
                        {
                            var conteudo = await resposta.Content.ReadAsStringAsync();
                            return conteudo;
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao fazer a requisição");
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                        throw;
                    }
                }
            }

        }

        public static async Task PostApi(string rota, Jogo novoJogo, Cliente novoCliente)
        {
            string urlCompleta = $"{Url}{rota}";

            if (novoJogo != null)
            {
                var json = ConverterEmJson(novoJogo);

                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage resposta = await cliente.PostAsync(urlCompleta, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            Console.WriteLine("\nJogo cadastrado com sucesso! :)");
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao cadastrar o jogo. STATUS: " + resposta.StatusCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                        throw;
                    }
                }
            }
            else
            {
                var json = ConverterEmJsonCliente(novoCliente);

                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage resposta = await cliente.PostAsync(urlCompleta, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            Console.WriteLine("\nCliente cadastrado com sucesso! :)");
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao cadastrar o cliente. STATUS: " + resposta.StatusCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public static async Task PutApi(string rota, Jogo atualizarJogo, Cliente atualizarCliente, int id)
        {
            string urlCompleta = $"{Url}{rota}/{id}";

            if (atualizarJogo != null)
            {
                var json = ConverterEmJson(atualizarJogo);

                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage resposta = await cliente.PutAsync(urlCompleta, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            Console.WriteLine("\nJogo atualizado com sucesso! :)");
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao atualizar o jogo. STATUS: " + resposta.StatusCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                        throw;
                    }
                }
            }
            else
            {
                var json = ConverterEmJsonCliente(atualizarCliente);

                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage resposta = await cliente.PutAsync(urlCompleta, content);

                        if (resposta.IsSuccessStatusCode)
                        {
                            Console.WriteLine("\nCliente atualizada com sucesso! :)");
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao atualizar o cliente. STATUS: " + resposta.StatusCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public static async Task DeleteApi(string rota, int id)
        {
            string urlCompleta = $"{Url}{rota}/{id}";

            using (HttpClient cliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage resposta = await cliente.DeleteAsync(urlCompleta);

                    if (resposta.IsSuccessStatusCode)
                    {
                        if (rota == "jogos")
                        {
                            Console.WriteLine("\nProduto deletado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nCliente deletado com sucesso!");
                        }
                    }
                    else
                    {
                        if (rota == "jogos")
                        {
                            Console.WriteLine("\nOcorreu um erro ao deletar o jogo. STATUS: " + resposta.StatusCode);
                        }
                        else
                        {
                            Console.WriteLine("\nOcorreu um erro ao deletar o cliente. STATUS: " + resposta.StatusCode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    throw;
                }
            }
        }


        #endregion


        #region Métodos úteis


        public static Jogo CadastrarAlterarJogo(string tipo)
        {
            Jogo jogo = new Jogo();

            if (tipo == "cadastrar")
            {
                Console.Write("\nQual o nome do jogo? ");
                jogo.Nome = Console.ReadLine();

                Console.Write("\nQual o gênero do jogo? ");
                jogo.Genero = Console.ReadLine();

                Console.Write("\nQual a descrição do jogo? ");
                jogo.Descricao = Console.ReadLine();

                Console.Write("\nQual a desenvolvedora do jogo? ");
                jogo.Desenvolvedora = Console.ReadLine();

                Console.Write("\nQual o preço do jogo? ");
                jogo.PrecoAluguel = Convert.ToDouble(Console.ReadLine());

            }
            else if (tipo == "alterar")
            {
                Console.Write("\nQual o novo nome do jogo? ");
                jogo.Nome = Console.ReadLine();

                Console.Write("\nQual o novo gênero do jogo? ");
                jogo.Descricao = Console.ReadLine();

                Console.Write("\nQual a nova descrição do jogo? ");
                jogo.Descricao = Console.ReadLine();

                Console.Write("\nQual a nova desenvolvedora do jogo? ");
                jogo.Descricao = Console.ReadLine();

                Console.Write("\nQual o novo preço do jogo? ");
                jogo.PrecoAluguel = Convert.ToDouble(Console.ReadLine());
            }

            return jogo;
        }
        public static Cliente CadastrarAlterarCliente(string tipo)
        {
            Cliente cliente = new Cliente();

            if (tipo == "cadastrar")
            {
                Console.Write("\nQual o CPF do cliente? ");
                cliente.CPF = Console.ReadLine();

                Console.Write("\nQual o nome do cliente? ");
                cliente.NomeCliente = Console.ReadLine();
            }
            else if (tipo == "alterar")
            {
                Console.Write("\nQual o novo CPF do cliente? ");
                cliente.CPF = Console.ReadLine();

                Console.Write("\nQual o novo nome do cliente? ");
                cliente.NomeCliente = Console.ReadLine();
            }

            return cliente;
        }
        public static void PrintarValoresLista(List<Jogo> listaJogos)
        {
            foreach (Jogo jogos in listaJogos)
            {
                Console.WriteLine($"\nID: {jogos.id}");
                Console.WriteLine($"Nome: {jogos.Nome}");
                Console.WriteLine($"Descrição: {jogos.Descricao}");
                Console.WriteLine($"Gênero: {jogos.Genero}");
                Console.WriteLine($"Desenvolvedora: {jogos.Desenvolvedora}");
                Console.WriteLine($"Preço: {jogos.PrecoAluguel}");
            }
        }
        public static void PrintarValores(Jogo jogoEspecificado)
        {
            Console.WriteLine($"\nID: {jogoEspecificado.id}");
            Console.WriteLine($"Nome: {jogoEspecificado.Nome}");
            Console.WriteLine($"Descrição: {jogoEspecificado.Descricao}");
            Console.WriteLine($"Gênero: {jogoEspecificado.Genero}");
            Console.WriteLine($"Desenvolvedora: {jogoEspecificado.Desenvolvedora}");
            Console.WriteLine($"Preço: {jogoEspecificado.PrecoAluguel}");
        }
        public static void PrintarValoresListaClientes(List<Cliente> listaClientes)
        {
            foreach (Cliente clientes in listaClientes)
            {
                Console.WriteLine($"\nID: {clientes.id}");
                Console.WriteLine($"CPF: {clientes.CPF}");
                Console.WriteLine($"Nome: {clientes.NomeCliente}");
                Console.WriteLine("Jogos Alugados:");
                foreach (Jogo jogos in clientes.JogoAlugado)
                {
                    Console.WriteLine($"    Nome: {jogos.Nome}");
                    Console.WriteLine($"    Gênero: {jogos.Genero}");
                    Console.WriteLine($"    Desenvolvedora: {jogos.Desenvolvedora}");
                    Console.WriteLine($"    Descrição: {jogos.Descricao}");
                    Console.WriteLine($"    Preço Aluguel: {jogos.PrecoAluguel}");
                    Console.WriteLine();
                }
                Console.WriteLine($"Data de Entrega: {clientes.DataEntrega}");
                Console.WriteLine($"Valor Aluguel: {clientes.CustoTotal}");
            }
        }
        public static void PrintarValoresCliente(Cliente clienteEspecificado)
        {
            Console.WriteLine($"\nID: {clienteEspecificado.id}");
            Console.WriteLine($"CPF: {clienteEspecificado.CPF}");
            Console.WriteLine($"Nome: {clienteEspecificado.NomeCliente}");
            Console.WriteLine("Jogos Alugados:");
            foreach (Jogo jogos in clienteEspecificado.JogoAlugado)
            {
                Console.WriteLine($"    Nome: {jogos.Nome}");
                Console.WriteLine($"    Gênero: {jogos.Genero}");
                Console.WriteLine($"    Desenvolvedora: {jogos.Desenvolvedora}");
                Console.WriteLine($"    Descrição: {jogos.Descricao}");
                Console.WriteLine($"    Preço Aluguel: {jogos.PrecoAluguel}");
                Console.WriteLine();
            }
            Console.WriteLine($"Data de Entrega: {clienteEspecificado.DataEntrega}");
            Console.WriteLine($"Valor Aluguel: {clienteEspecificado.CustoTotal}");
        }
        public static void PrintarJogosAlugados(Cliente cliente)
        {
            foreach (Jogo jogos in cliente.JogoAlugado)
            {
                Console.WriteLine($"Nome: {jogos.Nome}");
                Console.WriteLine($"Gênero: {jogos.Genero}");
                Console.WriteLine($"Desenvolvedora: {jogos.Desenvolvedora}");
                Console.WriteLine($"Descrição: {jogos.Descricao}");
                Console.WriteLine($"Preço Aluguel: {jogos.PrecoAluguel}");
                Console.WriteLine();
            }
        }


        #endregion


        #region Convertor JSON


        public static List<Jogo> DesconverterRespostaLista(string resposta)
        {
            List<Jogo> jogos = JsonConvert.DeserializeObject<List<Jogo>>(resposta);

            return jogos;
        }
        public static Jogo DesconverterResposta(string resposta)
        {
            Jogo jogo = JsonConvert.DeserializeObject<Jogo>(resposta);

            return jogo;
        }
        public static List<Cliente> DesconverterRespostaListaClientes(string resposta)
        {
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resposta);

            return clientes;
        }
        public static Cliente DesconverterRespostaCliente(string resposta)
        {
            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(resposta);

            return cliente;
        }
        public static string ConverterEmJson(Jogo jogo)
        {
            var json = JsonConvert.SerializeObject(jogo);

            return json;
        }
        public static string ConverterEmJsonCliente(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);

            return json;
        }


        #endregion


        #region Exportar CSV


        public static void ExportarParaCsv(List<Cliente> clientes, string csvCaminho)
        {
            using (var writer = new StreamWriter(csvCaminho))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(clientes);
            }
        }


        #endregion
    }
}
