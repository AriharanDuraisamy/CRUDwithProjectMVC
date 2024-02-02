using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly Dbcontxt _contxt;
        public StudentsRepository(Dbcontxt contxt)
        {
            _contxt = contxt;

        }
        public void Insert(StudentDetails stud)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"exec Insertdetail '{stud.Name}','{stud.DOB}',{stud.Age},'{stud.Gender}',{stud.MobileNum} ,'{stud.Emailid}','{stud.Subject}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Update(long id, StudentDetails stud)
        {
            try
            {
                var result = _contxt.Database.ExecuteSqlRaw($" update StudDetail set Name='{stud.Name}',DOB='{stud.DOB}',Age={stud.Age},Gender='{stud.Gender}',MobileNum='{stud.MobileNum}', Emailid='{stud.Emailid}',Subject='{stud.Subject}' where StudentID={id} ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(long studentid)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"delete StudDetail where StudentID={studentid}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<StudentDetails> GetAllDetails()
        {
            try
            {
                var result = _contxt.StudDetail.FromSqlRaw("select * from StudDetail").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public StudentDetails GetbyID(long studentid)
        {
            try
            {
                var result = _contxt.StudDetail.FromSqlRaw<StudentDetails>($"select * from StudDetail where StudentID={studentid}");
                return result.ToList().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
