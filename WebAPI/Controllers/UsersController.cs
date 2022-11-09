using Application.Features.Users.Commands.CreateUserCommand;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : BaseApiController
    {

        [HttpPost]
        [Route("/create-user")]
        public async Task<Response> CreateUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}