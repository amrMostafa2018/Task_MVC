using Ardalis.SharedKernel;
using AutoMapper;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;
using Task.Application.Interfaces;
using Task.Domain.Entities;

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
        public async Task<ResponseVM> AddEmployee(EmployeeRequestModel employeeRequest)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeRequest);
            await _repository.AddAsync(employeeEntity);
            return new ResponseVM
            {
                Data = employeeEntity.Id
            };
        }
    }
}
