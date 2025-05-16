using Ardalis.SharedKernel;
using AutoMapper;
using Task.Application.Common.Exceptions;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;
using Task.Domain.Entities;
using Task.Infrastructure.Specifications.CVSpecifications;
using FluentValidation.Results;

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
        public async Task<ResponseVM<EmployeeModel>> GetEmployeeById(int id)
        {
            var spec = new getEmployeeByIdSpec(id);
            var GetBySpec = await _repository.GetBySpecAsync(spec);
            var Data = _mapper.Map<EmployeeModel>(GetBySpec);
            return new ResponseVM<EmployeeModel>()
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
        public async Task<ResponseVM> EditEmployee(EmployeeRequestModel employeeRequest)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeRequest);
            await _repository.UpdateAsync(employeeEntity);
            return new ResponseVM
            {
                Data = employeeEntity.Id
            };
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var GetBySpec = new getEmployeeByIdSpec(id);
            var emp = await _repository.GetBySpecAsync(GetBySpec);
            if (emp == null)
                throw new ValidationException(new ValidationFailure[] { new ValidationFailure("Get Emplyee Error", $"Employee with ID {id} : not exist") });
            await _repository.DeleteAsync(emp);
            return true;
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

        public async Task<ResponseVM<List<EmployeeModel>>> GetFilterEmployees(string search)
        {
            var spec = new getFilterEmployeesSpec(search);
            var employeeList = await _repository.ListAsync(spec);
            var Data = _mapper.Map<List<EmployeeModel>>(employeeList);
            return new ResponseVM<List<EmployeeModel>>()
            {
                Data = Data
            };
        }

    }
}
