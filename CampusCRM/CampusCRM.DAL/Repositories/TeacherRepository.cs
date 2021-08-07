using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;

namespace CampusCRM.DAL.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly CampusContext _context;

        public TeacherRepository(CampusContext context)
        {
            _context = context;
        }

        public Teacher Get(int id)
        {
            return _context.Teachers.Find(id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public void Create(Teacher item)
        {
            _context.Add(item);
        }


        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return _context.Teachers.Where(predicate).ToList();
        }
        

        public void Update(Teacher item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
                _context.Teachers.Remove(teacher);
            else
                throw new ArgumentException("Teacher not found");
        }
    }
}
