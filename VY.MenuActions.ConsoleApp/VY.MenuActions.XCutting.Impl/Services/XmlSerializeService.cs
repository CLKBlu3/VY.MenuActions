using System.IO;
using System.Xml.Serialization;
using VY.MenuActions.XCutting.Contracts;
using VY.MenuActions.XCutting.Contracts.Services;

namespace VY.MenuActions.XCutting.Impl.Services
{
    public class XmlSerializeService : ISerializer
    {
        public SerializerType Source => SerializerType.Xml;
        public string Serialize<T>(T item)
        {
            StringWriter stringWriter = new();
            XmlSerializer serializer = new(typeof(T));
            serializer.Serialize(stringWriter, item);
            return stringWriter.ToString();
        }
        public T Deserialize<T>(string input)
        {
            StringReader stringReader = new(input);
            XmlSerializer serializer = new(typeof(T));
            var output = (T)serializer.Deserialize(stringReader);
            return output;
        }
    }
}
