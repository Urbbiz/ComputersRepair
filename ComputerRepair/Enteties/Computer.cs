namespace ComputerRepair.Enteties
{
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime IssueDate { get; set; }
        public ICollection<Maitence> Maitences { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
