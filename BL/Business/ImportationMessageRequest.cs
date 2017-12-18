using System;
using BL.InnerUtil;

namespace BL.Business
{
    public class ImportationMessageRequest : OriginalText
    {
        private ConfigureService _configureService;
        private string _xml;
        private int _numberOfMessage;
        private string _embarque;

        public ImportationMessageRequest(String xml, string embarque, int numberOfMessage, ConfigureService configureService)
        {
            this._xml = xml;
            _configureService = configureService;
            this._numberOfMessage = numberOfMessage;
            this._embarque = embarque;
        }

        public string Message { get { return MessageDetailed(); } }

        public string ContentText { get { return _xml; } }

        public string PathSaveFileText { get { return BasePath(); } }

        public bool IsConditionsAcceptableForSaveText()
        {
            return (!String.IsNullOrEmpty(this._xml) && _configureService != null && _configureService.IsSaveXml);
        }

        private string BasePath()
        {
            if (_configureService != null)
                return PathSaveFile.PathMessageRequestImportation(_configureService.RootLog, _embarque, _numberOfMessage);
            else
                return null;
        }

        private string MessageDetailed()
        {
            return String.Format("{0} - {1}", _numberOfMessage, _embarque, MessagesOfReturn.IMPORTATION_REQUEST);
        }
    }
}
