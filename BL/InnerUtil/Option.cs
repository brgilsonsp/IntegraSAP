using System;

namespace BL.InnerUtil
{
    public static class Option
    {
        private static string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public const Byte MENSAGEM1 = 1;
        public const Byte MENSAGEM2 = 2;
        public const Byte MENSAGEM3 = 3;
        public const Byte MENSAGEM4 = 4;
        public const Byte MENSAGEM5 = 5;

        public const int STANDARD_DELAYPROCCESS = 15;

        public const string EXPORTACAO = "Exportação";
        public const string IMPORTACAO = "Importação";
        
        public const string PATH_WEB_SERVICE = "PathWebService";
        public const string PATH_LOG = "PathLog";
        public const string DELAY_PROCCESS = "DelayProcess";
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
