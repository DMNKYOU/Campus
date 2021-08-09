using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.DAL.Entities;

namespace CampusCRM.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
        IRepository<Group> Groups { get; }
        IRepository<Teacher> Teachers { get; }
        void Save();
        void Dispose();
    }
}
