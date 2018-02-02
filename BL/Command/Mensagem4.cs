using BL.Business;
using BL.InnerUtil;
using System.Collections.Generic;

namespace BL.Command
{
    public class Mensagem4 : IMessage
    {
        public string Execute()
        {
            string messageReturn = "";
            NumberOfMessage numberOfMessage = NumberOfMessage.Four;

            messageReturn = Exportation(numberOfMessage);

            messageReturn += MessagesOfReturn.NewLine;

            messageReturn += Importation(numberOfMessage);

            return messageReturn;
        }

        private string Exportation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.EXPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequest4(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage4>(objectsToRequest, contentForSave).Process();
        }

        private string Importation(NumberOfMessage numberOfMessage)
        {
            string kindMessage = Option.IMPORTACAO;
            string message = MessagesOfReturn.Message(numberOfMessage, kindMessage);
            IDictionary<string, string> objectsToRequest = new DatasToRequest4(kindMessage).GetDatasToRequest();
            ContentText contentForSave = new ContentText(numberOfMessage, kindMessage);

            return new ProcessMessage<ResponseMessage4>(objectsToRequest, contentForSave).Process();
        }
    }
}
