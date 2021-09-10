

using AutoMapper;
using FluentAssertions;
using MovieStore.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace MovieStore.UnitTests.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMailIsGiven_InvalidOperationException_ShouldBeReturn()
        {

            var customer = new Customer() { Name = "Test4", SurName = "Test4", Password = "12345", Email = "test4@test.com" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = _mapper.Map<CreateCustomerModel>(customer);

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu e-mail zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Customer_ShouldBeCreated()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            CreateCustomerModel model = new CreateCustomerModel()
            {
                Name = "Test5",
                SurName = "Test5",
                Email = "test5@test.com",
                Password = "test5"
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var customer = _context.Customers.SingleOrDefault(x => x.Email == model.Email);
            customer.Should().NotBeNull();

        }
    }
}
