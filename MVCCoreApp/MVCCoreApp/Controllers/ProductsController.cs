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

}