using AutoMapper;
using MusicStore.DbOperations;
using MusicStore.Entities;
using System;
using System.Linq;

namespace MusicStore.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Email == Model.Email);

            if (customer != null)
                throw new InvalidOperationException("Bu e-mail zaten mevcut.");

            customer = _mapper.Map<Customer>(Model);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
    }
    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
