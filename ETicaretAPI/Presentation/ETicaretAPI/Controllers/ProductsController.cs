﻿using ETicaretAPI.Application.Repositories.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public ProductsController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        [HttpGet]

        public async Task Get()
        {
            await _writeRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product1", CreatedDate =DateTime.UtcNow, Stock = 100},
                new() {Id = Guid.NewGuid(), Name = "Product2", CreatedDate =DateTime.UtcNow, Stock = 10},
                new() {Id = Guid.NewGuid(), Name = "Product3", CreatedDate =DateTime.UtcNow, Stock = 50},
            });
            await _writeRepository.SaveAsync();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
          Product product =   await _readRepository.GetByIdAsync(id);
            return Ok(product);
        }


    }
}
