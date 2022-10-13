using MediatR;
using System;

namespace AccountLedger.SharedKernel
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }

    public abstract class BaseCreatedDate 
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}