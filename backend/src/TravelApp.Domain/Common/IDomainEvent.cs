using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Domain.Common
{
    public interface IDomainEvent
    {
        DateTime OccurredOnUtc { get; }
    }
}