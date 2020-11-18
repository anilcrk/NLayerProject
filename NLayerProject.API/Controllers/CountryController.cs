using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Model;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidationFilter]
    public class CountryController : ControllerBase
    {
        private readonly IService<Country> _service;
        private readonly IMapper _mapper;
        public CountryController(IService<Country> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CountyDto>>(countries));
        }
    }
}