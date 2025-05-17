using Ardalis.SharedKernel;
using AutoMapper;
using Task.Application.Common.Response;
using Task.Application.Interfaces;
using Task.Domain.Entities;
using Task.Application.Features.ViewModels.Task;
using Task.Infrastructure.Specifications.TaskSpecifications;

namespace Task.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskAssignment> _repository;
        private readonly IMapper _mapper;

        public TaskService(IRepository<TaskAssignment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseVM<List<EmployeeTaskItemModel>>> GetEmployeeTasks(int ManagerId)
        {
            var spec = new getEmployeeTasksSpec(ManagerId);
            var employeeList = await _repository.ListAsync(spec);
            var Data = _mapper.Map<List<EmployeeTaskItemModel>>(employeeList);
            return new ResponseVM<List<EmployeeTaskItemModel>>()
            {
                Data = Data
            };
        }
        public async Task<ResponseVM> AssignTaskToEmployee(EmployeeTaskRequestModel employeeTaskRequest)
        {
            var taskEntity = _mapper.Map<TaskAssignment>(employeeTaskRequest);
            await _repository.AddAsync(taskEntity);
            return new ResponseVM
            {
                Data = taskEntity.Id
            };
        }
    }
}
