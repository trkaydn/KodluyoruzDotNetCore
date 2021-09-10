

using AutoMapper;
using FluentAssertions;
using MovieStore.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStore.DbOperations;
using MovieStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MovieStore.UnitTests.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        public void WhenDirectorNotFound_InvalidOperationException_ShouldBeReturn(int directorId)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId = directorId;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir yönetmen bulunamadı.");
        }
    }
}
