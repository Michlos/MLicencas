using System;
using System.Collections.Generic;

namespace CommonComponents
{
    public static class GetOrdinal
    {
        public static string GetOrd(int num)
        {
            //VARIÁVEL DE RETORNO
            string numOrdinary = string.Empty;

            //VARIÁVEIS DE CONTROLE
            int numLenth = num.ToString().Length;
            string[] unidades = { "", "primeira", "segunda", "terceira", "quarta", "quinta", "sexta", "sétema", "oitava", "nona" };
            string[] dezenas = { "", "décima", "vigézima", "trigézima", "quadragézima", "quiquagézima", "sexagézima", "septuagézima", "octagézima", "nonagézima" };
            string unidadeStr = string.Empty, dezenaStr = string.Empty;
            int unidade = 0, dezena = 0;
            List<int> valuesDayInt = new List<int>();

            for (int i = numLenth; i > 0; i--)
            {
                string dayValue = num.ToString().Substring(i - 1, 1);
                valuesDayInt.Add(int.Parse(dayValue));

            }
            int[] daysArray = valuesDayInt.ToArray();

            //ATRIBUINDO VALORES ÀS VARIÁVEIS INTEIRAS CONFORME VALOR RECEBIDO
            for (int i = 0; i < daysArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        unidade = daysArray[i];
                        break;
                    case 1:
                        dezena = daysArray[i];
                        break;
                }
            }

            if (dezena != 0)
            {

                dezenaStr = dezenas[dezena];
            }

            if (unidade != 0)
            {
                if (dezena != 1)
                {
                    unidadeStr = unidades[unidade];
                }
            }

            if (unidade != 0)
            {
                if (dezena != 1)
                {
                    numOrdinary += unidadeStr;
                }
            }

            return numOrdinary;
        }



    }
}
