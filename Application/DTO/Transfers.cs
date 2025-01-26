using System;
using Domain.Enum;

namespace Application.DTO;

public class TransfersDto
{
    public long Id { get; set; }
    public decimal Value { get; set; }
    public TransferType Type { get; set; }
    public long AccountOriginId { get; set; }
    public long AccountDestinationId { get; set; }
}