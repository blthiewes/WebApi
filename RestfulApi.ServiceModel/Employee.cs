using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.ServiceModel
{
    public class Employee
    {
        public string PartyCode { get; set; }
        public int PartyNumber { get; set; }
        public Branch Branch { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}
