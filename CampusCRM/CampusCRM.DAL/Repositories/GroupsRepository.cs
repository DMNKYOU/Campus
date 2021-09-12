using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCRM.DAL.Repositories
{
    public class GroupsRepository : IRepositoryAsync<Group>
    {
        private readonly CampusContext _context;

        public GroupsRepository(CampusContext context)
        { 
            _context = context;
        }

        public Task<Group> GetAsync(int id)
        {
            return _context.Groups.AsNoTracking()
                .Include(s => s.Students).FirstOrDefaultAsync(g => g.Id == id);
        }

        public Task<List<Group>> GetAllAsync()
        {
            return _context.Groups.AsNoTracking()
                .Include(g => g.Teacher).ToListAsync();
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate) ///////////////////////////////////////////////////////////////
        {
            return _context.Groups.AsNoTracking().AsEnumerable().Where(predicate).ToList();
        }

        public async Task CreateAsync(Group item)
        {
            await _context.Groups.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);

            if (group == null){
                throw new ArgumentException("Error! Group not deleted, because not found!");
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
    }
}
