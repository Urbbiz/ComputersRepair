using ComputerRepair.Enteties;

namespace ComputerRepair.Dtos
{
    public class EmployeeGetDto
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public ICollection<Computer>? Computers { get; set; }
       

     
    }
}