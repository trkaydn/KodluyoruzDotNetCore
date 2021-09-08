using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using WebApi.Application.TokenOperations;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOperations;

namespace WebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IBookStoreDbContext _context;
        readonly IConfiguration _configuration;

        public RefreshTokenCommand(IBookStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            throw new InvalidOperationException("Valid bir refresh token bulunamadı.");
        }
    }
}
