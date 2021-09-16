using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.SingerOperations.Commands.CreateSinger;
using MusicStore.Application.SingerOperations.Commands.DeleteSinger;
using MusicStore.Application.SingerOperations.Commands.UpdateSinger;
using MusicStore.Application.SingerOperations.Queries.GetSingerDetail;
using MusicStore.Application.SingerOperations.Queries.GetSingers;
using MusicStore.DbOperations;
namespace MusicStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class SingerController : Controller
    {
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public SingerController(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateSinger([FromBody] CreateSingerModel newSinger)
        {
            CreateSingerCommand command = new CreateSingerCommand(_dbContext, _mapper);
            command.Model = newSinger;
            CreateSingerCommandValidator validator = new CreateSingerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSinger(int id)
        {
            DeleteSingerCommand command = new DeleteSingerCommand(_dbContext);
            command.SingerId = id;
            DeleteSingerCommandValidator validator = new DeleteSingerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMusic(int id, [FromBody] UpdateSingerModel updatedSinger)
        {
            UpdateSingerCommand command = new UpdateSingerCommand(_dbContext);
            command.SingerId = id;
            command.Model = updatedSinger;
            UpdateSingerCommandValidator validator = new UpdateSingerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetSingerDetailQuery query = new GetSingerDetailQuery(_dbContext, _mapper);
            SingerDetailViewModel result;

            query.SingerId = id;
            GetSingerDetailQueryValidator validator = new GetSingerDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetSingers()
        {
            GetSingersQuery query = new GetSingersQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
