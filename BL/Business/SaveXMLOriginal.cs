using System;
using System.IO;
using BL.InnerUtil;

namespace BL.Business
{
    public class SaveXMLOriginal
    {
        /// <summary>
        /// Salva o arquivo XML do objeto xmlOriginal no diretóro do servidor
        /// </summary>
        /// <param name="xmlOriginal">Objeto que contém as propriedades do XML que será gravado</param>
        public void SaveXML(OriginalText xmlOriginal)
        {
            //Verifica se o arquivo deve ser salva
            if (xmlOriginal.IsConditionsAcceptableForSaveText())
            {
                try
                {
                    using (var arq = File.AppendText(xmlOriginal.PathSaveFileText))
                    {
                        arq.WriteLine(xmlOriginal.ContentText);
                    }
                }
                catch (Exception ex) {
                    string msg = string.Format("{0}{1}", MessagesOfReturn.ERROR_SAVE_XML.Replace("?", xmlOriginal.PathSaveFileText), Environment.NewLine);
                    msg += string.Format("{0}{1}", ex.Message, Environment.NewLine);
                    MakeLog.MakeFileLogSuport(msg, xmlOriginal.Message, Option.FILE_LOG_SUPORT);
                }
            }
        }
    }
}
