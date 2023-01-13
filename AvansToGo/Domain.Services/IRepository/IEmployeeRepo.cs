namespace Core.Domain.Services.IRepository
{
    public interface IEmployeeRepo
    {
        //Create

        //Read
        IQueryable<Employee> GetAll();
        Employee GetEmployeeByEmail(string employee);
        //Update

        //Delete
    }
}
