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
public class MethodPaymentController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MethodPaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MethodPayment>>> Get()
        {
            var MethodPaymentes = await _unitOfWork.MethodPayments.GetAllAsync();
            return _mapper.Map<List<MethodPayment>>(MethodPaymentes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodPaymentDto>> Get(int id)
        {
            var MethodPayment = await _unitOfWork.MethodPayments.GetByIdAsync(id);
            if(MethodPayment == null)
            {
                return NotFound();
            }
            return _mapper.Map<MethodPaymentDto>(MethodPayment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MethodPayment>> Post(MethodPaymentDto MethodPaymentDto)
        {
            var MethodPayment = _mapper.Map<MethodPayment>(MethodPaymentDto);
            this._unitOfWork.MethodPayments.Add(MethodPayment);
            await _unitOfWork.SaveAsync();
            if(MethodPayment == null)
            {
                return BadRequest();
            }
            MethodPaymentDto.Id = MethodPayment.Id;
            return CreatedAtAction(nameof(Post), new {id = MethodPaymentDto.Id}, MethodPaymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodPaymentDto>> Put(int id, [FromBody] MethodPaymentDto MethodPaymentDto)
        {
            if(MethodPaymentDto == null)
            {
                return NotFound();
            }
            var MethodPaymentes = _mapper.Map<MethodPayment>(MethodPaymentDto);
            _unitOfWork.MethodPayments.Update(MethodPaymentes);
            await _unitOfWork.SaveAsync();
            return MethodPaymentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var MethodPayment = await _unitOfWork.MethodPayments.GetByIdAsync(id);
            if(MethodPayment == null)
            {
                return NotFound();
            }
            _unitOfWork.MethodPayments.Remove(MethodPayment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }