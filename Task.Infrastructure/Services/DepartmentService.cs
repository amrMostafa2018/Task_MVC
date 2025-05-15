using Ardalis.SharedKernel;
using AutoMapper;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;
using Task.Domain.Entities;

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


        public async Task<ResponseVM> AddDepartment(EmployeeRequestModel employeeRequest)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeRequest);
           // await _repository.AddAsync(employeeEntity);
            return new ResponseVM
            {
                Data = employeeEntity.Id
            };
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
    }
}
