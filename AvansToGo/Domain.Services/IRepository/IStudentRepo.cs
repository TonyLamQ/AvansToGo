namespace Core.Domain.Services.IRepository
{
    public interface IStudentRepo
    {
        //Create

        //Read
        IQueryable<Student> GetAll();
        Student GetStudentByEmail(string Student);
        //Update

        //Delete
    }
}
