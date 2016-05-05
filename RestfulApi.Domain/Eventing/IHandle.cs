namespace RestfulApi.Domain.Eventing
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
