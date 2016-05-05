using System;

namespace RestfulApi.Domain
{
    [Serializable]
    public class Contact
    {
        public int PartyID { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneDialingCode { get; set; }
        public string PhoneCountryCode { get; set; }
    }
}
