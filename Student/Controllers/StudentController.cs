using System;
using Microsoft.AspNetCore.Mvc;
using Student.DAL;
using Student.Models;

namespace Student.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private DataAccess _dataAccess;
		public StudentController(DataAccess dataAccess)
		{
            _dataAccess = dataAccess;

        }

        [HttpPost]
        [Route("api/Student/Add")]
        public AddStudentResponse Add([FromBody] StudentInfo studentInfo)
        {
            var transActionId = Guid.NewGuid().ToString();
            var studentId = _dataAccess.AddStudent(studentInfo, transActionId);
            var status = studentId > 0 ? true : false;
            var addStudentResponse = new AddStudentResponse
            {
                StudentId = studentId,
                TransactionId = transActionId,
                Status = status,
            };
            return addStudentResponse;
            
        }

        [HttpGet]
        [Route("api/Student/Get")]
        public StudentInfo Get(int id)
        {
           var studentInfo = _dataAccess.GetStudent(id);
            return studentInfo;

        }

	}
}

