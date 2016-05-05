namespace RestfulApi.Domain.Repositories
{
    public interface IContactRepository
    {
        Contact GetOnlineContact(string partyCode);
    }
}
