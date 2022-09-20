namespace Assignment2.Models.ViewModels
{
    public class BrokerageAndClientViewModel
    {
        // one client with many brokerages
       public Client Client { get; set; }
        public ICollection<Brokerage> Brokerages { get; set; }
        public bool isMember;
    }
}
