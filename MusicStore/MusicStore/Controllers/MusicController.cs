using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.MusicOperations.Commands.CreateMusic;
using MusicStore.Application.MusicOperations.Commands.DeleteMusic;
using MusicStore.Application.MusicOperations.Commands.UpdateMusic;
using MusicStore.Application.MusicOperations.Queries.GetMusicDetail;
using MusicStore.Application.MusicOperations.Queries.GetMusics;
using MusicStore.DbOperations;

namespace MusicStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MusicController : Controller
    {
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public MusicController(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMusic([FromBody] CreateMusicModel newMusic)
        {
            CreateMusicCommand command = new CreateMusicCommand(_dbContext, _mapper);
            command.Model = newMusic;
            CreateMusicCommandValidator validator = new CreateMusicCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMusic(int id)
        {
            DeleteMusicCommand command = new DeleteMusicCommand(_dbContext);
            command.MusicId = id;
            DeleteMusicCommandValidator validator = new DeleteMusicCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMusic(int id, [FromBody] UpdateMusicModel updatedMusic)
        {
            UpdateMusicCommand command = new UpdateMusicCommand(_dbContext);
            command.MusicId = id;
            command.Model = updatedMusic;
            UpdateMusicCommandValidator validator = new UpdateMusicCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetMusicDetailQuery query = new GetMusicDetailQuery(_dbContext, _mapper);
            MusicDetailViewModel result;

            query.MusicId = id;
            GetMusicDetailQueryValidator validator = new GetMusicDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetMusics()
        {
            GetMusicsQuery query = new GetMusicsQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
