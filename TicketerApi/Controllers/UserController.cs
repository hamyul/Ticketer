using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;
using TicketerApi.Services;

namespace TicketerApi.Controllers
{
    public class UserController : Controller
    {
        private DataService _dataService;

        public UserController(ApplicationDbContext context)
        {
            _dataService = new DataService(context);
        }

        [HttpPost("user")]
        public async Task<ActionResult<User>> Add(User user)
        {
            try
            {
                return Ok(await _dataService.AddAsync(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("user")]
        public async Task<ActionResult> Delete(User user)
        {
            try
            {
                await _dataService.DeleteAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("user")]
        public async Task<ActionResult> Edit(User user)
        {
            try
            {
                await _dataService.EditAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                return Ok(await _dataService.GetUserAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                return Ok(await _dataService.GetUserAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}