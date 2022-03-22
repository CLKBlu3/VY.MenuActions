using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Services;
using VY.MenuActions.Dtos;
using VY.MenuActions.XCutting.Contracts;

namespace VY.MenuActions.WebApi.Controllers
{
    public class MenuActionController : Controller
    {
        private readonly IMenuActionService _menuActionService;

        public MenuActionController(IMenuActionService menuActionService)
        {
            _menuActionService = menuActionService;
        }

        [HttpGet("Export")]
        [ProducesResponseType(typeof(IEnumerable<MenuActionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ErrorObject>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await _menuActionService.ExportAsync();
            if (result.HasErrors)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Result);
        }

        [HttpPost("Import")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ErrorObject>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] IEnumerable<MenuActionDto> menuActionDto)
        {
            var result = await _menuActionService.ImportAsync(menuActionDto);
            if(result.HasErrors) return BadRequest(result.Errors);
            return Ok(result);
        }
    }
}
