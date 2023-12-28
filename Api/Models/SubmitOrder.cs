using MessageContracts.Commands;

namespace Api.Models
{
    public class SubmitOrder : ISubmitOrderCommand
    {
        public int OrderId { get; set; }

        public required string OrderCode { get; init; }
    }
}
