using APISystem.Entity;
using UniAPISystem.Controllers;
using UniAPISystem.DtoModels;

namespace UniAPISystem.Interface
{
    public interface IStudentService
    {
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentiAsync();
        Task AddStudentAsync(StudentCreateDto studentDto);
        Task GetStudentWithPredmetiAsync(int id);
    }
}
