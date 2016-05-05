using System;

namespace RestfulApi.Domain
{
    [Serializable]
    public class Branch
    {
        public string PartyCode { get; set; }
        public int PartyNumber { get; set; }
    }
}
