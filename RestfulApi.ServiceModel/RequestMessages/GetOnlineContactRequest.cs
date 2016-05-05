namespace RestfulApi.ServiceModel.RequestMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class GetOnlineContactRequest
    {

        /// <summary>
        /// Party Code
        /// </summary>
        public string PartyCode { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserName { get; set; }
    }
}
