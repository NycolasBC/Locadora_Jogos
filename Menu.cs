﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class Menu
    {
        static void MenuGeral()
        {
            bool loopAplicacao = true;

            while (loopAplicacao)
            {
                Console.Clear();
                Console.WriteLine("------------- MENU LOGIN -------------");

                Console.WriteLine("1 - ADM Locadora" + "\n2 - Cliente" + "\n3 - Para Aplicação\n");
                int login = Convert.ToInt32(Console.ReadLine());

                switch (login)
                {
                    case 1:
                        {

                            break;
                        }

                    case 2:
                        {

                            break;
                        }

                    case 3:
                        {
                            loopAplicacao = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nEscolha um valor válido!\n");
                            Console.WriteLine("\nAperte ENTER para continuar...");
                            Console.ReadLine();

                            break;
                        }
                }
            }

            Console.WriteLine("\nFim da Aplicação!");
        }
    }
}
