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
    public class StudentsRepository : IRepositoryAsync<Student>
    {
        private readonly CampusContext _context;

        public StudentsRepository(CampusContext context)
        {
            _context = context;
        }
        public Task<Student> GetAsync(int id)
        {
            return _context.Students.AsNoTracking().Include(s => s.Group).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.AsNoTracking().Include(s => s.Group).ToListAsync();
        }


        public IEnumerable<Student> Find(Func<Student, bool> predicate) ///////////////////////////////////////////////////////////////
        {
            return _context.Students.AsNoTracking().AsEnumerable().Where(predicate).ToList(); 
        }

        public async Task CreateAsync(Student item)
        {
            await _context.Students.AddAsync(item);
            await _context.SaveChangesAsync();
        }
       
        public async Task UpdateAsync(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) {
                throw new ArgumentException("Error! Student not deleted, because not found!");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
