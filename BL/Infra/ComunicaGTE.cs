using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using BL.InnerUtil;

namespace BL.Business
{
    /// <summary>
    /// Classe responsável por efetuar a troca de mensagens com o Web Service da GTE.
    /// Será enviado uma string com o objeto serializado no formato XML e receberá
    /// também uma string XML.
    /// </summary>
    public class ComunicaGTE
    {
        /// <summary>
        /// Efetua a requisição ao WebService enviando o objeto informado no parâmetro
        /// </summary>
        /// <param name="xml">string de texto com o objeto serializado em XML</param>
        /// <param name="message">Mensagem que esta sendo executada no momento</param>
        /// <returns>Retorno do WebService</returns>
        public static string doRequestWebService(string xml, string message)
        {
            return new ComunicaGTE().ExecuteRequest(xml, message);
        }

        /// <summary>
        /// Executa a troca de informação com o WebService
        /// </summary>
        /// <param name="xml">string de texto com o objeto serializado em XML</param>
        /// <param name="message">Mensagem que esta sendo executada no momento</param>
        /// <returns>Retorno do Webservice</returns>
        private string ExecuteRequest(string xml, string message)
        {
            string returnGTE = "";
            try
            {                
                ignoreCertificate();
                using (var ws = new WebServiceGTE.wbsedxSoapClient())
                {
                    returnGTE = ws.funcsync(xml);
                }
                //Aguarda esse período a fim de definir um delay entre as mensagens
                TimeClosing.ThreadForCloseConnectionWebService();
            }
            catch (Exception ex)
            {
                MakeLog.MakeFileException(message, ex);
            }
            return returnGTE;
        }

        /// <summary>
        /// Ignora o certificado SSL do Web Service
        /// </summary>
        private static void ignoreCertificate()
        {
            ServicePointManager.ServerCertificateValidationCallback += acceptCertificate;
        }

        /// <summary>
        /// Delegado do System.Net.Security.RemoteCertificateValidationCallback
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="certificate"> X509Certificate </param>
        /// <param name="chain"> X509Chain </param>
        /// <param name="error"> SsPolicyErrors </param>
        /// <returns> Booleano, nesse caso retornará true validando o certificado </returns>
        private static bool acceptCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
    }
}
