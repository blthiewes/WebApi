using System;
using System.Collections.Generic;

namespace RestfulApi.Domain.Eventing
{
    public static class DomainEventDispatcher
    {

        [ThreadStatic]
        private static List<Delegate> actions;

        public static Func<Type, Array> Resolver { get; private set; }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void SetResolver(Func<Type, Array> resolver)
        {
            Resolver = resolver;
        }


        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Resolver != null)
            {
                foreach (IHandle<T> handler in Resolver(typeof(IHandle<T>)))
                {
                    handler.Handle(args);
                }
            }
            if (actions != null)
            {
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
            }
        }
    }
}
