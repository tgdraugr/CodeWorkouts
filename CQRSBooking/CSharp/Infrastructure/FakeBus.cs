using System;
using System.Collections.Generic;
using Core.Abstractions;

namespace Infrastructure
{
    public class FakeBus : ICommandSender, IEventPublisher, IMessageSubscriber
    {
        private readonly IDictionary<Type, IList<Action<IMessage>>> handlersPerType =
            new Dictionary<Type, IList<Action<IMessage>>>();

        public void Subscribe<T>(Action<T> handle) where T : IMessage
        {
            if (!handlersPerType.TryGetValue(typeof(T), out IList<Action<IMessage>> handlers))
            {
                handlers = new List<Action<IMessage>>();
                handlersPerType.Add(typeof(T), handlers);
            }

            handlers.Add(x => handle.Invoke((T)x));
        }

        public void Publish<T>(T @event) where T : IEvent => CallHandlers(@event);

        public void Send<T>(T command) where T : ICommand => CallHandlers(command);

        private void CallHandlers(IMessage message)
        {
            if (!handlersPerType.TryGetValue(message.GetType(), out IList<Action<IMessage>> handlers))
                return;

            foreach (var handler in handlers)
            {
                handler.Invoke(message);
            }
        }
    }
}
