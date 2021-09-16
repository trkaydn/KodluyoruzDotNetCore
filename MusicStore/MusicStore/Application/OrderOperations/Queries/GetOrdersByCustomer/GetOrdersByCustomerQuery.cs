using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Application.OrderOperations.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQuery
    {
        public int CustomerId { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersByCustomerQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GetOrdersByCustomerViewModel> Handle()
        {
            var orderList = _dbContext.Orders.Where(x => x.CustomerId == CustomerId).Include(x => x.Customer).Include(x => x.Music).ToList();

            if (orderList.Count < 1)
                throw new InvalidOperationException("Hiçbir sipariş bulunamadı.");

            List<GetOrdersByCustomerViewModel> vm = _mapper.Map<List<GetOrdersByCustomerViewModel>>(orderList);
            return vm;
        }
    }
    public class GetOrdersByCustomerViewModel
    {
        public string CustomerName { get; set; }
        public string MusicName { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }

    }

}