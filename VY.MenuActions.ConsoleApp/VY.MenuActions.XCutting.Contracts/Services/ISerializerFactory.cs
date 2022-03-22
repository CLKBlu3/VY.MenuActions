namespace VY.MenuActions.XCutting.Contracts.Services
{
    public interface ISerializerFactory
    {
        ISerializer GetSerializer(SerializerType serializerType);
    }
}
