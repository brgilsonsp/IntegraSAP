using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerUtil;

namespace BL.Business
{
    public class MakeLog
    {
        /// <summary>
        /// Constró o arquivo de log, se já existir apenas alimenta
        /// </summary>
        /// <param name="messageLog">string com a mensagem que será gravada no log</param>
        /// <param name="message">Um int informando qual a Mensagem que se refere o log</param>
        public static void MakeFileLogUser(string messageLog, int message, string nameFile)
        {
            string pathLog = new ConfigureService().GetPathLog();
            string textoLog = string.Format("{0} {1}", MessagesOfReturn.LINE_DASHED, Environment.NewLine);
            textoLog += string.Format("{0} {1} - {2} {3} {4}", MessagesOfReturn.TITLE_MESSAGE, message, MessagesOfReturn.DATE_INFO,
                DateTime.Now.ToLocalTime(), Environment.NewLine);
            textoLog += string.Format("{0} {1}", messageLog, Environment.NewLine);
            textoLog += string.Format("{0} {1}", MessagesOfReturn.LINE_DASHED, Environment.NewLine);
            string arq = string.Format("{0}{1}", pathLog, nameFile);
            using (StreamWriter str = File.AppendText(arq))
            {
                str.WriteLine(textoLog);
            }
        }

        /// <summary>
        /// Constrói o arquivo de Log para o suporte, com maiores detalhes na mensagem.
        /// Se o arquivo existir, apenas incrementa a mensagem.
        /// </summary>
        /// <param name="messageLog">string com a mensagem que será salva no arquivo</param>
        /// <param name="message">um inteiro informando qual a Mensagem que se refere a mensagem</param>
        public static void MakeFileLogSuport(string messageLog, int message, string nameFile)
        {
            string pathLog = new ConfigureService().GetPathLog();
            string textoLog = string.Format("{0} {1}", MessagesOfReturn.LINE_DASHED, Environment.NewLine);
            textoLog += string.Format("{0} {1} - {2} {3} {4}", MessagesOfReturn.TITLE_MESSAGE, message, MessagesOfReturn.DATE_INFO,
                DateTime.Now.ToLocalTime(), Environment.NewLine);
            textoLog += string.Format("{0} {1}", messageLog, Environment.NewLine);
            textoLog += string.Format("{0} {1}", MessagesOfReturn.LINE_DASHED, Environment.NewLine);
            string arq = string.Format("{0}{1}", pathLog, nameFile);
            using (StreamWriter str = File.AppendText(arq))
            {
                str.WriteLine(textoLog);
            }
        }
    }
}
