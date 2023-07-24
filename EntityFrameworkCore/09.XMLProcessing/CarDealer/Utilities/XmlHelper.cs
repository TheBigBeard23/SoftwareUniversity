namespace CarDealer.Utilities
{

    using System.Xml.Serialization;

    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), xmlRoot);

            StringReader sr = new StringReader(inputXml);

            
            T deserializedObject =
                (T)xmlSerializer.Deserialize(sr);

            return deserializedObject;
        }

        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T[]), xmlRoot);

            StringReader sr = new StringReader(inputXml);


            T[] deserializedObject =
                (T[])xmlSerializer.Deserialize(sr);

            return deserializedObject;
        }
    }
}
