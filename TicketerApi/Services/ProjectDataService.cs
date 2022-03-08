using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;

namespace TicketerApi.Services
{
    public class ProjectDataService : IGenericDataService<Project>
    {
        private ApplicationDbContext _context;

        public ProjectDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddAsync(Project item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot add null reference object.");

            _context.Projects.Add(item);

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Project item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot delete null reference object.");

            var ProjectToDelete = await GetAsync(item.Id);

            _context.Projects.Remove(ProjectToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Project item)
        {
            if (item == null)
                throw new NullReferenceException($"Cannot edit null reference object.");

            var dbProject = await GetAsync(item.Id);
            dbProject.Name = item.Name;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetAsync(int id)
        {
            var item = await _context.Projects.FindAsync(id);
            if (item == null)
                throw new KeyNotFoundException($"Cannot find Project with id = {id}.");

            return item;
        }
    }
}