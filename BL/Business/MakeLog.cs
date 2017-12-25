using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.InnerUtil;
using BL.InnerException;

namespace BL.Business
{
    public class MakeLog
    {
        /// <summary>
        /// Constrói o arquivo de log, se já existir apenas alimenta
        /// </summary>
        /// <param name="messageLog">string com a mensagem que será gravada no log</param>
        /// <param name="message">Uma string informando qual a Mensagem que se refere o log</param>
        public static void MakeFileLogUser(string messageLog, string message, string nameFile)
        {
            string pathLog = new ConfigureService().RootLog;
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
        /// <param name="message">uma string informando qual a Mensagem que se refere a mensagem</param>
        public static void MakeFileLogSuport(string messageLog, string message, string nameFile)
        {
            string pathLog = new ConfigureService().RootLog;
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




        public static void FactoryLogForError(Exception ex, string observation)
        {
            //Construir...
        }

        public static void FactoryLogForError(string information)
        {
            //Construir...
        }



        /// <summary>
        /// Constrói o arquivo de log para o BaseInnerException
        /// </summary>
        /// <param name="message">int</param>
        /// <param name="iE">BaseInnerException</param>
        public static void MakeFileBaseException(int message, BaseInnerException iE)
        {
            string innerCodeError = CodeRandom();
            string msgLogUser = MakeMsgLogUser(iE, innerCodeError);
            string msgLogSuport = MakeMsgLogSuportInnerException(iE, innerCodeError);
            MakeLog.MakeFileLogUser(msgLogUser, message.ToString(), Option.FILE_LOG_USER);
            MakeLog.MakeFileLogSuport(msgLogSuport, message.ToString(), Option.FILE_LOG_SUPORT);
        }

        /// <summary>
        /// Constrói o arquivo de Log para o Exception
        /// </summary>
        /// <param name="message">Mensagem em processamento</param>
        /// <param name="ex">Exception</param>
        public static void MakeFileException(string message, Exception ex)
        {
            string innerCodeError = CodeRandom();
            string msgLogUser = MakeMsgLogUser(ex, innerCodeError);
            string msgLogSuport = MakeMsgLogSuportException(ex, innerCodeError);

            MakeFileLogUser(msgLogUser, message, Option.FILE_LOG_USER);
            MakeFileLogSuport(msgLogSuport, message, Option.FILE_LOG_SUPORT);
        }

        /// <summary>
        /// Cria o arquivo de log no c:\
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msgException"></param>
        public static void MakeFileExceptionLog(string msg, string msgException)
        {
            string messageErrorLogSuport = string.Format("{0} {1} {2}", msg, Environment.NewLine, ConfigureDate.ActualDate);
            messageErrorLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.ERROR_CREATE_LOG_EXCEPTION,
                msgException, Environment.NewLine);
            using (var arq = File.AppendText(Option.FILE_LOG_ERROR_ACCESS))
            {
                arq.WriteLine(messageErrorLogSuport);
            }
        }

        /// <summary>
        /// Gera um código de erro para cada mensagem. Identificará as mensagens nos 
        /// log de suporte e usuário
        /// </summary>
        /// <returns>string com um código randomico</returns>
        private static string CodeRandom()
        {
            int ran = new Random().Next();
            DateTime dt = new DateTime();
            ran += ((dt.Hour + dt.Day + dt.Year) / 20) + ran;
            ran = Math.Abs(ran);
            return ran.ToString();
        }

        /// <summary>
        /// Constrói a mensagem que será inserida no arquivo de log do usuário
        /// </summary>
        /// <param name="exception">InnerException</param>
        /// <param name="code">string com o código do erro</param>
        /// <returns>string com a mensagem de erro definida</returns>
        public static string MakeMsgLogUser(Exception exception, string code)
        {
            string pathLog = new ConfigureService().RootLog;
            string msgLogUser = string.Format("{0} {1}", MessagesOfReturn.START_ERROR, Environment.NewLine);
            msgLogUser += string.Format("{0} {2} {1} {2}", MessagesOfReturn.COD_INFO, code, Environment.NewLine);
            msgLogUser += string.Format("{0} {2} {1} {2}", MessagesOfReturn.MESSAGE_INFO, exception.Message, Environment.NewLine);
            msgLogUser += string.Format("{2} {0} {1}.{2}", MessagesOfReturn.DETAIL_ARCHIVE, pathLog + Option.FILE_LOG_SUPORT,
                Environment.NewLine);
            msgLogUser += string.Format("{1}{0}{1}", MessagesOfReturn.END_ERROR, Environment.NewLine);

            return msgLogUser;
        }

        /// <summary>
        /// Constrói a mensagem que será inserida no arquivo de log de suporte, com mais detalhes
        /// </summary>
        /// <param name="exception">InnerException</param>
        /// <param name="code">string com o código de erro</param>
        /// <returns>string com a mensagem de erro definida</returns>
        private static string MakeMsgLogSuportInnerException(Exception exception, string code)
        {
            string msgLogSuport = string.Format("{0} {1} {2}", MessagesOfReturn.COD_INFO, code, Environment.NewLine);
            msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.RESULT_INFO, exception.HResult, Environment.NewLine);
            msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.SOURCE_INFO, exception.Source, Environment.NewLine);
            msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.TRACE_INFO, exception.StackTrace, Environment.NewLine);
            msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.TARGET_INFO, exception.TargetSite, Environment.NewLine);
            msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.EXCPTION_INFO, exception.GetBaseException().ToString(),
                Environment.NewLine);
            msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.MSG_EXCINFO, exception.Message, Environment.NewLine);
            if (exception.InnerException != null)
            {
                msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.INNER_EXCINFO, exception.InnerException,
                    Environment.NewLine);
                msgLogSuport += string.Format("{0} {1} {2}", MessagesOfReturn.MSG_INNER_EXCP_INFO, exception.InnerException.Message,
                    Environment.NewLine);
            }
            return msgLogSuport;
        }

        /// <summary>
        /// Constrói a mensagem que será inserida no arquivo de log de suporte, com mais detalhes
        /// porém diferenciando pois essa mensagem será para todas as Exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="code">string com o código de erro</param>
        /// <returns>string com a mensagem de erro definida</returns>
        private static string MakeMsgLogSuportException(Exception exception, string code)
        {
            string msgLogSuport = string.Format("{0}{1}", MessagesOfReturn.TITLE_MSG_EXCP_INFO, Environment.NewLine);
            msgLogSuport += MakeMsgLogSuportInnerException(exception, code);

            return msgLogSuport;
        }
    }
}
