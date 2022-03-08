using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApi.Data;
using TicketerApi.Services;

namespace TicketerApi.Controllers
{
    public class ProjectController : Controller
    {
        private IGenericDataService<Project> _dataService;

        public ProjectController(ApplicationDbContext context)
        {
            DataServiceFactory factory = new DataServiceFactory(context);
            IDataService dataService = factory.GetDataService(typeof(Project));
            _dataService = dataService as IGenericDataService<Project>;
        }

        [HttpPost("project")]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            try
            {
                return Ok(await _dataService.AddAsync(project));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("project")]
        public async Task<ActionResult> DeleteProject(Project project)
        {
            try
            {
                await _dataService.DeleteAsync(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("project")]
        public async Task<ActionResult> EditProject(Project project)
        {
            try
            {
                await _dataService.EditAsync(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Project>>> GetProject()
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
        public async Task<ActionResult<Project>> GetProject(int id)
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