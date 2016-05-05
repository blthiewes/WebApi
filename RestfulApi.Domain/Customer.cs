using System;

namespace RestfulApi.Domain
{
    [Serializable]
    public class Customer : Party
    {
        public Branch OwningBranch { get; set; }
        public Address Address { get; set; }
        public Employee SalesRep { get; set; }
        public Employee SecondSalesRep { get; set; }
        public int? PrimaryBillToReferenceNumTypeRDN { get; set; }
        public int? PrimaryCustomerReferenceNumTypeRDN { get; set; }
    }
}
