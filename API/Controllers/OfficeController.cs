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
public class OfficeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfficeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Office>>> Get()
        {
            var Officees = await _unitOfWork.Offices.GetAllAsync();
            return _mapper.Map<List<Office>>(Officees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Get(int id)
        {
            var Office = await _unitOfWork.Offices.GetByIdAsync(id);
            if(Office == null)
            {
                return NotFound();
            }
            return _mapper.Map<OfficeDto>(Office);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Office>> Post(OfficeDto OfficeDto)
        {
            var Office = _mapper.Map<Office>(OfficeDto);
            this._unitOfWork.Offices.Add(Office);
            await _unitOfWork.SaveAsync();
            if(Office == null)
            {
                return BadRequest();
            }
            OfficeDto.Id = Office.Id;
            return CreatedAtAction(nameof(Post), new {id = OfficeDto.Id}, OfficeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OfficeDto>> Put(int id, [FromBody] OfficeDto OfficeDto)
        {
            if(OfficeDto == null)
            {
                return NotFound();
            }
            var Officees = _mapper.Map<Office>(OfficeDto);
            _unitOfWork.Offices.Update(Officees);
            await _unitOfWork.SaveAsync();
            return OfficeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Office = await _unitOfWork.Offices.GetByIdAsync(id);
            if(Office == null)
            {
                return NotFound();
            }
            _unitOfWork.Offices.Remove(Office);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }