﻿using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.DepartmentSpecifications
{
    public class getDepartmentByIdSpec : Specification<Department>
    {
        public getDepartmentByIdSpec(int id)
        {
            Query.Where(n => n.Id == id).Include(n => n.Employees);
        }
    }

}
