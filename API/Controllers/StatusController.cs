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
public class StatusController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Status>>> Get()
        {
            var Statuses = await _unitOfWork.Statuses.GetAllAsync();
            return _mapper.Map<List<Status>>(Statuses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatusDto>> Get(int id)
        {
            var Status = await _unitOfWork.Statuses.GetByIdAsync(id);
            if(Status == null)
            {
                return NotFound();
            }
            return _mapper.Map<StatusDto>(Status);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Status>> Post(StatusDto StatusDto)
        {
            var Status = _mapper.Map<Status>(StatusDto);
            this._unitOfWork.Statuses.Add(Status);
            await _unitOfWork.SaveAsync();
            if(Status == null)
            {
                return BadRequest();
            }
            StatusDto.Id = Status.Id;
            return CreatedAtAction(nameof(Post), new {id = StatusDto.Id}, StatusDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatusDto>> Put(int id, [FromBody] StatusDto StatusDto)
        {
            if(StatusDto == null)
            {
                return NotFound();
            }
            var Statuses = _mapper.Map<Status>(StatusDto);
            _unitOfWork.Statuses.Update(Statuses);
            await _unitOfWork.SaveAsync();
            return StatusDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Status = await _unitOfWork.Statuses.GetByIdAsync(id);
            if(Status == null)
            {
                return NotFound();
            }
            _unitOfWork.Statuses.Remove(Status);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }