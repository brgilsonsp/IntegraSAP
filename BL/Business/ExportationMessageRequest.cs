using System;
using BL.InnerUtil;

namespace BL.Business
{
    public class ExportationMessageRequest : OriginalText
    {
        private ConfigureService _configureService;
        private string _xml;
        private byte _numberOfMessage;
        private string _embarque;

        public ExportationMessageRequest(string xml, string embarque, byte numberOfMessage)
        {
            this._xml = xml;
            this._embarque = embarque;
            this._numberOfMessage = numberOfMessage;
            this._configureService = new ConfigureService();
        }
        public string ContentText { get { return this._xml; } }

        public string Message
        {
            get
            {
                return MessagesOfReturn.ProcessExportation(this._numberOfMessage);
            }
        }

        public string PathSaveFileText { get { return BasePath(); } }

        public bool IsConditionsAcceptableForSaveText()
        {
            return (!String.IsNullOrEmpty(this._xml) && _configureService != null && _configureService.IsSaveXml);
        }

        private string BasePath()
        {
            if (_configureService != null)
                return PathSaveFile.PathMessageRequestExportation(_configureService.RootLog, this._embarque, this._numberOfMessage);
            else
                return null;
        }
    }
}
