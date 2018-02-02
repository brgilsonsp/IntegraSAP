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

                    //Efetua a troca da Mensagem com o Web Service
                    retorno += mensagem.Execute();
                }
                catch (Exception ex)
                {
                    string messageError = MessagesOfReturn.ExceptionMessageLogSupport($"Message {message}", null, GetNumberOfMessage(message));
                    int codeMessageError = MakeLog.BuildErrorLogSupport(ex, messageError, "RunMessenger");
                    messageError = $"Erro Faltal{Environment.NewLine}";
                    retorno += MessagesOfReturn.ExceptionMessageLogUser(codeMessageError, message.ToString());
                }
                finally
                {
                    stopwatch.Stop();
                    MakeLog.BuildLogUser(retorno, GetNumberOfMessage(message), stopwatch.Elapsed);
                }
            }
        }

        private NumberOfMessage GetNumberOfMessage(int message)
        {
            if (message.Equals(1))
                return NumberOfMessage.One;
            if (message.Equals(2))
                return NumberOfMessage.Two;
            if (message.Equals(3))
                return NumberOfMessage.Three;
            if (message.Equals(4))
                return NumberOfMessage.Four;
            else
                return NumberOfMessage.Five;
        }

    }
}
