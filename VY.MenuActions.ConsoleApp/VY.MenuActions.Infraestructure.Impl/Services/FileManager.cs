using System.IO;
using System.Threading.Tasks;
using VY.MenuActions.Infraestructure.Contracts.Services;

namespace VY.MenuActions.Infraestructure.Impl.Services
{
    public class FileManager : IDataManager
    {
        public async Task<string> Read(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }

        public async Task Write(string filePath, string content)
        {
            await File.WriteAllTextAsync(filePath, content);
        }
    }
}
