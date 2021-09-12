using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusCRM.DAL.Repositories
{
    public class StudentRequestsRepository : IRepositoryAsync<StudentRequest>
    {
        private readonly CampusContext _context;

        public StudentRequestsRepository(CampusContext context)
        {
            _context = context;
        }
        public Task<StudentRequest> GetAsync(int id)
        {
            return _context.StudentRequests.AsNoTracking().FirstOrDefaultAsync(sr => sr.Id == id);
        }

        public Task<List<StudentRequest>> GetAllAsync()
        {
            return _context.StudentRequests.AsNoTracking().Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync();
        }

        public async Task CreateAsync(StudentRequest item)
        {
            await _context.StudentRequests.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<StudentRequest> Find(Func<StudentRequest, bool> predicate) ///////////////////////////////////////////
        {
            return _context.StudentRequests.Where(predicate).ToList();
        }

        public async Task UpdateAsync(StudentRequest item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var request = await _context.StudentRequests.FindAsync(id);

            if (request == null)
                throw new ArgumentException("Error! Request  deleted, because not found!");
            _context.StudentRequests.Remove(request);

            await _context.SaveChangesAsync();
        }

    }
}