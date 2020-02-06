using System;

namespace bowling
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] pinosDerrubados = { 1, 4,  4, 5,  6, 4,  5, 5,  10,  0, 1,  7, 3,  6, 4,  10,  2, 8, 6 };
				//Retorno esperado = 133
			//int[] pinosDerrubados = { 0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  10,  2, 3,  0, 0 };
				//Retorno esperado = 20
			//int[] pinosDerrubados = { 0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  2, 8,  2, 3,  0, 0 };
				//Retorno esperado = 17
			int[] pinosDerrubados = { 10,  10,  10,  10,  10,  10,  10,  10,  10,  10, 10, 10 };
				//Retorno esperado = 300

			Console.WriteLine(CalculadoraPontuacaoBoliche.pontuacaoDoJogo(pinosDerrubados));
		}
	}

	class CalculadoraPontuacaoBoliche
	{
		public static int pontuacaoDoJogo (int[] jogadas)
		{
			int result = 0;

			for (int load = 0, round = 0, temp; round < 10; round++, load++)
			{
				temp = jogadas[load];
				if (temp == 10) //strike
				{
					result += temp + jogadas[load + 1] + jogadas[load + 2];
				}
				else
				{
					load++;
					temp += jogadas[load];
					if (temp == 10) //spare
					{
						result += temp + jogadas[load + 1];
					}
					else //normal
					{
						result += temp;
					}
				}
			}
			return result;
		}
	}
}
