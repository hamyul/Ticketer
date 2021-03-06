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
        private IGenericDataService<User> _dataService;

        public UserController(ApplicationDbContext context)
        {
            DataServiceFactory factory = new DataServiceFactory(context);
            IDataService dataService = factory.GetDataService(typeof(User));
            _dataService = dataService as IGenericDataService<User>;
        }

        [HttpPost("user")]
        public async Task<ActionResult<User>> AddUser(User user)
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
        public async Task<ActionResult> DeleteUser(User user)
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
        public async Task<ActionResult> EditUser(User user)
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
        public async Task<ActionResult<List<User>>> GetUser()
        {
            try
            {
                return Ok(await _dataService.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                return Ok(await _dataService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}