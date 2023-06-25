using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class Jogo
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Desenvolvedora { get; set; }
        public string Descricao { get; set; }
        public double PrecoAluguel { get; set; }
    }
}
