

using AutoMapper;
using FluentAssertions;
using MovieStore.Application.ActorOperations.Queries.GetActorDetail;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MovieStore.UnitTests.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenActorNotFound_InvalidOperationException_ShouldBeReturn(int actorId)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.ActorId = actorId;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir oyuncu bulunamadı.");
        }


    }
}
