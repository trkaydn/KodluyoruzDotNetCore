using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.OrderOperations.Commands.CreateOrder;
using MovieStore.Application.OrderOperations.Queries.GetOrdersByCustomer;
using MovieStore.DbOperations;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : Controller
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
            command.Model = newOrder;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet("{customerId}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            GetOrdersByCustomerQuery query = new GetOrdersByCustomerQuery(_dbContext, _mapper);
      
            query.CustomerId =customerId;
            GetOrdersByCustomerQueryValidator validator = new GetOrdersByCustomerQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

    }
}
