using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Domain;
using VY.MenuActions.Business.Contracts.Services;
using VY.MenuActions.Dtos;
using VY.MenuActions.Infraestructure.Contracts.Repositories;
using VY.MenuActions.Infraestructure.Contracts.Services;
using VY.MenuActions.XCutting.Contracts;
using VY.MenuActions.XCutting.Contracts.Services;

namespace VY.MenuActions.Business.Impl.Services
{
    public class ExportService : IAction, IExportService
    {
        public ActionType Source => ActionType.Export; 
        private readonly ISerializerFactory _serializerFactory;
        private readonly IMenuActionRepository _menuRepository;
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;
        private readonly ILogger<ExportService> _logger;

        public ExportService(ISerializerFactory serializerFactory, 
                             IMenuActionRepository menuRepository, 
                             IDataManager dataManager,
                             IMapper mapper,
                             ILogger<ExportService> logger)
        {
            _serializerFactory = serializerFactory;
            _menuRepository = menuRepository;
            _dataManager = dataManager;
            _mapper = mapper;
            _logger = logger;
        }
        #region .:IActionMethods:.
        public async Task<OperationResult> RunAction(ArgContext context)
        {
            var _serializer = _serializerFactory.GetSerializer(context.Serializer);

            var result = new OperationResult();
            try
            {
                var entities = (await _menuRepository.GetAllAsync()).ToList();

                var dataString = _serializer.Serialize(entities);

                await _dataManager.Write(context.Path, dataString);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }
            return result;
        }
        #endregion

        #region .:IExportServiceMethods:.
        public async Task<OperationResult<IEnumerable<MenuActionDto>>> ExportAsync()
        {
            _logger.LogInformation("Exporting data.");
            var result = new OperationResult<IEnumerable<MenuActionDto>>();
            try
            {
                var actionEntities = await _menuRepository.GetAllAsync();
                if (actionEntities.Any())
                {
                    var actionDtos = _mapper.Map<IEnumerable<MenuActionDto>>(actionEntities);
                    result.SetResult(actionDtos);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
        #endregion
    }
}
