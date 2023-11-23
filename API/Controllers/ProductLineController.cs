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
public class ProductLineController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductLineController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductLine>>> Get()
        {
            var ProductLinees = await _unitOfWork.ProductLines.GetAllAsync();
            return _mapper.Map<List<ProductLine>>(ProductLinees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductLineDto>> Get(int id)
        {
            var ProductLine = await _unitOfWork.ProductLines.GetByIdAsync(id);
            if(ProductLine == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProductLineDto>(ProductLine);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLine>> Post(ProductLineDto ProductLineDto)
        {
            var ProductLine = _mapper.Map<ProductLine>(ProductLineDto);
            this._unitOfWork.ProductLines.Add(ProductLine);
            await _unitOfWork.SaveAsync();
            if(ProductLine == null)
            {
                return BadRequest();
            }
            ProductLineDto.Id = ProductLine.Id;
            return CreatedAtAction(nameof(Post), new {id = ProductLineDto.Id}, ProductLineDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductLineDto>> Put(int id, [FromBody] ProductLineDto ProductLineDto)
        {
            if(ProductLineDto == null)
            {
                return NotFound();
            }
            var ProductLinees = _mapper.Map<ProductLine>(ProductLineDto);
            _unitOfWork.ProductLines.Update(ProductLinees);
            await _unitOfWork.SaveAsync();
            return ProductLineDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ProductLine = await _unitOfWork.ProductLines.GetByIdAsync(id);
            if(ProductLine == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductLines.Remove(ProductLine);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }