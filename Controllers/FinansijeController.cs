using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APISystem.Entity;
using UniAPISystem.Models;
using UniAPISystem.Interface;
using UniAPISystem.DtoModels;
using Microsoft.AspNetCore.Authorization;

namespace UniAPISystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinansijeController : ControllerBase
    {
        private readonly IFinansijeService _finansijeService;

        public FinansijeController(IFinansijeService finansijeService)
        {
            _finansijeService = finansijeService;
        }


        [HttpGet] //sve 
        public async Task<IActionResult> GetAllFinansijeAsync()
        {
            var finansije = await _finansijeService.GetAllFinansijeAsync();
            return Ok(finansije);
        }

        [HttpGet("{id}")] //po ID
        public async Task<IActionResult> GetFinansijeWithIdAsync([FromRoute] int id)
        {
            var finansije = await _finansijeService.GetFinansijeByIdAsync(id);

            if (finansije == null)
            {
                return NotFound($"Ovakvo finansiranje ne postoji");
            }

            return Ok(finansije);
        }

        [HttpPost] //novo
        public async Task<IActionResult> AddFinansijeAsync([FromBody] FinansijeCreateDto finansijeDto)
        {
            await _finansijeService.AddFinansijeAsync(finansijeDto);
            return Ok("Departmant dodat uspesno!");
        }



    }





}

