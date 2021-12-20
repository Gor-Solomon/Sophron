namespace Sophron.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Machine> Machines { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}