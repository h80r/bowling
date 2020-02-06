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

		public static int[] manual()
		{
			int[] arrayMaximo = new int[21];
			int[] jogoFinal;
			int jogadaAtual = 0;
			int valorInserido;

			for (int rodadaAtual = 0; rodadaAtual < 10; rodadaAtual++, jogadaAtual++)
			{
				valorInserido = int.Parse(Console.ReadLine());
				arrayMaximo[jogadaAtual] = valorInserido;

				if (valorInserido == 10) //strike
				{
					if (rodadaAtual == 9) //strike na última rodada
					{
						for (int i = 0; i < 2; i++)
						{
							jogadaAtual++;
							arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine());
						}
					}

					continue; //acabar rodada
				}

				jogadaAtual++;
				valorInserido = int.Parse(Console.ReadLine());
				arrayMaximo[jogadaAtual] = valorInserido;

				if ((arrayMaximo[jogadaAtual - 1] + valorInserido) == 10 && rodadaAtual == 9) //spare na última rodada
				{
					jogadaAtual++;
					arrayMaximo[jogadaAtual] = int.Parse(Console.ReadLine());
				}
			}

			jogoFinal = new int[jogadaAtual];
			Array.Copy(arrayMaximo, 0, jogoFinal, 0, jogadaAtual);
			return jogoFinal;
		}
	}
}
