using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.ServiceModel
{
    /// <summary>
    /// Contact Details
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PartyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        public string PhoneDialingCode { get; set; }
        public string PhoneCountryCode { get; set; }
    }
}
