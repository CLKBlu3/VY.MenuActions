using System.Collections.Generic;
using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Services;
using VY.MenuActions.Dtos;
using VY.MenuActions.XCutting.Contracts;

namespace VY.MenuActions.Business.Impl.Services
{
    public class MenuActionService : IMenuActionService
    {
        private readonly IExportService _exportService;
        private readonly IImportService _importService;

        public MenuActionService(IExportService exportService, IImportService importService)
        {
            _exportService = exportService;
            _importService = importService;
        }

        public async Task<OperationResult<IEnumerable<MenuActionDto>>> ExportAsync()
        {
            //From db to dto
            return await _exportService.ExportAsync();
        }

        public async Task<OperationResult> ImportAsync(IEnumerable<MenuActionDto> menuActionDto)
        {
            //From dto to db
            return await _importService.ImportAsync(menuActionDto);
        }
    }
}
