using System.Collections.Generic;

namespace RestfulApi.ServiceModel.ResponseMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class GetOnlineContactResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int PartyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// List of error messages from Orion
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
