using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraJogos
{
    internal class Locadora : ILocadora
    {
        private static Locadora _instancia;

        public Locadora()
        {
        }

        public static Locadora GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new Impressora();
            }

            return _instancia;
        }

        
    }
}
