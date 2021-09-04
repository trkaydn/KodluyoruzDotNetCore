using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı");

            _dbContext.Books.RemoveRange(_dbContext.Books.Where(x => x.AuthorId == AuthorId));
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
