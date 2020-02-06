using System;
using System.Collections.Generic;
using System.Text;

namespace bowling
{
	class ConfiguracaoPinos
	{
		public static int[] completoSpareStrike = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
		//Retorno esperado = 133

		public static int[] simplesStrike = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 2, 3, 0, 0 };
		//Retorno esperado = 20

		public static int[] simplesSpare = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 2, 3, 0, 0 };
		//Retorno esperado = 17

		public static int[] completoPerfeito = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
		//Retorno esperado = 300

		static void receberPinos (ref int[] arrayMaximo, int jogadaAtual, int pinosDerrubados = 0)
		{
			do
			{
				Console.WriteLine("Lembrete: Somente são válidos números entre 0 e {0}.", 10 - pinosDerrubados);
				try
				{
					arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("Insira apenas números!");
					arrayMaximo[jogadaAtual] = 88; //forçar a repetição do loop
				}
				catch (OverflowException)
				{
					Console.WriteLine("O número inserido era grande demais.");
					arrayMaximo[jogadaAtual] = 88; //forçar a repetição do loop
				}
			}
			while (arrayMaximo[jogadaAtual] > (10 - pinosDerrubados) || arrayMaximo[pinosDerrubados] < 0);
		}

		public static int[] manual()
		{
			int[] arrayMaximo = new int[21];
			int[] jogoFinal;
			int jogadaAtual = 0;

			for (int rodadaAtual = 0; rodadaAtual < 10; rodadaAtual++, jogadaAtual++)
			{
				Console.Clear();

				Console.WriteLine("Rodada {0}\nQuantos pinos foram derrubados na primeira jogada?", rodadaAtual + 1);

				receberPinos(ref arrayMaximo, jogadaAtual); //1ª jogada da rodada

				if (arrayMaximo[jogadaAtual] == 10) //strike
				{
					if (rodadaAtual == 9) //strike na última rodada
					{
						Console.WriteLine("\nQuantos pinos cairam na segunda jogada dessa rodada?");

						jogadaAtual++;
						receberPinos(ref arrayMaximo, jogadaAtual); //1ª jogada extra

						Console.WriteLine("\nE quantos foram derrubados na terceira?");

						jogadaAtual++;
						if (arrayMaximo[jogadaAtual - 1] == 10)
						{
							receberPinos(ref arrayMaximo, jogadaAtual); //2ª jogada extra, caso ocorra outro strike
						}
						else
						{
							receberPinos(ref arrayMaximo, jogadaAtual, arrayMaximo[jogadaAtual - 1]); //2ª jogada extra, sem strike
						}
					}

					continue; //acabar rodada
				}

				Console.WriteLine("\nQuantos pinos cairam na segunda jogada dessa rodada?");

				jogadaAtual++;
				receberPinos(ref arrayMaximo, jogadaAtual, arrayMaximo[jogadaAtual - 1]); //2ª jogada da rodada

				if ((arrayMaximo[jogadaAtual - 1] + arrayMaximo[jogadaAtual]) == 10) //spare
				{
					if (rodadaAtual == 9) //spare na última rodada
					{
						Console.WriteLine("\nE quantos foram derrubados na terceira?");

						jogadaAtual++;
						receberPinos(ref arrayMaximo, jogadaAtual);
					}
				}
			}

			jogoFinal = new int[jogadaAtual];
			Array.Copy(arrayMaximo, 0, jogoFinal, 0, jogadaAtual);
			return jogoFinal;
		}
	}
}
