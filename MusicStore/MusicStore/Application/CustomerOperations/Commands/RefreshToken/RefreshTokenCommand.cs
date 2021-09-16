using Microsoft.Extensions.Configuration;
using MusicStore.Application.TokenOperations;
using MusicStore.Application.TokenOperations.Models;
using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMusicStoreDbContext _context;
        readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMusicStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            throw new InvalidOperationException("Valid bir refresh token bulunamadı.");
        }
    }
}
