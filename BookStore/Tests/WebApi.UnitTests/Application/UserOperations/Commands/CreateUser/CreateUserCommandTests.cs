using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.UserOperations.Commands.CreateUser;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistUserMailIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var user = new User() { Name = "Test", SurName = "Test", Email = "aaa@hotmail.com", Password = "12345" };
            _context.Users.Add(user);
            _context.SaveChanges();

            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = new CreateUserModel() { Name = "test1", Surname = "test1", Email = "aaa@hotmail.com", Password = "12345" };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kullanıcı zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_User_ShouldBeCreated()
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            CreateUserModel model = new CreateUserModel() { Name = "İsim", Surname = "Soyisim", Email = "bbb@hotmail.com", Password = "12345" };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);
            user.Should().NotBeNull();
            user.Name.Should().Be(model.Name);
            user.SurName.Should().Be(model.Surname);
            user.Password.Should().Be(model.Password);
        }

    }
}
