using MovieStore.DbOperations;
using System;
using System.Linq;

namespace MovieStore.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteCustomerCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer is null || customer.Status==false)
                throw new InvalidOperationException("Silinecek müşteri bulunamadı");

            customer.Status = false;
            _dbContext.SaveChanges();
        }
    }
}
