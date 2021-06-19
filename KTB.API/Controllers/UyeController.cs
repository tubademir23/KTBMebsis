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
    public class UyeController : ControllerBase
    {

        private readonly IUyeService _uyeService;
        private readonly IMapper _mapper;
        public UyeController(IUyeService uyeService, IMapper mapper)
        {
            _uyeService =uyeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var uyeler = await _uyeService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<UyeDto>>(uyeler));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var uye = await _uyeService.GetByIdAsync(id);

            return Ok(_mapper.Map<UyeDto>(uye));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(UyeDto uyeDto)
        {
            var uye = await _uyeService.AddAsync(_mapper.Map<Uye>(uyeDto));

            return Created(string.Empty, _mapper.Map<UyeDto>(uye));
        }
        [HttpPut]
        public IActionResult Update(UyeDto uyeDto)
        {
            var uye = _uyeService.Update(_mapper.Map<Uye>(uyeDto));

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var uye = _uyeService.GetByIdAsync(id).Result;
            _uyeService.Remove(uye);
            return NoContent();
        }
        [HttpGet("{id}/eserler")]
        public async Task<IActionResult> GetWithEserByIdAsync(int uyeId)
        {
            var uye = await _uyeService.GetWithEserByIdAsync(uyeId);
            return Ok(_mapper.Map<UyeWithEserDto>(uye));
        }
    }
}
