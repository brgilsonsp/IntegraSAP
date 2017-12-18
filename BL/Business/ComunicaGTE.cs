using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using BL.InnerException;
using BL.InnerUtil;
using System.Threading;
using System.ServiceModel;

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
        /// Efetua a solicitação ao Web Service GTE. Enviado uma string com um objeto
        /// serializado no formato XML e o retorno também será uma string no formato XML.
        /// </summary>
        /// <param name="xml">string de texto com o objeto serializado em XML</param>
        /// <returns>string xml, retorno do Web Service GTE</returns>
        /// <exception cref="ComunicateException">Lança a exceção se não conseguir acesso ao Web Service GTE ou
        /// se a string enviado no parâmetro for nulo ou em branco.</exception>
        public string doRequestGTE(string xml)
        {
            try
            {
                if (!string.IsNullOrEmpty(xml) || !string.IsNullOrWhiteSpace(xml))
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
                }else
                {
                    string msg = string.Format("{0} {1}", MessagesOfReturn.ALERT_STRING_FOR_GTE_NULL, Environment.NewLine);
                    throw new ComunicateException(msg);
                }
            }catch(Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_COMUNICATE_GTE, Environment.NewLine);
                throw new ComunicateException(msg, ex);
            }
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
