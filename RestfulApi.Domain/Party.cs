using System;

namespace RestfulApi.Domain
{
    [Serializable]
    public class Party
    {
        public string Name { get; set; }
        public string PartyCode { get; set; }
        public int PartyNumber { get; set; }
    }
}
