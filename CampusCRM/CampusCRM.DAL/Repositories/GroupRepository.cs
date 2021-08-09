using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusCRM.DAL.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly CampusContext _context;
        public GroupRepository(CampusContext context)
        { 
            _context = context;
        }
        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.Include(g => g.Teacher).ToList();
        }

        public Group Get(int id)
        {
            return _context.Groups.Find(id);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return _context.Groups.Where(predicate).ToList();
        }

        public void Create(Group item)
        {
            _context.Groups.Add(item);
        }

        public void Update(Group item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var group = _context.Groups.Find(id);

            if (group != null){
                _context.Groups.Remove(group);
            }
            else{
                throw new ArgumentException("Group not found");
            }

        }
    }
}
