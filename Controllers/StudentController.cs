using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapp.Data;
using testapp.Dtos;
using testapp.Models;

namespace testapp.Controllers
{
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
    }
}
