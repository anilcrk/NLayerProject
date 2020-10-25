using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Model;
using NLayerProject.Core.Services;
using NLayerProject.WebUı.DTOs;
using NLayerProject.WebUI.APIService;

namespace NLayerProject.WebUI.Controllers
{
    public class CategoyController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly CategoryAPIService _categoryAPIService;
        public CategoyController(ICategoryService categoryService,IMapper mapper,CategoryAPIService categoryAPIService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryAPIService = categoryAPIService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryAPIService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var result = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var result = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Remove(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            _categoryService.Remove(_mapper.Map<Category>(category));
            return RedirectToAction("Index");
        }

    }
}