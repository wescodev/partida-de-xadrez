using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_xadrez.BaseTabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca PecaTela(int linha, int colunas)
        {
            return Pecas[linha, colunas];

        }

        public Peca PecaTela(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return PecaTela(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p; 
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if(PecaTela(pos) == null) 
            {
                return null; //se a peça for nula, significa que não tem peça pra tirar
            }
            Peca aux = PecaTela(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
      
        }

        public bool PosicaoValida(Posicao pos) //testa se a posição faz parte do tabuleiro
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos)) 
            {
                throw new TabuleiroException("Posição inválida!");
            }

        }
    }
}
