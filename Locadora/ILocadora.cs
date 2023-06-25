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

        void BuscarJogoAsync();
        void BuscarClienteAsync();
        void CadastrarJogoAsync();
        void AtualizarJogoAsync();
        void DeletarJogoAsync();
        void AtribuirJogoClienteAsync(int clienteID, Jogo jogoEscolhido);
        void ExportarCSVAsync();
    }
}
