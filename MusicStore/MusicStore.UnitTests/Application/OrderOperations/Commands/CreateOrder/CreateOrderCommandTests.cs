using AutoMapper;
using MusicStore.DbOperations;
using MusicStore.Entities;
using MusicStore.UnitTests.TestSetup;
using Xunit;
using System;
using MusicStore.Application.OrderOperations.Commands.CreateOrder;
using FluentAssertions;
using System.Linq;

namespace MusicStore.UnitTests.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
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
            command.Model = new CreateOrderModel() { CustomerId = order.CustomerId, MusicId = order.MusicId, OrderDate = order.OrderDate };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Şarkı zaten satın alınmış.");
        }

        [Fact]
        public void WhenMusicNotFound_InvalidOperationException_ShouldBeReturn()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() { CustomerId = 1, MusicId = 100, OrderDate = DateTime.Now };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Şarkı mevcut değil.");
        }

        [Fact]
        public void WhenCustomerNotFound_InvalidOperationException_ShouldBeReturn()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = new CreateOrderModel() { CustomerId = 100, MusicId = 1, OrderDate = DateTime.Now };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri mevcut değil.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Order_ShouldBeCreated()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            CreateOrderModel model = new CreateOrderModel()
            {
                MusicId = 1,
                CustomerId = 2,
                OrderDate = DateTime.Now,
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var order = _context.Orders.SingleOrDefault(x => x.CustomerId == 2 && x.MusicId == 1);
            order.Should().NotBeNull();
            order.OrderDate.Should().Be(model.OrderDate);
        }

    }
}
