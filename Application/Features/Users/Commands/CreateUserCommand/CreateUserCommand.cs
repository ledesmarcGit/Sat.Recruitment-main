using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }      
        public string UserType { get; set; }
        public decimal Money { get; set; }

    }

    //clase manejador, mediadora
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IUsersRepository _userRepo;
        private readonly IUsersServices _userService;
        private readonly IMapper _mapper;
        private List<string> Errores { get; set; }

        public CreateUserCommandHandler(IUsersRepository userRepo,IUsersServices userService, IMapper mapper )
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userService = userService;
            Errores = new List<string>();
        }
        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<User>(request);

            //Normalize email
            nuevoRegistro.Email = _userService.NormalizeEmail(nuevoRegistro.Email);
           
            IList<User> _listUsers = await _userRepo.GetAllAsync();

            if (_userService.isDuplicated(_listUsers, nuevoRegistro))
            {
                Debug.WriteLine("The user is duplicated");
                Errores.Add("Usuario duplicado");
                return new Response()
                {
                    Succeeded = false,
                    Errors = Errores
                };
            }
            else
            {
                nuevoRegistro.Money = _userService.calcularMoney(nuevoRegistro.UserType, request.Money.ToString());

                bool ok = await _userRepo.AddUser(nuevoRegistro);

                if (!ok)
                {
                    Errores.Add("Error al guardar el usuario");
                    return new Response()
                    {
                        Succeeded = false,
                        Errors = Errores
                    };
                }

                Debug.WriteLine("User Created");

                return new Response()
                {
                    Succeeded = true,
                    Message = "Usuario creado"
                  //  Errors = "Usuario Creado"
                };
            }
        }
    }
}
