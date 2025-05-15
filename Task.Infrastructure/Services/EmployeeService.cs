using Ardalis.SharedKernel;
using AutoMapper;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;
using Task.Domain.Entities;
using Task.Infrastructure.Specifications.CVSpecifications;

namespace Task.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseVM<List<EmployeeModel>>> GetEmployees()
        {
            var spec = new getAllEmployeesSpec();
            var employeeList = await _repository.ListAsync(spec);
            var Data = _mapper.Map<List<EmployeeModel>>(employeeList);
            return new ResponseVM<List<EmployeeModel>>()
            {
                Data = Data
            };
        }
        public async Task<ResponseVM> AddEmployee(EmployeeRequestModel employeeRequest)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeRequest);
            await _repository.AddAsync(employeeEntity);
            return new ResponseVM
            {
                Data = employeeEntity.Id
            };
        }

        public async Task<ResponseVM<List<ManagerModel>>> GetManagers()
        {
            var spec = new getAllManagersSpec();
            var managerList = await _repository.ListAsync(spec);
            var Data = _mapper.Map<List<ManagerModel>>(managerList);
            return new ResponseVM<List<ManagerModel>>()
            {
                Data = Data
            };
        }
    }
}
