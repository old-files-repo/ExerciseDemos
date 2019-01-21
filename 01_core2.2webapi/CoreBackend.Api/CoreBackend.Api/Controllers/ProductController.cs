using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreBackend.Api.Dtos;
using CoreBackend.Api.Entities;
using CoreBackend.Api.Repositories;
using CoreBackend.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CoreBackend.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ILogger<ProductController> _logger; // interface 不是具体的实现类
        private readonly IMailService _localMailService;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger,
            IMailService localMailService,
            IProductRepository productRepository)
        {
            _logger = logger;
            _localMailService = localMailService;
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductCreation product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (product.Name == "产品")
            {
                ModelState.AddModelError("Name", "产品的名称不可以是'产品'二字");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProduct = Mapper.Map<Product>(product);
            _productRepository.AddProduct(newProduct);
            if (!_productRepository.Save())
            {
                return StatusCode(500, "保存产品的时候出错");
            }

            var dto = Mapper.Map<ProductWithoutMaterialDto>(newProduct);

            return CreatedAtRoute("GetProduct", new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductModification productModificationDto)
        {
            if (productModificationDto == null)
            {
                return BadRequest();
            }

            if (productModificationDto.Name == "产品")
            {
                ModelState.AddModelError("Name", "产品的名称不可以是'产品'二字");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            Mapper.Map(productModificationDto, product);
            if (!_productRepository.Save())
            {
                return StatusCode(500, "保存产品的时候出错");
            }

            // return Ok(model);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ProductModification> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var productEntity = _productRepository.GetProduct(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            var toPatch = Mapper.Map<ProductModification>(productEntity);
            patchDoc.ApplyTo(toPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (toPatch.Name == "产品")
            {
                ModelState.AddModelError("Name", "产品的名称不可以是'产品'二字");
            }
            TryValidateModel(toPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(toPatch, productEntity);

            if (!_productRepository.Save())
            {
                return StatusCode(500, "更新的时候出错");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = _productRepository.GetProduct(id);
            if (model == null)
            {
                return NotFound();
            }
            _productRepository.DeleteProduct(model);
            if (!_productRepository.Save())
            {
                return StatusCode(500, "删除的时候出错");
            }
            _localMailService.Send("ProductDto Deleted", $"Id为{id}的产品被删除了");
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            var results = Mapper.Map<IEnumerable<ProductWithoutMaterialDto>>(products);
            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProducts(int id, bool includeMaterial = false)
        {
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            if (includeMaterial)
            {
                var productWithMaterialResult = Mapper.Map<ProductDto>(product);
                return Ok(productWithMaterialResult);
            }

            var onlyProductResult = Mapper.Map<ProductWithoutMaterialDto>(product);
            return Ok(onlyProductResult);
        }
    }
}
