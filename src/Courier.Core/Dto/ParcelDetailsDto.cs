using System;
using System.Collections.Generic;
using System.Text;

namespace Courier.Core.Dto
{
    public class ParcelDetailsDto :ParcelDto
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime? ReceivedAt { get; set; }
    }
}
