using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApiPOC.Data;
using StudentApiPOC.Model;

namespace StudentApiPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentDataContext _studDb;

        public StudentController(StudentDataContext studDb)
        {
            _studDb = studDb;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studDb.Students.Include(s => s.Subjects));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var student = _studDb.Students.Include(s => s.Subjects).SingleOrDefault(s => s.Id == Id);
            if (student == null)
            {
                return BadRequest("Student Not Found");
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student obj)
        {

            _studDb.Students.Add(obj);
            _studDb.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Student obj, int id)
        {
            var student = _studDb.Students.Include(s => s.Subjects).SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return BadRequest("Student Not Found");
            }
            else
            {
                _studDb.Entry<Student>(obj).State = EntityState.Modified;
                _studDb.SaveChanges();
                return Ok();
            }
        }

    }
}
