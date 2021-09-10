
using AutoMapper;
using MovieStore.Application.ActorOperations.Commands.CreateActor;
using MovieStore.Application.ActorOperations.Commands.UpdateActor;
using MovieStore.Application.ActorOperations.Queries.GetActorDetail;
using MovieStore.Application.ActorOperations.Queries.GetActors;
using MovieStore.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStore.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStore.Application.DirectorOperations.Queries.GetDirectors;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.Application.MovieOperations.Commands.UpdateMovie;
using MovieStore.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStore.Application.MovieOperations.Queries.GetMovies;
using MovieStore.Application.OrderOperations.Commands.CreateOrder;
using MovieStore.Application.OrderOperations.Queries.GetOrdersByCustomer;
using MovieStore.Entities;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.SurName)).ForMember(x => x.Actors, opt => opt.MapFrom(src => src.Actors));
            CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.SurName)).ForMember(x => x.Actors, opt => opt.MapFrom(src => src.Actors));
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, CreateCustomerModel>();
            CreateMap<CreateActorModel, Actor>();
            CreateMap<UpdateActorModel, Actor>();
            CreateMap<Actor, ActorDetailViewModel>().ForMember(x => x.StarringMovies, opt => opt.MapFrom(src => src.StarringMovies));
            CreateMap<Actor, ActorsViewModel>().ForMember(x => x.StarringMovies, opt => opt.MapFrom(src => src.StarringMovies));
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<UpdateDirectorModel, Director>();
            CreateMap<Director, DirectorDetailViewModel>().ForMember(x => x.DirectedMovies, opt => opt.MapFrom(src => src.DirectedMovies));
            CreateMap<Director, DirectorsViewModel>().ForMember(x => x.DirectedMovies, opt => opt.MapFrom(src => src.DirectedMovies));
            CreateMap<CreateOrderModel, Order>();
            CreateMap<Order,GetOrdersByCustomerViewModel>().ForMember(x => x.MovieName, opt => opt.MapFrom(src => src.Movie.Name)).ForMember(x => x.CustomerName, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.SurName));
            CreateMap<Actor, Director>();
        }
    }
}
