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
				arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine());
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
				receberPinos(ref arrayMaximo, jogadaAtual);

				if (arrayMaximo[jogadaAtual] == 10) //strike
				{
					if (rodadaAtual == 9) //strike na última rodada
					{
						jogadaAtual++;
						arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine()); //primeira jogada adicional

						jogadaAtual++;
						if (arrayMaximo[jogadaAtual - 1] == 10) arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine()); //segunda jogada adicional, caso ocorra outro strike
						else
						{
							arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine()); //segunda jogada adicional, sem strike
						}
					}

					continue; //acabar rodada
				}

				jogadaAtual++;
				receberPinos(ref arrayMaximo, jogadaAtual, arrayMaximo[jogadaAtual - 1]);

				if ((arrayMaximo[jogadaAtual - 1] + arrayMaximo[jogadaAtual]) == 10 && rodadaAtual == 9) //spare na última rodada
				{
					jogadaAtual++;
					receberPinos(ref arrayMaximo, jogadaAtual);
				}
			}

			jogoFinal = new int[jogadaAtual];
			Array.Copy(arrayMaximo, 0, jogoFinal, 0, jogadaAtual);
			return jogoFinal;
		}
	}
}
