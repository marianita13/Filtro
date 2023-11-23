
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
public class ClientController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            var Clientes = await _unitOfWork.Clients.GetAllAsync();
            return _mapper.Map<List<Client>>(Clientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDto>> Get(int id)
        {
            var Client = await _unitOfWork.Clients.GetByIdAsync(id);
            if(Client == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClientDto>(Client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> Post(ClientDto ClientDto)
        {
            var Client = _mapper.Map<Client>(ClientDto);
            this._unitOfWork.Clients.Add(Client);
            await _unitOfWork.SaveAsync();
            if(Client == null)
            {
                return BadRequest();
            }
            ClientDto.Id = Client.Id;
            return CreatedAtAction(nameof(Post), new {id = ClientDto.Id}, ClientDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto ClientDto)
        {
            if(ClientDto == null)
            {
                return NotFound();
            }
            var Clientes = _mapper.Map<Client>(ClientDto);
            _unitOfWork.Clients.Update(Clientes);
            await _unitOfWork.SaveAsync();
            return ClientDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Client = await _unitOfWork.Clients.GetByIdAsync(id);
            if(Client == null)
            {
                return NotFound();
            }
            _unitOfWork.Clients.Remove(Client);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }