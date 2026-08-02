using AutoMapper;
using EnterpriseAIEmployeeCopilot.Application.DTOs.Employee;
using EnterpriseAIEmployeeCopilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        //Employee to EmployeeDto mapping//
        public EmployeeProfile() 
        {
            CreateMap<Employee, EmployeeDto>()
                 .ForMember(dest => dest.FullName,
                     opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                 .ForMember(dest => dest.Department,
                     opt => opt.MapFrom(src => src.Department.Name))
                 .ForMember(dest => dest.Designation,
                     opt => opt.MapFrom(src => src.Designation.Name))
                 .ForMember(dest => dest.Role,
                     opt => opt.MapFrom(src => src.Role.Name));

            // Employee -> EmployeeDetailsDto
            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Department,
                    opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Designation,
                    opt => opt.MapFrom(src => src.Designation.Name))
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.ManagerName,
                    opt => opt.MapFrom(src =>
                        src.Manager != null
                            ? src.Manager.FirstName + " " + src.Manager.LastName
                            : null));

            // Create DTO -> Entity
            CreateMap<CreateEmployeeDto, Employee>();

            // Update DTO -> Entity
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
