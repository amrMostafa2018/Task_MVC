﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.ViewModels.Employee;

namespace Task.Application.Features.ViewModels.Department
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.Department, DepartmentModel>()
                .ReverseMap();

            }
        }
    }
}
