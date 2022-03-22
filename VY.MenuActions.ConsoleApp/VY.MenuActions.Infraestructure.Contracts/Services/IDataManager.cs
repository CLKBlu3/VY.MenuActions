using System.Threading.Tasks;

namespace VY.MenuActions.Infraestructure.Contracts.Services
{
    public interface IDataManager
    {
        Task<string> Read(string filePath);
        Task Write(string filePath, string content);
    }
}
