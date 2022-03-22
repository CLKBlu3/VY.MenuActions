using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Domain;
using VY.MenuActions.XCutting.Contracts;

namespace VY.MenuActions.Business.Contracts.Services
{
    public interface IAction
    {
        public ActionType Source { get; }
        Task<OperationResult> RunAction(ArgContext context);
    }
}
