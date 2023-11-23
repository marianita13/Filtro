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
public class PersonController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var Persones = await _unitOfWork.Persons.GetAllAsync();
            return _mapper.Map<List<Person>>(Persones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var Person = await _unitOfWork.Persons.GetByIdAsync(id);
            if(Person == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonDto>(Person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post(PersonDto PersonDto)
        {
            var Person = _mapper.Map<Person>(PersonDto);
            this._unitOfWork.Persons.Add(Person);
            await _unitOfWork.SaveAsync();
            if(Person == null)
            {
                return BadRequest();
            }
            PersonDto.Id = Person.Id;
            return CreatedAtAction(nameof(Post), new {id = PersonDto.Id}, PersonDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto PersonDto)
        {
            if(PersonDto == null)
            {
                return NotFound();
            }
            var Persones = _mapper.Map<Person>(PersonDto);
            _unitOfWork.Persons.Update(Persones);
            await _unitOfWork.SaveAsync();
            return PersonDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Person = await _unitOfWork.Persons.GetByIdAsync(id);
            if(Person == null)
            {
                return NotFound();
            }
            _unitOfWork.Persons.Remove(Person);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }