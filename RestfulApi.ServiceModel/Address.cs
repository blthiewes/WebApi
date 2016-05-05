namespace RestfulApi.ServiceModel
{
    /// <summary>
    /// Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address Line 1
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Address Line 2
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// State/Province
        /// </summary>
        public string StateProvince { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// County
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        public double? Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        public double? Longitude { get; set; }
        /// <summary>
        /// Address Number
        /// </summary>
        public int? AddressNumber { get; set; }
        /// <summary>
        /// Formatted Address
        /// </summary>
        public string FormattedAddress { get; set; }
    }
}
