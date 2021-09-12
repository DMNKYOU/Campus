using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using System.Threading.Tasks;

namespace CampusCRM.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRequestService _studentRequestService;
        private readonly IMapper _mapper;

        private readonly IStudentService _studentService;

        public GroupService(IUnitOfWork unitOfWork, IStudentService studentService, IMapper mapper,
            IStudentRequestService studentRequestService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _studentService = studentService;
            _studentRequestService = studentRequestService;
        }

        public async Task<List<GroupDTO>> GetAllAsync()
        {
            var groups = await _unitOfWork.Groups.GetAllAsync();
            return _mapper.Map<IEnumerable<Group>, List<GroupDTO>>(groups);
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var group = await _unitOfWork.Groups.GetAsync(id);

            return _mapper.Map<GroupDTO>(group);
        }

        public async Task AddAsync(GroupDTO groupDto)
        {
            if(groupDto == null)
                throw new ArgumentException();

            await _unitOfWork.Groups.CreateAsync(_mapper.Map<Group>(groupDto));
        }

        public async Task AddAsync(GroupDTO groupDto, List<int> studentsId)
        {
            await AddAsync(groupDto);

            foreach (var studentId in studentsId)
            {
                await _studentService.AddStudentToGroupAsync(studentId, groupDto.Id);///////////////////////////////////
            }

            await _studentRequestService.CloseRequestsAsync(studentsId, groupDto.CourseId);
        }


        public async Task EditAsync(GroupDTO groupDto)
        {

            if (groupDto == null)
                throw new ArgumentException();

            var group = _mapper.Map<Group>(groupDto);

            await _unitOfWork.Groups.UpdateAsync(group);


        }

        public async Task EditAsync(GroupDTO groupDto, List<int> studentsId)
        {

            if (groupDto == null)
                throw new ArgumentException();

            var studentsBefore = (_unitOfWork.Groups.GetAsync(groupDto.Id)).Result.Students;

            var studentsForDeleteFromGroup = studentsBefore.Where(stg => !studentsId.Contains(stg.Id)).ToList();///////////////////
            
            //Debug.WriteLine($"Number for DEL : {studentsForDeleteFromGroup.Count}!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            foreach (var st in studentsForDeleteFromGroup)
            {
                await _studentService.DeleteStudentFromGroupAsync(st.Id);
            }

            foreach (var studentId in studentsId)
            {
                await _studentService.AddStudentToGroupAsync(studentId, groupDto.Id);///////////////////////////////////
            }
            var group = _mapper.Map<Group>(groupDto);
            await _unitOfWork.Groups.UpdateAsync(group);

            await _studentRequestService.CloseRequestsAsync(studentsId, group.CourseId);////////////////////////////////
        }

        public async Task DeleteAsync(int id)
        {
           await _unitOfWork.Groups.DeleteAsync(id);
            //_unitOfWork.Save();
        }

        //public async Task AddStudentsToGroupAsync(GroupDTO group, List<int> studentsId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task UpdateStudentsInGroupAsync(GroupDTO group, List<int> studentsId)
        //{
        //    throw new NotImplementedException();
        //}
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
