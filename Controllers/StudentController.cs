using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapp.Data;
using testapp.Dtos;
using testapp.Models;

namespace testapp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private AppDbContext _AppDbContext;
        public StudentController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpGet("getAllStudets")]
        public ActionResult<ResponseData<List<Students>>> Get()
        {
            var values = _AppDbContext.Students.ToList();
            return Ok(new ResponseData<List<Students>> { ResponseCode = 200, Data = values, ResponseMessage = "successfully retrieved all teachers" });
        }

        [HttpPost("RegisterStudent")]
        public ActionResult<ResponseData<StudentDto>> Post([FromBody] StudentDto request)
        {
            DateTime dDate;
            if (DateTime.TryParse(request.DateofBirth, out dDate))
            {

                DateTime now = DateTime.Today;
                DateTime bdate = Convert.ToDateTime(request.DateofBirth);
                int age = now.Year - bdate.Year;
                if (age < 21)
                {

                    var NewStudent = new Students
                    {
                        DateofBirth = request.DateofBirth,
                        Name = request.Name,
                        Surname = request.Surname,
                        NationalIDNumber = request.NationalIDNumber,
                        StudentNumber = request.StudentNumber,  
                     
                    };

                    _AppDbContext.Students.Add(NewStudent);
                    _AppDbContext.SaveChanges();
                    return Ok(new ResponseData<StudentDto> { Data = request, ResponseCode = 200, ResponseMessage = "successfully added" });
                }
                else
                {
                    return Ok(new ResponseData<dynamic> { Data = null, ResponseCode = 502, ResponseMessage = "Student age should below 21" });
                }

            }
            else
            {

                return BadRequest(new ResponseData<dynamic> { Data = null, ResponseCode = 501, ResponseMessage = "invalid date format" });
            }
        }


    }
}
