﻿namespace ComputerRepair.Enteties
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public ICollection<Computer> Computers { get; set; }
    }
}
