using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courier.Core.Commands
{
    public class CreateParcel : ICommands
    {
        public string Name { get; }
        public Guid SenderId { get; }
        public Guid ReceiverId { get; }
        public string ReceiverAddress { get; }

        [JsonConstructor]
        public CreateParcel(string name, Guid senderId, Guid receiverId, string receiverAddress)
        {
            Name = name;
            SenderId = senderId;
            ReceiverId = receiverId;
            ReceiverAddress = receiverAddress;
        }
    }
}
