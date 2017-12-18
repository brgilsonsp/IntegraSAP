using System;
using System.Globalization;

namespace BL.InnerUtil
{
    public static class ConfigureDate
    {
        /// <summary>
        /// Retorna um DateTime com a data atual
        /// </summary>
        public static DateTime ActualDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Retorna uma string com o valor de data, hora, minuto e segundo
        /// no format ddMMyyyyHHmmss
        /// </summary>
        public static string DateNameFile
        {
            get
            {
                return ActualDate.ToString("ddMMyyyyHHmmss");
            }
        }
        /// <summary>
        /// Converte uma data string formato YYYYMMDD para um DateTime
        /// </summary>
        /// <param name="dateString">String com uma data YYYYMMMDD sem os separadores</param>
        /// <returns>DateTime</returns>
        public static DateTime? convertDateStringForDateTime(string dateString)
        {
            DateTime? dataOk;
            try
            {
                string formatDate = "yyyyMMdd";
                CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                dataOk = DateTime.ParseExact(dateString, formatDate, cultureInfo);
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
        public static string converDateTimeForDateString(DateTime? dateTime)
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
                    dataOk = "00000000";
                }
            }
            catch (Exception)
            {
                dataOk = "00000000";
            }
            return dataOk;
        }
    }
}
