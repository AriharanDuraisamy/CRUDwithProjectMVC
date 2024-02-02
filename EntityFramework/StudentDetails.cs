using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework
{
    public class StudentDetails
    {
        public StudentDetails()
        {
            Subject = "-1";
            DOB = DateTime.Now;
        }


        [Key]
        public long StudentID { get; set; }
        public string Name { get; set; }
        public DateTime DOB  { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long MobileNum { get; set; }
        public string Emailid { get; set; }
        public string Subject { get; set; }
    }
}

