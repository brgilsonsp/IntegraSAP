using System;
using System.IO;
using System.Xml.Serialization;
using BL.InnerException;
using BL.InnerUtil;

namespace BL.Business
{
    public class DeserializeXml<T>
    {
        /// <summary>
        /// Desserializa a string enviado no parâmetro em um objeto T.
        /// </summary>
        /// <param name="xml">string com os dados XML</param>
        /// <returns>Um ojeto tipo T desserializado</returns>
        /// <exception cref="ChangeXmlException">Lança a exceção do tipo ChangeXmlException com uma mensagem e internamente as exeções que ocorreram</exception>
        public T deserializeXmlForDB(string xml)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                T objectRetun;
                using (TextReader fileXml = new StringReader(xml))
                {
                    objectRetun = (T)xmlSer.Deserialize(fileXml);
                }
                return objectRetun;
            }
            catch (Exception ex)
            {
                throw new ChangeXmlException(MessagesOfReturn.ExceptionDeserializeXml, ex);
            }
        }
    }
}
