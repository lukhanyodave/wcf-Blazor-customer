using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Rtt.Data
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void AddCustomer(CustomerContract customer);
        [OperationContract]
        void UpdateCustomer(CustomerContract customer);

        [OperationContract]
        List<CustomerContract> GetAll();

        [OperationContract]
        CustomerContract GetById(Guid Id);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CustomerContract
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string  Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string ResidentialAddress { get; set; }
        [DataMember]
        public string WorkAddress { get; set; }
        [DataMember]
        public string PostalAddress { get; set; }
        [DataMember]
        public string  Cell { get; set; }
        [DataMember]
        public string WorkNumber { get; set; }

    }
}
