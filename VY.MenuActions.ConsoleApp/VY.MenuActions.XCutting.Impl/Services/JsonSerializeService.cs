using Newtonsoft.Json;
using VY.MenuActions.XCutting.Contracts;
using VY.MenuActions.XCutting.Contracts.Services;

namespace VY.MenuActions.XCutting.Impl.Services
{
    public class JsonSerializeService : ISerializer
    {
        public SerializerType Source => SerializerType.Json;
        public T Deserialize<T>(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                throw;
            }

        }

        public string Serialize<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
