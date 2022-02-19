namespace ComputerRepair.Enteties
{
    public class Employee
    {
        public Employee() 
        {
            Computers = new List<Computer>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public ICollection<Computer> Computers { get; set; }
    }
}
