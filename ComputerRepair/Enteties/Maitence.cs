namespace ComputerRepair.Enteties
{
    public class Maitence
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public DateTime Date { get; set; }
        public Computer Computer { get; set; }
    }
}
