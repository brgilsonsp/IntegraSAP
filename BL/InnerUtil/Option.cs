using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InnerUtil
{
    public static class Option
    {
        public const Byte MENSAGEM1 = 1;
        public const Byte MENSAGEM2 = 2;
        public const Byte MENSAGEM3 = 3;
        public const Byte MENSAGEM4 = 4;
        public const Byte MENSAGEM5 = 5;

        public const string EXPORTACAO = "EXPORTACAO";
        public const string IMPORTACAO = "IMPORTACAO";

        public const int ID_EMPTY = -1;

        public const string PCTYP_AD = "AD";
        public const string PCTYP_PC = "PC";

        public const string PATH_WEB_SERVICE = "PathWebService";
        public const string PATH_LOG = "PathLog";
        public const string DELAY_PROCCESS = "DelayProcess";
        public const string SAVE_XML = "SaveXML";

        public const string STANDAR_PATHWEBSERVICE = "https://46.165.168.135/edxqas/wbsedx.asmx";

        public const int STANDARD_DELAYPROCCESS = 15;


        public const string FILE_LOG_SUPORT = @"\SuportLogChangeXMLGTE.log";
        public const string FILE_LOG_USER = @"\ChangeXMLGTE.log";
        public const string FILE_LOG_ERROR_ACCESS = @"D:\ErrorTrocaXML.txt";
    }
}
