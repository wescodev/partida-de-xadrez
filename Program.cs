using projeto_xadrez.BaseTabuleiro;
using projeto_xadrez.BaseTabuleiro.Enum;
using projeto_xadrez.xadrez;

namespace projeto_xadrez;
class Program

{
    static void Main(string[] args)
    {
        try
        { 
           PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.Terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.Tabuleiro.PecaTela(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDeDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);

                }

                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }


        }

        catch (TabuleiroException e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.ReadLine();



    }
}