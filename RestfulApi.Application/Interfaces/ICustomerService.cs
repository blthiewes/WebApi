using RestfulApi.ServiceModel;
using RestfulApi.ServiceModel.RequestMessages;


namespace RestfulApi.Application.Interfaces
{
    public interface ICustomerService
    {
        Customer GetByPartyNumber(int partyNumber);

        Customer GetByCustomerCode(string customerCode);

        PagedCollection<Customer> SearchCustomers(string term, int offset, int limit);

        string GetBOLComment(string partyLocationOrCode);

        Contact GetOnlineContact(GetOnlineContactRequest request);
    }
}
