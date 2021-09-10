using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.UnitTests.TestSetup;
using Xunit;
using System;
using MovieStore.Application.OrderOperations.Commands.CreateOrder;
using FluentAssertions;
using System.Linq;

namespace MovieStore.UnitTests.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistOrderIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var order = _context.Orders.Where(x => x.Id == 1).FirstOrDefault();

            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() { CustomerId = order.CustomerId, MovieId = order.MovieId, OrderDate = order.OrderDate };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film zaten satın alınmış.");
        }

        [Fact]
        public void WhenMovieNotFound_InvalidOperationException_ShouldBeReturn()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() { CustomerId = 1, MovieId = 100, OrderDate = DateTime.Now };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film mevcut değil.");
        }

        [Fact]
        public void WhenCustomerNotFound_InvalidOperationException_ShouldBeReturn()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() { CustomerId = 100, MovieId = 1, OrderDate = DateTime.Now };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri mevcut değil.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Order_ShouldBeCreated()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            CreateOrderModel model = new CreateOrderModel()
            {
                MovieId = 1,
                CustomerId = 2,
                OrderDate = DateTime.Now,
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var order = _context.Orders.SingleOrDefault(x => x.CustomerId == 2 && x.MovieId == 1);
            order.Should().NotBeNull();
            order.OrderDate.Should().Be(model.OrderDate);
        }

    }
}
