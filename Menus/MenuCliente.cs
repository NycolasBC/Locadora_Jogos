using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class MenuCliente
    {
        public static async Task MenuClienteGeral()
        {
            Locadora locadora = Locadora.GetInstance();

            bool Aplicacaoloop = true;

            while (Aplicacaoloop)
            {
                Console.Clear();
                Console.WriteLine("------------- Sistema de Cadastro de Produtos -------------");
                Console.WriteLine("\n1 - Cadastrar Cliente\n" + "2 - Atualizar Cliente\n" + "3 - Remover Cliente\n" + "4 - Listar Jogos\n" + "5 - Visualizar Seus Jogos Alugados\n" + "6 - Alugar Jogos\n" + "7 - Sair\n");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            Console.Clear();
                            Cliente novoCliente = Utilitarios.CadastrarAlterarCliente("cadastrar");

                            await Utilitarios.PostApi("clientes", null, novoCliente);

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            Cliente novoCliente = Utilitarios.CadastrarAlterarCliente("alterar");

                            Console.Write("\nQual o ID do cliente a ser alterada? ");
                            int clienteID = Convert.ToInt32(Console.ReadLine());

                            await Utilitarios.PutApi("clientes", null, novoCliente, clienteID);

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 3:
                        {
                            Console.Clear();
                            Console.Write("\nQual o ID do cliente que será removida?");
                            int clienteID = Convert.ToInt32(Console.ReadLine());

                            await Utilitarios.DeleteApi("clientes", clienteID);

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            var resposta = await Utilitarios.GetApi("jogos");

                            if (resposta != null)
                            {
                                await locadora.BuscarJogoAsync();
                            }
                            else
                            {
                                Console.WriteLine("\nA API não retornou nada.");
                            }

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 5:
                        {
                            Console.Clear();
                            Console.Write("\nQual o seu ID? ");
                            int clienteID = Convert.ToInt32(Console.ReadLine());

                            var resposta = await Utilitarios.GetApi("clientes", clienteID);

                            if (resposta != null)
                            {
                                Cliente clienteEspecificado = Utilitarios.DesconverterRespostaCliente(resposta);

                                if (clienteEspecificado.JogoAlugado != null)
                                {
                                    Utilitarios.PrintarJogosAlugados(clienteEspecificado);
                                }
                                else
                                {
                                    Console.WriteLine("\nVocê não possui jogos alugados.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nA API não retornou nada.");
                            }

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            if (locadora.ListaJogo == null)
                            {
                                Console.WriteLine("\nVeja primeiro a lista de jogos.");
                            }
                            else
                            {
                                Console.WriteLine("\nQual o nome do jogo que deseja alugar? ");
                                string nomeJogo = Console.ReadLine();

                                Console.Write("\nQual o seu ID? ");
                                int clienteID = Convert.ToInt32(Console.ReadLine());

                                var resposta = await Utilitarios.GetApi("clientes", clienteID);

                                if (resposta != null)
                                {
                                    Cliente clienteEspecificado = Utilitarios.DesconverterRespostaCliente(resposta);

                                    Jogo jogoEscolhido = locadora.ListaJogo.Find(jogo => jogo.Nome == nomeJogo);

                                    if(jogoEscolhido != null)
                                    {
                                        Cliente novoCliente = locadora.AtribuirJogoClienteAsync(clienteEspecificado, jogoEscolhido);

                                        await Utilitarios.PutApi("clientes", null, novoCliente, clienteID);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nJogo não encontrado.");
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("\nA API não retornou nada.");
                                }
                            }

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 7:
                        {
                            Aplicacaoloop = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nEscolha uma opção válida!");
                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }
                }
            }
            Console.WriteLine("\nFim da aplicação! :)");
        }
    }
}
