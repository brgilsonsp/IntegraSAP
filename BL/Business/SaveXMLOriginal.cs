using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.InnerUtil;

namespace BL.Business
{
    public class SaveXMLOriginal
    {
        private static string basePath = new ConfigureService().GetPathLog() + @"\Mensagem";
        private string pathMsg1Request = basePath + @"\Mensagem1\Request\";
        private string pathMsg1Response = basePath + @"\Mensagem1\Response\";
        private string pathMsg2Request = basePath + @"\Mensagem2\Request\";
        private string pathMsg2Response = basePath + @"\Mensagem2\Response\";
        private string pathMsg3Request = basePath + @"\Mensagem3\Request\";
        private string pathMsg3Response = basePath + @"\Mensagem3\Response\";
        private string pathMsg4Request = basePath + @"\Mensagem4\Request\";
        private string pathMsg4Response = basePath + @"\Mensagem4\Response\";
        private string pathMsg5Request = basePath + @"\Mensagem5\Request\";
        private string pathMsg5Response = basePath + @"\Mensagem5\Response\";


        /// <summary>
        /// Salva o XML no diretório
        /// </summary>
        /// <param name="message">byte</param>
        /// <param name="xml">string</param>
        /// <param name="embarque">string</param>
        /// <param name="request">bool</param>
        /// <param name="response">bool</param>
        public void SaveXML(byte message, string xml, string embarque, bool request, bool response)
        {
            //Se a flag estiver como true salva o arquivo, caso contrário não fará nada
            bool saveXML = new ConfigureService().GetSaveXML();
            if (saveXML)
            {
                try
                {
                    switch (message)
                    {
                        case Option.MENSAGEM1:
                            {
                                string pathMsg1 = Message1(embarque, request, response);
                                Save(xml, pathMsg1, Option.MENSAGEM1);
                                break;
                            }
                        case Option.MENSAGEM2:
                            {
                                string pathMsg2 = Message2(embarque, request, response);
                                Save(xml, pathMsg2, Option.MENSAGEM2);
                                break;
                            }
                        case Option.MENSAGEM3:
                            {
                                string pathMsg3 = Message3(embarque, request, response);
                                Save(xml, pathMsg3, Option.MENSAGEM3);
                                break;
                            }
                        case Option.MENSAGEM4:
                            {
                                string pathMsg4 = Message4(embarque, request, response);
                                Save(xml, pathMsg4, Option.MENSAGEM4);
                                break;
                            }
                        case Option.MENSAGEM5:
                            {
                                string pathMsg5 = Message5(embarque, request, response);
                                Save(xml, pathMsg5, Option.MENSAGEM5);
                                break;
                            }
                    }
                }
                catch (Exception) { }
            }
        }

        private string Message1(string embarque, bool request, bool response)
        {
            string path = "";
            if (request)
            {
                path = pathMsg1Request + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            if (response)
            {
                path = pathMsg1Response + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            return path;
        }

        private string Message2(string embarque, bool request, bool response)
        {
            string path = "";
            if (request)
            {
                path = pathMsg2Request + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            if (response)
            {
                path = pathMsg2Response + embarque + ConfigureDate.DateNameFile + ".xml";
                
            }
            return path;
        }

        private string Message3(string embarque, bool request, bool response)
        {
            string path =  "";
            if (request)
            {
                path = pathMsg3Request + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            if (response)
            {
                path = pathMsg3Response + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            return path;
        }

        private string Message4(string embarque, bool request, bool response)
        {
            string path = "";
            if (request)
            {
                path = pathMsg4Request + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            if (response)
            {
                path = pathMsg4Response + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            return path;
        }

        private string Message5(string embarque, bool request, bool response)
        {
            string path =  "";
            if (request)
            {
                path = pathMsg5Request + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            if (response)
            {
                path = pathMsg5Response + embarque + ConfigureDate.DateNameFile + ".xml";
            }
            return path;
        }

        /// <summary>
        /// Salva o XML no caminho informado
        /// </summary>
        /// <param name="xml">string</param>
        /// <param name="path">string</param>
        private void Save(string xml, string path, int message)
        {
            try
            {
                using (var arq = File.AppendText(path))
                {
                    arq.WriteLine(xml);
                }
            }catch(Exception ex)
            {
                string msg = string.Format("{0}{1}", MessagesOfReturn.ERROR_SAVE_XML.Replace("?", path), Environment.NewLine);
                msg += string.Format("{0}{1}", ex.Message, Environment.NewLine);
                MakeLog.MakeFileLogSuport(msg, message, Option.FILE_LOG_SUPORT);
            }
        }
    }
}
