using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.OrderOperations.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQuery
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersByCustomerQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GetOrdersByCustomerViewModel> Handle()
        {
            var orderList = _dbContext.Orders.Where(x => x.CustomerId==CustomerId).Include(x => x.Customer).Include(x => x.Movie).ToList();

            if(orderList.Count<1)
                throw new InvalidOperationException("Hiçbir sipariş bulunamadı.");

            List<GetOrdersByCustomerViewModel> vm = _mapper.Map<List<GetOrdersByCustomerViewModel>>(orderList);
            return vm;
        }
    }
    public class GetOrdersByCustomerViewModel
    {
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }

    }

}
