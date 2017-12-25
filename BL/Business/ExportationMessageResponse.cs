using System;
using BL.InnerUtil;

namespace BL.Business
{
    public class ExportationMessageResponse : OriginalText
    {
        private string _xml;
        private ConfigureService _configureService;
        private int _numberOfMessage;
        private string _embarque;

        public string ContentText { get { return this._xml; } }

        public string Message { get { return MessageDetailed(); } }

        public string PathSaveFileText { get { return PathCompleteOfFile(); } }

        public ExportationMessageResponse(String xml, string embarque, int numberOfmessage)
        {
            this._xml = xml;
            this._configureService = new ConfigureService();
            this._numberOfMessage = numberOfmessage;
            this._embarque = embarque;
        }

        public bool IsConditionsAcceptableForSaveText()
        {
            return (!String.IsNullOrEmpty(this._xml) && this._configureService != null && this._configureService.IsSaveXml);
        }

        private string PathCompleteOfFile()
        {
            if (this._configureService != null)
                return PathSaveFile.PathMessageResponseExportation(_configureService.RootLog, this._embarque, this._numberOfMessage);
            else
                return null;
        }

        private string MessageDetailed()
        {
            return String.Format("{0} - {1}", this._numberOfMessage, this._embarque, MessagesOfReturn.EXPORTATION_RESPONSE);
        }
    }
}
