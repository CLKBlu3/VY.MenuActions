using System.Collections.Generic;
using System.Threading.Tasks;
using VY.MenuActions.Dtos;
using VY.MenuActions.XCutting.Contracts;

namespace VY.MenuActions.Business.Contracts.Services
{
    public interface IImportService
    {
        public Task<OperationResult> ImportAsync(IEnumerable<MenuActionDto> menuActionDto);
    }
}
