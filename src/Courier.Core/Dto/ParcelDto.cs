using System;
using System.Collections.Generic;
using System.Text;

namespace Courier.Core.Dto
{
    public class ParcelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SendAt { get; set; }
        public bool Received { get; set; }
    }
}
