using BL.Command;
using System;
using Util.InnerException;
using System.IO;
using BL.Business;
using DAL.ObjectMessages;
using System.Collections.Generic;
using Util.InnerUtil;

namespace BL
{
    public class RunMessenger
    {

        /// <summary>
        /// Instancia as classes do tipo Mensagem do BL.Command 
        /// e invoca o método SwapXmlWithGTE
        /// </summary>
        /// <returns></returns>
        public void StartChangeXML()
        {
            ConfigureService configureService = new ConfigureService();
            for (int i = 0; i < 5; i++)
            {
                string retorno = "";
                int message = i + 1;
                try
                {
                    //Define qual Mensagem instanciar
                    string objeto = "BL.Command.Mensagem" + message;
                    //Instancia a Mensagem
                    var classe = Activator.CreateInstance(null, objeto);
                    Mensagem mensagem = (Mensagem)classe.Unwrap();
                    //Efetua a troca da Mensagem com o Web Service do GTE
                    retorno += mensagem.SwapXmlWithGTE(configureService);
                    MakeLog.MakeFileLogUser(retorno, message.ToString(), Option.FILE_LOG_USER);
                }
                catch (BaseInnerException iE)
                {
                    try
                    {
                        //Escreve o arquivo de log se lançar um BaseInnerException
                        MakeFileBaseException(message, iE, configureService);
                    }
                    catch (Exception ex)
                    {
                        //Se não conseguir criar o arquivo de log, cria um log no c:\ informando
                        //a mensagem da excetpion que foi lançada
                        MakeFileExceptionLog(MessagesOfReturn.ERROR_CREATE_LOG_USER, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        //Escreve o arquivo de log se lançar um Exception
                        MakeFileException(message, ex, configureService);
                    }
                    catch (Exception ex1)
                    {
                        //Se não conseguir criar o arquivo de log, cria um log no c:\ informando
                        //a mensagem da excetpion que foi lançada
                        MakeFileExceptionLog(MessagesOfReturn.ERRORCREATELOGSUPORT, ex1.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Constrói o arquivo de log para o BaseInnerException
        /// </summary>
        /// <param name="message">int</param>
        /// <param name="iE">BaseInnerException</param>
        private void MakeFileBaseException(int message, BaseInnerException iE, ConfigureService configureService)
        {
            string innerCodeError = CodeRandom();
            string msgLogUser = MakeMsgLogUser(iE, innerCodeError, configureService);
            string msgLogSuport = MakeMsgLogSuportInnerException(iE, innerCodeError);
            MakeLog.MakeFileLogUser(msgLogUser, message.ToString(), Option.FILE_LOG_USER);
            MakeLog.MakeFileLogSuport(msgLogSuport, message.ToString(), Option.FILE_LOG_SUPORT);
        }

        /// <summary>
        /// Constrói o arquivo de Log para o Exception
        /// </summary>
        /// <param name="message">int</param>
        /// <param name="ex">Exception</param>
        private void MakeFileException(int message, Exception ex, ConfigureService configureService)
        {
            string innerCodeError = CodeRandom();
            string msgLogUser = MakeMsgLogUser(ex, innerCodeError, configureService);
            string msgLogSuport = MakeMsgLogSuportException(ex, innerCodeError);

            MakeLog.MakeFileLogUser(msgLogUser, message.ToString(), Option.FILE_LOG_USER);
            MakeLog.MakeFileLogSuport(msgLogSuport, message.ToString(), Option.FILE_LOG_SUPORT);
        }

        /// <summary>
        /// Cria o arquivo de log no c:\
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msgException"></param>
        private void MakeFileExceptionLog(string msg, string msgException)
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
        private string CodeRandom()
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
        private string MakeMsgLogUser(Exception exception, string code, ConfigureService configureService)
        {
            string pathLog = configureService.RootLog;
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
        private string MakeMsgLogSuportInnerException(Exception exception, string code)
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
        private string MakeMsgLogSuportException(Exception exception, string code)
        {
            string msgLogSuport = string.Format("{0}{1}", MessagesOfReturn.TITLE_MSG_EXCP_INFO, Environment.NewLine);
            msgLogSuport += MakeMsgLogSuportInnerException(exception, code);

            return msgLogSuport;
        }
    }
}
