using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;

namespace TicketerApi.Services
{
    public class UserDataService : IGenericDataService<User>
    {
        private ApplicationDbContext _context;

        public UserDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot add null reference object.");

            _context.Users.Add(item);

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(User item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot delete null reference object.");

            var userToDelete = await GetAsync(item.Id);

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(User item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot edit null reference object.");

            var dbUser = await GetAsync(item.Id);
            dbUser.Name = item.Name;
            dbUser.Email = item.Email;
            dbUser.Password = item.Password;

            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Cannot find user with id = {id}.");

            return user;
        }
    }
}
