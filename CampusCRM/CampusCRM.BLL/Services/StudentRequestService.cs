using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using System.Threading.Tasks;
using CampusCRM.BLL.Enums;

namespace CampusCRM.BLL.Services
{
    public class StudentRequestService : IStudentRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(StudentRequestDTO sqDto)
        {
            if (sqDto == null)
                throw new ArgumentException();
            var res = _mapper.Map<StudentRequest>(sqDto);

            await _unitOfWork.StudentRequests.CreateAsync(res);
        }

        public async Task EditAsync(StudentRequestDTO sqDto)
        {
            if (sqDto == null)
                throw new ArgumentException();
            var res = _mapper.Map<StudentRequest>(sqDto);
            await _unitOfWork.StudentRequests.UpdateAsync(res);
        }

        public async Task<List<StudentRequestDTO>> GetOpenRequestsAsync()
        {
            var requests = await _unitOfWork.StudentRequests.GetAllAsync();
            var reqMap = _mapper.Map<List<StudentRequest>, List<StudentRequestDTO>> (requests);
            return reqMap.Where(sr => sr.Status == RequestStatus.Open).ToList();
        }

        public async Task<List<StudentRequestDTO>> GetOpenRequestsByCourseAsync(int courseId)
        {
            var requests = await _unitOfWork.StudentRequests.GetAllAsync();
            var reqMap = _mapper.Map<List<StudentRequest>, List<StudentRequestDTO>>(requests);
            return reqMap.Where(sr => sr.Status == RequestStatus.Open && sr.CourseId == courseId)
                           .Distinct()
                           .ToList();
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsRequestedForCourseAsync(int courseId)
        {
            var requests = await _unitOfWork.StudentRequests.GetAllAsync();
            var reqMap = _mapper.Map<List<StudentRequest>, List<StudentRequestDTO>>(requests);
            return reqMap.Where(sr => sr.CourseId == courseId && sr.Status == RequestStatus.Open)
                           .Select(s => s.Student)
                           .Distinct();
        }

        public async Task CloseRequestsAsync(List<int> studentsId, int courseId)
        {
            var openRequests = await GetOpenRequestsByCourseAsync(courseId);
            var openRequestsForStudents = openRequests.Where(r => studentsId.Contains(r.StudentId));

            foreach (var request in openRequestsForStudents)
            {
                request.Status = RequestStatus.Closed;
                await EditAsync(request);
            }
        }

        public async Task<List<StudentRequestDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentRequest>, List<StudentRequestDTO>>(await _unitOfWork.StudentRequests.GetAllAsync());
        }

        public async Task<StudentRequestDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<StudentRequest, StudentRequestDTO>(await _unitOfWork.StudentRequests.GetAsync(id));
        }
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.StudentRequests.DeleteAsync(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
