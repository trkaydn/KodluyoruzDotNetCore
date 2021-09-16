using AutoMapper;
using Microsoft.Extensions.Configuration;
using MusicStore.Application.TokenOperations;
using MusicStore.Application.TokenOperations.Models;
using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CreateTokenCommand(IMusicStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı.");
        }
    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
