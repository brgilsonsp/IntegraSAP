using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BL.InnerUtil
{
    public static class TimeClosing
    {
        /// <summary>
        /// Define um tempo em stand by para encerrar a conexão com o BD
        /// </summary>
        public static void ThreadForCloseConnectionDB()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(10));
        }

        /// <summary>
        /// Define um tempo em stand by para encerrar a conexão com o Web Service
        /// </summary>
        public static void ThreadForCloseConnectionWebService()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(50));
        }
    }
}
