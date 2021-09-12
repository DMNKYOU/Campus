using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.DAL.Entities;

namespace CampusCRM.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryAsync<Student> Students { get; }
        IRepositoryAsync<Group> Groups { get; }
        IRepositoryAsync<Teacher> Teachers { get; }
        IRepositoryAsync<StudentRequest> StudentRequests { get; }
        IRepositoryAsync<Topic> Topics { get; }
        IRepositoryAsync<Course> Courses { get; }

        void Save();
        void Dispose();
    }
}
