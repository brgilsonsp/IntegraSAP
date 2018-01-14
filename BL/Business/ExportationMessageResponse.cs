using System;
using BL.InnerUtil;
using BL.Infra;

namespace BL.Business
{
    public class ExportationMessageResponse : IOriginalText
    {
        private string _xml;
        private ConfigureService _configureService;
        private byte _numberOfMessage;
        private string _embarque;
        private PathSaveFile _pathSaveFile;

        public ExportationMessageResponse(String xml, string embarque, byte numberOfmessage)
        {
            this._xml = xml;
            this._configureService = new ConfigureService();
            this._numberOfMessage = numberOfmessage;
            this._embarque = embarque;
            this._pathSaveFile = new PathSaveFile(_configureService.RootLog, embarque, numberOfmessage);
        }

        public string ContentText { get { return this._xml; } }

        public string Message { get { return MessagesOfReturn.Message(this._numberOfMessage, Option.EXPORTACAO); } } 

        public string PathFileSaveFileText { get { return _pathSaveFile.PathFileMessageResponseExportation; } }

        public string DirectoryFileSaveFileText { get { return _pathSaveFile.DirectoryFileMessageResponse; } }
               
        public bool IsConditionsAcceptableForSaveText { get { return this._configureService.IsSaveXml; } }

        private string PathCompleteOfFile()
        {
            if (this._configureService != null)
                return new PathSaveFile(_configureService.RootLog, this._embarque, this._numberOfMessage).PathFileMessageResponseExportation;
            else
                return null;
        }
    }
}
