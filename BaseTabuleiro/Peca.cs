using projeto_xadrez.BaseTabuleiro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_xadrez.BaseTabuleiro
{
     abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            QtdMovimentos = 0;
            Tab = tab;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public void DecrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int l = 0; l<Tab.Linhas; l++)
            {
                for(int c = 0; c<Tab.Colunas; c++)
                {
                    if (mat[l,c])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
   
    }
}
