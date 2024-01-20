using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Context;

namespace Twitter.DAL.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly TwitterDBContext _context;
        public GenericRepo(TwitterDBContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public T? GetByID(string Id)
        {
            return _context.Set<T>().Find(Id);
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }
        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }
        public string getUserFormToken(string tokenFromHeader /*Request.Headers.Authorization*/)
        {
            //Fetching Token From Header
            string? token = tokenFromHeader;

            //Cut of the Prefix "Bearer"
            if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer "))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            //Decrypt and fetching UserId from JWT token
            var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);
            string userId = tokenHandler.Subject;
            return userId;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
