using System.Collections.Generic;

namespace BL.Business
{
    public class DatasSerializedForConsultingXml<T> : DatasSerializedForConsulting<T> where T : class
    {
        public IList<string> GetDatasSerialized(IList<T> listObjectsToSerialization)
        {
            IList<string> datasSerialized = new List<string>();

            foreach (T t in listObjectsToSerialization)
                datasSerialized.Add(new XmlForGTE<T>().serializeXmlForGTE(t));

            return datasSerialized;
        }
    }
}
