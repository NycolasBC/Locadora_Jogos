using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    interface ILocadora
    {
        List<Jogo> ListaJogo { get; set; }
        Utilitarios Utilitarios { get; set; }

    }
}
