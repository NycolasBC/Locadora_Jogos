using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class MenuLocadora
    {
        public static async Task MenuLocadoraGeral()
        {
            Locadora locadora = Locadora.GetInstance();

            bool Aplicacaoloop = true;

            while (Aplicacaoloop)
            {
                Console.Clear();
                Console.WriteLine("------------- Sistema de Cadastro de Produtos -------------");
                Console.WriteLine("\n1 - Cadastrar Jogo\n" + "2 - Atualizar Jogo\n" + "3 - Remover Jogo\n" + "4 - Listar Jogos\n" + "5 - Listar Clientes\n" + "6 - Exportar para CSV\n" + "7 - Sair\n");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            await locadora.CadastrarJogoAsync();

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 2:
                        {
                            await locadora.AtualizarJogoAsync();

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 3:
                        {
                            await locadora.DeletarJogoAsync();

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 4:
                        {
                            await locadora.BuscarJogoAsync();

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 5:
                        {
                            await locadora.BuscarClienteAsync();

                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();
                            break;
                        }

                    case 6:
                        {
                            Console.Clear();
                            Console.Write("\nDeseja exportar para CSV? S/N ");
                            char escolha = Convert.ToChar(Console.ReadLine().ToUpper());

                            if (escolha == 'S')
                            {
                                await locadora.ExportarCSVAsync();
                            }
                            else if (escolha == 'N')
                            {
                                Console.WriteLine("\nNão será exportado para CSV :(");
                            }
                            else
                            {
                                Console.WriteLine("\nOpção inválida.");
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
