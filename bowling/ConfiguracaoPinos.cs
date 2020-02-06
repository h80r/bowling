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
	}
}
