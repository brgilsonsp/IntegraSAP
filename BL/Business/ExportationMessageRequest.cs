using System;
using BL.InnerUtil;

namespace BL.Business
{
    public class ExportationMessageRequest : OriginalText
    {
        private ConfigureService _configureService;
        private string _xml;
        private int _numberOfMessage;
        private string _embarque;

        public ExportationMessageRequest(string xml, string embarque, int numberOfMessage, ConfigureService configureService)
        {
            this._xml = xml;
            this._embarque = embarque;
            this._numberOfMessage = numberOfMessage;
            this._configureService = configureService;
        }
        public string ContentText { get { return this._xml; } }

        public string Message { get { return MessageDetailed(); } }

        public string PathSaveFileText { get { return BasePath(); } }

        public bool IsConditionsAcceptableForSaveText()
        {
            return (!String.IsNullOrEmpty(this._xml) && _configureService != null && _configureService.IsSaveXml);
        }

        private string MessageDetailed()
        {
            return String.Format("{0} - {1}", _numberOfMessage, _embarque, MessagesOfReturn.EXPORTATION_REQUEST);
        }

        private string BasePath()
        {
            if (_configureService != null)
                return PathSaveFile.PathMessageRequestExportation(_configureService.RootLog, _embarque, _numberOfMessage);
            else
                return null;
        }
    }
}
