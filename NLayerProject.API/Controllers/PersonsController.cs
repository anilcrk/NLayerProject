using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Model;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;
        private readonly IMapper _mapper;
        public PersonsController(IService<Person> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personels = await _service.GetAllAsync();
            return Ok(personels);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            var personResult = await _service.AddAsync(person);
            return Created(string.Empty,personResult);
        }
    }
}