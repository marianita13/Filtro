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
public class EmployeeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var Employeees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<List<Employee>>(Employeees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var Employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if(Employee == null)
            {
                return NotFound();
            }
            return _mapper.Map<EmployeeDto>(Employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Post(EmployeeDto EmployeeDto)
        {
            var Employee = _mapper.Map<Employee>(EmployeeDto);
            this._unitOfWork.Employees.Add(Employee);
            await _unitOfWork.SaveAsync();
            if(Employee == null)
            {
                return BadRequest();
            }
            EmployeeDto.Id = Employee.Id;
            return CreatedAtAction(nameof(Post), new {id = EmployeeDto.Id}, EmployeeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto EmployeeDto)
        {
            if(EmployeeDto == null)
            {
                return NotFound();
            }
            var Employeees = _mapper.Map<Employee>(EmployeeDto);
            _unitOfWork.Employees.Update(Employeees);
            await _unitOfWork.SaveAsync();
            return EmployeeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if(Employee == null)
            {
                return NotFound();
            }
            _unitOfWork.Employees.Remove(Employee);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }