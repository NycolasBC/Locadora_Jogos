using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class Locadora : ILocadora
    {
        private static Locadora _instancia;
        public List<Jogo> ListaJogo { get; set; }
        private Locadora()
        {
        }
        public static Locadora GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new Locadora();
            }

            return _instancia;
        }


        public async Task BuscarClienteAsync()
        {
            Console.Clear();
            Console.WriteLine("1 - Listar todos os clientes\n" + "2 - Listar cliente específico");
            int escolha = Convert.ToInt32(Console.ReadLine());

            if (escolha == 1)
            {
                var resposta = await Utilitarios.GetApi("clientes");

                if (resposta != null)
                {
                    List<Cliente> listaCategorias = Utilitarios.DesconverterRespostaListaClientes(resposta);

                    Utilitarios.PrintarValoresListaClientes(listaCategorias);
                }
                else
                {
                    Console.WriteLine("\nA API não retornou nada.");
                }
            }
            else if (escolha == 2)
            {
                Console.Write("\nQual o ID do cliente? ");
                int clienteID = Convert.ToInt32(Console.ReadLine());

                var resposta = await Utilitarios.GetApi("clientes", clienteID);

                if (resposta != null)
                {
                    Cliente clienteEspecificado = Utilitarios.DesconverterRespostaCliente(resposta);

                    Utilitarios.PrintarValoresCliente(clienteEspecificado);
                }
                else
                {
                    Console.WriteLine("\nA API não retornou nada.");
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
            }
        }
        public async Task BuscarJogoAsync()
        {
            Console.Clear();
            Console.WriteLine("1 - Listar todos os jogos\n" + "2 - Listar jogo específico");
            int escolha = Convert.ToInt32(Console.ReadLine());

            if (escolha == 1)
            {
                var resposta = await Utilitarios.GetApi("jogos");

                if (resposta != null)
                {
                    ListaJogo = Utilitarios.DesconverterRespostaLista(resposta);

                    Utilitarios.PrintarValoresLista(ListaJogo);
                }
                else
                {
                    Console.WriteLine("\nA API não retornou nada.");
                }
            }
            else if (escolha == 2)
            {
                Console.Write("\nQual o ID do jogo? ");
                int jogoID = Convert.ToInt32(Console.ReadLine());

                var resposta = await Utilitarios.GetApi("jogos", jogoID);

                if (resposta != null)
                {
                    Jogo jogoEspecificado = Utilitarios.DesconverterResposta(resposta);

                    Utilitarios.PrintarValores(jogoEspecificado);
                }
                else
                {
                    Console.WriteLine("\nA API não retornou nada.");
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
            }
        }
        public async Task CadastrarJogoAsync()
        {
            Jogo novoJogo = Utilitarios.CadastrarAlterarJogo("cadastrar");

            await Utilitarios.PostApi("jogos", novoJogo, null);
        }
        public async Task AtualizarJogoAsync()
        {
            Jogo novoJogo = Utilitarios.CadastrarAlterarJogo("alterar");

            Console.Write("\nQual o ID do jogo a ser alterado? ");
            int jogoID = Convert.ToInt32(Console.ReadLine());

            await Utilitarios.PutApi("jogos", novoJogo, null, jogoID);
        }
        public async Task DeletarJogoAsync()
        {
            Console.Write("\nQual o ID do jogo que será removido?");
            int jogoID = Convert.ToInt32(Console.ReadLine());

            await Utilitarios.DeleteApi("jogos", jogoID);
        }
        public async Task ExportarCSVAsync()
        {
            var resposta = await Utilitarios.GetApi("clientes");

            if (resposta != null)
            {
                List<Cliente> listaClientes = Utilitarios.DesconverterRespostaListaClientes(resposta);

                Console.WriteLine("\nQual será o caminho para guardar o arquivo?");
                string caminho = Console.ReadLine();

                string caminhoArquivo = $"{caminho}clientes.csv";

                Utilitarios.ExportarParaCsv(listaClientes, caminhoArquivo);

                Console.WriteLine("\nArquivo CSV gerado com sucesso! :)");
            }
            else
            {
                Console.WriteLine("\nA API não retornou nada.");
            }
        }
        public Cliente AtribuirJogoClienteAsync(Cliente cliente, Jogo jogoEscolhido)
        {
            if (cliente.JogoAlugado != null)
            {
                cliente.JogoAlugado.Add(jogoEscolhido);
            }
            else
            {
                cliente.JogoAlugado = new List<Jogo> { jogoEscolhido };
            }

            Random random = new Random();

            int intervaloDias = random.Next(1, 365);

            DateTime dataAtual = DateTime.Now;

            DateTime dataFuturaAleatoria = dataAtual.AddDays(intervaloDias);

            cliente.DataEntrega = dataFuturaAleatoria;

            cliente.CustoTotal += jogoEscolhido.PrecoAluguel;

            return cliente;
        }


        void ILocadora.ExportarCSVAsync()
        {
            throw new NotImplementedException();
        }
        void ILocadora.CadastrarJogoAsync()
        {
            throw new NotImplementedException();
        }
        void ILocadora.BuscarClienteAsync()
        {
            throw new NotImplementedException();
        }
        void ILocadora.BuscarJogoAsync()
        {
            throw new NotImplementedException();
        }
        void ILocadora.DeletarJogoAsync()
        {
            throw new NotImplementedException();
        }
        void ILocadora.AtualizarJogoAsync()
        {
            throw new NotImplementedException();
        }
        public void AtribuirJogoClienteAsync(int clienteID, Jogo jogoEscolhido)
        {
            throw new NotImplementedException();
        }
    }
}
