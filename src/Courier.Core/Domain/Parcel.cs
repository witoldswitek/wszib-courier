﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Courier.Core.Domain
{
    class Parcel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public DateTime SendAt { get; private set; }
        public DateTime? ReceivedAt { get; private set; } // ? means it can be NULL
        public Address SenderAddress { get; private set; }
        public Address ReceiverAddress { get; private set; }
        public ParcelStatus Status { get; private set; }


        public Parcel(Guid id, string name, User sender, User receiver, Address senderAddress, Address receiverAddress)
        {
            Id = id;
            Name = name;
            SenderId = sender.Id;
            ReceiverId = receiver.Id;
            SendAt = DateTime.UtcNow;
            SenderAddress = senderAddress;
            ReceiverAddress = receiverAddress;
            Status = ParcelStatus.Sent;
        }
    }
}
