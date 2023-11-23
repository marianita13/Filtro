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
public class PaymentController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            var Paymentes = await _unitOfWork.Payments.GetAllAsync();
            return _mapper.Map<List<Payment>>(Paymentes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDto>> Get(int id)
        {
            var Payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if(Payment == null)
            {
                return NotFound();
            }
            return _mapper.Map<PaymentDto>(Payment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Payment>> Post(PaymentDto PaymentDto)
        {
            var Payment = _mapper.Map<Payment>(PaymentDto);
            this._unitOfWork.Payments.Add(Payment);
            await _unitOfWork.SaveAsync();
            if(Payment == null)
            {
                return BadRequest();
            }
            PaymentDto.Id = Payment.Id;
            return CreatedAtAction(nameof(Post), new {id = PaymentDto.Id}, PaymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDto>> Put(int id, [FromBody] PaymentDto PaymentDto)
        {
            if(PaymentDto == null)
            {
                return NotFound();
            }
            var Paymentes = _mapper.Map<Payment>(PaymentDto);
            _unitOfWork.Payments.Update(Paymentes);
            await _unitOfWork.SaveAsync();
            return PaymentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if(Payment == null)
            {
                return NotFound();
            }
            _unitOfWork.Payments.Remove(Payment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }