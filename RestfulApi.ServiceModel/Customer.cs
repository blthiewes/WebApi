namespace RestfulApi.ServiceModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Customer : Party
    {
        /// <summary>
        /// 
        /// </summary>
        public Branch OwningBranch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Employee SalesRep { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UseSupplierCatalog { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UseSupplierLocation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PrimaryBillToReferenceNumTypeRDN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PrimaryCustomerReferenceNumTypeRDN { get; set; }
    }
}