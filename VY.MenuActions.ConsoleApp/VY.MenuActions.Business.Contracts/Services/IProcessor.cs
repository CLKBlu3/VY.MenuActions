using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Domain;

namespace VY.MenuActions.Business.Contracts.Services
{
    public interface IProcessor
    {
        Task Process(ArgContext context);
    }
}
