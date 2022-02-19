namespace ComputerRepair.Enteties
{
    public class Computer
    {
        public Computer()
        {
            Maintenances = new List<Maintenance>();
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public DateTime IssueDate { get; set; }
        public ICollection<Maintenance> Maintenances { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
