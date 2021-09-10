using AutoMapper;
using FluentAssertions;
using MovieStore.Application.OrderOperations.Queries.GetOrdersByCustomer;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MovieStore.UnitTests.Application.OrderOperations.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersByCustomerQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenOrdersNotFound_InvalidOperationException_ShouldBeReturn(int customerId)
        {
            GetOrdersByCustomerQuery query = new GetOrdersByCustomerQuery(_context, _mapper);
            query.CustomerId = customerId;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Hiçbir sipariş bulunamadı.");
        }
    }
}
