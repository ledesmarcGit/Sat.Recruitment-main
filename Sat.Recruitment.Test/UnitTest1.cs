using Application.Features.Users.Commands.CreateUserCommand;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Persistence.Implementation;
using Persistence.Interfaces;
using System;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Controllers;


using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly IUsersFiles _usersFiles;
        private readonly IUsersRepository _userRepo;
        private readonly IUsersServices _userService;
        private readonly IMapper _mapper;
        private readonly CreateUserCommandHandler _handler;
        private readonly CancellationToken _cencellationToken;


        public UnitTest1()
        {
            _usersFiles= new UsersFiles(() => $"{Directory.GetCurrentDirectory()}");
            _userRepo = new UsersRepository(_usersFiles);
            _userService = new UsersServices();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new GeneralProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _handler = new CreateUserCommandHandler(_userRepo, _userService, _mapper);
            _cencellationToken = CancellationToken.None;
        }


        [Fact]
        public async Task Test1()
        {

            CreateUserCommand createUserCommand = new CreateUserCommand()
            {
                Name ="Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone ="+349 1122354215",
                UserType ="Normal",
                Money = 124
            };


            var result =  await _handler.Handle(createUserCommand, _cencellationToken);


            Assert.True(result.Succeeded);
            Assert.Equal("Usuario creado", result.Message);
        }

        [Fact]
        public async Task Test2()
        {

            CreateUserCommand createUserCommand = new CreateUserCommand()
            {
                Name ="Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone ="+349 1122354215",
                UserType ="Normal",
                Money = 124
            };


            var result = await _handler.Handle(createUserCommand, _cencellationToken);


            Assert.False(result.Succeeded);
            Assert.Equal("Usuario duplicado", result.Errors[0].ToString());
        }
    }
}
