using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Task.Application.Common.Exceptions;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Interfaces;
using Task.Domain.Entities;
using Task.Infrastructure.Specifications.CVSpecifications;

namespace Task.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<Department> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseVM<List<DepartmentModel>>> GetDepartments()
        {
            var departmentList = await _repository.ListAsync();
            var Data = _mapper.Map<List<DepartmentModel>>(departmentList);
            return new ResponseVM<List<DepartmentModel>>()
            {
                Data = Data
            };
        }

        public async Task<ResponseVM<DepartmentModel>> GetDepartmentById(int id)
        {
            var spec = new getDepartmentByIdSpec(id);
            var GetBySpec = await _repository.GetBySpecAsync(spec);
            var Data = _mapper.Map<DepartmentModel>(GetBySpec);
            return new ResponseVM<DepartmentModel>()
            {
                Data = Data
            };
        }

        public async Task<ResponseVM<DepartmentSummaryModel>> GetDepartmentSummaryById(int id)
        {
            var spec = new getDepartmentByIdSpec(id);
            var GetBySpec = await _repository.GetBySpecAsync(spec);
            var Data = _mapper.Map<DepartmentSummaryModel>(GetBySpec);
            return new ResponseVM<DepartmentSummaryModel>()
            {
                Data = Data
            };
        }

        public async Task<ResponseVM<List<DepartmentModel>>> GetFilterDepartment(string search)
        {
            var spec = new getFilterDepartmentsSpec(search);
            var departmentList = await _repository.ListAsync(spec);
            var Data = _mapper.Map<List<DepartmentModel>>(departmentList);
            return new ResponseVM<List<DepartmentModel>>()
            {
                Data = Data
            };
        }

        public async Task<ResponseVM> AddDepartment(DepartmentModel departmentModel)
        {
            var departmentEntity = _mapper.Map<Department>(departmentModel);
            await _repository.AddAsync(departmentEntity);
            return new ResponseVM
            {
                Data = departmentEntity.Id
            };
        }

        public async Task<ResponseVM> EditDepartment(DepartmentModel departmentModel)
        {
            var departmentEntity = _mapper.Map<Department>(departmentModel);
            await _repository.UpdateAsync(departmentEntity);
            return new ResponseVM
            {
                Data = departmentEntity.Id
            };
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var GetBySpec = new getDepartmentByIdSpec(id);
            var dep = await _repository.GetBySpecAsync(GetBySpec);
            if (dep == null)
                throw new ValidationException(new ValidationFailure[] { new ValidationFailure("Get Department Error", $"Department with ID {id} : not exist") });
            if(dep.Employees.Count > 0)
                return false;
            await _repository.DeleteAsync(dep);
            return true;
        }

  
    }
}
