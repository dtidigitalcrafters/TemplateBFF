using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateBFF.Domain.Models.Users;
using TemplateBFF.Domain.Services;
using TemplateBFF.WebApi.Dtos.Users;

namespace TemplateBFF.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IListUsersService listUsersService;

        public UsersController(IMapper mapper, IListUsersService listUsersService)
        {
            this.mapper = mapper;
            this.listUsersService = listUsersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ListUsersGetResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListUsers([FromQuery] ListUsersGet model)
        {
            var input = mapper.Map<ListUsersGet, ListUsersInput>(model);

            var users = await listUsersService.ListUsers(input);

            var result = mapper.Map<IEnumerable<User>, IEnumerable<ListUsersGetResult>>(users.Users);

            return Ok(result);
        }

    }
}
