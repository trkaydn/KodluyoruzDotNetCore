using AutoMapper;
using MusicStore.Application.CustomerOperations.Commands.CreateCustomer;
using MusicStore.Application.MusicOperations.Commands.CreateMusic;
using MusicStore.Application.MusicOperations.Commands.UpdateMusic;
using MusicStore.Application.MusicOperations.Queries.GetMusicDetail;
using MusicStore.Application.MusicOperations.Queries.GetMusics;
using MusicStore.Application.OrderOperations.Commands.CreateOrder;
using MusicStore.Application.OrderOperations.Queries.GetOrdersByCustomer;
using MusicStore.Application.SingerOperations.Commands.CreateSinger;
using MusicStore.Application.SingerOperations.Commands.UpdateSinger;
using MusicStore.Application.SingerOperations.Queries.GetSingerDetail;
using MusicStore.Application.SingerOperations.Queries.GetSingers;
using MusicStore.Entities;

namespace MusicStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMusicModel, Music>();
            CreateMap<UpdateMusicModel, Music>();
            CreateMap<Music, MusicDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Singer, opt => opt.MapFrom(src => src.Singer.Name + " " + src.Singer.SurName));
            CreateMap<Music, MusicsViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Singer, opt => opt.MapFrom(src => src.Singer.Name + " " + src.Singer.SurName));
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, CreateCustomerModel>();
            CreateMap<CreateSingerModel, Singer>();
            CreateMap<UpdateSingerModel, Singer>();
            CreateMap<Singer, SingerDetailViewModel>().ForMember(x => x.SongCount, opt => opt.MapFrom(src => src.Songs.Count));
            CreateMap<Singer, SingersViewModel>().ForMember(x => x.SongCount, opt => opt.MapFrom(src => src.Songs.Count));
            CreateMap<CreateOrderModel, Order>();
            CreateMap<Order, GetOrdersByCustomerViewModel>().ForMember(x => x.MusicName, opt => opt.MapFrom(src => src.Music.Name)).ForMember(x => x.CustomerName, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.SurName));
        }
    }
}
