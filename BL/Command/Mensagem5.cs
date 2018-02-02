using BL.Business;
using BL.DAO;
using BL.Infra;
using BL.InnerUtil;
using BL.ObjectMessages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Command
{
    public class Mensagem5 : IMessage
    {

        public string Execute()
        {
            string messageReturn = "";
            NumberOfMessage numberOfMessage = NumberOfMessage.Five;

            messageReturn = Exportation(numberOfMessage);

            messageReturn += MessagesOfReturn.NewLine;

            messageReturn += Importation(numberOfMessage);

            return messageReturn;
        }

        private string Exportation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.EXPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequest5(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage5>(objectsToRequest, contentForSave).Process();
        }

        private string Importation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.IMPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequest5(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage5>(objectsToRequest, contentForSave).Process();
        }
    }
}
