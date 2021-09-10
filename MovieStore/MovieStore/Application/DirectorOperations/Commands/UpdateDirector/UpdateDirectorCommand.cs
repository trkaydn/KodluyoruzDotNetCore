using MovieStore.DbOperations;
using System;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director is null || director.Status == false)
                throw new InvalidOperationException("Güncellenecek yönetmen bulunamadı.");

            director.Name = Model.Name != default ? Model.Name : director.Name;
            director.SurName = Model.SurName != default ? Model.SurName : director.SurName;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
