using BL.Business;
using BL.InnerUtil;
using System;
using System.Collections.Generic;

namespace BL.Command
{
    public class Mensagem1 : IMessage
    {
        public string Execute()
        {
            string messageReturn = "";
            messageReturn = Exportation(NumberOfMessage.One);

            messageReturn += MessagesOfReturn.NewLine;
            
            messageReturn += Importation(NumberOfMessage.One);

            return messageReturn;
        }

        private string Exportation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.EXPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequestMessage1(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage1>(objectsToRequest, contentForSave).Process();
        }

        private string Importation(NumberOfMessage numberOfMessage)
        {
            string kindOfMessage = Option.IMPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindOfMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequestMessage1(kindOfMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindOfMessage);

            return new ProcessMessage<ResponseMessage1>(objectsToRequest,  contentForSave).Process();
        }
    }
}
