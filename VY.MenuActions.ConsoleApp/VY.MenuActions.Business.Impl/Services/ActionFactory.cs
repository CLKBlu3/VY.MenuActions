using System;
using System.Collections.Generic;
using System.Linq;
using VY.MenuActions.Business.Contracts.Domain;
using VY.MenuActions.Business.Contracts.Services;

namespace VY.MenuActions.Business.Impl.Services
{
    public class ActionFactory : IActionFactory
    {
        private readonly IEnumerable<IAction> _actions;

        public ActionFactory(IEnumerable<IAction> _actions)
        {
            this._actions = _actions;
        }

        public IAction GetAction(ActionType actionType)
        {
            if(actionType == null) throw new ArgumentNullException(nameof(actionType));
            return _actions.FirstOrDefault(c => c.Source == actionType);
            //switch (actionType)
            //{
            //    case ActionType.Export:
            //        return _actions.FirstOrDefault(c => c.Source == ActionType.Export);
            //    case ActionType.Import:
            //        return _actions.FirstOrDefault(c => c.Source == ActionType.Import);
            //    default:
            //        throw new ArgumentException(actionType.ToString());
            //}
        }
    }
}
