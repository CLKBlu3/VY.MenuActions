using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Domain;
using VY.MenuActions.Business.Contracts.Services;
using VY.MenuActions.Dtos;
using VY.MenuActions.Infraestructure.Contracts.Entities;
using VY.MenuActions.Infraestructure.Contracts.Repositories;
using VY.MenuActions.Infraestructure.Contracts.Services;
using VY.MenuActions.XCutting.Contracts;
using VY.MenuActions.XCutting.Contracts.Services;

namespace VY.MenuActions.Business.Impl.Services
{
    public class ImportService : IAction, IImportService
    {
        private readonly ISerializerFactory _serializerFactory;
        private readonly IMenuActionRepository _menuRepository;
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;
        private readonly ILogger<ImportService> _logger;

        public ImportService(ISerializerFactory serializerFactory, 
                             IMenuActionRepository menuRepository, 
                             IDataManager dataManager,
                             IMapper mapper,
                             ILogger<ImportService> logger)
        {
            _serializerFactory = serializerFactory;
            _menuRepository = menuRepository;
            _dataManager = dataManager;
            _mapper = mapper;
            _logger = logger;
        }

        public ActionType Source { get => ActionType.Import; }

        #region .:IActionMethods:.
        public async Task<OperationResult> RunAction(ArgContext context)
        {
            var _serializer = _serializerFactory.GetSerializer(context.Serializer);
            var result = new OperationResult();
            try
            {
                var dataString = await _dataManager.Read(context.Path);

                var entities = _serializer.Deserialize<IEnumerable<MenuAction>>(dataString);

                await _menuRepository.SaveAsync(entities);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }
            return result;
        }
        #endregion

        #region .:IImportService methods:.
        public async Task<OperationResult> ImportAsync(IEnumerable<MenuActionDto> menuActionDto)
        {
            _logger.LogInformation("Importing data.");
            var result = new OperationResult();
            UpdateMenuActionDtos(menuActionDto);
            var menuActionEntities = _mapper.Map<IEnumerable<MenuAction>>(menuActionDto);
            try
            {
                if (menuActionEntities != null)
                {
                    
                    await _menuRepository.SaveAsync(menuActionEntities);
                }
                else
                {
                    result.AddError(2000, "The given entity is null");
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }
            
            return result;
        }

        private void UpdateMenuActionDtos(IEnumerable<MenuActionDto> menuActionDtos, MenuActionDto parent=null)
        {
            foreach (var entry in menuActionDtos)
            {
                entry.Id = Guid.NewGuid();
                entry.ReportsToNavigation = parent;
                if (parent != null)
                {
                    entry.ReportsTo = parent.Id;
                }
                if(entry.InverseReportsToNavigation.Any()) 
                {
                    UpdateMenuActionDtos(entry.InverseReportsToNavigation, entry);
                }
            }
                
        }
        #endregion
    }
}
