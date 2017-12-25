using System;
using System.IO;
using System.Xml.Serialization;
using BL.InnerException;
using BL.InnerUtil;

namespace BL.Business
{
    public class ObjectForDB<T>
    {
        /// <summary>
        /// Desserializa a string enviado no parâmetro em um objeto T.
        /// </summary>
        /// <param name="xml">string com os dados XML</param>
        /// <returns>Um ojeto tipo T desserializado</returns>
        /// <exception cref="Exception">Lança a exceção se ocorrer algum erro ao desserializar a string Xml</exception>
        /// <exception cref="ConfigureXmlException">Lança a exceção se a string enviado no parâmetro for nula,
        /// vazia ou em branco.</exception>
        public T deserializeXmlForDB(string xml)
        {
            try
            {
                if (!string.IsNullOrEmpty(xml) || !string.IsNullOrWhiteSpace(xml))
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                    T objectRetun;
                    using (TextReader fileXml = new StringReader(xml))
                    {
                        objectRetun = (T)xmlSer.Deserialize(fileXml);
                    }
                    return objectRetun;
                }
                else
                    MakeLog.FactoryLogForError(MessagesOfReturn.ALERT_XML_FOR_DB_NULL);
            }
            catch (Exception ex)
            {
                throw new ConfigureXmlException(MessagesOfReturn.ErrorDeserializeResponse(typeof(T).Name), ex);
            }
            return default(T);
        }
    }
}
