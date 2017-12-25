using BL.Command;
using System;
using BL.InnerException;
using System.IO;
using BL.Business;
using BL.ObjectMessages;
using System.Collections.Generic;
using BL.InnerUtil;
using BL.DAO;

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
                try
                {
                    //Recarrega o contexto
                    ChangeXMLContext.ReloadContext();

                    //Define qual Mensagem instanciar
                    string objeto = "BL.Command.Mensagem" + message;

                    //Instancia a Mensagem
                    var classe = Activator.CreateInstance(null, objeto);
                    Mensagem mensagem = (Mensagem)classe.Unwrap();

                    //Efetua a troca da Mensagem com o Web Service do GTE
                    retorno += mensagem.SwapXmlWithGTE();
                    MakeLog.MakeFileLogUser(retorno, message.ToString(), Option.FILE_LOG_USER);
                }
                catch (BaseInnerException iE)
                {
                    try
                    {
                        //Escreve o arquivo de log se lançar um BaseInnerException
                        MakeLog.MakeFileBaseException(message, iE);
                    }
                    catch (Exception ex)
                    {
                        //Se não conseguir criar o arquivo de log, cria um log no c:\ informando
                        //a mensagem da excetpion que foi lançada
                        MakeLog.MakeFileExceptionLog(MessagesOfReturn.ERROR_CREATE_LOG_USER, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        //Escreve o arquivo de log se lançar um Exception
                        MakeLog.MakeFileException(message.ToString(), ex);
                    }
                    catch (Exception ex1)
                    {
                        //Se não conseguir criar o arquivo de log, cria um log no c:\ informando
                        //a mensagem da excetpion que foi lançada
                        MakeLog.MakeFileExceptionLog(MessagesOfReturn.ERRORCREATELOGSUPORT, ex1.Message);
                    }
                }
            }
        }

    }
}
