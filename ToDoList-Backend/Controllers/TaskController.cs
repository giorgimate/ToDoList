using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList_Backend.Context;
using ToDoList_Backend.Models;

namespace ToDoList_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ToDoListDbContext _dbContext;

        public TaskController(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var result = await _dbContext.Tasks.ToListAsync();
                var Response = new
                {
                    res = result,
                    statusCode = 200,
                    message = "success"
                };
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            //var result = await _dbContext.Tasks.SingleOrDefaultAsync(x => x.Id == id);
            //return Ok(result);
            try
            {

                var result = await _dbContext.Tasks.SingleOrDefaultAsync(x => x.Id == id);
                var Response = new
                {
                    res = result,
                    statusCode = 200,
                    message = "success"
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Create(TaskCreateModel task)
        {
            try
            {


                TaskModel tsk = new TaskModel
                {
                    Name = task.Name,
                    IsFinished = task.IsFinished,
                };
                var result = await _dbContext.Tasks.AddAsync(tsk);
                await _dbContext.SaveChangesAsync();
                var response = new
                {
                    statusCode = 200,
                    message = "success"
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(TaskModel task)
        {
            try
            {


                var result = await _dbContext.Tasks.SingleOrDefaultAsync(x => x.Id == task.Id);
                result.IsFinished = task.IsFinished;
                result.Name = task.Name;
                await _dbContext.SaveChangesAsync();
                var response = new
                {
                    statusCode = 200,
                    message = "success"
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {


                var result = await _dbContext.Tasks.SingleOrDefaultAsync(x => x.Id == id);
                _dbContext.Tasks.Remove(result);
                await _dbContext.SaveChangesAsync();
                var response = new
                {
                    statusCode = 200,
                    message = "success"
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
