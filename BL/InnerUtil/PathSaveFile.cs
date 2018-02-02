namespace BL.InnerUtil
{
    public class PathSaveFile
    {
        private string _rootFolder;
        private string _embarque;
        private byte _numberOfMessage;
        private string _kindOfMessage;
        private string _lastFolder;

        public PathSaveFile(string rootFolder, string embarque, NumberOfMessage numberOfMessage, string kindOfMessage, TypeContentText typeContent)
        {
            _rootFolder = rootFolder;
            _embarque = embarque;
            _numberOfMessage = (byte)numberOfMessage;
            _kindOfMessage = ConfigureString.RemoveAccents(kindOfMessage);
            
            if(typeContent == TypeContentText.RESPONSE)
                _lastFolder = "Response";
            else
                _lastFolder = "Request";
        }
        
        public string PathFileMessage { get { return $"{DirectoryFileMessage}\\{_kindOfMessage}_{_embarque}_{ConfigureDate.DateNameFile}.xml"; } }
        
        public string DirectoryFileMessage { get { return $"{_rootFolder}\\Mensagem\\Mensagem{_numberOfMessage}\\{_lastFolder}"; }}


    }
}
