using AutoMapper;
using FluentAssertions;
using MusicStore.Application.MusicOperations.Queries.GetMusicDetail;
using MusicStore.DbOperations;
using MusicStore.UnitTests.TestSetup;
using System;
using Xunit;

namespace MusicStore.UnitTests.Application.MusicOperations.Queries.GetMusicDetail
{
    public class GetMusicDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMusicDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void WhenMusicNotFound_InvalidOperationException_ShouldBeReturn(int musicId)
        {
            GetMusicDetailQuery query = new GetMusicDetailQuery(_context, _mapper);
            query.MusicId = musicId;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir şarkı bulunamadı.");
        }
    }
}
