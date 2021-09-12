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

        private GroupsRepository _groupsRepository;

        private TeachersRepository _teachersRepository;

        private TopicsRepository _topicsRepository;

        private StudentRequestsRepository _studentrequestsRepository;

        private CoursesRepository _coursesRepository;

        private bool _dispose = false;

        public UnitOfWork(CampusContext context)
        {
            //_context = new CampusContext();
            _context = context;
        }

        public IRepositoryAsync<Teacher> Teachers ////////////////////////////////////////////////
        {
            get
            {
                if (_teachersRepository == null)
                    _teachersRepository = new TeachersRepository(_context);

                return _teachersRepository;
            }
        }

        public IRepositoryAsync<Group> Groups ////////////////////////////////////////////////
        {
            get
            {
                if (_groupsRepository == null)
                    _groupsRepository = new GroupsRepository(_context);

                return _groupsRepository;
            }
        }

        public IRepositoryAsync<Student> Students ////////////////////////////////////////////////
        {
            get
            {
                if (_studentsRepository == null)
                    _studentsRepository = new StudentsRepository(_context);

                return _studentsRepository;
            }
        }

        public IRepositoryAsync<Course> Courses
        {
            get
            {
                if (_coursesRepository == null)
                    _coursesRepository = new CoursesRepository(_context);

                return _coursesRepository;
            }
        }

        public IRepositoryAsync<Topic> Topics
        {
            get
            {
                if (_topicsRepository == null)
                    _topicsRepository = new TopicsRepository(_context);

                return _topicsRepository;
            }
        }

        public IRepositoryAsync<StudentRequest> StudentRequests
        {
            get
            {
                if (_studentrequestsRepository == null)
                    _studentrequestsRepository = new StudentRequestsRepository(_context);

                return _studentrequestsRepository;
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
