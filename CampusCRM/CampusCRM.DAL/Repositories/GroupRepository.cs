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
        private readonly CampusContext db;
        public GroupRepository(CampusContext db)
        {
            this.db = db;
        }
        public IEnumerable<Group> GetAll()
        {
            return db.Groups.Include(g => g.Teacher).ToList();
        }

        public Group Get(int id)
        {
            return db.Groups.Find(id);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return db.Groups.Where(predicate).ToList();
        }

        public void Create(Group item)
        {
            db.Groups.Add(item);
        }

        public void Update(Group item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var group = db.Groups.Find(id);
            if (group != null)
                db.Groups.Remove(group);
            else
                throw new ArgumentException("Group not found");
        }
    }
}
