using BL.Command;
using System;
using BL.DAO;
using BL.Infra;
using BL.InnerUtil;
using System.Diagnostics;

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
            string tipo = "Exportação";
            for (int i = 0; i < 5; i++)
            {
                string retorno = "";
                int message = i + 1;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                try
                {
                    //Recarrega o contexto
                    ChangeXMLContext.ReloadContext();

                    //Define qual Mensagem instanciar
                    string objeto = "BL.Command.Mensagem" + message;

                    //Instancia a Mensagem
                    var classe = Activator.CreateInstance(null, objeto);
                    IMessage mensagem = (IMessage)classe.Unwrap();

                    //Efetua a troca da Mensagem com o Web Service do GTE
                    retorno += mensagem.SwapXmlWithGTE();
                    //MakeLog.BuildLogUser(retorno, byte.Parse(message.ToString()), tipo);
                }
                catch (Exception ex)
                {
                    string messageError = MessagesOfReturn.ExceptionMessageLogSupport($"Message {message}");
                    int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, "RunMessenger");
                    messageError = $"Erro Faltal{Environment.NewLine}";
                    retorno += MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, message.ToString());
                    //MakeLog.BuildLogUser(messageError, byte.Parse(message.ToString()), tipo);
                }
                finally
                {
                    stopwatch.Stop();
                    MakeLog.BuildLogUser(retorno, byte.Parse(message.ToString()), tipo, stopwatch.Elapsed);
                }
            }
        }

    }
}
