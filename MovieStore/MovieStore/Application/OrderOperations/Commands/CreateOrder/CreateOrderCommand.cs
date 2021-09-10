using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Linq;

namespace MovieStore.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.CustomerId == Model.CustomerId && x.MovieId == Model.MovieId);

            if (order != null)
                throw new InvalidOperationException("Film zaten satın alınmış.");

            var movie = _dbContext.Movies.Where(x => x.Id == Model.MovieId).FirstOrDefault();

            if (movie is null)
                throw new InvalidOperationException("Film mevcut değil.");

            var customer = _dbContext.Customers.Where(x => x.Id == Model.CustomerId).FirstOrDefault();
            if (customer == null)
                throw new InvalidOperationException("Müşteri mevcut değil.");

            order = _mapper.Map<Order>(Model);
            order.Price = movie.Price;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public double Price { get; }
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;

    }
}
