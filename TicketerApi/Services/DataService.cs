using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;

namespace TicketerApi.Services
{
    public class DataService
    {
        private ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            if (user == null)
                throw new NullReferenceException($"Cannot add null reference object.");

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            if (user == null)
                throw new NullReferenceException($"Cannot delete null reference object.");

            var userToDelete = await GetUserAsync(user.Id);

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            if (user == null)
                throw new NullReferenceException($"Cannot edit null reference object.");

            var dbUser = await GetUserAsync(user.Id);
            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.Password = user.Password;

            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Cannot find user with id = {id}.");

            return user;
        }
    }
}