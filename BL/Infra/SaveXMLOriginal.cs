using System;
using System.IO;
using BL.InnerUtil;
using BL.Business;
using BL.InnerException;

namespace BL.Infra
{
    public class SaveXMLOriginal
    {
        /// <summary>
        /// Salva o arquivo XML do objeto xmlOriginal no diretóro do servidor
        /// </summary>
        /// <param name="xmlOriginal">Objeto que contém as propriedades do XML que será gravado</param>
        /// <exception cref="ChangeXmlException">Lança a exceção do tipo ChangeXmlException com uma mensagem e internamente as exeções que ocorreram</exception>
        public static void SaveXML(ContentText xmlOriginal)
        {
            //Verifica se o arquivo deve ser salva
            if (xmlOriginal.IsConditionsAcceptableForSaveText)
            {
                try
                {
                    RecordFile.CreateDirectorIfNotExisty(xmlOriginal.DirectoryFileSaveFileText);

                    RecordFile.SaveFile(xmlOriginal.PathFileSaveFileText, xmlOriginal.Content);
                    
                }
                catch (Exception ex)
                {
                    string msg = MessagesOfReturn.ExceptionSaveXml(xmlOriginal.PathFileSaveFileText);
                    throw new ChangeXmlException(msg, ex);
                }
            }
        }
    }
}
