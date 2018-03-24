namespace BL.InnerUtil
{
    public class PathSaveFile
    {
        private string _rootFolder;
        private string _embarque;
        private byte _numberOfMessage;
        private string _kindOfMessage;
        private string _lastFolder;

        /// <summary>
        /// Cria um objeto que manterá todas as informações de infraestrura para salvar os arquivos em disco
        /// </summary>
        /// <param name="rootFolder">String com o caminho do diretório que manterá todos arquivos de log</param>
        /// <param name="embarque">String com o valor do SBELN</param>
        /// <param name="numberOfMessage">Enum com o número da mensagem</param>
        /// <param name="kindOfMessage">String com o tipo da mensagem. Utilize as constantes Exportacao/Importação disponibilizados na classe estática Option</param>
        /// <param name="typeContent">Enum com o tipo de processo, requisição ou resposta</param>
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
        
        /// <summary>
        /// Disponibiliza o caminho completo do arquivo xml da requição/resposta
        /// </summary>
        public string PathFileMessage { get { return $"{DirectoryFileMessage}\\{_kindOfMessage}_{_embarque}_{ConfigureDate.DateNameFile}.xml"; } }
        
        /// <summary>
        /// Disponibiliza o diretório que será salvo os arquivos xml da requição/resposta
        /// </summary>
        public string DirectoryFileMessage { get { return $"{_rootFolder}\\Mensagem\\Mensagem{_numberOfMessage}\\{_lastFolder}"; }}


    }
}
