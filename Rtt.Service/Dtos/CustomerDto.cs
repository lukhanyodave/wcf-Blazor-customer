using System.Runtime.Serialization;

namespace Rtt.Service.Dtos
{
    public  class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
       
        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
       
        public string ResidentialAddress { get; set; } = string.Empty;
       
        public string WorkAddress { get; set; } = string.Empty;
       
        public string PostalAddress { get; set; } = string.Empty;
       
        public string Cell { get; set; } = string.Empty;
      
        public string WorkNumber { get; set; } = string.Empty;  

    }
}
