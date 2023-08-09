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
        public ActionResult<ResponseData<dynamic>> Post([FromBody] TeachetsDto request)
        {
        
            DateTime dDate;
            if (DateTime.TryParse(request.DateOfBirth, out dDate))
            {
           
                DateTime now = DateTime.Today;
                DateTime bdate= Convert.ToDateTime(request.DateOfBirth);
                int age = now.Year - bdate.Year;
                if(age > 21)
                {

                    var NewTeacher = new Teachers 
                    { DateOfBirth = request.DateOfBirth,
                    Name = request.Name, NationalIDnumber = request.NationalIDnumber,
                    Salary = request.Salary, Title = request.Title, Surname = request.Surname,
                    TeacherNumber = request.TeacherNumber };

                    _AppDbContext.Teachers.Add(NewTeacher);
                    _AppDbContext.SaveChanges();
                  return Ok(new ResponseData<TeachetsDto> { Data =request, ResponseCode = 200, ResponseMessage = "successfully added" });
                }
                else
                {
                    return Ok(new ResponseData<dynamic> { Data = null, ResponseCode = 502, ResponseMessage = "Teachers age should above 21" });
                }
             
            }
            else
            {
              
                return BadRequest(new ResponseData<dynamic> { Data = null, ResponseCode = 501, ResponseMessage = "invalid date format" });
            }

          
        }

       

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
