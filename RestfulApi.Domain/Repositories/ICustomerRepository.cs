using System.Collections.Generic;

namespace RestfulApi.Domain.Repositories
{
    public interface ICustomerRepository
    {

        Customer GetByPartyNumber(int id);
        Customer GetByCustomerCode(string code);
        List<Customer> SearchCustomers(string term, int offset, int limit, out int total);
        string GetBOLComment(string partyNumberOrCode);
    }
}
