using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InnerUtil
{
    public static class ConverterValue
    {
        #region Converter int/string

        /// <summary>
        /// Converte uma string em um int?. Caso a string seja null ou vazia ou não possua um valor possível de converter
        /// para int, retorna um int? null, caso contrário, retorna o valor convertido para int?.
        /// </summary>
        /// <param name="numberText">String com um conteúdo possível de alterar para int</param>
        /// <returns>Um valor convertido para int?</returns>
        public static int? StringToIntNullable(string numberText)
        {
            int outInt;
            return int.TryParse(numberText, out outInt) ? outInt : (int?)null;
        }

        /// <summary>
        /// Converte o valor de number para string. Caso o number seja nulo, retorna uma string vazia
        /// </summary>
        /// <param name="intValue">Int?</param>
        /// <returns>String</returns>
        public static string IntNullableToString(int? intValue)
        {
            return intValue != null ? intValue.ToString() : "";
        }

        #endregion

        #region Converter decimal/string

        /// <summary>
        /// Converte uma string em um decimal?. Caso a string seja null ou vazia ou não possua um valor possível de converter
        /// para decimal, retorna um decimal? null, caso contrário, retorna o valor convertido para decimal?.
        /// </summary>
        /// <param name="decimalText">String com um conteúdo possível de alterar para decimal</param>
        /// <returns>Um valor convertido para decimal?</returns>
        public static decimal? StringToDecimalNullable(string decimalText)
        {
            decimal outDecimal;
            return decimal.TryParse(decimalText, out outDecimal) ? outDecimal : (decimal?)null;
        }

        /// <summary>
        /// Converte o valor de decimal para string. Caso o number seja nulo, retorna uma string vazia
        /// </summary>
        /// <param name="number">Int?</param>
        /// <returns>String</returns>
        public static string DecimalNullableToString(decimal? decimalValue)
        {
            return decimalValue != null ? decimalValue.ToString() : "";
        }

        #endregion

    }
}
