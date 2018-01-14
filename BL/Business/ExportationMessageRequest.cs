using System;
using BL.InnerUtil;
using BL.Infra;

namespace BL.Business
{
    public class ExportationMessageRequest : IOriginalText
    {
        private ConfigureService _configureService;
        private string _xml;
        private byte _numberOfMessage;
        private string _embarque;
        private PathSaveFile _pathSaveFile;

        public ExportationMessageRequest(string xml, string embarque, byte numberOfMessage)
        {
            this._xml = xml;
            this._embarque = embarque;
            this._numberOfMessage = numberOfMessage;
            this._configureService = new ConfigureService();
            this._pathSaveFile = new PathSaveFile(_configureService.RootLog, embarque, numberOfMessage);
        }
        public string ContentText { get { return this._xml; } }

        public string Message { get { return MessagesOfReturn.Message(this._numberOfMessage, Option.EXPORTACAO); } }

        public string PathFileSaveFileText { get { return _pathSaveFile.PathFileMessageRequestExportation; } }

        public bool IsConditionsAcceptableForSaveText { get { return _configureService.IsSaveXml; } }

        public string DirectoryFileSaveFileText { get { return _pathSaveFile.DirectoryFileMessageRequest; } }
    }
}
