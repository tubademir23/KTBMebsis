using AutoMapper;
using KTB.API.DTOs;
using KTB.API.Filters;
using KTB.Core.Entities;
using KTB.Core.Services;
using KTB.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MeslekController : ControllerBase
    {
        private readonly IMeslekService _meslekService;
        private readonly IMapper _mapper;
        public MeslekController(IMeslekService meslekService, IMapper mapper)
        {
            _meslekService = meslekService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var meslekler= await _meslekService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<MeslekDto>>(meslekler));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meslek = await _meslekService.GetByIdAsync(id);

            return Ok(_mapper.Map<MeslekDto>(meslek));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(MeslekDto meslekDto)
        {
            var meslek = await _meslekService.AddAsync(_mapper.Map<Meslek>(meslekDto));

            return Created(string.Empty, _mapper.Map<MeslekDto>(meslek));
        }
        [HttpPut]
        public IActionResult Update(MeslekDto meslekDto)
        {
            var meslek = _meslekService.Update(_mapper.Map<Meslek>(meslekDto));

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var meslek = _meslekService.GetByIdAsync(id).Result;
            _meslekService.Remove(meslek);
            return NoContent();
        }

    }
}
