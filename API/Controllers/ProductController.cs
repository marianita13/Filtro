using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ProductController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var Productes = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<Product>>(Productes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var Product = await _unitOfWork.Products.GetByIdAsync(id);
            if(Product == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProductDto>(Product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            this._unitOfWork.Products.Add(Product);
            await _unitOfWork.SaveAsync();
            if(Product == null)
            {
                return BadRequest();
            }
            ProductDto.Id = Product.Id;
            return CreatedAtAction(nameof(Post), new {id = ProductDto.Id}, ProductDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductDto ProductDto)
        {
            if(ProductDto == null)
            {
                return NotFound();
            }
            var Productes = _mapper.Map<Product>(ProductDto);
            _unitOfWork.Products.Update(Productes);
            await _unitOfWork.SaveAsync();
            return ProductDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _unitOfWork.Products.GetByIdAsync(id);
            if(Product == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(Product);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }