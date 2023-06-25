using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class Cliente
    {
        public int id { get; set; }
        public string CPF { get; set; }
        public string NomeCliente { get; set; }
        public List<Jogo> JogoAlugado { get; set; }
        public DateTime DataEntrega { get; set; }
        public double CustoTotal { get; set; }
    }
}
