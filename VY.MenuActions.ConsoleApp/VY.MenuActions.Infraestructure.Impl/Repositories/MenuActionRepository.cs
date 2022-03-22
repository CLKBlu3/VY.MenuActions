using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VY.MenuActions.Infraestructure.Contracts.Entities;
using VY.MenuActions.Infraestructure.Contracts.Repositories;
using VY.MenuActions.Infraestructure.Impl.Context;

namespace VY.MenuActions.Infraestructure.Impl.Repositories
{
    public class MenuActionRepository : IMenuActionRepository
    {
        private readonly MenuDbContext _dbContext;
        private readonly DbSet<MenuAction> _dbSet;

        public MenuActionRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<MenuAction>();
        }

        public async Task<IEnumerable<MenuAction>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities.Where(e => e.ReportsTo == null).ToList();
        }

        public async Task SaveAsync(IEnumerable<MenuAction> menuActions)
        {
            var entities = await _dbSet.Where(e => e.ReportsTo == null).ToListAsync();
            _dbSet.RemoveRange(entities);

            await _dbContext.AddRangeAsync(menuActions);
            await _dbContext.SaveChangesAsync();
        }
    }
}
