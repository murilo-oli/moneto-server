using System;
using Domain.Enum;

namespace Domain.Entities;

public class Transfers : Base
{
    public decimal Value { get; set; }
    public TransferType Type { get; set; }

    public long AccountOriginId { get; set; }
    public Account AccountOrigin { get; set; } = default!;

    public long AccountDestinationId { get; set; }
    public Account AccountDestination { get; set; } = default!;
}
