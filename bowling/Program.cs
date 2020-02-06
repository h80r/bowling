using System;

namespace bowling
{
	class Program
	{
		static void Main(string[] args)
		{
			int opcaoPinos;
			int[] pinosDerrubados;

			Console.WriteLine("Que configuração você deseja testar?\n");
			Console.WriteLine("1 - Jogo Completo com Spare e Strike");
			Console.WriteLine("2 - Jogo Simples com Strike");
			Console.WriteLine("3 - Jogo Simples com Spare");
			Console.WriteLine("4 - Jogo Completo Perfeito");
			Console.WriteLine("0 - Configuração Manual\n");
			opcaoPinos = int.Parse(Console.ReadLine());

			switch (opcaoPinos)
			{
				case 1:
					pinosDerrubados = ConfiguracaoPinos.completoSpareStrike;
					break;
				case 2:
					pinosDerrubados = ConfiguracaoPinos.simplesStrike;
					break;
				case 3:
					pinosDerrubados = ConfiguracaoPinos.simplesSpare;
					break;
				case 4:
					pinosDerrubados = ConfiguracaoPinos.completoPerfeito;
					break;
				case 0:
					pinosDerrubados = ConfiguracaoPinos.manual();
					break;
				default:
					Console.WriteLine("\nOpção inserida inválida.\nO teste será efetuado com a opção 1.");
					pinosDerrubados = ConfiguracaoPinos.completoSpareStrike;
					break;
			}

			Console.WriteLine("\nResultado final: {0} pontos!", CalculadoraPontuacaoBoliche.pontuacaoDoJogo(pinosDerrubados));
		}
	}
}
