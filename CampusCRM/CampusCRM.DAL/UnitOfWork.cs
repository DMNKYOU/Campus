using CampusCRM.DAL.Contexts;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using CampusCRM.DAL.Repositories;

namespace CampusCRM.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CampusContext _context;

        private StudentsRepository _studentsRepository;

        private bool _dispose = false;

        public UnitOfWork(CampusContext context)
        {
            //_context = new CampusContext();
            _context = context;
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_studentsRepository == null)
                    _studentsRepository = new StudentsRepository(_context);

                return _studentsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _dispose = true;
            }
        }

    }
}
