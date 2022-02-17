﻿using ComputerRepair.Data;
using ComputerRepair.Enteties;
using ComputerRepair.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepair.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeeController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task Post(Employee employee)
        {
            await _repository.Add(employee);
        }

        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            var items = await _repository.GetAll();
            return items;
        }
    }
}
