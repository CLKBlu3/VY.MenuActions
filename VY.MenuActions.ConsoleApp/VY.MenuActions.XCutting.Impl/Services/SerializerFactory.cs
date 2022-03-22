using System;
using System.Collections.Generic;
using System.Linq;
using VY.MenuActions.XCutting.Contracts;
using VY.MenuActions.XCutting.Contracts.Services;

namespace VY.MenuActions.XCutting.Impl.Services
{
    public class SerializerFactory : ISerializerFactory
    {
        private readonly IEnumerable<ISerializer> _serializers;

        public SerializerFactory(IEnumerable<ISerializer> serializers)
        {
            _serializers = serializers;
        }

        public ISerializer GetSerializer(SerializerType serializerType)
        {
            if (serializerType == null) throw new ArgumentNullException(nameof(serializerType));
            return _serializers.FirstOrDefault(c => c.Source == serializerType);
            //switch (serializerType)
            //{
            //    case SerializerType.Xml:
            //        return _serializers.FirstOrDefault(c => c.Source == SerializerType.Xml);
            //    case SerializerType.Json:
            //        return _serializers.FirstOrDefault(c => c.Source == SerializerType.Json);
            //    default:
            //        throw new ArgumentException(serializerType.ToString());
            //}
        }
    }
}
