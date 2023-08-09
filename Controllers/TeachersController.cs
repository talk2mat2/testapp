using Microsoft.AspNetCore.Mvc;
using testapp.Data;
using testapp.Dtos;
using testapp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private AppDbContext _AppDbContext;

        public TeachersController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpGet("getAllTeachers")]
        public ActionResult<ResponseData<Teachers>>  Get()
        {
            var values= _AppDbContext.Teachers.ToList();
            return Ok(new ResponseData<Teachers> { ResponseCode = 200, Data = values, ResponseMessage = "successfully retrieved all teachers" });
        }

     
        [HttpPost("RegisterTeacher")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
