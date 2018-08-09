using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// Converte o valor de int para string. Caso o number seja nulo, retorna uma string vazia
        /// </summary>
        /// <param name="intValue">Int?</param>
        /// <returns>String</returns>
        public static string IntNullableToString(int? intValue)
        {
            return intValue != null ? intValue.ToString() : "";
        }

        /// <summary>
        /// Converte uma string em um long?. Caso a string seja null ou vazia ou não possua um valor possível de converter
        /// para long, retorna um long? null, caso contrário, retorna o valor convertido para long?.
        /// </summary>
        /// <param name="numberText">String com um conteúdo possível de alterar para long</param>
        /// <returns>Um valor convertido para long?</returns>
        public static long? StringToLongNullable(string numberText)
        {
            long outInt;
            return long.TryParse(numberText, out outInt) ? outInt : (long?)null;
        }

        /// <summary>
        /// Converte o valor de long para string. Caso o long seja nulo, retorna uma string vazia
        /// </summary>
        /// <param name="intValue">long?</param>
        /// <returns>String</returns>
        public static string LongNullableToString(long? intValue)
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
            return decimal.TryParse(decimalText, NumberStyles.Any, CultureInfo.InvariantCulture, out outDecimal) ? outDecimal : (decimal?)null;
        }

        /// <summary>
        /// Converte o valor de decimal para string no padrão en-US. Caso o number seja nulo, retorna uma string vazia
        /// </summary>
        /// <param name="number">Int?</param>
        /// <returns>String</returns>
        public static string DecimalNullableToString(decimal? decimalValue)
        {
            if(decimalValue != null)
            {
                return decimalValue.Value.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            }
            return "";
        }

        #endregion
        
        #region datetime/string

        /// <summary>
        /// Converte uma data string formato YYYYMMDD para um DateTime
        /// </summary>
        /// <param name="dateString">String com uma data YYYYMMMDD sem os separadores</param>
        /// <returns>DateTime</returns>
        public static DateTime? StringForDateTimeNullable(string dateString)
        {
            DateTime? dataOk;
            try
            {
                string formatDate = "yyyyMMdd";
                CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                dataOk = DateTime.ParseExact(dateString.Trim(), formatDate, cultureInfo);
            }
            catch (Exception)
            {
                dataOk = null;
            }
            return dataOk;
        }

        /// <summary>
        /// Recebe um DateTime e retorna uma string no padrão yyyyMMdd, sem os separadores.
        /// </summary>
        /// <param name="dateTime">DateTime?</param>
        /// <returns>string no padrão yyyyMMdd, sem os separadores</returns>
        public static string DateTimeNullableForString(DateTime? dateTime)
        {
            string dataOk = "";
            try
            {
                if (dateTime != null)
                {
                    DateTime dataInterna = (DateTime)dateTime;
                    string formato = "yyyyMMdd";
                    dataOk = dataInterna.ToString(formato);
                }
                else
                {
                    dataOk = "";
                }
            }
            catch (Exception)
            {
                dataOk = "";
            }
            return dataOk;
        }

        #endregion

        #region string/null

        /// <summary>
        /// Se a string informada no parâmetro for null, returna uma string vazia, caso contrário retorna o valor 
        /// do parâmetro
        /// </summary>
        /// <param name="value">String para verificação</param>
        /// <returns>O valor do parâmetro caso seja diferente de null, caso seja null retorna uma string vazia</returns>
        public static string StringNullToEmpty(string value)
        {
            return string.IsNullOrEmpty(value) ? "" : value;
        }

        #endregion
    }
}
