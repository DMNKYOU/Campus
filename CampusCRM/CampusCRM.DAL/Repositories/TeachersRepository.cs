using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;

namespace CampusCRM.DAL.Repositories
{
    public class TeachersRepository : IRepositoryAsync<Teacher>
    {
        private readonly CampusContext _context;

        public TeachersRepository(CampusContext context)
        {
            _context = context;
        }

        public Task<Teacher> GetAsync(int id)
        {
            return _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task CreateAsync(Teacher item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)///////////////////////////////////////////////////////////
        {
            return _context.Teachers.AsEnumerable().Where(predicate);
        }
        
        public async Task UpdateAsync(Teacher item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null){
                throw new ArgumentException("Teacher not deleted, because not found!");
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
