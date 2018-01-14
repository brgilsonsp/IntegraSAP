using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using BL.InnerUtil;
using System.Diagnostics;
using BL.InnerException;

namespace BL.Business
{
    public class SerializeXml<T>
    {
        /// <summary>
        /// Serializa uma string XML com os dados do objeto enviado pelo parâmetro. Se ocorrer algum erro ao desserializar
        /// o objeto retorna uma string vazia
        /// </summary>
        /// <param name="t">Objeto genérico</param>
        /// <returns>string com os dados no formato XML</returns>
        /// <exception cref="ChangeXmlException">Lança a exceção do tipo ChangeXmlException com uma mensagem e internamente as exeções que ocorreram</exception>
        public string serializeXmlForGTE(T t)
        {
            try
            {
                XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add("", "");
                StringBuilder stringXml = new StringBuilder();
                using (StringWriter textWriter = new EncodingUTF8(stringXml))
                {
                    xmlSerialize.Serialize(textWriter, t, xmlns);
                }
                return stringXml.ToString();
            }
            catch (Exception ex)
            {
                throw new ChangeXmlException(MessagesOfReturn.ExceptionSerializeXml, ex);
            }
        }

        private void Serializer_UnreferencedObject (object sender, UnreferencedObjectEventArgs e)
        {
            Debug.WriteLine("UnreferencedObject:");
            Debug.WriteLine("ID: " + e.UnreferencedId);
            Debug.WriteLine("UnreferencedObject: " + e.UnreferencedObject);
        }
    }
}