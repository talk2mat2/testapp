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
        public ActionResult<ResponseData<List<Teachers>>>  Get()
        {
            var values= _AppDbContext.Teachers.ToList();
            return Ok(new ResponseData<List<Teachers>> { ResponseCode = 200, Data =values, ResponseMessage = "successfully retrieved all teachers" });
        }

     
        [HttpPost("RegisterTeacher")]
        public ActionResult<ResponseData<TeachetsDto>> Post([FromBody] TeachetsDto value)
        {

            return Ok(new ResponseData<TeachetsDto> { Data = value, ResponseCode = 200, ResponseMessage = "successfully added" });
        }

       

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
