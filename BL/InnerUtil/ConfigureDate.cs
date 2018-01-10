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
        /// Retorma a data de 01/01/1990
        /// </summary>
        public static DateTime DateMin
        {
            get { return new DateTime(1990, 1, 1); }
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

    }
}
