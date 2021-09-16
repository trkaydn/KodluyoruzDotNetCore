

using AutoMapper;
using FluentAssertions;
using MusicStore.Application.SingerOperations.Queries.GetSingerDetail;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MusicStore.UnitTests.Application.SingerOperations.Queries.GetSingerDetail
{
    public class GetSingerDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetSingerDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenSingerNotFound_InvalidOperationException_ShouldBeReturn(int SingerId)
        {
            GetSingerDetailQuery query = new GetSingerDetailQuery(_context, _mapper);
            query.SingerId = SingerId;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir şarkıcı bulunamadı.");
        }


    }
}
