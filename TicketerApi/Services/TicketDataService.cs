using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;

namespace TicketerApi.Services
{
    public class TicketDataService : IDataService
    {
        private ApplicationDbContext _context;

        public TicketDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddAsync(Ticket item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot add null reference object.");

            _context.Tickets.Add(item);

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Ticket item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot delete null reference object.");

            var TicketToDelete = await GetAsync(item.Id);

            _context.Tickets.Remove(TicketToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Ticket item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot edit null reference object.");

            var dbTicket = await GetAsync(item.Id);
            dbTicket.Title = item.Title;
            dbTicket.Description = item.Description;
            dbTicket.Status = item.Status;
            dbTicket.Project = item.Project;
            dbTicket.Owner = item.Owner;
            dbTicket.AssignedTo = item.AssignedTo;
            dbTicket.Comments = item.Comments;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Ticket>> GetAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetAsync(int id)
        {
            var item = await _context.Tickets.FindAsync(id);
            if (item == null)
                throw new KeyNotFoundException($"Cannot find Ticket with id = {id}.");

            return item;
        }
    }
}