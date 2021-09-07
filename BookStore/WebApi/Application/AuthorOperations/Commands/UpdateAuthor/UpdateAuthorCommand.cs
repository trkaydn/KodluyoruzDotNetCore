using System;
using System.Linq;
using WebApi.DbOperations;


namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı.");

            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            _dbContext.SaveChanges();
        }

    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
