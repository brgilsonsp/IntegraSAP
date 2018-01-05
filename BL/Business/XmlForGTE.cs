using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using BL.InnerException;
using BL.InnerUtil;

namespace BL.Business
{
    public class XmlForGTE<T>
    {
        /// <summary>
        /// Serializa uma string XML com os dados do objeto enviado pelo parâmetro. Se ocorrer algum erro ao desserializar
        /// o objeto retorna uma string vazia
        /// </summary>
        /// <param name="t">Objeto genérico</param>
        /// <returns>string com os dados no formato XML</returns>
        public string serializeXmlForGTE(T t)
        {
            string xml = "";
            try
            {
                if (t != null)
                {
                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                    XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                    xmlns.Add("", "");
                    StringBuilder stringXml = new StringBuilder();
                    using (StringWriter textWriter = new EncodingUTF8(stringXml))
                    {
                        xmlSerialize.Serialize(textWriter, t, xmlns);
                    }
                    xml = stringXml.ToString();
                }else
                    MakeLog.FactoryLogForError(MessagesOfReturn.ERROR_OBJECT_FOR_SERIALIZER);
            }
            catch (Exception ex)
            {
                MakeLog.FactoryLogForError(ex, MessagesOfReturn.ErrorSerializeConsulting(typeof(T).Name));
            }
            return xml;
        }

        private void Serializer_UnreferencedObject (object sender, UnreferencedObjectEventArgs e)
        {
            Console.WriteLine("UnreferencedObject:");
            Console.WriteLine("ID: " + e.UnreferencedId);
            Console.WriteLine("UnreferencedObject: " + e.UnreferencedObject);
        }
    }
}