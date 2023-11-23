using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Api.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class PostalCodeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostalCodeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PostalCode>>> Get()
        {
            var PostalCodees = await _unitOfWork.PostalCodes.GetAllAsync();
            return _mapper.Map<List<PostalCode>>(PostalCodees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostalCodeDto>> Get(int id)
        {
            var PostalCode = await _unitOfWork.PostalCodes.GetByIdAsync(id);
            if(PostalCode == null)
            {
                return NotFound();
            }
            return _mapper.Map<PostalCodeDto>(PostalCode);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostalCode>> Post(PostalCodeDto PostalCodeDto)
        {
            var PostalCode = _mapper.Map<PostalCode>(PostalCodeDto);
            this._unitOfWork.PostalCodes.Add(PostalCode);
            await _unitOfWork.SaveAsync();
            if(PostalCode == null)
            {
                return BadRequest();
            }
            PostalCodeDto.Id = PostalCode.Id;
            return CreatedAtAction(nameof(Post), new {id = PostalCodeDto.Id}, PostalCodeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostalCodeDto>> Put(int id, [FromBody] PostalCodeDto PostalCodeDto)
        {
            if(PostalCodeDto == null)
            {
                return NotFound();
            }
            var PostalCodees = _mapper.Map<PostalCode>(PostalCodeDto);
            _unitOfWork.PostalCodes.Update(PostalCodees);
            await _unitOfWork.SaveAsync();
            return PostalCodeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var PostalCode = await _unitOfWork.PostalCodes.GetByIdAsync(id);
            if(PostalCode == null)
            {
                return NotFound();
            }
            _unitOfWork.PostalCodes.Remove(PostalCode);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }