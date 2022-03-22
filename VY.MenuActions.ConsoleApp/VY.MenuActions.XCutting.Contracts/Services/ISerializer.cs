namespace VY.MenuActions.XCutting.Contracts.Services
{
    public interface ISerializer
    {
        public SerializerType Source { get; }
        T Deserialize<T>(string input);

        string Serialize<T>(T entity);
    }
}
