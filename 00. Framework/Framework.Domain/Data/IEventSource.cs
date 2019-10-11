using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.Data
{
    public interface IEventSource
    {
        void Save<TEvent>(string aggregateName, string streamId, IEnumerable<TEvent> events) where TEvent : IEvent;
    }
}
