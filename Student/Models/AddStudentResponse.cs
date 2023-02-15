using System;
namespace Student.Models
{
	public class AddStudentResponse
	{
		public AddStudentResponse()
		{
			
		}

		public int StudentId { get; set; }
		public string TransactionId { get; set; }
		public bool Status { get; set; }
    }
}

