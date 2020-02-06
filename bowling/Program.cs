using System;

namespace bowling
{
	class Program
	{
		static void Main(string[] args)
		{
			int opcaoPinos;
			int[] pinosDerrubados;

			do
			{
				Console.Clear();
				Console.WriteLine("Estas são as opções de configuração do placar:\n");
				Console.WriteLine("1 - Jogo Completo com Spare e Strike");
				Console.WriteLine("2 - Jogo Simples com Strike");
				Console.WriteLine("3 - Jogo Simples com Spare");
				Console.WriteLine("4 - Jogo Completo Perfeito");
				Console.WriteLine("0 - Configuração Manual\n");
				Console.WriteLine("Por favor, selecione uma das opções acima.");

				try
				{
					opcaoPinos = int.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("Insira apenas números.");
					opcaoPinos = 88; //forçar a repetição do loop
				}
				catch (OverflowException)
				{
					Console.WriteLine("O número inserido era grande demais.");
					opcaoPinos = 88; //forçar a repetição do loop
				}
				finally
				{
					System.Threading.Thread.Sleep(500); //tempo parado para que o usuário veja no caso de erro
				}
			}
			while (opcaoPinos > 4 || opcaoPinos < 0);

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
					Console.Write("\nConfiguração Manual iniciada!\nPressione qualquer tecla para continuar. . . ");
					Console.ReadKey();
					pinosDerrubados = ConfiguracaoPinos.manual();
					Console.Write("Configuração Manual encerrada!\nPressione qualquer tecla para continuar. . . ");
					Console.ReadKey();
					Console.Clear();
					break;
				default:
					Console.WriteLine("\nOpção inserida inválida.\nO teste será efetuado com a opção 1.");
					pinosDerrubados = ConfiguracaoPinos.completoSpareStrike;
					break;
			}

			Console.Write("Placar inserido: [ ");
			for (int i = 0; i < pinosDerrubados.Length - 1; i++)
			{
				Console.Write("{0}, ", pinosDerrubados[i]);
			}
			Console.WriteLine("{0} ]", pinosDerrubados[pinosDerrubados.Length - 1]);
			Console.WriteLine("\nResultado final: {0} pontos!", CalculadoraPontuacaoBoliche.pontuacaoDoJogo(pinosDerrubados));
		}
	}
}
