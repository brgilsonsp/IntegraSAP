using System;
using BL.InnerUtil;
using BL.Infra;

namespace BL.Business
{
    public class ImportationMessageRequest : IOriginalText
    {
        private ConfigureService _configureService;
        private string _xml;
        private byte _numberOfMessage;
        private string _embarque;
        private PathSaveFile _pathSaveFile;

        public ImportationMessageRequest(String xml, string embarque, byte numberOfMessage)
        {
            this._xml = xml;
            _configureService = new ConfigureService();
            this._numberOfMessage = numberOfMessage;
            this._embarque = embarque;
            this._pathSaveFile = new PathSaveFile(_configureService.RootLog, embarque, numberOfMessage);
        }

        public string Message { get { return MessagesOfReturn.Message(this._numberOfMessage, Option.IMPORTACAO); } }

        public string ContentText { get { return _xml; } }

        public string PathFileSaveFileText { get { return _pathSaveFile.PathFileMessageRequestImportation; } }

        public string DirectoryFileSaveFileText { get { return _pathSaveFile.DirectoryFileMessageRequest; } }

        public bool IsConditionsAcceptableForSaveText { get { return _configureService.IsSaveXml; } }
        
    }
}
