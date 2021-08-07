using System;
using System.Collections.Generic;
using System.Linq;
using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusCRM.DAL.Repositories
{
    public class StudentsRepository : IRepository<Student>
    {
        private readonly CampusContext _context;

        public StudentsRepository(CampusContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student Get(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return _context.Students.AsNoTracking().AsEnumerable().Where(predicate).ToList(); /////////////////////
        }

        public void Create(Student item)
        {
            _context.Students.Add(item);
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null) {
                _context.Students.Remove(student);
            }
            else {
                throw new ArgumentException("Student not found");
            }
        }
    }
}
