namespace Core.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; }
        public EnumCity City { get; set; }
        public string PhoneNumber { get; set; }
    }
}