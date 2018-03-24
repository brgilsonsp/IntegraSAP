using BL.Infra;

namespace BL.InnerUtil
{
    public class ContentText
    {
        private ConfigureService _configureService;
        private string _xml;
        private NumberOfMessage _numberOfMessage;
        private PathSaveFile _pathSaveFile;
        private string _kindOfMessage;

        public ContentText(NumberOfMessage numberOfMessage, string kind)
        {
            _numberOfMessage = numberOfMessage;
            _kindOfMessage = kind;
            _configureService = new ConfigureService();
        }

        /// <summary>
        /// Altera os valores informado nos parâmetros do objeto atual. A alteração desses valores irão alterar os seguintes campos:
        /// * Content
        /// * PathFileSaveFileText
        /// * DirectoryFileSaveFileText
        /// </summary>
        /// <param name="content">String com o conteúdo que será salvo, o XML</param>
        /// <param name="fileName">Nome do arquivo que será salvo o XML</param>
        /// <param name="typeContent">Enum que informa qual o tipo da transação, Request/Response </param>
        /// <returns></returns>
        public ContentText ProvideContent(string content, string fileName, TypeContentText typeContent)
        {
            _xml = content;           
            _pathSaveFile = new PathSaveFile(_configureService.RootLog, fileName, _numberOfMessage, _kindOfMessage, typeContent);

            return this;
        }

        /// <summary>
        /// Retorna o conteúdo que será gravado em disco
        /// </summary>
        public string Content { get { return this._xml; } }

        /// <summary>
        /// Retorna o detalhe da Mensagem que se refere
        /// </summary>
        public string Message { get { return MessagesOfReturn.Message(_numberOfMessage, this._kindOfMessage); } }

        /// <summary>
        /// Retorna true se o usuário solicitou a gravação dos XML gerados
        /// </summary>
        public bool IsConditionsAcceptableForSaveText{ get { return _configureService.IsSaveXml; } }

        /// <summary>
        /// Retorna o caminho completo que será gravado o Conteúdo (caminho e nome do arquivo)
        /// </summary>
        public string PathFileSaveFileText { get { return _pathSaveFile.PathFileMessage; } }

        /// <summary>
        /// Retorna o diretório que será gravado o arquivo
        /// </summary>
        public string DirectoryFileSaveFileText { get { return _pathSaveFile.DirectoryFileMessage; } }

        /// <summary>
        /// Retorna o número da Mensagem que se refere (1, 2, 3, 4 ou 5)
        /// </summary>
        public NumberOfMessage NumberOfMessage { get { return _numberOfMessage; } }

        /// <summary>
        /// Retorna qual o tipo da Mensagem que se refere (Importação ou Exportação)
        /// </summary>
        public string KindOfMessage { get { return _kindOfMessage; } }

    }
    
}
