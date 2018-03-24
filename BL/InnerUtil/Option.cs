using System;

namespace BL.InnerUtil
{
    public static class Option
    {
        private static string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Constante que informa qual número da mensagem que se refere, nesse caso a Mensagem 1
        /// </summary>
        public const Byte MENSAGEM1 = 1;
        /// <summary>
        /// Constante que informa qual número da mensagem que se refere, nesse caso a Mensagem 2
        /// </summary>
        public const Byte MENSAGEM2 = 2;
        /// <summary>
        /// Constante que informa qual número da mensagem que se refere, nesse caso a Mensagem 3
        /// </summary>
        public const Byte MENSAGEM3 = 3;
        /// <summary>
        /// Constante que informa qual número da mensagem que se refere, nesse caso a Mensagem 4
        /// </summary>
        public const Byte MENSAGEM4 = 4;
        /// <summary>
        /// Constante que informa qual número da mensagem que se refere, nesse caso a Mensagem 5
        /// </summary>
        public const Byte MENSAGEM5 = 5;

        /// <summary>
        /// Uma constante com o valor padrão do delay que o serviço irá aguardar para reiniciar a troca de mensagem, nesse caso 15
        /// </summary>
        public const int STANDARD_DELAYPROCCESS = 15;

        /// <summary>
        /// Constante com o valor de qual tipo de processo, nesse caso processo de Exportação
        /// </summary>
        public const string EXPORTACAO = "Exportação";
        /// <summary>
        /// Constante com o valor de qual tipo de processo, nesse caso processo de Importação
        /// </summary>
        public const string IMPORTACAO = "Importação";

        /// <summary>
        /// Constante com o valor da chave PathLog do arquivo app.config
        /// </summary>
        public const string PATH_LOG = "PathLog";
        /// <summary>
        /// Constante com o valor da chave DelayProcess do arquivo app.config
        /// </summary>
        public const string DELAY_PROCCESS = "DelayProcess";
        /// <summary>
        /// Constante com o valor da chave SaveXML do arquivo app.config
        /// </summary>
        public const string SAVE_XML = "SaveXML";
        
        /// <summary>
        /// Retorna o caminho padrão do WebService
        /// </summary>
        public static string StandarPathWebService { get { return "https://46.165.168.135/edxqas/wbsedx.asmx"; } }
        
        /// <summary>
        /// Retorna o nome do log para o suporte, log que contém o detalha das exceções
        /// </summary>
        public static string NameFileLogSuport { get { return @"\SuportLogChangeXMLGTE.log"; } }

        /// <summary>
        /// Retorna o nome do log do usuário
        /// </summary>
        public static string NameFileLogUser { get { return @"\ChangeXMLGTE.log"; } }

        /// <summary>
        /// Retorna o caminho completo para salvar o log de error de acesso. O caminho será o documents do usuário
        /// </summary>
        public static string PathFileLogError { get { return $"{_myDocuments}\\ErrorTrocaXML.txt"; } }
    }
}
