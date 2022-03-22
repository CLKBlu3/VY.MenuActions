using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Domain;
using VY.MenuActions.Business.Contracts.Services;

namespace VY.MenuActions.Business.Impl.Services
{
    public class MenuActionsProcessor : IProcessor
    {
        private readonly IActionFactory _actionFactory;

        public MenuActionsProcessor(IActionFactory actionFactory)
        {
            _actionFactory = actionFactory;
        }

        public async Task Process(ArgContext context)
        {
            var _action = _actionFactory.GetAction(context.Action);
            await _action.RunAction(context);
        }
    }
}
