using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public interface IStudentsRepository
    {
        public void Insert(StudentDetails stud);
        public void Delete(long id);
        public void Update(long id, StudentDetails stud);
        public IEnumerable<StudentDetails> GetAllDetails();
        public StudentDetails GetbyID(long StudentID);
    }
}
