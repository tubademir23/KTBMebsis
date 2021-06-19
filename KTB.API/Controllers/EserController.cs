using AutoMapper;
using KTB.API.DTOs;
using KTB.API.Filters;
using KTB.Core.Entities;
using KTB.Core.Services;
using KTB.Data;
using KTB.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EserController : Controller
    {

        private readonly IEserService _eserService;
        private readonly IMapper _mapper;
        public EserController(IEserService eserService, IMapper mapper)
        {
            _eserService = eserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           // global exception handling için test amaçlı eklenmiştir.
           //throw new Exception("Deneme amaçlıdır!");
            var eserler = await _eserService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<EserDto>>(eserler));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eser = await _eserService.GetByIdAsync(id);

            return Ok(_mapper.Map<EserDto>(eser));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(EserDto eserDto)
        {
            var eser = await _eserService.AddAsync(_mapper.Map<Eser>(eserDto));

            return Created(string.Empty, _mapper.Map<EserDto>(eser));
        }
        [HttpPut]
        public IActionResult Update(EserDto eserDto)
        {
            var eser = _eserService.Update(_mapper.Map<Eser>(eserDto));

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var eser = _eserService.GetByIdAsync(id).Result;
            _eserService.Remove(eser);
            return NoContent();
        }
        [HttpGet("{id}/uye")]
        public async Task<ActionResult> GetWithUyeByIdAsync(int eserId)
        {
            var eser = await _eserService.GetWithUyeByIdAsync(eserId);
            return Ok(_mapper.Map<EserWithUyeDto>(eser));
        }
    }
}
