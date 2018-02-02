using BL.Business;
using BL.InnerUtil;
using System.Collections.Generic;

namespace BL.Command
{
    public class Mensagem2 :  IMessage
    {
        public string Execute()
        {
            string messageReturn = "";
            NumberOfMessage numberOfMessage = NumberOfMessage.Two;

            messageReturn = Exportation(numberOfMessage);

            messageReturn += MessagesOfReturn.NewLine;

            messageReturn += Importation(numberOfMessage);

            return messageReturn;
        }

        private string Exportation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.EXPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequestMessage2(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage2Exportation>(objectsToRequest, contentForSave).Process();
        }

        private string Importation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.IMPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequestMessage2(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage2Importation>(objectsToRequest, contentForSave).Process();
        }
    }
}