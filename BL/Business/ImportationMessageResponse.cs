using System;
using Util.InnerUtil;

namespace BL.Business
{
    public class ImportationMessageResponse : OriginalText
    {
        private string _xml;
        private ConfigureService _configureService;
        private int _message;
        private string _embarque;

        public string ContentText { get { return this._xml; } }

        public string Message { get { return MessageDetailed(); } }

        public string PathSaveFileText { get { return PathCompleteOfFile(); } }

        public ImportationMessageResponse(String xml, string embarque, int numberOfmessage, ConfigureService configureService)
        {
            this._xml = xml;
            this._configureService = configureService;
            this._message = numberOfmessage;
            this._embarque = embarque;
        }

        public bool IsConditionsAcceptableForSaveText()
        {
            return (!String.IsNullOrEmpty(this._xml) && this._configureService != null && this._configureService.IsSaveXml);
        }

        private string PathCompleteOfFile()
        {
            if (this._configureService != null)
                return PathSaveFile.PathMessageResponseImportation(_configureService.RootLog, this._embarque, this._message);
            else
                return null;
        }

        private string MessageDetailed()
        {
            return String.Format("{0} - {1}", this._message, this._embarque, MessagesOfReturn.IMPORTATION_RESPONSE);
        }
    }
}
