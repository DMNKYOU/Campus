using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusCRM.DAL.Repositories
{
    public class TopicsRepository : IRepositoryAsync<Topic>
    {
        private readonly CampusContext _context;
        public TopicsRepository(CampusContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Topic item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
                throw new ArgumentException("Error! Topic not found!");

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Topic> Find(Func<Topic, bool> predicate)
        {
            return _context.Topics.Where(predicate).ToList();
        }

        public Task<Topic> GetAsync(int id)
        {
            return _context.Topics.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<List<Topic>> GetAllAsync()
        {
            return _context.Topics.ToListAsync();
        }

        public async Task UpdateAsync(Topic item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
