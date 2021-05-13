﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackingSystem.BLL.Interfaces;
using TaskTrackingSystem.BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using TaskTrackingSystem.ViewModels;


namespace TaskTrackingSystem.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    //[Authorize]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projService;

        public ProjectController(IProjectService projService)
        {
            _projService = projService;
        }

        //[AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IEnumerable<ProjectDTO> Get()
        {
            var projects = _projService.GetAllProjects();
            return projects;
        }
        [AllowAnonymous]
        [HttpPost]
        public void AddProject([FromQuery] ProjectView proj)
        {
            var newProj = new ProjectDTO()
            {
                ClientEmail = proj.ClientEmail,
                Description = proj.Description,
                EndTime = proj.EndTime,
                Name = proj.Name,
                PercentCompletion = 0,
                Status = proj.StartTime > DateTime.Now ? BLL.Enums.StatusDTO.Pending : BLL.Enums.StatusDTO.Started,
                StartTime = proj.StartTime,
            };

            _projService.AddProject(newProj);
        }
        [Authorize(Roles = "Admin, Manager")]
        public void Delete([FromQuery] ProjectView proj)
        {
            var project = new ProjectDTO()
            {
                ClientEmail = proj.ClientEmail,
                Description = proj.Description,
                EndTime = proj.EndTime,
                Name = proj.Name,
                PercentCompletion = 0,
                Status = proj.StartTime > DateTime.Now ? BLL.Enums.StatusDTO.Pending : BLL.Enums.StatusDTO.Started,
                StartTime = proj.StartTime,
            };

            _projService.DeleteProject(project);
        }
        [HttpPut]
        [Authorize(Roles = "Admin, Manager")]
        public void EditProject([FromQuery] ProjectView proj)
        {
            var project = new ProjectDTO()
            {
                ClientEmail = proj.ClientEmail,
                Description = proj.Description,
                EndTime = proj.EndTime,
                Name = proj.Name,
                PercentCompletion = 0,
                Status = proj.StartTime > DateTime.Now ? BLL.Enums.StatusDTO.Pending : BLL.Enums.StatusDTO.Started,
                StartTime = proj.StartTime,
            };

            _projService.EditProject(project);
        }
    }
}