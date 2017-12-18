using BL.ObjectMessages;
using System.Collections.Generic;

namespace BL.Business
{
    public class DatasSerializedForConsultingXml<T> : DatasSerializedForConsulting<T, string> where T : class
    {
        public IList<string> GetDatasSerialized(DatasOfRequest<T> t)
        {
            IList<T> objectsToSerialize = t.GetListObjectForRequest();
            IList<string> objctsSerielized = new List<string>();

            foreach (T eachObjectToSerialize in objectsToSerialize)
            {
                objctsSerielized.Add(new XmlForGTE<T>().serializeXmlForGTE(eachObjectToSerialize));
            }
            return objctsSerielized;
        }
    }
}
