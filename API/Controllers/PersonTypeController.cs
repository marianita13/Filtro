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
public class PersonTypeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonType>>> Get()
        {
            var PersonTypees = await _unitOfWork.PersonTypes.GetAllAsync();
            return _mapper.Map<List<PersonType>>(PersonTypees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonTypeDto>> Get(int id)
        {
            var PersonType = await _unitOfWork.PersonTypes.GetByIdAsync(id);
            if(PersonType == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonTypeDto>(PersonType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonType>> Post(PersonTypeDto PersonTypeDto)
        {
            var PersonType = _mapper.Map<PersonType>(PersonTypeDto);
            this._unitOfWork.PersonTypes.Add(PersonType);
            await _unitOfWork.SaveAsync();
            if(PersonType == null)
            {
                return BadRequest();
            }
            PersonTypeDto.Id = PersonType.Id;
            return CreatedAtAction(nameof(Post), new {id = PersonTypeDto.Id}, PersonTypeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto PersonTypeDto)
        {
            if(PersonTypeDto == null)
            {
                return NotFound();
            }
            var PersonTypees = _mapper.Map<PersonType>(PersonTypeDto);
            _unitOfWork.PersonTypes.Update(PersonTypees);
            await _unitOfWork.SaveAsync();
            return PersonTypeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var PersonType = await _unitOfWork.PersonTypes.GetByIdAsync(id);
            if(PersonType == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonTypes.Remove(PersonType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }