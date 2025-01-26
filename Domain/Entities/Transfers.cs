using System;
using Domain.Enum;

namespace Domain.Entities;

public class Transfers : Base
{
    public decimal Value { get; set; }
    public TransferType Type { get; set; }

    public long AccountOriginId { get; set; } // ID da conta de origem
    public Account AccountOrigin { get; set; } = default!;

    public long AccountDestinationId { get; set; } // ID da conta de destino
    public Account AccountDestination { get; set; } = default!;
}
