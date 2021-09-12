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
    public class CoursesRepository : IRepositoryAsync<Course>
    {

        private readonly CampusContext _context;

        public CoursesRepository(CampusContext context)
        {
            _context = context;
        }
        public Task<Course> GetAsync(int id)
        {
            return _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public async Task CreateAsync(Course item)
        {
            await _context.Courses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                throw new ArgumentException("Error! Not found");
            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();
        }

        public IEnumerable<Course> Find(Func<Course, bool> predicate)  /////////////////////////////////////////////////////////
        {
            return _context.Courses.Where(predicate);
        }

        public async Task UpdateAsync(Course item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
