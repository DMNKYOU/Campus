using AutoMapper;
using System;
using System.Collections.Generic;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;

namespace CampusCRM.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IStudentService _studentService;
        public GroupService(IUnitOfWork unitOfWork, IStudentService studentService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _studentService = studentService;
        }
        public void AddGroup(GroupDTO groupDto)
        {
            if (groupDto == null)
                throw new ArgumentException();

            var group = _mapper.Map<Group>(groupDto);

            _unitOfWork.Groups.Create(group);
            _unitOfWork.Save();
        }

        public void DeleteGroup(int id)
        {
            _unitOfWork.Groups.Delete(id);
            _unitOfWork.Save();
        }


        public void EditGroup(GroupDTO groupDto)
        {
            if (groupDto == null)
                throw new ArgumentException();

            var group = _mapper.Map<Group>(groupDto);

            _unitOfWork.Groups.Update(group);
            _unitOfWork.Save();
        }

        public GroupDTO GetGroup(int id)
        {
            var group = _unitOfWork.Groups.Get(id);

            return _mapper.Map<GroupDTO>(group);
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            var groups = _unitOfWork.Groups.GetAll();
            return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
