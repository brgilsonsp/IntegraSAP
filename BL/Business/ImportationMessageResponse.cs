using System;
using BL.InnerUtil;
using BL.Infra;

namespace BL.Business
{
    public class ImportationMessageResponse : IOriginalText
    {
        private string _xml;
        private ConfigureService _configureService;
        private byte _numberOfMessage;
        private string _embarque;
        private PathSaveFile _pathSaveFile;

        public ImportationMessageResponse(String xml, string embarque, byte numberOfmessage)
        {
            this._xml = xml;
            this._configureService = new ConfigureService();
            this._numberOfMessage = numberOfmessage;
            this._embarque = embarque;
            this._pathSaveFile = new PathSaveFile(_configureService.RootLog, embarque, numberOfmessage);
        }

        public string ContentText { get { return this._xml; } }

        public string Message { get { return MessagesOfReturn.Message(this._numberOfMessage, Option.IMPORTACAO); } }

        public string PathFileSaveFileText { get { return _pathSaveFile.PathFileMessageResponseImportation; } }

        public string DirectoryFileSaveFileText { get { return _pathSaveFile.DirectoryFileMessageResponse; } }

        public bool IsConditionsAcceptableForSaveText { get { return this._configureService.IsSaveXml; } }
        
    }
}
