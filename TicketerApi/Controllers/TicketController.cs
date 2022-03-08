using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;
using TicketerApi.Services;

namespace TicketerApi.Controllers
{
    public class TicketController : Controller
    {
        private IGenericDataService<Ticket> _dataService;

        public TicketController(ApplicationDbContext context)
        {
            DataServiceFactory factory = new DataServiceFactory(context);
            IDataService dataService = factory.GetDataService(typeof(Ticket));
            _dataService = dataService as IGenericDataService<Ticket>;
        }

        [HttpPost("ticket")]
        public async Task<ActionResult<Ticket>> AddTicket(Ticket ticket)
        {
            try
            {
                return Ok(await _dataService.AddAsync(ticket));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ticket")]
        public async Task<ActionResult> DeleteTicket(Ticket ticket)
        {
            try
            {
                await _dataService.DeleteAsync(ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ticket")]
        public async Task<ActionResult> EditTicket(Ticket ticket)
        {
            try
            {
                await _dataService.EditAsync(ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Ticket>>> GetTicket()
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
        public async Task<ActionResult<Ticket>> GetTicket(int id)
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