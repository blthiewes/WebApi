﻿using System;

namespace RestfulApi.Domain
{
    [Serializable]
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? AddressNumber { get; set; }
        public string FormattedAddress { get; set; }
    }
}
