using AutoMapper;
using MusicStore.DbOperations;
using MusicStore.Entities;
using System;
using System.Linq;

namespace MusicStore.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.CustomerId == Model.CustomerId && x.MusicId == Model.MusicId);

            if (order != null)
                throw new InvalidOperationException("Şarkı zaten satın alınmış.");

            var music = _dbContext.Musics.Where(x => x.Id == Model.MusicId).FirstOrDefault();

            if (music is null)
                throw new InvalidOperationException("Şarkı mevcut değil.");

            var customer = _dbContext.Customers.Where(x => x.Id == Model.CustomerId).FirstOrDefault();
            if (customer == null)
                throw new InvalidOperationException("Müşteri mevcut değil.");

            order = _mapper.Map<Order>(Model);
            order.Price = music.Price;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MusicId { get; set; }
        public double Price { get; }
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;

    }
}
