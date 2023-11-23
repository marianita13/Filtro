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
public class OrderController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var Orderes = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<List<Order>>(Orderes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var Order = await _unitOfWork.Orders.GetByIdAsync(id);
            if(Order == null)
            {
                return NotFound();
            }
            return _mapper.Map<OrderDto>(Order);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Post(OrderDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            this._unitOfWork.Orders.Add(Order);
            await _unitOfWork.SaveAsync();
            if(Order == null)
            {
                return BadRequest();
            }
            OrderDto.Id = Order.Id;
            return CreatedAtAction(nameof(Post), new {id = OrderDto.Id}, OrderDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderDto OrderDto)
        {
            if(OrderDto == null)
            {
                return NotFound();
            }
            var Orderes = _mapper.Map<Order>(OrderDto);
            _unitOfWork.Orders.Update(Orderes);
            await _unitOfWork.SaveAsync();
            return OrderDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Order = await _unitOfWork.Orders.GetByIdAsync(id);
            if(Order == null)
            {
                return NotFound();
            }
            _unitOfWork.Orders.Remove(Order);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }