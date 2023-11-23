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
public class CountryController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            var Countryes = await _unitOfWork.Countries.GetAllAsync();
            return _mapper.Map<List<Country>>(Countryes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> Get(int id)
        {
            var Country = await _unitOfWork.Countries.GetByIdAsync(id);
            if(Country == null)
            {
                return NotFound();
            }
            return _mapper.Map<CountryDto>(Country);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Country>> Post(CountryDto CountryDto)
        {
            var Country = _mapper.Map<Country>(CountryDto);
            this._unitOfWork.Countries.Add(Country);
            await _unitOfWork.SaveAsync();
            if(Country == null)
            {
                return BadRequest();
            }
            CountryDto.Id = Country.Id;
            return CreatedAtAction(nameof(Post), new {id = CountryDto.Id}, CountryDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto CountryDto)
        {
            if(CountryDto == null)
            {
                return NotFound();
            }
            var Countryes = _mapper.Map<Country>(CountryDto);
            _unitOfWork.Countries.Update(Countryes);
            await _unitOfWork.SaveAsync();
            return CountryDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Country = await _unitOfWork.Countries.GetByIdAsync(id);
            if(Country == null)
            {
                return NotFound();
            }
            _unitOfWork.Countries.Remove(Country);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }