using VY.MenuActions.Business.Contracts.Domain;

namespace VY.MenuActions.Business.Contracts.Services
{
    public interface IActionFactory
    {
        IAction GetAction(ActionType actionType);

    }
}
