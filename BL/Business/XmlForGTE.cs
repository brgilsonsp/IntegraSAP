using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Util.InnerException;
using Util.InnerUtil;

namespace BL.Business
{
    public class XmlForGTE<T>
    {
        /// <summary>
        /// Serializa uma string XML com os dados do objeto enviado pelo parâmetro
        /// </summary>
        /// <param name="t">Objeto do tipo T</param>
        /// <returns>string com os dados no formato XML</returns>
        /// <exception cref="ConfigureXmlException">Lança a exception se ocorrer algum erro na serialização
        /// ou se o objeto enviado no parâmetro for nullo.</exception>
        public string serializeXmlForGTE(T t)
        {
            try
            {
                if (t != null)
                {
                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));
                    XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                    xmlns.Add("", "");
                    StringBuilder stringXml = new StringBuilder();
                    //using (TextWriter textWriter = new StringWriter(stringXml))
                    using (StringWriter textWriter = new EncodingUTF8(stringXml))
                    {
                        xmlSerialize.Serialize(textWriter, t, xmlns);
                    }
                    return stringXml.ToString();
                }else
                {
                    string message = string.Format("{0} {1}", MessagesOfReturn.ERROR_OBJECT_FOR_SERIALIZER_NULL,
                        Environment.NewLine);
                    throw new ConfigureXmlException(message);
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0} {1}", MessagesOfReturn.ERROR_SERIALIZA_CONSULTA.Replace("?", typeof(T).Name),
                    Environment.NewLine);
                throw new ConfigureXmlException(msg, ex);
            }
        }
    }
}