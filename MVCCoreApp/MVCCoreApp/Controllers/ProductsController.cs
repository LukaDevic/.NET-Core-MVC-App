using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Abstractions;
using MVCCoreApp.Data.Dtos;
using MVCCoreApp.Data.Models;
using MVCCoreApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVCCoreApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<Product> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productsRepository.GetAllAsync();
            var viewModel = new ProductsViewModel
            {
                Products = products
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productDto);
                await _productsRepository.AddAsync(product);
                return RedirectToAction("Index");
            }

            return View(productDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var productFromDb = await _productsRepository.GetAsync(id);
            if(productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _productsRepository.UpdateAsync(product);

            return RedirectToAction("Index");
        }
}