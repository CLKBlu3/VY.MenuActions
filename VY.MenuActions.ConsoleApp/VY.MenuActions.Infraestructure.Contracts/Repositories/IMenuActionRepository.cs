using System.Collections.Generic;
using VY.MenuActions.Infraestructure.Contracts.Entities;

namespace VY.MenuActions.Infraestructure.Contracts.Repositories
{
    public interface IMenuActionRepository : IRepository<IEnumerable<MenuAction>>
    {
    }
}
