using System;

namespace Core.Abstractions
{
    public interface IMessageSubscriber
    {
        void Subscribe<T>(Action<T> handle) where T : IMessage;
    }
}
