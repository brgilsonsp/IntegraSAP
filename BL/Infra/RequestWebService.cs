using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using BL.InnerUtil;
using BL.InnerException;

namespace BL.Infra
{
    /// <summary>
    /// Classe responsável por efetuar a troca de mensagens com o Web Service da E-IT.
    /// Será enviado uma string com o objeto serializado no formato XML e receberá
    /// também uma string XML.
    /// </summary>
    public class RequestWebService
    {
        /// <summary>
        /// Efetua a requisição ao WebService enviando o objeto informado no parâmetro
        /// </summary>
        /// <param name="xml">string de texto com o objeto serializado em XML</param>
        /// <param name="message">Mensagem que esta sendo executada no momento</param>
        /// <returns>Retorno do WebService</returns>
        /// <exception cref="ChangeXmlException">Lança a exceção do tipo ChangeXmlException com uma mensagem e internamente as exeções que ocorreram</exception>
        public static string doRequestWebService(string xml, string message)
        {
            try
            {
                return new RequestWebService().ExecuteRequest(xml, message);
            }
            catch (Exception ex)
            {
                throw new ChangeXmlException(MessagesOfReturn.ExceptionRequestWebService, ex);
            }
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
            ignoreCertificate();

            using (var ws = new WebServiceGTE.wbsedxSoapClient())
            {
                returnGTE = ws.funcsync(xml);
            }

            //Aguarda esse período a fim de definir um delay entre as mensagens
            TimeClosing.ThreadForCloseConnectionWebService();

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
