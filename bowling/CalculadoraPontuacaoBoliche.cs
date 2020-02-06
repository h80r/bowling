using System;
using System.Collections.Generic;
using System.Text;

namespace bowling
{
	class CalculadoraPontuacaoBoliche
	{
		public static int pontuacaoDoJogo(int[] jogadas)
		{
			int pontuacaoFinal = 0;

			for (int jogadaAtual = 0, rodadaAtual = 0, pontuacaoRodada; rodadaAtual < 10; rodadaAtual++, jogadaAtual++)
			{
				pontuacaoRodada = jogadas[jogadaAtual];

				if (pontuacaoRodada == 10) //strike
				{
					pontuacaoRodada += jogadas[jogadaAtual + 1] + jogadas[jogadaAtual + 2];
				}
				else //spare & normal
				{
					jogadaAtual++;
					pontuacaoRodada += jogadas[jogadaAtual];
					if (pontuacaoRodada == 10) //spare
					{
						pontuacaoRodada += jogadas[jogadaAtual + 1];
					}
				}

				pontuacaoFinal += pontuacaoRodada;
			}
			return pontuacaoFinal;
		}
	}
}
